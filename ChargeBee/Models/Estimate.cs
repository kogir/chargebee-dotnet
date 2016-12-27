namespace ChargeBee.Models {
  using System;
  using System.Collections.Generic;
  using System.Net.Http;
  using ChargeBee.Api;
  using ChargeBee.Internal;
  using ChargeBee.Models.Enums;

  public class Estimate : Resource {
    public static CreateSubscriptionRequest CreateSubscription() {
      string url = ApiUtil.BuildUrl("estimates", "create_subscription");
      return new CreateSubscriptionRequest(url, HttpMethod.Post);
    }
    public static UpdateSubscriptionRequest UpdateSubscription() {
      string url = ApiUtil.BuildUrl("estimates", "update_subscription");
      return new UpdateSubscriptionRequest(url, HttpMethod.Post);
    }
    public static RenewalEstimateRequest RenewalEstimate(string id) {
      string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "renewal_estimate");
      return new RenewalEstimateRequest(url, HttpMethod.Get);
    }

    public DateTime CreatedAt {
      get { return (DateTime)GetDateTime("created_at", true); }
    }
    public SubscriptionEstimate SubscriptionEstimate {
      get { return GetSubResource<SubscriptionEstimate>("subscription_estimate"); }
    }
    public InvoiceEstimate InvoiceEstimate {
      get { return GetSubResource<InvoiceEstimate>("invoice_estimate"); }
    }
    public InvoiceEstimate NextInvoiceEstimate {
      get { return GetSubResource<InvoiceEstimate>("next_invoice_estimate"); }
    }
    public List<CreditNoteEstimate> CreditNoteEstimates {
      get { return GetResourceList<CreditNoteEstimate>("credit_note_estimates"); }
    }

    public class CreateSubscriptionRequest : EntityRequest<CreateSubscriptionRequest> {
      public CreateSubscriptionRequest(string url, HttpMethod method)
              : base(url, method) {
      }

      public CreateSubscriptionRequest BillingCycles(int billingCycles) {
        m_params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
      public CreateSubscriptionRequest CouponIds(List<string> couponIds) {
        m_params.AddOpt("coupon_ids", couponIds);
        return this;
      }
      public CreateSubscriptionRequest SubscriptionId(string subscriptionId) {
        m_params.AddOpt("subscription[id]", subscriptionId);
        return this;
      }
      public CreateSubscriptionRequest SubscriptionPlanId(string subscriptionPlanId) {
        m_params.Add("subscription[plan_id]", subscriptionPlanId);
        return this;
      }
      public CreateSubscriptionRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) {
        m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
        return this;
      }
      public CreateSubscriptionRequest SubscriptionStartDate(long subscriptionStartDate) {
        m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
        return this;
      }
      public CreateSubscriptionRequest SubscriptionTrialEnd(long subscriptionTrialEnd) {
        m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
        return this;
      }
      [Obsolete]
      public CreateSubscriptionRequest SubscriptionCoupon(string subscriptionCoupon) {
        m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressLine1(string billingAddressLine1) {
        m_params.AddOpt("billing_address[line1]", billingAddressLine1);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressLine2(string billingAddressLine2) {
        m_params.AddOpt("billing_address[line2]", billingAddressLine2);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressLine3(string billingAddressLine3) {
        m_params.AddOpt("billing_address[line3]", billingAddressLine3);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressCity(string billingAddressCity) {
        m_params.AddOpt("billing_address[city]", billingAddressCity);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressStateCode(string billingAddressStateCode) {
        m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressZip(string billingAddressZip) {
        m_params.AddOpt("billing_address[zip]", billingAddressZip);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressCountry(string billingAddressCountry) {
        m_params.AddOpt("billing_address[country]", billingAddressCountry);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressValidationStatus(ValidationStatusEnum billingAddressValidationStatus) {
        m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressLine1(string shippingAddressLine1) {
        m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressLine2(string shippingAddressLine2) {
        m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressLine3(string shippingAddressLine3) {
        m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressCity(string shippingAddressCity) {
        m_params.AddOpt("shipping_address[city]", shippingAddressCity);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressStateCode(string shippingAddressStateCode) {
        m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressZip(string shippingAddressZip) {
        m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressCountry(string shippingAddressCountry) {
        m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressValidationStatus(ValidationStatusEnum shippingAddressValidationStatus) {
        m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
        return this;
      }
      public CreateSubscriptionRequest CustomerVatNumber(string customerVatNumber) {
        m_params.AddOpt("customer[vat_number]", customerVatNumber);
        return this;
      }
      public CreateSubscriptionRequest CustomerTaxability(TaxabilityEnum customerTaxability) {
        m_params.AddOpt("customer[taxability]", customerTaxability);
        return this;
      }
      public CreateSubscriptionRequest CustomerEntityCode(EntityCodeEnum customerEntityCode) {
        m_params.AddOpt("customer[entity_code]", customerEntityCode);
        return this;
      }
      public CreateSubscriptionRequest CustomerExemptNumber(string customerExemptNumber) {
        m_params.AddOpt("customer[exempt_number]", customerExemptNumber);
        return this;
      }
      public CreateSubscriptionRequest AddonId(int index, string addonId) {
        m_params.AddOpt("addons[id][" + index + "]", addonId);
        return this;
      }
      public CreateSubscriptionRequest AddonQuantity(int index, int addonQuantity) {
        m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
        return this;
      }
    }

    public class UpdateSubscriptionRequest : EntityRequest<UpdateSubscriptionRequest> {
      public UpdateSubscriptionRequest(string url, HttpMethod method)
              : base(url, method) {
      }

      public UpdateSubscriptionRequest BillingCycles(int billingCycles) {
        m_params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
      public UpdateSubscriptionRequest ReplaceAddonList(bool replaceAddonList) {
        m_params.AddOpt("replace_addon_list", replaceAddonList);
        return this;
      }
      public UpdateSubscriptionRequest CouponIds(List<string> couponIds) {
        m_params.AddOpt("coupon_ids", couponIds);
        return this;
      }
      public UpdateSubscriptionRequest ReplaceCouponList(bool replaceCouponList) {
        m_params.AddOpt("replace_coupon_list", replaceCouponList);
        return this;
      }
      public UpdateSubscriptionRequest Prorate(bool prorate) {
        m_params.AddOpt("prorate", prorate);
        return this;
      }
      public UpdateSubscriptionRequest EndOfTerm(bool endOfTerm) {
        m_params.AddOpt("end_of_term", endOfTerm);
        return this;
      }
      public UpdateSubscriptionRequest ForceTermReset(bool forceTermReset) {
        m_params.AddOpt("force_term_reset", forceTermReset);
        return this;
      }
      public UpdateSubscriptionRequest IncludeDelayedCharges(bool includeDelayedCharges) {
        m_params.AddOpt("include_delayed_charges", includeDelayedCharges);
        return this;
      }
      public UpdateSubscriptionRequest UseExistingBalances(bool useExistingBalances) {
        m_params.AddOpt("use_existing_balances", useExistingBalances);
        return this;
      }
      public UpdateSubscriptionRequest SubscriptionId(string subscriptionId) {
        m_params.Add("subscription[id]", subscriptionId);
        return this;
      }
      public UpdateSubscriptionRequest SubscriptionPlanId(string subscriptionPlanId) {
        m_params.AddOpt("subscription[plan_id]", subscriptionPlanId);
        return this;
      }
      public UpdateSubscriptionRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) {
        m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
        return this;
      }
      public UpdateSubscriptionRequest SubscriptionStartDate(long subscriptionStartDate) {
        m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
        return this;
      }
      public UpdateSubscriptionRequest SubscriptionTrialEnd(long subscriptionTrialEnd) {
        m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
        return this;
      }
      [Obsolete]
      public UpdateSubscriptionRequest SubscriptionCoupon(string subscriptionCoupon) {
        m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressLine1(string billingAddressLine1) {
        m_params.AddOpt("billing_address[line1]", billingAddressLine1);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressLine2(string billingAddressLine2) {
        m_params.AddOpt("billing_address[line2]", billingAddressLine2);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressLine3(string billingAddressLine3) {
        m_params.AddOpt("billing_address[line3]", billingAddressLine3);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressCity(string billingAddressCity) {
        m_params.AddOpt("billing_address[city]", billingAddressCity);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressStateCode(string billingAddressStateCode) {
        m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressZip(string billingAddressZip) {
        m_params.AddOpt("billing_address[zip]", billingAddressZip);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressCountry(string billingAddressCountry) {
        m_params.AddOpt("billing_address[country]", billingAddressCountry);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressValidationStatus(ValidationStatusEnum billingAddressValidationStatus) {
        m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressLine1(string shippingAddressLine1) {
        m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressLine2(string shippingAddressLine2) {
        m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressLine3(string shippingAddressLine3) {
        m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressCity(string shippingAddressCity) {
        m_params.AddOpt("shipping_address[city]", shippingAddressCity);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressStateCode(string shippingAddressStateCode) {
        m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressZip(string shippingAddressZip) {
        m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressCountry(string shippingAddressCountry) {
        m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressValidationStatus(ValidationStatusEnum shippingAddressValidationStatus) {
        m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
        return this;
      }
      public UpdateSubscriptionRequest CustomerVatNumber(string customerVatNumber) {
        m_params.AddOpt("customer[vat_number]", customerVatNumber);
        return this;
      }
      [Obsolete]
      public UpdateSubscriptionRequest CustomerTaxability(TaxabilityEnum customerTaxability) {
        m_params.AddOpt("customer[taxability]", customerTaxability);
        return this;
      }
      public UpdateSubscriptionRequest AddonId(int index, string addonId) {
        m_params.AddOpt("addons[id][" + index + "]", addonId);
        return this;
      }
      public UpdateSubscriptionRequest AddonQuantity(int index, int addonQuantity) {
        m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
        return this;
      }
    }

    public class RenewalEstimateRequest : EntityRequest<RenewalEstimateRequest> {
      public RenewalEstimateRequest(string url, HttpMethod method)
              : base(url, method) {
      }

      public RenewalEstimateRequest IncludeDelayedCharges(bool includeDelayedCharges) {
        m_params.AddOpt("include_delayed_charges", includeDelayedCharges);
        return this;
      }

      public RenewalEstimateRequest UseExistingBalances(bool useExistingBalances) {
        m_params.AddOpt("use_existing_balances", useExistingBalances);
        return this;
      }
    }
  }
}
