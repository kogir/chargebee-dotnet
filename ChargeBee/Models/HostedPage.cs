namespace ChargeBee.Models {
  using System;
  using System.ComponentModel;
  using System.Net.Http;
  using ChargeBee.Api;
  using ChargeBee.Internal;
  using ChargeBee.Models.Enums;
  using Newtonsoft.Json.Linq;

  public class HostedPage : Resource {
    public static CheckoutNewRequest CheckoutNew() {
      string url = ApiUtil.BuildUrl("hosted_pages", "checkout_new");
      return new CheckoutNewRequest(url, HttpMethod.Post);
    }
    public static CheckoutExistingRequest CheckoutExisting() {
      string url = ApiUtil.BuildUrl("hosted_pages", "checkout_existing");
      return new CheckoutExistingRequest(url, HttpMethod.Post);
    }
    public static UpdatePaymentMethodRequest UpdatePaymentMethod() {
      string url = ApiUtil.BuildUrl("hosted_pages", "update_payment_method");
      return new UpdatePaymentMethodRequest(url, HttpMethod.Post);
    }
    public static EntityRequest<Type> Retrieve(string id) {
      string url = ApiUtil.BuildUrl("hosted_pages", CheckNull(id));
      return new EntityRequest<Type>(url, HttpMethod.Get);
    }

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
      public CheckoutNewRequest(string url, HttpMethod method)
              : base(url, method) {
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
      public CheckoutNewRequest CardGateway(GatewayEnum cardGateway) {
        _params.AddOpt("card[gateway]", cardGateway);
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
    }

    public class CheckoutExistingRequest : EntityRequest<CheckoutExistingRequest> {
      public CheckoutExistingRequest(string url, HttpMethod method)
              : base(url, method) {
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
      public CheckoutExistingRequest CardGateway(GatewayEnum cardGateway) {
        _params.AddOpt("card[gateway]", cardGateway);
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
    }

    public class UpdateCardRequest : EntityRequest<UpdateCardRequest> {
      public UpdateCardRequest(string url, HttpMethod method)
              : base(url, method) {
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
      public UpdateCardRequest CardGateway(GatewayEnum cardGateway) {
        _params.AddOpt("card[gateway]", cardGateway);
        return this;
      }
    }

    public class UpdatePaymentMethodRequest : EntityRequest<UpdatePaymentMethodRequest> {
      public UpdatePaymentMethodRequest(string url, HttpMethod method)
              : base(url, method) {
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
      public UpdatePaymentMethodRequest CardGateway(GatewayEnum cardGateway) {
        _params.AddOpt("card[gateway]", cardGateway);
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
