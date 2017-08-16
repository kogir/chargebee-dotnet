namespace RealArtists.ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum FriendOfferTypeEnum {
    Unknown,

    [Description("none")]
    None,

    [Description("coupon")]
    Coupon,

    [Description("coupon_code")]
    CouponCode,
  }
}
