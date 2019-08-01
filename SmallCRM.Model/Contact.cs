using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class Contact:BaseEntity
    {
        public string Owner { get; set; }
        public string FullName {  get { return FirstName + " " + LastName;  } }
        public string FirstName { get; set; } // required
        public string LastName { get; set; }
        public TitleOfCourtesy? TitleOfCourtesy { get; set; }
        public Guid? CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string OtherPhone { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string AssistantName { get; set; }
        public string AssistantPhone { get; set; }
        public Guid? LeadSourceId { get; set; }
        public virtual LeadSource LeadSource { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Fax { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool NotSendEmail { get; set; }
        public bool NotSendSms { get; set; }
        public string SkypeId { get; set; }
        public string Twitter { get; set; }
        public string SecondaryEmail { get; set; }

        public Guid? ReportsTo { get; set; }
        public virtual Contact ReportsToContact { get; set; }

        public virtual ICollection<Contact> ChildContacts { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Opportunity> Opportunities { get; set; }

        public string Photo { get; set; }

        public string Address { get; set; }

        public Guid? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public Guid? CityId { get; set; }
        public virtual City City { get; set; }

        public Guid? RegionId { get; set; }
        public virtual Region Region { get; set; }

        public string PostalCode { get; set; }

        public string OtherAddress { get; set; }

        public Guid? OtherCountryId { get; set; }
        public virtual Country OtherCountry { get; set; }

        public Guid? OtherCityId { get; set; }
        public virtual City OtherCity { get; set; }

        public Guid? OtherRegionId { get; set; }
        public virtual Region OtherRegion { get; set; }

        public string OtherPostalCode { get; set; }

        public string Description { get; set; }

    }
}
