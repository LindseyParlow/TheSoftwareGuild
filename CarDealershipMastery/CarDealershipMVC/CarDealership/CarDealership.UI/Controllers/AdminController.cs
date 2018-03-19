using CarDealership.Data;
using CarDealership.Models.Identity;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class AdminController : Controller
    {
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

        [HttpPost]
        public ActionResult AddVehicle(AddVehicleVM addVehicleVM)
        {
            if (ModelState.IsValid)
            {
                var repo = DealershipRepositoryFactory.Create();

                addVehicleVM.Vehicle.PurchaseStatus = repo.GetPuchaseStatusForAddedVehicle();
                addVehicleVM.Vehicle.Transmission = repo.GetTransmission(addVehicleVM.Vehicle.TransmissionId);
                addVehicleVM.Vehicle.VehicleBody = repo.GetVehicleBody(addVehicleVM.Vehicle.VehicleBodyId);
                addVehicleVM.Vehicle.VehicleModel = repo.GetVehicleModel(addVehicleVM.Vehicle.VehicleModelId);

                addVehicleVM.Vehicle.VehicleType = repo.GetVehicleType(addVehicleVM.Vehicle.VehicleTypeId);

                try
                {
                    if (addVehicleVM.ImageUpload != null && addVehicleVM.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(addVehicleVM.ImageUpload.FileName);
                        string extension = Path.GetExtension(addVehicleVM.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        addVehicleVM.ImageUpload.SaveAs(filePath);
                        addVehicleVM.Vehicle.ImagePath = Path.GetFileName(filePath);
                    } 
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                repo.AddVehicle(addVehicleVM.Vehicle);
                return RedirectToAction("Index");
            }
            else
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

        [HttpPost]
        public ActionResult EditVehicle(AddVehicleVM addVehicleVM)
        {
            if (ModelState.IsValid)
            {
                var repo = DealershipRepositoryFactory.Create();

                try
                {
                    var oldVehicle = repo.GetVehicleDetailsByVehicleId(addVehicleVM.Vehicle.VehicleId);
                    
                    addVehicleVM.Vehicle.Transmission = repo.GetTransmission(addVehicleVM.Vehicle.TransmissionId);
                    addVehicleVM.Vehicle.VehicleBody = repo.GetVehicleBody(addVehicleVM.Vehicle.VehicleBodyId);
                    addVehicleVM.Vehicle.VehicleModel = repo.GetVehicleModel(addVehicleVM.Vehicle.VehicleModelId);

                    addVehicleVM.Vehicle.VehicleType = repo.GetVehicleType(addVehicleVM.Vehicle.VehicleTypeId);

                    if (addVehicleVM.ImageUpload != null && addVehicleVM.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(addVehicleVM.ImageUpload.FileName);
                        string extension = Path.GetExtension(addVehicleVM.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        addVehicleVM.ImageUpload.SaveAs(filePath);
                        addVehicleVM.Vehicle.ImagePath = Path.GetFileName(filePath);

                        // delete old file
                        var oldPath = Path.Combine(savepath, oldVehicle.ImagePath);
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    else
                    {
                        // they did not replace the old file, so keep the old file name
                        addVehicleVM.Vehicle.ImagePath = oldVehicle.ImagePath;
                    }

                    repo.EditVehicle(addVehicleVM.Vehicle);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
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
        }

        //[Authorize(Roles = "admin")]
        public ActionResult DeleteVehicle()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllVehicles();

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteVehicle(int id)
        {
            var repo = DealershipRepositoryFactory.Create();

            //var model = repo.DeleteVehicle(id);

            return RedirectToAction("Index");
        }
        
        public ActionResult Users()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllUsers();

            return View(model);
        }
        
        public ActionResult AddUser()
        {
            var viewModel = new AddUserVM();

            viewModel.SetRoleItems(DealershipRepositoryFactory.Create().GetAllRoles());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddUser(AddUserVM viewModel)
        {
            var userManager = Request.GetOwinContext().GetUserManager<UserManager<AppUser>>();

            if (ModelState.IsValid)
            {
                var newUser = new AppUser()
                {
                    UserName = viewModel.User.Email,
                    FirstName = viewModel.User.FirstName,
                    LastName = viewModel.User.LastName,
                    Email = viewModel.User.Email
                };

                
                var result = userManager.Create(newUser, viewModel.Password);
                userManager.AddToRole(newUser.Id, viewModel.RoleName);

                return RedirectToAction("Users");
            }
            else
            {
                viewModel.SetRoleItems(DealershipRepositoryFactory.Create().GetAllRoles());

                return View(viewModel);
            }
        }
        
        public ActionResult EditUser(string id)
        {
            var viewModel = new AddUserVM();
            var userManager = Request.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var roles = DealershipRepositoryFactory.Create().GetAllRoles();
            var user = userManager.FindById(id);
            viewModel.User = user;
            viewModel.User.RoleName = roles.First(r => r.Id == user.Roles.First().RoleId).Name;
            viewModel.RoleName = viewModel.User.RoleName;
            viewModel.SetRoleItems(roles);
            
            return View(viewModel);   
        }

        [HttpPost]
        public ActionResult EditUser(AddUserVM userVM)
        {
            if (ModelState.IsValid)
            {
                var userManager = Request.GetOwinContext().GetUserManager<UserManager<AppUser>>();

                var oldUser = userManager.FindById(userVM.User.Id);

                var roles = DealershipRepositoryFactory.Create().GetAllRoles();

                oldUser.RoleName = roles.First(r => r.Id == oldUser.Roles.First().RoleId).Name;

                oldUser.UserName = userVM.User.Email;
                oldUser.LastName = userVM.User.LastName;
                oldUser.FirstName = userVM.User.FirstName;
                oldUser.Email = userVM.User.Email;

                if(!String.IsNullOrWhiteSpace(userVM.Password) && userVM.Password == userVM.ConfirmPassword)
                {
                    oldUser.PasswordHash = userManager.PasswordHasher.HashPassword(userVM.Password);
                }

                userManager.RemoveFromRole(oldUser.Id, oldUser.RoleName);
                userManager.AddToRole(oldUser.Id, userVM.RoleName);
                userManager.Update(oldUser);

                return RedirectToAction("Users");
            }
            else
            {
                var viewModel = new AddUserVM();
                var userManager = Request.GetOwinContext().GetUserManager<UserManager<AppUser>>();
                var roles = DealershipRepositoryFactory.Create().GetAllRoles();
                var user = userManager.FindById(userVM.User.Id);
                viewModel.User = user;
                viewModel.User.RoleName = roles.First(r => r.Id == user.Roles.First().RoleId).Name;
                viewModel.RoleName = viewModel.User.RoleName;
                viewModel.SetRoleItems(roles);

                return View(viewModel);
            }
        }
        
        public ActionResult Makes()
        {
            var viewModel = new AddMakeVM();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Makes(AddMakeVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var userManager = Request.GetOwinContext().GetUserManager<UserManager<AppUser>>();

                var userInfo = userManager.FindById(User.Identity.GetUserId());
                viewModel.VehicleMakeItem.User = userInfo;
                viewModel.VehicleMakeItem.UserId = userInfo.Id;
                viewModel.VehicleMakeItem.DateAdded = DateTime.Today;

                DealershipRepositoryFactory.Create().AddMake(viewModel.VehicleMakeItem);

                return RedirectToAction("Makes");
            }
            else
            {
                return View(viewModel);
            }
        }

        public ActionResult Models()
        {
            var viewModel = new AddModelVM();

            viewModel.SetMakeItems(DealershipRepositoryFactory.Create().GetAllMakes());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Models(AddModelVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var userManager = Request.GetOwinContext().GetUserManager<UserManager<AppUser>>();

                var userInfo = userManager.FindById(User.Identity.GetUserId());
                viewModel.VehicleModel.User = userInfo;
                viewModel.VehicleModel.UserId = userInfo.Id;
                viewModel.VehicleModel.DateAdded = DateTime.Today;
                viewModel.VehicleModel.VehicleMake = DealershipRepositoryFactory.Create().GetVehicleMake(viewModel.VehicleModel.VehicleMakeId);
                //addVehicleVM.Vehicle.VehicleModel = repo.GetVehicleModel(addVehicleVM.Vehicle.VehicleModelId);

                DealershipRepositoryFactory.Create().AddModel(viewModel.VehicleModel);

                return RedirectToAction("Models");
            }
            else
            {
                return View(viewModel);
            }
        }

        public ActionResult Specials()
        {
            var viewModel = new AddSpecialVM();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Specials(AddSpecialVM specialVM)
        {
            if (ModelState.IsValid)
            {
                var repo = DealershipRepositoryFactory.Create();

                repo.AddSpecial(specialVM.AddSpecial);

                return RedirectToAction("Index");
            }
            else
            {
                var viewModel = new AddSpecialVM();

                return View(viewModel);
            }
        }

        [HttpPost]
        public JsonResult GetModelsByMake(int makeId)
        {
            var models = DealershipRepositoryFactory.Create().GetVehicleModelsByVehicleMake(makeId);

            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}