using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    // Lead: Müşteri Adayı
    public class Lead : BaseEntity
    {
        public string Owner { get; set; }
        public string FirstName { get; set; } // required
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Company { get; set; } // required
        public TitleOfCourtesy? TitleOfCourtesy { get; set; }
        public Gender? Gender { get; set; }
        public string Title { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public Guid? LeadSourceId { get; set; }
        public virtual LeadSource LeadSource { get; set; }
        public Guid? SectorId { get; set; }
        public virtual Sector Sector { get; set; }

        public bool NotSendEmail { get; set; }
        public bool NotSendSms { get; set; }

        public string Website { get; set; }
        public Guid? LeadStatusId { get; set; }
        public virtual LeadStatus LeadStatus { get; set; }

        public Stage? Stage { get; set; }
        public string SkypeId { get; set; }
        public string Twitter { get; set; }
        public string SecondaryEmail { get; set; }

        public string Photo { get; set; }
        public string Address { get; set; }
       
        public Guid? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public Guid? CityId { get; set; }
        public virtual City City { get; set; }

        public Guid? RegionId { get; set; }
        public virtual Region Region { get; set; }

        public string PostalCode { get; set; }
        public string Description { get; set; }
    }
}
