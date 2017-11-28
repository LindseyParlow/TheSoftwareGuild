using CarDealership.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class InventoryController : Controller
    {
        [AllowAnonymous]
        public ActionResult New()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetTop20NewVehicles();

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Used()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetTop20UsedVehicles();

            return View(model);
        }
    }
}