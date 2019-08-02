using Microsoft.AspNet.Identity.EntityFramework;
using SmallCRM.Data.Builders;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<CampaignSource> CampaignSources { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyType> CompanyTypes { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Feed> Feeds { get; set; }
        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<LeadSource> LeadSources { get; set; }
        public virtual DbSet<LeadStatus> LeadStatuses { get; set; }
        public virtual DbSet<Opportunity> Opportunities { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<TimeSpending> TimeSpendings { get; set; }
        public virtual DbSet<WorkItem> WorkItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ActivityBuilder(modelBuilder.Entity<Activity>());
            new CampaignBuilder(modelBuilder.Entity<Campaign>());
            new CampaignSourceBuilder(modelBuilder.Entity<CampaignSource>());
            new CityBuilder(modelBuilder.Entity<City>());
            new CompanyBuilder(modelBuilder.Entity<Company>());
            new CompanyTypeBuilder(modelBuilder.Entity<CompanyType>());
            new ContactBuilder(modelBuilder.Entity<Contact>());
            new CountryBuilder(modelBuilder.Entity<Country>());
            new DocumentBuilder(modelBuilder.Entity<Document>());
            new FeedBuilder(modelBuilder.Entity<Feed>());
            new LeadBuilder(modelBuilder.Entity<Lead>());
            new LeadSourceBuilder(modelBuilder.Entity<LeadSource>());
            new LeadStatusBuilder(modelBuilder.Entity<LeadStatus>());
            new OpportunityBuilder(modelBuilder.Entity<Opportunity>());
            new ProjectBuilder(modelBuilder.Entity<Project>());
            new RegionBuilder(modelBuilder.Entity<Region>());
            new ReportBuilder(modelBuilder.Entity<Report>());
            new SectorBuilder(modelBuilder.Entity<Sector>());
            new TimeSpendingBuilder(modelBuilder.Entity<TimeSpending>());
            new WorkItemBuilder(modelBuilder.Entity<WorkItem>());
        }
    }
}
