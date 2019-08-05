using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class FeedViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(4000)]
        [Display(Name ="Mesaj")]
        public string Message { get; set; }
        [Display(Name = "Belge")]
        public Guid? DocumentId { get; set; }
        [Display(Name = "Okundu Bilgisi")]
        public bool IsRead { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Hedef Kullanıcı")]
        public string TargetUser { get; set; }
    }
}