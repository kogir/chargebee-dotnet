namespace RealArtists.ChargeBee.Api {
  public class ListRequest : ListRequestBase<ListRequest> {
    public ListRequest(ChargeBeeApi api, string url) : base(api, url) {
    }
  }
}
