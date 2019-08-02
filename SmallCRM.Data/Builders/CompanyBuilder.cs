using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Data.Builders
{
    public class CompanyBuilder
    {
        public CompanyBuilder(EntityTypeConfiguration<Company> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();
            builder.HasOptional(a => a.MainCompany).WithMany(b => b.ChildCompanies).HasForeignKey(a => a.MainCompanyId);
            builder.HasOptional(a => a.CompanyType).WithMany(b => b.Companies).HasForeignKey(a => a.CompanyTypeId);
            builder.HasOptional(a => a.Sector).WithMany(b => b.Companies).HasForeignKey(a => a.SectorId);

            builder.HasOptional(a => a.InvoiceCity).WithMany(b => b.InvoiceCompanies).HasForeignKey(a => a.InvoiceCityId);
            builder.HasOptional(a => a.InvoiceRegion).WithMany(b => b.InvoiceCompanies).HasForeignKey(a=>a.InvoiceRegionId);
            builder.HasOptional(a => a.InvoiceCountry).WithMany(b => b.InvoiceCountries).HasForeignKey(a => a.InvoiceCountryId);

            builder.HasOptional(a => a.DeliveryCity).WithMany(b => b.DeliveryCompanies).HasForeignKey(a =>a.DeliveryCityId);
            builder.HasOptional(a => a.DeliveryRegion).WithMany(b => b.DeliveryCompanies).HasForeignKey(a =>a.DeliveryRegionId);
            builder.HasOptional(a => a.DeliveryCountry).WithMany(b => b.InvoiceCountries).HasForeignKey(a =>a.DeliveryCountryId);

        }
    }
}
