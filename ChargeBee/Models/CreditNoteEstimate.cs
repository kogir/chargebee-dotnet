namespace ChargeBee.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using ChargeBee.Internal;
  using ChargeBee.Models.Enums;

  public class CreditNoteEstimate : Resource {
    public string ReferenceInvoiceId {
      get { return GetValue<string>("reference_invoice_id", true); }
    }
    public TypeEnum CreditNoteEstimateType {
      get { return GetEnum<TypeEnum>("type", true); }
    }
    public PriceTypeEnum PriceType {
      get { return GetEnum<PriceTypeEnum>("price_type", true); }
    }
    public string CurrencyCode {
      get { return GetValue<string>("currency_code", true); }
    }
    public int SubTotal {
      get { return GetValue<int>("sub_total", true); }
    }
    public int Total {
      get { return GetValue<int>("total", true); }
    }
    public int AmountAllocated {
      get { return GetValue<int>("amount_allocated", true); }
    }
    public int AmountAvailable {
      get { return GetValue<int>("amount_available", true); }
    }
    public List<CreditNoteEstimateLineItem> LineItems {
      get { return GetResourceList<CreditNoteEstimateLineItem>("line_items"); }
    }
    public List<CreditNoteEstimateDiscount> Discounts {
      get { return GetResourceList<CreditNoteEstimateDiscount>("discounts"); }
    }
    public List<CreditNoteEstimateTax> Taxes {
      get { return GetResourceList<CreditNoteEstimateTax>("taxes"); }
    }
    public List<CreditNoteEstimateLineItemTax> LineItemTaxes {
      get { return GetResourceList<CreditNoteEstimateLineItemTax>("line_ite_taxes"); }
    }

    public enum TypeEnum {
      Unknown,
      [Description("adjustment")]
      Adjustment,
      [Description("refundable")]
      Refundable,
    }

    public class CreditNoteEstimateLineItem : Resource {
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

    public class CreditNoteEstimateDiscount : Resource {
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

    public class CreditNoteEstimateTax : Resource {
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

    public class CreditNoteEstimateLineItemTax : Resource {
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
  }
}
