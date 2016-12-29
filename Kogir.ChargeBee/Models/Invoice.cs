namespace Kogir.ChargeBee.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Net.Http;
  using Kogir.ChargeBee.Api;
  using Kogir.ChargeBee.Filters.Enums;
  using Kogir.ChargeBee.Internal;
  using Kogir.ChargeBee.Models.Enums;

  public class InvoiceActions : ApiResourceActions {
    public InvoiceActions(ChargeBeeApi api) : base(api) { }

    public Invoice.CreateRequest Create() {
      string url = BuildUrl("invoices");
      return new Invoice.CreateRequest(Api, url, HttpMethod.Post);
    }
    public Invoice.ChargeRequest Charge() {
      string url = BuildUrl("invoices", "charge");
      return new Invoice.ChargeRequest(Api, url, HttpMethod.Post);
    }
    public Invoice.ChargeAddonRequest ChargeAddon() {
      string url = BuildUrl("invoices", "charge_addon");
      return new Invoice.ChargeAddonRequest(Api, url, HttpMethod.Post);
    }
    public EntityRequest<Type> StopDunning(string id) {
      string url = BuildUrl("invoices", id, "stop_dunning");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }
    public Invoice.ImportInvoiceRequest ImportInvoice() {
      string url = BuildUrl("invoices", "import_invoice");
      return new Invoice.ImportInvoiceRequest(Api, url, HttpMethod.Post);
    }
    public Invoice.InvoiceListRequest List() {
      string url = BuildUrl("invoices");
      return new Invoice.InvoiceListRequest(Api, url);
    }
    public EntityRequest<Type> Retrieve(string id) {
      string url = BuildUrl("invoices", id);
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }
    public EntityRequest<Type> Pdf(string id) {
      string url = BuildUrl("invoices", id, "pdf");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }
    public Invoice.AddChargeRequest AddCharge(string id) {
      string url = BuildUrl("invoices", id, "add_charge");
      return new Invoice.AddChargeRequest(Api, url, HttpMethod.Post);
    }
    public Invoice.AddAddonChargeRequest AddAddonCharge(string id) {
      string url = BuildUrl("invoices", id, "add_addon_charge");
      return new Invoice.AddAddonChargeRequest(Api, url, HttpMethod.Post);
    }
    public EntityRequest<Type> Close(string id) {
      string url = BuildUrl("invoices", id, "close");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }
    public Invoice.CollectPaymentRequest CollectPayment(string id) {
      string url = BuildUrl("invoices", id, "collect_payment");
      return new Invoice.CollectPaymentRequest(Api, url, HttpMethod.Post);
    }
    public Invoice.RecordPaymentRequest RecordPayment(string id) {
      string url = BuildUrl("invoices", id, "record_payment");
      return new Invoice.RecordPaymentRequest(Api, url, HttpMethod.Post);
    }
    public Invoice.RefundRequest Refund(string id) {
      string url = BuildUrl("invoices", id, "refund");
      return new Invoice.RefundRequest(Api, url, HttpMethod.Post);
    }
    public Invoice.RecordRefundRequest RecordRefund(string id) {
      string url = BuildUrl("invoices", id, "record_refund");
      return new Invoice.RecordRefundRequest(Api, url, HttpMethod.Post);
    }
    public Invoice.VoidInvoiceRequest VoidInvoice(string id) {
      string url = BuildUrl("invoices", id, "void");
      return new Invoice.VoidInvoiceRequest(Api, url, HttpMethod.Post);
    }
    public Invoice.WriteOffRequest WriteOff(string id) {
      string url = BuildUrl("invoices", id, "write_off");
      return new Invoice.WriteOffRequest(Api, url, HttpMethod.Post);
    }
    public Invoice.DeleteRequest Delete(string id) {
      string url = BuildUrl("invoices", id, "delete");
      return new Invoice.DeleteRequest(Api, url, HttpMethod.Post);
    }
  }

  public class Invoice : Resource {
    public string Id {
      get { return GetValue<string>("id", true); }
    }
    public string PoNumber {
      get { return GetValue<string>("po_number", false); }
    }
    public string CustomerId {
      get { return GetValue<string>("customer_id", true); }
    }
    public string SubscriptionId {
      get { return GetValue<string>("subscription_id", false); }
    }
    public bool Recurring {
      get { return GetValue<bool>("recurring", true); }
    }
    public StatusEnum Status {
      get { return GetEnum<StatusEnum>("status", true); }
    }
    public string VatNumber {
      get { return GetValue<string>("vat_number", false); }
    }
    public PriceTypeEnum PriceType {
      get { return GetEnum<PriceTypeEnum>("price_type", true); }
    }
    public DateTime? Date {
      get { return GetDateTime("date", false); }
    }
    public DateTime? DueDate {
      get { return GetDateTime("due_date", false); }
    }
    public int? NetTermDays {
      get { return GetValue<int?>("net_ter_days", false); }
    }
    public string CurrencyCode {
      get { return GetValue<string>("currency_code", true); }
    }
    public int? Total {
      get { return GetValue<int?>("total", false); }
    }
    public int? AmountPaid {
      get { return GetValue<int?>("amount_paid", false); }
    }
    public int? AmountAdjusted {
      get { return GetValue<int?>("amount_adjusted", false); }
    }
    public int? WriteOffAmount {
      get { return GetValue<int?>("write_off_amount", false); }
    }
    public int? CreditsApplied {
      get { return GetValue<int?>("credits_applied", false); }
    }
    public int? AmountDue {
      get { return GetValue<int?>("amount_due", false); }
    }
    public DateTime? PaidAt {
      get { return GetDateTime("paid_at", false); }
    }
    public DunningStatusEnum? DunningStatus {
      get { return GetEnum<DunningStatusEnum>("dunning_status", false); }
    }
    public DateTime? NextRetryAt {
      get { return GetDateTime("next_retry_at", false); }
    }
    public DateTime? VoidedAt {
      get { return GetDateTime("voided_at", false); }
    }
    public long? ResourceVersion {
      get { return GetValue<long?>("resource_version", false); }
    }
    public DateTime? UpdatedAt {
      get { return GetDateTime("updated_at", false); }
    }
    public int SubTotal {
      get { return GetValue<int>("sub_total", true); }
    }
    public int Tax {
      get { return GetValue<int>("tax", true); }
    }
    public bool? FirstInvoice {
      get { return GetValue<bool?>("first_invoice", false); }
    }
    public List<InvoiceLineItem> LineItems {
      get { return GetResourceList<InvoiceLineItem>("line_items"); }
    }
    public List<InvoiceDiscount> Discounts {
      get { return GetResourceList<InvoiceDiscount>("discounts"); }
    }
    public List<InvoiceTax> Taxes {
      get { return GetResourceList<InvoiceTax>("taxes"); }
    }
    public List<InvoiceLineItemTax> LineItemTaxes {
      get { return GetResourceList<InvoiceLineItemTax>("line_ite_taxes"); }
    }
    public List<InvoiceLinkedPayment> LinkedPayments {
      get { return GetResourceList<InvoiceLinkedPayment>("linked_payments"); }
    }
    public List<InvoiceAppliedCredit> AppliedCredits {
      get { return GetResourceList<InvoiceAppliedCredit>("applied_credits"); }
    }
    public List<InvoiceAdjustmentCreditNote> AdjustmentCreditNotes {
      get { return GetResourceList<InvoiceAdjustmentCreditNote>("adjustment_credit_notes"); }
    }
    public List<InvoiceIssuedCreditNote> IssuedCreditNotes {
      get { return GetResourceList<InvoiceIssuedCreditNote>("issued_credit_notes"); }
    }
    public List<InvoiceLinkedOrder> LinkedOrders {
      get { return GetResourceList<InvoiceLinkedOrder>("linked_orders"); }
    }
    public List<InvoiceNote> Notes {
      get { return GetResourceList<InvoiceNote>("notes"); }
    }
    public InvoiceShippingAddress ShippingAddress {
      get { return GetSubResource<InvoiceShippingAddress>("shipping_address"); }
    }
    public InvoiceBillingAddress BillingAddress {
      get { return GetSubResource<InvoiceBillingAddress>("billing_address"); }
    }
    public bool Deleted {
      get { return GetValue<bool>("deleted", true); }
    }

    public class CreateRequest : EntityRequest<CreateRequest> {
      public CreateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CreateRequest CustomerId(string customerId) {
        _params.Add("customer_id", customerId);
        return this;
      }
      public CreateRequest CurrencyCode(string currencyCode) {
        _params.AddOpt("currency_code", currencyCode);
        return this;
      }
      public CreateRequest Coupon(string coupon) {
        _params.AddOpt("coupon", coupon);
        return this;
      }
      public CreateRequest PoNumber(string poNumber) {
        _params.AddOpt("po_number", poNumber);
        return this;
      }
      public CreateRequest ShippingAddressFirstName(string shippingAddressFirstName) {
        _params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
        return this;
      }
      public CreateRequest ShippingAddressLastName(string shippingAddressLastName) {
        _params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
        return this;
      }
      public CreateRequest ShippingAddressEmail(string shippingAddressEmail) {
        _params.AddOpt("shipping_address[email]", shippingAddressEmail);
        return this;
      }
      public CreateRequest ShippingAddressCompany(string shippingAddressCompany) {
        _params.AddOpt("shipping_address[company]", shippingAddressCompany);
        return this;
      }
      public CreateRequest ShippingAddressPhone(string shippingAddressPhone) {
        _params.AddOpt("shipping_address[phone]", shippingAddressPhone);
        return this;
      }
      public CreateRequest ShippingAddressLine1(string shippingAddressLine1) {
        _params.AddOpt("shipping_address[line1]", shippingAddressLine1);
        return this;
      }
      public CreateRequest ShippingAddressLine2(string shippingAddressLine2) {
        _params.AddOpt("shipping_address[line2]", shippingAddressLine2);
        return this;
      }
      public CreateRequest ShippingAddressLine3(string shippingAddressLine3) {
        _params.AddOpt("shipping_address[line3]", shippingAddressLine3);
        return this;
      }
      public CreateRequest ShippingAddressCity(string shippingAddressCity) {
        _params.AddOpt("shipping_address[city]", shippingAddressCity);
        return this;
      }
      public CreateRequest ShippingAddressStateCode(string shippingAddressStateCode) {
        _params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
        return this;
      }
      public CreateRequest ShippingAddressState(string shippingAddressState) {
        _params.AddOpt("shipping_address[state]", shippingAddressState);
        return this;
      }
      public CreateRequest ShippingAddressZip(string shippingAddressZip) {
        _params.AddOpt("shipping_address[zip]", shippingAddressZip);
        return this;
      }
      public CreateRequest ShippingAddressCountry(string shippingAddressCountry) {
        _params.AddOpt("shipping_address[country]", shippingAddressCountry);
        return this;
      }
      public CreateRequest ShippingAddressValidationStatus(ValidationStatusEnum shippingAddressValidationStatus) {
        _params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
        return this;
      }
      public CreateRequest AddonId(int index, string addonId) {
        _params.AddOpt("addons[id][" + index + "]", addonId);
        return this;
      }
      public CreateRequest AddonQuantity(int index, int addonQuantity) {
        _params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
        return this;
      }
      public CreateRequest ChargeAmount(int index, int chargeAmount) {
        _params.AddOpt("charges[amount][" + index + "]", chargeAmount);
        return this;
      }
      public CreateRequest ChargeDescription(int index, string chargeDescription) {
        _params.AddOpt("charges[description][" + index + "]", chargeDescription);
        return this;
      }
    }

    public class ChargeRequest : EntityRequest<ChargeRequest> {
      public ChargeRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public ChargeRequest CustomerId(string customerId) {
        _params.AddOpt("customer_id", customerId);
        return this;
      }
      public ChargeRequest SubscriptionId(string subscriptionId) {
        _params.AddOpt("subscription_id", subscriptionId);
        return this;
      }
      public ChargeRequest CurrencyCode(string currencyCode) {
        _params.AddOpt("currency_code", currencyCode);
        return this;
      }
      public ChargeRequest Amount(int amount) {
        _params.Add("amount", amount);
        return this;
      }
      public ChargeRequest Description(string description) {
        _params.Add("description", description);
        return this;
      }
      public ChargeRequest Coupon(string coupon) {
        _params.AddOpt("coupon", coupon);
        return this;
      }
      public ChargeRequest PoNumber(string poNumber) {
        _params.AddOpt("po_number", poNumber);
        return this;
      }
    }

    public class ChargeAddonRequest : EntityRequest<ChargeAddonRequest> {
      public ChargeAddonRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public ChargeAddonRequest CustomerId(string customerId) {
        _params.AddOpt("customer_id", customerId);
        return this;
      }
      public ChargeAddonRequest SubscriptionId(string subscriptionId) {
        _params.AddOpt("subscription_id", subscriptionId);
        return this;
      }
      public ChargeAddonRequest AddonId(string addonId) {
        _params.Add("addon_id", addonId);
        return this;
      }
      public ChargeAddonRequest AddonQuantity(int addonQuantity) {
        _params.AddOpt("addon_quantity", addonQuantity);
        return this;
      }
      public ChargeAddonRequest Coupon(string coupon) {
        _params.AddOpt("coupon", coupon);
        return this;
      }
      public ChargeAddonRequest PoNumber(string poNumber) {
        _params.AddOpt("po_number", poNumber);
        return this;
      }
    }

    public class ImportInvoiceRequest : EntityRequest<ImportInvoiceRequest> {
      public ImportInvoiceRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public ImportInvoiceRequest Id(string id) {
        _params.Add("id", id);
        return this;
      }
      public ImportInvoiceRequest CurrencyCode(string currencyCode) {
        _params.AddOpt("currency_code", currencyCode);
        return this;
      }
      public ImportInvoiceRequest CustomerId(string customerId) {
        _params.AddOpt("customer_id", customerId);
        return this;
      }
      public ImportInvoiceRequest SubscriptionId(string subscriptionId) {
        _params.AddOpt("subscription_id", subscriptionId);
        return this;
      }
      public ImportInvoiceRequest PoNumber(string poNumber) {
        _params.AddOpt("po_number", poNumber);
        return this;
      }
      public ImportInvoiceRequest PriceType(PriceTypeEnum priceType) {
        _params.AddOpt("price_type", priceType);
        return this;
      }
      public ImportInvoiceRequest TaxOverrideReason(TaxOverrideReasonEnum taxOverrideReason) {
        _params.AddOpt("tax_override_reason", taxOverrideReason);
        return this;
      }
      public ImportInvoiceRequest VatNumber(string vatNumber) {
        _params.AddOpt("vat_number", vatNumber);
        return this;
      }
      public ImportInvoiceRequest Date(long date) {
        _params.Add("date", date);
        return this;
      }
      public ImportInvoiceRequest Total(int total) {
        _params.Add("total", total);
        return this;
      }
      public ImportInvoiceRequest RoundOff(int roundOff) {
        _params.AddOpt("round_off", roundOff);
        return this;
      }
      public ImportInvoiceRequest Status(StatusEnum status) {
        _params.AddOpt("status", status);
        return this;
      }
      public ImportInvoiceRequest DueDate(long dueDate) {
        _params.AddOpt("due_date", dueDate);
        return this;
      }
      public ImportInvoiceRequest NetTermDays(int netTermDays) {
        _params.AddOpt("net_ter_days", netTermDays);
        return this;
      }
      public ImportInvoiceRequest UseForProration(bool useForProration) {
        _params.AddOpt("use_for_proration", useForProration);
        return this;
      }
      public ImportInvoiceRequest BillingAddressFirstName(string billingAddressFirstName) {
        _params.AddOpt("billing_address[first_name]", billingAddressFirstName);
        return this;
      }
      public ImportInvoiceRequest BillingAddressLastName(string billingAddressLastName) {
        _params.AddOpt("billing_address[last_name]", billingAddressLastName);
        return this;
      }
      public ImportInvoiceRequest BillingAddressEmail(string billingAddressEmail) {
        _params.AddOpt("billing_address[email]", billingAddressEmail);
        return this;
      }
      public ImportInvoiceRequest BillingAddressCompany(string billingAddressCompany) {
        _params.AddOpt("billing_address[company]", billingAddressCompany);
        return this;
      }
      public ImportInvoiceRequest BillingAddressPhone(string billingAddressPhone) {
        _params.AddOpt("billing_address[phone]", billingAddressPhone);
        return this;
      }
      public ImportInvoiceRequest BillingAddressLine1(string billingAddressLine1) {
        _params.AddOpt("billing_address[line1]", billingAddressLine1);
        return this;
      }
      public ImportInvoiceRequest BillingAddressLine2(string billingAddressLine2) {
        _params.AddOpt("billing_address[line2]", billingAddressLine2);
        return this;
      }
      public ImportInvoiceRequest BillingAddressLine3(string billingAddressLine3) {
        _params.AddOpt("billing_address[line3]", billingAddressLine3);
        return this;
      }
      public ImportInvoiceRequest BillingAddressCity(string billingAddressCity) {
        _params.AddOpt("billing_address[city]", billingAddressCity);
        return this;
      }
      public ImportInvoiceRequest BillingAddressStateCode(string billingAddressStateCode) {
        _params.AddOpt("billing_address[state_code]", billingAddressStateCode);
        return this;
      }
      public ImportInvoiceRequest BillingAddressState(string billingAddressState) {
        _params.AddOpt("billing_address[state]", billingAddressState);
        return this;
      }
      public ImportInvoiceRequest BillingAddressZip(string billingAddressZip) {
        _params.AddOpt("billing_address[zip]", billingAddressZip);
        return this;
      }
      public ImportInvoiceRequest BillingAddressCountry(string billingAddressCountry) {
        _params.AddOpt("billing_address[country]", billingAddressCountry);
        return this;
      }
      public ImportInvoiceRequest BillingAddressValidationStatus(ValidationStatusEnum billingAddressValidationStatus) {
        _params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
        return this;
      }
      public ImportInvoiceRequest ShippingAddressFirstName(string shippingAddressFirstName) {
        _params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
        return this;
      }
      public ImportInvoiceRequest ShippingAddressLastName(string shippingAddressLastName) {
        _params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
        return this;
      }
      public ImportInvoiceRequest ShippingAddressEmail(string shippingAddressEmail) {
        _params.AddOpt("shipping_address[email]", shippingAddressEmail);
        return this;
      }
      public ImportInvoiceRequest ShippingAddressCompany(string shippingAddressCompany) {
        _params.AddOpt("shipping_address[company]", shippingAddressCompany);
        return this;
      }
      public ImportInvoiceRequest ShippingAddressPhone(string shippingAddressPhone) {
        _params.AddOpt("shipping_address[phone]", shippingAddressPhone);
        return this;
      }
      public ImportInvoiceRequest ShippingAddressLine1(string shippingAddressLine1) {
        _params.AddOpt("shipping_address[line1]", shippingAddressLine1);
        return this;
      }
      public ImportInvoiceRequest ShippingAddressLine2(string shippingAddressLine2) {
        _params.AddOpt("shipping_address[line2]", shippingAddressLine2);
        return this;
      }
      public ImportInvoiceRequest ShippingAddressLine3(string shippingAddressLine3) {
        _params.AddOpt("shipping_address[line3]", shippingAddressLine3);
        return this;
      }
      public ImportInvoiceRequest ShippingAddressCity(string shippingAddressCity) {
        _params.AddOpt("shipping_address[city]", shippingAddressCity);
        return this;
      }
      public ImportInvoiceRequest ShippingAddressStateCode(string shippingAddressStateCode) {
        _params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
        return this;
      }
      public ImportInvoiceRequest ShippingAddressState(string shippingAddressState) {
        _params.AddOpt("shipping_address[state]", shippingAddressState);
        return this;
      }
      public ImportInvoiceRequest ShippingAddressZip(string shippingAddressZip) {
        _params.AddOpt("shipping_address[zip]", shippingAddressZip);
        return this;
      }
      public ImportInvoiceRequest ShippingAddressCountry(string shippingAddressCountry) {
        _params.AddOpt("shipping_address[country]", shippingAddressCountry);
        return this;
      }
      public ImportInvoiceRequest ShippingAddressValidationStatus(ValidationStatusEnum shippingAddressValidationStatus) {
        _params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
        return this;
      }
      public ImportInvoiceRequest LineItemDateFrom(int index, long lineItemDateFrom) {
        _params.AddOpt("line_items[date_from][" + index + "]", lineItemDateFrom);
        return this;
      }
      public ImportInvoiceRequest LineItemDateTo(int index, long lineItemDateTo) {
        _params.AddOpt("line_items[date_to][" + index + "]", lineItemDateTo);
        return this;
      }
      public ImportInvoiceRequest LineItemDescription(int index, string lineItemDescription) {
        _params.Add("line_items[description][" + index + "]", lineItemDescription);
        return this;
      }
      public ImportInvoiceRequest LineItemUnitAmount(int index, int lineItemUnitAmount) {
        _params.AddOpt("line_items[unit_amount][" + index + "]", lineItemUnitAmount);
        return this;
      }
      public ImportInvoiceRequest LineItemQuantity(int index, int lineItemQuantity) {
        _params.AddOpt("line_items[quantity][" + index + "]", lineItemQuantity);
        return this;
      }
      public ImportInvoiceRequest LineItemAmount(int index, int lineItemAmount) {
        _params.AddOpt("line_items[amount][" + index + "]", lineItemAmount);
        return this;
      }
      public ImportInvoiceRequest LineItemEntityType(int index, InvoiceLineItem.EntityTypeEnum lineItemEntityType) {
        _params.AddOpt("line_items[entity_type][" + index + "]", lineItemEntityType);
        return this;
      }
      public ImportInvoiceRequest LineItemEntityId(int index, string lineItemEntityId) {
        _params.AddOpt("line_items[entity_id][" + index + "]", lineItemEntityId);
        return this;
      }
      public ImportInvoiceRequest LineItemItemLevelDiscount1EntityId(int index, string lineItemItemLevelDiscount1EntityId) {
        _params.AddOpt("line_items[ite_level_discount1_entity_id][" + index + "]", lineItemItemLevelDiscount1EntityId);
        return this;
      }
      public ImportInvoiceRequest LineItemItemLevelDiscount1Amount(int index, int lineItemItemLevelDiscount1Amount) {
        _params.AddOpt("line_items[ite_level_discount1_amount][" + index + "]", lineItemItemLevelDiscount1Amount);
        return this;
      }
      public ImportInvoiceRequest LineItemItemLevelDiscount2EntityId(int index, string lineItemItemLevelDiscount2EntityId) {
        _params.AddOpt("line_items[ite_level_discount2_entity_id][" + index + "]", lineItemItemLevelDiscount2EntityId);
        return this;
      }
      public ImportInvoiceRequest LineItemItemLevelDiscount2Amount(int index, int lineItemItemLevelDiscount2Amount) {
        _params.AddOpt("line_items[ite_level_discount2_amount][" + index + "]", lineItemItemLevelDiscount2Amount);
        return this;
      }
      public ImportInvoiceRequest LineItemTax1Name(int index, string lineItemTax1Name) {
        _params.AddOpt("line_items[tax1_name][" + index + "]", lineItemTax1Name);
        return this;
      }
      public ImportInvoiceRequest LineItemTax1Amount(int index, int lineItemTax1Amount) {
        _params.AddOpt("line_items[tax1_amount][" + index + "]", lineItemTax1Amount);
        return this;
      }
      public ImportInvoiceRequest LineItemTax2Name(int index, string lineItemTax2Name) {
        _params.AddOpt("line_items[tax2_name][" + index + "]", lineItemTax2Name);
        return this;
      }
      public ImportInvoiceRequest LineItemTax2Amount(int index, int lineItemTax2Amount) {
        _params.AddOpt("line_items[tax2_amount][" + index + "]", lineItemTax2Amount);
        return this;
      }
      public ImportInvoiceRequest LineItemTax3Name(int index, string lineItemTax3Name) {
        _params.AddOpt("line_items[tax3_name][" + index + "]", lineItemTax3Name);
        return this;
      }
      public ImportInvoiceRequest LineItemTax3Amount(int index, int lineItemTax3Amount) {
        _params.AddOpt("line_items[tax3_amount][" + index + "]", lineItemTax3Amount);
        return this;
      }
      public ImportInvoiceRequest LineItemTax4Name(int index, string lineItemTax4Name) {
        _params.AddOpt("line_items[tax4_name][" + index + "]", lineItemTax4Name);
        return this;
      }
      public ImportInvoiceRequest LineItemTax4Amount(int index, int lineItemTax4Amount) {
        _params.AddOpt("line_items[tax4_amount][" + index + "]", lineItemTax4Amount);
        return this;
      }
      public ImportInvoiceRequest DiscountEntityType(int index, InvoiceDiscount.EntityTypeEnum discountEntityType) {
        _params.Add("discounts[entity_type][" + index + "]", discountEntityType);
        return this;
      }
      public ImportInvoiceRequest DiscountEntityId(int index, string discountEntityId) {
        _params.AddOpt("discounts[entity_id][" + index + "]", discountEntityId);
        return this;
      }
      public ImportInvoiceRequest DiscountDescription(int index, string discountDescription) {
        _params.AddOpt("discounts[description][" + index + "]", discountDescription);
        return this;
      }
      public ImportInvoiceRequest DiscountAmount(int index, int discountAmount) {
        _params.Add("discounts[amount][" + index + "]", discountAmount);
        return this;
      }
      public ImportInvoiceRequest TaxName(int index, string taxName) {
        _params.Add("taxes[name][" + index + "]", taxName);
        return this;
      }
      public ImportInvoiceRequest TaxRate(int index, double taxRate) {
        _params.Add("taxes[rate][" + index + "]", taxRate);
        return this;
      }
      public ImportInvoiceRequest TaxAmount(int index, int taxAmount) {
        _params.AddOpt("taxes[amount][" + index + "]", taxAmount);
        return this;
      }
      public ImportInvoiceRequest TaxDescription(int index, string taxDescription) {
        _params.AddOpt("taxes[description][" + index + "]", taxDescription);
        return this;
      }
      public ImportInvoiceRequest TaxJurisType(int index, TaxJurisTypeEnum taxJurisType) {
        _params.AddOpt("taxes[juris_type][" + index + "]", taxJurisType);
        return this;
      }
      public ImportInvoiceRequest TaxJurisName(int index, string taxJurisName) {
        _params.AddOpt("taxes[juris_name][" + index + "]", taxJurisName);
        return this;
      }
      public ImportInvoiceRequest TaxJurisCode(int index, string taxJurisCode) {
        _params.AddOpt("taxes[juris_code][" + index + "]", taxJurisCode);
        return this;
      }
      public ImportInvoiceRequest PaymentAmount(int index, int paymentAmount) {
        _params.Add("payments[amount][" + index + "]", paymentAmount);
        return this;
      }
      public ImportInvoiceRequest PaymentPaymentMethod(int index, PaymentMethodEnum paymentPaymentMethod) {
        _params.Add("payments[payment_method][" + index + "]", paymentPaymentMethod);
        return this;
      }
      public ImportInvoiceRequest PaymentDate(int index, long paymentDate) {
        _params.AddOpt("payments[date][" + index + "]", paymentDate);
        return this;
      }
      public ImportInvoiceRequest PaymentReferenceNumber(int index, string paymentReferenceNumber) {
        _params.AddOpt("payments[reference_number][" + index + "]", paymentReferenceNumber);
        return this;
      }
      public ImportInvoiceRequest NoteEntityType(int index, InvoiceNote.EntityTypeEnum noteEntityType) {
        _params.AddOpt("notes[entity_type][" + index + "]", noteEntityType);
        return this;
      }
      public ImportInvoiceRequest NoteEntityId(int index, string noteEntityId) {
        _params.AddOpt("notes[entity_id][" + index + "]", noteEntityId);
        return this;
      }
      public ImportInvoiceRequest NoteNote(int index, string noteNote) {
        _params.AddOpt("notes[note][" + index + "]", noteNote);
        return this;
      }
    }

    public class InvoiceListRequest : ListRequestBase<InvoiceListRequest> {
      public InvoiceListRequest(ChargeBeeApi api, string url)
              : base(api, url) {
      }

      public InvoiceListRequest IncludeDeleted(bool includeDeleted) {
        _params.AddOpt("include_deleted", includeDeleted);
        return this;
      }
      public StringFilter<InvoiceListRequest> Id() {
        return new StringFilter<InvoiceListRequest>("id", this).SupportsMultiOperators(true);
      }
      public StringFilter<InvoiceListRequest> SubscriptionId() {
        return new StringFilter<InvoiceListRequest>("subscription_id", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);
      }
      public StringFilter<InvoiceListRequest> CustomerId() {
        return new StringFilter<InvoiceListRequest>("customer_id", this).SupportsMultiOperators(true);
      }
      public BooleanFilter<InvoiceListRequest> Recurring() {
        return new BooleanFilter<InvoiceListRequest>("recurring", this);
      }
      public EnumFilter<StatusEnum, InvoiceListRequest> Status() {
        return new EnumFilter<StatusEnum, InvoiceListRequest>("status", this);
      }
      public EnumFilter<PriceTypeEnum, InvoiceListRequest> PriceType() {
        return new EnumFilter<PriceTypeEnum, InvoiceListRequest>("price_type", this);
      }
      public TimestampFilter<InvoiceListRequest> Date() {
        return new TimestampFilter<InvoiceListRequest>("date", this);
      }
      public TimestampFilter<InvoiceListRequest> PaidAt() {
        return new TimestampFilter<InvoiceListRequest>("paid_at", this);
      }
      public NumberFilter<int, InvoiceListRequest> Total() {
        return new NumberFilter<int, InvoiceListRequest>("total", this);
      }
      public NumberFilter<int, InvoiceListRequest> AmountPaid() {
        return new NumberFilter<int, InvoiceListRequest>("amount_paid", this);
      }
      public NumberFilter<int, InvoiceListRequest> AmountAdjusted() {
        return new NumberFilter<int, InvoiceListRequest>("amount_adjusted", this);
      }
      public NumberFilter<int, InvoiceListRequest> CreditsApplied() {
        return new NumberFilter<int, InvoiceListRequest>("credits_applied", this);
      }
      public NumberFilter<int, InvoiceListRequest> AmountDue() {
        return new NumberFilter<int, InvoiceListRequest>("amount_due", this);
      }
      public EnumFilter<DunningStatusEnum, InvoiceListRequest> DunningStatus() {
        return new EnumFilter<DunningStatusEnum, InvoiceListRequest>("dunning_status", this).SupportsPresenceOperator(true);
      }
      public TimestampFilter<InvoiceListRequest> VoidedAt() {
        return new TimestampFilter<InvoiceListRequest>("voided_at", this);
      }
      public TimestampFilter<InvoiceListRequest> UpdatedAt() {
        return new TimestampFilter<InvoiceListRequest>("updated_at", this);
      }
      public InvoiceListRequest SortByDate(SortOrderEnum order) {
        _params.AddOpt("sort_by[" + order.ToString().ToLower() + "]", "date");
        return this;
      }
    }

    public class AddChargeRequest : EntityRequest<AddChargeRequest> {
      public AddChargeRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public AddChargeRequest Amount(int amount) {
        _params.Add("amount", amount);
        return this;
      }
      public AddChargeRequest Description(string description) {
        _params.Add("description", description);
        return this;
      }
    }

    public class AddAddonChargeRequest : EntityRequest<AddAddonChargeRequest> {
      public AddAddonChargeRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public AddAddonChargeRequest AddonId(string addonId) {
        _params.Add("addon_id", addonId);
        return this;
      }
      public AddAddonChargeRequest AddonQuantity(int addonQuantity) {
        _params.AddOpt("addon_quantity", addonQuantity);
        return this;
      }
    }

    public class CollectPaymentRequest : EntityRequest<CollectPaymentRequest> {
      public CollectPaymentRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CollectPaymentRequest Amount(int amount) {
        _params.AddOpt("amount", amount);
        return this;
      }
    }

    public class RecordPaymentRequest : EntityRequest<RecordPaymentRequest> {
      public RecordPaymentRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public RecordPaymentRequest Comment(string comment) {
        _params.AddOpt("comment", comment);
        return this;
      }
      public RecordPaymentRequest TransactionAmount(int transactionAmount) {
        _params.AddOpt("transaction[amount]", transactionAmount);
        return this;
      }
      public RecordPaymentRequest TransactionPaymentMethod(PaymentMethodEnum transactionPaymentMethod) {
        _params.Add("transaction[payment_method]", transactionPaymentMethod);
        return this;
      }
      public RecordPaymentRequest TransactionReferenceNumber(string transactionReferenceNumber) {
        _params.AddOpt("transaction[reference_number]", transactionReferenceNumber);
        return this;
      }
      public RecordPaymentRequest TransactionIdAtGateway(string transactionIdAtGateway) {
        _params.AddOpt("transaction[id_at_gateway]", transactionIdAtGateway);
        return this;
      }
      public RecordPaymentRequest TransactionStatus(Transaction.StatusEnum transactionStatus) {
        _params.AddOpt("transaction[status]", transactionStatus);
        return this;
      }
      public RecordPaymentRequest TransactionDate(long transactionDate) {
        _params.AddOpt("transaction[date]", transactionDate);
        return this;
      }
      public RecordPaymentRequest TransactionErrorCode(string transactionErrorCode) {
        _params.AddOpt("transaction[error_code]", transactionErrorCode);
        return this;
      }
      public RecordPaymentRequest TransactionErrorText(string transactionErrorText) {
        _params.AddOpt("transaction[error_text]", transactionErrorText);
        return this;
      }
    }

    public class RefundRequest : EntityRequest<RefundRequest> {
      public RefundRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public RefundRequest RefundAmount(int refundAmount) {
        _params.AddOpt("refund_amount", refundAmount);
        return this;
      }
      public RefundRequest Comment(string comment) {
        _params.AddOpt("comment", comment);
        return this;
      }
      public RefundRequest CustomerNotes(string customerNotes) {
        _params.AddOpt("customer_notes", customerNotes);
        return this;
      }
      public RefundRequest CreditNoteReasonCode(CreditNote.ReasonCodeEnum creditNoteReasonCode) {
        _params.AddOpt("credit_note[reason_code]", creditNoteReasonCode);
        return this;
      }
    }

    public class RecordRefundRequest : EntityRequest<RecordRefundRequest> {
      public RecordRefundRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public RecordRefundRequest Comment(string comment) {
        _params.AddOpt("comment", comment);
        return this;
      }
      public RecordRefundRequest CustomerNotes(string customerNotes) {
        _params.AddOpt("customer_notes", customerNotes);
        return this;
      }
      public RecordRefundRequest TransactionAmount(int transactionAmount) {
        _params.AddOpt("transaction[amount]", transactionAmount);
        return this;
      }
      public RecordRefundRequest TransactionPaymentMethod(PaymentMethodEnum transactionPaymentMethod) {
        _params.Add("transaction[payment_method]", transactionPaymentMethod);
        return this;
      }
      public RecordRefundRequest TransactionReferenceNumber(string transactionReferenceNumber) {
        _params.AddOpt("transaction[reference_number]", transactionReferenceNumber);
        return this;
      }
      public RecordRefundRequest TransactionDate(long transactionDate) {
        _params.Add("transaction[date]", transactionDate);
        return this;
      }
      public RecordRefundRequest CreditNoteReasonCode(CreditNote.ReasonCodeEnum creditNoteReasonCode) {
        _params.AddOpt("credit_note[reason_code]", creditNoteReasonCode);
        return this;
      }
    }

    public class VoidInvoiceRequest : EntityRequest<VoidInvoiceRequest> {
      public VoidInvoiceRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public VoidInvoiceRequest Comment(string comment) {
        _params.AddOpt("comment", comment);
        return this;
      }
    }

    public class WriteOffRequest : EntityRequest<WriteOffRequest> {
      public WriteOffRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public WriteOffRequest Comment(string comment) {
        _params.AddOpt("comment", comment);
        return this;
      }
    }

    public class DeleteRequest : EntityRequest<DeleteRequest> {
      public DeleteRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public DeleteRequest Comment(string comment) {
        _params.AddOpt("comment", comment);
        return this;
      }
    }

    public enum StatusEnum {
      Unknown,
      [Description("paid")]
      Paid,
      [Description("posted")]
      Posted,
      [Description("payment_due")]
      PaymentDue,
      [Description("not_paid")]
      NotPaid,
      [Description("voided")]
      Voided,
      [Description("pending")]
      Pending,
    }
    public enum DunningStatusEnum {
      Unknown,
      [Description("in_progress")]
      InProgress,
      [Description("exhausted")]
      Exhausted,
      [Description("stopped")]
      Stopped,
      [Description("success")]
      Success,
    }

    public class InvoiceLineItem : Resource {
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

      public string Id() {
        return GetValue<string>("id", false);
      }

      public DateTime DateFrom() {
        return (DateTime)GetDateTime("date_from", true);
      }

      public DateTime DateTo() {
        return (DateTime)GetDateTime("date_to", true);
      }

      public int UnitAmount() {
        return GetValue<int>("unit_amount", true);
      }

      public int? Quantity() {
        return GetValue<int?>("quantity", false);
      }

      public bool IsTaxed() {
        return GetValue<bool>("is_taxed", true);
      }

      public int? TaxAmount() {
        return GetValue<int?>("tax_amount", false);
      }

      public double? TaxRate() {
        return GetValue<double?>("tax_rate", false);
      }

      public int Amount() {
        return GetValue<int>("amount", true);
      }

      public int? DiscountAmount() {
        return GetValue<int?>("discount_amount", false);
      }

      public int? ItemLevelDiscountAmount() {
        return GetValue<int?>("ite_level_discount_amount", false);
      }

      public string Description() {
        return GetValue<string>("description", true);
      }

      public EntityTypeEnum EntityType() {
        return GetEnum<EntityTypeEnum>("entity_type", true);
      }

      public string EntityId() {
        return GetValue<string>("entity_id", false);
      }
    }

    public class InvoiceDiscount : Resource {
      public enum EntityTypeEnum {
        Unknown,
        [Description("ite_level_coupon")]
        ItemLevelCoupon,
        [Description("document_level_coupon")]
        DocumentLevelCoupon,
        [Description("promotional_credits")]
        PromotionalCredits,
        [Description("prorated_credits")]
        ProratedCredits,
      }

      public int Amount() {
        return GetValue<int>("amount", true);
      }

      public string Description() {
        return GetValue<string>("description", false);
      }

      public EntityTypeEnum EntityType() {
        return GetEnum<EntityTypeEnum>("entity_type", true);
      }

      public string EntityId() {
        return GetValue<string>("entity_id", false);
      }
    }

    public class InvoiceTax : Resource {
      public string Name() {
        return GetValue<string>("name", true);
      }

      public int Amount() {
        return GetValue<int>("amount", true);
      }

      public string Description() {
        return GetValue<string>("description", false);
      }
    }

    public class InvoiceLineItemTax : Resource {
      public string LineItemId() {
        return GetValue<string>("line_ite_id", false);
      }

      public string TaxName() {
        return GetValue<string>("tax_name", true);
      }

      public double TaxRate() {
        return GetValue<double>("tax_rate", true);
      }

      public int TaxAmount() {
        return GetValue<int>("tax_amount", true);
      }

      public TaxJurisTypeEnum? TaxJurisType() {
        return GetEnum<TaxJurisTypeEnum>("tax_juris_type", false);
      }

      public string TaxJurisName() {
        return GetValue<string>("tax_juris_name", false);
      }

      public string TaxJurisCode() {
        return GetValue<string>("tax_juris_code", false);
      }
    }

    public class InvoiceLinkedPayment : Resource {
      public string TxnId() {
        return GetValue<string>("txn_id", true);
      }

      public int AppliedAmount() {
        return GetValue<int>("applied_amount", true);
      }

      public DateTime AppliedAt() {
        return (DateTime)GetDateTime("applied_at", true);
      }

      public Transaction.StatusEnum? TxnStatus() {
        return GetEnum<Transaction.StatusEnum>("txn_status", false);
      }

      public DateTime? TxnDate() {
        return GetDateTime("txn_date", false);
      }

      public int? TxnAmount() {
        return GetValue<int?>("txn_amount", false);
      }
    }

    public class InvoiceAppliedCredit : Resource {
      public string CnId() {
        return GetValue<string>("cn_id", true);
      }

      public int AppliedAmount() {
        return GetValue<int>("applied_amount", true);
      }

      public DateTime AppliedAt() {
        return (DateTime)GetDateTime("applied_at", true);
      }

      public CreditNote.ReasonCodeEnum CnReasonCode() {
        return GetEnum<CreditNote.ReasonCodeEnum>("cn_reason_code", true);
      }

      public DateTime? CnDate() {
        return GetDateTime("cn_date", false);
      }

      public CreditNote.StatusEnum CnStatus() {
        return GetEnum<CreditNote.StatusEnum>("cn_status", true);
      }
    }

    public class InvoiceAdjustmentCreditNote : Resource {
      public string CnId() {
        return GetValue<string>("cn_id", true);
      }

      public CreditNote.ReasonCodeEnum CnReasonCode() {
        return GetEnum<CreditNote.ReasonCodeEnum>("cn_reason_code", true);
      }

      public DateTime? CnDate() {
        return GetDateTime("cn_date", false);
      }

      public int? CnTotal() {
        return GetValue<int?>("cn_total", false);
      }

      public CreditNote.StatusEnum CnStatus() {
        return GetEnum<CreditNote.StatusEnum>("cn_status", true);
      }
    }

    public class InvoiceIssuedCreditNote : Resource {
      public string CnId() {
        return GetValue<string>("cn_id", true);
      }

      public CreditNote.ReasonCodeEnum CnReasonCode() {
        return GetEnum<CreditNote.ReasonCodeEnum>("cn_reason_code", true);
      }

      public DateTime? CnDate() {
        return GetDateTime("cn_date", false);
      }

      public int? CnTotal() {
        return GetValue<int?>("cn_total", false);
      }

      public CreditNote.StatusEnum CnStatus() {
        return GetEnum<CreditNote.StatusEnum>("cn_status", true);
      }
    }

    public class InvoiceLinkedOrder : Resource {
      public enum StatusEnum {
        Unknown,
        [Description("new")]
        New,
        [Description("processing")]
        Processing,
        [Description("complete")]
        Complete,
        [Description("cancelled")]
        Cancelled,
        [Description("voided")]
        Voided,
      }

      public string Id() {
        return GetValue<string>("id", true);
      }

      public StatusEnum? Status() {
        return GetEnum<StatusEnum>("status", false);
      }

      public string ReferenceId() {
        return GetValue<string>("reference_id", false);
      }

      public string FulfillmentStatus() {
        return GetValue<string>("fulfillment_status", false);
      }

      public string BatchId() {
        return GetValue<string>("batch_id", false);
      }

      public DateTime CreatedAt() {
        return (DateTime)GetDateTime("created_at", true);
      }
    }

    public class InvoiceNote : Resource {
      public enum EntityTypeEnum {
        Unknown,
        [Description("plan")]
        Plan,
        [Description("addon")]
        Addon,
        [Description("coupon")]
        Coupon,
        [Description("subscription")]
        Subscription,
        [Description("customer")]
        Customer,
      }

      public EntityTypeEnum EntityType() {
        return GetEnum<EntityTypeEnum>("entity_type", true);
      }

      public string Note() {
        return GetValue<string>("note", true);
      }

      public string EntityId() {
        return GetValue<string>("entity_id", false);
      }
    }

    public class InvoiceShippingAddress : Resource {
      public string FirstName() {
        return GetValue<string>("first_name", false);
      }

      public string LastName() {
        return GetValue<string>("last_name", false);
      }

      public string Email() {
        return GetValue<string>("email", false);
      }

      public string Company() {
        return GetValue<string>("company", false);
      }

      public string Phone() {
        return GetValue<string>("phone", false);
      }

      public string Line1() {
        return GetValue<string>("line1", false);
      }

      public string Line2() {
        return GetValue<string>("line2", false);
      }

      public string Line3() {
        return GetValue<string>("line3", false);
      }

      public string City() {
        return GetValue<string>("city", false);
      }

      public string StateCode() {
        return GetValue<string>("state_code", false);
      }

      public string State() {
        return GetValue<string>("state", false);
      }

      public string Country() {
        return GetValue<string>("country", false);
      }

      public string Zip() {
        return GetValue<string>("zip", false);
      }

      public ValidationStatusEnum? ValidationStatus() {
        return GetEnum<ValidationStatusEnum>("validation_status", false);
      }
    }

    public class InvoiceBillingAddress : Resource {
      public string FirstName() {
        return GetValue<string>("first_name", false);
      }

      public string LastName() {
        return GetValue<string>("last_name", false);
      }

      public string Email() {
        return GetValue<string>("email", false);
      }

      public string Company() {
        return GetValue<string>("company", false);
      }

      public string Phone() {
        return GetValue<string>("phone", false);
      }

      public string Line1() {
        return GetValue<string>("line1", false);
      }

      public string Line2() {
        return GetValue<string>("line2", false);
      }

      public string Line3() {
        return GetValue<string>("line3", false);
      }

      public string City() {
        return GetValue<string>("city", false);
      }

      public string StateCode() {
        return GetValue<string>("state_code", false);
      }

      public string State() {
        return GetValue<string>("state", false);
      }

      public string Country() {
        return GetValue<string>("country", false);
      }

      public string Zip() {
        return GetValue<string>("zip", false);
      }

      public ValidationStatusEnum? ValidationStatus() {
        return GetEnum<ValidationStatusEnum>("validation_status", false);
      }
    }
  }
}
