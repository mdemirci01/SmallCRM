using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
        public ActionResult Create(DocumentViewModel document, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // yüklenen dosyanın adını entity'deki alana ata
                    document.File = UploadFile(upload);
                }
                catch (Exception ex)
                {
                    // upload sırasında bir hata oluşursa View'da görüntülemek üzere hatayı değişkene ekle
                    ViewBag.Error = ex.Message;                    
                    // hata oluştuğu için projeyi veritabanına eklemek yerine View'ı tekrar göster ve metottan çık
                    return View(document);
                }
                var entity = Mapper.Map<Document>(document); //view modelden alınanı entity e dönüştürüyor.
                documentService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(document);
        }
        public string UploadFile(HttpPostedFileBase upload)
        {
            // yüklenmek istenen dosya var mı?
            if (upload != null && upload.ContentLength > 0)
            {
                // dosyanın uzantısını kontrol et
                var extension = Path.GetExtension(upload.FileName).ToLower();
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".png" || extension == ".pdf" || extension == ".zip" || extension == ".rar" || extension == ".mp3" || extension == ".mp4" || extension == ".docx" || extension == ".doc" || extension == ".pptx" || extension == ".xlsx" || extension == ".txt" || extension == ".rtf")
                {
                    // uzantı doğruysa dosyanın yükleneceği Uploads dizini var mı kontrol et
                    if (Directory.Exists(Server.MapPath("~/Uploads")))
                    {
                        // dosya adındaki geçersiz karakterleri düzelt
                        string fileName = upload.FileName.ToLower();
                        fileName = fileName.Replace("İ", "i");
                        fileName = fileName.Replace("Ş", "s");
                        fileName = fileName.Replace("Ğ", "g");
                        fileName = fileName.Replace("ğ", "g");
                        fileName = fileName.Replace("ı", "i");
                        fileName = fileName.Replace("(", "");
                        fileName = fileName.Replace(")", "");
                        fileName = fileName.Replace(" ", "-");
                        fileName = fileName.Replace(",", "");
                        fileName = fileName.Replace("ö", "o");
                        fileName = fileName.Replace("ü", "u");
                        fileName = fileName.Replace("`", "");
                        // aynı isimde dosya olabilir diye dosya adının önüne zaman pulu ekliyoruz
                        fileName = DateTime.Now.Ticks.ToString() + fileName;

                        // dosyayı Uploads dizinine yükle
                        upload.SaveAs(Path.Combine(Server.MapPath("~/Uploads"), fileName));

                        // yüklenen dosyanın adını geri döndür
                        return fileName;
                    }
                    else
                    {
                        throw new Exception("Uploads dizini mevcut değil.");
                    }
                }
                else
                {
                    throw new Exception("Dosya uzantısı geçerli değil.");
                }
            }
            return null;
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
        public ActionResult Edit(DocumentViewModel document, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0) { 
                        // yüklenen dosyanın adını entity'deki alana ata
                        document.File = UploadFile(upload);
                    }
                }
                catch (Exception ex)
                {
                    // upload sırasında bir hata oluşursa View'da görüntülemek üzere hatayı değişkene ekle
                    ViewBag.Error = ex.Message;
                    
                    // hata oluştuğu için projeyi veritabanına eklemek yerine View'ı tekrar göster ve metottan çık
                    return View(document);
                }
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
