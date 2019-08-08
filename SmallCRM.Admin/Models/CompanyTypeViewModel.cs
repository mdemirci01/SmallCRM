using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class CompanyTypeViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name="Firma Türü")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}