namespace RealArtists.ChargeBee {
  using System;
  using System.Collections.Generic;
  using System.Net;
  using System.Runtime.Serialization;
  using System.Security.Permissions;

  [Serializable]
  public class ApiException : Exception {
    public string ErrorCode { get; private set; }
    public string ErrorParam { get; private set; }
    public string ErrorType { get; private set; }
    public HttpStatusCode HttpStatusCode { get; private set; }

    public ApiException() {
    }

    public ApiException(string message) : base(message) {
    }

    public ApiException(string message, Exception innerException) : base(message, innerException) {
    }

    [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context) {
      ErrorCode = info.GetString("ErrorCode");
      ErrorParam = info.GetString("ErrorParam");
      ErrorType = info.GetString("ErrorType");
      HttpStatusCode = (HttpStatusCode)info.GetInt32("HttpStatusCode");
    }

    public ApiException(HttpStatusCode httpStatusCode, Dictionary<string, string> errorResp)
      : base(errorResp["message"]) {
      HttpStatusCode = httpStatusCode;

      if (errorResp.ContainsKey("api_error_code")) {
        ErrorCode = errorResp["api_error_code"];
      }

      if (errorResp.ContainsKey("param")) {
        ErrorParam = errorResp["param"];
      }

      if (errorResp.ContainsKey("type")) {
        ErrorType = errorResp["type"];
      }
    }

    [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    public override void GetObjectData(SerializationInfo info, StreamingContext context) {
      info.AddValue("ErrorCode", ErrorCode);
      info.AddValue("ErrorParam", ErrorParam);
      info.AddValue("ErrorType", ErrorType);
      info.AddValue("HttpStatusCode", (int)HttpStatusCode);
      base.GetObjectData(info, context);
    }
  }
}
