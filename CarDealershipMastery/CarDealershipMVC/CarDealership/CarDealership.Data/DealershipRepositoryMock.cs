using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;

namespace CarDealership.Data
{
    public class DealershipRepositoryMock : IDealershipRepository
    {
        private static List<Address> _addresses;
        private static List<ContactUsQuery> _contactUsQueries;
        private static List<Customer> _customers;
        private static List<Dealership> _dealerships;
        private static List<Employee> _employees;
        private static List<Phone> _phones;
        private static List<Purchase> _purchases;
        private static List<PurchaseStatus> _purchaseStatus;
        private static List<PurchaseType> _purchaseType;
        private static List<Special> _specials;
        private static List<State> _states;
        private static List<Transmission> _Transmissions;
        private static List<Vehicle> _vehicles;
        private static List<VehicleBody> _vehicleBodies;
        private static List<VehicleMake> _vehicleMakes;
        private static List<VehicleModel> _vehicleModels;
        private static List<VehicleType> _VehicleTypes;

        static DealershipRepositoryMock()
        {
            _addresses = new List<Address>()
            {
                new Address
                {
                    AddressId = 1,
                    Street1 = "123 Apple St NW",
                    Street2 = "Apt 100",
                    City = "Alpaca",
                    StateId = 3,
                    ZipCode = 55111
                },
                new Address
                {
                    AddressId = 2,
                    Street1 = "234 Banana St NW",
                    Street2 = "Apt 200",
                    City = "Bat",
                    StateId = 6,
                    ZipCode = 55222
                },
                new Address
                {
                    AddressId = 3,
                    Street1 = "345 Cantalope St NW",
                    Street2 = "Apt 300",
                    City = "Catfish",
                    StateId = 9,
                    ZipCode = 55000
                },
                new Address
                {
                    AddressId = 4,
                    Street1 = "456 Durian St NW",
                    Street2 = "Apt 400",
                    City = "Dog",
                    StateId = 12,
                    ZipCode = 55000
                },
            };

            _contactUsQueries = new List<ContactUsQuery>()
            {
                new ContactUsQuery
                {
                    ContactUsQueryId = 1,
                    FirstName = "Mark",
                    LastName = "Johnson",
                    Email = "Mark.Johnson@gmail.com",
                    PhoneId = 3,
                    Message = "Hey, will you find me a car like this but in blue?",
                    DateQueryToCustomer = new DateTime(2017, 10, 01),
                    DateQueryToDealership = new DateTime(2017, 10, 02),
                    VehicleId = 2
                },
                new ContactUsQuery
                {
                    ContactUsQueryId = 2,
                    FirstName = "Rob",
                    LastName = "Reynolds",
                    Email = "Rob.Reynolds@gmail.com",
                    PhoneId = 2,
                    Message = "Do you accept trades?",
                    DateQueryToCustomer = new DateTime(2017, 10, 013),
                    DateQueryToDealership = new DateTime(2017, 10, 14),
                    VehicleId = null
                },
                new ContactUsQuery
                {
                    ContactUsQueryId = 3,
                    FirstName = "Javier",
                    LastName = "Aguirre",
                    Email = "Javier.Aguirre@gmail.com",
                    PhoneId = 1,
                    Message = "I need a sweet truck!",
                    DateQueryToCustomer = new DateTime(2017, 10, 26),
                    DateQueryToDealership = new DateTime(2017, 10, 27),
                    VehicleId = null
                },
            };

            _customers = new List<Customer>()
            {
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Jake",
                    LastName = "Ganser",
                    Email = "Jake.Ganser@gmail.com",
                    PhoneId = 6,
                    CustomerMessage = "Why did I make this section?",
                    AddressId = 1
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Judy",
                    LastName = "Thao",
                    Email = "Judy.Thao@gmail.com",
                    PhoneId = 5,
                    CustomerMessage = "Why did I make this section?",
                    AddressId = 2
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Nik",
                    LastName = "Clay",
                    Email = "Nik.Clay@gmail.com",
                    PhoneId = 4,
                    CustomerMessage = "Why did I make this section?",
                    AddressId = 3
                },
            };

            _dealerships = new List<Dealership>()
            {
                new Dealership
                {
                    DealershipId = 1,
                    DealerShipName = "Lindsey's Amazing Car Dealership",
                    AddressId = 4,
                    Phone = _phones.Where(p => p.PhoneId == 7 || p.PhoneId == 8).ToList()
                }
            };

            _employees = new List<Employee>()
            {
                new Employee
                {
                    EmployeeId = 1,
                    LastName = "Rohode",
                    FirstName = "AJ",
                    Email = "AJ.Rohode@gmail.com",
                    Password = "ARhode123"
                },
                new Employee
                {
                    EmployeeId = 2,
                    LastName = "Hirsi",
                    FirstName = "Ali",
                    Email = "Ali.Hirsi@gmail.com",
                    Password = "AHirsi123"
                },
                new Employee
                {
                    EmployeeId = 3,
                    LastName = "Doul",
                    FirstName = "Na",
                    Email = "Na.Doul@gmail.com",
                    Password = "NDoul123"
                },
            };

            _phones = new List<Phone>()
            {
                new Phone
                {
                    PhoneId = 1,
                    PhoneType = "Cell",
                    PhoneNumber = "555-555-1111",
                    Dealership = _dealerships.Where(d => d.DealershipId == 1).ToList()
                },
                new Phone
                {
                    PhoneId = 2,
                    PhoneType = "Home",
                    PhoneNumber = "555-555-2222",
                    Dealership = _dealerships.Where(d => d.DealershipId == 1).ToList()
                },
                new Phone
                {
                    PhoneId = 3,
                    PhoneType = "Cell",
                    PhoneNumber = "555-555-3333",
                    Dealership = _dealerships.Where(d => d.DealershipId == 1).ToList()
                },
                new Phone
                {
                    PhoneId = 4,
                    PhoneType = "Cell",
                    PhoneNumber = "555-555-4444",
                    Dealership = _dealerships.Where(d => d.DealershipId == 1).ToList()
                },
                new Phone
                {
                    PhoneId = 5,
                    PhoneType = "Cell",
                    PhoneNumber = "555-555-5555",
                    Dealership = _dealerships.Where(d => d.DealershipId == 1).ToList()
                },
                new Phone
                {
                    PhoneId = 6,
                    PhoneType = "Cell",
                    PhoneNumber = "555-555-6666",
                    Dealership = _dealerships.Where(d => d.DealershipId == 1).ToList()
                },
                new Phone
                {
                    PhoneId = 7,
                    PhoneType = "Cell",
                    PhoneNumber = "555-555-7777",
                    Dealership = _dealerships.Where(d => d.DealershipId == 1).ToList()
                },
                new Phone
                {
                    PhoneId = 8,
                    PhoneType = "Cell",
                    PhoneNumber = "555-555-8888",
                    Dealership = _dealerships.Where(d => d.DealershipId == 1).ToList()
                },
            };

            _purchases = new List<Purchase>()
            {
                new Purchase
                {
                    PurchaseId = 1,
                    PurchasePrice = 11000,
                    PurchaseTypeId = 1,
                    EmployeeId = 1,
                    CustomerId = 1,
                    VehicleId = 1,
                    DatePurchased = new DateTime(2017, 10, 26)
                },
                new Purchase
                {
                    PurchaseId = 2,
                    PurchasePrice = 12000,
                    PurchaseTypeId = 1,
                    EmployeeId = 1,
                    CustomerId = 1,
                    VehicleId = 1,
                    DatePurchased = new DateTime(2017, 10, 01)
                },
                new Purchase
                {
                    PurchaseId = 3,
                    PurchasePrice = 13000,
                    PurchaseTypeId = 1,
                    EmployeeId = 1,
                    CustomerId = 1,
                    VehicleId = 1,
                    DatePurchased = new DateTime(2017, 09, 13)
                },
            };

            _purchaseStatus = new List<PurchaseStatus>()
            {
                new PurchaseStatus
                {
                    PurchaseStatusId = 1,
                    PurchaseStatusDescription = "Sold"
                },
                new PurchaseStatus
                {
                    PurchaseStatusId = 1,
                    PurchaseStatusDescription = "Available"
                },
            };

            _purchaseType = new List<PurchaseType>
            {
                new PurchaseType
                {
                    PurchaseTypeId = 1,
                    PurchaseTypeDescription = "Bank Finance"
                },
                new PurchaseType
                {
                    PurchaseTypeId = 2,
                    PurchaseTypeDescription = "Cash"
                },
                new PurchaseType
                {
                    PurchaseTypeId = 3,
                    PurchaseTypeDescription = "Dealer Finance"
                },
            };

            _specials = new List<Special>()
            {
                new Special
                {
                    SpecialId = 1,
                    SpecialTitle = "Truck Month",
                    SpecialDescription = "Any truck purchase is an extra 10% off sale price!",
                    StartDate = new DateTime(2017, 12, 01),
                    EndDate = new DateTime(2017, 12, 31),
                    SpecialValue = .10M
                },
                new Special
                {
                    SpecialId = 2,
                    SpecialTitle = "First Time Buyer Weekend",
                    SpecialDescription = "If this is your first vehicle, get an extra $500 off your new vehicle purchase!",
                    StartDate = new DateTime(2017, 10, 27),
                    EndDate = new DateTime(2017, 10, 30),
                    SpecialValue = 500M
                },
            };
        }

        public void AddEmployee(Employee employeeToAdd)
        {
            throw new NotImplementedException();
        }

        public void AddMake(VehicleMake vehicleMake)
        {
            throw new NotImplementedException();
        }

        public void AddModel(VehicleModel vehicleModel)
        {
            throw new NotImplementedException();
        }

        public void AddSpecial(Special specialToAdd)
        {
            throw new NotImplementedException();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpecial(Special specialToDelete)
        {
            throw new NotImplementedException();
        }

        public void EditEmployee(Employee employeeToEdit)
        {
            throw new NotImplementedException();
        }

        public void EditVehicle(Vehicle vehicleToEdit)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllFeaturedVehicles()
        {
            throw new NotImplementedException();
        }

        public List<Special> GetAllSpecials()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllVehicles()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllVehiclesByMake()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllVehiclesByPriceRange()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllVehiclesByYear()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllVehiclesByYeareRange()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllVehiclesModel()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetTop20NewVehicles()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetTop20NewVehiclesByMake()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetTop20NewVehiclesByPriceRange()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetTop20NewVehiclesByYear()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetTop20NewVehiclesByYearRange()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetTop20NewVehiclesModel()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetTop20UsedVehicles()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetTop20UsedVehiclesByMake()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetTop20UsedVehiclesByPriceRange()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetTop20UsedVehiclesByYear()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetTop20UsedVehiclesByYeareRange()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetTop20UsedVehiclesModel()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleDetails()
        {
            throw new NotImplementedException();
        }
    }
}
