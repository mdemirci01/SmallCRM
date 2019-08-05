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
    public class FeedsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Feeds
        public ActionResult Index()
        {
            var feeds = db.Feeds.Include(f => f.Document);
            return View(feeds.ToList());
        }

        // GET: Feeds/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = db.Feeds.Find(id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            return View(feed);
        }

        // GET: Feeds/Create
        public ActionResult Create()
        {
            ViewBag.DocumentId = new SelectList(db.Documents, "Id", "Name");
            return View();
        }

        // POST: Feeds/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Message,DocumentId,IsRead,TargetUser,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Feed feed)
        {
            if (ModelState.IsValid)
            {
                feed.Id = Guid.NewGuid();
                db.Feeds.Add(feed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocumentId = new SelectList(db.Documents, "Id", "Name", feed.DocumentId);
            return View(feed);
        }

        // GET: Feeds/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = db.Feeds.Find(id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentId = new SelectList(db.Documents, "Id", "Name", feed.DocumentId);
            return View(feed);
        }

        // POST: Feeds/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Message,DocumentId,IsRead,TargetUser,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Feed feed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocumentId = new SelectList(db.Documents, "Id", "Name", feed.DocumentId);
            return View(feed);
        }

        // GET: Feeds/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = db.Feeds.Find(id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            return View(feed);
        }

        // POST: Feeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Feed feed = db.Feeds.Find(id);
            db.Feeds.Remove(feed);
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
