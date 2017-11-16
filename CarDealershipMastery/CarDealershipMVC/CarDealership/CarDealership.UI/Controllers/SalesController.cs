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
        public ActionResult Index()
        {
            var viewModel = new SalesInfoVM();
            viewModel.SetStateItems(DealershipRepositoryFactory.Create().GetAllStates());
            viewModel.SetPurchaseTypeItems(DealershipRepositoryFactory.Create().GetAllPurchaseTypes());

            return View(viewModel);
        }

        //[HttpPost]
        //public ActionResult Index(SalesInformationViewModel salesInformationViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        salesInformationViewModel.Purchase.Customer.Address.State = new List<State>();

        //        foreach () ;

        //        salesInformationViewModel.Purchase.PurchaseType = new List<PurchaseType>();

        //        return RedirectToAction("SOMEWHERE");
        //    }
        //    else
        //    {
        //        var viewModel = new SalesInformationViewModel();
        //        viewModel.SetStateItems(DealershipRepositoryFactory.Create().GetAllStates());
        //        viewModel.SetPurchaseTypeItems(DealershipRepositoryFactory.Create().GetAllPurchaseTypes());

        //        return View(viewModel);

        //    }
        //}
    }
}