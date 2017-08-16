namespace RealArtists.ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum ReferrerRewardTypeEnum {
    Unknown,

    [Description("none")]
    None,

    [Description("referral_direct_reward")]
    ReferralDirectReward,

    [Description("custom_promotional_credit")]
    CustomPromotionalCredit,

    [Description("custom_revenue_percent_based")]
    CustomRevenuePercentBased,
  }
}
