using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IDealershipRepository
    {
        //make sure not to show vehicles that are sold for users
        //
        Vehicle GetVehicleById(int vehicleId);

        List<Vehicle> GetTop20NewVehicles();
        List<Vehicle> GetTop20NewVehiclesByMake(string makeName);
        List<Vehicle> GetTop20NewVehiclesModel(string modelName);
        List<Vehicle> GetTop20NewVehiclesByYear(int vehicleYear);
        List<Vehicle> GetTop20NewVehiclesByPriceRange(decimal minPrice, decimal maxPrice);
        List<Vehicle> GetTop20NewVehiclesByPriceMin(decimal minPrice);
        List<Vehicle> GetTop20NewVehiclesByPriceMax(decimal maxPrice);
        List<Vehicle> GetTop20NewVehiclesByYearRange(int minYear, int maxYear);
        List<Vehicle> GetTop20NewVehiclesByYearMin(int minYear);
        List<Vehicle> GetTop20NewVehiclesByYearMax(int maxYear);

        List<Vehicle> GetTop20UsedVehicles();
        List<Vehicle> GetTop20UsedVehiclesByMake(string makeName);
        List<Vehicle> GetTop20UsedVehiclesModel(string modelName);
        List<Vehicle> GetTop20UsedVehiclesByYear(int vehicleYear);
        List<Vehicle> GetTop20UsedVehiclesByYearRange(int minYear, int maxYear);
        List<Vehicle> GetTop20UsedVehiclesByYearMin(int minYear);
        List<Vehicle> GetTop20UsedVehiclesByYearMax(int maxYear);
        List<Vehicle> GetTop20UsedVehiclesByPriceRange(decimal minPrice, decimal maxPrice);
        List<Vehicle> GetTop20UsedVehiclesByPriceMin(decimal minPrice);
        List<Vehicle> GetTop20UsedVehiclesByPriceMax(decimal maxPrice);

        //Vehicle GetVehicleDetails();

        List<Vehicle> GetAllVehicles();
        List<Vehicle> GetAllVehiclesByMake(string makeName);
        List<Vehicle> GetAllVehiclesByModel(string modelName);
        List<Vehicle> GetAllVehiclesByYear(int vehicleYear);

        List<Vehicle> GetAllFeaturedVehicles();

        List<Special> GetAllSpecials();

        void AddMake(VehicleMake vehicleMake);
        void AddModel(VehicleModel vehicleModel);
        void AddVehicle(Vehicle vehicleToAdd);
        void EditVehicle(Vehicle vehicleToEdit);

        void AddEmployee(Employee employeeToAdd);
        void EditEmployee(Employee employeeToEdit);

        void AddSpecial(Special specialToAdd);
        void DeleteSpecial(int specialId);

        List<Customer> GetAllCustomers();
        List<ContactUsQuery> GetAllContactUsQueries();

        List<Vehicle> GetNewVehicleByMegaSearchFilter(string input, int minPrice, int maxPrice, int minYear, int maxYear);
        List<Vehicle> GetUsedVehicleByMegaSearchFilter(string input, int minPrice, int maxPrice, int minYear, int maxYear);

        Vehicle GetVehicleDetailsByVehicleId(int vehicleId);
        List<Vehicle> GetNewAndUsedVehiclesForSales();
        List<Vehicle> GetFilteredNewAndUsedVehiclesForSales(string input, int minPrice, int maxPrice, int minYear, int maxYear);

        List<State> GetAllStates();
        List<PurchaseType> GetAllPurchaseTypes();

        //CRUD for phone, addresses, specials, customers, employees, etc
        //methods for getting sales report and inventory report
    }
}
