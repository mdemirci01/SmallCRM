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
    [Authorize]
    public class DocumentsController : Controller
    {
        private readonly IDocumentService documentService;


        public DocumentsController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }
        // GET: Documents
        public ActionResult Index()
        {
            var documents = Mapper.Map<IEnumerable<DocumentViewModel>>(documentService.GetAll());
            return View(documents);
        }

        // GET: Documents/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentViewModel document = Mapper.Map<DocumentViewModel>(documentService.Get(id.Value));
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Documents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Documents/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DocumentViewModel document)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Document>(document); //view modelden alınanı entity e dönüştürüyor.
                documentService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(document);
        }

        // GET: Documents/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentViewModel document = Mapper.Map<DocumentViewModel>(documentService.Get(id.Value));
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DocumentViewModel document)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Document>(document);
                documentService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(document);
        }

        // GET: Documents/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentViewModel document = Mapper.Map<DocumentViewModel>(documentService.Get(id.Value));
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            documentService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
