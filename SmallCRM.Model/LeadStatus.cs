using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class LeadStatus
    {
        public string Name { get; set; }
        public virtual ICollection<Lead> Leads { get; set; }
    }
}
