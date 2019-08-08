using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class Country:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }

        public virtual ICollection<Lead> Leads { get; set; }
        public virtual ICollection<Contact> PostalContacts { get; set; }
        public virtual ICollection<Contact> OtherContacts { get; set; }
        public virtual ICollection<Company> InvoiceCompanies { get; set; }
        public virtual ICollection<Company> DeliveryCompanies { get; set; }
    }
}
