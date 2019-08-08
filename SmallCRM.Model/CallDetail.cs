using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum CallDetail
    {
        [Display(Name = "Yeni Arama")]
        NewCall = 0,
        [Display(Name = "Tamamlanmış Arama")]
        CompletedCall = 1,
        [Display(Name = "Planlama Çağrısı")]
        PlanningCall = 2
    }
}
