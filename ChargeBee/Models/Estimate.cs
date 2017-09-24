namespace RealArtists.ChargeBee.Models {
  using System;
  using System.Collections.Generic;
  using System.Net.Http;
  using RealArtists.ChargeBee.Api;
  using RealArtists.ChargeBee.Internal;
  using RealArtists.ChargeBee.Models.Enums;

  public class EstimateActions : ApiResourceActions {
    public EstimateActions(ChargeBeeApi api) : base(api) { }

    public Estimate.CreateSubscriptionRequest CreateSubscription() {
      string url = BuildUrl("estimates", "create_subscription");
      return new Estimate.CreateSubscriptionRequest(Api, url, HttpMethod.Post);
    }

    public Estimate.CreateSubForCustomerEstimateRequest CreateSubForCustomerEstimate(string id) {
      string url = BuildUrl("customers", id, "create_subscription_estimate");
      return new Estimate.CreateSubForCustomerEstimateRequest(Api, url, HttpMethod.Get);
    }

    public Estimate.UpdateSubscriptionRequest UpdateSubscription() {
      string url = BuildUrl("estimates", "update_subscription");
      return new Estimate.UpdateSubscriptionRequest(Api, url, HttpMethod.Post);
    }

    public Estimate.RenewalEstimateRequest RenewalEstimate(string id) {
      string url = BuildUrl("subscriptions", id, "renewal_estimate");
      return new Estimate.RenewalEstimateRequest(Api, url, HttpMethod.Get);
    }

    public EntityRequest<Type> UpcomingInvoicesEstimate(string id) {
      string url = BuildUrl("customers", id, "upcoming_invoices_estimate");
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }

    public Estimate.ChangeTermEndRequest ChangeTermEnd(string id) {
      string url = BuildUrl("subscriptions", id, "change_term_end_estimate");
      return new Estimate.ChangeTermEndRequest(Api, url, HttpMethod.Post);
    }

    public Estimate.CancelSubscriptionRequest CancelSubscription(string id) {
      string url = BuildUrl("subscriptions", id, "cancel_subscription_estimate");
      return new Estimate.CancelSubscriptionRequest(Api, url, HttpMethod.Post);
    }
  }

  public class Estimate : Resource {
    public DateTime CreatedAt {
      get { return (DateTime)GetDateTime("created_at", true); }
    }
    public SubscriptionEstimate SubscriptionEstimate {
      get { return GetSubResource<SubscriptionEstimate>("subscription_estimate"); }
    }
    public InvoiceEstimate InvoiceEstimate {
      get { return GetSubResource<InvoiceEstimate>("invoice_estimate"); }
    }
    public List<InvoiceEstimate> InvoiceEstimates {
      get { return GetResourceList<InvoiceEstimate>("invoice_estimates"); }
    }
    public InvoiceEstimate NextInvoiceEstimate {
      get { return GetSubResource<InvoiceEstimate>("next_invoice_estimate"); }
    }
    public List<CreditNoteEstimate> CreditNoteEstimates {
      get { return GetResourceList<CreditNoteEstimate>("credit_note_estimates"); }
    }
    public List<UnbilledCharge> UnbilledChargeEstimates {
      get { return GetResourceList<UnbilledCharge>("unbilled_charge_estimates"); }
    }

    public class CreateSubscriptionRequest : EntityRequest<CreateSubscriptionRequest> {
      public CreateSubscriptionRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CreateSubscriptionRequest BillingCycles(int billingCycles) {
        _params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
      public CreateSubscriptionRequest TermsToCharge(int termsToCharge) {
        _params.AddOpt("terms_to_charge", termsToCharge);
        return this;
      }
      public CreateSubscriptionRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) {
        _params.AddOpt("billing_alignment_mode", billingAlignmentMode);
        return this;
      }
      public CreateSubscriptionRequest CouponIds(List<string> couponIds) {
        _params.AddOpt("coupon_ids", couponIds);
        return this;
      }
      public CreateSubscriptionRequest InvoiceImmediately(bool invoiceImmediately) {
        _params.AddOpt("invoice_immediately", invoiceImmediately);
        return this;
      }
      public CreateSubscriptionRequest SubscriptionId(string subscriptionId) {
        _params.AddOpt("subscription[id]", subscriptionId);
        return this;
      }
      public CreateSubscriptionRequest SubscriptionPlanId(string subscriptionPlanId) {
        _params.Add("subscription[plan_id]", subscriptionPlanId);
        return this;
      }
      public CreateSubscriptionRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) {
        _params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
        return this;
      }
      public CreateSubscriptionRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) {
        _params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
        return this;
      }
      public CreateSubscriptionRequest SubscriptionSetupFee(int subscriptionSetupFee) {
        _params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
        return this;
      }
      public CreateSubscriptionRequest SubscriptionStartDate(long subscriptionStartDate) {
        _params.AddOpt("subscription[start_date]", subscriptionStartDate);
        return this;
      }
      public CreateSubscriptionRequest SubscriptionTrialEnd(long subscriptionTrialEnd) {
        _params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressLine1(string billingAddressLine1) {
        _params.AddOpt("billing_address[line1]", billingAddressLine1);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressLine2(string billingAddressLine2) {
        _params.AddOpt("billing_address[line2]", billingAddressLine2);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressLine3(string billingAddressLine3) {
        _params.AddOpt("billing_address[line3]", billingAddressLine3);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressCity(string billingAddressCity) {
        _params.AddOpt("billing_address[city]", billingAddressCity);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressStateCode(string billingAddressStateCode) {
        _params.AddOpt("billing_address[state_code]", billingAddressStateCode);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressZip(string billingAddressZip) {
        _params.AddOpt("billing_address[zip]", billingAddressZip);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressCountry(string billingAddressCountry) {
        _params.AddOpt("billing_address[country]", billingAddressCountry);
        return this;
      }
      public CreateSubscriptionRequest BillingAddressValidationStatus(ValidationStatusEnum billingAddressValidationStatus) {
        _params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressLine1(string shippingAddressLine1) {
        _params.AddOpt("shipping_address[line1]", shippingAddressLine1);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressLine2(string shippingAddressLine2) {
        _params.AddOpt("shipping_address[line2]", shippingAddressLine2);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressLine3(string shippingAddressLine3) {
        _params.AddOpt("shipping_address[line3]", shippingAddressLine3);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressCity(string shippingAddressCity) {
        _params.AddOpt("shipping_address[city]", shippingAddressCity);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressStateCode(string shippingAddressStateCode) {
        _params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressZip(string shippingAddressZip) {
        _params.AddOpt("shipping_address[zip]", shippingAddressZip);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressCountry(string shippingAddressCountry) {
        _params.AddOpt("shipping_address[country]", shippingAddressCountry);
        return this;
      }
      public CreateSubscriptionRequest ShippingAddressValidationStatus(ValidationStatusEnum shippingAddressValidationStatus) {
        _params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
        return this;
      }
      public CreateSubscriptionRequest CustomerVatNumber(string customerVatNumber) {
        _params.AddOpt("customer[vat_number]", customerVatNumber);
        return this;
      }
      public CreateSubscriptionRequest CustomerRegisteredForGst(bool customerRegisteredForGst) {
        _params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
        return this;
      }
      public CreateSubscriptionRequest CustomerTaxability(TaxabilityEnum customerTaxability) {
        _params.AddOpt("customer[taxability]", customerTaxability);
        return this;
      }
      public CreateSubscriptionRequest CustomerEntityCode(EntityCodeEnum customerEntityCode) {
        _params.AddOpt("customer[entity_code]", customerEntityCode);
        return this;
      }
      public CreateSubscriptionRequest CustomerExemptNumber(string customerExemptNumber) {
        _params.AddOpt("customer[exempt_number]", customerExemptNumber);
        return this;
      }
      public CreateSubscriptionRequest AddonId(int index, string addonId) {
        _params.AddOpt("addons[id][" + index + "]", addonId);
        return this;
      }
      public CreateSubscriptionRequest AddonQuantity(int index, int addonQuantity) {
        _params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
        return this;
      }
      public CreateSubscriptionRequest AddonUnitPrice(int index, int addonUnitPrice) {
        _params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
        return this;
      }
      public CreateSubscriptionRequest AddonTrialEnd(int index, long addonTrialEnd) {
        _params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
        return this;
      }
    }

    public class CreateSubForCustomerEstimateRequest : EntityRequest<CreateSubForCustomerEstimateRequest> {
      public CreateSubForCustomerEstimateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CreateSubForCustomerEstimateRequest UseExistingBalances(bool useExistingBalances) {
        _params.AddOpt("use_existing_balances", useExistingBalances);
        return this;
      }
      public CreateSubForCustomerEstimateRequest InvoiceImmediately(bool invoiceImmediately) {
        _params.AddOpt("invoice_immediately", invoiceImmediately);
        return this;
      }
      public CreateSubForCustomerEstimateRequest BillingCycles(int billingCycles) {
        _params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
      public CreateSubForCustomerEstimateRequest TermsToCharge(int termsToCharge) {
        _params.AddOpt("terms_to_charge", termsToCharge);
        return this;
      }
      public CreateSubForCustomerEstimateRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) {
        _params.AddOpt("billing_alignment_mode", billingAlignmentMode);
        return this;
      }
      public CreateSubForCustomerEstimateRequest CouponIds(List<string> couponIds) {
        _params.AddOpt("coupon_ids", couponIds);
        return this;
      }
      public CreateSubForCustomerEstimateRequest SubscriptionId(string subscriptionId) {
        _params.AddOpt("subscription[id]", subscriptionId);
        return this;
      }
      public CreateSubForCustomerEstimateRequest SubscriptionPlanId(string subscriptionPlanId) {
        _params.Add("subscription[plan_id]", subscriptionPlanId);
        return this;
      }
      public CreateSubForCustomerEstimateRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) {
        _params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
        return this;
      }
      public CreateSubForCustomerEstimateRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) {
        _params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
        return this;
      }
      public CreateSubForCustomerEstimateRequest SubscriptionSetupFee(int subscriptionSetupFee) {
        _params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
        return this;
      }
      public CreateSubForCustomerEstimateRequest SubscriptionStartDate(long subscriptionStartDate) {
        _params.AddOpt("subscription[start_date]", subscriptionStartDate);
        return this;
      }
      public CreateSubForCustomerEstimateRequest SubscriptionTrialEnd(long subscriptionTrialEnd) {
        _params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
        return this;
      }
      public CreateSubForCustomerEstimateRequest ShippingAddressLine1(string shippingAddressLine1) {
        _params.AddOpt("shipping_address[line1]", shippingAddressLine1);
        return this;
      }
      public CreateSubForCustomerEstimateRequest ShippingAddressLine2(string shippingAddressLine2) {
        _params.AddOpt("shipping_address[line2]", shippingAddressLine2);
        return this;
      }
      public CreateSubForCustomerEstimateRequest ShippingAddressLine3(string shippingAddressLine3) {
        _params.AddOpt("shipping_address[line3]", shippingAddressLine3);
        return this;
      }
      public CreateSubForCustomerEstimateRequest ShippingAddressCity(string shippingAddressCity) {
        _params.AddOpt("shipping_address[city]", shippingAddressCity);
        return this;
      }
      public CreateSubForCustomerEstimateRequest ShippingAddressStateCode(string shippingAddressStateCode) {
        _params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
        return this;
      }
      public CreateSubForCustomerEstimateRequest ShippingAddressZip(string shippingAddressZip) {
        _params.AddOpt("shipping_address[zip]", shippingAddressZip);
        return this;
      }
      public CreateSubForCustomerEstimateRequest ShippingAddressCountry(string shippingAddressCountry) {
        _params.AddOpt("shipping_address[country]", shippingAddressCountry);
        return this;
      }
      public CreateSubForCustomerEstimateRequest ShippingAddressValidationStatus(ValidationStatusEnum shippingAddressValidationStatus) {
        _params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
        return this;
      }
      public CreateSubForCustomerEstimateRequest AddonId(int index, string addonId) {
        _params.AddOpt("addons[id][" + index + "]", addonId);
        return this;
      }
      public CreateSubForCustomerEstimateRequest AddonQuantity(int index, int addonQuantity) {
        _params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
        return this;
      }
      public CreateSubForCustomerEstimateRequest AddonUnitPrice(int index, int addonUnitPrice) {
        _params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
        return this;
      }
      public CreateSubForCustomerEstimateRequest AddonTrialEnd(int index, long addonTrialEnd) {
        _params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
        return this;
      }
    }

    public class UpdateSubscriptionRequest : EntityRequest<UpdateSubscriptionRequest> {
      public UpdateSubscriptionRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public UpdateSubscriptionRequest BillingCycles(int billingCycles) {
        _params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
      public UpdateSubscriptionRequest ReplaceAddonList(bool replaceAddonList) {
        _params.AddOpt("replace_addon_list", replaceAddonList);
        return this;
      }
      public UpdateSubscriptionRequest TermsToCharge(int termsToCharge) {
        _params.AddOpt("terms_to_charge", termsToCharge);
        return this;
      }
      public UpdateSubscriptionRequest ReactivateFrom(long reactivateFrom) {
        _params.AddOpt("reactivate_from", reactivateFrom);
        return this;
      }
      public UpdateSubscriptionRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) {
        _params.AddOpt("billing_alignment_mode", billingAlignmentMode);
        return this;
      }
      public UpdateSubscriptionRequest CouponIds(List<string> couponIds) {
        _params.AddOpt("coupon_ids", couponIds);
        return this;
      }
      public UpdateSubscriptionRequest ReplaceCouponList(bool replaceCouponList) {
        _params.AddOpt("replace_coupon_list", replaceCouponList);
        return this;
      }
      public UpdateSubscriptionRequest Prorate(bool prorate) {
        _params.AddOpt("prorate", prorate);
        return this;
      }
      public UpdateSubscriptionRequest EndOfTerm(bool endOfTerm) {
        _params.AddOpt("end_of_term", endOfTerm);
        return this;
      }
      public UpdateSubscriptionRequest ForceTermReset(bool forceTermReset) {
        _params.AddOpt("force_ter_reset", forceTermReset);
        return this;
      }
      public UpdateSubscriptionRequest Reactivate(bool reactivate) {
        _params.AddOpt("reactivate", reactivate);
        return this;
      }
      public UpdateSubscriptionRequest IncludeDelayedCharges(bool includeDelayedCharges) {
        _params.AddOpt("include_delayed_charges", includeDelayedCharges);
        return this;
      }
      public UpdateSubscriptionRequest UseExistingBalances(bool useExistingBalances) {
        _params.AddOpt("use_existing_balances", useExistingBalances);
        return this;
      }
      public UpdateSubscriptionRequest InvoiceImmediately(bool invoiceImmediately) {
        _params.AddOpt("invoice_immediately", invoiceImmediately);
        return this;
      }
      public UpdateSubscriptionRequest SubscriptionId(string subscriptionId) {
        _params.Add("subscription[id]", subscriptionId);
        return this;
      }
      public UpdateSubscriptionRequest SubscriptionPlanId(string subscriptionPlanId) {
        _params.AddOpt("subscription[plan_id]", subscriptionPlanId);
        return this;
      }
      public UpdateSubscriptionRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) {
        _params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
        return this;
      }
      public UpdateSubscriptionRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) {
        _params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
        return this;
      }
      public UpdateSubscriptionRequest SubscriptionSetupFee(int subscriptionSetupFee) {
        _params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
        return this;
      }
      public UpdateSubscriptionRequest SubscriptionStartDate(long subscriptionStartDate) {
        _params.AddOpt("subscription[start_date]", subscriptionStartDate);
        return this;
      }
      public UpdateSubscriptionRequest SubscriptionTrialEnd(long subscriptionTrialEnd) {
        _params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressLine1(string billingAddressLine1) {
        _params.AddOpt("billing_address[line1]", billingAddressLine1);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressLine2(string billingAddressLine2) {
        _params.AddOpt("billing_address[line2]", billingAddressLine2);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressLine3(string billingAddressLine3) {
        _params.AddOpt("billing_address[line3]", billingAddressLine3);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressCity(string billingAddressCity) {
        _params.AddOpt("billing_address[city]", billingAddressCity);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressStateCode(string billingAddressStateCode) {
        _params.AddOpt("billing_address[state_code]", billingAddressStateCode);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressZip(string billingAddressZip) {
        _params.AddOpt("billing_address[zip]", billingAddressZip);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressCountry(string billingAddressCountry) {
        _params.AddOpt("billing_address[country]", billingAddressCountry);
        return this;
      }
      public UpdateSubscriptionRequest BillingAddressValidationStatus(ValidationStatusEnum billingAddressValidationStatus) {
        _params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressLine1(string shippingAddressLine1) {
        _params.AddOpt("shipping_address[line1]", shippingAddressLine1);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressLine2(string shippingAddressLine2) {
        _params.AddOpt("shipping_address[line2]", shippingAddressLine2);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressLine3(string shippingAddressLine3) {
        _params.AddOpt("shipping_address[line3]", shippingAddressLine3);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressCity(string shippingAddressCity) {
        _params.AddOpt("shipping_address[city]", shippingAddressCity);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressStateCode(string shippingAddressStateCode) {
        _params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressZip(string shippingAddressZip) {
        _params.AddOpt("shipping_address[zip]", shippingAddressZip);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressCountry(string shippingAddressCountry) {
        _params.AddOpt("shipping_address[country]", shippingAddressCountry);
        return this;
      }
      public UpdateSubscriptionRequest ShippingAddressValidationStatus(ValidationStatusEnum shippingAddressValidationStatus) {
        _params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
        return this;
      }
      public UpdateSubscriptionRequest CustomerVatNumber(string customerVatNumber) {
        _params.AddOpt("customer[vat_number]", customerVatNumber);
        return this;
      }
      public UpdateSubscriptionRequest CustomerRegisteredForGst(bool customerRegisteredForGst) {
        _params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
        return this;
      }
      public UpdateSubscriptionRequest AddonId(int index, string addonId) {
        _params.AddOpt("addons[id][" + index + "]", addonId);
        return this;
      }
      public UpdateSubscriptionRequest AddonQuantity(int index, int addonQuantity) {
        _params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
        return this;
      }
      public UpdateSubscriptionRequest AddonUnitPrice(int index, int addonUnitPrice) {
        _params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
        return this;
      }
      public UpdateSubscriptionRequest AddonTrialEnd(int index, long addonTrialEnd) {
        _params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
        return this;
      }
    }

    public class RenewalEstimateRequest : EntityRequest<RenewalEstimateRequest> {
      public RenewalEstimateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public RenewalEstimateRequest IncludeDelayedCharges(bool includeDelayedCharges) {
        _params.AddOpt("include_delayed_charges", includeDelayedCharges);
        return this;
      }

      public RenewalEstimateRequest UseExistingBalances(bool useExistingBalances) {
        _params.AddOpt("use_existing_balances", useExistingBalances);
        return this;
      }
      public RenewalEstimateRequest IgnoreScheduledCancellation(bool ignoreScheduledCancellation) {
        _params.AddOpt("ignore_scheduled_cancellation", ignoreScheduledCancellation);
        return this;
      }
      public RenewalEstimateRequest IgnoreScheduledChanges(bool ignoreScheduledChanges) {
        _params.AddOpt("ignore_scheduled_changes", ignoreScheduledChanges);
        return this;
      }
    }

    public class ChangeTermEndRequest : EntityRequest<ChangeTermEndRequest> {
      public ChangeTermEndRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public ChangeTermEndRequest TermEndsAt(long termEndsAt) {
        _params.AddOpt("term_ends_at", termEndsAt);
        return this;
      }
      public ChangeTermEndRequest Prorate(bool prorate) {
        _params.AddOpt("prorate", prorate);
        return this;
      }
      public ChangeTermEndRequest InvoiceImmediately(bool invoiceImmediately) {
        _params.AddOpt("invoice_immediately", invoiceImmediately);
        return this;
      }
    }

    public class CancelSubscriptionRequest : EntityRequest<CancelSubscriptionRequest> {
      public CancelSubscriptionRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CancelSubscriptionRequest EndOfTerm(bool endOfTerm) {
        _params.AddOpt("end_of_term", endOfTerm);
        return this;
      }
      public CancelSubscriptionRequest CreditOptionForCurrentTermCharges(CreditOptionForCurrentTermChargesEnum creditOptionForCurrentTermCharges) {
        _params.AddOpt("credit_option_for_current_term_charges", creditOptionForCurrentTermCharges);
        return this;
      }
      public CancelSubscriptionRequest UnbilledChargesOption(UnbilledChargesOptionEnum unbilledChargesOption) {
        _params.AddOpt("unbilled_charges_option", unbilledChargesOption);
        return this;
      }
      public CancelSubscriptionRequest AccountReceivablesHandling(AccountReceivablesHandlingEnum accountReceivablesHandling) {
        _params.AddOpt("account_receivables_handling", accountReceivablesHandling);
        return this;
      }
      public CancelSubscriptionRequest RefundableCreditsHandling(RefundableCreditsHandlingEnum refundableCreditsHandling) {
        _params.AddOpt("refundable_credits_handling", refundableCreditsHandling);
        return this;
      }
    }
  }
}
