using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data.Builders
{
    public class LeadSourceBuilder
    {
        public LeadSourceBuilder(EntityTypeConfiguration<LeadSource> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            
        }

    }
}
