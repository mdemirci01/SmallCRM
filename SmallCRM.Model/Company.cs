using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class Company:BaseEntity
    {
        public string Owner { get; set; }//FirmaKayıtSahibi
        public string Name { get; set; }

        public Guid? MainCompanyId { get; set; }
        public virtual Company MainCompany { get; set; }

        public string CompanyNumber { get; set; }
        public Guid? CompanyTypeId { get; set; }
        public virtual CompanyType CompanyType { get; set; }

        public Guid? SectorId { get; set; }
        public virtual Sector Sector { get; set; }

        public decimal AnnualIncome { get; set; }
        public Stage? Stage { get; set; }


        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string ImkbCode { get; set; }
        public Ownership? OwnerShip { get; set; }
        public string NaceCode { get; set; }


        //ADRES BİLGİLERİ
        //Fatura Bilgisi-INVOICE
        public string InvoiceAddress { get; set; }

        public Guid? InvoiceCityId { get; set; }
        public virtual City InvoiceCity { get; set; }


        public Guid? InvoiceRegionId { get; set; }
        public virtual Region InvoiceRegion { get; set; }

   
        public string InvoicePostalCode { get; set; }
        public string InvoiceDescription { get; set; }

        public Guid? InvoiceCountryId { get; set; }
        public virtual Country InvoiceCountry { get; set; }



        //Teslimat Bilgisi-DELIVERY
        public string DeliveryAddress { get; set; }

        public Guid? DeliveryCityId { get; set; }
        public virtual City DeliveryCity { get; set; }


        public Guid? DeliveryRegionId { get; set; }
        public virtual Region DeliveryRegion { get; set; }

     
        public string DeliveryPostalCode { get; set; }
        public string DeliveryDescription { get; set; }

        public Guid? DeliveryCountryId { get; set; }
        public virtual Country DeliveryCountry { get; set; }

        public string Description { get; set; }


        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Lead> Leads { get; set; }
        public virtual ICollection<Opportunity> Opportunities { get; set; }













    }
}
