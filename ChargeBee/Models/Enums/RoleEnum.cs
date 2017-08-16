namespace RealArtists.ChargeBee.Models.Enums {
  using System.ComponentModel;

  public enum RoleEnum {
    Unknown,

    [Description("primary")]
    Primary,

    [Description("backup")]
    Backup,

    [Description("none")]
    None,
  }
}
