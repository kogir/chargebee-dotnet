namespace ChargeBee.Api {
  using System.Collections.Generic;
  using System.Net.Http;

  public class ListRequestBase<U> where U : ListRequestBase<U> {
    string _url;
    protected HttpMethod _method = HttpMethod.Get;
    protected Params _params = new Params();
    protected Dictionary<string, string> headers = new Dictionary<string, string>();

    public ListRequestBase(string url) {
      _url = url;
    }

    public U Limit(int limit) {
      _params.AddOpt("limit", limit);
      return (U)this;
    }

    public U Offset(string offset) {
      _params.AddOpt("offset", offset);
      return (U)this;
    }

    public U Header(string headerName, string headerValue) {
      headers.Add(headerName, headerValue);
      return (U)this;
    }

    public ListResult Request(ApiConfig env) {
      return ApiUtil.GetList(_url, _params, headers, ApiConfig.Instance);
    }

    public ListResult Request() {
      return Request(ApiConfig.Instance);
    }

    public Params Params() {
      return _params;
    }

  }
}
