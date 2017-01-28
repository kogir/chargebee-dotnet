namespace RealArtists.ChargeBee.Models {
  using System;
  using System.ComponentModel;
  using System.Net.Http;
  using Newtonsoft.Json.Linq;
  using RealArtists.ChargeBee.Api;
  using RealArtists.ChargeBee.Internal;
  using RealArtists.ChargeBee.Models.Enums;

  public class HostedPageActions : ApiResourceActions {
    public HostedPageActions(ChargeBeeApi api) : base(api) { }

    public HostedPage.CheckoutNewRequest CheckoutNew() {
      string url = BuildUrl("hosted_pages", "checkout_new");
      return new HostedPage.CheckoutNewRequest(Api, url, HttpMethod.Post);
    }

    public HostedPage.CheckoutExistingRequest CheckoutExisting() {
      string url = BuildUrl("hosted_pages", "checkout_existing");
      return new HostedPage.CheckoutExistingRequest(Api, url, HttpMethod.Post);
    }

    public HostedPage.UpdatePaymentMethodRequest UpdatePaymentMethod() {
      string url = BuildUrl("hosted_pages", "update_payment_method");
      return new HostedPage.UpdatePaymentMethodRequest(Api, url, HttpMethod.Post);
    }

    public EntityRequest<Type> Retrieve(string id) {
      string url = BuildUrl("hosted_pages", id);
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }
  }

  public class HostedPage : Resource {
    public string Id {
      get { return GetValue<string>("id", false); }
    }
    public TypeEnum? HostedPageType {
      get { return GetEnum<TypeEnum>("type", false); }
    }
    public string Url {
      get { return GetValue<string>("url", false); }
    }
    public StateEnum? State {
      get { return GetEnum<StateEnum>("state", false); }
    }
    public FailureReasonEnum? FailureReason {
      get { return GetEnum<FailureReasonEnum>("failure_reason", false); }
    }
    public string PassThruContent {
      get { return GetValue<string>("pass_thru_content", false); }
    }
    public bool Embed {
      get { return GetValue<bool>("embed", true); }
    }
    public DateTime? CreatedAt {
      get { return GetDateTime("created_at", false); }
    }
    public DateTime? ExpiresAt {
      get { return GetDateTime("expires_at", false); }
    }
    public HostedPageContent Content {
      get {
        if (GetValue<JToken>("content", false) == null) {
          return null;
        }
        return new HostedPageContent(GetValue<JToken>("content"));
      }
    }

    public class CheckoutNewRequest : EntityRequest<CheckoutNewRequest> {
      public CheckoutNewRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CheckoutNewRequest BillingCycles(int billingCycles) {
        _params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
      public CheckoutNewRequest RedirectUrl(string redirectUrl) {
        _params.AddOpt("redirect_url", redirectUrl);
        return this;
      }
      public CheckoutNewRequest CancelUrl(string cancelUrl) {
        _params.AddOpt("cancel_url", cancelUrl);
        return this;
      }
      public CheckoutNewRequest PassThruContent(string passThruContent) {
        _params.AddOpt("pass_thru_content", passThruContent);
        return this;
      }
      public CheckoutNewRequest Embed(bool embed) {
        _params.AddOpt("embed", embed);
        return this;
      }
      public CheckoutNewRequest IframeMessaging(bool iframeMessaging) {
        _params.AddOpt("iframe_messaging", iframeMessaging);
        return this;
      }
      public CheckoutNewRequest SubscriptionId(string subscriptionId) {
        _params.AddOpt("subscription[id]", subscriptionId);
        return this;
      }
      public CheckoutNewRequest CustomerId(string customerId) {
        _params.AddOpt("customer[id]", customerId);
        return this;
      }
      public CheckoutNewRequest CustomerEmail(string customerEmail) {
        _params.AddOpt("customer[email]", customerEmail);
        return this;
      }
      public CheckoutNewRequest CustomerFirstName(string customerFirstName) {
        _params.AddOpt("customer[first_name]", customerFirstName);
        return this;
      }
      public CheckoutNewRequest CustomerLastName(string customerLastName) {
        _params.AddOpt("customer[last_name]", customerLastName);
        return this;
      }
      public CheckoutNewRequest CustomerCompany(string customerCompany) {
        _params.AddOpt("customer[company]", customerCompany);
        return this;
      }
      public CheckoutNewRequest CustomerTaxability(TaxabilityEnum customerTaxability) {
        _params.AddOpt("customer[taxability]", customerTaxability);
        return this;
      }
      public CheckoutNewRequest CustomerLocale(string customerLocale) {
        _params.AddOpt("customer[locale]", customerLocale);
        return this;
      }
      public CheckoutNewRequest CustomerPhone(string customerPhone) {
        _params.AddOpt("customer[phone]", customerPhone);
        return this;
      }
      public CheckoutNewRequest SubscriptionPlanId(string subscriptionPlanId) {
        _params.Add("subscription[plan_id]", subscriptionPlanId);
        return this;
      }
      public CheckoutNewRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) {
        _params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
        return this;
      }
      public CheckoutNewRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) {
        _params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
        return this;
      }
      public CheckoutNewRequest SubscriptionSetupFee(int subscriptionSetupFee) {
        _params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
        return this;
      }
      public CheckoutNewRequest SubscriptionStartDate(long subscriptionStartDate) {
        _params.AddOpt("subscription[start_date]", subscriptionStartDate);
        return this;
      }
      public CheckoutNewRequest SubscriptionTrialEnd(long subscriptionTrialEnd) {
        _params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
        return this;
      }
      public CheckoutNewRequest SubscriptionCoupon(string subscriptionCoupon) {
        _params.AddOpt("subscription[coupon]", subscriptionCoupon);
        return this;
      }
      public CheckoutNewRequest SubscriptionInvoiceNotes(string subscriptionInvoiceNotes) {
        _params.AddOpt("subscription[invoice_notes]", subscriptionInvoiceNotes);
        return this;
      }
      public CheckoutNewRequest CardGatewayAccountId(string cardGatewayAccountId) {
        _params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
        return this;
      }
      public CheckoutNewRequest BillingAddressFirstName(string billingAddressFirstName) {
        _params.AddOpt("billing_address[first_name]", billingAddressFirstName);
        return this;
      }
      public CheckoutNewRequest BillingAddressLastName(string billingAddressLastName) {
        _params.AddOpt("billing_address[last_name]", billingAddressLastName);
        return this;
      }
      public CheckoutNewRequest BillingAddressEmail(string billingAddressEmail) {
        _params.AddOpt("billing_address[email]", billingAddressEmail);
        return this;
      }
      public CheckoutNewRequest BillingAddressCompany(string billingAddressCompany) {
        _params.AddOpt("billing_address[company]", billingAddressCompany);
        return this;
      }
      public CheckoutNewRequest BillingAddressPhone(string billingAddressPhone) {
        _params.AddOpt("billing_address[phone]", billingAddressPhone);
        return this;
      }
      public CheckoutNewRequest BillingAddressLine1(string billingAddressLine1) {
        _params.AddOpt("billing_address[line1]", billingAddressLine1);
        return this;
      }
      public CheckoutNewRequest BillingAddressLine2(string billingAddressLine2) {
        _params.AddOpt("billing_address[line2]", billingAddressLine2);
        return this;
      }
      public CheckoutNewRequest BillingAddressLine3(string billingAddressLine3) {
        _params.AddOpt("billing_address[line3]", billingAddressLine3);
        return this;
      }
      public CheckoutNewRequest BillingAddressCity(string billingAddressCity) {
        _params.AddOpt("billing_address[city]", billingAddressCity);
        return this;
      }
      public CheckoutNewRequest BillingAddressStateCode(string billingAddressStateCode) {
        _params.AddOpt("billing_address[state_code]", billingAddressStateCode);
        return this;
      }
      public CheckoutNewRequest BillingAddressState(string billingAddressState) {
        _params.AddOpt("billing_address[state]", billingAddressState);
        return this;
      }
      public CheckoutNewRequest BillingAddressZip(string billingAddressZip) {
        _params.AddOpt("billing_address[zip]", billingAddressZip);
        return this;
      }
      public CheckoutNewRequest BillingAddressCountry(string billingAddressCountry) {
        _params.AddOpt("billing_address[country]", billingAddressCountry);
        return this;
      }
      public CheckoutNewRequest BillingAddressValidationStatus(ValidationStatusEnum billingAddressValidationStatus) {
        _params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
        return this;
      }
      public CheckoutNewRequest ShippingAddressFirstName(string shippingAddressFirstName) {
        _params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
        return this;
      }
      public CheckoutNewRequest ShippingAddressLastName(string shippingAddressLastName) {
        _params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
        return this;
      }
      public CheckoutNewRequest ShippingAddressEmail(string shippingAddressEmail) {
        _params.AddOpt("shipping_address[email]", shippingAddressEmail);
        return this;
      }
      public CheckoutNewRequest ShippingAddressCompany(string shippingAddressCompany) {
        _params.AddOpt("shipping_address[company]", shippingAddressCompany);
        return this;
      }
      public CheckoutNewRequest ShippingAddressPhone(string shippingAddressPhone) {
        _params.AddOpt("shipping_address[phone]", shippingAddressPhone);
        return this;
      }
      public CheckoutNewRequest ShippingAddressLine1(string shippingAddressLine1) {
        _params.AddOpt("shipping_address[line1]", shippingAddressLine1);
        return this;
      }
      public CheckoutNewRequest ShippingAddressLine2(string shippingAddressLine2) {
        _params.AddOpt("shipping_address[line2]", shippingAddressLine2);
        return this;
      }
      public CheckoutNewRequest ShippingAddressLine3(string shippingAddressLine3) {
        _params.AddOpt("shipping_address[line3]", shippingAddressLine3);
        return this;
      }
      public CheckoutNewRequest ShippingAddressCity(string shippingAddressCity) {
        _params.AddOpt("shipping_address[city]", shippingAddressCity);
        return this;
      }
      public CheckoutNewRequest ShippingAddressStateCode(string shippingAddressStateCode) {
        _params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
        return this;
      }
      public CheckoutNewRequest ShippingAddressState(string shippingAddressState) {
        _params.AddOpt("shipping_address[state]", shippingAddressState);
        return this;
      }
      public CheckoutNewRequest ShippingAddressZip(string shippingAddressZip) {
        _params.AddOpt("shipping_address[zip]", shippingAddressZip);
        return this;
      }
      public CheckoutNewRequest ShippingAddressCountry(string shippingAddressCountry) {
        _params.AddOpt("shipping_address[country]", shippingAddressCountry);
        return this;
      }
      public CheckoutNewRequest ShippingAddressValidationStatus(ValidationStatusEnum shippingAddressValidationStatus) {
        _params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
        return this;
      }
      public CheckoutNewRequest AddonId(int index, string addonId) {
        _params.AddOpt("addons[id][" + index + "]", addonId);
        return this;
      }
      public CheckoutNewRequest AddonQuantity(int index, int addonQuantity) {
        _params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
        return this;
      }
      public CheckoutNewRequest AddonUnitPrice(int index, int addonUnitPrice) {
        _params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
        return this;
      }
    }

    public class CheckoutExistingRequest : EntityRequest<CheckoutExistingRequest> {
      public CheckoutExistingRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CheckoutExistingRequest BillingCycles(int billingCycles) {
        _params.AddOpt("billing_cycles", billingCycles);
        return this;
      }
      public CheckoutExistingRequest ReplaceAddonList(bool replaceAddonList) {
        _params.AddOpt("replace_addon_list", replaceAddonList);
        return this;
      }
      public CheckoutExistingRequest RedirectUrl(string redirectUrl) {
        _params.AddOpt("redirect_url", redirectUrl);
        return this;
      }
      public CheckoutExistingRequest CancelUrl(string cancelUrl) {
        _params.AddOpt("cancel_url", cancelUrl);
        return this;
      }
      public CheckoutExistingRequest PassThruContent(string passThruContent) {
        _params.AddOpt("pass_thru_content", passThruContent);
        return this;
      }
      public CheckoutExistingRequest Embed(bool embed) {
        _params.AddOpt("embed", embed);
        return this;
      }
      public CheckoutExistingRequest IframeMessaging(bool iframeMessaging) {
        _params.AddOpt("iframe_messaging", iframeMessaging);
        return this;
      }
      public CheckoutExistingRequest SubscriptionId(string subscriptionId) {
        _params.Add("subscription[id]", subscriptionId);
        return this;
      }
      public CheckoutExistingRequest SubscriptionPlanId(string subscriptionPlanId) {
        _params.AddOpt("subscription[plan_id]", subscriptionPlanId);
        return this;
      }
      public CheckoutExistingRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) {
        _params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
        return this;
      }
      public CheckoutExistingRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) {
        _params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
        return this;
      }
      public CheckoutExistingRequest SubscriptionSetupFee(int subscriptionSetupFee) {
        _params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
        return this;
      }
      public CheckoutExistingRequest SubscriptionStartDate(long subscriptionStartDate) {
        _params.AddOpt("subscription[start_date]", subscriptionStartDate);
        return this;
      }
      public CheckoutExistingRequest SubscriptionTrialEnd(long subscriptionTrialEnd) {
        _params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
        return this;
      }
      public CheckoutExistingRequest SubscriptionCoupon(string subscriptionCoupon) {
        _params.AddOpt("subscription[coupon]", subscriptionCoupon);
        return this;
      }
      public CheckoutExistingRequest SubscriptionInvoiceNotes(string subscriptionInvoiceNotes) {
        _params.AddOpt("subscription[invoice_notes]", subscriptionInvoiceNotes);
        return this;
      }
      public CheckoutExistingRequest CardGatewayAccountId(string cardGatewayAccountId) {
        _params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
        return this;
      }
      public CheckoutExistingRequest AddonId(int index, string addonId) {
        _params.AddOpt("addons[id][" + index + "]", addonId);
        return this;
      }
      public CheckoutExistingRequest AddonQuantity(int index, int addonQuantity) {
        _params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
        return this;
      }
      public CheckoutExistingRequest AddonUnitPrice(int index, int addonUnitPrice) {
        _params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
        return this;
      }
    }

    public class UpdateCardRequest : EntityRequest<UpdateCardRequest> {
      public UpdateCardRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public UpdateCardRequest RedirectUrl(string redirectUrl) {
        _params.AddOpt("redirect_url", redirectUrl);
        return this;
      }
      public UpdateCardRequest CancelUrl(string cancelUrl) {
        _params.AddOpt("cancel_url", cancelUrl);
        return this;
      }
      public UpdateCardRequest PassThruContent(string passThruContent) {
        _params.AddOpt("pass_thru_content", passThruContent);
        return this;
      }
      public UpdateCardRequest Embed(bool embed) {
        _params.AddOpt("embed", embed);
        return this;
      }
      public UpdateCardRequest IframeMessaging(bool iframeMessaging) {
        _params.AddOpt("iframe_messaging", iframeMessaging);
        return this;
      }
      public UpdateCardRequest CustomerId(string customerId) {
        _params.Add("customer[id]", customerId);
        return this;
      }
      public UpdateCardRequest CardGatewayAccountId(string cardGatewayAccountId) {
        _params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
        return this;
      }
    }

    public class UpdatePaymentMethodRequest : EntityRequest<UpdatePaymentMethodRequest> {
      public UpdatePaymentMethodRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public UpdatePaymentMethodRequest RedirectUrl(string redirectUrl) {
        _params.AddOpt("redirect_url", redirectUrl);
        return this;
      }
      public UpdatePaymentMethodRequest CancelUrl(string cancelUrl) {
        _params.AddOpt("cancel_url", cancelUrl);
        return this;
      }
      public UpdatePaymentMethodRequest PassThruContent(string passThruContent) {
        _params.AddOpt("pass_thru_content", passThruContent);
        return this;
      }
      public UpdatePaymentMethodRequest Embed(bool embed) {
        _params.AddOpt("embed", embed);
        return this;
      }
      public UpdatePaymentMethodRequest IframeMessaging(bool iframeMessaging) {
        _params.AddOpt("iframe_messaging", iframeMessaging);
        return this;
      }
      public UpdatePaymentMethodRequest CustomerId(string customerId) {
        _params.Add("customer[id]", customerId);
        return this;
      }
      public UpdatePaymentMethodRequest CardGatewayAccountId(string cardGatewayAccountId) {
        _params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
        return this;
      }
    }

    public enum TypeEnum {
      Unknown,
      [Description("checkout_new")]
      CheckoutNew,
      [Description("checkout_existing")]
      CheckoutExisting,
      [Description("update_payment_method")]
      UpdatePaymentMethod,
    }

    public enum StateEnum {
      Unknown,
      [Description("created")]
      Created,
      [Description("requested")]
      Requested,
      [Description("succeeded")]
      Succeeded,
      [Description("cancelled")]
      Cancelled,
      [Description("failed")]
      Failed,
    }

    public enum FailureReasonEnum {
      Unknown,
      [Description("card_error")]
      CardError,
      [Description("server_error")]
      ServerError,
    }

    public class HostedPageContent : ResultBase {
      public HostedPageContent() { }

      internal HostedPageContent(JToken jobj) {
        _jobj = jobj;
      }
    }
  }
}
