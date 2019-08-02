using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data.Builders
{
    public class RegionBuilder
    {
        public RegionBuilder(EntityTypeConfiguration<Region> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();
        }
    }
}
