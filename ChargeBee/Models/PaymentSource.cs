namespace RealArtists.ChargeBee.Models {
  using System;
  using System.ComponentModel;
  using System.Net.Http;
  using RealArtists.ChargeBee.Api;
  using RealArtists.ChargeBee.Internal;
  using RealArtists.ChargeBee.Models.Enums;

  public class PaymentSourceActions : ApiResourceActions {
    public PaymentSourceActions(ChargeBeeApi api) : base(api) { }

    public PaymentSource.CreateUsingTempTokenRequest CreateUsingTempToken() {
      string url = BuildUrl("payment_sources", "create_using_temp_token");
      return new PaymentSource.CreateUsingTempTokenRequest(Api, url, HttpMethod.Post);
    }

    public PaymentSource.CreateUsingPermanentTokenRequest CreateUsingPermanentToken() {
      string url = BuildUrl("payment_sources", "create_using_permanent_token");
      return new PaymentSource.CreateUsingPermanentTokenRequest(Api, url, HttpMethod.Post);
    }

    public PaymentSource.CreateCardRequest CreateCard() {
      string url = BuildUrl("payment_sources", "create_card");
      return new PaymentSource.CreateCardRequest(Api, url, HttpMethod.Post);
    }

    public PaymentSource.UpdateCardRequest UpdateCard(string id) {
      string url = BuildUrl("payment_sources", id, "update_card");
      return new PaymentSource.UpdateCardRequest(Api, url, HttpMethod.Post);
    }

    public EntityRequest<Type> Retrieve(string id) {
      string url = BuildUrl("payment_sources", id);
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }

    public PaymentSource.PaymentSourceListRequest List() {
      string url = BuildUrl("payment_sources");
      return new PaymentSource.PaymentSourceListRequest(Api, url);
    }

    public PaymentSource.SwitchGatewayAccountRequest SwitchGatewayAccount(string id) {
      string url = BuildUrl("payment_sources", id, "switch_gateway_account");
      return new PaymentSource.SwitchGatewayAccountRequest(Api, url, HttpMethod.Post);
    }

    public PaymentSource.ExportPaymentSourceRequest ExportPaymentSource(string id) {
      string url = BuildUrl("payment_sources", id, "export_payment_source");
      return new PaymentSource.ExportPaymentSourceRequest(Api, url, HttpMethod.Post);
    }

    public EntityRequest<Type> Delete(string id) {
      string url = BuildUrl("payment_sources", id, "delete");
      return new EntityRequest<Type>(Api, url, HttpMethod.Post);
    }
  }

  public class PaymentSource : Resource {
    public string Id {
      get { return GetValue<string>("id", true); }
    }
    public string CustomerId {
      get { return GetValue<string>("customer_id", true); }
    }
    public TypeEnum PaymentSourceType {
      get { return GetEnum<TypeEnum>("type", true); }
    }
    public string ReferenceId {
      get { return GetValue<string>("reference_id", true); }
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
    public string IpAddress {
      get { return GetValue<string>("ip_address", false); }
    }
    public string IssuingCountry {
      get { return GetValue<string>("issuing_country", false); }
    }
    public PaymentSourceCard Card {
      get { return GetSubResource<PaymentSourceCard>("card"); }
    }
    public PaymentSourceBankAccount BankAccount {
      get { return GetSubResource<PaymentSourceBankAccount>("bank_account"); }
    }
    public PaymentSourceAmazonPayment AmazonPayment {
      get { return GetSubResource<PaymentSourceAmazonPayment>("amazon_payment"); }
    }
    public PaymentSourcePaypal Paypal {
      get { return GetSubResource<PaymentSourcePaypal>("paypal"); }
    }

    public class CreateUsingTempTokenRequest : EntityRequest<CreateUsingTempTokenRequest> {
      public CreateUsingTempTokenRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CreateUsingTempTokenRequest CustomerId(string customerId) {
        _params.Add("customer_id", customerId);
        return this;
      }
      public CreateUsingTempTokenRequest GatewayAccountId(string gatewayAccountId) {
        _params.AddOpt("gateway_account_id", gatewayAccountId);
        return this;
      }
      public CreateUsingTempTokenRequest Type(ChargeBee.Models.Enums.TypeEnum type) {
        _params.Add("type", type);
        return this;
      }
      public CreateUsingTempTokenRequest TmpToken(string tmpToken) {
        _params.Add("tmp_token", tmpToken);
        return this;
      }
      public CreateUsingTempTokenRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) {
        _params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
        return this;
      }
    }

    public class CreateUsingPermanentTokenRequest : EntityRequest<CreateUsingPermanentTokenRequest> {
      public CreateUsingPermanentTokenRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CreateUsingPermanentTokenRequest CustomerId(string customerId) {
        _params.Add("customer_id", customerId);
        return this;
      }
      public CreateUsingPermanentTokenRequest Type(ChargeBee.Models.Enums.TypeEnum type) {
        _params.Add("type", type);
        return this;
      }
      public CreateUsingPermanentTokenRequest GatewayAccountId(string gatewayAccountId) {
        _params.AddOpt("gateway_account_id", gatewayAccountId);
        return this;
      }
      public CreateUsingPermanentTokenRequest ReferenceId(string referenceId) {
        _params.Add("reference_id", referenceId);
        return this;
      }
      public CreateUsingPermanentTokenRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) {
        _params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
        return this;
      }
    }

    public class CreateCardRequest : EntityRequest<CreateCardRequest> {
      public CreateCardRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CreateCardRequest CustomerId(string customerId) {
        _params.Add("customer_id", customerId);
        return this;
      }
      public CreateCardRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) {
        _params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
        return this;
      }
      public CreateCardRequest CardGatewayAccountId(string cardGatewayAccountId) {
        _params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
        return this;
      }
      public CreateCardRequest CardFirstName(string cardFirstName) {
        _params.AddOpt("card[first_name]", cardFirstName);
        return this;
      }
      public CreateCardRequest CardLastName(string cardLastName) {
        _params.AddOpt("card[last_name]", cardLastName);
        return this;
      }
      public CreateCardRequest CardNumber(string cardNumber) {
        _params.Add("card[number]", cardNumber);
        return this;
      }
      public CreateCardRequest CardExpiryMonth(int cardExpiryMonth) {
        _params.Add("card[expiry_month]", cardExpiryMonth);
        return this;
      }
      public CreateCardRequest CardExpiryYear(int cardExpiryYear) {
        _params.Add("card[expiry_year]", cardExpiryYear);
        return this;
      }
      public CreateCardRequest CardCvv(string cardCvv) {
        _params.AddOpt("card[cvv]", cardCvv);
        return this;
      }
      public CreateCardRequest CardBillingAddr1(string cardBillingAddr1) {
        _params.AddOpt("card[billing_addr1]", cardBillingAddr1);
        return this;
      }
      public CreateCardRequest CardBillingAddr2(string cardBillingAddr2) {
        _params.AddOpt("card[billing_addr2]", cardBillingAddr2);
        return this;
      }
      public CreateCardRequest CardBillingCity(string cardBillingCity) {
        _params.AddOpt("card[billing_city]", cardBillingCity);
        return this;
      }
      public CreateCardRequest CardBillingStateCode(string cardBillingStateCode) {
        _params.AddOpt("card[billing_state_code]", cardBillingStateCode);
        return this;
      }
      public CreateCardRequest CardBillingState(string cardBillingState) {
        _params.AddOpt("card[billing_state]", cardBillingState);
        return this;
      }
      public CreateCardRequest CardBillingZip(string cardBillingZip) {
        _params.AddOpt("card[billing_zip]", cardBillingZip);
        return this;
      }
      public CreateCardRequest CardBillingCountry(string cardBillingCountry) {
        _params.AddOpt("card[billing_country]", cardBillingCountry);
        return this;
      }
    }

    public class UpdateCardRequest : EntityRequest<UpdateCardRequest> {
      public UpdateCardRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public UpdateCardRequest GatewayMetaData(string gatewayMetaData) {
        _params.AddOpt("gateway_meta_data", gatewayMetaData);
        return this;
      }
      public UpdateCardRequest CardFirstName(string cardFirstName) {
        _params.AddOpt("card[first_name]", cardFirstName);
        return this;
      }
      public UpdateCardRequest CardLastName(string cardLastName) {
        _params.AddOpt("card[last_name]", cardLastName);
        return this;
      }
      public UpdateCardRequest CardExpiryMonth(int cardExpiryMonth) {
        _params.AddOpt("card[expiry_month]", cardExpiryMonth);
        return this;
      }
      public UpdateCardRequest CardExpiryYear(int cardExpiryYear) {
        _params.AddOpt("card[expiry_year]", cardExpiryYear);
        return this;
      }
      public UpdateCardRequest CardBillingAddr1(string cardBillingAddr1) {
        _params.AddOpt("card[billing_addr1]", cardBillingAddr1);
        return this;
      }
      public UpdateCardRequest CardBillingAddr2(string cardBillingAddr2) {
        _params.AddOpt("card[billing_addr2]", cardBillingAddr2);
        return this;
      }
      public UpdateCardRequest CardBillingCity(string cardBillingCity) {
        _params.AddOpt("card[billing_city]", cardBillingCity);
        return this;
      }
      public UpdateCardRequest CardBillingZip(string cardBillingZip) {
        _params.AddOpt("card[billing_zip]", cardBillingZip);
        return this;
      }
      public UpdateCardRequest CardBillingStateCode(string cardBillingStateCode) {
        _params.AddOpt("card[billing_state_code]", cardBillingStateCode);
        return this;
      }
      public UpdateCardRequest CardBillingState(string cardBillingState) {
        _params.AddOpt("card[billing_state]", cardBillingState);
        return this;
      }
      public UpdateCardRequest CardBillingCountry(string cardBillingCountry) {
        _params.AddOpt("card[billing_country]", cardBillingCountry);
        return this;
      }
    }

    public class PaymentSourceListRequest : ListRequestBase<PaymentSourceListRequest> {
      public PaymentSourceListRequest(ChargeBeeApi api, string url)
              : base(api, url) {
      }

      public StringFilter<PaymentSourceListRequest> CustomerId() {
        return new StringFilter<PaymentSourceListRequest>("customer_id", this).SupportsMultiOperators(true);
      }
      public EnumFilter<ChargeBee.Models.Enums.TypeEnum, PaymentSourceListRequest> Type() {
        return new EnumFilter<ChargeBee.Models.Enums.TypeEnum, PaymentSourceListRequest>("type", this);
      }
      public EnumFilter<PaymentSource.StatusEnum, PaymentSourceListRequest> Status() {
        return new EnumFilter<PaymentSource.StatusEnum, PaymentSourceListRequest>("status", this);
      }
    }

    public class SwitchGatewayAccountRequest : EntityRequest<SwitchGatewayAccountRequest> {
      public SwitchGatewayAccountRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public SwitchGatewayAccountRequest GatewayAccountId(string gatewayAccountId) {
        _params.Add("gateway_account_id", gatewayAccountId);
        return this;
      }
    }

    public class ExportPaymentSourceRequest : EntityRequest<ExportPaymentSourceRequest> {
      public ExportPaymentSourceRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public ExportPaymentSourceRequest GatewayAccountId(string gatewayAccountId) {
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
      [Description("invalid")]
      Invalid,
      [Description("pending_verification")]
      PendingVerification,

    }

    public class PaymentSourceCard : Resource {
      public enum BrandEnum {
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

      public string FirstName() {
        return GetValue<string>("first_name", false);
      }

      public string LastName() {
        return GetValue<string>("last_name", false);
      }

      public string Iin() {
        return GetValue<string>("iin", true);
      }

      public string Last4() {
        return GetValue<string>("last4", true);
      }

      public BrandEnum Brand() {
        return GetEnum<BrandEnum>("brand", true);
      }

      public FundingTypeEnum FundingType() {
        return GetEnum<FundingTypeEnum>("funding_type", true);
      }

      public int ExpiryMonth() {
        return GetValue<int>("expiry_month", true);
      }

      public int ExpiryYear() {
        return GetValue<int>("expiry_year", true);
      }

      public string BillingAddr1() {
        return GetValue<string>("billing_addr1", false);
      }

      public string BillingAddr2() {
        return GetValue<string>("billing_addr2", false);
      }

      public string BillingCity() {
        return GetValue<string>("billing_city", false);
      }

      public string BillingStateCode() {
        return GetValue<string>("billing_state_code", false);
      }

      public string BillingState() {
        return GetValue<string>("billing_state", false);
      }

      public string BillingCountry() {
        return GetValue<string>("billing_country", false);
      }

      public string BillingZip() {
        return GetValue<string>("billing_zip", false);
      }

      public string MaskedNumber() {
        return GetValue<string>("masked_number", false);
      }
    }

    public class PaymentSourceBankAccount : Resource {
      public enum AccountTypeEnum {
        Unknown,
        [Description("checking")]
        Checking,
        [Description("savings")]
        Savings,
      }

      public string NameOnAccount() {
        return GetValue<string>("name_on_account", false);
      }

      public string BankName() {
        return GetValue<string>("bank_name", false);
      }

      public string MandateId() {
        return GetValue<string>("mandate_id", false);
      }

      public AccountTypeEnum? AccountType() {
        return GetEnum<AccountTypeEnum>("account_type", false);
      }

    }

    public class PaymentSourceAmazonPayment : Resource {

      public string Email() {
        return GetValue<string>("email", false);
      }

      public string AgreementId() {
        return GetValue<string>("agreement_id", false);
      }

    }

    public class PaymentSourcePaypal : Resource {

      public string Email() {
        return GetValue<string>("email", false);
      }

      public string AgreementId() {
        return GetValue<string>("agreement_id", false);
      }

    }
  }
}
