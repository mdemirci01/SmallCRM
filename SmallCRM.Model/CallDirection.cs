using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum CallDirection
    {
        [Display(Name = "Giden Arama")]
        OutgoingCall = 0,
        [Display(Name = "Gelen Arama")]
        IncomingCall = 1
    }
}
