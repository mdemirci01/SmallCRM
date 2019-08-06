using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class OpportunityViewModel
    {
        
        public Guid Id { get; set; }
        [Display(Name ="Satış Fırsatı Kayıt Sahibi")]
        [MaxLength(100)]
        public string Owner { get; set; }
        [Required]
        [Display(Name = "Satış Fırsatı Adı")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Firma Adı")]
        public Guid CompanyId { get; set; }
        [Display(Name = "Tip")]
        public OpportunityType? OpportunityType { get; set; }
      
        [Display(Name = "Sonraki Adım")]
        [MaxLength(100)]
        public string NextStep { get; set; }
        [Display(Name = "Müşteri Adayı Kaynağı")]
        public Guid? LeadSourceId { get; set; }
        [Display(Name = "Kişi Adı")]
        public Guid? ContactId { get; set; }
        [Display(Name = "Tutar")]
        public decimal Amount { get; set; }
        [Required]
        [Display(Name = "Kapanış Tarihi")]
        public DateTime CloseDate { get; set; }
        [Required]
        [Display(Name = "Aşama")]
        public OpportunityStage OpportunityStage { get; set; }
        [Display(Name = "Olasılık")]
        public int Possibility { get; set; }
        [Display(Name = "Beklenen Ciro")]
        public decimal ExpectedRevenue { get; set; }
        [Display(Name = "Kampanya Kaynağı")]
        public Guid? CampaignSourceId { get; set; }
        [Display(Name = "Açıklama")]
        [MaxLength(4000)]
        public string Description { get; set; }
        [Display(Name ="Aktif Mi?")]
        public bool IsActive { get; set; }
        [Display(Name = "Kampanya Kaynağı Adı")]
        public string CampaignSourceName { get; set; }
        [Display(Name = "Şirket Kayıt Sahibi")]
        public string CompanyOwner { get; set; }
        [Display(Name = "Kişi Kayıt Sahibi")]
        public string ContactOwner { get; set; }
        [Display(Name = "Müşteri Kaynağı Adı")]
        public string LeadSourceName { get; set; }
    }
}