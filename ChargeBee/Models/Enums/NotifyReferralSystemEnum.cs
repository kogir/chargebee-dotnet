namespace RealArtists.ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum NotifyReferralSystemEnum {
    Unknown,

    [Description("none")]
    None,

    [Description("first_paid_conversion")]
    FirstPaidConversion,

    [Description("all_invoices")]
    AllInvoices,
  }
}
