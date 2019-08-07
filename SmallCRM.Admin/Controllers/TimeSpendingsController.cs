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
    public class TimeSpendingsController : Controller
    {
        private readonly ITimeSpendingService timeSpendingService;
        private readonly IProjectService projectService;
        private readonly IWorkItemService workItemService;
        private ApplicationDbContext db = new ApplicationDbContext();
        public TimeSpendingsController(ITimeSpendingService timeSpendingService)
        {
            this.timeSpendingService = timeSpendingService;
        }
        // GET: TimeSpendings
        public ActionResult Index()
        {
            var timeSpendings = Mapper.Map<IEnumerable<TimeSpendingViewModel>>(timeSpendingService.GetAll());
            return View(timeSpendings);
        }

        // GET: TimeSpendings/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSpendingViewModel timeSpending = Mapper.Map<TimeSpendingViewModel>(timeSpendingService.Get(id.Value));
            if (timeSpending == null)
            {
                return HttpNotFound();
            }
            return View(timeSpending);
        }

        // GET: TimeSpendings/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(projectService.GetAll(), "Id", "Name");
            ViewBag.WorkItemId = new SelectList(workItemService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: TimeSpendings/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TimeSpendingViewModel timeSpending)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<TimeSpending>(timeSpending);
                timeSpendingService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(projectService.GetAll(), "Id", "Name", timeSpending.ProjectId);
            ViewBag.WorkItemId = new SelectList(workItemService.GetAll(), "Id", "Name", timeSpending.WorkItemId);
            return View(timeSpending);
        }

        // GET: TimeSpendings/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSpendingViewModel timeSpending = Mapper.Map<TimeSpendingViewModel>(timeSpendingService.Get(id.Value));
            if (timeSpending == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(projectService.GetAll(), "Id", "Name", timeSpending.ProjectId);
            ViewBag.WorkItemId = new SelectList(workItemService.GetAll(), "Id", "Name", timeSpending.WorkItemId);
            return View(timeSpending);
        }

        // POST: TimeSpendings/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TimeSpendingViewModel timeSpending)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<TimeSpending>(timeSpending);
                timeSpendingService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(projectService.GetAll(), "Id", "Name", timeSpending.ProjectId);
            ViewBag.WorkItemId = new SelectList(workItemService.GetAll(), "Id", "Name", timeSpending.WorkItemId);
            return View(timeSpending);
        }

        // GET: TimeSpendings/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSpendingViewModel timeSpending = Mapper.Map<TimeSpendingViewModel>(timeSpendingService.Get(id.Value));
            if (timeSpending == null)
            {
                return HttpNotFound();
            }
            return View(timeSpending);
        }

        // POST: TimeSpendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            timeSpendingService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
