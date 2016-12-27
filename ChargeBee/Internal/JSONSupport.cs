namespace ChargeBee.Internal {
  using Newtonsoft.Json.Linq;

  public class JSONSupport {
    protected JToken m_jobj;

    internal JToken JObj {
      get { return m_jobj; }
      set { m_jobj = value; }
    }
  }
}
