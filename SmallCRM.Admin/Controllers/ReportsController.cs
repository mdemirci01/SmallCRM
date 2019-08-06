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
    public class ReportsController : Controller
    {
        private readonly IReportService reportService;
        public ReportsController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reports
        public ActionResult Index()
        {
            var report = Mapper.Map<IEnumerable<ReportViewModel>>(reportService.GetAll());
            return View(report);
        }

        // GET: Reports/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportViewModel report = Mapper.Map<ReportViewModel>(reportService.Get(id.Value));
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // GET: Reports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReportViewModel report)
        {
            if (ModelState.IsValid)
            {

                var entity = Mapper.Map<Report>(report);
                reportService.Insert(entity);
                return RedirectToAction("Index");

            }

            return View(report);
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
              ReportViewModel report = Mapper.Map<ReportViewModel>(reportService.Get(id.Value));
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReportViewModel report)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Report>(report);
                reportService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(report);
        }

        // GET: Reports/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportViewModel report = Mapper.Map<ReportViewModel>(reportService.Get(id.Value));
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            reportService.Delete(id);
            return RedirectToAction("Index");
        }

      
    }
}
