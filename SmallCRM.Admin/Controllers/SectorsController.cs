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
    public class SectorsController : Controller
    {
        private readonly ISectorService sectorService;
        
        public SectorsController(ISectorService sectorService)
        {
            this.sectorService = sectorService;
        }

        // GET: Sectors
        public ActionResult Index()
        {
            var sectors = Mapper.Map<IEnumerable<SectorViewModel>>(sectorService.GetAll());
            return View(sectors);
        }

        // GET: Sectors/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectorViewModel sector = Mapper.Map<SectorViewModel>(sectorService.Get(id.Value));
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // GET: Sectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SectorViewModel sector)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Sector>(sector);
                sectorService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(sector);
        }

        // GET: Sectors/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            SectorViewModel sector = Mapper.Map<SectorViewModel>(sectorService.Get(id.Value));
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // POST: Sectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SectorViewModel sector)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Sector>(sector);
                sectorService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(sector);
        }

        // GET: Sectors/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectorViewModel sector = Mapper.Map<SectorViewModel>(sectorService.Get(id.Value));
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // POST: Sectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            sectorService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
