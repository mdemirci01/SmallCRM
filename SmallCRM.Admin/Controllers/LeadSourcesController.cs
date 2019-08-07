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
    public class LeadSourcesController : Controller
    {
        private readonly ILeadSourceService leadSourceService;
       

        public LeadSourcesController(ILeadSourceService leadSourceService)
        {
            this.leadSourceService = leadSourceService;
        }
        // GET: LeadSources
        public ActionResult Index()
        {
            var leadSources = Mapper.Map<IEnumerable<LeadSourceViewModel>>(leadSourceService.GetAll());
            return View(leadSources);
        }

        // GET: LeadSources/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadSourceViewModel leadSource = Mapper.Map<LeadSourceViewModel>(leadSourceService.Get(id.Value));
            if (leadSource == null)
            {
                return HttpNotFound();
            }
            return View(leadSource);
        }

        // GET: LeadSources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeadSources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeadSourceViewModel leadSource)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<LeadSource>(leadSource);
                leadSourceService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(leadSource);
        }

        // GET: LeadSources/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadSourceViewModel leadSource = Mapper.Map<LeadSourceViewModel>(leadSourceService.Get(id.Value));
            if (leadSource == null)
            {
                return HttpNotFound();
            }
            return View(leadSource);
        }

        // POST: LeadSources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeadSourceViewModel leadSource)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<LeadSource>(leadSource);
                leadSourceService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(leadSource);
        }

        // GET: LeadSources/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadSourceViewModel leadSource = Mapper.Map<LeadSourceViewModel>(leadSourceService.Get(id.Value));
            if (leadSource == null)
            {
                return HttpNotFound();
            }
            return View(leadSource);
        }

        // POST: LeadSources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            leadSourceService.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
