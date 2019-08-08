using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum OpportunityType
    {
        [Display(Name = "Yok")]
        None =0,
        [Display(Name = "Konferans")]
        Conference =1,
        [Display(Name = "Webiner")]
        Webiner =2,
        [Display(Name = "Ticari Fuar")]
        Exibition =3,
        [Display(Name = "Halkla İlişkiler")]
        PublicRelations =4,
        [Display(Name = "Ortaklar")]
        Partners =5,
        [Display(Name = "Yönlendirme Programları")]
        RoutingPrograms =6,
        [Display(Name = "Reklam")]
        Commercial =7,
        [Display(Name = " Banner Reklamları")]
        BannerCommercials =8,
        [Display(Name = "Direkt Gönderi")]
        DirectPost =9,
        [Display(Name = "E-Posta")]
        Email =10,
        [Display(Name = "Telefonla Pazarlama")]
        Telemarketing =11,
        [Display(Name = "Diğerleri")]
        Others =12
    }
}
