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
    public class CampaignsController : Controller
    {
        private readonly ICampaignService campaignService;

        public CampaignsController(ICampaignService campaignService)
        {
            this.campaignService = campaignService;
        }
        // GET: Campaigns
        public ActionResult Index()
        {
            var campaigns = Mapper.Map<IEnumerable<CampaignViewModel>>(campaignService.GetAll());
            return View(campaigns);
        }

        // GET: Campaigns/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampaignViewModel campaign = Mapper.Map<CampaignViewModel>(campaignService.Get(id.Value));
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // GET: Campaigns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campaigns/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( CampaignViewModel campaign)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Campaign>(campaign);
                campaignService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(campaign);
        }

        // GET: Campaigns/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampaignViewModel campaign = Mapper.Map<CampaignViewModel>(campaignService.Get(id.Value));
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // POST: Campaigns/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CampaignViewModel campaign)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Campaign>(campaign);
                campaignService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(campaign);
        }

        // GET: Campaigns/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampaignViewModel campaign = Mapper.Map<CampaignViewModel>(campaignService.Get(id.Value));
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // POST: Campaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            campaignService.Delete(id);
            return RedirectToAction("Index");
        }

     
    }
}
