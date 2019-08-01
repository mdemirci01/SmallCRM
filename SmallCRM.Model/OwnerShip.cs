using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
     public enum Ownership
    {
        None =0,
        Other=1,
        VisibleToOwner=2,
        General=3,
        VisibleToPartner=4
    }
}
