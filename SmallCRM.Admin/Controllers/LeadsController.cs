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
    public class LeadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Leads
        public ActionResult Index()
        {
            var leads = db.Leads.Include(l => l.City).Include(l => l.Country).Include(l => l.LeadSource).Include(l => l.LeadStatus).Include(l => l.Region).Include(l => l.Sector);
            return View(leads.ToList());
        }

        // GET: Leads/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = db.Leads.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        // GET: Leads/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name");
            ViewBag.LeadStatusId = new SelectList(db.LeadStatuses, "Id", "Name");
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name");
            ViewBag.SectorId = new SelectList(db.Sectors, "Id", "Name");
            return View();
        }

        // POST: Leads/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Owner,FirstName,LastName,Company,TitleOfCourtesy,Gender,Title,Telephone,MobilePhone,Email,Fax,LeadSourceId,SectorId,NotSendEmail,NotSendSms,Website,LeadStatusId,Stage,SkypeId,Twitter,SecondaryEmail,Photo,Address,CountryId,CityId,RegionId,PostalCode,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Lead lead)
        {
            if (ModelState.IsValid)
            {
                lead.Id = Guid.NewGuid();
                db.Leads.Add(lead);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", lead.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", lead.CountryId);
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name", lead.LeadSourceId);
            ViewBag.LeadStatusId = new SelectList(db.LeadStatuses, "Id", "Name", lead.LeadStatusId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", lead.RegionId);
            ViewBag.SectorId = new SelectList(db.Sectors, "Id", "Name", lead.SectorId);
            return View(lead);
        }

        // GET: Leads/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = db.Leads.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", lead.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", lead.CountryId);
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name", lead.LeadSourceId);
            ViewBag.LeadStatusId = new SelectList(db.LeadStatuses, "Id", "Name", lead.LeadStatusId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", lead.RegionId);
            ViewBag.SectorId = new SelectList(db.Sectors, "Id", "Name", lead.SectorId);
            return View(lead);
        }

        // POST: Leads/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Owner,FirstName,LastName,Company,TitleOfCourtesy,Gender,Title,Telephone,MobilePhone,Email,Fax,LeadSourceId,SectorId,NotSendEmail,NotSendSms,Website,LeadStatusId,Stage,SkypeId,Twitter,SecondaryEmail,Photo,Address,CountryId,CityId,RegionId,PostalCode,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Lead lead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lead).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", lead.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", lead.CountryId);
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name", lead.LeadSourceId);
            ViewBag.LeadStatusId = new SelectList(db.LeadStatuses, "Id", "Name", lead.LeadStatusId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", lead.RegionId);
            ViewBag.SectorId = new SelectList(db.Sectors, "Id", "Name", lead.SectorId);
            return View(lead);
        }

        // GET: Leads/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = db.Leads.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        // POST: Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Lead lead = db.Leads.Find(id);
            db.Leads.Remove(lead);
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
