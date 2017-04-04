namespace RealArtists.ChargeBee.Models {
  using System;
  using System.ComponentModel;
  using System.Net.Http;
  using RealArtists.ChargeBee.Api;
  using RealArtists.ChargeBee.Internal;
  using RealArtists.ChargeBee.Models.Enums;

  public class ResourceMigrationActions : ApiResourceActions {
    public ResourceMigrationActions(ChargeBeeApi api) : base(api) { }

    public ResourceMigration.RetrieveLatestRequest RetrieveLatest() {
      string url = BuildUrl("resource_migrations", "retrieve_latest");
      return new ResourceMigration.RetrieveLatestRequest(Api, url, HttpMethod.Get);
    }
  }

  public class ResourceMigration : Resource {
    public string FromSite {
      get { return GetValue<string>("from_site", true); }
    }
    public EntityTypeEnum EntityType {
      get { return GetEnum<EntityTypeEnum>("entity_type", true); }
    }
    public string EntityId {
      get { return GetValue<string>("entity_id", true); }
    }
    public StatusEnum Status {
      get { return GetEnum<StatusEnum>("status", true); }
    }
    public string Errors {
      get { return GetValue<string>("errors", false); }
    }
    public DateTime CreatedAt {
      get { return (DateTime)GetDateTime("created_at", true); }
    }
    public DateTime UpdatedAt {
      get { return (DateTime)GetDateTime("updated_at", true); }
    }

    public class RetrieveLatestRequest : EntityRequest<RetrieveLatestRequest> {
      public RetrieveLatestRequest(ChargeBeeApi api, string url, HttpMethod method)
              : base(api, url, method) {
      }

      public RetrieveLatestRequest FromSite(string fromSite) {
        _params.Add("from_site", fromSite);
        return this;
      }
      public RetrieveLatestRequest EntityType(EntityTypeEnum entityType) {
        _params.Add("entity_type", entityType);
        return this;
      }
      public RetrieveLatestRequest EntityId(string entityId) {
        _params.Add("entity_id", entityId);
        return this;
      }
    }

    public enum StatusEnum {
      Unknown,
      [Description("scheduled")]
      Scheduled,
      [Description("failed")]
      Failed,
      [Description("succeeded")]
      Succeeded,
    }
  }
}
