namespace RealArtists.ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum TypeEnum {
    /// <summary>
    /// Indicates unexpected value for this enum. You can get this when there is a
    /// dotnet-client version incompatibility. We suggest you to upgrade to the latest version
    /// </summary>
    [Description("Unexpected Value")]
    Unknown,

    [Description("card")]
    Card,

    [Description("paypal_express_checkout")]
    PaypalExpressCheckout,

    [Description("amazon_payments")]
    AmazonPayments,

    [Description("direct_debit")]
    DirectDebit,

    [Description("generic")]
    Generic,

    [Description("alipay")]
    Alipay,

    [Description("unionpay")]
    Unionpay,
  }
}
