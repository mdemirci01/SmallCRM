using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class LeadSourceViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name="Müşteri Adayı Kaynağı")]
        public string Name { get; set; }
        [Display(Name="Aktif mi?")]
        public bool IsActive { get; set; }
    }
}