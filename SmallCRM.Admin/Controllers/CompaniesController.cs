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
    public class CompaniesController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly ICompanyTypeService companyTypeService;
        private readonly ICityService cityService;
        private readonly ICountryService countryService;
        private readonly IRegionService regionService;
        private readonly ISectorService sectorService;



  
        public CompaniesController(ICompanyService companyService, ICompanyTypeService companyTypeService, ICityService cityService, ICountryService countryService, IRegionService regionService, ISectorService sectorService)
        {
            this.companyService = companyService;
            this.companyTypeService = companyTypeService;
            this.cityService = cityService;
            this.countryService = countryService;
            this.regionService = regionService;
            this.sectorService = sectorService;
        }
        // GET: Companies
        public ActionResult Index()
        {
            var companies = Mapper.Map<IEnumerable<CompanyViewModel>>(companyService.GetAll());
            return View(companies);
        }

        // GET: Companies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompanyViewModel company = Mapper.Map<CompanyViewModel>(companyService.Get(id.Value));

            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.CompanyTypeId = new SelectList(companyTypeService.GetAll(), "Id", "Name");
            ViewBag.DeliveryCityId = new SelectList(cityService.GetAll(), "Id", "Name");
            ViewBag.DeliveryCountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            ViewBag.DeliveryRegionId = new SelectList(regionService.GetAll(), "Id", "Name");
            ViewBag.InvoiceCityId = new SelectList(cityService.GetAll(), "Id", "Name");
            ViewBag.InvoiceCountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            ViewBag.InvoiceRegionId = new SelectList(regionService.GetAll(), "Id", "Name");
            ViewBag.MainCompanyId = new SelectList(companyService.GetAll(), "Id", "Owner");
            ViewBag.SectorId = new SelectList(sectorService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Company>(company);
                companyService.Insert(entity);
                return RedirectToAction("Index");
            }

         
            ViewBag.CompanyTypeId = new SelectList(companyTypeService.GetAll(), "Id", "Name", company.CompanyTypeId);
            ViewBag.DeliveryCityId = new SelectList(cityService.GetAll(), "Id", "Name", company.DeliveryCityId);
            ViewBag.DeliveryCountryId = new SelectList(countryService.GetAll(), "Id", "Name", company.DeliveryCountryId);
            ViewBag.DeliveryRegionId = new SelectList(regionService.GetAll(), "Id", "Name", company.DeliveryRegionId);
            ViewBag.InvoiceCityId = new SelectList(cityService.GetAll(), "Id", "Name", company.InvoiceCityId);
            ViewBag.InvoiceCountryId = new SelectList(countryService.GetAll(), "Id", "Name", company.InvoiceCountryId);
            ViewBag.InvoiceRegionId = new SelectList(regionService.GetAll(), "Id", "Name", company.InvoiceRegionId);
            ViewBag.MainCompanyId = new SelectList(companyService.GetAll(), "Id", "Owner", company.MainCompanyId);
            ViewBag.SectorId = new SelectList(sectorService.GetAll(), "Id", "Name", company.SectorId);
            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyViewModel company = Mapper.Map<CompanyViewModel>(companyService.Get(id.Value));
            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyTypeId = new SelectList(companyTypeService.GetAll(), "Id", "Name", company.CompanyTypeId);
            ViewBag.DeliveryCityId = new SelectList(cityService.GetAll(), "Id", "Name", company.DeliveryCityId);
            ViewBag.DeliveryCountryId = new SelectList(countryService.GetAll(), "Id", "Name", company.DeliveryCountryId);
            ViewBag.DeliveryRegionId = new SelectList(regionService.GetAll(), "Id", "Name", company.DeliveryRegionId);
            ViewBag.InvoiceCityId = new SelectList(cityService.GetAll(), "Id", "Name", company.InvoiceCityId);
            ViewBag.InvoiceCountryId = new SelectList(countryService.GetAll(), "Id", "Name", company.InvoiceCountryId);
            ViewBag.InvoiceRegionId = new SelectList(regionService.GetAll(), "Id", "Name", company.InvoiceRegionId);
            ViewBag.MainCompanyId = new SelectList(companyService.GetAll(), "Id", "Owner", company.MainCompanyId);
            ViewBag.SectorId = new SelectList(sectorService.GetAll(), "Id", "Name", company.SectorId);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Company>(company);
                companyService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CompanyTypeId = new SelectList(companyTypeService.GetAll(), "Id", "Name", company.CompanyTypeId);
            ViewBag.DeliveryCityId = new SelectList(cityService.GetAll(), "Id", "Name", company.DeliveryCityId);
            ViewBag.DeliveryCountryId = new SelectList(countryService.GetAll(), "Id", "Name", company.DeliveryCountryId);
            ViewBag.DeliveryRegionId = new SelectList(regionService.GetAll(), "Id", "Name", company.DeliveryRegionId);
            ViewBag.InvoiceCityId = new SelectList(cityService.GetAll(), "Id", "Name", company.InvoiceCityId);
            ViewBag.InvoiceCountryId = new SelectList(countryService.GetAll(), "Id", "Name", company.InvoiceCountryId);
            ViewBag.InvoiceRegionId = new SelectList(regionService.GetAll(), "Id", "Name", company.InvoiceRegionId);
            ViewBag.MainCompanyId = new SelectList(companyService.GetAll(), "Id", "Owner", company.MainCompanyId);
            ViewBag.SectorId = new SelectList(sectorService.GetAll(), "Id", "Name", company.SectorId);
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyViewModel company = Mapper.Map<CompanyViewModel>(companyService.Get(id.Value));
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            companyService.Delete(id);
            return RedirectToAction("Index");
        }

      
    }
}
