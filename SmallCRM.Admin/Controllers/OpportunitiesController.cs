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
using static SmallCRM.Service.ContactService;

namespace SmallCRM.Admin.Controllers
{
    public class OpportunitiesController : Controller
    {
        private readonly IOpportunityService opportunityService;
        private readonly ICampaignSourceService campaignSourceService;
        private readonly ICompanyService companyService;
        private readonly IContactService contactService;
        private readonly ILeadSourceService leadSourceService;
       

        public OpportunitiesController(IOpportunityService opportunityService, ICampaignSourceService campaignSourceService, ICompanyService companyService, IContactService contactService, ILeadSourceService leadSourceService)
        {
            this.opportunityService = opportunityService;
            this.campaignSourceService = campaignSourceService;
            this.companyService = companyService;
            this.contactService = contactService;
            this.leadSourceService = leadSourceService;
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
            ViewBag.CampaignSourceId = new SelectList(campaignSourceService.GetAll(), "Id", "Name");
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name");
            ViewBag.ContactId = new SelectList(contactService.GetAll(), "Id", "FullName");
            ViewBag.LeadSourceId = new SelectList(leadSourceService.GetAll(), "Id", "Name");
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

            ViewBag.CampaignSourceId = new SelectList(campaignSourceService.GetAll(), "Id", "Name");
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Owner");
            ViewBag.ContactId = new SelectList(contactService.GetAll(), "Id", "Owner");
            ViewBag.LeadSourceId = new SelectList(leadSourceService.GetAll(), "Id", "Name");
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
            ViewBag.CampaignSourceId = new SelectList(campaignSourceService.GetAll(), "Id", "Name");
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Owner");
            ViewBag.ContactId = new SelectList(contactService.GetAll(), "Id", "Owner");
            ViewBag.LeadSourceId = new SelectList(leadSourceService.GetAll(), "Id", "Name");
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
            ViewBag.CampaignSourceId = new SelectList(campaignSourceService.GetAll(), "Id", "Name");
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Owner");
            ViewBag.ContactId = new SelectList(contactService.GetAll(), "Id", "Owner");
            ViewBag.LeadSourceId = new SelectList(leadSourceService.GetAll(), "Id", "Name");
            return View(opportunity);
        }

        // GET: Opportunities/Delete/5
        public ActionResult Delete(Guid? id)
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
