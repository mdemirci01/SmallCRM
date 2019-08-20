using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SmallCRM.Admin.Models;
using SmallCRM.Data;
using SmallCRM.Model;
using SmallCRM.Service;
using static SmallCRM.Service.ContactService;

namespace SmallCRM.Admin.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContactService contactService;
        private readonly ICityService cityService;
        private readonly ICompanyService companyService;
        private readonly ICountryService countryService;
        private readonly ILeadSourceService leadSourceService;
        private readonly IRegionService regionService;
        private readonly IReportService reportService;
       
        

        public ContactsController(IContactService contactService, ICityService cityService, ICompanyService companyService, ICountryService countryService, ILeadSourceService leadSourceService, IRegionService regionService, IReportService reportService)
        {
            this.contactService = contactService;
            this.cityService = cityService;
            this.companyService = companyService;
            this.leadSourceService = leadSourceService;
            this.countryService = countryService;
            this.regionService = regionService;
            this.reportService = reportService;
        }
         [HttpPost]
        public ActionResult GetCities(Guid countryId)
        {
            var cities = Mapper.Map<IEnumerable<CityViewModel>>(cityService.GetAllByCountryId(countryId));
            return Json(cities);
        }
        [HttpPost]
        public ActionResult GetRegions(Guid cityId)
        {
            var region = Mapper.Map<IEnumerable<RegionViewModel>>(regionService.GetAllByCityId(cityId));
            return Json(region);
        }


        // GET: Contacts
        public ActionResult Index()
        {
            var contacts = Mapper.Map<IEnumerable<ContactViewModel>>(contactService.GetAll());
            return View(contacts);
        }

        // GET: Contacts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactViewModel contact = Mapper.Map<ContactViewModel>(contactService.Get(id.Value));
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(cityService.GetAllByCountryId(Guid.NewGuid()), "Id", "Name");
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name");
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            ViewBag.LeadSourceId = new SelectList(leadSourceService.GetAll(), "Id", "Name");
            ViewBag.OtherCityId = new SelectList(cityService.GetAll(), "Id", "Name");
            ViewBag.OtherCountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            ViewBag.OtherRegionId = new SelectList(regionService.GetAll(), "Id", "Name");
            ViewBag.RegionId = new SelectList(regionService.GetAllByCityId(Guid.NewGuid()), "Id", "Name");
            ViewBag.ReportsToContactId = new SelectList(reportService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Contacts/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Owner,FirstName,LastName,TitleOfCourtesy,CompanyId,Email,Telephone,OtherPhone,HomePhone,MobilePhone,AssistantName,AssistantPhone,LeadSourceId,Title,Department,Fax,BirthDate,NotSendEmail,NotSendSms,SkypeId,Twitter,SecondaryEmail,ReportsToContactId,Photo,Address,CountryId,CityId,RegionId,PostalCode,OtherAddress,OtherCountryId,OtherCityId,OtherRegionId,OtherPostalCode,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Contact>(contact);
                contactService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", contact.CityId);
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", contact.CompanyId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", contact.CountryId);
            ViewBag.LeadSourceId = new SelectList(leadSourceService.GetAll(), "Id", "Name", contact.LeadSourceId);
            ViewBag.OtherCityId = new SelectList(cityService.GetAll(), "Id", "Name", contact.OtherCityId);
            ViewBag.OtherCountryId = new SelectList(countryService.GetAll(), "Id", "Name", contact.OtherCountryId);
            ViewBag.OtherRegionId = new SelectList(regionService.GetAll(), "Id", "Name", contact.OtherRegionId);
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "Name", contact.RegionId);
            ViewBag.ReportsToContactId = new SelectList(reportService.GetAll(), "Id", "Name", contact.ReportsToContactId);
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactViewModel contact = Mapper.Map<ContactViewModel>(contactService.Get(id.Value));
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", contact.CityId);
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", contact.CompanyId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", contact.CountryId);
            ViewBag.LeadSourceId = new SelectList(leadSourceService.GetAll(), "Id", "Name", contact.LeadSourceId);
            ViewBag.OtherCityId = new SelectList(cityService.GetAll(), "Id", "Name", contact.OtherCityId);
            ViewBag.OtherCountryId = new SelectList(countryService.GetAll(), "Id", "Name", contact.OtherCountryId);
            ViewBag.OtherRegionId = new SelectList(regionService.GetAll(), "Id", "Name", contact.OtherRegionId);
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "Name", contact.RegionId);
            ViewBag.ReportsToContactId = new SelectList(reportService.GetAll(), "Id", "Name", contact.ReportsToContactId);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Contact>(contact);
                contactService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", contact.CityId);
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", contact.CompanyId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", contact.CountryId);
            ViewBag.LeadSourceId = new SelectList(leadSourceService.GetAll(), "Id", "Name", contact.LeadSourceId);
            ViewBag.OtherCityId = new SelectList(cityService.GetAll(), "Id", "Name", contact.OtherCityId);
            ViewBag.OtherCountryId = new SelectList(countryService.GetAll(), "Id", "Name", contact.OtherCountryId);
            ViewBag.OtherRegionId = new SelectList(regionService.GetAll(), "Id", "Name", contact.OtherRegionId);
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "Name", contact.RegionId);
            ViewBag.ReportsToContactId = new SelectList(reportService.GetAll(), "Id", "Name", contact.ReportsToContactId);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactViewModel contact = Mapper.Map<ContactViewModel>(contactService.Get(id.Value));
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            contactService.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
