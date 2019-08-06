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
    public class CampaignSourcesController : Controller
    {
        private readonly ICampaignSourceService campaignSourceService;
       
        public CampaignSourcesController(ICampaignSourceService campaignSourceService)
        {
            this.campaignSourceService = campaignSourceService;
        }
        // GET: CampaignSources
        public ActionResult Index()
        {
            var campaignSources = Mapper.Map<IEnumerable<CampaignSourceViewModel>>(campaignSourceService.GetAll());
            return View(campaignSources);
        }

        // GET: CampaignSources/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           CampaignSourceViewModel campaignSource= Mapper.Map<CampaignSourceViewModel>(campaignSourceService.Get(id.Value));
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
        public ActionResult Create(CampaignSource campaignSource)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<CampaignSource>(campaignSource);
                campaignSourceService.Insert(entity);
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
            CampaignSourceViewModel campaignSource= Mapper.Map<CampaignSourceViewModel>(campaignSourceService.Get(id.Value));
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
        public ActionResult Edit(CampaignSource campaignSource)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<CampaignSource>(campaignSource);
               campaignSourceService.Update(entity);
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
            CampaignSourceViewModel campaignSource= Mapper.Map<CampaignSourceViewModel>(campaignSourceService.Get(id.Value));
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
            campaignSourceService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
