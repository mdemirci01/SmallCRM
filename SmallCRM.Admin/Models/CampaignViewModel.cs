using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class CampaignViewModel
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        [Display(Name ="Kampanya Kayıt Sahibi")]
        public string Owner { get; set; }        
        [Display(Name = "Kampanya Adı")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime? StartDate { get; set; }
        [MaxLength(100)]
        [Display(Name = "Beklenen Ciro")]
        public decimal? ExpectedRevenue { get; set; } //Beklenen ciro
        [Display(Name = "Gerçekleşen Masraf")]
        public decimal? Cost { get; set; } //Maliyet(Gerçekleşen masraf)
        [Display(Name = "Gönderilen Numaralar")]
        public string SendPhoneNumbers { get; set; } //Gönderilen Numaralar
        [Required]
        [Display(Name = "Tip")]
        public OpportunityType OpportunityType { get; set; }
        [Display(Name = "Durum")]
        public CampaignStatus? CampaignStatus { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Bütçelenmiş Masraf")]
        public decimal? PlannedCost { get; set; } //Bütçelenmiş masraf
        [Display(Name = "Beklenen Tepki")]
        public string ExpectedResponse { get; set; } //Beklenen tepki
        [Display(Name = "Açıklama")]
        [MaxLength(4000)]
        public string Description { get; set; }
    }
}