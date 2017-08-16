namespace RealArtists.ChargeBee.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using RealArtists.ChargeBee.Internal;
  using RealArtists.ChargeBee.Models.Enums;

  public class InvoiceEstimate : Resource {
    public bool Recurring {
      get { return GetValue<bool>("recurring", true); }
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
    public int? Total {
      get { return GetValue<int?>("total", false); }
    }
    public int? CreditsApplied {
      get { return GetValue<int?>("credits_applied", false); }
    }
    public int? AmountPaid {
      get { return GetValue<int?>("amount_paid", false); }
    }
    public int? AmountDue {
      get { return GetValue<int?>("amount_due", false); }
    }
    public List<InvoiceEstimateLineItem> LineItems {
      get { return GetResourceList<InvoiceEstimateLineItem>("line_items"); }
    }
    public List<InvoiceEstimateDiscount> Discounts {
      get { return GetResourceList<InvoiceEstimateDiscount>("discounts"); }
    }
    public List<InvoiceEstimateTax> Taxes {
      get { return GetResourceList<InvoiceEstimateTax>("taxes"); }
    }
    public List<InvoiceEstimateLineItemTax> LineItemTaxes {
      get { return GetResourceList<InvoiceEstimateLineItemTax>("line_ite_taxes"); }
    }
    public List<InvoiceEstimateLineItemDiscount> LineItemDiscounts {
      get { return GetResourceList<InvoiceEstimateLineItemDiscount>("line_item_discounts"); }
    }

    public class InvoiceEstimateLineItem : Resource {
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

      public string SubscriptionId() {
        return GetValue<string>("subscription_id", false);
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

      public TaxExemptReasonEnum? TaxExemptReason() {
        return GetEnum<TaxExemptReasonEnum>("tax_exempt_reason", false);
      }

      public string EntityId() {
        return GetValue<string>("entity_id", false);
      }
    }

    public class InvoiceEstimateDiscount : Resource {
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

    public class InvoiceEstimateTax : Resource {
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

    public class InvoiceEstimateLineItemTax : Resource {
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

    public class InvoiceEstimateLineItemDiscount : Resource {
      public enum DiscountTypeEnum {
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

      public string LineItemId() {
        return GetValue<string>("line_item_id", true);
      }

      public DiscountTypeEnum DiscountType() {
        return GetEnum<DiscountTypeEnum>("discount_type", true);
      }

      public string CouponId() {
        return GetValue<string>("coupon_id", false);
      }

      public int DiscountAmount() {
        return GetValue<int>("discount_amount", true);
      }
    }
  }
}
