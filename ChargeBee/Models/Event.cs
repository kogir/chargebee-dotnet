namespace ChargeBee.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.IO;
  using System.Net.Http;
  using ChargeBee.Api;
  using ChargeBee.Filters.Enums;
  using ChargeBee.Internal;
  using ChargeBee.Models.Enums;
  using Newtonsoft.Json.Linq;

  public class EventActions : ApiResourceActions {
    public EventActions(ChargeBeeApi api) : base(api) { }

    public Event.EventListRequest List() {
      string url = BuildUrl("events");
      return new Event.EventListRequest(Api, url);
    }

    public EntityRequest<Type> Retrieve(string id) {
      string url = BuildUrl("events", id);
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }
  }

  public class Event : Resource {
    public Event() { }

    public Event(Stream stream) {
      using (StreamReader reader = new StreamReader(stream)) {
        JObj = JToken.Parse(reader.ReadToEnd());
        apiVersionCheck(JObj);
      }
    }

    public Event(TextReader reader) {
      JObj = JToken.Parse(reader.ReadToEnd());
      apiVersionCheck(JObj);
    }

    public Event(string jsonString) {
      JObj = JToken.Parse(jsonString);
      apiVersionCheck(JObj);
    }

    public string Id {
      get { return GetValue<string>("id", true); }
    }
    public DateTime OccurredAt {
      get { return (DateTime)GetDateTime("occurred_at", true); }
    }
    public SourceEnum Source {
      get { return GetEnum<SourceEnum>("source", true); }
    }
    public string User {
      get { return GetValue<string>("user", false); }
    }
    public List<EventWebhook> Webhooks {
      get { return GetResourceList<EventWebhook>("webhooks"); }
    }
    public EventTypeEnum? EventType {
      get { return GetEnum<EventTypeEnum>("event_type", false); }
    }
    public ApiVersionEnum? ApiVersion {
      get { return GetEnum<ApiVersionEnum>("api_version", false); }
    }
    public EventContent Content {
      get { return new EventContent(GetValue<JToken>("content")); }
    }

    public class EventListRequest : ListRequestBase<EventListRequest> {
      public EventListRequest(ChargeBeeApi api, string url)
              : base(api, url) {
      }

      public StringFilter<EventListRequest> Id() {
        return new StringFilter<EventListRequest>("id", this).SupportsMultiOperators(true);
      }
      public EnumFilter<EventTypeEnum, EventListRequest> EventType() {
        return new EnumFilter<EventTypeEnum, EventListRequest>("event_type", this);
      }
      public EnumFilter<SourceEnum, EventListRequest> Source() {
        return new EnumFilter<SourceEnum, EventListRequest>("source", this);
      }
      public TimestampFilter<EventListRequest> OccurredAt() {
        return new TimestampFilter<EventListRequest>("occurred_at", this);
      }
      public EventListRequest SortByOccurredAt(SortOrderEnum order) {
        _params.AddOpt("sort_by[" + order.ToString().ToLower() + "]", "occurred_at");
        return this;
      }
    }

    public class EventWebhook : Resource {
      public enum WebhookStatusEnum {
        Unknown,
        [Description("not_configured")]
        NotConfigured,
        [Description("scheduled")]
        Scheduled,
        [Description("succeeded")]
        Succeeded,
        [Description("re_scheduled")]
        ReScheduled,
        [Description("failed")]
        Failed,
        [Description("skipped")]
        Skipped,
        [Description("not_applicable")]
        NotApplicable,
      }

      public string Id() {
        return GetValue<string>("id", true);
      }

      public WebhookStatusEnum WebhookStatus() {
        return GetEnum<WebhookStatusEnum>("webhook_status", true);
      }
    }

    public class EventContent : ResultBase {

      public EventContent() { }

      internal EventContent(JToken jobj) {
        _jobj = jobj;
      }
    }
  }
}
