namespace RealArtists.ChargeBee {
  using System;
  using RealArtists.ChargeBee.Api;

  public class BooleanFilter<U> where U : ListRequestBase<U> {
    private U req;
    private string paramName;
    private bool supportsPresenceOperator;

    public BooleanFilter(string paramName, U req) {
      this.paramName = paramName;
      this.req = req;
    }

    public U Is(bool value) {
      req.Params().AddOpt(paramName + "[is]", value);
      return req;
    }

    public BooleanFilter<U> SupportsPresenceOperator(bool supportsPresenceOperator) {
      this.supportsPresenceOperator = supportsPresenceOperator;
      return this;
    }

    public U IsPresent(bool value) {
      if (!supportsPresenceOperator) {
        throw new NotSupportedException("operator '[is_present]' is not supported for this filter-parameter");
      }
      req.Params().AddOpt(paramName + "[is_present]", value);
      return req;
    }
  }
}
