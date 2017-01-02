namespace RealArtists.ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum GatewayEnum {
    /// <summary>
    /// Indicates unexpected value for this enum. You can get this when there is a
    /// dotnet-client version incompatibility. We suggest you to upgrade to the latest version
    /// </summary>
    [Description("Unexpected Value")]
    Unknown,

    [Description("chargebee")]
    Chargebee,

    [Description("stripe")]
    Stripe,

    [Description("wepay")]
    Wepay,

    [Description("braintree")]
    Braintree,

    [Description("authorize_net")]
    AuthorizeNet,

    [Description("paypal_pro")]
    PaypalPro,

    [Description("pin")]
    Pin,

    [Description("eway")]
    Eway,

    [Description("eway_rapid")]
    EwayRapid,

    [Description("worldpay")]
    Worldpay,

    [Description("balanced_payments")]
    BalancedPayments,

    [Description("beanstream")]
    Beanstream,

    [Description("bluepay")]
    Bluepay,

    [Description("elavon")]
    Elavon,

    [Description("first_data_global")]
    FirstDataGlobal,

    [Description("hdfc")]
    Hdfc,

    [Description("migs")]
    Migs,

    [Description("nmi")]
    Nmi,

    [Description("ogone")]
    Ogone,

    [Description("paymill")]
    Paymill,

    [Description("paypal_payflow_pro")]
    PaypalPayflowPro,

    [Description("sage_pay")]
    SagePay,

    [Description("tco")]
    Tco,

    [Description("wirecard")]
    Wirecard,

    [Description("gocardless")]
    Gocardless,

    [Description("not_applicable")]
    NotApplicable,
  }
}
