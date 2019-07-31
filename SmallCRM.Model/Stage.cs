using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum Stage
    {
        None = 0,
        Gained = 1,
        Active = 2,
        Failed = 3,
        Cancelled = 4,
        Closed  = 5
    }
}
