using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class Region:BaseEntity
    {
        public string Name { get; set; }
        public Guid CityId { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<Lead> Leads { get; set; }

        public virtual ICollection<Contact> PostalContacts { get; set; }
        public virtual ICollection<Contact> OtherContacts { get; set; }
        public virtual ICollection<Company> DeliveryCompanies { get; set; }
        public virtual ICollection<Company> InvoiceCompanies { get; set; }
    }
}
