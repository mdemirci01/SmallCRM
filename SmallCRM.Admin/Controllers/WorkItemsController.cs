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
    public class WorkItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkItems
        public ActionResult Index()
        {
            var workItems = db.WorkItems.Include(w => w.Project);
            return View(workItems.ToList());
        }

        // GET: WorkItems/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItem workItem = db.WorkItems.Find(id);
            if (workItem == null)
            {
                return HttpNotFound();
            }
            return View(workItem);
        }

        // GET: WorkItems/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            return View();
        }

        // POST: WorkItems/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,AssignedTo,StartDate,EndDate,Category,WorkItemStatus,ProjectId,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] WorkItem workItem)
        {
            if (ModelState.IsValid)
            {
                workItem.Id = Guid.NewGuid();
                db.WorkItems.Add(workItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", workItem.ProjectId);
            return View(workItem);
        }

        // GET: WorkItems/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItem workItem = db.WorkItems.Find(id);
            if (workItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", workItem.ProjectId);
            return View(workItem);
        }

        // POST: WorkItems/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,AssignedTo,StartDate,EndDate,Category,WorkItemStatus,ProjectId,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] WorkItem workItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", workItem.ProjectId);
            return View(workItem);
        }

        // GET: WorkItems/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItem workItem = db.WorkItems.Find(id);
            if (workItem == null)
            {
                return HttpNotFound();
            }
            return View(workItem);
        }

        // POST: WorkItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            WorkItem workItem = db.WorkItems.Find(id);
            db.WorkItems.Remove(workItem);
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
