namespace RealArtists.ChargeBee.Models {
  using System;
  using System.ComponentModel;
  using System.Net.Http;
  using RealArtists.ChargeBee.Api;
  using RealArtists.ChargeBee.Internal;

  public class TimeMachineActions : ApiResourceActions {
    public TimeMachineActions(ChargeBeeApi api) : base(api) { }

    public EntityRequest<Type> Retrieve(string id) {
      string url = BuildUrl("time_machines", id);
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }
    public TimeMachine.StartAfreshRequest StartAfresh(string id) {
      string url = BuildUrl("time_machines", id, "start_afresh");
      return new TimeMachine.StartAfreshRequest(Api, url, HttpMethod.Post);
    }
    public TimeMachine.TravelForwardRequest TravelForward(string id) {
      string url = BuildUrl("time_machines", id, "travel_forward");
      return new TimeMachine.TravelForwardRequest(Api, url, HttpMethod.Post);
    }
  }

  public class TimeMachine : Resource {
    public string Name {
      get { return GetValue<string>("name", true); }
    }
    public TimeTravelStatusEnum TimeTravelStatus {
      get { return GetEnum<TimeTravelStatusEnum>("time_travel_status", true); }
    }
    public DateTime GenesisTime {
      get { return (DateTime)GetDateTime("genesis_time", true); }
    }
    public DateTime DestinationTime {
      get { return (DateTime)GetDateTime("destination_time", true); }
    }
    public string FailureCode {
      get { return GetValue<string>("failure_code", false); }
    }
    public string FailureReason {
      get { return GetValue<string>("failure_reason", false); }
    }
    public string ErrorJson {
      get { return GetValue<string>("error_json", false); }
    }

    //public TimeMachine WaitForTimeTravelCompletion() {
    //  return WaitForTimeTravelCompletion(null);
    //}

    //public TimeMachine WaitForTimeTravelCompletion(ApiConfig config) {
    //  int count = 0;
    //  int sleepTime = System.Environment.GetEnvironmentVariable("cb.dotnet.time_travel.sleep.millis") != null
    //      ? Convert.ToInt32(System.Environment.GetEnvironmentVariable("cb.dotnet.time_travel.sleep.millis"))
    //      : 3000;
    //  while (this.TimeTravelStatus == TimeTravelStatusEnum.InProgress) {
    //    if (count++ > 30) {
    //      throw new SystemException("Time travel is taking too much time");
    //    }
    //    Thread.Sleep(sleepTime);
    //    EntityRequest<Type> req = Retrieve(this.Name);
    //    this.JObj = ((config == null) ? req.Request() : req.Request(config)).TimeMachine.JObj;
    //  }
    //  if (this.TimeTravelStatus == TimeTravelStatusEnum.Failed) {
    //    Dictionary<String, String> errorJson = JsonConvert.DeserializeObject<Dictionary<String, String>>(this.ErrorJson
    //    );
    //    HttpStatusCode httpStatusCode = (HttpStatusCode)Convert.ToInt32(errorJson["http_code"]);
    //    throw new Exceptions.OperationFailedException(httpStatusCode, errorJson);
    //  }
    //  if (this.TimeTravelStatus == TimeTravelStatusEnum.NotEnabled || this.TimeTravelStatus == TimeTravelStatusEnum.Unknown) {
    //    throw new SystemException("Time travel is in wrong state : " + this.TimeTravelStatus);
    //  }
    //  return this;
    //}

    public class StartAfreshRequest : EntityRequest<StartAfreshRequest> {
      public StartAfreshRequest(ChargeBeeApi api, string url, HttpMethod method)
            : base(api, url, method) {
      }

      public StartAfreshRequest GenesisTime(long genesisTime) {
        _params.AddOpt("genesis_time", genesisTime);
        return this;
      }
    }

    public class TravelForwardRequest : EntityRequest<TravelForwardRequest> {
      public TravelForwardRequest(ChargeBeeApi api, string url, HttpMethod method)
            : base(api, url, method) {
      }

      public TravelForwardRequest DestinationTime(long destinationTime) {
        _params.AddOpt("destination_time", destinationTime);
        return this;
      }
    }

    public enum TimeTravelStatusEnum {
      Unknown,
      [Description("not_enabled")]
      NotEnabled,
      [Description("in_progress")]
      InProgress,
      [Description("succeeded")]
      Succeeded,
      [Description("failed")]
      Failed,

    }
  }
}
