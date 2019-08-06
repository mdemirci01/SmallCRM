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
    public class RegionsController : Controller
    {
        private readonly IRegionService regionService;
        private ApplicationDbContext db = new ApplicationDbContext();

        public RegionsController(IRegionService regionService)
        {
            this.regionService = regionService;
        }
        // GET: Regions
        public ActionResult Index()
        {
            var regions = Mapper.Map<IEnumerable<RegionViewModel>>(regionService.GetAll());
            return View(regions);
        }

        // GET: Regions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionViewModel region = Mapper.Map<RegionViewModel>(regionService.Get(id.Value));
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // GET: Regions/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            return View();
        }

        // POST: Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegionViewModel region)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Region>(region);
                regionService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", region.CityId);
            return View(region);
        }

        // GET: Regions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionViewModel region = Mapper.Map<RegionViewModel>(regionService.Get(id.Value));
            if (region == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", region.CityId);
            return View(region);
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RegionViewModel region)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Region>(region);
                regionService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", region.CityId);
            return View(region);
        }

        // GET: Regions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionViewModel region = Mapper.Map<RegionViewModel>(regionService.Get(id.Value)); ;
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            regionService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
