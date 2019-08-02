using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data.Builders
{
    public class LeadBuilder
    {
        public LeadBuilder(EntityTypeConfiguration<Lead> builder)
        {
            builder.Property(b => b.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.Company).HasMaxLength(100).IsRequired();
            builder.HasOptional(p => p.LeadSource).WithMany(w => w.Leads).HasForeignKey(p => p.LeadSourceId);
            builder.HasOptional(p => p.Sector).WithMany(w => w.Leads).HasForeignKey(p => p.SectorId);
            builder.HasOptional(p => p.LeadStatus).WithMany(w => w.Leads).HasForeignKey(p => p.LeadStatusId);
            builder.HasOptional(p => p.Country).WithMany(w => w.Leads).HasForeignKey(p => p.CountryId);
            builder.HasOptional(p => p.City).WithMany(w => w.Leads).HasForeignKey(p => p.CityId);
            builder.HasOptional(p => p.Region).WithMany(w => w.Leads).HasForeignKey(p => p.RegionId);

        }
    }
}
