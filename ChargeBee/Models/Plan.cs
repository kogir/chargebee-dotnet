namespace RealArtists.ChargeBee.Models {
  using System;
  using System.ComponentModel;
  using System.Net.Http;
  using Newtonsoft.Json.Linq;
  using RealArtists.ChargeBee.Api;
  using RealArtists.ChargeBee.Internal;

  public class PlanActions : ApiResourceActions {
    public PlanActions(ChargeBeeApi api) : base(api) { }

    public Plan.CreateRequest Create() {
      string url = BuildUrl("plans");
      return new Plan.CreateRequest(Api, url, HttpMethod.Post);
    }

    public Plan.UpdateRequest Update(string id) {
      string url = BuildUrl("plans", id);
      return new Plan.UpdateRequest(Api, url, HttpMethod.Post);
    }

    public Plan.PlanListRequest List() {
      string url = BuildUrl("plans");
      return new Plan.PlanListRequest(Api, url);
    }

    public EntityRequest<Type> Retrieve(string id) {
      string url = BuildUrl("plans", id);
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }

    public EntityRequest<Type> Delete(string id) {
      string url = BuildUrl("plans", id, "delete");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }

    public Plan.CopyRequest Copy() {
      string url = BuildUrl("plans", "copy");
      return new Plan.CopyRequest(Api, url, HttpMethod.Post);
    }

    public EntityRequest<Type> Unarchive(string id) {
      string url = BuildUrl("plans", id, "unarchive");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }
  }

  public class Plan : Resource {
    public string Id {
      get { return GetValue<string>("id", true); }
    }
    public string Name {
      get { return GetValue<string>("name", true); }
    }
    public string InvoiceName {
      get { return GetValue<string>("invoice_name", false); }
    }
    public string Description {
      get { return GetValue<string>("description", false); }
    }
    public int Price {
      get { return GetValue<int>("price", true); }
    }
    public string CurrencyCode {
      get { return GetValue<string>("currency_code", true); }
    }
    public int Period {
      get { return GetValue<int>("period", true); }
    }
    public PeriodUnitEnum PeriodUnit {
      get { return GetEnum<PeriodUnitEnum>("period_unit", true); }
    }
    public int? TrialPeriod {
      get { return GetValue<int?>("trial_period", false); }
    }
    public TrialPeriodUnitEnum? TrialPeriodUnit {
      get { return GetEnum<TrialPeriodUnitEnum>("trial_period_unit", false); }
    }
    public ChargeModelEnum ChargeModel {
      get { return GetEnum<ChargeModelEnum>("charge_model", true); }
    }
    public int FreeQuantity {
      get { return GetValue<int>("free_quantity", true); }
    }
    public int? SetupCost {
      get { return GetValue<int?>("setup_cost", false); }
    }
    public StatusEnum Status {
      get { return GetEnum<StatusEnum>("status", true); }
    }
    public DateTime? ArchivedAt {
      get { return GetDateTime("archived_at", false); }
    }
    public int? BillingCycles {
      get { return GetValue<int?>("billing_cycles", false); }
    }
    public string RedirectUrl {
      get { return GetValue<string>("redirect_url", false); }
    }
    public bool EnabledInHostedPages {
      get { return GetValue<bool>("enabled_in_hosted_pages", true); }
    }
    public bool EnabledInPortal {
      get { return GetValue<bool>("enabled_in_portal", true); }
    }
    public string TaxCode {
      get { return GetValue<string>("tax_code", false); }
    }
    public string Sku {
      get { return GetValue<string>("sku", false); }
    }
    public string AccountingCode {
      get { return GetValue<string>("accounting_code", false); }
    }
    public string AccountingCategory1 {
      get { return GetValue<string>("accounting_category1", false); }
    }
    public string AccountingCategory2 {
      get { return GetValue<string>("accounting_category2", false); }
    }
    public long? ResourceVersion {
      get { return GetValue<long?>("resource_version", false); }
    }
    public DateTime? UpdatedAt {
      get { return GetDateTime("updated_at", false); }
    }
    public string InvoiceNotes {
      get { return GetValue<string>("invoice_notes", false); }
    }
    public bool? Taxable {
      get { return GetValue<bool?>("taxable", false); }
    }
    public string TaxProfileId {
      get { return GetValue<string>("tax_profile_id", false); }
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
      public CreateRequest Description(string description) {
        _params.AddOpt("description", description);
        return this;
      }
      public CreateRequest TrialPeriod(int trialPeriod) {
        _params.AddOpt("trial_period", trialPeriod);
        return this;
      }
      public CreateRequest TrialPeriodUnit(TrialPeriodUnitEnum trialPeriodUnit) {
        _params.AddOpt("trial_period_unit", trialPeriodUnit);
        return this;
      }
      public CreateRequest Period(int period) {
        _params.AddOpt("period", period);
        return this;
      }
      public CreateRequest PeriodUnit(PeriodUnitEnum periodUnit) {
        _params.AddOpt("period_unit", periodUnit);
        return this;
      }
      public CreateRequest SetupCost(int setupCost) {
        _params.AddOpt("setup_cost", setupCost);
        return this;
      }
      public CreateRequest Price(int price) {
        _params.AddOpt("price", price);
        return this;
      }
      public CreateRequest CurrencyCode(string currencyCode) {
        _params.AddOpt("currency_code", currencyCode);
        return this;
      }
      public CreateRequest BillingCycles(int billingCycles) {
        _params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
      public CreateRequest ChargeModel(ChargeModelEnum chargeModel) {
        _params.AddOpt("charge_model", chargeModel);
        return this;
      }
      public CreateRequest FreeQuantity(int freeQuantity) {
        _params.AddOpt("free_quantity", freeQuantity);
        return this;
      }
      public CreateRequest RedirectUrl(string redirectUrl) {
        _params.AddOpt("redirect_url", redirectUrl);
        return this;
      }
      public CreateRequest EnabledInHostedPages(bool enabledInHostedPages) {
        _params.AddOpt("enabled_in_hosted_pages", enabledInHostedPages);
        return this;
      }
      public CreateRequest EnabledInPortal(bool enabledInPortal) {
        _params.AddOpt("enabled_in_portal", enabledInPortal);
        return this;
      }
      public CreateRequest Taxable(bool taxable) {
        _params.AddOpt("taxable", taxable);
        return this;
      }
      public CreateRequest TaxProfileId(string taxProfileId) {
        _params.AddOpt("tax_profile_id", taxProfileId);
        return this;
      }
      public CreateRequest TaxCode(string taxCode) {
        _params.AddOpt("tax_code", taxCode);
        return this;
      }
      public CreateRequest Sku(string sku) {
        _params.AddOpt("sku", sku);
        return this;
      }
      public CreateRequest AccountingCode(string accountingCode) {
        _params.AddOpt("accounting_code", accountingCode);
        return this;
      }
      public CreateRequest AccountingCategory1(string accountingCategory1) {
        _params.AddOpt("accounting_category1", accountingCategory1);
        return this;
      }
      public CreateRequest AccountingCategory2(string accountingCategory2) {
        _params.AddOpt("accounting_category2", accountingCategory2);
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
    }

    public class UpdateRequest : EntityRequest<UpdateRequest> {
      public UpdateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public UpdateRequest Id(string id) {
        _params.AddOpt("id", id);
        return this;
      }
      public UpdateRequest Name(string name) {
        _params.AddOpt("name", name);
        return this;
      }
      public UpdateRequest InvoiceName(string invoiceName) {
        _params.AddOpt("invoice_name", invoiceName);
        return this;
      }
      public UpdateRequest Description(string description) {
        _params.AddOpt("description", description);
        return this;
      }
      public UpdateRequest TrialPeriod(int trialPeriod) {
        _params.AddOpt("trial_period", trialPeriod);
        return this;
      }
      public UpdateRequest TrialPeriodUnit(TrialPeriodUnitEnum trialPeriodUnit) {
        _params.AddOpt("trial_period_unit", trialPeriodUnit);
        return this;
      }
      public UpdateRequest Period(int period) {
        _params.AddOpt("period", period);
        return this;
      }
      public UpdateRequest PeriodUnit(PeriodUnitEnum periodUnit) {
        _params.AddOpt("period_unit", periodUnit);
        return this;
      }
      public UpdateRequest SetupCost(int setupCost) {
        _params.AddOpt("setup_cost", setupCost);
        return this;
      }
      public UpdateRequest Price(int price) {
        _params.AddOpt("price", price);
        return this;
      }
      public UpdateRequest CurrencyCode(string currencyCode) {
        _params.AddOpt("currency_code", currencyCode);
        return this;
      }
      public UpdateRequest BillingCycles(int billingCycles) {
        _params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
      public UpdateRequest ChargeModel(ChargeModelEnum chargeModel) {
        _params.AddOpt("charge_model", chargeModel);
        return this;
      }
      public UpdateRequest FreeQuantity(int freeQuantity) {
        _params.AddOpt("free_quantity", freeQuantity);
        return this;
      }
      public UpdateRequest RedirectUrl(string redirectUrl) {
        _params.AddOpt("redirect_url", redirectUrl);
        return this;
      }
      public UpdateRequest EnabledInHostedPages(bool enabledInHostedPages) {
        _params.AddOpt("enabled_in_hosted_pages", enabledInHostedPages);
        return this;
      }
      public UpdateRequest EnabledInPortal(bool enabledInPortal) {
        _params.AddOpt("enabled_in_portal", enabledInPortal);
        return this;
      }
      public UpdateRequest Taxable(bool taxable) {
        _params.AddOpt("taxable", taxable);
        return this;
      }
      public UpdateRequest TaxProfileId(string taxProfileId) {
        _params.AddOpt("tax_profile_id", taxProfileId);
        return this;
      }
      public UpdateRequest TaxCode(string taxCode) {
        _params.AddOpt("tax_code", taxCode);
        return this;
      }
      public UpdateRequest Sku(string sku) {
        _params.AddOpt("sku", sku);
        return this;
      }
      public UpdateRequest AccountingCode(string accountingCode) {
        _params.AddOpt("accounting_code", accountingCode);
        return this;
      }
      public UpdateRequest AccountingCategory1(string accountingCategory1) {
        _params.AddOpt("accounting_category1", accountingCategory1);
        return this;
      }
      public UpdateRequest AccountingCategory2(string accountingCategory2) {
        _params.AddOpt("accounting_category2", accountingCategory2);
        return this;
      }
      public UpdateRequest InvoiceNotes(string invoiceNotes) {
        _params.AddOpt("invoice_notes", invoiceNotes);
        return this;
      }
      public UpdateRequest MetaData(JToken metaData) {
        _params.AddOpt("meta_data", metaData);
        return this;
      }
    }

    public class PlanListRequest : ListRequestBase<PlanListRequest> {
      public PlanListRequest(ChargeBeeApi api, string url)
              : base(api, url) {
      }

      public StringFilter<PlanListRequest> Id() {
        return new StringFilter<PlanListRequest>("id", this).SupportsMultiOperators(true);
      }
      public StringFilter<PlanListRequest> Name() {
        return new StringFilter<PlanListRequest>("name", this).SupportsMultiOperators(true);
      }
      public NumberFilter<int, PlanListRequest> Price() {
        return new NumberFilter<int, PlanListRequest>("price", this);
      }
      public NumberFilter<int, PlanListRequest> Period() {
        return new NumberFilter<int, PlanListRequest>("period", this);
      }
      public EnumFilter<PeriodUnitEnum, PlanListRequest> PeriodUnit() {
        return new EnumFilter<PeriodUnitEnum, PlanListRequest>("period_unit", this);
      }
      public NumberFilter<int, PlanListRequest> TrialPeriod() {
        return new NumberFilter<int, PlanListRequest>("trial_period", this).SupportsPresenceOperator(true);
      }
      public EnumFilter<TrialPeriodUnitEnum, PlanListRequest> TrialPeriodUnit() {
        return new EnumFilter<TrialPeriodUnitEnum, PlanListRequest>("trial_period_unit", this);
      }
      public EnumFilter<ChargeModelEnum, PlanListRequest> ChargeModel() {
        return new EnumFilter<ChargeModelEnum, PlanListRequest>("charge_model", this);
      }
      public EnumFilter<StatusEnum, PlanListRequest> Status() {
        return new EnumFilter<StatusEnum, PlanListRequest>("status", this);
      }
      public TimestampFilter<PlanListRequest> UpdatedAt() {
        return new TimestampFilter<PlanListRequest>("updated_at", this);
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
    }

    public enum PeriodUnitEnum {
      Unknown,
      [Description("week")]
      Week,
      [Description("month")]
      Month,
      [Description("year")]
      Year,
    }

    public enum TrialPeriodUnitEnum {
      Unknown,
      [Description("day")]
      Day,
      [Description("month")]
      Month,
    }

    public enum ChargeModelEnum {
      Unknown,
      [Description("flat_fee")]
      FlatFee,
      [Description("per_unit")]
      PerUnit,
    }

    public enum StatusEnum {
      Unknown,
      [Description("active")]
      Active,
      [Description("archived")]
      Archived,
      [Description("deleted")]
      Deleted,
    }
  }
}
