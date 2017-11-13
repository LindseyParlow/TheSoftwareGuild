using CarDealership.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllSpecials();

            return View(model);
        }
        
        public ActionResult Specials()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllSpecials();

            return View(model);
        }

        public ActionResult Contact()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllCustomers();

            return View();
        }

        public ActionResult Sales()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllVehicles();

            return View(model);
        }
    }
}