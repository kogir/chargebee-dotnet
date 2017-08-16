namespace RealArtists.ChargeBee.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Net.Http;
  using Newtonsoft.Json.Linq;
  using RealArtists.ChargeBee.Api;
  using RealArtists.ChargeBee.Filters.Enums;
  using RealArtists.ChargeBee.Internal;

  public class CouponActions : ApiResourceActions {
    public CouponActions(ChargeBeeApi api) : base(api) { }

    public Coupon.CreateRequest Create() {
      string url = BuildUrl("coupons");
      return new Coupon.CreateRequest(Api, url, HttpMethod.Post);
    }

    public Coupon.CouponListRequest List() {
      string url = BuildUrl("coupons");
      return new Coupon.CouponListRequest(Api, url);
    }

    public EntityRequest<Type> Retrieve(string id) {
      string url = BuildUrl("coupons", id);
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }

    public EntityRequest<Type> Delete(string id) {
      string url = BuildUrl("coupons", id, "delete");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }

    public Coupon.CopyRequest Copy() {
      string url = BuildUrl("coupons", "copy");
      return new Coupon.CopyRequest(Api, url, HttpMethod.Post);
    }

    public EntityRequest<Type> Unarchive(string id) {
      string url = BuildUrl("coupons", id, "unarchive");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }
  }

  public class Coupon : Resource {
    public string Id {
      get { return GetValue<string>("id", true); }
    }
    public string Name {
      get { return GetValue<string>("name", true); }
    }
    public string InvoiceName {
      get { return GetValue<string>("invoice_name", false); }
    }
    public DiscountTypeEnum DiscountType {
      get { return GetEnum<DiscountTypeEnum>("discount_type", true); }
    }
    public double? DiscountPercentage {
      get { return GetValue<double?>("discount_percentage", false); }
    }
    public int? DiscountAmount {
      get { return GetValue<int?>("discount_amount", false); }
    }
    public string CurrencyCode {
      get { return GetValue<string>("currency_code", false); }
    }
    public DurationTypeEnum DurationType {
      get { return GetEnum<DurationTypeEnum>("duration_type", true); }
    }
    public int? DurationMonth {
      get { return GetValue<int?>("duration_month", false); }
    }
    public DateTime? ValidTill {
      get { return GetDateTime("valid_till", false); }
    }
    public int? MaxRedemptions {
      get { return GetValue<int?>("max_redemptions", false); }
    }
    public StatusEnum? Status {
      get { return GetEnum<StatusEnum>("status", false); }
    }
    public ApplyOnEnum ApplyOn {
      get { return GetEnum<ApplyOnEnum>("apply_on", true); }
    }
    public PlanConstraintEnum PlanConstraint {
      get { return GetEnum<PlanConstraintEnum>("plan_constraint", true); }
    }
    public AddonConstraintEnum AddonConstraint {
      get { return GetEnum<AddonConstraintEnum>("addon_constraint", true); }
    }
    public DateTime CreatedAt {
      get { return (DateTime)GetDateTime("created_at", true); }
    }
    public DateTime? ArchivedAt {
      get { return GetDateTime("archived_at", false); }
    }
    public long? ResourceVersion {
      get { return GetValue<long?>("resource_version", false); }
    }
    public DateTime? UpdatedAt {
      get { return GetDateTime("updated_at", false); }
    }
    public List<string> PlanIds {
      get { return GetList<string>("plan_ids"); }
    }
    public List<string> AddonIds {
      get { return GetList<string>("addon_ids"); }
    }
    public int? Redemptions {
      get { return GetValue<int?>("redemptions", false); }
    }
    public string InvoiceNotes {
      get { return GetValue<string>("invoice_notes", false); }
    }
    public JToken MetaData {
      get { return GetJToken("meta_data", false); }
    }

    public class CreateRequest : EntityRequest<CreateRequest> {
      public CreateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CreateRequest Id(string id) {
        _params.Add("id", id);
        return this;
      }
      public CreateRequest Name(string name) {
        _params.Add("name", name);
        return this;
      }
      public CreateRequest InvoiceName(string invoiceName) {
        _params.AddOpt("invoice_name", invoiceName);
        return this;
      }
      public CreateRequest DiscountType(Coupon.DiscountTypeEnum discountType) {
        _params.Add("discount_type", discountType);
        return this;
      }
      public CreateRequest DiscountAmount(int discountAmount) {
        _params.AddOpt("discount_amount", discountAmount);
        return this;
      }
      public CreateRequest CurrencyCode(string currencyCode) {
        _params.AddOpt("currency_code", currencyCode);
        return this;
      }
      public CreateRequest DiscountPercentage(double discountPercentage) {
        _params.AddOpt("discount_percentage", discountPercentage);
        return this;
      }
      public CreateRequest ApplyOn(Coupon.ApplyOnEnum applyOn) {
        _params.Add("apply_on", applyOn);
        return this;
      }
      public CreateRequest PlanConstraint(PlanConstraintEnum planConstraint) {
        _params.AddOpt("plan_constraint", planConstraint);
        return this;
      }
      public CreateRequest AddonConstraint(AddonConstraintEnum addonConstraint) {
        _params.AddOpt("addon_constraint", addonConstraint);
        return this;
      }
      public CreateRequest PlanIds(List<string> planIds) {
        _params.AddOpt("plan_ids", planIds);
        return this;
      }
      public CreateRequest AddonIds(List<string> addonIds) {
        _params.AddOpt("addon_ids", addonIds);
        return this;
      }
      public CreateRequest DurationType(Coupon.DurationTypeEnum durationType) {
        _params.Add("duration_type", durationType);
        return this;
      }
      public CreateRequest DurationMonth(int durationMonth) {
        _params.AddOpt("duration_month", durationMonth);
        return this;
      }
      public CreateRequest ValidTill(long validTill) {
        _params.AddOpt("valid_till", validTill);
        return this;
      }
      public CreateRequest MaxRedemptions(int maxRedemptions) {
        _params.AddOpt("max_redemptions", maxRedemptions);
        return this;
      }
      public CreateRequest InvoiceNotes(string invoiceNotes) {
        _params.AddOpt("invoice_notes", invoiceNotes);
        return this;
      }
      public CreateRequest MetaData(JToken metaData) {
        _params.AddOpt("meta_data", metaData);
        return this;
      }
      public CreateRequest Status(Coupon.StatusEnum status) {
        _params.AddOpt("status", status);
        return this;
      }
    }

    public class CouponListRequest : ListRequestBase<CouponListRequest> {
      public CouponListRequest(ChargeBeeApi api, string url)
              : base(api, url) {
      }

      public StringFilter<CouponListRequest> Id() {
        return new StringFilter<CouponListRequest>("id", this).SupportsMultiOperators(true);
      }
      public StringFilter<CouponListRequest> Name() {
        return new StringFilter<CouponListRequest>("name", this).SupportsMultiOperators(true);
      }
      public EnumFilter<Coupon.DiscountTypeEnum, CouponListRequest> DiscountType() {
        return new EnumFilter<Coupon.DiscountTypeEnum, CouponListRequest>("discount_type", this);
      }
      public EnumFilter<Coupon.DurationTypeEnum, CouponListRequest> DurationType() {
        return new EnumFilter<Coupon.DurationTypeEnum, CouponListRequest>("duration_type", this);
      }
      public EnumFilter<Coupon.StatusEnum, CouponListRequest> Status() {
        return new EnumFilter<Coupon.StatusEnum, CouponListRequest>("status", this);
      }
      public EnumFilter<Coupon.ApplyOnEnum, CouponListRequest> ApplyOn() {
        return new EnumFilter<Coupon.ApplyOnEnum, CouponListRequest>("apply_on", this);
      }
      public TimestampFilter<CouponListRequest> CreatedAt() {
        return new TimestampFilter<CouponListRequest>("created_at", this);
      }
      public TimestampFilter<CouponListRequest> UpdatedAt() {
        return new TimestampFilter<CouponListRequest>("updated_at", this);
      }
      public CouponListRequest SortByCreatedAt(SortOrderEnum order) {
        _params.AddOpt("sort_by[" + order.ToString().ToLower() + "]", "created_at");
        return this;
      }
    }

    public class CopyRequest : EntityRequest<CopyRequest> {
      public CopyRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CopyRequest FromSite(string fromSite) {
        _params.Add("fro_site", fromSite);
        return this;
      }
      public CopyRequest IdAtFromSite(string idAtFromSite) {
        _params.Add("id_at_fro_site", idAtFromSite);
        return this;
      }
      public CopyRequest Id(string id) {
        _params.AddOpt("id", id);
        return this;
      }
      public CopyRequest ForSiteMerging(bool forSiteMerging) {
        _params.AddOpt("for_site_merging", forSiteMerging);
        return this;
      }
    }

    public enum DiscountTypeEnum {
      Unknown,
      [Description("fixed_amount")]
      FixedAmount,
      [Description("percentage")]
      Percentage,
    }

    public enum DurationTypeEnum {
      Unknown,
      [Description("one_time")]
      OneTime,
      [Description("forever")]
      Forever,
      [Description("limited_period")]
      LimitedPeriod,
    }

    public enum StatusEnum {
      Unknown,
      [Description("active")]
      Active,
      [Description("expired")]
      Expired,
      [Description("archived")]
      Archived,
      [Description("deleted")]
      Deleted,
    }

    public enum ApplyOnEnum {
      Unknown,
      [Description("invoice_amount")]
      InvoiceAmount,
      [Description("each_specified_item")]
      EachSpecifiedItem,
    }

    public enum PlanConstraintEnum {
      Unknown,
      [Description("none")]
      None,
      [Description("all")]
      All,
      [Description("specific")]
      Specific,
      [Description("not_applicable")]
      NotApplicable,
    }

    public enum AddonConstraintEnum {
      Unknown,
      [Description("none")]
      None,
      [Description("all")]
      All,
      [Description("specific")]
      Specific,
      [Description("not_applicable")]
      NotApplicable,
    }
  }
}
