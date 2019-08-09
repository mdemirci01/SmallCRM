using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using SmallCRM.Admin.Models;
using SmallCRM.Model;
using SmallCRM.Service;

namespace SmallCRM.Admin.Controllers
{
    [Authorize]
    public class WorkItemsController : Controller
    {
        private readonly IWorkItemService _workItemService;
        private readonly IProjectService _projectService;

        public WorkItemsController(IWorkItemService workItemService,IProjectService projectService)
        {
            this._workItemService = workItemService;
            this._projectService = projectService;
        }

        // GET: WorkItems
        public ActionResult Index()
        {
            var workItems = Mapper.Map<IEnumerable<WorkItemViewModel>>(_workItemService.GetAll());
            return View(workItems);
        }

        // GET: WorkItems/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItemViewModel workItem = Mapper.Map<WorkItemViewModel>(_workItemService.Get(id.Value));
            if (workItem == null)
            {
                return HttpNotFound();
            }
            return View(workItem);
        }

        // GET: WorkItems/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(_projectService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: WorkItems/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkItemViewModel workItem)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<WorkItem>(workItem);
                _workItemService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(_projectService.GetAll(), "Id", "Name", workItem.ProjectId);
            return View(workItem);
        }

        // GET: WorkItems/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItemViewModel workItem =Mapper.Map<WorkItemViewModel>(_workItemService.Get(id.Value));
            if (workItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(_projectService.GetAll(), "Id", "Name", workItem.ProjectId);
            return View(workItem);
        }

        // POST: WorkItems/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkItemViewModel workItem)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<WorkItem>(workItem);
                _workItemService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(_projectService.GetAll(), "Id", "Name", workItem.ProjectId);
            return View(workItem);
        }

        // GET: WorkItems/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItemViewModel workItem = Mapper.Map<WorkItemViewModel>(_workItemService.Get(id.Value)) ;
            if (workItem == null)
            {
                return HttpNotFound();
            }
            return View(workItem);
        }

        // POST: WorkItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _workItemService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
