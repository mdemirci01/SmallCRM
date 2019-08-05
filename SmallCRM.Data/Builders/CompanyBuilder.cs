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


            builder.Property(a => a.Location).HasMaxLength(100);
            builder.Property(a => a.Owner).HasMaxLength(100);
            builder.Property(a => a.CompanyNumber).HasMaxLength(20);
            builder.Property(a => a.Telephone).HasMaxLength(20);
            builder.Property(a => a.Fax).HasMaxLength(20);
            builder.Property(a => a.Website).HasMaxLength(50);
            builder.Property(a => a.ImkbCode).HasMaxLength(50);
            builder.Property(a => a.NaceCode).HasMaxLength(50);
            builder.Property(a => a.DeliveryAddress).HasMaxLength(500);
            builder.Property(a => a.DeliveryPostalCode).HasMaxLength(50);
            builder.Property(a => a.InvoiceAddress).HasMaxLength(500);
            builder.Property(a => a.InvoicePostalCode).HasMaxLength(50);
            builder.Property(a => a.Description).HasMaxLength(4000);
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();



            builder.HasOptional(a => a.MainCompany).WithMany(b => b.ChildCompanies).HasForeignKey(a => a.MainCompanyId);
            builder.HasOptional(a => a.CompanyType).WithMany(b => b.Companies).HasForeignKey(a => a.CompanyTypeId);
            builder.HasOptional(a => a.Sector).WithMany(b => b.Companies).HasForeignKey(a => a.SectorId);

            builder.HasOptional(a => a.InvoiceCity).WithMany(b => b.InvoiceCompanies).HasForeignKey(a => a.InvoiceCityId);
            builder.HasOptional(a => a.InvoiceRegion).WithMany(b => b.InvoiceCompanies).HasForeignKey(a=>a.InvoiceRegionId);
            builder.HasOptional(a => a.InvoiceCountry).WithMany(b => b.InvoiceCompanies).HasForeignKey(a => a.InvoiceCountryId);

            builder.HasOptional(a => a.DeliveryCity).WithMany(b => b.DeliveryCompanies).HasForeignKey(a =>a.DeliveryCityId);
            builder.HasOptional(a => a.DeliveryRegion).WithMany(b => b.DeliveryCompanies).HasForeignKey(a =>a.DeliveryRegionId);
            builder.HasOptional(a => a.DeliveryCountry).WithMany(b => b.DeliveryCompanies).HasForeignKey(a =>a.DeliveryCountryId);

        }
    }
}
