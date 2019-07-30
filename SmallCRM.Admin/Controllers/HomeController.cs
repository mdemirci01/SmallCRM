using AutoMapper;
using SmallCRM.Admin.Models;
using SmallCRM.Service;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallCRM.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService customerService;
        public HomeController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        public ActionResult Index()
        {
            var customers = Mapper.Map<IEnumerable<CustomerViewModel>>(customerService.GetAll());

            return View(customers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}