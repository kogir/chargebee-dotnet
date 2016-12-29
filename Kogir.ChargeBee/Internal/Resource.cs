namespace Kogir.ChargeBee.Internal {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Linq;
  using System.Net;
  using Kogir.ChargeBee.Api;
  using Newtonsoft.Json.Linq;

  public class Resource : JSONSupport {
    public Resource() { }

    internal Resource(string json) {
      if (!string.IsNullOrEmpty(json))
        _jobj = JToken.Parse(json);
    }

    internal Resource(JToken jobj) {
      _jobj = jobj;
    }

    public T GetValue<T>(string key, bool required = true) {
      if (required)
        ThrowIfKeyMissed(key);

      if (_jobj[key] == null)
        return default(T);

      return _jobj[key].ToObject<T>();
    }

    public DateTime? GetDateTime(string key, bool required = true) {
      long? ts = GetValue<long?>(key, required);
      if (ts == null)
        return null;
      return EpochUtility.ToDateTime((int)ts);
    }

    public JToken GetJToken(string key, bool required = true) {
      if (required)
        ThrowIfKeyMissed(key);

      if (_jobj[key] == null)
        return null;

      return JToken.Parse(_jobj[key].ToString());
    }

    public T GetEnum<T>(string key, bool required = true) {
      string value = GetValue<string>(key, required);
      if (string.IsNullOrEmpty(value))
        return default(T);

      Type eType = typeof(T);

      // Handle nullable enum
      if (eType.IsGenericType)
        eType = eType.GetGenericArguments()[0];

      foreach (var fi in eType.GetFields()) {
        DescriptionAttribute[] attrs =
          (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attrs.Length == 0)
          continue;

        if (value == attrs[0].Description)
          return (T)fi.GetValue(null);
      }

      return default(T);
    }

    protected void ThrowIfKeyMissed(string key) {
      if (_jobj[key] == null)
        throw new ArgumentException(string.Format("The property {0} is not present!", key));
    }

    protected List<T> GetResourceList<T>(string property) where T : Resource, new() {
      if (_jobj == null)
        return null;

      JToken jobj = _jobj[property];
      if (jobj == null)
        return null;

      List<T> list = new List<T>();
      foreach (var item in jobj.Children()) {
        T t = new T() {
          JObj = item
        };
        list.Add(t);
      }

      return list;
    }

    protected List<T> GetList<T>(string property) {
      if (_jobj == null)
        return null;

      JToken jobj = _jobj[property];
      if (jobj == null)
        return null;

      List<T> list = new List<T>();
      foreach (var item in jobj.Children()) {
        list.Add(item.ToObject<T>());
      }

      return list;
    }

    protected T GetSubResource<T>(string property) where T : Resource, new() {
      if (_jobj == null)
        return null;

      JToken jobj = _jobj[property];
      if (jobj == null)
        return null;
      T t = new T() {
        JObj = jobj
      };
      return t;
    }

    protected static void apiVersionCheck(JToken jObj) {
      if (jObj["api_version"] == null) {
        return;
      }
      string apiVersion = jObj["api_version"].ToString().ToUpper();
      if (!apiVersion.Equals(ChargeBeeApi.Version, StringComparison.OrdinalIgnoreCase)) {
        throw new ArgumentException("API version [" + apiVersion + "] in response does not match "
          + "with client library API version [" + ChargeBeeApi.Version.ToUpper() + "]");
      }
    }

  }
}
