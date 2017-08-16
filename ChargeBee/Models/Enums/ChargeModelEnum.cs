namespace RealArtists.ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum ChargeModelEnum {
    Unknown,

    [Description("full_charge")]
    FullCharge,

    [Description("prorate")]
    Prorate,
  }
}
