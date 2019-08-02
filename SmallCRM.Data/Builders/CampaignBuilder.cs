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
            builder.Property(b => b.Owner).HasMaxLength(50);
            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();            
            builder.Property(b => b.ExpectedResponse).HasMaxLength(30);
            builder.Property(b => b.Description).HasMaxLength(200);
        }
    }
}
