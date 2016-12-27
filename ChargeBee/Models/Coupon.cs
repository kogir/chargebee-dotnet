namespace ChargeBee.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Net.Http;
  using ChargeBee.Api;
  using ChargeBee.Filters.Enums;
  using ChargeBee.Internal;
  using Newtonsoft.Json.Linq;

  public class Coupon : Resource {
    public static CreateRequest Create() {
      string url = ApiUtil.BuildUrl("coupons");
      return new CreateRequest(url, HttpMethod.Post);
    }
    public static CouponListRequest List() {
      string url = ApiUtil.BuildUrl("coupons");
      return new CouponListRequest(url);
    }
    public static EntityRequest<Type> Retrieve(string id) {
      string url = ApiUtil.BuildUrl("coupons", CheckNull(id));
      return new EntityRequest<Type>(url, HttpMethod.Get);
    }
    public static EntityRequest<Type> Delete(string id) {
      string url = ApiUtil.BuildUrl("coupons", CheckNull(id), "delete");
      return new EntityRequest<Type>(url, HttpMethod.Post);
    }
    public static CopyRequest Copy() {
      string url = ApiUtil.BuildUrl("coupons", "copy");
      return new CopyRequest(url, HttpMethod.Post);
    }

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
    [Obsolete]
    public int? DiscountQuantity {
      get { return GetValue<int?>("discount_quantity", false); }
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
    [Obsolete]
    public ApplyDiscountOnEnum ApplyDiscountOn {
      get { return GetEnum<ApplyDiscountOnEnum>("apply_discount_on", true); }
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
      public CreateRequest(string url, HttpMethod method)
              : base(url, method) {
      }

      public CreateRequest Id(string id) {
        m_params.Add("id", id);
        return this;
      }
      public CreateRequest Name(string name) {
        m_params.Add("name", name);
        return this;
      }
      public CreateRequest InvoiceName(string invoiceName) {
        m_params.AddOpt("invoice_name", invoiceName);
        return this;
      }
      public CreateRequest DiscountType(DiscountTypeEnum discountType) {
        m_params.Add("discount_type", discountType);
        return this;
      }
      public CreateRequest DiscountAmount(int discountAmount) {
        m_params.AddOpt("discount_amount", discountAmount);
        return this;
      }
      public CreateRequest CurrencyCode(string currencyCode) {
        m_params.AddOpt("currency_code", currencyCode);
        return this;
      }
      public CreateRequest DiscountPercentage(double discountPercentage) {
        m_params.AddOpt("discount_percentage", discountPercentage);
        return this;
      }
      [Obsolete]
      public CreateRequest DiscountQuantity(int discountQuantity) {
        m_params.AddOpt("discount_quantity", discountQuantity);
        return this;
      }
      public CreateRequest ApplyOn(ApplyOnEnum applyOn) {
        m_params.Add("apply_on", applyOn);
        return this;
      }
      public CreateRequest PlanConstraint(PlanConstraintEnum planConstraint) {
        m_params.AddOpt("plan_constraint", planConstraint);
        return this;
      }
      public CreateRequest AddonConstraint(AddonConstraintEnum addonConstraint) {
        m_params.AddOpt("addon_constraint", addonConstraint);
        return this;
      }
      public CreateRequest PlanIds(List<string> planIds) {
        m_params.AddOpt("plan_ids", planIds);
        return this;
      }
      public CreateRequest AddonIds(List<string> addonIds) {
        m_params.AddOpt("addon_ids", addonIds);
        return this;
      }
      public CreateRequest DurationType(DurationTypeEnum durationType) {
        m_params.Add("duration_type", durationType);
        return this;
      }
      public CreateRequest DurationMonth(int durationMonth) {
        m_params.AddOpt("duration_month", durationMonth);
        return this;
      }
      public CreateRequest ValidTill(long validTill) {
        m_params.AddOpt("valid_till", validTill);
        return this;
      }
      public CreateRequest MaxRedemptions(int maxRedemptions) {
        m_params.AddOpt("max_redemptions", maxRedemptions);
        return this;
      }
      public CreateRequest InvoiceNotes(string invoiceNotes) {
        m_params.AddOpt("invoice_notes", invoiceNotes);
        return this;
      }
      public CreateRequest MetaData(JToken metaData) {
        m_params.AddOpt("meta_data", metaData);
        return this;
      }
    }

    public class CouponListRequest : ListRequestBase<CouponListRequest> {
      public CouponListRequest(string url)
              : base(url) {
      }

      public StringFilter<CouponListRequest> Id() {
        return new StringFilter<CouponListRequest>("id", this).SupportsMultiOperators(true);
      }
      public StringFilter<CouponListRequest> Name() {
        return new StringFilter<CouponListRequest>("name", this).SupportsMultiOperators(true);
      }
      public EnumFilter<DiscountTypeEnum, CouponListRequest> DiscountType() {
        return new EnumFilter<DiscountTypeEnum, CouponListRequest>("discount_type", this);
      }
      public EnumFilter<DurationTypeEnum, CouponListRequest> DurationType() {
        return new EnumFilter<DurationTypeEnum, CouponListRequest>("duration_type", this);
      }
      public EnumFilter<StatusEnum, CouponListRequest> Status() {
        return new EnumFilter<StatusEnum, CouponListRequest>("status", this);
      }
      public EnumFilter<ApplyOnEnum, CouponListRequest> ApplyOn() {
        return new EnumFilter<ApplyOnEnum, CouponListRequest>("apply_on", this);
      }
      public TimestampFilter<CouponListRequest> CreatedAt() {
        return new TimestampFilter<CouponListRequest>("created_at", this);
      }
      public TimestampFilter<CouponListRequest> UpdatedAt() {
        return new TimestampFilter<CouponListRequest>("updated_at", this);
      }
      public CouponListRequest SortByCreatedAt(SortOrderEnum order) {
        m_params.AddOpt("sort_by[" + order.ToString().ToLower() + "]", "created_at");
        return this;
      }
    }

    public class CopyRequest : EntityRequest<CopyRequest> {
      public CopyRequest(string url, HttpMethod method)
              : base(url, method) {
      }

      public CopyRequest FromSite(string fromSite) {
        m_params.Add("from_site", fromSite);
        return this;
      }
      public CopyRequest IdAtFromSite(string idAtFromSite) {
        m_params.Add("id_at_from_site", idAtFromSite);
        return this;
      }
    }

    public enum DiscountTypeEnum {
      Unknown,
      [Description("fixed_amount")]
      FixedAmount,
      [Description("percentage")]
      Percentage,
      [Description("offer_quantity")]
      [Obsolete]
      OfferQuantity,
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

    [Obsolete]
    public enum ApplyDiscountOnEnum {
      Unknown,
      [Description("plans")]
      Plans,
      [Description("plans_and_addons")]
      PlansAndAddons,
      [Description("plans_with_quantity")]
      PlansWithQuantity,
      [Description("not_applicable")]
      NotApplicable,
    }

    public enum ApplyOnEnum {
      Unknown,
      [Description("invoice_amount")]
      InvoiceAmount,
      [Description("specified_items_total")]
      [Obsolete]
      SpecifiedItemsTotal,
      [Description("each_specified_item")]
      EachSpecifiedItem,
      [Description("each_unit_of_specified_items")]
      [Obsolete]
      EachUnitOfSpecifiedItems,
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
