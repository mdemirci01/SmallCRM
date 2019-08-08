using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum WorkItemStatus
    {
        [Display(Name = "Başlanmadı")]
        NotStarted = 0,
        [Display(Name = "Devam Ediyor")]
        Continuing = 1,
        [Display(Name = "Ertelendi")]
        Postponed = 2,
        [Display(Name = "İptal Edildi")]
        Canceled = 3,
        [Display(Name = "Tamamlandı")]
        Completed = 4
    }
}

    

