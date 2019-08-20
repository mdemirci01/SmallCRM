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
using SmallCRM.Model;
using SmallCRM.Service;

namespace SmallCRM.Admin.Controllers
{
    [Authorize]
    public class LeadsController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ILeadService _leadService;
        private readonly ILeadSourceService _leadSourceService;
        private readonly ILeadStatusService _leadStatusService;
        private readonly IRegionService _regionService;
        private readonly ISectorService _sectorService;
        private readonly ICountryService _countryService;
        public LeadsController(ILeadService leadService, ICountryService countryService, ISectorService sectorService, ICityService cityService, IRegionService regionService, ILeadSourceService leadSourceService, ILeadStatusService leadStatusService)
        {
            this._leadService = leadService;
            this._cityService = cityService;
            this._leadSourceService = leadSourceService;
            this._leadStatusService = leadStatusService;
            this._regionService = regionService;
            this._sectorService = sectorService;
            this._countryService = countryService;
        }

        // GET: Leads
        public ActionResult Index()
        {
            var leads = Mapper.Map<IEnumerable<LeadViewModel>>(_leadService.GetAll());
            return View(leads);
        }

        [HttpPost]
        public ActionResult GetCities(Guid countryId)
        {
            var cities = Mapper.Map<IEnumerable<CityViewModel>>(_cityService.GetAllByCountryId(countryId));
            return Json(cities);
        }
        [HttpPost]
        public ActionResult GetRegions(Guid cityId)
        {
            var region = Mapper.Map<IEnumerable<RegionViewModel>>(_regionService.GetAllByCityId(cityId));
            return Json(region);
        }


        // GET: Leads/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadViewModel lead = Mapper.Map<LeadViewModel>(_leadService.Get(id.Value));
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        // GET: Leads/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(_countryService.GetAll(), "Id", "Name");
            ViewBag.CityId = new SelectList(_cityService.GetAllByCountryId(Guid.NewGuid()), "Id", "Name");
            ViewBag.RegionId = new SelectList(_regionService.GetAllByCityId(Guid.NewGuid()), "Id", "Name");
            ViewBag.LeadSourceId = new SelectList(_leadSourceService.GetAll(), "Id", "Name");
            ViewBag.LeadStatusId = new SelectList(_leadStatusService.GetAll(), "Id", "Name");
            ViewBag.SectorId = new SelectList(_sectorService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Leads/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeadViewModel lead)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Lead>(lead);
                _leadService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(_countryService.GetAll(), "Id", "Name",lead.CountryId);
            ViewBag.CityId = new SelectList(_cityService.GetAllByCountryId( lead.CountryId ?? Guid.NewGuid()) ,"Id", "Name",lead.CityId);
            ViewBag.RegionId = new SelectList(_regionService.GetAllByCityId(lead.CityId??Guid.NewGuid()), "Id", "Name",lead.RegionId);
            ViewBag.LeadSourceId = new SelectList(_leadSourceService.GetAll(), "Id", "Name", lead.LeadSourceId);
            ViewBag.LeadStatusId = new SelectList(_leadStatusService.GetAll(), "Id", "Name", lead.LeadStatusId);
            ViewBag.SectorId = new SelectList(_sectorService.GetAll(), "Id", "Name", lead.SectorId);
            return View(lead);
        }

        // GET: Leads/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadViewModel lead = Mapper.Map<LeadViewModel>(_leadService.Get(id.Value));
            if (lead == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(_countryService.GetAll(), "Id", "Name",lead.CountryId);
            ViewBag.CityId = new SelectList(_cityService.GetAllByCountryId( lead.CountryId ?? Guid.NewGuid()) ,"Id", "Name",lead.CityId);
            ViewBag.RegionId = new SelectList(_regionService.GetAllByCityId(lead.CityId??Guid.NewGuid()), "Id", "Name",lead.RegionId);
            ViewBag.LeadSourceId = new SelectList(_leadSourceService.GetAll(), "Id", "Name", lead.LeadSourceId);
            ViewBag.LeadStatusId = new SelectList(_leadStatusService.GetAll(), "Id", "Name", lead.LeadStatusId);
            ViewBag.SectorId = new SelectList(_sectorService.GetAll(), "Id", "Name", lead.SectorId);
            return View(lead);
        }

        // POST: Leads/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeadViewModel lead)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Lead>(lead);
                _leadService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(_countryService.GetAll(), "Id", "Name",lead.CountryId);
            ViewBag.CityId = new SelectList(_cityService.GetAllByCountryId( lead.CountryId ?? Guid.NewGuid()) ,"Id", "Name",lead.CityId);
            ViewBag.RegionId = new SelectList(_regionService.GetAllByCityId(lead.CityId??Guid.NewGuid()), "Id", "Name",lead.RegionId);
            ViewBag.LeadSourceId = new SelectList(_leadSourceService.GetAll(), "Id", "Name", lead.LeadSourceId);
            ViewBag.LeadStatusId = new SelectList(_leadStatusService.GetAll(), "Id", "Name", lead.LeadStatusId);
            ViewBag.SectorId = new SelectList(_sectorService.GetAll(), "Id", "Name", lead.SectorId);
            return View(lead);
        }

        // GET: Leads/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadViewModel lead = Mapper.Map<LeadViewModel>(_leadService.Get(id.Value));
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        // POST: Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _leadService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
