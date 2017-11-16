using CarDealership.Data;
using CarDealership.UI.Models;
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
            var viewModel = new ContactUsVM();
            

            return View(viewModel);
        }

        public ActionResult Sales()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllVehicles();

            return View(model);
        }
    }
}