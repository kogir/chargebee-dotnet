namespace ChargeBee.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Net.Http;
  using ChargeBee.Api;
  using ChargeBee.Filters.Enums;
  using ChargeBee.Internal;
  using ChargeBee.Models.Enums;

  public class CreditNote : Resource {
    public static CreateRequest Create() {
      string url = ApiUtil.BuildUrl("credit_notes");
      return new CreateRequest(url, HttpMethod.Post);
    }
    public static EntityRequest<Type> Retrieve(string id) {
      string url = ApiUtil.BuildUrl("credit_notes", CheckNull(id));
      return new EntityRequest<Type>(url, HttpMethod.Get);
    }
    public static EntityRequest<Type> Pdf(string id) {
      string url = ApiUtil.BuildUrl("credit_notes", CheckNull(id), "pdf");
      return new EntityRequest<Type>(url, HttpMethod.Post);
    }
    public static CreditNoteListRequest List() {
      string url = ApiUtil.BuildUrl("credit_notes");
      return new CreditNoteListRequest(url);
    }
    [Obsolete]
    public static ListRequest CreditNotesForCustomer(string id) {
      string url = ApiUtil.BuildUrl("customers", CheckNull(id), "credit_notes");
      return new ListRequest(url);
    }

    public string Id {
      get { return GetValue<string>("id", true); }
    }
    public string CustomerId {
      get { return GetValue<string>("customer_id", true); }
    }
    public string SubscriptionId {
      get { return GetValue<string>("subscription_id", false); }
    }
    public string ReferenceInvoiceId {
      get { return GetValue<string>("reference_invoice_id", true); }
    }
    public TypeEnum CreditNoteType {
      get { return GetEnum<TypeEnum>("type", true); }
    }
    public ReasonCodeEnum ReasonCode {
      get { return GetEnum<ReasonCodeEnum>("reason_code", true); }
    }
    public StatusEnum Status {
      get { return GetEnum<StatusEnum>("status", true); }
    }
    public string VatNumber {
      get { return GetValue<string>("vat_number", false); }
    }
    public DateTime? Date {
      get { return GetDateTime("date", false); }
    }
    public PriceTypeEnum PriceType {
      get { return GetEnum<PriceTypeEnum>("price_type", true); }
    }
    public string CurrencyCode {
      get { return GetValue<string>("currency_code", true); }
    }
    public int? Total {
      get { return GetValue<int?>("total", false); }
    }
    public int? AmountAllocated {
      get { return GetValue<int?>("amount_allocated", false); }
    }
    public int? AmountRefunded {
      get { return GetValue<int?>("amount_refunded", false); }
    }
    public int? AmountAvailable {
      get { return GetValue<int?>("amount_available", false); }
    }
    public DateTime? RefundedAt {
      get { return GetDateTime("refunded_at", false); }
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
    public List<CreditNoteLineItem> LineItems {
      get { return GetResourceList<CreditNoteLineItem>("line_items"); }
    }
    public List<CreditNoteDiscount> Discounts {
      get { return GetResourceList<CreditNoteDiscount>("discounts"); }
    }
    public List<CreditNoteTax> Taxes {
      get { return GetResourceList<CreditNoteTax>("taxes"); }
    }
    public List<CreditNoteLineItemTax> LineItemTaxes {
      get { return GetResourceList<CreditNoteLineItemTax>("line_item_taxes"); }
    }
    public List<CreditNoteLinkedRefund> LinkedRefunds {
      get { return GetResourceList<CreditNoteLinkedRefund>("linked_refunds"); }
    }
    public List<CreditNoteAllocation> Allocations {
      get { return GetResourceList<CreditNoteAllocation>("allocations"); }
    }
    public bool Deleted {
      get { return GetValue<bool>("deleted", true); }
    }

    public class CreateRequest : EntityRequest<CreateRequest> {
      public CreateRequest(string url, HttpMethod method)
              : base(url, method) {
      }

      public CreateRequest ReferenceInvoiceId(string referenceInvoiceId) {
        m_params.Add("reference_invoice_id", referenceInvoiceId);
        return this;
      }
      public CreateRequest Total(int total) {
        m_params.AddOpt("total", total);
        return this;
      }
      public CreateRequest Type(TypeEnum type) {
        m_params.Add("type", type);
        return this;
      }
      public CreateRequest ReasonCode(ReasonCodeEnum reasonCode) {
        m_params.Add("reason_code", reasonCode);
        return this;
      }
      public CreateRequest Date(long date) {
        m_params.AddOpt("date", date);
        return this;
      }
      public CreateRequest CustomerNotes(string customerNotes) {
        m_params.AddOpt("customer_notes", customerNotes);
        return this;
      }
      public CreateRequest LineItemReferenceLineItemId(int index, string lineItemReferenceLineItemId) {
        m_params.Add("line_items[reference_line_item_id][" + index + "]", lineItemReferenceLineItemId);
        return this;
      }
      public CreateRequest LineItemUnitAmount(int index, int lineItemUnitAmount) {
        m_params.Add("line_items[unit_amount][" + index + "]", lineItemUnitAmount);
        return this;
      }
      public CreateRequest LineItemQuantity(int index, int lineItemQuantity) {
        m_params.Add("line_items[quantity][" + index + "]", lineItemQuantity);
        return this;
      }
      public CreateRequest LineItemDescription(int index, string lineItemDescription) {
        m_params.AddOpt("line_items[description][" + index + "]", lineItemDescription);
        return this;
      }
    }

    public class CreditNoteListRequest : ListRequestBase<CreditNoteListRequest> {
      public CreditNoteListRequest(string url)
              : base(url) {
      }

      public CreditNoteListRequest IncludeDeleted(bool includeDeleted) {
        m_params.AddOpt("include_deleted", includeDeleted);
        return this;
      }
      public StringFilter<CreditNoteListRequest> Id() {
        return new StringFilter<CreditNoteListRequest>("id", this).SupportsMultiOperators(true);
      }
      public StringFilter<CreditNoteListRequest> CustomerId() {
        return new StringFilter<CreditNoteListRequest>("customer_id", this).SupportsMultiOperators(true);
      }
      public StringFilter<CreditNoteListRequest> SubscriptionId() {
        return new StringFilter<CreditNoteListRequest>("subscription_id", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);
      }
      public StringFilter<CreditNoteListRequest> ReferenceInvoiceId() {
        return new StringFilter<CreditNoteListRequest>("reference_invoice_id", this).SupportsMultiOperators(true);
      }
      public EnumFilter<TypeEnum, CreditNoteListRequest> Type() {
        return new EnumFilter<TypeEnum, CreditNoteListRequest>("type", this);
      }
      public EnumFilter<ReasonCodeEnum, CreditNoteListRequest> ReasonCode() {
        return new EnumFilter<ReasonCodeEnum, CreditNoteListRequest>("reason_code", this);
      }
      public EnumFilter<StatusEnum, CreditNoteListRequest> Status() {
        return new EnumFilter<StatusEnum, CreditNoteListRequest>("status", this);
      }
      public TimestampFilter<CreditNoteListRequest> Date() {
        return new TimestampFilter<CreditNoteListRequest>("date", this);
      }
      public NumberFilter<int, CreditNoteListRequest> Total() {
        return new NumberFilter<int, CreditNoteListRequest>("total", this);
      }
      public EnumFilter<PriceTypeEnum, CreditNoteListRequest> PriceType() {
        return new EnumFilter<PriceTypeEnum, CreditNoteListRequest>("price_type", this);
      }
      public NumberFilter<int, CreditNoteListRequest> AmountAllocated() {
        return new NumberFilter<int, CreditNoteListRequest>("amount_allocated", this);
      }
      public NumberFilter<int, CreditNoteListRequest> AmountRefunded() {
        return new NumberFilter<int, CreditNoteListRequest>("amount_refunded", this);
      }
      public NumberFilter<int, CreditNoteListRequest> AmountAvailable() {
        return new NumberFilter<int, CreditNoteListRequest>("amount_available", this);
      }
      public TimestampFilter<CreditNoteListRequest> VoidedAt() {
        return new TimestampFilter<CreditNoteListRequest>("voided_at", this);
      }
      public TimestampFilter<CreditNoteListRequest> UpdatedAt() {
        return new TimestampFilter<CreditNoteListRequest>("updated_at", this);
      }
      public CreditNoteListRequest SortByDate(SortOrderEnum order) {
        m_params.AddOpt("sort_by[" + order.ToString().ToLower() + "]", "date");
        return this;
      }
    }

    public enum TypeEnum {
      Unknown,
      [Description("adjustment")]
      Adjustment,
      [Description("refundable")]
      Refundable,
    }

    public enum ReasonCodeEnum {
      Unknown,
      [Description("write_off")]
      WriteOff,
      [Description("subscription_change")]
      SubscriptionChange,
      [Description("chargeback")]
      Chargeback,
      [Description("product_unsatisfactory")]
      ProductUnsatisfactory,
      [Description("service_unsatisfactory")]
      ServiceUnsatisfactory,
      [Description("order_change")]
      OrderChange,
      [Description("order_cancellation")]
      OrderCancellation,
      [Description("waiver")]
      Waiver,
      [Description("other")]
      Other,
    }

    public enum StatusEnum {
      Unknown,
      [Description("adjusted")]
      Adjusted,
      [Description("refunded")]
      Refunded,
      [Description("refund_due")]
      RefundDue,
      [Description("voided")]
      Voided,
    }

    public class CreditNoteLineItem : Resource {
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
        return GetValue<int?>("item_level_discount_amount", false);
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

    public class CreditNoteDiscount : Resource {
      public enum EntityTypeEnum {
        Unknown,
        [Description("item_level_coupon")]
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

    public class CreditNoteTax : Resource {
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

    public class CreditNoteLineItemTax : Resource {
      public string LineItemId() {
        return GetValue<string>("line_item_id", false);
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

    public class CreditNoteLinkedRefund : Resource {
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

    public class CreditNoteAllocation : Resource {
      public string InvoiceId() {
        return GetValue<string>("invoice_id", true);
      }

      public int AllocatedAmount() {
        return GetValue<int>("allocated_amount", true);
      }

      public DateTime AllocatedAt() {
        return (DateTime)GetDateTime("allocated_at", true);
      }

      public DateTime? InvoiceDate() {
        return GetDateTime("invoice_date", false);
      }

      public Invoice.StatusEnum InvoiceStatus() {
        return GetEnum<Invoice.StatusEnum>("invoice_status", true);
      }
    }
  }
}
