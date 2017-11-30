using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using CarDealership.Data;
using CarDealership.Models;
using CarDealership.Models.Identity;
using CarDealership.UI.Models;

namespace CarDealership.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginVM();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            // attempt to load the user with this password
            AppUser user = userManager.Find(model.UserName, model.Password);

            // user will be null if the password or user name is bad
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
            else
            {
                // successful login, set up their cookies and send them on their way
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home", null);
            }
        }

        public ActionResult ChangePassword()
        {
            var viewModel = new ChangePasswordVM();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordVM viewModel)
        {
            if(ModelState.IsValid)
            {
                var userManager = Request.GetOwinContext().GetUserManager<UserManager<AppUser>>();

                var currentUser = userManager.FindById(User.Identity.GetUserId());

                currentUser.PasswordHash = userManager.PasswordHasher.HashPassword(viewModel.Password);

                userManager.Update(currentUser);

                return RedirectToAction("Index", "Home", null);
            }
            return View(viewModel);
        }
        
        public ActionResult LogOff()
        {
            var authMgr = Request.GetOwinContext().Authentication;

            authMgr.SignOut("ApplicationCookie");

            return RedirectToAction("Index", "Home");
        }

    }
}