using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class LeadStatusViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name="Müşteri Adayı Durumu")]
        public string Name { get; set; }
    }
}