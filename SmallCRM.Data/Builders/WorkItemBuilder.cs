using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data.Builders
{
    public class WorkItemBuilder
    {
        public WorkItemBuilder(EntityTypeConfiguration<WorkItem> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Description);
            builder.Property(b => b.AssignedTo).HasMaxLength(100);
            builder.Property(b => b.Category).HasMaxLength(100);
           
            builder.HasRequired(p => p.Project).WithMany(w => w.WorkItems).HasForeignKey(p => p.ProjectId);            
        }
    }
}
