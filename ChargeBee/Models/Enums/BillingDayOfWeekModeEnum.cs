namespace RealArtists.ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum BillingDayOfWeekModeEnum {
    Unknown,

    [Description("using_defaults")]
    UsingDefaults,

    [Description("manually_set")]
    ManuallySet,
  }
}
