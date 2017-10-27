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

        List<Vehicle> GetTop20NewVehicles();
        List<Vehicle> GetTop20NewVehiclesByMake();
        List<Vehicle> GetTop20NewVehiclesModel();
        List<Vehicle> GetTop20NewVehiclesByYear();
        List<Vehicle> GetTop20NewVehiclesByPriceRange();
        List<Vehicle> GetTop20NewVehiclesByYearRange();
        List<Vehicle> GetTop20UsedVehicles();
        List<Vehicle> GetTop20UsedVehiclesByMake();
        List<Vehicle> GetTop20UsedVehiclesModel();
        List<Vehicle> GetTop20UsedVehiclesByYear();
        List<Vehicle> GetTop20UsedVehiclesByPriceRange();
        List<Vehicle> GetTop20UsedVehiclesByYeareRange();
        Vehicle GetVehicleDetails();

        List<Vehicle> GetAllVehicles();
        List<Vehicle> GetAllVehiclesByMake();
        List<Vehicle> GetAllVehiclesModel();
        List<Vehicle> GetAllVehiclesByYear();
        List<Vehicle> GetAllVehiclesByPriceRange();
        List<Vehicle> GetAllVehiclesByYeareRange();
        List<Vehicle> GetAllFeaturedVehicles();

        List<Special> GetAllSpecials();

        void AddMake(VehicleMake vehicleMake);
        void AddModel(VehicleModel vehicleModel);
        void AddVehicle(Vehicle vehicleToAdd);
        void EditVehicle(Vehicle vehicleToEdit);

        void AddEmployee(Employee employeeToAdd);
        void EditEmployee(Employee employeeToEdit);

        void AddSpecial(Special specialToAdd);
        void DeleteSpecial(Special specialToDelete);

        //CRUD for phone, addresses, specials, customers, employees, etc
        //methods for getting sales report and inventory report
    }
}
