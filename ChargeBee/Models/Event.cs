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

    public static EventListRequest List() {
      string url = ApiUtil.BuildUrl("events");
      return new EventListRequest(url);
    }
    public static EntityRequest<Type> Retrieve(string id) {
      string url = ApiUtil.BuildUrl("events", CheckNull(id));
      return new EntityRequest<Type>(url, HttpMethod.Get);
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
    [Obsolete]
    public WebhookStatusEnum WebhookStatus {
      get { return GetEnum<WebhookStatusEnum>("webhook_status", true); }
    }
    [Obsolete]
    public string WebhookFailureReason {
      get { return GetValue<string>("webhook_failure_reason", false); }
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
      public EventListRequest(string url)
              : base(url) {
      }

      [Obsolete]
      public EventListRequest StartTime(long startTime) {
        m_params.AddOpt("start_time", startTime);
        return this;
      }
      [Obsolete]
      public EventListRequest EndTime(long endTime) {
        m_params.AddOpt("end_time", endTime);
        return this;
      }
      public StringFilter<EventListRequest> Id() {
        return new StringFilter<EventListRequest>("id", this).SupportsMultiOperators(true);
      }
      public EnumFilter<WebhookStatusEnum, EventListRequest> WebhookStatus() {
        return new EnumFilter<WebhookStatusEnum, EventListRequest>("webhook_status", this);
      }
      [Obsolete]
      public EventListRequest WebhookStatus(WebhookStatusEnum webhookStatus) {
        m_params.AddOpt("webhook_status", webhookStatus);
        return this;
      }
      public EnumFilter<EventTypeEnum, EventListRequest> EventType() {
        return new EnumFilter<EventTypeEnum, EventListRequest>("event_type", this);
      }
      [Obsolete]
      public EventListRequest EventType(EventTypeEnum eventType) {
        m_params.AddOpt("event_type", eventType);
        return this;
      }
      public EnumFilter<SourceEnum, EventListRequest> Source() {
        return new EnumFilter<SourceEnum, EventListRequest>("source", this);
      }
      public TimestampFilter<EventListRequest> OccurredAt() {
        return new TimestampFilter<EventListRequest>("occurred_at", this);
      }
      public EventListRequest SortByOccurredAt(SortOrderEnum order) {
        m_params.AddOpt("sort_by[" + order.ToString().ToLower() + "]", "occurred_at");
        return this;
      }
    }

    [Obsolete]
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
        m_jobj = jobj;
      }
    }
  }
}
