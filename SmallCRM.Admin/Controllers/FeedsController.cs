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
    public class FeedsController : Controller
    {
        private readonly IFeedService feedService;
        private readonly IDocumentService documentService;

  
        public FeedsController(IFeedService feedService, IDocumentService documentService)
        {
            this.feedService = feedService;
            this.documentService = documentService;
        }
        // GET: Feeds
        public ActionResult Index()
        {
            var feeds = Mapper.Map<IEnumerable<FeedViewModel>>(feedService.GetAll());
            return View(feeds);
        }

        // GET: Feeds/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedViewModel feed = Mapper.Map<FeedViewModel>(feedService.Get(id.Value));
            if (feed == null)
            {
                return HttpNotFound();
            }
            return View(feed);
        }

        // GET: Feeds/Create
        public ActionResult Create()
        {
            ViewBag.DocumentId = new SelectList(documentService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Feeds/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedViewModel feed)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Feed>(feed);
                feedService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.DocumentId = new SelectList(documentService.GetAll(), "Id", "Name", feed.DocumentId);
            return View(feed);
        }

        // GET: Feeds/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedViewModel feed = Mapper.Map<FeedViewModel>(feedService.Get(id.Value));
            if (feed == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentId = new SelectList(documentService.GetAll(), "Id", "Name", feed.DocumentId);
            return View(feed);
        }

        // POST: Feeds/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FeedViewModel feed)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Feed>(feed);
                feedService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.DocumentId = new SelectList(documentService.GetAll(), "Id", "Name", feed.DocumentId);
            return View(feed);
        }

        // GET: Feeds/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedViewModel feed = Mapper.Map<FeedViewModel>(feedService.Get(id.Value));
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
            feedService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
