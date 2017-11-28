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
        public ActionResult Index(SalesInfoVM salesInfoVM)
        {
            //do this once identity is set up becuase you need to attach a sales user to the sale
            return View();
        }
    }
}