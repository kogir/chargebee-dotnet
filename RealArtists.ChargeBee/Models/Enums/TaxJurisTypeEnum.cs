namespace RealArtists.ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum TaxJurisTypeEnum {
    /// <summary>
    /// Indicates unexpected value for this enum. You can get this when there is a
    /// dotnet-client version incompatibility. We suggest you to upgrade to the latest version
    /// </summary>
    [Description("Unexpected Value")]
    Unknown,

    [Description("country")]
    Country,

    [Description("state")]
    State,

    [Description("county")]
    County,

    [Description("city")]
    City,

    [Description("special")]
    Special,

    [Description("other")]
    Other,
  }
}
