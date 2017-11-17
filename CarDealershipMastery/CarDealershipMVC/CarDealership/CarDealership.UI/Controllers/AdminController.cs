using CarDealership.Data;
using CarDealership.UI.Models;
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

        public ActionResult AddVehicle()
        {
            var viewModel = new AddVehicleVM();
            viewModel.SetMakeItems(DealershipRepositoryFactory.Create().GetAllMakes());
            viewModel.SetModelItems(DealershipRepositoryFactory.Create().GetAllModels());
            viewModel.SetTypeItems(DealershipRepositoryFactory.Create().GetAllVehicleTypes());
            viewModel.SetBodyStyleItems(DealershipRepositoryFactory.Create().GetAllBodyStyles());
            viewModel.SetTransmissionItems(DealershipRepositoryFactory.Create().GetAllTransmissionTypes());
            viewModel.SetColorItems();
            viewModel.SetInteriorItems();

            return View(viewModel);
        }



        //NO VIEWS FOR THESE YET. NOT SURE IF I WILL NEED THEM

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