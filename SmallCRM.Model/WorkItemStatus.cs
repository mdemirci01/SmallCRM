using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum WorkItemStatus
    {    
        NotStarted = 0,        
        Continuing = 1,        
        Postponed = 2,        
        Canceled = 3,        
        Completed = 4
    }
}

    

