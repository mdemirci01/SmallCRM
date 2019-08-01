using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class LeadSource:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Lead> Leads { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; } // updateDate : 01.08.2019
        public virtual ICollection<Opportunity> Opportunities { get; set; } // updateDate : 01.08.2019
    }
}
