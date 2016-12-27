namespace ChargeBee {
  using System;
  using System.Collections.Generic;
  using System.Net;
  using System.Runtime.Serialization;
  using System.Security.Permissions;

  [Serializable]
  public class OperationFailedException : ApiException {
    public OperationFailedException() {
    }

    public OperationFailedException(string message) : base(message) {
    }

    public OperationFailedException(string message, Exception innerException) : base(message, innerException) {
    }

    public OperationFailedException(HttpStatusCode httpStatusCode, Dictionary<string, string> errorJson)
      : base(httpStatusCode, errorJson) {
    }

    [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    protected OperationFailedException(SerializationInfo info, StreamingContext context)
      : base(info, context) {
    }
  }
}

