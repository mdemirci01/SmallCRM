using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
     public enum Ownership
    {
        [Display(Name ="Yok")]
        None =0,

        [Display(Name = "Diğer")]
        Other =1,

        [Display(Name = "Sahibi Görebilir")]
        VisibleToOwner =2,

        [Display(Name = "Genel")]
        General =3,


        [Display(Name = "Yan Kuruluş")]
        VisibleToPartner =4
    }
}
