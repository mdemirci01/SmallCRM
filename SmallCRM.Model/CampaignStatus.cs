using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum CampaignStatus
    {
        [Display(Name = "-Yok-")]
        None =0,
        [Display(Name = "Planlanıyor")]
        Planning = 1,
        [Display(Name = "Aktif")]
        Active = 2,
        [Display(Name = "Aktif Değil")]
        NonActive = 3,
        [Display(Name = "Tamamlandı")]
        Completed = 4
    }
   
}
