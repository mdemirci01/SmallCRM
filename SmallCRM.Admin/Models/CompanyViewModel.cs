using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class CompanyViewModel
    {
        [Display(Name ="Aktif Mi?")]
        public bool IsActive { get; set; }
        public Guid Id { get; set; }

        [Display(Name = "Firma Kayıt Sahibi")]
        [MaxLength(100)]
        public string Owner { get; set; }

        [Display(Name="Firma Konumu")]
        [MaxLength(100)]
        public string CompanyLocation { get; set; }

        [Required]
        [Display(Name ="Firma Adı")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name="Ana Firma")]
        public Guid? MainCompanyId { get; set; }

   
        [Display(Name = "Firma Numarası")]
        [MaxLength(20)]
        public string CompanyNumber { get; set; }

        [Display(Name = "Firma Türü")]
        public Guid? CompanyTypeId { get; set; }

        [Display(Name = "Sektör")]
        public Guid? SectorId { get; set; }

        [Display(Name = "Yıllık Gelir")]
        public decimal AnnualIncome { get; set; }

        [Display(Name = "Derece")]
        public Stage? Stage { get; set; }

     
        [Display(Name = "Telefon")]
        [MaxLength(20)]
        public string Telephone { get; set; }

        [Display(Name = "Fax")]
        [MaxLength(20)]
        public string Fax { get; set; }

       
        [Display(Name = "Web Sitesi")]
        [MaxLength(50)]
        public string Website { get; set; }

   
        [Display(Name = "İMKB Kodu")]
        [MaxLength(50)]
        public string ImkbCode { get; set; }


        [Display(Name ="Sahiplik")]
        public Ownership? OwnerShip { get; set; }



        [Display(Name = "NACE Kodu")]
        [MaxLength(50)]
        public string NaceCode { get; set; }
       
        //ADRES BİLGİLERİ
        //Fatura Bilgisi-INVOICE


   
        [Display(Name = "Fatura Adresi")]
        [MaxLength(500)]
        public string InvoiceAddress { get; set; }



        [Display(Name = "Fatura Şehir")]
        public Guid? InvoiceCityId { get; set; }

        [Display(Name = "Fatura İlçe")]
        public Guid? InvoiceRegionId { get; set; }


        [Display(Name = "Fatura Posta Kodu")]
        [MaxLength(50)]
        public string InvoicePostalCode { get; set; }

        [Display(Name = "Fatura Ülke")]
        public Guid? InvoiceCountryId { get; set; }
        //Teslimat Bilgisi-DELIVERY


        [Display(Name = "Sevkiyat Adresi - Cadde")]
        [MaxLength(500)]
        public string DeliveryAddress { get; set; }

        [Display(Name = "Teslimat Şehir")]
        public Guid? DeliveryCityId { get; set; }

        [Display(Name = "Teslimat İlçe")]
        public Guid? DeliveryRegionId { get; set; }

        [Display(Name = "Teslimat Posta Kodu")]
        [MaxLength(50)]
        public string DeliveryPostalCode { get; set; }


        [Display(Name = "Teslimat Ülke")]
        public Guid? DeliveryCountryId { get; set; }

        [Display(Name = "Açıklama")]
        [MaxLength(4000)]
        public string Description { get; set; }

        public string CompanyTypeName { get; set; }
        public string DeliveryCityName { get; set; }
        public string DeliveryCountryName { get; set; }
        public string DeliveryRegionName { get; set; }
        public string InvoiceCityName { get; set; }
        public string InvoiceCountryName { get; set; }
        public string InvoiceRegionName { get; set; }
        public string MainCompanyOwner { get; set; }
        public string SectorName { get; set; }

    }
}