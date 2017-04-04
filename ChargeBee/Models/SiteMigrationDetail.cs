namespace RealArtists.ChargeBee.Models {
  using System;
  using System.ComponentModel;
  using RealArtists.ChargeBee.Api;
  using RealArtists.ChargeBee.Internal;
  using RealArtists.ChargeBee.Models.Enums;

  public class SiteMigrationDetailActions : ApiResourceActions {
    public SiteMigrationDetailActions(ChargeBeeApi api) : base(api) { }

    public SiteMigrationDetail.SiteMigrationDetailListRequest List() {
      string url = BuildUrl("site_migration_details");
      return new SiteMigrationDetail.SiteMigrationDetailListRequest(Api, url);
    }
  }

  public class SiteMigrationDetail : Resource {
    public string EntityId {
      get { return GetValue<string>("entity_id", true); }
    }
    public string OtherSiteName {
      get { return GetValue<string>("other_site_name", true); }
    }
    public string EntityIdAtOtherSite {
      get { return GetValue<string>("entity_id_at_other_site", true); }
    }
    public DateTime MigratedAt {
      get { return (DateTime)GetDateTime("migrated_at", true); }
    }
    public EntityTypeEnum EntityType {
      get { return GetEnum<EntityTypeEnum>("entity_type", true); }
    }
    public StatusEnum Status {
      get { return GetEnum<StatusEnum>("status", true); }
    }

    public class SiteMigrationDetailListRequest : ListRequestBase<SiteMigrationDetailListRequest> {
      public SiteMigrationDetailListRequest(ChargeBeeApi api, string url)
              : base(api, url) {
      }

      public StringFilter<SiteMigrationDetailListRequest> EntityIdAtOtherSite() {
        return new StringFilter<SiteMigrationDetailListRequest>("entity_id_at_other_site", this);
      }
      public StringFilter<SiteMigrationDetailListRequest> OtherSiteName() {
        return new StringFilter<SiteMigrationDetailListRequest>("other_site_name", this);
      }
      public StringFilter<SiteMigrationDetailListRequest> EntityId() {
        return new StringFilter<SiteMigrationDetailListRequest>("entity_id", this);
      }
      public EnumFilter<EntityTypeEnum, SiteMigrationDetailListRequest> EntityType() {
        return new EnumFilter<EntityTypeEnum, SiteMigrationDetailListRequest>("entity_type", this);
      }
      public EnumFilter<StatusEnum, SiteMigrationDetailListRequest> Status() {
        return new EnumFilter<StatusEnum, SiteMigrationDetailListRequest>("status", this);
      }
    }

    public enum StatusEnum {
      Unknown,
      [Description("moved_in")]
      MovedIn,
      [Description("moved_out")]
      MovedOut,
      [Description("moving_out")]
      MovingOut,

    }
  }
}
