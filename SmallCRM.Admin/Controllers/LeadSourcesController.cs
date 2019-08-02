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
    public class LeadSourcesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LeadSources
        public ActionResult Index()
        {
            return View(db.LeadSources.ToList());
        }

        // GET: LeadSources/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadSource leadSource = db.LeadSources.Find(id);
            if (leadSource == null)
            {
                return HttpNotFound();
            }
            return View(leadSource);
        }

        // GET: LeadSources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeadSources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] LeadSource leadSource)
        {
            if (ModelState.IsValid)
            {
                leadSource.Id = Guid.NewGuid();
                db.LeadSources.Add(leadSource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leadSource);
        }

        // GET: LeadSources/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadSource leadSource = db.LeadSources.Find(id);
            if (leadSource == null)
            {
                return HttpNotFound();
            }
            return View(leadSource);
        }

        // POST: LeadSources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] LeadSource leadSource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leadSource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leadSource);
        }

        // GET: LeadSources/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadSource leadSource = db.LeadSources.Find(id);
            if (leadSource == null)
            {
                return HttpNotFound();
            }
            return View(leadSource);
        }

        // POST: LeadSources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            LeadSource leadSource = db.LeadSources.Find(id);
            db.LeadSources.Remove(leadSource);
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
