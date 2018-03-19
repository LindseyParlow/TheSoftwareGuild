using CarDealership.Data;
using CarDealership.Models;
using CarDealership.Models.Identity;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        [Authorize(Roles = "admin,author")]
        public ActionResult Index()
        {
            var viewModel = new SalesInfoVM();
            viewModel.SetStateItems(DealershipRepositoryFactory.Create().GetAllStates());
            viewModel.SetPurchaseTypeItems(DealershipRepositoryFactory.Create().GetAllPurchaseTypes());
            
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "admin,author")]
        public ActionResult Index(SalesInfoVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var repo = DealershipRepositoryFactory.Create();
                var userManager = Request.GetOwinContext().GetUserManager<UserManager<AppUser>>();

                var userInfo = userManager.FindById(User.Identity.GetUserId());
                viewModel.Purchase.User = userInfo;
                viewModel.Purchase.UserId = userInfo.Id;
                viewModel.Purchase.DatePurchased = DateTime.Today;

                viewModel.Purchase.Vehicle = DealershipRepositoryFactory.Create().GetVehicleDetailsByVehicleId(viewModel.Purchase.VehicleId);

                repo.AddPurchase(viewModel.Purchase);

                return RedirectToAction("Index");
            }
            else
            {
                viewModel.SetStateItems(DealershipRepositoryFactory.Create().GetAllStates());
                viewModel.SetPurchaseTypeItems(DealershipRepositoryFactory.Create().GetAllPurchaseTypes());

                return View(viewModel);
            }
        }
    }
}