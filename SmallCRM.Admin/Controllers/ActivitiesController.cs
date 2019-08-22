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
    public class ActivitiesController : Controller
    {
        private readonly IActivityService activityService;
        private readonly ICampaignService campaignService;
        private readonly ICompanyService companyService;
        private readonly IContactService contactService;
        private readonly IOpportunityService opportunityService;

        public ActivitiesController(IActivityService activityService, ICampaignService campaignService, ICompanyService companyService, IContactService contactService, IOpportunityService opportunityService)
        {
            this.activityService = activityService;
            this.campaignService = campaignService;
            this.companyService = companyService;
            this.contactService = contactService;
            this.opportunityService = opportunityService;
        }
        // GET: Activities
        public ActionResult Index()
        {
            var activities = Mapper.Map<IEnumerable<ActivityViewModel>>(activityService.GetAll());
            return View(activities);
        }

        // GET: Activities/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityViewModel activity = Mapper.Map<ActivityViewModel>(activityService.Get(id.Value));
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: Activities/Create
        public ActionResult Create()
        {
            ViewBag.CampaignId = new SelectList(campaignService.GetAll(), "Id", "Name");
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name");
            ViewBag.Companies = companyService.GetAll();
            ViewBag.ContactId = new SelectList(contactService.GetAll(), "Id", "FullName");
            ViewBag.OpportunityId = new SelectList(opportunityService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Activities/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActivityViewModel activity)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Activity>(activity);
                activityService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CampaignId = new SelectList(campaignService.GetAll(), "Id", "Name", activity.CampaignId);
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", activity.CompanyId);
            ViewBag.Companies = companyService.GetAll();
            ViewBag.ContactId = new SelectList(contactService.GetAll(), "Id", "FullName", activity.ContactId);
            ViewBag.OpportunityId = new SelectList(opportunityService.GetAll(), "Id", "Name", activity.OpportunityId);
            return View(activity);
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityViewModel activity = Mapper.Map<ActivityViewModel>(activityService.Get(id.Value));
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampaignId = new SelectList(campaignService.GetAll(), "Id", "Name", activity.CampaignId);
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", activity.CompanyId);
            ViewBag.Companies = companyService.GetAll();
            ViewBag.ContactId = new SelectList(contactService.GetAll(), "Id", "FullName", activity.ContactId);
            ViewBag.OpportunityId = new SelectList(opportunityService.GetAll(), "Id", "Name", activity.OpportunityId);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ActivityViewModel activity)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Activity>(activity);
                activityService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CampaignId = new SelectList(campaignService.GetAll(), "Id", "Name", activity.CampaignId);
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", activity.CompanyId);
            ViewBag.Companies = companyService.GetAll();
            ViewBag.ContactId = new SelectList(contactService.GetAll(), "Id", "FullName", activity.ContactId);
            ViewBag.OpportunityId = new SelectList(opportunityService.GetAll(), "Id", "Name", activity.OpportunityId);
            return View(activity);
        }

        [HttpPost]
        public ActionResult AddCompany(string companyName, string companyPhone, string companyWebsite)
        {
            try
            {
                var company = new Company();
                company.Name = companyName;
                company.Telephone = companyPhone;
                company.Website = companyWebsite;
                companyService.Insert(company);
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
        [HttpPost]
        public ActionResult GetCompanies()
        {
            return Json(Mapper.Map<IEnumerable<CompanyViewModel>>(companyService.GetAll()));
        }

        [HttpPost]
        public ActionResult AddOpportunity(decimal opportunityAmount, OpportunityStage opportunityStage, DateTime opportunityCloseDate, Guid companyId , string opportunityName)
        {
            try
            {
                var opportunity = new Opportunity();

                opportunity.Amount = opportunityAmount;
                opportunity.OpportunityStage = opportunityStage;
                opportunity.CloseDate = opportunityCloseDate;
                opportunity.CompanyId = companyId;
                opportunity.Name = opportunityName;
                opportunityService.Insert(opportunity);
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
        [HttpPost]
        public ActionResult GetOpportunities()
        {
            return Json(Mapper.Map<IEnumerable<OpportunityViewModel>>(opportunityService.GetAll()));
        }
        public ActionResult AddCampaign(OpportunityType opportunityType, string campaignName, CampaignStatus? campaignStatus, DateTime startDate, DateTime endDate, decimal expectedRevenue)
        {
            try
            {
                var campaign = new Campaign();

                campaign.OpportunityType = opportunityType;
                campaign.Name = campaignName;
                campaign.CampaignStatus = campaignStatus;
                campaign.StartDate = startDate;
                campaign.EndDate = endDate;
                campaign.ExpectedRevenue = expectedRevenue;
                campaignService.Insert(campaign);
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
        [HttpPost]
        public ActionResult GetCampaigns()
        {
            return Json(Mapper.Map<IEnumerable<CampaignViewModel>>(campaignService.GetAll()));
        }
        // GET: Activities/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityViewModel activity = Mapper.Map<ActivityViewModel>(activityService.Get(id.Value));
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            activityService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
