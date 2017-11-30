using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using CarDealership.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace CarDealership.Data
{
    public class DealershipRepositoryEF : IDealershipRepository
    {
        public void AddMake(VehicleMake vehicleMake)
        {
            using (var ctx = new CarDealershipEntities())
            {
                if (ctx.VehicleMakes.Any())
                {
                    vehicleMake.VehicleMakeId = ctx.VehicleMakes.Max(m => m.VehicleMakeId) + 1;
                }
                else
                {
                    vehicleMake.VehicleMakeId = 1;
                }

                ctx.VehicleMakes.Add(vehicleMake);
                ctx.SaveChanges();
            }
                
        }

        public void AddModel(VehicleModel vehicleModel)
        {
            using (var ctx = new CarDealershipEntities())
            {
                if (ctx.VehicleModels.Any())
                {
                    vehicleModel.VehicleModelId = ctx.VehicleModels.Max(m => m.VehicleModelId) + 1;
                }
                else
                {
                    vehicleModel.VehicleModelId = 1;
                }

                ctx.VehicleModels.Add(vehicleModel);
                ctx.SaveChanges();
            }
        }

        public void AddContactUsQuery(ContactUsQuery contactUsQueryToAdd)
        {
            using (var ctx = new CarDealershipEntities())
            {
                if (ctx.ContactUsQueries.Any())
                {
                    contactUsQueryToAdd.ContactUsQueryId = ctx.ContactUsQueries.Max(s => s.ContactUsQueryId) + 1;
                }
                else
                {
                    contactUsQueryToAdd.ContactUsQueryId = 1;
                }

                ctx.ContactUsQueries.Add(contactUsQueryToAdd);
                ctx.SaveChanges();
            }
        }


        public void AddSpecial(Special specialToAdd)
        {
            using (var ctx = new CarDealershipEntities())
            {
                if (ctx.Specials.Any())
                {
                    specialToAdd.SpecialId = ctx.Specials.Max(s => s.SpecialId) + 1;
                }
                else
                {
                    specialToAdd.SpecialId = 1;
                }

                ctx.Specials.Add(specialToAdd);
                ctx.SaveChanges();
            }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            using (var ctx = new CarDealershipEntities())
            {
                if (ctx.Vehicles.Any())
                {
                    vehicle.VehicleId = ctx.Vehicles.Max(v => v.VehicleId) + 1;
                }
                else
                {
                    vehicle.VehicleId = 1;
                }

                ctx.Vehicles.Add(vehicle);
                ctx.SaveChanges();
            }
        }

        public void DeleteSpecial(int specialId)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var deleteThis = ctx.Specials.SingleOrDefault(s => s.SpecialId == specialId);
                ctx.Specials.Remove(deleteThis);
                ctx.SaveChanges();
            }
        }

        public void DeleteVehicle(int vehicleId)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var deleteThis = ctx.Vehicles.SingleOrDefault(v => v.VehicleId == vehicleId);
                ctx.Vehicles.Remove(deleteThis);
                ctx.SaveChanges();
            }
        }

        public void EditVehicle(Vehicle vehicleToEdit)
        {
            using (var ctx = new CarDealershipEntities())
            {
                vehicleToEdit.VehicleTypeId = vehicleToEdit.VehicleType.VehicleTypeId;
                vehicleToEdit.VehicleModelId = vehicleToEdit.VehicleModel.VehicleModelId;
                vehicleToEdit.TransmissionId = vehicleToEdit.Transmission.TransmissionId;
                vehicleToEdit.VehicleBodyId = vehicleToEdit.VehicleBody.VehicleBodyId;
                vehicleToEdit.PurchaseStatusId = vehicleToEdit.PurchaseStatus.PurchaseStatusId;

                ctx.Vehicles.Attach(vehicleToEdit);
                ctx.Entry(vehicleToEdit).State = System.Data.Entity.EntityState.Modified;
                ctx.VehicleTypes.Attach(vehicleToEdit.VehicleType);
                ctx.VehicleModels.Attach(vehicleToEdit.VehicleModel);
                ctx.Transmissions.Attach(vehicleToEdit.Transmission);
                ctx.VehicleBodies.Attach(vehicleToEdit.VehicleBody);
                ctx.PurchaseStatuses.Attach(vehicleToEdit.PurchaseStatus);
                ctx.SaveChanges();
            }
        }

        public List<Vehicle> GetAllFeaturedVehicles()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Vehicles
                    .Include("VehicleType")
                    .Include("VehicleModel")
                    .Include("VehicleModel.VehicleMake")
                    .Include("Transmission")
                    .Include("VehicleBody")
                    .Include("PurchaseStatus")
                    .Where(v => v.IsFeatured && v.PurchaseStatus.PurchaseStatusDescription == "Available")
                    .ToList();
            }
        }

        public List<Special> GetAllSpecials()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Specials.ToList();
            }
        }

        public List<Vehicle> GetAllVehicles()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Vehicles
                    .Include("VehicleType")
                    .Include("VehicleModel")
                    .Include("VehicleModel.VehicleMake")
                    .Include("Transmission")
                    .Include("VehicleBody")
                    .Include("PurchaseStatus")
                    .ToList();

            }
        }

        public List<Vehicle> GetTop20NewVehicles()
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles
                    .Include("VehicleType")
                    .Include("VehicleModel")
                    .Include("VehicleModel.VehicleMake")
                    .Include("Transmission")
                    .Include("VehicleBody")
                    .Include("PurchaseStatus")
                    .Where(t => t.VehicleType.VehicleTypeDescription == "New")
                    .OrderByDescending(p => p.MSRPPrice)
                    .ToList();
                if (vehicles.Count < 20)
                {
                    return vehicles;
                }
                else
                {
                    return vehicles.Take(20).ToList();
                }
            }
                
        }

        public List<Vehicle> GetTop20UsedVehicles()
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles
                    .Include("VehicleType")
                    .Include("VehicleModel")
                    .Include("VehicleModel.VehicleMake")
                    .Include("Transmission")
                    .Include("VehicleBody")
                    .Include("PurchaseStatus")
                    .Where(t => t.VehicleType.VehicleTypeDescription == "Used")
                    .OrderByDescending(p => p.MSRPPrice)
                    .ToList();
                if (vehicles.Count < 20)
                {
                    return vehicles;
                }
                else
                {
                    return vehicles
                        .Take(20)
                        .ToList();
                }
            }
                
        }

        public List<Customer> GetAllCustomers()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Customers
                    .Include("Address")
                    .ToList();
            }
        }

        public List<ContactUsQuery> GetAllContactUsQueries()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.ContactUsQueries
                    .Include("Vehicle")
                    .ToList();
            }
        }

        public List<Vehicle> GetNewVehicleByMegaSearchFilter(string input, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles
                    .Include("VehicleType")
                    .Include("VehicleModel")
                    .Include("VehicleModel.VehicleMake")
                    .Include("Transmission")
                    .Include("VehicleBody")
                    .Include("PurchaseStatus")
                    .Where(p => p.VehicleType.VehicleTypeDescription == "New" 
                        && p.SalePrice >= minPrice 
                        && p.SalePrice <= maxPrice 
                        && p.Year >= minYear 
                        && p.Year <= maxYear);

                if (input == "noVehicleInput")
                {
                    return vehicles.ToList();
                }
                else
                {
                    return vehicles
                        .Where(v => v.VehicleModel.VehicleMake.VehicleMakeDescription.Contains(input) 
                            || v.VehicleModel.VehicleModelDescription.Contains(input) 
                            || v.Year.ToString().Contains(input))
                            .ToList();
                }
            }    
        }

        public List<Vehicle> GetUsedVehicleByMegaSearchFilter(string input, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles
                    .Include("VehicleType")
                    .Include("VehicleModel")
                    .Include("VehicleModel.VehicleMake")
                    .Include("Transmission")
                    .Include("VehicleBody")
                    .Include("PurchaseStatus")
                    .Where(p => p.VehicleType.VehicleTypeDescription == "Used" 
                        && p.SalePrice >= minPrice 
                        && p.SalePrice <= maxPrice 
                        && p.Year >= minYear 
                        && p.Year <= maxYear);

                if (input == "noVehicleInput")
                {
                    return vehicles.ToList();
                }
                else
                {
                    return vehicles
                        .Where(v => v.VehicleModel.VehicleMake.VehicleMakeDescription.Contains(input) 
                            || v.VehicleModel.VehicleModelDescription.Contains(input) 
                            || v.Year.ToString().Contains(input))
                        .ToList();
                }
            }             
        }

        public Vehicle GetVehicleDetailsByVehicleId(int vehicleId)
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Vehicles
                    .Include("VehicleType")
                    .Include("VehicleModel")
                    .Include("VehicleModel.VehicleMake")
                    .Include("Transmission")
                    .Include("VehicleBody")
                    .Include("PurchaseStatus")
                    .Single(v => v.VehicleId == vehicleId);
            }
        }

        public List<Vehicle> GetNewAndUsedVehiclesForSales()
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles
                    .Include("VehicleType")
                    .Include("VehicleModel")
                    .Include("VehicleModel.VehicleMake")
                    .Include("Transmission")
                    .Include("VehicleBody")
                    .Include("PurchaseStatus")
                    .Where(v => v.PurchaseStatus.PurchaseStatusDescription == "Available")
                    .OrderByDescending(p => p.MSRPPrice)
                    .ToList();
                if (vehicles.Count < 20)
                {
                    return vehicles;
                }
                else
                {
                    return vehicles
                        .Take(20)
                        .ToList();
                }
            }
        }

        public List<Vehicle> GetFilteredNewAndUsedVehiclesForSales(string input, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles
                    .Include("VehicleType")
                    .Include("VehicleModel")
                    .Include("VehicleModel.VehicleMake")
                    .Include("Transmission")
                    .Include("VehicleBody")
                    .Include("PurchaseStatus")
                    .Where(p => p.PurchaseStatus.PurchaseStatusDescription == "Available"
                        && p.SalePrice >= minPrice 
                        && p.SalePrice <= maxPrice 
                        && p.Year >= minYear 
                        && p.Year <= maxYear);

                if (input == "noVehicleInput")
                {
                    return vehicles.ToList();
                }
                else
                {
                    return vehicles
                        .Where(v => v.VehicleModel.VehicleMake.VehicleMakeDescription.Contains(input) 
                            || v.VehicleModel.VehicleModelDescription.Contains(input) 
                            || v.Year.ToString().Contains(input))
                        .ToList();
                }
            }
        }

        public List<State> GetAllStates()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.States.ToList();
            }
        }

        public List<PurchaseType> GetAllPurchaseTypes()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.PurchaseTypes.ToList();
            }
        }

        public List<Phone> GetAllDealershipPhoneNumbers()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Dealerships.Include("Address").SelectMany(p => p.Phones).ToList();
            }
        }

        public List<VehicleMake> GetAllMakes()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.VehicleMakes.Include("User").ToList();
            }
        }

        public List<VehicleModel> GetAllModels()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.VehicleModels.Include("User").Include("VehicleMake").ToList();
            }
        }

        public List<VehicleType> GetAllVehicleTypes()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.VehicleTypes.ToList();
            }
        }

        public List<VehicleBody> GetAllBodyStyles()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.VehicleBodies.ToList();
            }
        }

        public List<Transmission> GetAllTransmissionTypes()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Transmissions.ToList();
            }
        }

        public List<VehicleMake> GetAllVehicleMakes()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.VehicleMakes.ToList();

            }
        }

        public List<VehicleModel> GetVehicleModelsByVehicleMake(int makeId)
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.VehicleModels.Include("VehicleMake").Where(v => v.VehicleMake.VehicleMakeId == makeId).ToList();
            }
        }

        public PurchaseStatus GetPurchaseStatus(int purchaseStatusId)
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.PurchaseStatuses.Single(p => p.PurchaseStatusId == purchaseStatusId);
            }
        }

        public Transmission GetTransmission(int transmissionId)
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Transmissions.Single(t => t.TransmissionId == transmissionId);
            }
        }

        public VehicleBody GetVehicleBody(int vehicleBodyId)
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.VehicleBodies.Single(v => v.VehicleBodyId == vehicleBodyId);
            }
        }

        public VehicleModel GetVehicleModel(int modelId)
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.VehicleModels.Include("VehicleMake").Single(v => v.VehicleModelId == modelId);
            }
        }

        public VehicleType GetVehicleType(int vehicleTypeId)
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.VehicleTypes.Single(v => v.VehicleTypeId == vehicleTypeId);
            }
        }

        public PurchaseStatus GetPuchaseStatusForAddedVehicle()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.PurchaseStatuses.Single(v => v.PurchaseStatusDescription == "Available");
            }
        }


        public List<AppUser> GetAllUsers()
        {
            using (var ctx = new CarDealershipEntities())
            {
                var users = ctx.Users.Include(u => u.Roles).ToList();
                var roles = ctx.Roles.ToList();



                foreach (var user in users)
                {
                    foreach (var role in user.Roles)
                    {
                        if (roles.Any(i => i.Id == role.RoleId))
                        {
                            var thisThing = roles.First(i => i.Id == role.RoleId);

                            user.RoleName = thisThing.Name;
                        }

                    }
                }
                return users;
            }
        }


        public List<IdentityRole> GetAllRoles()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Roles.ToList();
                //var roleStore = new RoleStore<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(ctx);
                //var roleMgr = new RoleManager<IdentityRole>(roleStore);

                //return roleMgr.Roles.ToList();
            }
        }

    }
}
