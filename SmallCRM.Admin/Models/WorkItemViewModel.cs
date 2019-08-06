using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class WorkItemViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name ="Ad")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [MaxLength(100)]
        [Display(Name = "Atanan Kişi")]
        public string AssignedTo { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime? EndDate { get; set; }
        [MaxLength(100)]
        [Display(Name = "Kategori")]
        public string Category { get; set; }
        [Display(Name = "Çalışma Durumu")]
        public WorkItemStatus? WorkItemStatus { get; set; }
        [Display(Name = "Proje")]
        public Guid ProjectId { get; set; }
        [Display(Name = "Toplam Harcanan Zaman")]
        public decimal TotalTimeSpent { get; set; }
        [Display(Name ="Aktif Mi?")]
        public bool IsActive { get; set; }
        [Display(Name ="Proje Adı")]
        public string ProjectName { get; set; }
    }
}