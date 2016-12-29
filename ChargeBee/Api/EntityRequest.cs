namespace ChargeBee.Api {
  using System;
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading.Tasks;

  public class EntityRequest<T> {
    private ChargeBeeApi _api;
    private string _url;

    protected HttpMethod _method;
    protected Params _params = new Params();
    protected Dictionary<string, string> _headers = new Dictionary<string, string>();

    public EntityRequest(ChargeBeeApi api, string url, HttpMethod method) {
      _api = api;
      _url = url;
      _method = method;
    }

    public T AddParam(string paramName, object value) {
      _params.Add(paramName, value);
      return (T)Convert.ChangeType(this, typeof(T));
    }

    public T AddHeader(string headerName, string headerValue) {
      _headers.Add(headerName, headerValue);
      return (T)Convert.ChangeType(this, typeof(T));
    }

    public Task<EntityResult> Request() {
      switch (_method.Method) {
        case "GET":
          return _api.Get(_url, _params, _headers);
        case "POST":
          return _api.Post(_url, _params, _headers);
        default:
          throw new NotImplementedException(string.Format(
              "HTTP method {0} is not implemented",
              _method));
      }
    }
  }
}
