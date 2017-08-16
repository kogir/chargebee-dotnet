namespace RealArtists.ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum BillingDateModeEnum {
    Unknown,

    [Description("using_defaults")]
    UsingDefaults,

    [Description("manually_set")]
    ManuallySet,
  }
}
