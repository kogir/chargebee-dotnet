namespace ChargeBee.Models {
  using System;
  using System.ComponentModel;
  using System.Net.Http;
  using ChargeBee.Api;
  using ChargeBee.Internal;

  public class CouponCodeActions : ApiResourceActions {
    public CouponCodeActions(ChargeBeeApi api) : base(api) { }

    public CouponCode.CreateRequest Create() {
      string url = BuildUrl("coupon_codes");
      return new CouponCode.CreateRequest(Api, url, HttpMethod.Post);
    }
    public EntityRequest<Type> Retrieve(string id) {
      string url = BuildUrl("coupon_codes", id);
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }
    public CouponCode.CouponCodeListRequest List() {
      string url = BuildUrl("coupon_codes");
      return new CouponCode.CouponCodeListRequest(Api, url);
    }
    public EntityRequest<Type> Archive(string id) {
      string url = BuildUrl("coupon_codes", id, "archive");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }
  }

  public class CouponCode : Resource {
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
      public CreateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
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
      public CouponCodeListRequest(ChargeBeeApi api, string url)
              : base(api, url) {
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
