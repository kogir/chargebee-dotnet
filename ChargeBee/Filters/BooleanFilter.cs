namespace ChargeBee {
  using ChargeBee.Api;

  public class BooleanFilter<U> where U : ListRequestBase<U> {
    private U req;
    private string paramName;

    public BooleanFilter(string paramName, U req) {
      this.paramName = paramName;
      this.req = req;
    }

    public U Is(bool value) {
      req.Params().AddOpt(paramName + "[is]", value);
      return req;
    }
  }
}
