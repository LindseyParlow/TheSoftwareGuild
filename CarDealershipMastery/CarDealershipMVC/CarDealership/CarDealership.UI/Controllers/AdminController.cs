using CarDealership.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllVehicles();

            return View(model);
        }


        //public ActionResult Admin()
        //{
        //    var repo = DealershipRepositoryFactory.Create();

        //    var model = repo.GetAllVehicles();

        //    return View(model);
        //}

        //NO VIEWS FOR THESE YET. NOT SURE IF I WILL NEED THEM

        //public ActionResult AddVehicle()
        //{
        //    var repo = DealershipRepositoryFactory.Create();

        //    var model = repo.GetAllFeaturedVehicles();

        //    return View(model);
        //}

        //public ActionResult EditVehicle()
        //{
        //    var repo = DealershipRepositoryFactory.Create();

        //    var model = repo.GetAllFeaturedVehicles();

        //    return View(model);
        //}

        //public ActionResult Users()
        //{
        //    var repo = DealershipRepositoryFactory.Create();

        //    var model = repo.GetAllFeaturedVehicles();

        //    return View(model);
        //}
    }
}