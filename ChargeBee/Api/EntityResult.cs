namespace RealArtists.ChargeBee.Api {
  using System.Net;
  using RealArtists.ChargeBee.Internal;

  public class EntityResult : ResultBase {

    public EntityResult(HttpStatusCode statusCode, string json)
        : base(json) {
      StatusCode = statusCode;
    }

    public HttpStatusCode StatusCode { get; private set; }
  }
}
