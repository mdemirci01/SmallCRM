using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum OpportunityStage
    {
        [Display(Name ="Yok")]
        None=0,
        [Display(Name = "Görüşülüyor/Değerlendiriliyor")]
        Evaluation = 1,
        [Display(Name = "Analiz Gerekiyor")]
        AnalysisRequired =2,
        [Display(Name = "Değer Öneriliyor")]
        SuggestingValue =3,
        [Display(Name = "Karar Verenleri Tanımla")]
        IdentifyMadeDecisions =4,
        [Display(Name = "Fiyat Teklifi")]
        OfferingPrice =5,
        [Display(Name = "Kapandı-Kazanıldı")]
        ClosedWon =6,
        [Display(Name = "Kapandı-Kaybedildi")]
        ClosedLost =7,
        [Display(Name = "Rekabette Kapandı-Kaybedildi")]
        LostToCompetition =8




    }
}
