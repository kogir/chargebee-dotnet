namespace RealArtists.ChargeBee.Models {
  using System;
  using System.ComponentModel;
  using System.Net.Http;
  using RealArtists.ChargeBee.Api;
  using RealArtists.ChargeBee.Internal;
  using RealArtists.ChargeBee.Models.Enums;

  public class CardActions : ApiResourceActions {
    public CardActions(ChargeBeeApi api) : base(api) { }

    public EntityRequest<Type> Retrieve(string id) {
      string url = BuildUrl("cards", id);
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }

    public Card.UpdateCardForCustomerRequest UpdateCardForCustomer(string id) {
      string url = BuildUrl("customers", id, "credit_card");
      return new Card.UpdateCardForCustomerRequest(Api, url, HttpMethod.Post);
    }

    public Card.SwitchGatewayForCustomerRequest SwitchGatewayForCustomer(string id) {
      string url = BuildUrl("customers", id, "switch_gateway");
      return new Card.SwitchGatewayForCustomerRequest(Api, url, HttpMethod.Post);
    }

    public Card.CopyCardForCustomerRequest CopyCardForCustomer(string id) {
      string url = BuildUrl("customers", id, "copy_card");
      return new Card.CopyCardForCustomerRequest(Api, url, HttpMethod.Post);
    }

    public EntityRequest<Type> DeleteCardForCustomer(string id) {
      string url = BuildUrl("customers", id, "delete_card");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }
  }

  public class Card : Resource {
    public string PaymentSourceId {
      get { return GetValue<string>("payment_source_id", true); }
    }
    public StatusEnum Status {
      get { return GetEnum<StatusEnum>("status", true); }
    }
    public GatewayEnum Gateway {
      get { return GetEnum<GatewayEnum>("gateway", true); }
    }
    public string GatewayAccountId {
      get { return GetValue<string>("gateway_account_id", false); }
    }
    public string FirstName {
      get { return GetValue<string>("first_name", false); }
    }
    public string LastName {
      get { return GetValue<string>("last_name", false); }
    }
    public string Iin {
      get { return GetValue<string>("iin", true); }
    }
    public string Last4 {
      get { return GetValue<string>("last4", true); }
    }
    public CardTypeEnum? CardType {
      get { return GetEnum<CardTypeEnum>("card_type", false); }
    }
    public FundingTypeEnum FundingType {
      get { return GetEnum<FundingTypeEnum>("funding_type", true); }
    }
    public int ExpiryMonth {
      get { return GetValue<int>("expiry_month", true); }
    }
    public int ExpiryYear {
      get { return GetValue<int>("expiry_year", true); }
    }
    public string IssuingCountry {
      get { return GetValue<string>("issuing_country", false); }
    }
    public string BillingAddr1 {
      get { return GetValue<string>("billing_addr1", false); }
    }
    public string BillingAddr2 {
      get { return GetValue<string>("billing_addr2", false); }
    }
    public string BillingCity {
      get { return GetValue<string>("billing_city", false); }
    }
    public string BillingStateCode {
      get { return GetValue<string>("billing_state_code", false); }
    }
    public string BillingState {
      get { return GetValue<string>("billing_state", false); }
    }
    public string BillingCountry {
      get { return GetValue<string>("billing_country", false); }
    }
    public string BillingZip {
      get { return GetValue<string>("billing_zip", false); }
    }
    public string IpAddress {
      get { return GetValue<string>("ip_address", false); }
    }
    public string CustomerId {
      get { return GetValue<string>("customer_id", true); }
    }
    public string MaskedNumber {
      get { return GetValue<string>("masked_number", false); }
    }

    public class UpdateCardForCustomerRequest : EntityRequest<UpdateCardForCustomerRequest> {
      public UpdateCardForCustomerRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public UpdateCardForCustomerRequest GatewayAccountId(string gatewayAccountId) {
        _params.AddOpt("gateway_account_id", gatewayAccountId);
        return this;
      }
      public UpdateCardForCustomerRequest TmpToken(string tmpToken) {
        _params.AddOpt("tmp_token", tmpToken);
        return this;
      }
      public UpdateCardForCustomerRequest FirstName(string firstName) {
        _params.AddOpt("first_name", firstName);
        return this;
      }
      public UpdateCardForCustomerRequest LastName(string lastName) {
        _params.AddOpt("last_name", lastName);
        return this;
      }
      public UpdateCardForCustomerRequest Number(string number) {
        _params.Add("number", number);
        return this;
      }
      public UpdateCardForCustomerRequest ExpiryMonth(int expiryMonth) {
        _params.Add("expiry_month", expiryMonth);
        return this;
      }
      public UpdateCardForCustomerRequest ExpiryYear(int expiryYear) {
        _params.Add("expiry_year", expiryYear);
        return this;
      }
      public UpdateCardForCustomerRequest Cvv(string cvv) {
        _params.AddOpt("cvv", cvv);
        return this;
      }
      public UpdateCardForCustomerRequest BillingAddr1(string billingAddr1) {
        _params.AddOpt("billing_addr1", billingAddr1);
        return this;
      }
      public UpdateCardForCustomerRequest BillingAddr2(string billingAddr2) {
        _params.AddOpt("billing_addr2", billingAddr2);
        return this;
      }
      public UpdateCardForCustomerRequest BillingCity(string billingCity) {
        _params.AddOpt("billing_city", billingCity);
        return this;
      }
      public UpdateCardForCustomerRequest BillingStateCode(string billingStateCode) {
        _params.AddOpt("billing_state_code", billingStateCode);
        return this;
      }
      public UpdateCardForCustomerRequest BillingState(string billingState) {
        _params.AddOpt("billing_state", billingState);
        return this;
      }
      public UpdateCardForCustomerRequest BillingZip(string billingZip) {
        _params.AddOpt("billing_zip", billingZip);
        return this;
      }
      public UpdateCardForCustomerRequest BillingCountry(string billingCountry) {
        _params.AddOpt("billing_country", billingCountry);
        return this;
      }
    }

    public class SwitchGatewayForCustomerRequest : EntityRequest<SwitchGatewayForCustomerRequest> {
      public SwitchGatewayForCustomerRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }


      public SwitchGatewayForCustomerRequest GatewayAccountId(string gatewayAccountId) {
        _params.Add("gateway_account_id", gatewayAccountId);
        return this;
      }
    }

    public class CopyCardForCustomerRequest : EntityRequest<CopyCardForCustomerRequest> {
      public CopyCardForCustomerRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CopyCardForCustomerRequest GatewayAccountId(string gatewayAccountId) {
        _params.Add("gateway_account_id", gatewayAccountId);
        return this;
      }
    }

    public enum StatusEnum {
      Unknown,
      [Description("valid")]
      Valid,
      [Description("expiring")]
      Expiring,
      [Description("expired")]
      Expired,
    }

    public enum CardTypeEnum {
      Unknown,
      [Description("visa")]
      Visa,
      [Description("mastercard")]
      Mastercard,
      [Description("american_express")]
      AmericanExpress,
      [Description("discover")]
      Discover,
      [Description("jcb")]
      Jcb,
      [Description("diners_club")]
      DinersClub,
      [Description("other")]
      Other,
      [Description("not_applicable")]
      NotApplicable,
    }

    public enum FundingTypeEnum {
      Unknown,
      [Description("credit")]
      Credit,
      [Description("debit")]
      Debit,
      [Description("prepaid")]
      Prepaid,
      [Description("not_known")]
      NotKnown,
      [Description("not_applicable")]
      NotApplicable,
    }
  }
}
