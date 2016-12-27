namespace ChargeBee.Api {
  using System;
  using System.Collections.Generic;
  using System.Net.Http;

  public class EntityRequest<T> {
    string _url;
    protected HttpMethod _method;
    protected Params _params = new Params();
    protected Dictionary<string, string> headers = new Dictionary<string, string>();

    public EntityRequest(string url, HttpMethod method) {
      _url = url;
      _method = method;
    }

    public T Param(string paramName, Object value) {
      _params.Add(paramName, value);
      return (T)Convert.ChangeType(this, typeof(T));
    }

    public T Header(string headerName, string headerValue) {
      headers.Add(headerName, headerValue);
      return (T)Convert.ChangeType(this, typeof(T));
    }

    public EntityResult Request() {
      return Request(ApiConfig.Instance);
    }

    public EntityResult Request(ApiConfig env) {
      switch (_method.Method) {
        case "GET":
          return ApiUtil.Get(_url, _params, headers, env);
        case "POST":
          return ApiUtil.Post(_url, _params, headers, env);
        default:
          throw new NotImplementedException(string.Format(
              "HTTP method {0} is not implemented",
              _method));
      }

    }
  }
}
