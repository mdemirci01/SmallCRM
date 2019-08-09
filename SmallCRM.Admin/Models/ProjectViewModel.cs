using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class ProjectViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name ="Proje Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [MaxLength(4000)]
        [Display(Name = "Yöneticiler")]
        public string Managers { get; set; }
        [MaxLength(4000)]
        [Display(Name = "İş Analistleri")]
        public string BussinessAnalyists { get; set; }
        [MaxLength(4000)]
        [Display(Name = "Geliştiriciler")]
        public string Developers { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Çalışma Durumu")]
        public WorkItemStatus? WorkItemStatus { get; set; }
        [Display(Name = "Toplam Harcanan Zaman")]
        public decimal TotalTimeSpent { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}