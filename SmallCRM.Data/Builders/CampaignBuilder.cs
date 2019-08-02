using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data.Builders
{
    public class CampaignBuilder
    {
        public CampaignBuilder(EntityTypeConfiguration<Campaign> builder)
        {
            builder.Property(b => b.Owner).HasMaxLength(100);
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();            
            builder.Property(b => b.ExpectedResponse).HasMaxLength(100);
            builder.Property(b => b.Description).HasMaxLength(4000);
        }
    }
}
