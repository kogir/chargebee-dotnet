namespace ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum PriceTypeEnum {

    /// <summary>
    /// Indicates unexpected value for this enum. You can get this when there is a
    /// dotnet-client version incompatibility. We suggest you to upgrade to the latest version
    /// </summary>
    [Description("Unexpected Value")]
    Unknown,

    [Description("tax_exclusive")]
    TaxExclusive,

    [Description("tax_inclusive")]
    TaxInclusive,
  }
}
