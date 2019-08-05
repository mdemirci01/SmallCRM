using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class ActivityViewModels
    {

        public Guid Id { get; set; }
        [Display(Name = "İrtibat Adı")]
        public string ContactFullName { get; set; }
        [MaxLength(100)]
        [Display(Name = "Konu")]
        [Required]
        public string Subject { get; set; }
        [Display(Name = "Arama Nedeni")]
        public CallReason? CallReason { get; set; }
        [Display(Name = "İlgilisi")]
        public RelatedRecord? RelatedRecord { get; set; }
        [Display(Name = "Arama Tipi")]
        [Required]
        public CallDirection CallDirection { get; set; }
        [Display(Name = "Arama Detayları")]
        public CallDetail? CallDetail { get; set; }
        [Display(Name = "Arama Sonucu")]
        public CallResult? CallResult { get; set; }
        [Display(Name = "İrtibat")]
        public Guid? ContactId { get; set; }

        
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [MaxLength(50)]
        [Display(Name = "Firma Adı")]
        [Required]
        public string CompanyName { get; set; }
        [Display(Name = "Telefon")]
        [Phone]
        public string CompanyTelephone { get; set; }
        [Display(Name = "Web Sitesi")]
        [EmailAddress]
        public string CompanyWebsite { get; set; }
        [Display(Name = "Firma")]
        public Guid? CompanyId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Satış Fırsatı Adı")]
        [Required]
        public string OpportunityName { get; set; }
        [Display(Name = "Tutar")]
        public decimal? OpportunityAmount { get; set; }
        [Display(Name = "Kapanış Tarihi")]
        [Required]
        public DateTime OpportunityCloseDate { get; set; }
        [Display(Name = "Tipi")]
        [Required]
        public OpportunityType OpportunityType { get; set; }
        [Display(Name = "Aşama")]
        [Required]
        public OpportunityStage OpportunityStage { get; set; }
        [Display(Name = "Satış Fırsatı")]
        public Guid? OpportunityId { get; set; }

        [Display(Name = "Kampanya Adı")]
        [Required]
        [MaxLength(100)]
        public string CampaignName { get; set; }

        [Display(Name = "Durum")]
        public CampaignStatus? CampaignStatus { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime? CampaignStartDate { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime? CampaignEndDate { get; set; }
        [Display(Name = "Beklenen Ciro")]
        public decimal? CampaignExpectedRevenue { get; set; } //Beklenen ciro
        [Display(Name = "Kampanya")]
        public Guid? CampaignId { get; set; }

    }
}