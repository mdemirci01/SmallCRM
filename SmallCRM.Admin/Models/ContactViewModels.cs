using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class ContactViewModels
    {
        [Required]
        public Guid Id { get; set; }
        [MaxLength(100)]
        [Display(Name ="Sahip")]
        public string Owner { get; set; }
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Ad")]

        public string FirstName { get; set; } // required
        [MaxLength(50)]
        [Display(Name = "Soyad")]

        public string LastName { get; set; }
        [Display(Name = "Nezaket Ünvanı")]
        public TitleOfCourtesy? TitleOfCourtesy { get; set; }
        [Display(Name = "Şirket")]

        public Guid? CompanyId { get; set; }
        [MaxLength(100)]
        [Display(Name = "E-Posta")]

        public string Email { get; set; }
        [MaxLength(20)]
        [Display(Name = "Telefon")]
        public string Telephone { get; set; }
        [MaxLength(20)]
        [Display(Name = "Diğer Telefon")]
        public string OtherPhone { get; set; }
        [MaxLength(20)]
        [Display(Name = "Sabit Telefon")]
        public string HomePhone { get; set; }
        [MaxLength(20)]
        [Display(Name = "Cep Telefonu")]
        public string MobilePhone { get; set; }
        [MaxLength(100)]
        [Display(Name = "Asistan Adı")]
        public string AssistantName { get; set; }
        [MaxLength(20)]
        [Display(Name = "Asistan Numarası")]
        public string AssistantPhone { get; set; }
        [Display(Name = "Müşteri Kaynak")]
        public Guid? LeadSourceId { get; set; }
        [MaxLength(100)]
        [Display(Name = "Başlık")]

        public string Title { get; set; }
        [MaxLength(100)]
        [Display(Name = "Departman")]
        public string Department { get; set; }
        [MaxLength(20)]
        [Display(Name = "Faks")]
        public string Fax { get; set; }
        [Display(Name = "Doğum Günü")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "E-Mail Gönderme")]
        public bool NotSendEmail { get; set; }
        [Display(Name = "Sms Gönderme")]
        public bool NotSendSms { get; set; }
        [MaxLength(100)]
        [Display(Name = "Skype")]
        public string SkypeId { get; set; }
        [MaxLength(100)]
        public string Twitter { get; set; }
        [MaxLength(100)]
        [Display(Name = "İkincil E-Mail")]
        public string SecondaryEmail { get; set; }
        [Display(Name = "Rapor")]


        public Guid? ReportsToContactId { get; set; }
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
        [Display(Name = "İlçe")]


        public Guid? RegionId { get; set; }
        [MaxLength(10)]
        [Display(Name = "Posta Kodu")]

        public string PostalCode { get; set; }
        [MaxLength(500)]
        [Display(Name = "Diğer Adres")]

        public string OtherAddress { get; set; }
        [Display(Name = "Diğer Ülke")]

        public Guid? OtherCountryId { get; set; }
        [Display(Name = "Diğer Şehir")]


        public Guid? OtherCityId { get; set; }
        [Display(Name = "Diğer İlçe")]


        public Guid? OtherRegionId { get; set; }
        [MaxLength(10)]
        [Display(Name = "Diğer Posta Kodu")]


        public string OtherPostalCode { get; set; }
        [MaxLength(4000)]
        [Display(Name = "Açıklama")]

        public string Description { get; set; }
    }
}