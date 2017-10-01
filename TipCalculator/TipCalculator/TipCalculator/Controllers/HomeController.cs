using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TipCalculator.Models;

namespace TipCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Tip()
        {
            TipData model = new TipData();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Tip(TipData t)
        {
            return View(t);
        }
    }
}