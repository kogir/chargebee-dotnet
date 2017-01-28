namespace RealArtists.ChargeBee.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Net.Http;
  using Newtonsoft.Json.Linq;
  using RealArtists.ChargeBee.Api;
  using RealArtists.ChargeBee.Filters.Enums;
  using RealArtists.ChargeBee.Internal;
  using RealArtists.ChargeBee.Models.Enums;

  public class SubScriptionActions : ApiResourceActions {
    public SubScriptionActions(ChargeBeeApi api) : base(api) { }

    public Subscription.CreateRequest Create() {
      string url = BuildUrl("subscriptions");
      return new Subscription.CreateRequest(Api, url, HttpMethod.Post);
    }

    public Subscription.CreateForCustomerRequest CreateForCustomer(string id) {
      string url = BuildUrl("customers", id, "subscriptions");
      return new Subscription.CreateForCustomerRequest(Api, url, HttpMethod.Post);
    }

    public Subscription.SubscriptionListRequest List() {
      string url = BuildUrl("subscriptions");
      return new Subscription.SubscriptionListRequest(Api, url);
    }

    public EntityRequest<Type> Retrieve(string id) {
      string url = BuildUrl("subscriptions", id);
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }

    public EntityRequest<Type> RetrieveWithScheduledChanges(string id) {
      string url = BuildUrl("subscriptions", id, "retrieve_with_scheduled_changes");
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }

    public EntityRequest<Type> RemoveScheduledChanges(string id) {
      string url = BuildUrl("subscriptions", id, "remove_scheduled_changes");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }

    public Subscription.RemoveScheduledCancellationRequest RemoveScheduledCancellation(string id) {
      string url = BuildUrl("subscriptions", id, "remove_scheduled_cancellation");
      return new Subscription.RemoveScheduledCancellationRequest(Api, url, HttpMethod.Post);
    }

    public Subscription.RemoveCouponsRequest RemoveCoupons(string id) {
      string url = BuildUrl("subscriptions", id, "remove_coupons");
      return new Subscription.RemoveCouponsRequest(Api, url, HttpMethod.Post);
    }

    public Subscription.UpdateRequest Update(string id) {
      string url = BuildUrl("subscriptions", id);
      return new Subscription.UpdateRequest(Api, url, HttpMethod.Post);
    }

    public Subscription.ChangeTermEndRequest ChangeTermEnd(string id) {
      string url = BuildUrl("subscriptions", id, "change_ter_end");
      return new Subscription.ChangeTermEndRequest(Api, url, HttpMethod.Post);
    }

    public Subscription.CancelRequest Cancel(string id) {
      string url = BuildUrl("subscriptions", id, "cancel");
      return new Subscription.CancelRequest(Api, url, HttpMethod.Post);
    }

    public Subscription.ReactivateRequest Reactivate(string id) {
      string url = BuildUrl("subscriptions", id, "reactivate");
      return new Subscription.ReactivateRequest(Api, url, HttpMethod.Post);
    }

    public Subscription.AddChargeAtTermEndRequest AddChargeAtTermEnd(string id) {
      string url = BuildUrl("subscriptions", id, "add_charge_at_ter_end");
      return new Subscription.AddChargeAtTermEndRequest(Api, url, HttpMethod.Post);
    }

    public Subscription.ChargeAddonAtTermEndRequest ChargeAddonAtTermEnd(string id) {
      string url = BuildUrl("subscriptions", id, "charge_addon_at_ter_end");
      return new Subscription.ChargeAddonAtTermEndRequest(Api, url, HttpMethod.Post);
    }

    public Subscription.ImportSubscriptionRequest ImportSubscription() {
      string url = BuildUrl("subscriptions", "import_subscription");
      return new Subscription.ImportSubscriptionRequest(Api, url, HttpMethod.Post);
    }

    public Subscription.ImportForCustomerRequest ImportForCustomer(string id) {
      string url = BuildUrl("customers", id, "import_subscription");
      return new Subscription.ImportForCustomerRequest(Api, url, HttpMethod.Post);
    }

    public EntityRequest<Type> Delete(string id) {
      string url = BuildUrl("subscriptions", id, "delete");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }
  }

  public class Subscription : Resource {
    public string Id {
      get { return GetValue<string>("id", true); }
    }
    public string CustomerId {
      get { return GetValue<string>("customer_id", true); }
    }
    public string CurrencyCode {
      get { return GetValue<string>("currency_code", true); }
    }
    public string PlanId {
      get { return GetValue<string>("plan_id", true); }
    }
    public int PlanQuantity {
      get { return GetValue<int>("plan_quantity", true); }
    }
    public int? PlanUnitPrice {
      get { return GetValue<int?>("plan_unit_price", false); }
    }
    public int? SetupFee {
      get { return GetValue<int?>("setup_fee", false); }
    }
    public int? BillingPeriod {
      get { return GetValue<int?>("billing_period", false); }
    }
    public BillingPeriodUnitEnum? BillingPeriodUnit {
      get { return GetEnum<BillingPeriodUnitEnum>("billing_period_unit", false); }
    }
    public int? PlanFreeQuantity {
      get { return GetValue<int?>("plan_free_quantity", false); }
    }
    public StatusEnum Status {
      get { return GetEnum<StatusEnum>("status", true); }
    }
    public DateTime? StartDate {
      get { return GetDateTime("start_date", false); }
    }
    public DateTime? TrialStart {
      get { return GetDateTime("trial_start", false); }
    }
    public DateTime? TrialEnd {
      get { return GetDateTime("trial_end", false); }
    }
    public DateTime? CurrentTermStart {
      get { return GetDateTime("current_ter_start", false); }
    }
    public DateTime? CurrentTermEnd {
      get { return GetDateTime("current_ter_end", false); }
    }
    public int? RemainingBillingCycles {
      get { return GetValue<int?>("remaining_billing_cycles", false); }
    }
    public string PoNumber {
      get { return GetValue<string>("po_number", false); }
    }
    public DateTime? CreatedAt {
      get { return GetDateTime("created_at", false); }
    }
    public DateTime? StartedAt {
      get { return GetDateTime("started_at", false); }
    }
    public DateTime? ActivatedAt {
      get { return GetDateTime("activated_at", false); }
    }
    public DateTime? CancelledAt {
      get { return GetDateTime("cancelled_at", false); }
    }
    public CancelReasonEnum? CancelReason {
      get { return GetEnum<CancelReasonEnum>("cancel_reason", false); }
    }
    public string AffiliateToken {
      get { return GetValue<string>("affiliate_token", false); }
    }
    public string CreatedFromIp {
      get { return GetValue<string>("created_fro_ip", false); }
    }
    public long? ResourceVersion {
      get { return GetValue<long?>("resource_version", false); }
    }
    public DateTime? UpdatedAt {
      get { return GetDateTime("updated_at", false); }
    }
    public bool HasScheduledChanges {
      get { return GetValue<bool>("has_scheduled_changes", true); }
    }
    public int? DueInvoicesCount {
      get { return GetValue<int?>("due_invoices_count", false); }
    }
    public DateTime? DueSince {
      get { return GetDateTime("due_since", false); }
    }
    public int? TotalDues {
      get { return GetValue<int?>("total_dues", false); }
    }
    public int? Mrr {
      get { return GetValue<int?>("mrr", false); }
    }
    public decimal? ExchangeRate {
      get { return GetValue<decimal?>("exchange_rate", false); }
    }
    public string BaseCurrencyCode {
      get { return GetValue<string>("base_currency_code", false); }
    }
    public List<SubscriptionAddon> Addons {
      get { return GetResourceList<SubscriptionAddon>("addons"); }
    }
    public List<SubscriptionCoupon> Coupons {
      get { return GetResourceList<SubscriptionCoupon>("coupons"); }
    }
    public SubscriptionShippingAddress ShippingAddress {
      get { return GetSubResource<SubscriptionShippingAddress>("shipping_address"); }
    }
    public string InvoiceNotes {
      get { return GetValue<string>("invoice_notes", false); }
    }
    public JToken MetaData {
      get { return GetJToken("meta_data", false); }
    }
    public bool Deleted {
      get { return GetValue<bool>("deleted", true); }
    }


    public class CreateRequest : EntityRequest<CreateRequest> {
      public CreateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CreateRequest Id(string id) {
        _params.AddOpt("id", id);
        return this;
      }
      public CreateRequest PlanId(string planId) {
        _params.Add("plan_id", planId);
        return this;
      }
      public CreateRequest PlanQuantity(int planQuantity) {
        _params.AddOpt("plan_quantity", planQuantity);
        return this;
      }
      public CreateRequest PlanUnitPrice(int planUnitPrice) {
        _params.AddOpt("plan_unit_price", planUnitPrice);
        return this;
      }
      public CreateRequest SetupFee(int setupFee) {
        _params.AddOpt("setup_fee", setupFee);
        return this;
      }
      public CreateRequest StartDate(long startDate) {
        _params.AddOpt("start_date", startDate);
        return this;
      }
      public CreateRequest TrialEnd(long trialEnd) {
        _params.AddOpt("trial_end", trialEnd);
        return this;
      }
      public CreateRequest BillingCycles(int billingCycles) {
        _params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
      public CreateRequest PoNumber(string poNumber) {
        _params.AddOpt("po_number", poNumber);
        return this;
      }
      public CreateRequest CouponIds(List<string> couponIds) {
        _params.AddOpt("coupon_ids", couponIds);
        return this;
      }
      public CreateRequest AffiliateToken(string affiliateToken) {
        _params.AddOpt("affiliate_token", affiliateToken);
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
      public CreateRequest CustomerId(string customerId) {
        _params.AddOpt("customer[id]", customerId);
        return this;
      }
      public CreateRequest CustomerEmail(string customerEmail) {
        _params.AddOpt("customer[email]", customerEmail);
        return this;
      }
      public CreateRequest CustomerFirstName(string customerFirstName) {
        _params.AddOpt("customer[first_name]", customerFirstName);
        return this;
      }
      public CreateRequest CustomerLastName(string customerLastName) {
        _params.AddOpt("customer[last_name]", customerLastName);
        return this;
      }
      public CreateRequest CustomerCompany(string customerCompany) {
        _params.AddOpt("customer[company]", customerCompany);
        return this;
      }
      public CreateRequest CustomerTaxability(TaxabilityEnum customerTaxability) {
        _params.AddOpt("customer[taxability]", customerTaxability);
        return this;
      }
      public CreateRequest CustomerLocale(string customerLocale) {
        _params.AddOpt("customer[locale]", customerLocale);
        return this;
      }
      public CreateRequest CustomerEntityCode(EntityCodeEnum customerEntityCode) {
        _params.AddOpt("customer[entity_code]", customerEntityCode);
        return this;
      }
      public CreateRequest CustomerExemptNumber(string customerExemptNumber) {
        _params.AddOpt("customer[exempt_number]", customerExemptNumber);
        return this;
      }
      public CreateRequest CustomerNetTermDays(int customerNetTermDays) {
        _params.AddOpt("customer[net_ter_days]", customerNetTermDays);
        return this;
      }
      public CreateRequest CustomerPhone(string customerPhone) {
        _params.AddOpt("customer[phone]", customerPhone);
        return this;
      }
      public CreateRequest CustomerAutoCollection(AutoCollectionEnum customerAutoCollection) {
        _params.AddOpt("customer[auto_collection]", customerAutoCollection);
        return this;
      }
      public CreateRequest CustomerAllowDirectDebit(bool customerAllowDirectDebit) {
        _params.AddOpt("customer[allow_direct_debit]", customerAllowDirectDebit);
        return this;
      }
      public CreateRequest CardGatewayAccountId(string cardGatewayAccountId) {
        _params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
        return this;
      }
      public CreateRequest CardTmpToken(string cardTmpToken) {
        _params.AddOpt("card[tmp_token]", cardTmpToken);
        return this;
      }
      public CreateRequest PaymentMethodType(TypeEnum paymentMethodType) {
        _params.AddOpt("payment_method[type]", paymentMethodType);
        return this;
      }
      public CreateRequest PaymentMethodGatewayAccountId(string paymentMethodGatewayAccountId) {
        _params.AddOpt("payment_method[gateway_account_id]", paymentMethodGatewayAccountId);
        return this;
      }
      public CreateRequest PaymentMethodReferenceId(string paymentMethodReferenceId) {
        _params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
        return this;
      }
      public CreateRequest CardFirstName(string cardFirstName) {
        _params.AddOpt("card[first_name]", cardFirstName);
        return this;
      }
      public CreateRequest CardLastName(string cardLastName) {
        _params.AddOpt("card[last_name]", cardLastName);
        return this;
      }
      public CreateRequest CardNumber(string cardNumber) {
        _params.AddOpt("card[number]", cardNumber);
        return this;
      }
      public CreateRequest CardExpiryMonth(int cardExpiryMonth) {
        _params.AddOpt("card[expiry_month]", cardExpiryMonth);
        return this;
      }
      public CreateRequest CardExpiryYear(int cardExpiryYear) {
        _params.AddOpt("card[expiry_year]", cardExpiryYear);
        return this;
      }
      public CreateRequest CardCvv(string cardCvv) {
        _params.AddOpt("card[cvv]", cardCvv);
        return this;
      }
      public CreateRequest CardBillingAddr1(string cardBillingAddr1) {
        _params.AddOpt("card[billing_addr1]", cardBillingAddr1);
        return this;
      }
      public CreateRequest CardBillingAddr2(string cardBillingAddr2) {
        _params.AddOpt("card[billing_addr2]", cardBillingAddr2);
        return this;
      }
      public CreateRequest CardBillingCity(string cardBillingCity) {
        _params.AddOpt("card[billing_city]", cardBillingCity);
        return this;
      }
      public CreateRequest CardBillingStateCode(string cardBillingStateCode) {
        _params.AddOpt("card[billing_state_code]", cardBillingStateCode);
        return this;
      }
      public CreateRequest CardBillingState(string cardBillingState) {
        _params.AddOpt("card[billing_state]", cardBillingState);
        return this;
      }
      public CreateRequest CardBillingZip(string cardBillingZip) {
        _params.AddOpt("card[billing_zip]", cardBillingZip);
        return this;
      }
      public CreateRequest CardBillingCountry(string cardBillingCountry) {
        _params.AddOpt("card[billing_country]", cardBillingCountry);
        return this;
      }
      public CreateRequest BillingAddressFirstName(string billingAddressFirstName) {
        _params.AddOpt("billing_address[first_name]", billingAddressFirstName);
        return this;
      }
      public CreateRequest BillingAddressLastName(string billingAddressLastName) {
        _params.AddOpt("billing_address[last_name]", billingAddressLastName);
        return this;
      }
      public CreateRequest BillingAddressEmail(string billingAddressEmail) {
        _params.AddOpt("billing_address[email]", billingAddressEmail);
        return this;
      }
      public CreateRequest BillingAddressCompany(string billingAddressCompany) {
        _params.AddOpt("billing_address[company]", billingAddressCompany);
        return this;
      }
      public CreateRequest BillingAddressPhone(string billingAddressPhone) {
        _params.AddOpt("billing_address[phone]", billingAddressPhone);
        return this;
      }
      public CreateRequest BillingAddressLine1(string billingAddressLine1) {
        _params.AddOpt("billing_address[line1]", billingAddressLine1);
        return this;
      }
      public CreateRequest BillingAddressLine2(string billingAddressLine2) {
        _params.AddOpt("billing_address[line2]", billingAddressLine2);
        return this;
      }
      public CreateRequest BillingAddressLine3(string billingAddressLine3) {
        _params.AddOpt("billing_address[line3]", billingAddressLine3);
        return this;
      }
      public CreateRequest BillingAddressCity(string billingAddressCity) {
        _params.AddOpt("billing_address[city]", billingAddressCity);
        return this;
      }
      public CreateRequest BillingAddressStateCode(string billingAddressStateCode) {
        _params.AddOpt("billing_address[state_code]", billingAddressStateCode);
        return this;
      }
      public CreateRequest BillingAddressState(string billingAddressState) {
        _params.AddOpt("billing_address[state]", billingAddressState);
        return this;
      }
      public CreateRequest BillingAddressZip(string billingAddressZip) {
        _params.AddOpt("billing_address[zip]", billingAddressZip);
        return this;
      }
      public CreateRequest BillingAddressCountry(string billingAddressCountry) {
        _params.AddOpt("billing_address[country]", billingAddressCountry);
        return this;
      }
      public CreateRequest BillingAddressValidationStatus(ValidationStatusEnum billingAddressValidationStatus) {
        _params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
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
      public CreateRequest CustomerVatNumber(string customerVatNumber) {
        _params.AddOpt("customer[vat_number]", customerVatNumber);
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
      public CreateRequest AddonUnitPrice(int index, int addonUnitPrice) {
        _params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
        return this;
      }
    }
    public class CreateForCustomerRequest : EntityRequest<CreateForCustomerRequest> {
      public CreateForCustomerRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CreateForCustomerRequest Id(string id) {
        _params.AddOpt("id", id);
        return this;
      }
      public CreateForCustomerRequest PlanId(string planId) {
        _params.Add("plan_id", planId);
        return this;
      }
      public CreateForCustomerRequest PlanQuantity(int planQuantity) {
        _params.AddOpt("plan_quantity", planQuantity);
        return this;
      }
      public CreateForCustomerRequest PlanUnitPrice(int planUnitPrice) {
        _params.AddOpt("plan_unit_price", planUnitPrice);
        return this;
      }
      public CreateForCustomerRequest SetupFee(int setupFee) {
        _params.AddOpt("setup_fee", setupFee);
        return this;
      }
      public CreateForCustomerRequest StartDate(long startDate) {
        _params.AddOpt("start_date", startDate);
        return this;
      }
      public CreateForCustomerRequest TrialEnd(long trialEnd) {
        _params.AddOpt("trial_end", trialEnd);
        return this;
      }
      public CreateForCustomerRequest BillingCycles(int billingCycles) {
        _params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
      public CreateForCustomerRequest PoNumber(string poNumber) {
        _params.AddOpt("po_number", poNumber);
        return this;
      }
      public CreateForCustomerRequest CouponIds(List<string> couponIds) {
        _params.AddOpt("coupon_ids", couponIds);
        return this;
      }
      public CreateForCustomerRequest InvoiceNotes(string invoiceNotes) {
        _params.AddOpt("invoice_notes", invoiceNotes);
        return this;
      }
      public CreateForCustomerRequest MetaData(JToken metaData) {
        _params.AddOpt("meta_data", metaData);
        return this;
      }
      public CreateForCustomerRequest ShippingAddressFirstName(string shippingAddressFirstName) {
        _params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
        return this;
      }
      public CreateForCustomerRequest ShippingAddressLastName(string shippingAddressLastName) {
        _params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
        return this;
      }
      public CreateForCustomerRequest ShippingAddressEmail(string shippingAddressEmail) {
        _params.AddOpt("shipping_address[email]", shippingAddressEmail);
        return this;
      }
      public CreateForCustomerRequest ShippingAddressCompany(string shippingAddressCompany) {
        _params.AddOpt("shipping_address[company]", shippingAddressCompany);
        return this;
      }
      public CreateForCustomerRequest ShippingAddressPhone(string shippingAddressPhone) {
        _params.AddOpt("shipping_address[phone]", shippingAddressPhone);
        return this;
      }
      public CreateForCustomerRequest ShippingAddressLine1(string shippingAddressLine1) {
        _params.AddOpt("shipping_address[line1]", shippingAddressLine1);
        return this;
      }
      public CreateForCustomerRequest ShippingAddressLine2(string shippingAddressLine2) {
        _params.AddOpt("shipping_address[line2]", shippingAddressLine2);
        return this;
      }
      public CreateForCustomerRequest ShippingAddressLine3(string shippingAddressLine3) {
        _params.AddOpt("shipping_address[line3]", shippingAddressLine3);
        return this;
      }
      public CreateForCustomerRequest ShippingAddressCity(string shippingAddressCity) {
        _params.AddOpt("shipping_address[city]", shippingAddressCity);
        return this;
      }
      public CreateForCustomerRequest ShippingAddressStateCode(string shippingAddressStateCode) {
        _params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
        return this;
      }
      public CreateForCustomerRequest ShippingAddressState(string shippingAddressState) {
        _params.AddOpt("shipping_address[state]", shippingAddressState);
        return this;
      }
      public CreateForCustomerRequest ShippingAddressZip(string shippingAddressZip) {
        _params.AddOpt("shipping_address[zip]", shippingAddressZip);
        return this;
      }
      public CreateForCustomerRequest ShippingAddressCountry(string shippingAddressCountry) {
        _params.AddOpt("shipping_address[country]", shippingAddressCountry);
        return this;
      }
      public CreateForCustomerRequest ShippingAddressValidationStatus(ValidationStatusEnum shippingAddressValidationStatus) {
        _params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
        return this;
      }
      public CreateForCustomerRequest AddonId(int index, string addonId) {
        _params.AddOpt("addons[id][" + index + "]", addonId);
        return this;
      }
      public CreateForCustomerRequest AddonQuantity(int index, int addonQuantity) {
        _params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
        return this;
      }
      public CreateForCustomerRequest AddonUnitPrice(int index, int addonUnitPrice) {
        _params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
        return this;
      }
    }
    public class SubscriptionListRequest : ListRequestBase<SubscriptionListRequest> {
      public SubscriptionListRequest(ChargeBeeApi api, string url)
              : base(api, url) {
      }

      public SubscriptionListRequest IncludeDeleted(bool includeDeleted) {
        _params.AddOpt("include_deleted", includeDeleted);
        return this;
      }
      public StringFilter<SubscriptionListRequest> Id() {
        return new StringFilter<SubscriptionListRequest>("id", this).SupportsMultiOperators(true);
      }
      public StringFilter<SubscriptionListRequest> CustomerId() {
        return new StringFilter<SubscriptionListRequest>("customer_id", this).SupportsMultiOperators(true);
      }
      public StringFilter<SubscriptionListRequest> PlanId() {
        return new StringFilter<SubscriptionListRequest>("plan_id", this).SupportsMultiOperators(true);
      }
      public EnumFilter<StatusEnum, SubscriptionListRequest> Status() {
        return new EnumFilter<StatusEnum, SubscriptionListRequest>("status", this);
      }
      public EnumFilter<CancelReasonEnum, SubscriptionListRequest> CancelReason() {
        return new EnumFilter<CancelReasonEnum, SubscriptionListRequest>("cancel_reason", this).SupportsPresenceOperator(true);
      }
      public NumberFilter<int, SubscriptionListRequest> RemainingBillingCycles() {
        return new NumberFilter<int, SubscriptionListRequest>("remaining_billing_cycles", this).SupportsPresenceOperator(true);
      }
      public TimestampFilter<SubscriptionListRequest> CreatedAt() {
        return new TimestampFilter<SubscriptionListRequest>("created_at", this);
      }
      public TimestampFilter<SubscriptionListRequest> CancelledAt() {
        return new TimestampFilter<SubscriptionListRequest>("cancelled_at", this);
      }
      public BooleanFilter<SubscriptionListRequest> HasScheduledChanges() {
        return new BooleanFilter<SubscriptionListRequest>("has_scheduled_changes", this);
      }
      public TimestampFilter<SubscriptionListRequest> UpdatedAt() {
        return new TimestampFilter<SubscriptionListRequest>("updated_at", this);
      }
      public SubscriptionListRequest SortByCreatedAt(SortOrderEnum order) {
        _params.AddOpt("sort_by[" + order.ToString().ToLower() + "]", "created_at");
        return this;
      }
    }
    public class RemoveScheduledCancellationRequest : EntityRequest<RemoveScheduledCancellationRequest> {
      public RemoveScheduledCancellationRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public RemoveScheduledCancellationRequest BillingCycles(int billingCycles) {
        _params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
    }
    public class RemoveCouponsRequest : EntityRequest<RemoveCouponsRequest> {
      public RemoveCouponsRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public RemoveCouponsRequest CouponIds(List<string> couponIds) {
        _params.AddOpt("coupon_ids", couponIds);
        return this;
      }
    }
    public class UpdateRequest : EntityRequest<UpdateRequest> {
      public UpdateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public UpdateRequest PlanId(string planId) {
        _params.AddOpt("plan_id", planId);
        return this;
      }
      public UpdateRequest PlanQuantity(int planQuantity) {
        _params.AddOpt("plan_quantity", planQuantity);
        return this;
      }
      public UpdateRequest PlanUnitPrice(int planUnitPrice) {
        _params.AddOpt("plan_unit_price", planUnitPrice);
        return this;
      }
      public UpdateRequest SetupFee(int setupFee) {
        _params.AddOpt("setup_fee", setupFee);
        return this;
      }
      public UpdateRequest StartDate(long startDate) {
        _params.AddOpt("start_date", startDate);
        return this;
      }
      public UpdateRequest TrialEnd(long trialEnd) {
        _params.AddOpt("trial_end", trialEnd);
        return this;
      }
      public UpdateRequest BillingCycles(int billingCycles) {
        _params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
      public UpdateRequest ReplaceAddonList(bool replaceAddonList) {
        _params.AddOpt("replace_addon_list", replaceAddonList);
        return this;
      }
      public UpdateRequest PoNumber(string poNumber) {
        _params.AddOpt("po_number", poNumber);
        return this;
      }
      public UpdateRequest CouponIds(List<string> couponIds) {
        _params.AddOpt("coupon_ids", couponIds);
        return this;
      }
      public UpdateRequest ReplaceCouponList(bool replaceCouponList) {
        _params.AddOpt("replace_coupon_list", replaceCouponList);
        return this;
      }
      public UpdateRequest Prorate(bool prorate) {
        _params.AddOpt("prorate", prorate);
        return this;
      }
      public UpdateRequest EndOfTerm(bool endOfTerm) {
        _params.AddOpt("end_of_term", endOfTerm);
        return this;
      }
      public UpdateRequest ForceTermReset(bool forceTermReset) {
        _params.AddOpt("force_ter_reset", forceTermReset);
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
      public UpdateRequest CardGatewayAccountId(string cardGatewayAccountId) {
        _params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
        return this;
      }
      public UpdateRequest CardTmpToken(string cardTmpToken) {
        _params.AddOpt("card[tmp_token]", cardTmpToken);
        return this;
      }
      public UpdateRequest PaymentMethodType(TypeEnum paymentMethodType) {
        _params.AddOpt("payment_method[type]", paymentMethodType);
        return this;
      }
      public UpdateRequest PaymentMethodGatewayAccountId(string paymentMethodGatewayAccountId) {
        _params.AddOpt("payment_method[gateway_account_id]", paymentMethodGatewayAccountId);
        return this;
      }
      public UpdateRequest PaymentMethodReferenceId(string paymentMethodReferenceId) {
        _params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
        return this;
      }
      public UpdateRequest PaymentMethodTmpToken(string paymentMethodTmpToken) {
        _params.AddOpt("payment_method[tmp_token]", paymentMethodTmpToken);
        return this;
      }
      public UpdateRequest CardFirstName(string cardFirstName) {
        _params.AddOpt("card[first_name]", cardFirstName);
        return this;
      }
      public UpdateRequest CardLastName(string cardLastName) {
        _params.AddOpt("card[last_name]", cardLastName);
        return this;
      }
      public UpdateRequest CardNumber(string cardNumber) {
        _params.AddOpt("card[number]", cardNumber);
        return this;
      }
      public UpdateRequest CardExpiryMonth(int cardExpiryMonth) {
        _params.AddOpt("card[expiry_month]", cardExpiryMonth);
        return this;
      }
      public UpdateRequest CardExpiryYear(int cardExpiryYear) {
        _params.AddOpt("card[expiry_year]", cardExpiryYear);
        return this;
      }
      public UpdateRequest CardCvv(string cardCvv) {
        _params.AddOpt("card[cvv]", cardCvv);
        return this;
      }
      public UpdateRequest CardBillingAddr1(string cardBillingAddr1) {
        _params.AddOpt("card[billing_addr1]", cardBillingAddr1);
        return this;
      }
      public UpdateRequest CardBillingAddr2(string cardBillingAddr2) {
        _params.AddOpt("card[billing_addr2]", cardBillingAddr2);
        return this;
      }
      public UpdateRequest CardBillingCity(string cardBillingCity) {
        _params.AddOpt("card[billing_city]", cardBillingCity);
        return this;
      }
      public UpdateRequest CardBillingStateCode(string cardBillingStateCode) {
        _params.AddOpt("card[billing_state_code]", cardBillingStateCode);
        return this;
      }
      public UpdateRequest CardBillingState(string cardBillingState) {
        _params.AddOpt("card[billing_state]", cardBillingState);
        return this;
      }
      public UpdateRequest CardBillingZip(string cardBillingZip) {
        _params.AddOpt("card[billing_zip]", cardBillingZip);
        return this;
      }
      public UpdateRequest CardBillingCountry(string cardBillingCountry) {
        _params.AddOpt("card[billing_country]", cardBillingCountry);
        return this;
      }
      public UpdateRequest BillingAddressFirstName(string billingAddressFirstName) {
        _params.AddOpt("billing_address[first_name]", billingAddressFirstName);
        return this;
      }
      public UpdateRequest BillingAddressLastName(string billingAddressLastName) {
        _params.AddOpt("billing_address[last_name]", billingAddressLastName);
        return this;
      }
      public UpdateRequest BillingAddressEmail(string billingAddressEmail) {
        _params.AddOpt("billing_address[email]", billingAddressEmail);
        return this;
      }
      public UpdateRequest BillingAddressCompany(string billingAddressCompany) {
        _params.AddOpt("billing_address[company]", billingAddressCompany);
        return this;
      }
      public UpdateRequest BillingAddressPhone(string billingAddressPhone) {
        _params.AddOpt("billing_address[phone]", billingAddressPhone);
        return this;
      }
      public UpdateRequest BillingAddressLine1(string billingAddressLine1) {
        _params.AddOpt("billing_address[line1]", billingAddressLine1);
        return this;
      }
      public UpdateRequest BillingAddressLine2(string billingAddressLine2) {
        _params.AddOpt("billing_address[line2]", billingAddressLine2);
        return this;
      }
      public UpdateRequest BillingAddressLine3(string billingAddressLine3) {
        _params.AddOpt("billing_address[line3]", billingAddressLine3);
        return this;
      }
      public UpdateRequest BillingAddressCity(string billingAddressCity) {
        _params.AddOpt("billing_address[city]", billingAddressCity);
        return this;
      }
      public UpdateRequest BillingAddressStateCode(string billingAddressStateCode) {
        _params.AddOpt("billing_address[state_code]", billingAddressStateCode);
        return this;
      }
      public UpdateRequest BillingAddressState(string billingAddressState) {
        _params.AddOpt("billing_address[state]", billingAddressState);
        return this;
      }
      public UpdateRequest BillingAddressZip(string billingAddressZip) {
        _params.AddOpt("billing_address[zip]", billingAddressZip);
        return this;
      }
      public UpdateRequest BillingAddressCountry(string billingAddressCountry) {
        _params.AddOpt("billing_address[country]", billingAddressCountry);
        return this;
      }
      public UpdateRequest BillingAddressValidationStatus(ValidationStatusEnum billingAddressValidationStatus) {
        _params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
        return this;
      }
      public UpdateRequest ShippingAddressFirstName(string shippingAddressFirstName) {
        _params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
        return this;
      }
      public UpdateRequest ShippingAddressLastName(string shippingAddressLastName) {
        _params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
        return this;
      }
      public UpdateRequest ShippingAddressEmail(string shippingAddressEmail) {
        _params.AddOpt("shipping_address[email]", shippingAddressEmail);
        return this;
      }
      public UpdateRequest ShippingAddressCompany(string shippingAddressCompany) {
        _params.AddOpt("shipping_address[company]", shippingAddressCompany);
        return this;
      }
      public UpdateRequest ShippingAddressPhone(string shippingAddressPhone) {
        _params.AddOpt("shipping_address[phone]", shippingAddressPhone);
        return this;
      }
      public UpdateRequest ShippingAddressLine1(string shippingAddressLine1) {
        _params.AddOpt("shipping_address[line1]", shippingAddressLine1);
        return this;
      }
      public UpdateRequest ShippingAddressLine2(string shippingAddressLine2) {
        _params.AddOpt("shipping_address[line2]", shippingAddressLine2);
        return this;
      }
      public UpdateRequest ShippingAddressLine3(string shippingAddressLine3) {
        _params.AddOpt("shipping_address[line3]", shippingAddressLine3);
        return this;
      }
      public UpdateRequest ShippingAddressCity(string shippingAddressCity) {
        _params.AddOpt("shipping_address[city]", shippingAddressCity);
        return this;
      }
      public UpdateRequest ShippingAddressStateCode(string shippingAddressStateCode) {
        _params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
        return this;
      }
      public UpdateRequest ShippingAddressState(string shippingAddressState) {
        _params.AddOpt("shipping_address[state]", shippingAddressState);
        return this;
      }
      public UpdateRequest ShippingAddressZip(string shippingAddressZip) {
        _params.AddOpt("shipping_address[zip]", shippingAddressZip);
        return this;
      }
      public UpdateRequest ShippingAddressCountry(string shippingAddressCountry) {
        _params.AddOpt("shipping_address[country]", shippingAddressCountry);
        return this;
      }
      public UpdateRequest ShippingAddressValidationStatus(ValidationStatusEnum shippingAddressValidationStatus) {
        _params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
        return this;
      }
      public UpdateRequest CustomerVatNumber(string customerVatNumber) {
        _params.AddOpt("customer[vat_number]", customerVatNumber);
        return this;
      }
      public UpdateRequest AddonId(int index, string addonId) {
        _params.AddOpt("addons[id][" + index + "]", addonId);
        return this;
      }
      public UpdateRequest AddonQuantity(int index, int addonQuantity) {
        _params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
        return this;
      }
      public UpdateRequest AddonUnitPrice(int index, int addonUnitPrice) {
        _params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
        return this;
      }
    }
    public class ChangeTermEndRequest : EntityRequest<ChangeTermEndRequest> {
      public ChangeTermEndRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public ChangeTermEndRequest TermEndsAt(long termEndsAt) {
        _params.Add("ter_ends_at", termEndsAt);
        return this;
      }
    }
    public class CancelRequest : EntityRequest<CancelRequest> {
      public CancelRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CancelRequest EndOfTerm(bool endOfTerm) {
        _params.AddOpt("end_of_term", endOfTerm);
        return this;
      }
    }
    public class ReactivateRequest : EntityRequest<ReactivateRequest> {
      public ReactivateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public ReactivateRequest TrialEnd(long trialEnd) {
        _params.AddOpt("trial_end", trialEnd);
        return this;
      }
      public ReactivateRequest BillingCycles(int billingCycles) {
        _params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
    }
    public class AddChargeAtTermEndRequest : EntityRequest<AddChargeAtTermEndRequest> {
      public AddChargeAtTermEndRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public AddChargeAtTermEndRequest Amount(int amount) {
        _params.Add("amount", amount);
        return this;
      }
      public AddChargeAtTermEndRequest Description(string description) {
        _params.Add("description", description);
        return this;
      }
    }
    public class ChargeAddonAtTermEndRequest : EntityRequest<ChargeAddonAtTermEndRequest> {
      public ChargeAddonAtTermEndRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public ChargeAddonAtTermEndRequest AddonId(string addonId) {
        _params.Add("addon_id", addonId);
        return this;
      }
      public ChargeAddonAtTermEndRequest AddonQuantity(int addonQuantity) {
        _params.AddOpt("addon_quantity", addonQuantity);
        return this;
      }
      public ChargeAddonAtTermEndRequest AddonUnitPrice(int addonUnitPrice) {
        _params.AddOpt("addon_unit_price", addonUnitPrice);
        return this;
      }
    }
    public class ImportSubscriptionRequest : EntityRequest<ImportSubscriptionRequest> {
      public ImportSubscriptionRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public ImportSubscriptionRequest Id(string id) {
        _params.AddOpt("id", id);
        return this;
      }
      public ImportSubscriptionRequest PlanId(string planId) {
        _params.Add("plan_id", planId);
        return this;
      }
      public ImportSubscriptionRequest PlanQuantity(int planQuantity) {
        _params.AddOpt("plan_quantity", planQuantity);
        return this;
      }
      public ImportSubscriptionRequest PlanUnitPrice(int planUnitPrice) {
        _params.AddOpt("plan_unit_price", planUnitPrice);
        return this;
      }
      public ImportSubscriptionRequest SetupFee(int setupFee) {
        _params.AddOpt("setup_fee", setupFee);
        return this;
      }
      public ImportSubscriptionRequest StartDate(long startDate) {
        _params.AddOpt("start_date", startDate);
        return this;
      }
      public ImportSubscriptionRequest TrialEnd(long trialEnd) {
        _params.AddOpt("trial_end", trialEnd);
        return this;
      }
      public ImportSubscriptionRequest BillingCycles(int billingCycles) {
        _params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
      public ImportSubscriptionRequest PoNumber(string poNumber) {
        _params.AddOpt("po_number", poNumber);
        return this;
      }
      public ImportSubscriptionRequest CouponIds(List<string> couponIds) {
        _params.AddOpt("coupon_ids", couponIds);
        return this;
      }
      public ImportSubscriptionRequest Status(StatusEnum status) {
        _params.Add("status", status);
        return this;
      }
      public ImportSubscriptionRequest CurrentTermEnd(long currentTermEnd) {
        _params.AddOpt("current_ter_end", currentTermEnd);
        return this;
      }
      public ImportSubscriptionRequest CurrentTermStart(long currentTermStart) {
        _params.AddOpt("current_ter_start", currentTermStart);
        return this;
      }
      public ImportSubscriptionRequest TrialStart(long trialStart) {
        _params.AddOpt("trial_start", trialStart);
        return this;
      }
      public ImportSubscriptionRequest CancelledAt(long cancelledAt) {
        _params.AddOpt("cancelled_at", cancelledAt);
        return this;
      }
      public ImportSubscriptionRequest StartedAt(long startedAt) {
        _params.AddOpt("started_at", startedAt);
        return this;
      }
      public ImportSubscriptionRequest AffiliateToken(string affiliateToken) {
        _params.AddOpt("affiliate_token", affiliateToken);
        return this;
      }
      public ImportSubscriptionRequest InvoiceNotes(string invoiceNotes) {
        _params.AddOpt("invoice_notes", invoiceNotes);
        return this;
      }
      public ImportSubscriptionRequest MetaData(JToken metaData) {
        _params.AddOpt("meta_data", metaData);
        return this;
      }
      public ImportSubscriptionRequest CustomerId(string customerId) {
        _params.AddOpt("customer[id]", customerId);
        return this;
      }
      public ImportSubscriptionRequest CustomerEmail(string customerEmail) {
        _params.AddOpt("customer[email]", customerEmail);
        return this;
      }
      public ImportSubscriptionRequest CustomerFirstName(string customerFirstName) {
        _params.AddOpt("customer[first_name]", customerFirstName);
        return this;
      }
      public ImportSubscriptionRequest CustomerLastName(string customerLastName) {
        _params.AddOpt("customer[last_name]", customerLastName);
        return this;
      }
      public ImportSubscriptionRequest CustomerCompany(string customerCompany) {
        _params.AddOpt("customer[company]", customerCompany);
        return this;
      }
      public ImportSubscriptionRequest CustomerTaxability(TaxabilityEnum customerTaxability) {
        _params.AddOpt("customer[taxability]", customerTaxability);
        return this;
      }
      public ImportSubscriptionRequest CustomerLocale(string customerLocale) {
        _params.AddOpt("customer[locale]", customerLocale);
        return this;
      }
      public ImportSubscriptionRequest CustomerEntityCode(EntityCodeEnum customerEntityCode) {
        _params.AddOpt("customer[entity_code]", customerEntityCode);
        return this;
      }
      public ImportSubscriptionRequest CustomerExemptNumber(string customerExemptNumber) {
        _params.AddOpt("customer[exempt_number]", customerExemptNumber);
        return this;
      }
      public ImportSubscriptionRequest CustomerNetTermDays(int customerNetTermDays) {
        _params.AddOpt("customer[net_ter_days]", customerNetTermDays);
        return this;
      }
      public ImportSubscriptionRequest CustomerPhone(string customerPhone) {
        _params.AddOpt("customer[phone]", customerPhone);
        return this;
      }
      public ImportSubscriptionRequest CustomerAutoCollection(AutoCollectionEnum customerAutoCollection) {
        _params.AddOpt("customer[auto_collection]", customerAutoCollection);
        return this;
      }
      public ImportSubscriptionRequest CustomerAllowDirectDebit(bool customerAllowDirectDebit) {
        _params.AddOpt("customer[allow_direct_debit]", customerAllowDirectDebit);
        return this;
      }
      public ImportSubscriptionRequest CardGatewayAccountId(string cardGatewayAccountId) {
        _params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
        return this;
      }
      public ImportSubscriptionRequest CardTmpToken(string cardTmpToken) {
        _params.AddOpt("card[tmp_token]", cardTmpToken);
        return this;
      }
      public ImportSubscriptionRequest PaymentMethodType(TypeEnum paymentMethodType) {
        _params.AddOpt("payment_method[type]", paymentMethodType);
        return this;
      }
      public ImportSubscriptionRequest PaymentMethodGatewayAccountId(string paymentMethodGatewayAccountId) {
        _params.AddOpt("payment_method[gateway_account_id]", paymentMethodGatewayAccountId);
        return this;
      }
      public ImportSubscriptionRequest PaymentMethodReferenceId(string paymentMethodReferenceId) {
        _params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
        return this;
      }
      public ImportSubscriptionRequest CardFirstName(string cardFirstName) {
        _params.AddOpt("card[first_name]", cardFirstName);
        return this;
      }
      public ImportSubscriptionRequest CardLastName(string cardLastName) {
        _params.AddOpt("card[last_name]", cardLastName);
        return this;
      }
      public ImportSubscriptionRequest CardNumber(string cardNumber) {
        _params.AddOpt("card[number]", cardNumber);
        return this;
      }
      public ImportSubscriptionRequest CardExpiryMonth(int cardExpiryMonth) {
        _params.AddOpt("card[expiry_month]", cardExpiryMonth);
        return this;
      }
      public ImportSubscriptionRequest CardExpiryYear(int cardExpiryYear) {
        _params.AddOpt("card[expiry_year]", cardExpiryYear);
        return this;
      }
      public ImportSubscriptionRequest CardCvv(string cardCvv) {
        _params.AddOpt("card[cvv]", cardCvv);
        return this;
      }
      public ImportSubscriptionRequest CardBillingAddr1(string cardBillingAddr1) {
        _params.AddOpt("card[billing_addr1]", cardBillingAddr1);
        return this;
      }
      public ImportSubscriptionRequest CardBillingAddr2(string cardBillingAddr2) {
        _params.AddOpt("card[billing_addr2]", cardBillingAddr2);
        return this;
      }
      public ImportSubscriptionRequest CardBillingCity(string cardBillingCity) {
        _params.AddOpt("card[billing_city]", cardBillingCity);
        return this;
      }
      public ImportSubscriptionRequest CardBillingStateCode(string cardBillingStateCode) {
        _params.AddOpt("card[billing_state_code]", cardBillingStateCode);
        return this;
      }
      public ImportSubscriptionRequest CardBillingState(string cardBillingState) {
        _params.AddOpt("card[billing_state]", cardBillingState);
        return this;
      }
      public ImportSubscriptionRequest CardBillingZip(string cardBillingZip) {
        _params.AddOpt("card[billing_zip]", cardBillingZip);
        return this;
      }
      public ImportSubscriptionRequest CardBillingCountry(string cardBillingCountry) {
        _params.AddOpt("card[billing_country]", cardBillingCountry);
        return this;
      }
      public ImportSubscriptionRequest BillingAddressFirstName(string billingAddressFirstName) {
        _params.AddOpt("billing_address[first_name]", billingAddressFirstName);
        return this;
      }
      public ImportSubscriptionRequest BillingAddressLastName(string billingAddressLastName) {
        _params.AddOpt("billing_address[last_name]", billingAddressLastName);
        return this;
      }
      public ImportSubscriptionRequest BillingAddressEmail(string billingAddressEmail) {
        _params.AddOpt("billing_address[email]", billingAddressEmail);
        return this;
      }
      public ImportSubscriptionRequest BillingAddressCompany(string billingAddressCompany) {
        _params.AddOpt("billing_address[company]", billingAddressCompany);
        return this;
      }
      public ImportSubscriptionRequest BillingAddressPhone(string billingAddressPhone) {
        _params.AddOpt("billing_address[phone]", billingAddressPhone);
        return this;
      }
      public ImportSubscriptionRequest BillingAddressLine1(string billingAddressLine1) {
        _params.AddOpt("billing_address[line1]", billingAddressLine1);
        return this;
      }
      public ImportSubscriptionRequest BillingAddressLine2(string billingAddressLine2) {
        _params.AddOpt("billing_address[line2]", billingAddressLine2);
        return this;
      }
      public ImportSubscriptionRequest BillingAddressLine3(string billingAddressLine3) {
        _params.AddOpt("billing_address[line3]", billingAddressLine3);
        return this;
      }
      public ImportSubscriptionRequest BillingAddressCity(string billingAddressCity) {
        _params.AddOpt("billing_address[city]", billingAddressCity);
        return this;
      }
      public ImportSubscriptionRequest BillingAddressStateCode(string billingAddressStateCode) {
        _params.AddOpt("billing_address[state_code]", billingAddressStateCode);
        return this;
      }
      public ImportSubscriptionRequest BillingAddressState(string billingAddressState) {
        _params.AddOpt("billing_address[state]", billingAddressState);
        return this;
      }
      public ImportSubscriptionRequest BillingAddressZip(string billingAddressZip) {
        _params.AddOpt("billing_address[zip]", billingAddressZip);
        return this;
      }
      public ImportSubscriptionRequest BillingAddressCountry(string billingAddressCountry) {
        _params.AddOpt("billing_address[country]", billingAddressCountry);
        return this;
      }
      public ImportSubscriptionRequest BillingAddressValidationStatus(ValidationStatusEnum billingAddressValidationStatus) {
        _params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
        return this;
      }
      public ImportSubscriptionRequest ShippingAddressFirstName(string shippingAddressFirstName) {
        _params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
        return this;
      }
      public ImportSubscriptionRequest ShippingAddressLastName(string shippingAddressLastName) {
        _params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
        return this;
      }
      public ImportSubscriptionRequest ShippingAddressEmail(string shippingAddressEmail) {
        _params.AddOpt("shipping_address[email]", shippingAddressEmail);
        return this;
      }
      public ImportSubscriptionRequest ShippingAddressCompany(string shippingAddressCompany) {
        _params.AddOpt("shipping_address[company]", shippingAddressCompany);
        return this;
      }
      public ImportSubscriptionRequest ShippingAddressPhone(string shippingAddressPhone) {
        _params.AddOpt("shipping_address[phone]", shippingAddressPhone);
        return this;
      }
      public ImportSubscriptionRequest ShippingAddressLine1(string shippingAddressLine1) {
        _params.AddOpt("shipping_address[line1]", shippingAddressLine1);
        return this;
      }
      public ImportSubscriptionRequest ShippingAddressLine2(string shippingAddressLine2) {
        _params.AddOpt("shipping_address[line2]", shippingAddressLine2);
        return this;
      }
      public ImportSubscriptionRequest ShippingAddressLine3(string shippingAddressLine3) {
        _params.AddOpt("shipping_address[line3]", shippingAddressLine3);
        return this;
      }
      public ImportSubscriptionRequest ShippingAddressCity(string shippingAddressCity) {
        _params.AddOpt("shipping_address[city]", shippingAddressCity);
        return this;
      }
      public ImportSubscriptionRequest ShippingAddressStateCode(string shippingAddressStateCode) {
        _params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
        return this;
      }
      public ImportSubscriptionRequest ShippingAddressState(string shippingAddressState) {
        _params.AddOpt("shipping_address[state]", shippingAddressState);
        return this;
      }
      public ImportSubscriptionRequest ShippingAddressZip(string shippingAddressZip) {
        _params.AddOpt("shipping_address[zip]", shippingAddressZip);
        return this;
      }
      public ImportSubscriptionRequest ShippingAddressCountry(string shippingAddressCountry) {
        _params.AddOpt("shipping_address[country]", shippingAddressCountry);
        return this;
      }
      public ImportSubscriptionRequest ShippingAddressValidationStatus(ValidationStatusEnum shippingAddressValidationStatus) {
        _params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
        return this;
      }
      public ImportSubscriptionRequest CustomerVatNumber(string customerVatNumber) {
        _params.AddOpt("customer[vat_number]", customerVatNumber);
        return this;
      }
      public ImportSubscriptionRequest AddonId(int index, string addonId) {
        _params.AddOpt("addons[id][" + index + "]", addonId);
        return this;
      }
      public ImportSubscriptionRequest AddonQuantity(int index, int addonQuantity) {
        _params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
        return this;
      }
      public ImportSubscriptionRequest AddonUnitPrice(int index, int addonUnitPrice) {
        _params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
        return this;
      }
    }
    public class ImportForCustomerRequest : EntityRequest<ImportForCustomerRequest> {
      public ImportForCustomerRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public ImportForCustomerRequest Id(string id) {
        _params.AddOpt("id", id);
        return this;
      }
      public ImportForCustomerRequest PlanId(string planId) {
        _params.Add("plan_id", planId);
        return this;
      }
      public ImportForCustomerRequest PlanQuantity(int planQuantity) {
        _params.AddOpt("plan_quantity", planQuantity);
        return this;
      }
      public ImportForCustomerRequest PlanUnitPrice(int planUnitPrice) {
        _params.AddOpt("plan_unit_price", planUnitPrice);
        return this;
      }
      public ImportForCustomerRequest SetupFee(int setupFee) {
        _params.AddOpt("setup_fee", setupFee);
        return this;
      }
      public ImportForCustomerRequest StartDate(long startDate) {
        _params.AddOpt("start_date", startDate);
        return this;
      }
      public ImportForCustomerRequest TrialEnd(long trialEnd) {
        _params.AddOpt("trial_end", trialEnd);
        return this;
      }
      public ImportForCustomerRequest BillingCycles(int billingCycles) {
        _params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
      public ImportForCustomerRequest PoNumber(string poNumber) {
        _params.AddOpt("po_number", poNumber);
        return this;
      }
      public ImportForCustomerRequest CouponIds(List<string> couponIds) {
        _params.AddOpt("coupon_ids", couponIds);
        return this;
      }
      public ImportForCustomerRequest Status(StatusEnum status) {
        _params.Add("status", status);
        return this;
      }
      public ImportForCustomerRequest CurrentTermEnd(long currentTermEnd) {
        _params.AddOpt("current_ter_end", currentTermEnd);
        return this;
      }
      public ImportForCustomerRequest CurrentTermStart(long currentTermStart) {
        _params.AddOpt("current_ter_start", currentTermStart);
        return this;
      }
      public ImportForCustomerRequest TrialStart(long trialStart) {
        _params.AddOpt("trial_start", trialStart);
        return this;
      }
      public ImportForCustomerRequest CancelledAt(long cancelledAt) {
        _params.AddOpt("cancelled_at", cancelledAt);
        return this;
      }
      public ImportForCustomerRequest StartedAt(long startedAt) {
        _params.AddOpt("started_at", startedAt);
        return this;
      }
      public ImportForCustomerRequest InvoiceNotes(string invoiceNotes) {
        _params.AddOpt("invoice_notes", invoiceNotes);
        return this;
      }
      public ImportForCustomerRequest MetaData(JToken metaData) {
        _params.AddOpt("meta_data", metaData);
        return this;
      }
      public ImportForCustomerRequest ShippingAddressFirstName(string shippingAddressFirstName) {
        _params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
        return this;
      }
      public ImportForCustomerRequest ShippingAddressLastName(string shippingAddressLastName) {
        _params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
        return this;
      }
      public ImportForCustomerRequest ShippingAddressEmail(string shippingAddressEmail) {
        _params.AddOpt("shipping_address[email]", shippingAddressEmail);
        return this;
      }
      public ImportForCustomerRequest ShippingAddressCompany(string shippingAddressCompany) {
        _params.AddOpt("shipping_address[company]", shippingAddressCompany);
        return this;
      }
      public ImportForCustomerRequest ShippingAddressPhone(string shippingAddressPhone) {
        _params.AddOpt("shipping_address[phone]", shippingAddressPhone);
        return this;
      }
      public ImportForCustomerRequest ShippingAddressLine1(string shippingAddressLine1) {
        _params.AddOpt("shipping_address[line1]", shippingAddressLine1);
        return this;
      }
      public ImportForCustomerRequest ShippingAddressLine2(string shippingAddressLine2) {
        _params.AddOpt("shipping_address[line2]", shippingAddressLine2);
        return this;
      }
      public ImportForCustomerRequest ShippingAddressLine3(string shippingAddressLine3) {
        _params.AddOpt("shipping_address[line3]", shippingAddressLine3);
        return this;
      }
      public ImportForCustomerRequest ShippingAddressCity(string shippingAddressCity) {
        _params.AddOpt("shipping_address[city]", shippingAddressCity);
        return this;
      }
      public ImportForCustomerRequest ShippingAddressStateCode(string shippingAddressStateCode) {
        _params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
        return this;
      }
      public ImportForCustomerRequest ShippingAddressState(string shippingAddressState) {
        _params.AddOpt("shipping_address[state]", shippingAddressState);
        return this;
      }
      public ImportForCustomerRequest ShippingAddressZip(string shippingAddressZip) {
        _params.AddOpt("shipping_address[zip]", shippingAddressZip);
        return this;
      }
      public ImportForCustomerRequest ShippingAddressCountry(string shippingAddressCountry) {
        _params.AddOpt("shipping_address[country]", shippingAddressCountry);
        return this;
      }
      public ImportForCustomerRequest ShippingAddressValidationStatus(ValidationStatusEnum shippingAddressValidationStatus) {
        _params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
        return this;
      }
      public ImportForCustomerRequest AddonId(int index, string addonId) {
        _params.AddOpt("addons[id][" + index + "]", addonId);
        return this;
      }
      public ImportForCustomerRequest AddonQuantity(int index, int addonQuantity) {
        _params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
        return this;
      }
      public ImportForCustomerRequest AddonUnitPrice(int index, int addonUnitPrice) {
        _params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
        return this;
      }
    }

    public enum BillingPeriodUnitEnum {

      Unknown,
      [Description("week")]
      Week,
      [Description("month")]
      Month,
      [Description("year")]
      Year,

    }
    public enum StatusEnum {
      Unknown,
      [Description("future")]
      Future,
      [Description("in_trial")]
      InTrial,
      [Description("active")]
      Active,
      [Description("non_renewing")]
      NonRenewing,
      [Description("cancelled")]
      Cancelled,
    }
    public enum CancelReasonEnum {
      Unknown,
      [Description("not_paid")]
      NotPaid,
      [Description("no_card")]
      NoCard,
      [Description("fraud_review_failed")]
      FraudReviewFailed,
      [Description("non_compliant_eu_customer")]
      NonCompliantEuCustomer,
      [Description("tax_calculation_failed")]
      TaxCalculationFailed,
      [Description("currency_incompatible_with_gateway")]
      CurrencyIncompatibleWithGateway,
      [Description("non_compliant_customer")]
      NonCompliantCustomer,
    }

    public class SubscriptionAddon : Resource {
      public string Id() {
        return GetValue<string>("id", true);
      }

      public int? Quantity() {
        return GetValue<int?>("quantity", false);
      }

      public int? UnitPrice() {
        return GetValue<int?>("unit_price", false);
      }
    }

    public class SubscriptionCoupon : Resource {
      public string CouponId() {
        return GetValue<string>("coupon_id", true);
      }

      public DateTime? ApplyTill() {
        return GetDateTime("apply_till", false);
      }

      public int AppliedCount() {
        return GetValue<int>("applied_count", true);
      }

      public string CouponCode() {
        return GetValue<string>("coupon_code", false);
      }
    }

    public class SubscriptionShippingAddress : Resource {
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
