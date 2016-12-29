namespace RealArtists.ChargeBee.Models {
  using System;
  using System.ComponentModel;
  using System.Net.Http;
  using RealArtists.ChargeBee.Api;
  using RealArtists.ChargeBee.Internal;
  using Newtonsoft.Json.Linq;

  public class AddonActions : ApiResourceActions {
    public AddonActions(ChargeBeeApi api) : base(api) { }

    public Addon.CreateRequest Create() {
      string url = BuildUrl("addons");
      return new Addon.CreateRequest(Api, url, HttpMethod.Post);
    }

    public Addon.UpdateRequest Update(string id) {
      string url = BuildUrl("addons", id);
      return new Addon.UpdateRequest(Api, url, HttpMethod.Post);
    }

    public Addon.AddonListRequest List() {
      string url = BuildUrl("addons");
      return new Addon.AddonListRequest(Api, url);
    }

    public EntityRequest<Type> Retrieve(string id) {
      string url = BuildUrl("addons", id);
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }

    public EntityRequest<Type> Delete(string id) {
      string url = BuildUrl("addons", id, "delete");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }

    public Addon.CopyRequest Copy() {
      string url = BuildUrl("addons", "copy");
      return new Addon.CopyRequest(Api, url, HttpMethod.Post);
    }
  }

  public class Addon : Resource {
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
    public TypeEnum AddonType {
      get { return GetEnum<TypeEnum>("type", true); }
    }
    public ChargeTypeEnum ChargeType {
      get { return GetEnum<ChargeTypeEnum>("charge_type", true); }
    }
    public int Price {
      get { return GetValue<int>("price", true); }
    }
    public string CurrencyCode {
      get { return GetValue<string>("currency_code", true); }
    }
    public int? Period {
      get { return GetValue<int?>("period", false); }
    }
    public PeriodUnitEnum PeriodUnit {
      get { return GetEnum<PeriodUnitEnum>("period_unit", true); }
    }
    public string Unit {
      get { return GetValue<string>("unit", false); }
    }
    public StatusEnum Status {
      get { return GetEnum<StatusEnum>("status", true); }
    }
    public DateTime? ArchivedAt {
      get { return GetDateTime("archived_at", false); }
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
        : base(api, url, method) { }

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
      public CreateRequest ChargeType(ChargeTypeEnum chargeType) {
        _params.Add("charge_type", chargeType);
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
      public CreateRequest Period(int period) {
        _params.AddOpt("period", period);
        return this;
      }
      public CreateRequest PeriodUnit(PeriodUnitEnum periodUnit) {
        _params.AddOpt("period_unit", periodUnit);
        return this;
      }
      public CreateRequest Type(TypeEnum type) {
        _params.Add("type", type);
        return this;
      }
      public CreateRequest Unit(string unit) {
        _params.AddOpt("unit", unit);
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
      public CreateRequest InvoiceNotes(string invoiceNotes) {
        _params.AddOpt("invoice_notes", invoiceNotes);
        return this;
      }
      public CreateRequest MetaData(JToken metaData) {
        _params.AddOpt("meta_data", metaData);
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
      public UpdateRequest ChargeType(ChargeTypeEnum chargeType) {
        _params.AddOpt("charge_type", chargeType);
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
      public UpdateRequest Period(int period) {
        _params.AddOpt("period", period);
        return this;
      }
      public UpdateRequest PeriodUnit(PeriodUnitEnum periodUnit) {
        _params.AddOpt("period_unit", periodUnit);
        return this;
      }
      public UpdateRequest Type(TypeEnum type) {
        _params.AddOpt("type", type);
        return this;
      }
      public UpdateRequest Unit(string unit) {
        _params.AddOpt("unit", unit);
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
      public UpdateRequest InvoiceNotes(string invoiceNotes) {
        _params.AddOpt("invoice_notes", invoiceNotes);
        return this;
      }
      public UpdateRequest MetaData(JToken metaData) {
        _params.AddOpt("meta_data", metaData);
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
    }

    public class AddonListRequest : ListRequestBase<AddonListRequest> {
      public AddonListRequest(ChargeBeeApi api, string url)
              : base(api, url) {
      }

      public StringFilter<AddonListRequest> Id() {
        return new StringFilter<AddonListRequest>("id", this).SupportsMultiOperators(true);
      }
      public StringFilter<AddonListRequest> Name() {
        return new StringFilter<AddonListRequest>("name", this).SupportsMultiOperators(true);
      }
      public EnumFilter<TypeEnum, AddonListRequest> Type() {
        return new EnumFilter<TypeEnum, AddonListRequest>("type", this);
      }
      public EnumFilter<ChargeTypeEnum, AddonListRequest> ChargeType() {
        return new EnumFilter<ChargeTypeEnum, AddonListRequest>("charge_type", this);
      }
      public NumberFilter<int, AddonListRequest> Price() {
        return new NumberFilter<int, AddonListRequest>("price", this);
      }
      public NumberFilter<int, AddonListRequest> Period() {
        return new NumberFilter<int, AddonListRequest>("period", this);
      }
      public EnumFilter<PeriodUnitEnum, AddonListRequest> PeriodUnit() {
        return new EnumFilter<PeriodUnitEnum, AddonListRequest>("period_unit", this);
      }
      public EnumFilter<StatusEnum, AddonListRequest> Status() {
        return new EnumFilter<StatusEnum, AddonListRequest>("status", this);
      }
      public TimestampFilter<AddonListRequest> UpdatedAt() {
        return new TimestampFilter<AddonListRequest>("updated_at", this);
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

    public enum TypeEnum {
      Unknown,
      [Description("on_off")]
      OnOff,
      [Description("quantity")]
      Quantity,
    }

    public enum ChargeTypeEnum {
      Unknown,
      [Description("recurring")]
      Recurring,
      [Description("non_recurring")]
      NonRecurring,
    }

    public enum PeriodUnitEnum {
      Unknown,
      [Description("week")]
      Week,
      [Description("month")]
      Month,
      [Description("year")]
      Year,
      [Description("not_applicable")]
      NotApplicable,
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
