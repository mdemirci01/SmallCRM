using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data.Builders
{
    public class TimeSpendingBuilder
    {
        public TimeSpendingBuilder(EntityTypeConfiguration<TimeSpending> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.HasRequired(a => a.Project).WithMany(b => b.TimeSpendings).HasForeignKey(a => a.ProjectId);
            builder.HasOptional(a => a.WorkItem).WithMany(b => b.TimeSpendings).HasForeignKey(a => a.WorkItemId);
            builder.Property(b => b.Worker).HasMaxLength(100).IsRequired();
        }
    }
}
