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
    public class ActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Activities
        public ActionResult Index()
        {
            var activities = db.Activities.Include(a => a.Campaign).Include(a => a.Company).Include(a => a.Contact).Include(a => a.Opportunity);
            return View(activities.ToList());
        }

        // GET: Activities/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: Activities/Create
        public ActionResult Create()
        {
            ViewBag.CampaignId = new SelectList(db.Campaigns, "Id", "Owner");
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner");
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Owner");
            ViewBag.OpportunityId = new SelectList(db.Opportunities, "Id", "Owner");
            return View();
        }

        // POST: Activities/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ContactFullName,Subject,CallReason,RelatedRecord,CallDirection,CallDetail,CallResult,ContactId,Description,CompanyName,CompanyTelephone,CompanyWebsite,CompanyId,OpportunityName,OpportunityAmount,OpportunityCloseDate,OpportunityType,OpportunityStage,OpportunityId,CampaignName,CampaignStatus,CampaignStartDate,CampaignEndDate,CampaignExpectedRevenue,CampaignId,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                activity.Id = Guid.NewGuid();
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CampaignId = new SelectList(db.Campaigns, "Id", "Owner", activity.CampaignId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner", activity.CompanyId);
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Owner", activity.ContactId);
            ViewBag.OpportunityId = new SelectList(db.Opportunities, "Id", "Owner", activity.OpportunityId);
            return View(activity);
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampaignId = new SelectList(db.Campaigns, "Id", "Owner", activity.CampaignId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner", activity.CompanyId);
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Owner", activity.ContactId);
            ViewBag.OpportunityId = new SelectList(db.Opportunities, "Id", "Owner", activity.OpportunityId);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ContactFullName,Subject,CallReason,RelatedRecord,CallDirection,CallDetail,CallResult,ContactId,Description,CompanyName,CompanyTelephone,CompanyWebsite,CompanyId,OpportunityName,OpportunityAmount,OpportunityCloseDate,OpportunityType,OpportunityStage,OpportunityId,CampaignName,CampaignStatus,CampaignStartDate,CampaignEndDate,CampaignExpectedRevenue,CampaignId,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampaignId = new SelectList(db.Campaigns, "Id", "Owner", activity.CampaignId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner", activity.CompanyId);
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Owner", activity.ContactId);
            ViewBag.OpportunityId = new SelectList(db.Opportunities, "Id", "Owner", activity.OpportunityId);
            return View(activity);
        }

        // GET: Activities/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
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
