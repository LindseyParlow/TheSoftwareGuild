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
        //[AllowAnonymous]
        public ActionResult Index()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllSpecials();

            return View(model);
        }

        //[AllowAnonymous]
        public ActionResult Specials()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllSpecials();

            return View(model);
        }

        //[AllowAnonymous]
        public ActionResult Contact(string id)
        {
            var viewModel = new ContactUsVM();

            viewModel.ContactUs.Message = id;

            return View(viewModel);
        }

        [HttpPost]
        //[AllowAnonymous]
        public ActionResult Contact(ContactUsVM contactVM)
        {
            contactVM.ContactUs.Vehicle = DealershipRepositoryFactory.Create().GetVehicleDetailsByVehicleId(contactVM.ContactUs.Vehicle.VehicleId);
            DealershipRepositoryFactory.Create().AddContactUsQuery(contactVM.ContactUs);

            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "admin, sales")]
        public ActionResult Sales()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllVehicles();

            return View(model);
        }
    }
}