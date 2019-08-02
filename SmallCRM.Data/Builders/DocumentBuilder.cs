using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data.Builders
{
    public class DocumentBuilder
    {
        public DocumentBuilder(EntityTypeConfiguration<Document> builder)
        {            
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.Property(b => b.File).HasMaxLength(200).IsRequired();
            builder.Property(b => b.Description).HasMaxLength(4000);
        }
    }
}
