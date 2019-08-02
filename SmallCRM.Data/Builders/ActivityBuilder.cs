using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data.Builders
{
    public class ActivityBuilder
    {
        public ActivityBuilder(EntityTypeConfiguration<Activity> builder)
        {
           
            builder.Property(b => b.Subject).HasMaxLength(100).IsRequired();
            builder.HasOptional(a => a.Contact).WithMany(b => b.Activities).HasForeignKey(a => a.ContactId);


            builder.Property(b => b.CompanyName).IsRequired();
            builder.HasOptional(a => a.Company).WithMany(b => b.Activities).HasForeignKey(a => a.CompanyId);

            builder.Property(b => b.OpportunityName).IsRequired();
            builder.Property(b => b.OpportunityCloseDate).IsRequired();
            builder.Property(b => b.OpportunityStage).IsRequired();
            builder.Property(b => b.OpportunityType).IsRequired();
            builder.Property(b => b.CampaignName).IsRequired();
            builder.HasOptional(a => a.Opportunity).WithMany(b => b.Activities).HasForeignKey(a => a.OpportunityId);
            builder.HasOptional(a => a.Campaign).WithMany(b => b.Activities).HasForeignKey(a => a.CampaignId);
        }
    }
}
