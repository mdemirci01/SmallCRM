using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmallCRM.Data;
using SmallCRM.Model;

namespace SmallCRM.Admin.Controllers
{
    public class CompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Companies
        public ActionResult Index()
        {
            var companies = db.Companies.Include(c => c.CompanyType).Include(c => c.DeliveryCity).Include(c => c.DeliveryCountry).Include(c => c.DeliveryRegion).Include(c => c.InvoiceCity).Include(c => c.InvoiceCountry).Include(c => c.InvoiceRegion).Include(c => c.MainCompany).Include(c => c.Sector);
            return View(companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.CompanyTypeId = new SelectList(db.CompanyTypes, "Id", "Name");
            ViewBag.DeliveryCityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.DeliveryCountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.DeliveryRegionId = new SelectList(db.Regions, "Id", "Name");
            ViewBag.InvoiceCityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.InvoiceCountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.InvoiceRegionId = new SelectList(db.Regions, "Id", "Name");
            ViewBag.MainCompanyId = new SelectList(db.Companies, "Id", "Owner");
            ViewBag.SectorId = new SelectList(db.Sectors, "Id", "Name");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Owner,Name,MainCompanyId,CompanyNumber,CompanyTypeId,SectorId,AnnualIncome,Stage,Telephone,Fax,Website,ImkbCode,OwnerShip,NaceCode,InvoiceAddress,InvoiceCityId,InvoiceRegionId,InvoicePostalCode,InvoiceDescription,InvoiceCountryId,DeliveryAddress,DeliveryCityId,DeliveryRegionId,DeliveryPostalCode,DeliveryDescription,DeliveryCountryId,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Company company)
        {
            if (ModelState.IsValid)
            {
                company.Id = Guid.NewGuid();
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyTypeId = new SelectList(db.CompanyTypes, "Id", "Name", company.CompanyTypeId);
            ViewBag.DeliveryCityId = new SelectList(db.Cities, "Id", "Name", company.DeliveryCityId);
            ViewBag.DeliveryCountryId = new SelectList(db.Countries, "Id", "Name", company.DeliveryCountryId);
            ViewBag.DeliveryRegionId = new SelectList(db.Regions, "Id", "Name", company.DeliveryRegionId);
            ViewBag.InvoiceCityId = new SelectList(db.Cities, "Id", "Name", company.InvoiceCityId);
            ViewBag.InvoiceCountryId = new SelectList(db.Countries, "Id", "Name", company.InvoiceCountryId);
            ViewBag.InvoiceRegionId = new SelectList(db.Regions, "Id", "Name", company.InvoiceRegionId);
            ViewBag.MainCompanyId = new SelectList(db.Companies, "Id", "Owner", company.MainCompanyId);
            ViewBag.SectorId = new SelectList(db.Sectors, "Id", "Name", company.SectorId);
            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyTypeId = new SelectList(db.CompanyTypes, "Id", "Name", company.CompanyTypeId);
            ViewBag.DeliveryCityId = new SelectList(db.Cities, "Id", "Name", company.DeliveryCityId);
            ViewBag.DeliveryCountryId = new SelectList(db.Countries, "Id", "Name", company.DeliveryCountryId);
            ViewBag.DeliveryRegionId = new SelectList(db.Regions, "Id", "Name", company.DeliveryRegionId);
            ViewBag.InvoiceCityId = new SelectList(db.Cities, "Id", "Name", company.InvoiceCityId);
            ViewBag.InvoiceCountryId = new SelectList(db.Countries, "Id", "Name", company.InvoiceCountryId);
            ViewBag.InvoiceRegionId = new SelectList(db.Regions, "Id", "Name", company.InvoiceRegionId);
            ViewBag.MainCompanyId = new SelectList(db.Companies, "Id", "Owner", company.MainCompanyId);
            ViewBag.SectorId = new SelectList(db.Sectors, "Id", "Name", company.SectorId);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Owner,Name,MainCompanyId,CompanyNumber,CompanyTypeId,SectorId,AnnualIncome,Stage,Telephone,Fax,Website,ImkbCode,OwnerShip,NaceCode,InvoiceAddress,InvoiceCityId,InvoiceRegionId,InvoicePostalCode,InvoiceDescription,InvoiceCountryId,DeliveryAddress,DeliveryCityId,DeliveryRegionId,DeliveryPostalCode,DeliveryDescription,DeliveryCountryId,Description,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyTypeId = new SelectList(db.CompanyTypes, "Id", "Name", company.CompanyTypeId);
            ViewBag.DeliveryCityId = new SelectList(db.Cities, "Id", "Name", company.DeliveryCityId);
            ViewBag.DeliveryCountryId = new SelectList(db.Countries, "Id", "Name", company.DeliveryCountryId);
            ViewBag.DeliveryRegionId = new SelectList(db.Regions, "Id", "Name", company.DeliveryRegionId);
            ViewBag.InvoiceCityId = new SelectList(db.Cities, "Id", "Name", company.InvoiceCityId);
            ViewBag.InvoiceCountryId = new SelectList(db.Countries, "Id", "Name", company.InvoiceCountryId);
            ViewBag.InvoiceRegionId = new SelectList(db.Regions, "Id", "Name", company.InvoiceRegionId);
            ViewBag.MainCompanyId = new SelectList(db.Companies, "Id", "Owner", company.MainCompanyId);
            ViewBag.SectorId = new SelectList(db.Sectors, "Id", "Name", company.SectorId);
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
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
