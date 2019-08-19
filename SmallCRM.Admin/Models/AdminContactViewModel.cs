using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class AdminContactViewModel
    {
        [Display(Name = "Ad")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Ad alanı gereklidir")]
        public string FirstName { get; set; }
        [Display(Name = "Soyad")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Soyad alanı gereklidir")]
        public string LastName { get; set; }
        [Display(Name = "Telefon")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Telefon alanı gereklidir.")]
        [Phone]
        public string Phone { get; set; }
        [Display(Name = "E-posta")]
        [MaxLength(100)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Mesaj")]
        [MaxLength(4000)]
        [Required]
        public string Message { get; set; }
        [Display(Name = "Kvkk")]
        [Required]
        public bool PrivacyPolicyAccepted { get; set; }
    }
}