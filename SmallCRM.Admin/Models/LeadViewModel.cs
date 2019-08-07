using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class LeadViewModel
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        [Display(Name = "Sahip")]
        public string Owner { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Ad")]
        public string FirstName { get; set; } // required
        [MaxLength(50)]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [Display(Name = "Tam Ad")]
        public string FullName { get; set; }
        [MaxLength(100)]
        [Display(Name = "Firma")]
        public string Company { get; set; } // required
        [Display(Name = "Nezaket Ünvanı")]
        public TitleOfCourtesy? TitleOfCourtesy { get; set; }
        [Display(Name = "Cinsiyet")]
        public Gender? Gender { get; set; }
        [MaxLength(100)]
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [DataType(DataType.PhoneNumber)]
        [MaxLength(20)]
        [Display(Name = "Telefon")]
        public string Telephone { get; set; }
        [DataType(DataType.PhoneNumber)]
        [MaxLength(20)]
        [Display(Name = "Cep Telefonu")]
        public string MobilePhone { get; set; }
        [MaxLength(100)]
        [Display(Name = "Eposta")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [MaxLength(20)]
        [Display(Name = "Faks")]
        public string Fax { get; set; }
        [Display(Name = "Müşteri Adı Kaynağı")]
        public Guid? LeadSourceId { get; set; }
        [Display(Name = "Sektör")]
        public Guid? SectorId { get; set; }
        [Display(Name = "Eposta Gönderilmesin")]
        public bool NotSendEmail { get; set; }
        [Display(Name = "Sms Gönderilmesin")]
        public bool NotSendSms { get; set; }
        [MaxLength(100)]
        [Display(Name = "Web Sitesi")]
        public string Website { get; set; }
        [Display(Name = "Durum")]
        public Guid? LeadStatusId { get; set; }
        [Display(Name ="Aşama")]
        public Stage? Stage { get; set; }
        [MaxLength(100)]
        [Display(Name = "Skype")]
        public string SkypeId { get; set; }
        [MaxLength(100)]
        [Display(Name = "Twitter")]
        public string Twitter { get; set; }
        [DataType(DataType.EmailAddress)]
        [MaxLength(100)]
        [Display(Name = "İkinci Eposta")]
        public string SecondaryEmail { get; set; }
        [MaxLength(200)]
        [Display(Name = "Fotoğraf")]
        public string Photo { get; set; }
        [MaxLength(500)]
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Display(Name = "Ülke")]
        public Guid? CountryId { get; set; }
        [Display(Name = "Şehir")]
        public Guid? CityId { get; set; }
        [Display(Name = "Mahalle")]
        public Guid? RegionId { get; set; }
        [MaxLength(10)]
        [Display(Name = "Posta Kodu")]
        public string PostalCode { get; set; }
        [Display(Name = "Açıklama")]
        [MaxLength(4000)]
        public string Description { get; set; }
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
        [Display(Name = "Mahalle Adı")]
        public string RegionName { get; set; }
        [Display(Name = "Şehir Adı")]
        public string CityName { get; set; }
        [Display(Name = "Ülke Adı")]
        public string CountryName { get; set; }
        [Display(Name = "Müşteri Kaynağı Adı")]
        public string LeadSourceName { get; set; }
        [Display(Name = "Müşteri Durumu")]
        public string LeadStatusName { get; set; }
        [Display(Name = "Sektör Adı")]
        public string SectorName { get; set; }

    }
}