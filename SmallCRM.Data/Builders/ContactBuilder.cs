using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data.Builders
{
    public class ContactBuilder
    {
        public ContactBuilder(EntityTypeConfiguration<Contact> builder)
        {
            builder.Property(b => b.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.LastName).HasMaxLength(50);
            builder.HasOptional(a => a.Company).WithMany(b => b.Contacts).HasForeignKey(a => a.CompanyId);
            builder.HasOptional(a => a.LeadSource).WithMany(b => b.Contacts).HasForeignKey(a => a.LeadSourceId);
            builder.HasOptional(a => a.ReportsToContact).WithMany(b => b.ChildContacts).HasForeignKey(a => a.ReportsToContactId);
            builder.HasOptional(a => a.Country).WithMany(b => b.PostalContacts).HasForeignKey(a => a.CountryId);
            builder.HasOptional(a => a.City).WithMany(b => b.PostalContacts).HasForeignKey(a => a.CityId);
            builder.HasOptional(a => a.Region).WithMany(b => b.PostalContacts).HasForeignKey(a => a.RegionId);
            builder.HasOptional(a => a.OtherCountry).WithMany(b => b.OtherContacts).HasForeignKey(a => a.OtherCountryId);
            builder.HasOptional(a => a.OtherCity).WithMany(b => b.OtherContacts).HasForeignKey(a => a.OtherCityId);
            builder.HasOptional(a => a.OtherRegion).WithMany(b => b.OtherContacts).HasForeignKey(a => a.OtherRegionId);
            
           
            
           
        }
    }
}
