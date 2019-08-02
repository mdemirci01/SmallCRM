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
    public class OpportunitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Opportunities
        public ActionResult Index()
        {
            var opportunities = db.Opportunities.Include(o => o.CampaignSource).Include(o => o.Company).Include(o => o.Contact).Include(o => o.LeadSource);
            return View(opportunities.ToList());
        }

        // GET: Opportunities/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opportunity opportunity = db.Opportunities.Find(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            return View(opportunity);
        }

        // GET: Opportunities/Create
        public ActionResult Create()
        {
            ViewBag.CampaignSourceId = new SelectList(db.CampaignSources, "Id", "Name");
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner");
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Owner");
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name");
            return View();
        }

        // POST: Opportunities/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Owner,Name,CompanyId,OpportunityType,NextStep,LeadSourceId,ContactId,Amount,CloseDate,OpportunityStage,Possibility,ExpectedRevenue,CampaignSourceId,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                opportunity.Id = Guid.NewGuid();
                db.Opportunities.Add(opportunity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CampaignSourceId = new SelectList(db.CampaignSources, "Id", "Name", opportunity.CampaignSourceId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner", opportunity.CompanyId);
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Owner", opportunity.ContactId);
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name", opportunity.LeadSourceId);
            return View(opportunity);
        }

        // GET: Opportunities/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opportunity opportunity = db.Opportunities.Find(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampaignSourceId = new SelectList(db.CampaignSources, "Id", "Name", opportunity.CampaignSourceId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner", opportunity.CompanyId);
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Owner", opportunity.ContactId);
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name", opportunity.LeadSourceId);
            return View(opportunity);
        }

        // POST: Opportunities/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Owner,Name,CompanyId,OpportunityType,NextStep,LeadSourceId,ContactId,Amount,CloseDate,OpportunityStage,Possibility,ExpectedRevenue,CampaignSourceId,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opportunity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampaignSourceId = new SelectList(db.CampaignSources, "Id", "Name", opportunity.CampaignSourceId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner", opportunity.CompanyId);
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Owner", opportunity.ContactId);
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name", opportunity.LeadSourceId);
            return View(opportunity);
        }

        // GET: Opportunities/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opportunity opportunity = db.Opportunities.Find(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            return View(opportunity);
        }

        // POST: Opportunities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Opportunity opportunity = db.Opportunities.Find(id);
            db.Opportunities.Remove(opportunity);
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
