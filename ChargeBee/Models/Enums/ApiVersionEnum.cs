namespace ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum ApiVersionEnum {
    /// <summary>
    /// Indicates unexpected value for this enum. You can get this when there is a
    /// dotnet-client version incompatibility. We suggest you to upgrade to the latest version
    /// </summary>
    [Description("Unexpected Value")]
    Unknown,

    [Description("v1")]
    V1,

    [Description("v2")]
    V2,
  }
}
