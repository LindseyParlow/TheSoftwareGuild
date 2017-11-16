using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;

namespace CarDealership.Data
{
    public class DealershipRepositoryEF : IDealershipRepository
    {
        public void AddEmployee(Employee employeeToAdd)
        {
            using (var ctx = new CarDealershipEntities())
            {
                ctx.Employees.Add(employeeToAdd);
                ctx.SaveChanges();
            }
        }

        public void AddMake(VehicleMake vehicleMake)
        {
            using (var ctx = new CarDealershipEntities())
            {
                ctx.VehicleMakes.Add(vehicleMake);
                ctx.SaveChanges();
            }
        }

        public void AddModel(VehicleModel vehicleModel)
        {
            using (var ctx = new CarDealershipEntities())
            {
                ctx.VehicleModels.Add(vehicleModel);
                ctx.SaveChanges();
            }
        }

        public void AddSpecial(Special specialToAdd)
        {
            using (var ctx = new CarDealershipEntities())
            {
                ctx.Specials.Add(specialToAdd);
                ctx.SaveChanges();
            }
        }

        public void AddVehicle(Vehicle vehicleToAdd)
        {
            using (var ctx = new CarDealershipEntities())
            {
                ctx.Vehicles.Add(vehicleToAdd);
                ctx.SaveChanges();
            }
        }

        public void DeleteSpecial(int specialId)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var deleteThis = ctx.Specials.SingleOrDefault(i => i.SpecialId == specialId);
                ctx.Specials.Remove(deleteThis);
                ctx.SaveChanges();
            };
        }

        public void EditEmployee(Employee employeeToEdit)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var editThis = ctx.Employees.SingleOrDefault(s => s.EmployeeId == employeeToEdit.EmployeeId);
                editThis.LastName = employeeToEdit.LastName;
                editThis.FirstName = employeeToEdit.FirstName;
                editThis.Email = employeeToEdit.Email;
                editThis.Password = employeeToEdit.Password;

                ctx.SaveChanges();
            }
        }

        public void EditVehicle(Vehicle vehicleToEdit)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var editThis = ctx.Vehicles.SingleOrDefault(s => s.VehicleId == vehicleToEdit.VehicleId);
                editThis.VehicleTypeId = vehicleToEdit.VehicleTypeId;
                editThis.VehicleModelId = vehicleToEdit.VehicleModelId;
                editThis.TransmissionId = vehicleToEdit.TransmissionId;
                editThis.SalePrice = vehicleToEdit.SalePrice;
                editThis.MSRPPrice = vehicleToEdit.MSRPPrice;
                editThis.VehicleBodyId = vehicleToEdit.VehicleBodyId;
                editThis.Year = vehicleToEdit.Year;
                editThis.VehicleColor = vehicleToEdit.VehicleColor;
                editThis.InteriorColor = vehicleToEdit.InteriorColor;
                editThis.VinNumber = vehicleToEdit.VinNumber;
                editThis.Mileage = vehicleToEdit.Mileage;
                editThis.VehicleDescription = vehicleToEdit.VehicleDescription;
                editThis.SpecialId = vehicleToEdit.SpecialId;
                editThis.DateAdded = vehicleToEdit.DateAdded;
                editThis.PurchaseStatusId = vehicleToEdit.PurchaseStatusId;
                editThis.IsFeatured = vehicleToEdit.IsFeatured;

                editThis.VehicleType = vehicleToEdit.VehicleType;
                editThis.VehicleModel = vehicleToEdit.VehicleModel;
                editThis.Transmission = vehicleToEdit.Transmission;
                editThis.VehicleBody = vehicleToEdit.VehicleBody;
                editThis.Special = vehicleToEdit.Special;
                editThis.PurchaseStatus = vehicleToEdit.PurchaseStatus;

                ctx.SaveChanges();
            }
        }

        public List<Vehicle> GetAllFeaturedVehicles()
        {
            using (var ctx = new CarDealershipEntities())
            {
                var isFeaturedVehicle = ctx.Vehicles.Where(i => i.IsFeatured).Where(p => p.PurchaseStatus.PurchaseStatusDescription == "Available");

                return isFeaturedVehicle.ToList();
            }
        }

        public List<Special> GetAllSpecials()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Specials.Where(s=> s.IsActive).ToList();
            }
        }

        public List<Vehicle> GetAllVehicles()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Vehicles.ToList();
            }
        }

        public List<Vehicle> GetAllVehiclesByMake(string makeName)
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Vehicles.Where(b => b.VehicleModel.VehicleMake.VehicleMakeDescription.Contains(makeName)).ToList();
            }
        }

        public List<Vehicle> GetAllVehiclesByModel(string modelName)
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Vehicles.Where(b => b.VehicleModel.VehicleModelDescription.Contains(modelName)).ToList();
            }
        }

        public List<Vehicle> GetAllVehiclesByYear(int vehicleYear)
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Vehicles.Where(b => b.Year == vehicleYear).ToList();
            }
        }

        public List<Vehicle> GetTop20NewVehicles()
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(b => b.VehicleType.VehicleTypeDescription == "New" && b.PurchaseStatus.PurchaseStatusDescription == "Available").OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20NewVehiclesByMake(string makeName)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(t => t.VehicleType.VehicleTypeDescription == "New").Where(v => v.VehicleModel.VehicleMake.VehicleMakeDescription.Contains(makeName)).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20NewVehiclesByPriceMax(decimal maxPrice)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "New" && v.SalePrice <= maxPrice).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20NewVehiclesByPriceMin(decimal minPrice)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "New" && v.SalePrice >= minPrice).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20NewVehiclesByPriceRange(decimal minPrice, decimal maxPrice)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "New" && v.SalePrice >= minPrice && v.SalePrice <= maxPrice).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20NewVehiclesByYear(int vehicleYear)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(t => t.VehicleType.VehicleTypeDescription == "New").Where(y => y.Year == vehicleYear).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20NewVehiclesByYearMax(int maxYear)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "New" && v.Year <= maxYear).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20NewVehiclesByYearMin(int minYear)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "New" && v.Year >= minYear).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20NewVehiclesByYearRange(int minYear, int maxYear)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "New" && v.Year >= minYear && v.Year <= maxYear).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20NewVehiclesModel(string modelName)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "New" && v.VehicleModel.VehicleModelDescription.Contains(modelName)).OrderByDescending(p => p.MSRPPrice).ToList();
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
                var vehicles = ctx.Vehicles.Where(t => t.VehicleType.VehicleTypeDescription == "Used" && t.PurchaseStatus.PurchaseStatusDescription == "Available").OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20UsedVehiclesByMake(string makeName)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(t => t.VehicleType.VehicleTypeDescription == "Used").Where(v => v.VehicleModel.VehicleMake.VehicleMakeDescription.Contains(makeName)).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20UsedVehiclesByPriceMax(decimal maxPrice)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "Used" && v.SalePrice <= maxPrice).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20UsedVehiclesByPriceMin(decimal minPrice)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "Used" && v.SalePrice >= minPrice).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20UsedVehiclesByPriceRange(decimal minPrice, decimal maxPrice)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "Used" && v.SalePrice >= minPrice && v.SalePrice <= maxPrice).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20UsedVehiclesByYear(int vehicleYear)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(t => t.VehicleType.VehicleTypeDescription == "Used").Where(y => y.Year == vehicleYear).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20UsedVehiclesByYearMax(int maxYear)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "Used" && v.Year <= maxYear).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20UsedVehiclesByYearMin(int minYear)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "Used" && v.Year >= minYear).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20UsedVehiclesByYearRange(int minYear, int maxYear)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "Used" && v.Year >= minYear && v.Year <= maxYear).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20UsedVehiclesModel(string modelName)
        {
            using (var ctx = new CarDealershipEntities())
            {
                var vehicles = ctx.Vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "Used" && v.VehicleModel.VehicleModelDescription.Contains(modelName)).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Customer> GetAllCustomers()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.Customers.ToList();
            }
        }

        public List<ContactUsQuery> GetAllContactUsQueries()
        {
            using (var ctx = new CarDealershipEntities())
            {
                return ctx.ContactUsQueries.ToList();
            }
        }

        //need to do something with this
        public Vehicle GetVehicleById(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetNewVehicleByMegaSearchFilter(string input, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            throw new NotImplementedException();
            //var vehicles = _vehicles.Where(p => p.VehicleType.VehicleTypeDescription == "New" && p.SalePrice >= minPrice && p.SalePrice <= maxPrice && p.Year >= minYear && p.Year <= maxYear);

            //if (input == "")
            //{
            //    return vehicles.ToList();
            //}
            //else
            //{
            //    return vehicles.Where(v => ((v.VehicleModel.VehicleModelDescription).Contains(input) || (v.VehicleModel.VehicleMake.VehicleMakeDescription).Contains(input)) || (v.Year.ToString()) == input).ToList();
            //}
        }

        public List<Vehicle> GetUsedVehicleByMegaSearchFilter(string input, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            throw new NotImplementedException();
            //var vehicles = _vehicles.Where(p => p.VehicleType.VehicleTypeDescription == "New" && p.SalePrice >= minPrice && p.SalePrice <= maxPrice && p.Year >= minYear && p.Year <= maxYear);

            //if (input == "")
            //{
            //    return vehicles.ToList();
            //}
            //else
            //{
            //    return vehicles.Where(v => ((v.VehicleModel.VehicleModelDescription).Contains(input) || (v.VehicleModel.VehicleMake.VehicleMakeDescription).Contains(input)) || (v.Year.ToString()) == input).ToList();
            //}
        }

        public Vehicle GetVehicleDetailsByVehicleId(int vehicleId)
        {
            throw new NotImplementedException();
            //return _vehicles.Single(v => v.VehicleId == vehicleId);
        }

        public List<Vehicle> GetNewAndUsedVehiclesForSales()
        {
            throw new NotImplementedException();

            //var vehicles = _vehicles.OrderByDescending(p => p.MSRPPrice).ToList();
            //if (vehicles.Count < 20)
            //{
            //    return vehicles;
            //}
            //else
            //{
            //    return vehicles.Take(20).ToList();
            //}
        }

        public List<Vehicle> GetFilteredNewAndUsedVehiclesForSales(string input, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            throw new NotImplementedException();

            //var vehicles = _vehicles.Where(p => p.SalePrice >= minPrice && p.SalePrice <= maxPrice && p.Year >= minYear && p.Year <= maxYear);

            //if (input == "noVehicleInput")
            //{
            //    return vehicles.ToList();
            //}
            //else
            //{
            //    return vehicles.Where(v => v.VehicleModel.VehicleMake.VehicleMakeDescription.Contains(input) || v.VehicleModel.VehicleModelDescription.Contains(input) || v.Year.ToString().Contains(input)).ToList();
            //}
        }

        public List<State> GetAllStates()
        {
            throw new NotImplementedException();

            //return _states;
        }

        public List<PurchaseType> GetAllPurchaseTypes()
        {
            throw new NotImplementedException();

            //return _purchaseType;
        }

        public List<Phone> GetAllDealershipPhoneNumbers()
        {
            throw new NotImplementedException();
        }
    }
}
