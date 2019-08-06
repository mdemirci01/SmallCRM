using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class CampaignSourceViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name ="Kampanya Kaynağı Adı")]
        public string Name { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}