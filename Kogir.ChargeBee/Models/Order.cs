namespace Kogir.ChargeBee.Models {
  using System;
  using System.ComponentModel;
  using System.Net.Http;
  using Kogir.ChargeBee.Api;
  using Kogir.ChargeBee.Filters.Enums;
  using Kogir.ChargeBee.Internal;

  public class OrderActions : ApiResourceActions {
    public OrderActions(ChargeBeeApi api) : base(api) { }

    public Order.CreateRequest Create() {
      string url = BuildUrl("orders");
      return new Order.CreateRequest(Api, url, HttpMethod.Post);
    }
    public Order.UpdateRequest Update(string id) {
      string url = BuildUrl("orders", id);
      return new Order.UpdateRequest(Api, url, HttpMethod.Post);
    }
    public EntityRequest<Type> Retrieve(string id) {
      string url = BuildUrl("orders", id);
      return new EntityRequest<Type>(Api, url, HttpMethod.Get);
    }
    public Order.OrderListRequest List() {
      string url = BuildUrl("orders");
      return new Order.OrderListRequest(Api, url);
    }
  }

  public class Order : Resource {
    public string Id {
      get { return GetValue<string>("id", true); }
    }
    public string InvoiceId {
      get { return GetValue<string>("invoice_id", true); }
    }
    public StatusEnum? Status {
      get { return GetEnum<StatusEnum>("status", false); }
    }
    public string ReferenceId {
      get { return GetValue<string>("reference_id", false); }
    }
    public string FulfillmentStatus {
      get { return GetValue<string>("fulfillment_status", false); }
    }
    public string Note {
      get { return GetValue<string>("note", false); }
    }
    public string TrackingId {
      get { return GetValue<string>("tracking_id", false); }
    }
    public string BatchId {
      get { return GetValue<string>("batch_id", false); }
    }
    public string CreatedBy {
      get { return GetValue<string>("created_by", false); }
    }
    public DateTime CreatedAt {
      get { return (DateTime)GetDateTime("created_at", true); }
    }
    public DateTime? StatusUpdateAt {
      get { return GetDateTime("status_update_at", false); }
    }

    public class CreateRequest : EntityRequest<CreateRequest> {
      public CreateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public CreateRequest Id(string id) {
        _params.AddOpt("id", id);
        return this;
      }
      public CreateRequest InvoiceId(string invoiceId) {
        _params.Add("invoice_id", invoiceId);
        return this;
      }
      public CreateRequest Status(StatusEnum status) {
        _params.AddOpt("status", status);
        return this;
      }
      public CreateRequest ReferenceId(string referenceId) {
        _params.AddOpt("reference_id", referenceId);
        return this;
      }
      public CreateRequest FulfillmentStatus(string fulfillmentStatus) {
        _params.AddOpt("fulfillment_status", fulfillmentStatus);
        return this;
      }
      public CreateRequest Note(string note) {
        _params.AddOpt("note", note);
        return this;
      }
      public CreateRequest TrackingId(string trackingId) {
        _params.AddOpt("tracking_id", trackingId);
        return this;
      }
      public CreateRequest BatchId(string batchId) {
        _params.AddOpt("batch_id", batchId);
        return this;
      }
    }

    public class UpdateRequest : EntityRequest<UpdateRequest> {
      public UpdateRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public UpdateRequest Status(StatusEnum status) {
        _params.AddOpt("status", status);
        return this;
      }
      public UpdateRequest ReferenceId(string referenceId) {
        _params.AddOpt("reference_id", referenceId);
        return this;
      }
      public UpdateRequest FulfillmentStatus(string fulfillmentStatus) {
        _params.AddOpt("fulfillment_status", fulfillmentStatus);
        return this;
      }
      public UpdateRequest Note(string note) {
        _params.AddOpt("note", note);
        return this;
      }
      public UpdateRequest TrackingId(string trackingId) {
        _params.AddOpt("tracking_id", trackingId);
        return this;
      }
      public UpdateRequest BatchId(string batchId) {
        _params.AddOpt("batch_id", batchId);
        return this;
      }
    }

    public class OrderListRequest : ListRequestBase<OrderListRequest> {
      public OrderListRequest(ChargeBeeApi api, string url)
              : base(api, url) {
      }

      public StringFilter<OrderListRequest> Id() {
        return new StringFilter<OrderListRequest>("id", this).SupportsMultiOperators(true);
      }
      public StringFilter<OrderListRequest> InvoiceId() {
        return new StringFilter<OrderListRequest>("invoice_id", this).SupportsMultiOperators(true);
      }
      public EnumFilter<StatusEnum, OrderListRequest> Status() {
        return new EnumFilter<StatusEnum, OrderListRequest>("status", this);
      }
      public TimestampFilter<OrderListRequest> CreatedAt() {
        return new TimestampFilter<OrderListRequest>("created_at", this);
      }
      public OrderListRequest SortByCreatedAt(SortOrderEnum order) {
        _params.AddOpt("sort_by[" + order.ToString().ToLower() + "]", "created_at");
        return this;
      }
    }

    public enum StatusEnum {
      Unknown,
      [Description("new")]
      New,
      [Description("processing")]
      Processing,
      [Description("complete")]
      Complete,
      [Description("cancelled")]
      Cancelled,
      [Description("voided")]
      Voided,
    }
  }
}
