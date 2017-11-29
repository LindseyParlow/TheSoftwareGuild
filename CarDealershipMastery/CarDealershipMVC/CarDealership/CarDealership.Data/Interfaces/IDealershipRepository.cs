using CarDealership.Models;
using CarDealership.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IDealershipRepository
    {
        List<Vehicle> GetTop20NewVehicles();
        List<Vehicle> GetTop20UsedVehicles();
        List<Vehicle> GetAllVehicles();
        List<Vehicle> GetAllFeaturedVehicles();
        List<Special> GetAllSpecials();

        void AddContactUsQuery(ContactUsQuery contactUsQueryToAdd);
        void AddSpecial(Special specialToAdd);
        void AddMake(VehicleMake vehicleMake);
        void AddModel(VehicleModel vehicleModel);
        //void AddUser(AddUserVM viewModel);
        void AddVehicle(Vehicle vehicleToAdd);
        void EditVehicle(Vehicle vehicleToEdit);
        void DeleteSpecial(int specialId);
        void DeleteVehicle(int vehicleId);

        List<Customer> GetAllCustomers();
        List<ContactUsQuery> GetAllContactUsQueries();

        List<Vehicle> GetNewVehicleByMegaSearchFilter(string input, int minPrice, int maxPrice, int minYear, int maxYear);
        List<Vehicle> GetUsedVehicleByMegaSearchFilter(string input, int minPrice, int maxPrice, int minYear, int maxYear);

        Vehicle GetVehicleDetailsByVehicleId(int vehicleId);
        List<Vehicle> GetNewAndUsedVehiclesForSales();
        List<Vehicle> GetFilteredNewAndUsedVehiclesForSales(string input, int minPrice, int maxPrice, int minYear, int maxYear);

        List<State> GetAllStates();
        List<PurchaseType> GetAllPurchaseTypes();
        List<Phone> GetAllDealershipPhoneNumbers();

        List<VehicleMake> GetAllMakes();
        List<VehicleModel> GetAllModels();
        List<VehicleType> GetAllVehicleTypes();
        List<VehicleBody> GetAllBodyStyles();
        List<Transmission> GetAllTransmissionTypes();

        List<VehicleMake> GetAllVehicleMakes();
        List<VehicleModel> GetVehicleModelsByVehicleMake(int makeId);
        PurchaseStatus GetPurchaseStatus(int purchaseStatusId);
        Transmission GetTransmission(int transmissionId);
        VehicleBody GetVehicleBody(int vehicleBodyId);
        VehicleModel GetVehicleModel(int modelId);
        VehicleType GetVehicleType(int vehicleTypeId);

        PurchaseStatus GetPuchaseStatusForAddedVehicle();
        List<AppUser> GetAllUsers();
        List<IdentityRole> GetAllRoles();
    }
}
