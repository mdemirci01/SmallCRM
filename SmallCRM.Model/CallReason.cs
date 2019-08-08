using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum CallReason
    {
        [Display(Name = "Bulunamadı")]
        NotFound = 0,
        [Display(Name = "İnceleniyor")]
        Inspecting = 1,
        [Display(Name = "Yönetimsel")]
        Administrative = 2,
        [Display(Name = "Müzakere")]
        Negotiation = 3,
        [Display(Name = "Demo")]
        Demo = 4,
        [Display(Name = "Proje")]
        Project = 5,
        [Display(Name = "Destek")]
        Support = 6

    }
}
