namespace ChargeBee.Exceptions {
  using System.Collections.Generic;
  using System.Net;
  using ChargeBee.Api;

  public class InvalidRequestException : ApiException {
    public InvalidRequestException(HttpStatusCode httpStatusCode, Dictionary<string, string> errorJson)
      : base(httpStatusCode, errorJson) {
    }
  }
}

