namespace RealArtists.ChargeBee.Internal {
  using Newtonsoft.Json.Linq;

  public class JSONSupport {
    protected JToken _jobj;

    internal JToken JObj {
      get { return _jobj; }
      set { _jobj = value; }
    }
  }
}
