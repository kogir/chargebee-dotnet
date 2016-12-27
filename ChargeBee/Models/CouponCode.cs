namespace ChargeBee.Models {
  using System;
  using System.ComponentModel;
  using System.Net.Http;
  using ChargeBee.Api;
  using ChargeBee.Internal;

  public class CouponCode : Resource {
    public static CreateRequest Create() {
      string url = ApiUtil.BuildUrl("coupon_codes");
      return new CreateRequest(url, HttpMethod.Post);
    }
    public static EntityRequest<Type> Retrieve(string id) {
      string url = ApiUtil.BuildUrl("coupon_codes", CheckNull(id));
      return new EntityRequest<Type>(url, HttpMethod.Get);
    }
    public static CouponCodeListRequest List() {
      string url = ApiUtil.BuildUrl("coupon_codes");
      return new CouponCodeListRequest(url);
    }
    public static EntityRequest<Type> Archive(string id) {
      string url = ApiUtil.BuildUrl("coupon_codes", CheckNull(id), "archive");
      return new EntityRequest<Type>(url, HttpMethod.Post);
    }

    public string Code {
      get { return GetValue<string>("code", true); }
    }
    public StatusEnum Status {
      get { return GetEnum<StatusEnum>("status", true); }
    }
    public string CouponId {
      get { return GetValue<string>("coupon_id", true); }
    }
    public string CouponSetName {
      get { return GetValue<string>("coupon_set_name", true); }
    }

    public class CreateRequest : EntityRequest<CreateRequest> {
      public CreateRequest(string url, HttpMethod method)
              : base(url, method) {
      }

      public CreateRequest CouponId(string couponId) {
        _params.Add("coupon_id", couponId);
        return this;
      }
      public CreateRequest CouponSetName(string couponSetName) {
        _params.Add("coupon_set_name", couponSetName);
        return this;
      }
      public CreateRequest Code(string code) {
        _params.Add("code", code);
        return this;
      }
    }

    public class CouponCodeListRequest : ListRequestBase<CouponCodeListRequest> {
      public CouponCodeListRequest(string url)
              : base(url) {
      }

      public StringFilter<CouponCodeListRequest> Code() {
        return new StringFilter<CouponCodeListRequest>("code", this).SupportsMultiOperators(true);
      }
      public StringFilter<CouponCodeListRequest> CouponId() {
        return new StringFilter<CouponCodeListRequest>("coupon_id", this).SupportsMultiOperators(true);
      }
      public StringFilter<CouponCodeListRequest> CouponSetName() {
        return new StringFilter<CouponCodeListRequest>("coupon_set_name", this);
      }
      public EnumFilter<StatusEnum, CouponCodeListRequest> Status() {
        return new EnumFilter<StatusEnum, CouponCodeListRequest>("status", this);
      }
    }

    public enum StatusEnum {
      Unknown,
      [Description("not_redeemed")]
      NotRedeemed,
      [Description("redeemed")]
      Redeemed,
      [Description("archived")]
      Archived,
    }
  }
}
