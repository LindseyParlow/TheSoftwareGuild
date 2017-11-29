using CarDealership.Data;
using CarDealership.Models;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        //[Authorize(Roles = "admin,author")]
        public ActionResult Index()
        {
            var viewModel = new SalesInfoVM();
            viewModel.SetStateItems(DealershipRepositoryFactory.Create().GetAllStates());
            viewModel.SetPurchaseTypeItems(DealershipRepositoryFactory.Create().GetAllPurchaseTypes());

            return View(viewModel);
        }

        [HttpPost]
        //[Authorize(Roles = "admin,author")]
        public ActionResult Index(SalesInfoVM salesInfoVM)
        {
            //if (ModelState.IsValid)
            //{
            //    var repo = DealershipRepositoryFactory.Create();

            //    salesInfoVM.Purchase.PurchaseType = repo.GetPuchaseType(salesInfoVM.Purchase.PurchaseTypeId);
            //    salesInfoVM.Purchase.User = repo.GetUser();
            //    salesInfoVM.Purchase.Customer = repo.GetCustomer();
            //    salesInfoVM.Purchase.Vehicle = repo.GetVehicleDetailsByVehicleId(salesInfoVM.Purchase.VehicleId);

            //    salesInfoVM.Purchase.Vehicle.PurchaseStatus.PurchaseStatusDescription = "Sold";
            //    salesInfoVM.Purchase.Vehicle.PurchaseStatusId = repo.GetPurchaseStatus(salesInfoVM.Purchase.)
            //}
            //else
            //{
            //    var viewModel = new SalesInfoVM();
            //    viewModel.SetStateItems(DealershipRepositoryFactory.Create().GetAllStates());
            //    viewModel.SetPurchaseTypeItems(DealershipRepositoryFactory.Create().GetAllPurchaseTypes());

                return View();
            //viewModel
            //}
        }
    }
}