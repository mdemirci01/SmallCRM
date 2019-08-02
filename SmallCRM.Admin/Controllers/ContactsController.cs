using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmallCRM.Data;
using SmallCRM.Model;

namespace SmallCRM.Admin.Controllers
{
    public class ContactsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contacts
        public ActionResult Index()
        {
            var contacts = db.Contacts.Include(c => c.City).Include(c => c.Company).Include(c => c.Country).Include(c => c.LeadSource).Include(c => c.OtherCity).Include(c => c.OtherCountry).Include(c => c.OtherRegion).Include(c => c.Region).Include(c => c.ReportsToContact);
            return View(contacts.ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name");
            ViewBag.OtherCityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.OtherCountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.OtherRegionId = new SelectList(db.Regions, "Id", "Name");
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name");
            ViewBag.ReportsToContactId = new SelectList(db.Contacts, "Id", "Owner");
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
                contact.Id = Guid.NewGuid();
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", contact.CityId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner", contact.CompanyId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", contact.CountryId);
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name", contact.LeadSourceId);
            ViewBag.OtherCityId = new SelectList(db.Cities, "Id", "Name", contact.OtherCityId);
            ViewBag.OtherCountryId = new SelectList(db.Countries, "Id", "Name", contact.OtherCountryId);
            ViewBag.OtherRegionId = new SelectList(db.Regions, "Id", "Name", contact.OtherRegionId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", contact.RegionId);
            ViewBag.ReportsToContactId = new SelectList(db.Contacts, "Id", "Owner", contact.ReportsToContactId);
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", contact.CityId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner", contact.CompanyId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", contact.CountryId);
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name", contact.LeadSourceId);
            ViewBag.OtherCityId = new SelectList(db.Cities, "Id", "Name", contact.OtherCityId);
            ViewBag.OtherCountryId = new SelectList(db.Countries, "Id", "Name", contact.OtherCountryId);
            ViewBag.OtherRegionId = new SelectList(db.Regions, "Id", "Name", contact.OtherRegionId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", contact.RegionId);
            ViewBag.ReportsToContactId = new SelectList(db.Contacts, "Id", "Owner", contact.ReportsToContactId);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Owner,FirstName,LastName,TitleOfCourtesy,CompanyId,Email,Telephone,OtherPhone,HomePhone,MobilePhone,AssistantName,AssistantPhone,LeadSourceId,Title,Department,Fax,BirthDate,NotSendEmail,NotSendSms,SkypeId,Twitter,SecondaryEmail,ReportsToContactId,Photo,Address,CountryId,CityId,RegionId,PostalCode,OtherAddress,OtherCountryId,OtherCityId,OtherRegionId,OtherPostalCode,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", contact.CityId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner", contact.CompanyId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", contact.CountryId);
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name", contact.LeadSourceId);
            ViewBag.OtherCityId = new SelectList(db.Cities, "Id", "Name", contact.OtherCityId);
            ViewBag.OtherCountryId = new SelectList(db.Countries, "Id", "Name", contact.OtherCountryId);
            ViewBag.OtherRegionId = new SelectList(db.Regions, "Id", "Name", contact.OtherRegionId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", contact.RegionId);
            ViewBag.ReportsToContactId = new SelectList(db.Contacts, "Id", "Owner", contact.ReportsToContactId);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
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
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
