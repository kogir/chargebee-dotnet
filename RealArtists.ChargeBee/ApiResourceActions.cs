namespace RealArtists.ChargeBee {
  using System;
  using System.Linq;
  using System.Net;

  public class ApiResourceActions {
    protected ChargeBeeApi Api { get; private set; }

    public ApiResourceActions(ChargeBeeApi api) {
      Api = api;
    }

    public string BuildUrl(params string[] paths) {
      if (paths.Any(x => string.IsNullOrWhiteSpace(x))) {
        throw new ArgumentException("Uri path elements cannot be null or empty.", nameof(paths));
      }
      return string.Join("/", paths.Select(x => WebUtility.UrlEncode(x)));
    }
  }
}
