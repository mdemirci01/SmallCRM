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
    public class CountriesController : Controller
    {
        private readonly ICountryService countryService;
        
        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }
        // GET: Countries
        public ActionResult Index()
        {
            var countries = Mapper.Map<IEnumerable<CountryViewModel>>(countryService.GetAll());
            return View(countries);
        }

        // GET: Countries/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryViewModel country = Mapper.Map<CountryViewModel>(countryService.Get(id.Value));
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryViewModel country)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Country>(country);
                countryService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(country);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryViewModel country = Mapper.Map<CountryViewModel>(countryService.Get(id.Value));
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CountryViewModel country)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Country>(country);
                countryService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryViewModel country = Mapper.Map<CountryViewModel>(countryService.Get(id.Value));
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            countryService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
