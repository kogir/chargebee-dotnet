namespace RealArtists.ChargeBee.Models {
  using System;
  using System.ComponentModel;
  using System.Net.Http;
  using RealArtists.ChargeBee.Api;
  using RealArtists.ChargeBee.Internal;

  public class UnbilledChargeActions : ApiResourceActions {
    public UnbilledChargeActions(ChargeBeeApi api) : base(api) { }

    public UnbilledCharge.InvoiceUnbilledChargesRequest InvoiceUnbilledCharges() {
      string url = BuildUrl("unbilled_charges", "invoice_unbilled_charges");
      return new UnbilledCharge.InvoiceUnbilledChargesRequest(Api, url, HttpMethod.Post);
    }
    public EntityRequest<Type> Delete(string id) {
      string url = BuildUrl("unbilled_charges", id, "delete");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }
    public UnbilledCharge.UnbilledChargeListRequest List() {
      string url = BuildUrl("unbilled_charges");
      return new UnbilledCharge.UnbilledChargeListRequest(Api, url);
    }
    public UnbilledCharge.InvoiceNowEstimateRequest InvoiceNowEstimate() {
      string url = BuildUrl("unbilled_charges", "invoice_now_estimate");
      return new UnbilledCharge.InvoiceNowEstimateRequest(Api, url, HttpMethod.Post);
    }
  }

  public class UnbilledCharge : Resource {
    public string Id {
      get { return GetValue<string>("id", false); }
    }
    public string CustomerId {
      get { return GetValue<string>("customer_id", false); }
    }
    public string SubscriptionId {
      get { return GetValue<string>("subscription_id", false); }
    }
    public DateTime? DateFrom {
      get { return GetDateTime("date_from", false); }
    }
    public DateTime? DateTo {
      get { return GetDateTime("date_to", false); }
    }
    public int? UnitAmount {
      get { return GetValue<int?>("unit_amount", false); }
    }
    public int? Quantity {
      get { return GetValue<int?>("quantity", false); }
    }
    public int? Amount {
      get { return GetValue<int?>("amount", false); }
    }
    public string CurrencyCode {
      get { return GetValue<string>("currency_code", true); }
    }
    public int? DiscountAmount {
      get { return GetValue<int?>("discount_amount", false); }
    }
    public string Description {
      get { return GetValue<string>("description", false); }
    }
    public EntityTypeEnum EntityType {
      get { return GetEnum<EntityTypeEnum>("entity_type", true); }
    }
    public string EntityId {
      get { return GetValue<string>("entity_id", false); }
    }
    public bool IsVoided {
      get { return GetValue<bool>("is_voided", true); }
    }
    public DateTime? VoidedAt {
      get { return GetDateTime("voided_at", false); }
    }

    public class InvoiceUnbilledChargesRequest : EntityRequest<InvoiceUnbilledChargesRequest> {
      public InvoiceUnbilledChargesRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public InvoiceUnbilledChargesRequest SubscriptionId(string subscriptionId) {
        _params.AddOpt("subscription_id", subscriptionId);
        return this;
      }
      public InvoiceUnbilledChargesRequest CustomerId(string customerId) {
        _params.AddOpt("customer_id", customerId);
        return this;
      }
    }

    public class UnbilledChargeListRequest : ListRequestBase<UnbilledChargeListRequest> {
      public UnbilledChargeListRequest(ChargeBeeApi api, string url)
              : base(api, url) {
      }

      public StringFilter<UnbilledChargeListRequest> SubscriptionId() {
        return new StringFilter<UnbilledChargeListRequest>("subscription_id", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);
      }
      public StringFilter<UnbilledChargeListRequest> CustomerId() {
        return new StringFilter<UnbilledChargeListRequest>("customer_id", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);
      }
    }

    public class InvoiceNowEstimateRequest : EntityRequest<InvoiceNowEstimateRequest> {
      public InvoiceNowEstimateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public InvoiceNowEstimateRequest SubscriptionId(string subscriptionId) {
        _params.AddOpt("subscription_id", subscriptionId);
        return this;
      }
      public InvoiceNowEstimateRequest CustomerId(string customerId) {
        _params.AddOpt("customer_id", customerId);
        return this;
      }
    }

    public enum EntityTypeEnum {
      Unknown,
      [Description("plan_setup")]
      PlanSetup,
      [Description("plan")]
      Plan,
      [Description("addon")]
      Addon,
      [Description("adhoc")]
      Adhoc,

    }
  }
}
