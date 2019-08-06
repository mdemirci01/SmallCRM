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

namespace SmallCRM.Admin.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly IActivityService activityService;

        private ApplicationDbContext db = new ApplicationDbContext();
        public ActivitiesController(IActivityService activityService)
        {
            this.activityService = activityService;
        }
        // GET: Activities
        public ActionResult Index()
        {
            var activities = Mapper.Map<IEnumerable<ActivityViewModel>>(activityService.GetAll());
            return View(activities);
        }

        // GET: Activities/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityViewModel activity = Mapper.Map<ActivityViewModel>(activityService.Get(id.Value));
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
        public ActionResult Create(ActivityViewModel activity)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Activity>(activity);
                activityService.Insert(entity);
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
            ActivityViewModel activity = Mapper.Map<ActivityViewModel>(activityService.Get(id.Value));
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
        public ActionResult Edit(ActivityViewModel activity)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Activity>(activity);
                activityService.Update(entity);
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
            ActivityViewModel activity = Mapper.Map<ActivityViewModel>(activityService.Get(id.Value));
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
            activityService.Delete(id);
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
