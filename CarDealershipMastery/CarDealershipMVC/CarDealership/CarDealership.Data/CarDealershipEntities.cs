using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class CarDealershipEntities : DbContext
    {
        public CarDealershipEntities() : base("CarDealership")
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactUsQuery> ContactUsQueries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dealership> Dealerships { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseStatus> PurchaseStatuses { get; set; }
        public DbSet<PurchaseType> PurcahseTypes { get; set; }
        public DbSet<Special> Specials { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleBody> VehicleBodies { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
    }
}
