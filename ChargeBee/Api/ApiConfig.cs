namespace ChargeBee.Api {
  using System;
  using System.Net.Http.Headers;
  using System.Text;

  public sealed class ApiConfig {
    public const string Version = "2.2.1";
    public const string ApiVersion = "v2";

    private static ApiConfig _instance;

    public Uri ApiBase { get; set; }
    public AuthenticationHeaderValue AuthenticationHeader { get; set; }

    private ApiConfig(string siteName, string apiKey) {
      if (string.IsNullOrEmpty(siteName)) {
        throw new ArgumentException("Site name can't be empty!");
      }

      if (string.IsNullOrEmpty(apiKey)) {
        throw new ArgumentException("Api key can't be empty!");
      }

      ApiBase = new Uri($"https://{siteName}.chargebee.com/api/{ApiVersion}");
      AuthenticationHeader = new AuthenticationHeaderValue(
        "Basic",
        Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:")));
    }

    public static void Configure(string siteName, string apiKey) {
      _instance = new ApiConfig(siteName, apiKey);
    }

    public static ApiConfig Instance {
      get {
        if (_instance == null) {
          throw new ApplicationException("Not yet configured!");
        }

        return _instance;
      }
    }
  }
}
