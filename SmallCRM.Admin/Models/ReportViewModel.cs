using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class ReportViewModel
    {
        [Display(Name="Rapor No")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name ="Rapor Adı")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Açıklama")]
        [MaxLength(4000)]
        public string Description { get; set; }
        [Required]
        [Display(Name="Son Değiştirme Tarihi")]
        public DateTime LastExecutionDate { get; set; }
        public bool IsActive { get; set; }

    }
}