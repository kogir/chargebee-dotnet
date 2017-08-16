namespace RealArtists.ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum ReferralSystemEnum {
    Unknown,

    [Description("referral_candy")]
    ReferralCandy,

    [Description("referral_saasquatch")]
    ReferralSaasquatch,

    [Description("friendbuy")]
    Friendbuy,
  }
}
