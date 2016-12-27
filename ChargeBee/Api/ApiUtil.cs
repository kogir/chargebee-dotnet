namespace ChargeBee.Api {
  using System;
  using System.Collections.Generic;
  using System.Diagnostics.CodeAnalysis;
  using System.Net;
  using System.Net.Http;
  using System.Net.Http.Headers;
  using System.Text;
  using ChargeBee.Exceptions;
  using Newtonsoft.Json;

  public static class ApiUtil {
    public static HttpClient HttpClient { get; set; } = CreateGitHubHttpClient();
    private static ProductInfoHeaderValue UserAgent { get; } = new ProductInfoHeaderValue("ChargeBee.net", "1.0.0");

    public static string BuildUrl(params string[] paths) {
      StringBuilder sb = new StringBuilder(ApiConfig.Instance.ApiBaseUrl);

      foreach (var path in paths) {
        sb.Append('/').Append(WebUtility.UrlEncode(path));
      }

      return sb.ToString();
    }

    private static HttpRequestMessage GetRequest(string url, HttpMethod method, Dictionary<string, string> headers, ApiConfig env) {
      var uri = new Uri(url);
      var request = new HttpRequestMessage(method, uri);

      request.Headers.UserAgent.Clear();
      request.Headers.UserAgent.Add(UserAgent);

      request.Headers.Accept.Clear();
      request.Headers.Accept.ParseAdd("application/json");

      request.Headers.AcceptCharset.Clear();
      request.Headers.AcceptCharset.ParseAdd(env.Charset);

      request.Headers.Authorization = AuthenticationHeaderValue.Parse(env.AuthValue);

      foreach (var entry in headers) {
        request.Headers.Add(entry.Key, entry.Value);
      }

      return request;
    }

    private static string SendRequest(HttpRequestMessage request, out HttpStatusCode code) {
      var response = HttpClient.SendAsync(request).GetAwaiter().GetResult();
      code = response.StatusCode;
      if (response.IsSuccessStatusCode) {
        return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
      } else {
        // Try to match old error handling for now. Fix later.
        if (response.Content == null) {
          // Not a chargebe error response.
          response.EnsureSuccessStatusCode();
        }
        var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        try {
          var errorJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
          var type = string.Empty;
          errorJson.TryGetValue("type", out type);
          switch (type) {
            case "payment":
              throw new PaymentException(response.StatusCode, errorJson);
            case "operation_failed":
              throw new OperationFailedException(response.StatusCode, errorJson);
            case "invalid_request":
              throw new InvalidRequestException(response.StatusCode, errorJson);
            default:
              throw new ApiException(response.StatusCode, errorJson);
          }
        } catch (JsonException e) {
          throw new SystemException("Not in JSON format. Probably not a ChargeBee response. \n " + content, e);
        }
      }
    }

    private static string GetJson(string url, Params parameters, ApiConfig env, Dictionary<string, string> headers, out HttpStatusCode code, bool IsList) {
      url = string.Format("{0}?{1}", url, parameters.GetQuery(IsList));
      var request = GetRequest(url, HttpMethod.Get, headers, env);
      return SendRequest(request, out code);
    }

    public static EntityResult Post(string url, Params parameters, Dictionary<string, string> headers, ApiConfig env) {
      var request = GetRequest(url, HttpMethod.Post, headers, env);
      request.Content = new StringContent(parameters.GetQuery(false), Encoding.GetEncoding(env.Charset));
      request.Content.Headers.ContentType =
        MediaTypeHeaderValue.Parse($"application/x-www-form-urlencoded;charset={env.Charset}");

      HttpStatusCode code;
      string json = SendRequest(request, out code);

      EntityResult result = new EntityResult(code, json);
      return result;
    }

    public static EntityResult Get(string url, Params parameters, Dictionary<string, string> headers, ApiConfig env) {
      HttpStatusCode code;
      string json = GetJson(url, parameters, env, headers, out code, false);

      EntityResult result = new EntityResult(code, json);
      return result;
    }

    public static ListResult GetList(string url, Params parameters, Dictionary<string, string> headers, ApiConfig env) {
      HttpStatusCode code;
      string json = GetJson(url, parameters, env, headers, out code, true);

      ListResult result = new ListResult(code, json);
      return result;
    }

    [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
    private static HttpClient CreateGitHubHttpClient() {
      var handler = new WinHttpHandler() {
        AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
        AutomaticRedirection = false,
        CookieUsePolicy = CookieUsePolicy.IgnoreCookies,
      };

      var httpClient = new HttpClient(handler, true);

      var headers = httpClient.DefaultRequestHeaders;
      headers.AcceptEncoding.Clear();
      headers.AcceptEncoding.ParseAdd("gzip");
      headers.AcceptEncoding.ParseAdd("deflate");

      headers.Accept.Clear();
      headers.Accept.ParseAdd("application/json");

      headers.AcceptCharset.Clear();
      headers.AcceptCharset.ParseAdd("utf-8");

      return httpClient;
    }
  }
}
