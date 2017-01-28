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

  public class CustomerActions : ApiResourceActions {
    public CustomerActions(ChargeBeeApi api) : base(api) { }

    public Customer.CreateRequest Create() {
      string url = BuildUrl("customers");
      return new Customer.CreateRequest(Api, url, HttpMethod.Post);
    }
    public Customer.CustomerListRequest List() {
      string url = BuildUrl("customers");
      return new Customer.CustomerListRequest(Api, url);
    }
    public EntityRequest<Type> Retrieve(string id) {
      string url = BuildUrl("customers", id);
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }
    public Customer.UpdateRequest Update(string id) {
      string url = BuildUrl("customers", id);
      return new Customer.UpdateRequest(Api, url, HttpMethod.Post);
    }
    public Customer.UpdatePaymentMethodRequest UpdatePaymentMethod(string id) {
      string url = BuildUrl("customers", id, "update_payment_method");
      return new Customer.UpdatePaymentMethodRequest(Api, url, HttpMethod.Post);
    }
    public Customer.UpdateBillingInfoRequest UpdateBillingInfo(string id) {
      string url = BuildUrl("customers", id, "update_billing_info");
      return new Customer.UpdateBillingInfoRequest(Api, url, HttpMethod.Post);
    }
    public Customer.AddContactRequest AddContact(string id) {
      string url = BuildUrl("customers", id, "add_contact");
      return new Customer.AddContactRequest(Api, url, HttpMethod.Post);
    }
    public Customer.UpdateContactRequest UpdateContact(string id) {
      string url = BuildUrl("customers", id, "update_contact");
      return new Customer.UpdateContactRequest(Api, url, HttpMethod.Post);
    }
    public Customer.DeleteContactRequest DeleteContact(string id) {
      string url = BuildUrl("customers", id, "delete_contact");
      return new Customer.DeleteContactRequest(Api, url, HttpMethod.Post);
    }
    public Customer.AddPromotionalCreditsRequest AddPromotionalCredits(string id) {
      string url = BuildUrl("customers", id, "add_promotional_credits");
      return new Customer.AddPromotionalCreditsRequest(Api, url, HttpMethod.Post);
    }
    public Customer.DeductPromotionalCreditsRequest DeductPromotionalCredits(string id) {
      string url = BuildUrl("customers", id, "deduct_promotional_credits");
      return new Customer.DeductPromotionalCreditsRequest(Api, url, HttpMethod.Post);
    }
    public Customer.SetPromotionalCreditsRequest SetPromotionalCredits(string id) {
      string url = BuildUrl("customers", id, "set_promotional_credits");
      return new Customer.SetPromotionalCreditsRequest(Api, url, HttpMethod.Post);
    }
    public Customer.RecordExcessPaymentRequest RecordExcessPayment(string id) {
      string url = BuildUrl("customers", id, "record_excess_payment");
      return new Customer.RecordExcessPaymentRequest(Api, url, HttpMethod.Post);
    }
    public Customer.DeleteRequest Delete(string id) {
      string url = BuildUrl("customers", id, "delete");
      return new Customer.DeleteRequest(Api, url, HttpMethod.Post);
    }
  }

  public class Customer : Resource {
    public string Id {
      get { return GetValue<string>("id", true); }
    }
    public string FirstName {
      get { return GetValue<string>("first_name", false); }
    }
    public string LastName {
      get { return GetValue<string>("last_name", false); }
    }
    public string Email {
      get { return GetValue<string>("email", false); }
    }
    public string Phone {
      get { return GetValue<string>("phone", false); }
    }
    public string Company {
      get { return GetValue<string>("company", false); }
    }
    public string VatNumber {
      get { return GetValue<string>("vat_number", false); }
    }
    public AutoCollectionEnum AutoCollection {
      get { return GetEnum<AutoCollectionEnum>("auto_collection", true); }
    }
    public int NetTermDays {
      get { return GetValue<int>("net_ter_days", true); }
    }
    public bool AllowDirectDebit {
      get { return GetValue<bool>("allow_direct_debit", true); }
    }
    public DateTime CreatedAt {
      get { return (DateTime)GetDateTime("created_at", true); }
    }
    public string CreatedFromIp {
      get { return GetValue<string>("created_fro_ip", false); }
    }
    public TaxabilityEnum? Taxability {
      get { return GetEnum<TaxabilityEnum>("taxability", false); }
    }
    public EntityCodeEnum? EntityCode {
      get { return GetEnum<EntityCodeEnum>("entity_code", false); }
    }
    public string ExemptNumber {
      get { return GetValue<string>("exempt_number", false); }
    }
    public long? ResourceVersion {
      get { return GetValue<long?>("resource_version", false); }
    }
    public DateTime? UpdatedAt {
      get { return GetDateTime("updated_at", false); }
    }
    public string Locale {
      get { return GetValue<string>("locale", false); }
    }
    public FraudFlagEnum? FraudFlag {
      get { return GetEnum<FraudFlagEnum>("fraud_flag", false); }
    }
    public CustomerBillingAddress BillingAddress {
      get { return GetSubResource<CustomerBillingAddress>("billing_address"); }
    }
    public List<CustomerContact> Contacts {
      get { return GetResourceList<CustomerContact>("contacts"); }
    }
    public CustomerPaymentMethod PaymentMethod {
      get { return GetSubResource<CustomerPaymentMethod>("payment_method"); }
    }
    public string InvoiceNotes {
      get { return GetValue<string>("invoice_notes", false); }
    }
    public string PreferredCurrencyCode {
      get { return GetValue<string>("preferred_currency_code", false); }
    }
    public int PromotionalCredits {
      get { return GetValue<int>("promotional_credits", true); }
    }
    public int RefundableCredits {
      get { return GetValue<int>("refundable_credits", true); }
    }
    public int ExcessPayments {
      get { return GetValue<int>("excess_payments", true); }
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
      public CreateRequest FirstName(string firstName) {
        _params.AddOpt("first_name", firstName);
        return this;
      }
      public CreateRequest LastName(string lastName) {
        _params.AddOpt("last_name", lastName);
        return this;
      }
      public CreateRequest Email(string email) {
        _params.AddOpt("email", email);
        return this;
      }
      public CreateRequest PreferredCurrencyCode(string preferredCurrencyCode) {
        _params.AddOpt("preferred_currency_code", preferredCurrencyCode);
        return this;
      }
      public CreateRequest Phone(string phone) {
        _params.AddOpt("phone", phone);
        return this;
      }
      public CreateRequest Company(string company) {
        _params.AddOpt("company", company);
        return this;
      }
      public CreateRequest AutoCollection(AutoCollectionEnum autoCollection) {
        _params.AddOpt("auto_collection", autoCollection);
        return this;
      }
      public CreateRequest NetTermDays(int netTermDays) {
        _params.AddOpt("net_ter_days", netTermDays);
        return this;
      }
      public CreateRequest AllowDirectDebit(bool allowDirectDebit) {
        _params.AddOpt("allow_direct_debit", allowDirectDebit);
        return this;
      }
      public CreateRequest VatNumber(string vatNumber) {
        _params.AddOpt("vat_number", vatNumber);
        return this;
      }
      public CreateRequest Taxability(TaxabilityEnum taxability) {
        _params.AddOpt("taxability", taxability);
        return this;
      }
      public CreateRequest Locale(string locale) {
        _params.AddOpt("locale", locale);
        return this;
      }
      public CreateRequest EntityCode(EntityCodeEnum entityCode) {
        _params.AddOpt("entity_code", entityCode);
        return this;
      }
      public CreateRequest ExemptNumber(string exemptNumber) {
        _params.AddOpt("exempt_number", exemptNumber);
        return this;
      }
      public CreateRequest MetaData(JToken metaData) {
        _params.AddOpt("meta_data", metaData);
        return this;
      }
      public CreateRequest InvoiceNotes(string invoiceNotes) {
        _params.AddOpt("invoice_notes", invoiceNotes);
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
      public CreateRequest PaymentMethodTmpToken(string paymentMethodTmpToken) {
        _params.AddOpt("payment_method[tmp_token]", paymentMethodTmpToken);
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
    }

    public class CustomerListRequest : ListRequestBase<CustomerListRequest> {
      public CustomerListRequest(ChargeBeeApi api, string url)
              : base(api, url) {
      }

      public CustomerListRequest IncludeDeleted(bool includeDeleted) {
        _params.AddOpt("include_deleted", includeDeleted);
        return this;
      }
      public StringFilter<CustomerListRequest> Id() {
        return new StringFilter<CustomerListRequest>("id", this).SupportsMultiOperators(true);
      }
      public StringFilter<CustomerListRequest> FirstName() {
        return new StringFilter<CustomerListRequest>("first_name", this).SupportsPresenceOperator(true);
      }
      public StringFilter<CustomerListRequest> LastName() {
        return new StringFilter<CustomerListRequest>("last_name", this).SupportsPresenceOperator(true);
      }
      public StringFilter<CustomerListRequest> Email() {
        return new StringFilter<CustomerListRequest>("email", this).SupportsPresenceOperator(true);
      }
      public StringFilter<CustomerListRequest> Company() {
        return new StringFilter<CustomerListRequest>("company", this).SupportsPresenceOperator(true);
      }
      public EnumFilter<AutoCollectionEnum, CustomerListRequest> AutoCollection() {
        return new EnumFilter<AutoCollectionEnum, CustomerListRequest>("auto_collection", this);
      }
      public EnumFilter<TaxabilityEnum, CustomerListRequest> Taxability() {
        return new EnumFilter<TaxabilityEnum, CustomerListRequest>("taxability", this);
      }
      public TimestampFilter<CustomerListRequest> CreatedAt() {
        return new TimestampFilter<CustomerListRequest>("created_at", this);
      }
      public TimestampFilter<CustomerListRequest> UpdatedAt() {
        return new TimestampFilter<CustomerListRequest>("updated_at", this);
      }
      public CustomerListRequest SortByCreatedAt(SortOrderEnum order) {
        _params.AddOpt("sort_by[" + order.ToString().ToLower() + "]", "created_at");
        return this;
      }
    }

    public class UpdateRequest : EntityRequest<UpdateRequest> {
      public UpdateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public UpdateRequest FirstName(string firstName) {
        _params.AddOpt("first_name", firstName);
        return this;
      }
      public UpdateRequest LastName(string lastName) {
        _params.AddOpt("last_name", lastName);
        return this;
      }
      public UpdateRequest Email(string email) {
        _params.AddOpt("email", email);
        return this;
      }
      public UpdateRequest PreferredCurrencyCode(string preferredCurrencyCode) {
        _params.AddOpt("preferred_currency_code", preferredCurrencyCode);
        return this;
      }
      public UpdateRequest Phone(string phone) {
        _params.AddOpt("phone", phone);
        return this;
      }
      public UpdateRequest Company(string company) {
        _params.AddOpt("company", company);
        return this;
      }
      public UpdateRequest AutoCollection(AutoCollectionEnum autoCollection) {
        _params.AddOpt("auto_collection", autoCollection);
        return this;
      }
      public UpdateRequest AllowDirectDebit(bool allowDirectDebit) {
        _params.AddOpt("allow_direct_debit", allowDirectDebit);
        return this;
      }
      public UpdateRequest NetTermDays(int netTermDays) {
        _params.AddOpt("net_ter_days", netTermDays);
        return this;
      }
      public UpdateRequest Taxability(TaxabilityEnum taxability) {
        _params.AddOpt("taxability", taxability);
        return this;
      }
      public UpdateRequest Locale(string locale) {
        _params.AddOpt("locale", locale);
        return this;
      }
      public UpdateRequest EntityCode(EntityCodeEnum entityCode) {
        _params.AddOpt("entity_code", entityCode);
        return this;
      }
      public UpdateRequest ExemptNumber(string exemptNumber) {
        _params.AddOpt("exempt_number", exemptNumber);
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
      public UpdateRequest FraudFlag(FraudFlagEnum fraudFlag) {
        _params.AddOpt("fraud_flag", fraudFlag);
        return this;
      }
    }

    public class UpdatePaymentMethodRequest : EntityRequest<UpdatePaymentMethodRequest> {
      public UpdatePaymentMethodRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }
      public UpdatePaymentMethodRequest PaymentMethodType(TypeEnum paymentMethodType) {
        _params.Add("payment_method[type]", paymentMethodType);
        return this;
      }
      public UpdatePaymentMethodRequest PaymentMethodGatewayAccountId(string paymentMethodGatewayAccountId) {
        _params.AddOpt("payment_method[gateway_account_id]", paymentMethodGatewayAccountId);
        return this;
      }
      public UpdatePaymentMethodRequest PaymentMethodReferenceId(string paymentMethodReferenceId) {
        _params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
        return this;
      }
      public UpdatePaymentMethodRequest PaymentMethodTmpToken(string paymentMethodTmpToken) {
        _params.AddOpt("payment_method[tmp_token]", paymentMethodTmpToken);
        return this;
      }
    }

    public class UpdateBillingInfoRequest : EntityRequest<UpdateBillingInfoRequest> {
      public UpdateBillingInfoRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public UpdateBillingInfoRequest VatNumber(string vatNumber) {
        _params.AddOpt("vat_number", vatNumber);
        return this;
      }
      public UpdateBillingInfoRequest BillingAddressFirstName(string billingAddressFirstName) {
        _params.AddOpt("billing_address[first_name]", billingAddressFirstName);
        return this;
      }
      public UpdateBillingInfoRequest BillingAddressLastName(string billingAddressLastName) {
        _params.AddOpt("billing_address[last_name]", billingAddressLastName);
        return this;
      }
      public UpdateBillingInfoRequest BillingAddressEmail(string billingAddressEmail) {
        _params.AddOpt("billing_address[email]", billingAddressEmail);
        return this;
      }
      public UpdateBillingInfoRequest BillingAddressCompany(string billingAddressCompany) {
        _params.AddOpt("billing_address[company]", billingAddressCompany);
        return this;
      }
      public UpdateBillingInfoRequest BillingAddressPhone(string billingAddressPhone) {
        _params.AddOpt("billing_address[phone]", billingAddressPhone);
        return this;
      }
      public UpdateBillingInfoRequest BillingAddressLine1(string billingAddressLine1) {
        _params.AddOpt("billing_address[line1]", billingAddressLine1);
        return this;
      }
      public UpdateBillingInfoRequest BillingAddressLine2(string billingAddressLine2) {
        _params.AddOpt("billing_address[line2]", billingAddressLine2);
        return this;
      }
      public UpdateBillingInfoRequest BillingAddressLine3(string billingAddressLine3) {
        _params.AddOpt("billing_address[line3]", billingAddressLine3);
        return this;
      }
      public UpdateBillingInfoRequest BillingAddressCity(string billingAddressCity) {
        _params.AddOpt("billing_address[city]", billingAddressCity);
        return this;
      }
      public UpdateBillingInfoRequest BillingAddressStateCode(string billingAddressStateCode) {
        _params.AddOpt("billing_address[state_code]", billingAddressStateCode);
        return this;
      }
      public UpdateBillingInfoRequest BillingAddressState(string billingAddressState) {
        _params.AddOpt("billing_address[state]", billingAddressState);
        return this;
      }
      public UpdateBillingInfoRequest BillingAddressZip(string billingAddressZip) {
        _params.AddOpt("billing_address[zip]", billingAddressZip);
        return this;
      }
      public UpdateBillingInfoRequest BillingAddressCountry(string billingAddressCountry) {
        _params.AddOpt("billing_address[country]", billingAddressCountry);
        return this;
      }
      public UpdateBillingInfoRequest BillingAddressValidationStatus(ValidationStatusEnum billingAddressValidationStatus) {
        _params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
        return this;
      }
    }

    public class AddContactRequest : EntityRequest<AddContactRequest> {
      public AddContactRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public AddContactRequest ContactId(string contactId) {
        _params.AddOpt("contact[id]", contactId);
        return this;
      }
      public AddContactRequest ContactFirstName(string contactFirstName) {
        _params.AddOpt("contact[first_name]", contactFirstName);
        return this;
      }
      public AddContactRequest ContactLastName(string contactLastName) {
        _params.AddOpt("contact[last_name]", contactLastName);
        return this;
      }
      public AddContactRequest ContactEmail(string contactEmail) {
        _params.Add("contact[email]", contactEmail);
        return this;
      }
      public AddContactRequest ContactPhone(string contactPhone) {
        _params.AddOpt("contact[phone]", contactPhone);
        return this;
      }
      public AddContactRequest ContactLabel(string contactLabel) {
        _params.AddOpt("contact[label]", contactLabel);
        return this;
      }
      public AddContactRequest ContactEnabled(bool contactEnabled) {
        _params.AddOpt("contact[enabled]", contactEnabled);
        return this;
      }
      public AddContactRequest ContactSendBillingEmail(bool contactSendBillingEmail) {
        _params.AddOpt("contact[send_billing_email]", contactSendBillingEmail);
        return this;
      }
      public AddContactRequest ContactSendAccountEmail(bool contactSendAccountEmail) {
        _params.AddOpt("contact[send_account_email]", contactSendAccountEmail);
        return this;
      }
    }

    public class UpdateContactRequest : EntityRequest<UpdateContactRequest> {
      public UpdateContactRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public UpdateContactRequest ContactId(string contactId) {
        _params.Add("contact[id]", contactId);
        return this;
      }
      public UpdateContactRequest ContactFirstName(string contactFirstName) {
        _params.AddOpt("contact[first_name]", contactFirstName);
        return this;
      }
      public UpdateContactRequest ContactLastName(string contactLastName) {
        _params.AddOpt("contact[last_name]", contactLastName);
        return this;
      }
      public UpdateContactRequest ContactEmail(string contactEmail) {
        _params.AddOpt("contact[email]", contactEmail);
        return this;
      }
      public UpdateContactRequest ContactPhone(string contactPhone) {
        _params.AddOpt("contact[phone]", contactPhone);
        return this;
      }
      public UpdateContactRequest ContactLabel(string contactLabel) {
        _params.AddOpt("contact[label]", contactLabel);
        return this;
      }
      public UpdateContactRequest ContactEnabled(bool contactEnabled) {
        _params.AddOpt("contact[enabled]", contactEnabled);
        return this;
      }
      public UpdateContactRequest ContactSendBillingEmail(bool contactSendBillingEmail) {
        _params.AddOpt("contact[send_billing_email]", contactSendBillingEmail);
        return this;
      }
      public UpdateContactRequest ContactSendAccountEmail(bool contactSendAccountEmail) {
        _params.AddOpt("contact[send_account_email]", contactSendAccountEmail);
        return this;
      }
    }

    public class DeleteContactRequest : EntityRequest<DeleteContactRequest> {
      public DeleteContactRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public DeleteContactRequest ContactId(string contactId) {
        _params.Add("contact[id]", contactId);
        return this;
      }
    }

    public class AddPromotionalCreditsRequest : EntityRequest<AddPromotionalCreditsRequest> {
      public AddPromotionalCreditsRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public AddPromotionalCreditsRequest Amount(int amount) {
        _params.Add("amount", amount);
        return this;
      }
      public AddPromotionalCreditsRequest CurrencyCode(string currencyCode) {
        _params.AddOpt("currency_code", currencyCode);
        return this;
      }
      public AddPromotionalCreditsRequest Description(string description) {
        _params.Add("description", description);
        return this;
      }
    }

    public class DeductPromotionalCreditsRequest : EntityRequest<DeductPromotionalCreditsRequest> {
      public DeductPromotionalCreditsRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public DeductPromotionalCreditsRequest Amount(int amount) {
        _params.Add("amount", amount);
        return this;
      }
      public DeductPromotionalCreditsRequest CurrencyCode(string currencyCode) {
        _params.AddOpt("currency_code", currencyCode);
        return this;
      }
      public DeductPromotionalCreditsRequest Description(string description) {
        _params.Add("description", description);
        return this;
      }
    }

    public class SetPromotionalCreditsRequest : EntityRequest<SetPromotionalCreditsRequest> {
      public SetPromotionalCreditsRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public SetPromotionalCreditsRequest Amount(int amount) {
        _params.Add("amount", amount);
        return this;
      }
      public SetPromotionalCreditsRequest CurrencyCode(string currencyCode) {
        _params.AddOpt("currency_code", currencyCode);
        return this;
      }
      public SetPromotionalCreditsRequest Description(string description) {
        _params.Add("description", description);
        return this;
      }
    }

    public class RecordExcessPaymentRequest : EntityRequest<RecordExcessPaymentRequest> {
      public RecordExcessPaymentRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public RecordExcessPaymentRequest Comment(string comment) {
        _params.AddOpt("comment", comment);
        return this;
      }
      public RecordExcessPaymentRequest TransactionAmount(int transactionAmount) {
        _params.Add("transaction[amount]", transactionAmount);
        return this;
      }
      public RecordExcessPaymentRequest TransactionCurrencyCode(string transactionCurrencyCode) {
        _params.AddOpt("transaction[currency_code]", transactionCurrencyCode);
        return this;
      }
      public RecordExcessPaymentRequest TransactionDate(long transactionDate) {
        _params.Add("transaction[date]", transactionDate);
        return this;
      }
      public RecordExcessPaymentRequest TransactionPaymentMethod(ChargeBee.Models.Enums.PaymentMethodEnum transactionPaymentMethod) {
        _params.Add("transaction[payment_method]", transactionPaymentMethod);
        return this;
      }
      public RecordExcessPaymentRequest TransactionReferenceNumber(string transactionReferenceNumber) {
        _params.AddOpt("transaction[reference_number]", transactionReferenceNumber);
        return this;
      }
    }

    public class DeleteRequest : EntityRequest<DeleteRequest> {
      public DeleteRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public DeleteRequest DeletePaymentMethod(bool deletePaymentMethod) {
        _params.AddOpt("delete_payment_method", deletePaymentMethod);
        return this;
      }
    }

    public enum FraudFlagEnum {
      Unknown,
      [Description("safe")]
      Safe,
      [Description("suspicious")]
      Suspicious,
      [Description("fraudulent")]
      Fraudulent,
    }

    public class CustomerBillingAddress : Resource {
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

    public class CustomerContact : Resource {
      public string Id() {
        return GetValue<string>("id", true);
      }

      public string FirstName() {
        return GetValue<string>("first_name", false);
      }

      public string LastName() {
        return GetValue<string>("last_name", false);
      }

      public string Email() {
        return GetValue<string>("email", true);
      }

      public string Phone() {
        return GetValue<string>("phone", false);
      }

      public string Label() {
        return GetValue<string>("label", false);
      }

      public bool Enabled() {
        return GetValue<bool>("enabled", true);
      }

      public bool SendAccountEmail() {
        return GetValue<bool>("send_account_email", true);
      }

      public bool SendBillingEmail() {
        return GetValue<bool>("send_billing_email", true);
      }
    }

    public class CustomerPaymentMethod : Resource {
      public enum TypeEnum {
        Unknown,
        [Description("card")]
        Card,
        [Description("paypal_express_checkout")]
        PaypalExpressCheckout,
        [Description("amazon_payments")]
        AmazonPayments,
        [Description("direct_debit")]
        DirectDebit,
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

      public TypeEnum PaymentMethodType() {
        return GetEnum<TypeEnum>("type", true);
      }

      public GatewayEnum Gateway() {
        return GetEnum<GatewayEnum>("gateway", true);
      }

      public string GatewayAccountId() {
        return GetValue<string>("gateway_account_id", false);
      }

      public StatusEnum Status() {
        return GetEnum<StatusEnum>("status", true);
      }

      public string ReferenceId() {
        return GetValue<string>("reference_id", false);
      }
    }
  }
}
