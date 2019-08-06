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
    public class CitiesController : Controller     
    {

        private readonly ICountryService countryService;
        private readonly ICityService cityService;

        private ApplicationDbContext db = new ApplicationDbContext();
        public CitiesController(ICityService cityService, ICountryService countryService)
        {
            this.countryService = countryService;
            this.cityService = cityService;
        }

        // GET: Cities
        public ActionResult Index()
        {
            var cities = Mapper.Map<IEnumerable<CityViewModel>>(cityService.GetAll());
            return View(cities);
        }

        // GET: Cities/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityViewModel city = Mapper.Map<CityViewModel>(cityService.Get(id.Value));
            
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityViewModel city)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<City>(city);
                cityService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", city.CountryId);
            return View(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityViewModel city = Mapper.Map<CityViewModel>(cityService.Get(id.Value));
            if (city == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", city.CountryId);
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CityViewModel city)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<City>(city);
                cityService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", city.CountryId);
            return View(city);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityViewModel city = Mapper.Map<CityViewModel>(cityService.Get(id.Value));
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            cityService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
