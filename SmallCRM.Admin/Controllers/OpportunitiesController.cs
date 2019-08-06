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
    public class OpportunitiesController : Controller
    {
        private readonly IOpportunityService opportunityService;
        private ApplicationDbContext db = new ApplicationDbContext();

        public OpportunitiesController(IOpportunityService opportunityService)
        {
            this.opportunityService = opportunityService;
        }

        // GET: Opportunities
        public ActionResult Index()
        {
            var opportunities = Mapper.Map<IEnumerable<OpportunityViewModel>>(opportunityService.GetAll());
            return View(opportunities);
        }

        // GET: Opportunities/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpportunityViewModel opportunity = Mapper.Map<OpportunityViewModel>(opportunityService.Get(id.Value));
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            return View(opportunity);
        }

        // GET: Opportunities/Create
        public ActionResult Create()
        {
            ViewBag.CampaignSourceId = new SelectList(db.CampaignSources, "Id", "Name");
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner");
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Owner");
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name");
            return View();
        }

        // POST: Opportunities/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OpportunityViewModel opportunity)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Opportunity>(opportunity); //view modelden alınanı entity e dönüştürüyor.
                opportunityService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CampaignSourceId = new SelectList(db.CampaignSources, "Id", "Name", opportunity.CampaignSourceId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner", opportunity.CompanyId);
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Owner", opportunity.ContactId);
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name", opportunity.LeadSourceId);
            return View(opportunity);
        }

        // GET: Opportunities/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpportunityViewModel opportunity = Mapper.Map<OpportunityViewModel>(opportunityService.Get(id.Value));

            if (opportunity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampaignSourceId = new SelectList(db.CampaignSources, "Id", "Name", opportunity.CampaignSourceId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner", opportunity.CompanyId);
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Owner", opportunity.ContactId);
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name", opportunity.LeadSourceId);
            return View(opportunity);
        }

        // POST: Opportunities/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( OpportunityViewModel opportunity)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Opportunity>(opportunity);
                opportunityService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CampaignSourceId = new SelectList(db.CampaignSources, "Id", "Name", opportunity.CampaignSourceId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Owner", opportunity.CompanyId);
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Owner", opportunity.ContactId);
            ViewBag.LeadSourceId = new SelectList(db.LeadSources, "Id", "Name", opportunity.LeadSourceId);
            return View(opportunity);
        }

        // GET: Opportunities/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpportunityViewModel opportunity = Mapper.Map<OpportunityViewModel>(opportunityService.Get(id.Value)); ;
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            return View(opportunity);
        }

        // POST: Opportunities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            opportunityService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
