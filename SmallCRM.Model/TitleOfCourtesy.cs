using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum TitleOfCourtesy
    {
        [Display(Name = "Yok")]
        None = 0,
        [Display(Name = "Erkek")]
        Mr = 1,
        [Display(Name = "Kadın")]
        Mrs = 2,
        [Display(Name = "Doktor")]
        Dr = 3,
        [Display(Name = "Profesör")]
        Prof = 4,
        [Display(Name = "Doçent")]
        AssociateProf = 5,
        [Display(Name = "Yardımcı Doçent")]
        AssistantProf = 6,
        [Display(Name = "Avukat")]
        Lawyer = 7
    }
}
