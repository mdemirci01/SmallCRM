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
    public class LeadStatusesController : Controller
    {
        private readonly ILeadStatusService leadStatusService;

        // GET: LeadStatus
        public LeadStatusesController(ILeadStatusService leadStatusService)
        {
            this.leadStatusService = leadStatusService;
        }
        public ActionResult Index()
        {
            var leadStatuses = Mapper.Map<IEnumerable<LeadStatusViewModel>>(leadStatusService.GetAll());
            return View(leadStatuses);
        }

        // GET: LeadStatus/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadStatusViewModel leadStatus = Mapper.Map<LeadStatusViewModel>(leadStatusService.Get
(id.Value));
            if (leadStatus == null)
            {
                return HttpNotFound();
            }
            return View(leadStatus);
        }

        // GET: LeadStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeadStatus/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeadStatusViewModel leadStatus)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<LeadStatus>(leadStatus);
                leadStatusService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(leadStatus);
        }

        // GET: LeadStatus/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadStatusViewModel leadStatus = Mapper.Map<LeadStatusViewModel>(leadStatusService.Get
(id.Value));
            if (leadStatus == null)
            {
                return HttpNotFound();
            }
            return View(leadStatus);
        }

        // POST: LeadStatus/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeadStatusViewModel leadStatus)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<LeadStatus>(leadStatus);
                leadStatusService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(leadStatus);
        }

        // GET: LeadStatus/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadStatusViewModel leadStatus = Mapper.Map<LeadStatusViewModel>(leadStatusService.Get
(id.Value));
            if (leadStatus == null)
            {
                return HttpNotFound();
            }
            return View(leadStatus);
        }

        // POST: LeadStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            leadStatusService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
