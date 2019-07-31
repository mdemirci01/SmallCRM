using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class City:BaseEntity
    {
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Region> Regions { get; set; }

        public virtual ICollection<Lead> Leads { get; set; }

        public virtual ICollection<Contact> PostalContacts { get; set; }
        public virtual ICollection<Contact> OtherContacts { get; set; }
    }
}
