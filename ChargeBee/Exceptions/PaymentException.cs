namespace ChargeBee {
  using System;
  using System.Collections.Generic;
  using System.Net;
  using System.Runtime.Serialization;
  using System.Security.Permissions;

  [Serializable]
  public class PaymentException : ApiException {
    public PaymentException() {
    }

    public PaymentException(string message) : base(message) {
    }

    public PaymentException(string message, Exception innerException) : base(message, innerException) {
    }

    public PaymentException(HttpStatusCode httpStatusCode, Dictionary<string, string> errorResp)
      : base(httpStatusCode, errorResp) {
    }

    [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    protected PaymentException(SerializationInfo info, StreamingContext context)
      : base(info, context) {
    }
  }
}
