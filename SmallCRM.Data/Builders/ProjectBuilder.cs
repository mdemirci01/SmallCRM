using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data.Builders
{
     public class ProjectBuilder
    {
        public ProjectBuilder(EntityTypeConfiguration<Project> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Description).HasMaxLength(4000);
            builder.Property(b => b.Managers).HasMaxLength(4000);
            builder.Property(b => b.BussinessAnalyists).HasMaxLength(4000);
            builder.Property(b => b.Developers).HasMaxLength(4000);
            
        }
    }
}
