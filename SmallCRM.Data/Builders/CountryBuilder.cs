using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace SmallCRM.Data.Builders
{
    class CountryBuilder
    {
        public CountryBuilder(EntityTypeConfiguration<Country> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();
        }
    }
}
