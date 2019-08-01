using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data.Builders
{
    public class CampaignSourceBuilder
    {
        public CampaignSourceBuilder(EntityTypeConfiguration<CampaignSourceBuilder> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();

        }
    }
}
