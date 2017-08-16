namespace RealArtists.ChargeBee.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Net.Http;
  using RealArtists.ChargeBee.Api;
  using RealArtists.ChargeBee.Internal;

  public class PortalSessionActions : ApiResourceActions {
    public PortalSessionActions(ChargeBeeApi api) : base(api) { }

    public PortalSession.CreateRequest Create() {
      string url = BuildUrl("portal_sessions");
      return new PortalSession.CreateRequest(Api, url, HttpMethod.Post);
    }

    public EntityRequest<Type> Retrieve(string id) {
      string url = BuildUrl("portal_sessions", id);
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }

    public EntityRequest<Type> Logout(string id) {
      string url = BuildUrl("portal_sessions", id, "logout");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }

    public PortalSession.ActivateRequest Activate(string id) {
      string url = BuildUrl("portal_sessions", id, "activate");
      return new PortalSession.ActivateRequest(Api, url, HttpMethod.Post);
    }
  }

  public class PortalSession : Resource {
    public string Id {
      get { return GetValue<string>("id", true); }
    }
    public string Token {
      get { return GetValue<string>("token", true); }
    }
    public string AccessUrl {
      get { return GetValue<string>("access_url", true); }
    }
    public string RedirectUrl {
      get { return GetValue<string>("redirect_url", true); }
    }
    public StatusEnum Status {
      get { return GetEnum<StatusEnum>("status", true); }
    }
    public DateTime CreatedAt {
      get { return (DateTime)GetDateTime("created_at", true); }
    }
    public DateTime? ExpiresAt {
      get { return GetDateTime("expires_at", false); }
    }
    public string CustomerId {
      get { return GetValue<string>("customer_id", true); }
    }
    public DateTime? LoginAt {
      get { return GetDateTime("login_at", false); }
    }
    public DateTime? LogoutAt {
      get { return GetDateTime("logout_at", false); }
    }
    public string LoginIpaddress {
      get { return GetValue<string>("login_ipaddress", false); }
    }
    public string LogoutIpaddress {
      get { return GetValue<string>("logout_ipaddress", false); }
    }
    public List<PortalSessionLinkedCustomer> LinkedCustomers {
      get { return GetResourceList<PortalSessionLinkedCustomer>("linked_customers"); }
    }

    public class CreateRequest : EntityRequest<CreateRequest> {
      public CreateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CreateRequest RedirectUrl(string redirectUrl) {
        _params.AddOpt("redirect_url", redirectUrl);
        return this;
      }
      public CreateRequest ForwardUrl(string forwardUrl) {
        _params.AddOpt("forward_url", forwardUrl);
        return this;
      }
      public CreateRequest CustomerId(string customerId) {
        _params.Add("customer[id]", customerId);
        return this;
      }
    }

    public class ActivateRequest : EntityRequest<ActivateRequest> {
      public ActivateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public ActivateRequest Token(string token) {
        _params.Add("token", token);
        return this;
      }
    }

    public enum StatusEnum {
      Unknown,
      [Description("created")]
      Created,
      [Description("logged_in")]
      LoggedIn,
      [Description("logged_out")]
      LoggedOut,
      [Description("not_yet_activated")]
      NotYetActivated,
      [Description("activated")]
      Activated,
    }

    public class PortalSessionLinkedCustomer : Resource {
      public string CustomerId() {
        return GetValue<string>("customer_id", true);
      }

      public string Email() {
        return GetValue<string>("email", false);
      }

      public bool HasBillingAddress() {
        return GetValue<bool>("has_billing_address", true);
      }

      public bool HasPaymentMethod() {
        return GetValue<bool>("has_payment_method", true);
      }

      public bool HasActiveSubscription() {
        return GetValue<bool>("has_active_subscription", true);
      }
    }
  }
}
