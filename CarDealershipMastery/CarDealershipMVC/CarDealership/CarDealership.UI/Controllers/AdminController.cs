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

        public ActionResult EditVehicle(int id)
        {
            var viewModel = new AddVehicleVM();

            viewModel.Vehicle = DealershipRepositoryFactory.Create().GetVehicleDetailsByVehicleId(id);

            viewModel.SetMakeItems(DealershipRepositoryFactory.Create().GetAllMakes());
            viewModel.SetModelItems(DealershipRepositoryFactory.Create().GetAllModels());
            viewModel.SetTypeItems(DealershipRepositoryFactory.Create().GetAllVehicleTypes());
            viewModel.SetBodyStyleItems(DealershipRepositoryFactory.Create().GetAllBodyStyles());
            viewModel.SetTransmissionItems(DealershipRepositoryFactory.Create().GetAllTransmissionTypes());
            viewModel.SetColorItems();
            viewModel.SetInteriorItems();

            return View(viewModel);
        }

        public ActionResult Users()
        {
            //CHANGE THE METHOD IN HERE ONCE I ADD IDENTITY!!!
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllVehicles();

            return View(model);
        }

        public ActionResult AddUser()
        {
            //CHANGE THE METHOD IN HERE ONCE I ADD IDENTITY!!!
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllVehicles();

            return View(model);
        }

        public ActionResult EditUser()
        {
            //CHANGE THE METHOD IN HERE ONCE I ADD IDENTITY!!!
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllVehicles();

            return View(model);
        }

        public ActionResult Makes()
        {
            //CHANGE THE METHOD IN HERE ONCE I ADD IDENTITY!!!
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllVehicles();

            return View(model);
        }

        public ActionResult Models()
        {
            //CHANGE THE METHOD IN HERE ONCE I ADD IDENTITY!!!
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllVehicles();

            return View(model);
        }

        public ActionResult Specials()
        {
            //CHANGE THE METHOD IN HERE ONCE I ADD IDENTITY!!!
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllVehicles();

            return View(model);
        }

    }
}