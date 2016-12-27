namespace ChargeBee.Api {
  using System;
  using System.Collections.Generic;
  using System.Net;

  public class ApiException : ApplicationException {

    private string ErrorType = "";
    private string ErrorParam = "";

    public ApiException(HttpStatusCode httpStatusCode, Dictionary<string, string> errorResp)
      : base(errorResp["message"]) {
      HttpStatusCode = httpStatusCode;
      errorResp.TryGetValue("type", out ErrorType);
      ApiErrorCode = errorResp["api_error_code"];

      errorResp.TryGetValue("param", out ErrorParam);

      //Deprecated fields.
#pragma warning disable CS0618
      ApiCode = errorResp["error_code"];
      ApiMessage = errorResp["error_msg"];
#pragma warning restore CS0618
    }

    public HttpStatusCode HttpStatusCode { get; set; }

    public string Type {
      get {
        return ErrorType;
      }
    }

    public string ApiErrorCode { get; set; }

    public string Param {
      get {
        return ErrorParam;
      }
    }

    [Obsolete("Use HttpStatusCode")]
    public HttpStatusCode HttpCode {
      get {
        return HttpStatusCode;
      }
    }

    [Obsolete("Use Code")]
    public string ApiCode { get; set; }

    [Obsolete("Use Param")]
    public string Parameter {
      get {
        return Param;
      }
    }

    [Obsolete("Use Message")]
    public string ApiMessage { get; set; }

  }
}
