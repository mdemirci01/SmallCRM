using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum Stage
    {
        [Display(Name ="Yok")]
        None = 0,

        [Display(Name = "Kazanılan")]
        Gained = 1,

        [Display(Name = "Aktif")]
        Active = 2,

        [Display(Name = "Başarısız Oldu")]
        Failed = 3,

        [Display(Name = "Proje İptal")]
        Cancelled = 4,


        [Display(Name = "Kapat")]
        Closed  = 5
    }
}
