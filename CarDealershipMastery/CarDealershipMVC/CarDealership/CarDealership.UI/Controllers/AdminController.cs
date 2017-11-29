using CarDealership.Data;
using CarDealership.UI.Models;
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
        // GET: Admin
        public ActionResult Index()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllVehicles();

            return View(model);
        }

        //[Authorize(Roles = "admin")]
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
        //[Authorize(Roles = "admin")]
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

                repo.AddVehicle(addVehicleVM.Vehicle);

                //=================================================================

                try
                {
                    if (addVehicleVM.ImageUpload != null && addVehicleVM.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(addVehicleVM.ImageUpload.FileName);
                        string extension = Path.GetExtension(addVehicleVM.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        addVehicleVM.ImageUpload.SaveAs(filePath);
                        addVehicleVM.Vehicle.ImagePath = Path.GetFileName(filePath);
                    } 
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                //=================================================================

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

        //[Authorize(Roles = "admin")]
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
        //[Authorize(Roles = "admin")]
        public ActionResult EditVehicle(AddVehicleVM addVehicleVM)
        {
            if (ModelState.IsValid)
            {
                var repo = DealershipRepositoryFactory.Create();


                try
                {

                    var oldVehicle = repo.GetVehicleDetailsByVehicleId(addVehicleVM.Vehicle.VehicleId);

                    //addVehicleVM.Vehicle.PurchaseStatus = repo.GetPurchaseStatus(addVehicleVM.Vehicle.PurchaseStatus.PurchaseStatusId);
                    
                    addVehicleVM.Vehicle.Transmission = repo.GetTransmission(addVehicleVM.Vehicle.TransmissionId);
                    addVehicleVM.Vehicle.VehicleBody = repo.GetVehicleBody(addVehicleVM.Vehicle.VehicleBodyId);
                    addVehicleVM.Vehicle.VehicleModel = repo.GetVehicleModel(addVehicleVM.Vehicle.VehicleModelId);

                    addVehicleVM.Vehicle.VehicleType = repo.GetVehicleType(addVehicleVM.Vehicle.VehicleTypeId);

                    //repo.AddVehicle(addVehicleVM.Vehicle);


                    if (addVehicleVM.ImageUpload != null && addVehicleVM.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(addVehicleVM.ImageUpload.FileName);
                        string extension = Path.GetExtension(addVehicleVM.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

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

                //viewModel.Vehicle = DealershipRepositoryFactory.Create().GetVehicleDetailsByVehicleId(id);

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
        //[Authorize(Roles = "admin")]
        public ActionResult DeleteVehicle(int id)
        {
            var repo = DealershipRepositoryFactory.Create();

            //var model = repo.DeleteVehicle(id);

            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "admin")]
        public ActionResult Users()
        {
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllUsers();

            return View(model);
        }

        //[Authorize(Roles = "admin")]
        public ActionResult AddUser()
        {
            var viewModel = new AddUserVM();

            viewModel.SetRoleItems(DealershipRepositoryFactory.Create().GetAllRoles());

            return View(viewModel);
        }


        //[Authorize(Roles = "admin")]
        public ActionResult EditUser()
        {
            //CHANGE THE METHOD IN HERE ONCE I ADD IDENTITY!!!
            var repo = DealershipRepositoryFactory.Create();

            var viewModel = new AddUserVM();

            return View(viewModel);
        }

        //[Authorize(Roles = "admin")]
        public ActionResult Makes()
        {
            //CHANGE THE METHOD IN HERE ONCE I ADD IDENTITY!!!
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllVehicles();

            return View(model);
        }

        //[Authorize(Roles = "admin")]
        public ActionResult Models()
        {
            //CHANGE THE METHOD IN HERE ONCE I ADD IDENTITY!!!
            var repo = DealershipRepositoryFactory.Create();

            var model = repo.GetAllVehicles();

            return View(model);
        }

        //[Authorize(Roles = "admin")]
        public ActionResult Specials()
        {
            var viewModel = new AddSpecialVM();

            return View(viewModel);
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
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
        //[AllowAnonymous]
        public JsonResult GetModelsByMake(int makeId)
        {
            var models = DealershipRepositoryFactory.Create().GetVehicleModelsByVehicleMake(makeId);

            return Json(models, JsonRequestBehavior.AllowGet);
        }


    }
}