using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data.Builders
{
    public class FeedBuilder
    {
        public FeedBuilder(EntityTypeConfiguration<Feed> builder)
        {
            builder.Property(b => b.Message).HasMaxLength(4000).IsRequired();
            builder.HasOptional(a => a.Document).WithMany(b => b.Feeds).HasForeignKey(a => a.DocumentId);
            builder.Property(b => b.TargetUser).HasMaxLength(100).IsRequired();

        }
    }
}
