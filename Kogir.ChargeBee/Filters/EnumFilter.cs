﻿namespace Kogir.ChargeBee {
  using System;
  using Kogir.ChargeBee.Api;

  public class EnumFilter<T, U> where U : ListRequestBase<U> {
    private U req;
    private string paramName;
    private bool supportsPresenceOperator;

    public EnumFilter(string paramName, U req) {
      this.paramName = paramName;
      this.req = req;
    }

    public EnumFilter<T, U> SupportsPresenceOperator(bool supportsPresenceOperator) {
      this.supportsPresenceOperator = supportsPresenceOperator;
      return this;
    }

    public U Is(T value) {
      req.Params().AddOpt(paramName + "[is]", value);
      return req;
    }

    public U IsNot(T value) {
      req.Params().AddOpt(paramName + "[is_not]", value);
      return req;
    }

    public U In(params T[] value) {
      req.Params().AddOpt(paramName + "[in]", value);
      return req;
    }

    public U NotIn(params T[] value) {
      req.Params().AddOpt(paramName + "[not_in]", value);
      return req;
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
