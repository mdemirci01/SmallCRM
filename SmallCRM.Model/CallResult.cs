using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum CallResult
    {
        NotFound = 0,
        Interested = 1,
        NotInterested = 2,
        NotAnsweredOrBusy = 3,
        RequestMoreInformation = 4,
        CallbackRequest = 5,
        WrongNumber = 6
    }
}
