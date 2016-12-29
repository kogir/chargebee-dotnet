namespace Kogir.ChargeBee.Api {
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading.Tasks;

  public class ListRequestBase<U> where U : ListRequestBase<U> {
    private ChargeBeeApi _api;
    private string _url;

    protected HttpMethod _method = HttpMethod.Get;
    protected Params _params = new Params();
    protected Dictionary<string, string> _headers = new Dictionary<string, string>();

    public ListRequestBase(ChargeBeeApi api, string url) {
      _api = api;
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
      _headers.Add(headerName, headerValue);
      return (U)this;
    }

    public Task<ListResult> Request() {
      return _api.GetList(_url, _params, _headers);
    }

    public Params Params() {
      return _params;
    }

  }
}
