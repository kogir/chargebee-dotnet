namespace ChargeBee {
  using System;
  using System.Collections.Generic;
  using System.Net;
  using System.Runtime.Serialization;
  using System.Security.Permissions;

  [Serializable]
  public class InvalidRequestException : ApiException {
    public InvalidRequestException() {
    }

    public InvalidRequestException(string message) : base(message) {
    }

    public InvalidRequestException(string message, Exception innerException) : base(message, innerException) {
    }

    public InvalidRequestException(HttpStatusCode httpStatusCode, Dictionary<string, string> errorResp)
      : base(httpStatusCode, errorResp) {
    }

    [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    protected InvalidRequestException(SerializationInfo info, StreamingContext context)
      : base(info, context) {
    }
  }
}

