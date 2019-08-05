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
    public class CampaignSourcesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CampaignSources
        public ActionResult Index()
        {
            return View(db.CampaignSources.ToList());
        }

        // GET: CampaignSources/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampaignSource campaignSource = db.CampaignSources.Find(id);
            if (campaignSource == null)
            {
                return HttpNotFound();
            }
            return View(campaignSource);
        }

        // GET: CampaignSources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CampaignSources/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] CampaignSource campaignSource)
        {
            if (ModelState.IsValid)
            {
                campaignSource.Id = Guid.NewGuid();
                db.CampaignSources.Add(campaignSource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campaignSource);
        }

        // GET: CampaignSources/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampaignSource campaignSource = db.CampaignSources.Find(id);
            if (campaignSource == null)
            {
                return HttpNotFound();
            }
            return View(campaignSource);
        }

        // POST: CampaignSources/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] CampaignSource campaignSource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campaignSource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campaignSource);
        }

        // GET: CampaignSources/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampaignSource campaignSource = db.CampaignSources.Find(id);
            if (campaignSource == null)
            {
                return HttpNotFound();
            }
            return View(campaignSource);
        }

        // POST: CampaignSources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CampaignSource campaignSource = db.CampaignSources.Find(id);
            db.CampaignSources.Remove(campaignSource);
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
