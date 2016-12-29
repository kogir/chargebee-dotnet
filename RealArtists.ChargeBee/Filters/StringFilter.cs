namespace RealArtists.ChargeBee {
  using System;
  using RealArtists.ChargeBee.Api;

  public class StringFilter<U> where U : ListRequestBase<U> {
    private U req;
    private string paramName;
    private bool supportsMultiOperator;
    private bool supportsPresenceOperator;

    public StringFilter(string paramName, U req) {
      this.paramName = paramName;
      this.req = req;
      supportsPresenceOperator = true;
    }

    public StringFilter<U> SupportsPresenceOperator(bool supportsPresenceOperators) {
      supportsPresenceOperator = supportsPresenceOperators;
      return this;
    }

    public StringFilter<U> SupportsMultiOperators(bool supportsMultiOperators) {
      supportsMultiOperator = supportsMultiOperators;
      return this;
    }

    public U Is(string value) {
      req.Params().AddOpt(paramName + "[is]", value);
      return req;
    }


    public U IsNot(string value) {
      req.Params().AddOpt(paramName + "[is_not]", value);
      return req;
    }

    public U StartsWith(string value) {
      req.Params().AddOpt(paramName + "[starts_with]", value);
      return req;
    }

    public U IsPresent(bool value) {
      if (!supportsPresenceOperator) {
        throw new NotSupportedException("operator '[is_present]' is not supported for this filter-parameter");
      }
      req.Params().AddOpt(paramName + "[is_present]", value);
      return req;
    }

    public U In(params string[] value) {
      if (!supportsMultiOperator) {
        throw new NotSupportedException("operator '[in]' is not supported for this filter-parameter");
      }

      req.Params().AddOpt(paramName + "[in]", value);
      return req;
    }

    public U NotIn(params string[] value) {
      if (!supportsMultiOperator) {
        throw new NotSupportedException("operator '[not_in]' is not supported for this filter-parameter");
      }
      req.Params().AddOpt(paramName + "[not_in]", value);
      return req;
    }
  }
}

