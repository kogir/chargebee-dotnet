namespace RealArtists.ChargeBee.Models {
  using RealArtists.ChargeBee.Internal;
  using RealArtists.ChargeBee.Models.Enums;

  public class ThirdPartyPaymentMethod : Resource {
    public TypeEnum ThirdPartyPaymentMethodType {
      get { return GetEnum<TypeEnum>("type", true); }
    }
    public GatewayEnum Gateway {
      get { return GetEnum<GatewayEnum>("gateway", true); }
    }
    public string ReferenceId {
      get { return GetValue<string>("reference_id", false); }
    }
  }
}
