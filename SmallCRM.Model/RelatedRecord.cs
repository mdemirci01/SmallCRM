using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum RelatedRecord
    {
        [Display(Name = "Firma")]
        Company = 0,
        [Display(Name = "Satış fırsatı")]
        SalesOppurtunity = 1,
        [Display(Name = "Kampanya")]
        Campaign = 2
    }
}
