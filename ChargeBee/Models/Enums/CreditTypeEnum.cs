namespace RealArtists.ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum CreditTypeEnum {
    Unknown,

    [Description("loyalty_credits")]
    LoyaltyCredits,

    [Description("referral_rewards")]
    ReferralRewards,

    [Description("general")]
    General,
  }
}
