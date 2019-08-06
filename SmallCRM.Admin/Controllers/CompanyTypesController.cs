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
    public class CompanyTypesController : Controller
    {
        private readonly ICompanyTypeService companyTypeService;

        private ApplicationDbContext db = new ApplicationDbContext();

        public CompanyTypesController(ICompanyTypeService companyTypeService)
        {
            this.companyTypeService = companyTypeService;
        }


        // GET: CompanyTypes
        public ActionResult Index()
        {
            var companyTypes = Mapper.Map<IEnumerable<CompanyTypeViewModel>>(companyTypeService.GetAll());
            return View(companyTypes);
        }

        // GET: CompanyTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyTypeViewModel companyType = Mapper.Map<CompanyTypeViewModel>(companyTypeService.Get(id.Value));
            if (companyType == null)
            {
                return HttpNotFound();
            }
            return View(companyType);
        }

        // GET: CompanyTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyTypeViewModel companyType)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<CompanyType>(companyType);
                companyTypeService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(companyType);
        }

        // GET: CompanyTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyTypeViewModel companyType = Mapper.Map<CompanyTypeViewModel>(companyTypeService.Get(id.Value));
            if (companyType == null)
            {
                return HttpNotFound();
            }
            return View(companyType);
        }

        // POST: CompanyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] CompanyType companyType)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<CompanyType>(companyType);
                companyTypeService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(companyType);
        }

        // GET: CompanyTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyTypeViewModel companyType = Mapper.Map<CompanyTypeViewModel>(companyTypeService.Get(id.Value));            
            if (companyType == null)
            {
                return HttpNotFound();
            }
            return View(companyType);
        }

        // POST: CompanyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            companyTypeService.Delete(id);
            return RedirectToAction("Index");
        }
        

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

    }
}
