using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data.Builders
{
    public class OpportunityBuilder
    {
        public OpportunityBuilder(EntityTypeConfiguration<Opportunity> builder)
        {
            builder.Property(b => b.Owner).HasMaxLength(100);
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.HasRequired(a => a.Company).WithMany(b => b.Opportunities).HasForeignKey(a => a.CompanyId);
            builder.Property(b => b.NextStep).HasMaxLength(100);
            builder.HasOptional(b => b.LeadSource).WithMany(a => a.Opportunities).HasForeignKey(b => b.LeadSourceId);
            builder.HasOptional(b => b.Contact).WithMany(a => a.Opportunities).HasForeignKey(b => b.ContactId);
            builder.HasOptional(b => b.CampaignSource).WithMany(a => a.Opportunities).HasForeignKey(b => b.CampaignSourceId);
            builder.Property(b => b.Description).HasMaxLength(4000);
        }
    }
}
