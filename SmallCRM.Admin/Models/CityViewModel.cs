using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class CityViewModel
    {
        
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Şehir Adı")]
        public string Name { get; set; }

        [Display(Name = "Ülke")]
        public Guid CountryId { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }

        [Display(Name ="Ülke Adı")]
        public string CountryName { get; set; }
    }
}