namespace Kogir.ChargeBee {
  using System;
  using System.Collections.Generic;
  using System.Diagnostics.CodeAnalysis;
  using System.Net;
  using System.Net.Http;
  using System.Net.Http.Headers;
  using System.Text;
  using System.Threading.Tasks;
  using Kogir.ChargeBee.Api;
  using Kogir.ChargeBee.Models;
  using Newtonsoft.Json;

  public class ChargeBeeApi {
    public const string Version = "2.2.1";

    private static HttpClient DefaultHttpClient { get; set; } = CreateHttpClient();

    public Uri ApiBase { get; }
    public string ApiVersion { get; } = "v2";
    public AuthenticationHeaderValue AuthenticationHeader { get; }
    public HttpClient HttpClient { get; }

    // Resource Actions
    public AddonActions Addon { get; }
    public AddressActions Address { get; }
    public CardActions Card { get; }
    public CommentActions Comment { get; }
    public CouponActions Coupon { get; }
    public CouponCodeActions CouponCode { get; }
    public CreditNoteActions CreditNote { get; }
    public CustomerActions Customer { get; }
    public EstimateActions Estimate { get; }
    public EventActions Event { get; }
    public HostedPageActions HostedPage { get; }
    public InvoiceActions Invoice { get; }
    public PlanActions Plan { get; }
    public PortalSessionActions PortalSession { get; }
    public SubScriptionActions Subscription { get; }
    public TransactionActions Transaction { get; }

    private ChargeBeeApi() {
      Addon = new AddonActions(this);
      Address = new AddressActions(this);
      Card = new CardActions(this);
      Comment = new CommentActions(this);
      Coupon = new CouponActions(this);
      CouponCode = new CouponCodeActions(this);
      CreditNote = new CreditNoteActions(this);
      Customer = new CustomerActions(this);
      Estimate = new EstimateActions(this);
      Event = new EventActions(this);
      HostedPage = new HostedPageActions(this);
      Invoice = new InvoiceActions(this);
      Plan = new PlanActions(this);
      PortalSession = new PortalSessionActions(this);
      Subscription = new SubScriptionActions(this);
      Transaction = new TransactionActions(this);
    }

    public ChargeBeeApi(string siteName, string apiKey) : this() {
      if (string.IsNullOrEmpty(siteName)) {
        throw new ArgumentException($"{nameof(siteName)} is required.");
      }

      if (string.IsNullOrEmpty(apiKey)) {
        throw new ArgumentException($"{nameof(apiKey)} is required.");
      }

      ApiBase = new Uri($"https://{siteName}.chargebee.com/api/{ApiVersion}");
      AuthenticationHeader = new AuthenticationHeaderValue(
        "Basic",
        Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:")));
      HttpClient = DefaultHttpClient;
    }

    public ChargeBeeApi(Uri apiBase, string apiKey)
      : this(apiBase,
          new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:"))),
          DefaultHttpClient) { }

    public ChargeBeeApi(Uri apiBase, AuthenticationHeaderValue authHeader)
      : this(apiBase, authHeader, DefaultHttpClient) { }

    public ChargeBeeApi(Uri apiBase, AuthenticationHeaderValue authHeader, HttpClient client) : this() {
      ApiBase = apiBase;
      AuthenticationHeader = authHeader;
      HttpClient = HttpClient;
    }

    private HttpRequestMessage GetRequest(string url, HttpMethod method, Dictionary<string, string> headers) {
      var uri = new Uri(ApiBase, url);
      var request = new HttpRequestMessage(method, uri);

      request.Headers.Authorization = AuthenticationHeader;

      foreach (var entry in headers) {
        request.Headers.Add(entry.Key, entry.Value);
      }

      return request;
    }

    private async Task<HttpResponseMessage> SendRequest(HttpRequestMessage request) {
      var response = await HttpClient.SendAsync(request);
      if (response.IsSuccessStatusCode) {
        return response;
      } else {
        // Try to match old error handling for now. Fix later.
        if (response.Content == null) {
          // Not a chargebe error response.
          response.EnsureSuccessStatusCode();
        }
        var content = await response.Content.ReadAsStringAsync();
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

    private async Task<T> GetJson<T>(string url, Params parameters, Dictionary<string, string> headers, bool IsList, Func<HttpResponseMessage, Task<T>> handler) {
      url = string.Format("{0}?{1}", url, parameters.GetQuery(IsList));
      var request = GetRequest(url, HttpMethod.Get, headers);
      var response = await SendRequest(request);
      return await handler(response);
    }

    public async Task<EntityResult> Post(string url, Params parameters, Dictionary<string, string> headers) {
      var request = GetRequest(url, HttpMethod.Post, headers);
      request.Content = new StringContent(parameters.GetQuery(false), Encoding.UTF8);
      request.Content.Headers.ContentType =
        new MediaTypeHeaderValue("application/x-www-form-urlencoded") {
          CharSet = Encoding.UTF8.WebName,
        };

      var response = await SendRequest(request);
      var json = await response.Content.ReadAsStringAsync();
      return new EntityResult(response.StatusCode, json);
    }

    public async Task<EntityResult> Get(string url, Params parameters, Dictionary<string, string> headers) {
      return await GetJson(url, parameters, headers, false, async (response) => {
        var json = await response.Content.ReadAsStringAsync();
        return new EntityResult(response.StatusCode, json);
      });
    }

    public async Task<ListResult> GetList(string url, Params parameters, Dictionary<string, string> headers) {
      return await GetJson(url, parameters, headers, true, async (response) => {
        var json = await response.Content.ReadAsStringAsync();
        return new ListResult(response.StatusCode, json);
      });
    }

    [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
    public static HttpClient CreateHttpClient() {
      var handler = new WinHttpHandler() {
        AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
        AutomaticRedirection = false,
        CookieUsePolicy = CookieUsePolicy.IgnoreCookies,
      };

      return CreateHttpClient(handler, true);
    }

    [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
    public static HttpClient CreateHttpClient(HttpMessageHandler handler, bool disposeHandler) {
      var httpClient = new HttpClient(handler, disposeHandler);

      var headers = httpClient.DefaultRequestHeaders;
      headers.AcceptEncoding.Clear();
      headers.AcceptEncoding.ParseAdd("gzip");
      headers.AcceptEncoding.ParseAdd("deflate");

      headers.Accept.Clear();
      headers.Accept.ParseAdd("application/json");

      headers.AcceptCharset.Clear();
      headers.AcceptCharset.ParseAdd(Encoding.UTF8.WebName);

      headers.UserAgent.Clear();
      headers.UserAgent.Add(new ProductInfoHeaderValue("ChargeBee.NET", Version));

      return httpClient;
    }
  }
}
