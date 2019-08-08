using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum CallResult
    {
        [Display(Name = "Bulunamadı")]
        NotFound = 0,
        [Display(Name = "İlgimi çekti")]
        Interested = 1,
        [Display(Name = "İlgilenmiyorum")]
        NotInterested = 2,
        [Display(Name = "Yanıt Yok/Meşgul")]
        NotAnsweredOrBusy = 3,
        [Display(Name = "Daha fazla bilgi talep edildi")]
        RequestMoreInformation = 4,
        [Display(Name = "Geri arama talep edildi")]
        CallbackRequest = 5,
        [Display(Name = "Yanlış Numara")]
        WrongNumber = 6
    }
}
