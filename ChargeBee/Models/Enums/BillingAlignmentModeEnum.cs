namespace RealArtists.ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum BillingAlignmentModeEnum {
    Unknown,

    [Description("immediate")]
    Immediate,

    [Description("delayed")]
    Delayed,
  }
}
