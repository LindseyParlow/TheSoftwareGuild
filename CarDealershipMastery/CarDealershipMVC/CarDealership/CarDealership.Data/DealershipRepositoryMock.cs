using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using CarDealership.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarDealership.Data
{
    public class DealershipRepositoryMock : IDealershipRepository
    {
        private static List<Address> _addresses;
        private static List<ContactUsQuery> _contactUsQueries;
        private static List<Customer> _customers;
        private static List<Dealership> _dealerships;
        private static List<AppUser> _appUsers;
        private static List<IdentityRole> _appRoles;
        private static List<Phone> _phones;
        private static List<Purchase> _purchases;
        private static List<PurchaseStatus> _purchaseStatus;
        private static List<PurchaseType> _purchaseType;
        private static List<Special> _specials;
        private static List<State> _states;
        private static List<Transmission> _transmissions;
        private static List<Vehicle> _vehicles;
        private static List<VehicleBody> _vehicleBodies;
        private static List<VehicleMake> _vehicleMakes;
        private static List<VehicleModel> _vehicleModels;
        private static List<VehicleType> _VehicleTypes;

        static DealershipRepositoryMock()
        {
            _states = new List<State>()
            {
                new State {StateId = 1, StateName = "Alabama"},
                new State {StateId = 2, StateName = "Alaska"},
                new State {StateId = 3, StateName = "Arizona"},
                new State {StateId = 4, StateName = "Arkansas"},
                new State {StateId = 5, StateName = "California"},
                new State {StateId = 6, StateName = "Colorado"},
                new State {StateId = 7, StateName = "Conneticut"},
                new State {StateId = 8, StateName = "Delaware"},
                new State {StateId = 9, StateName = "Florida"},
                new State {StateId = 10, StateName = "Georgia"},
                new State {StateId = 11, StateName = "Hawaii"},
                new State {StateId = 12, StateName = "Idaho"},
            };

            _addresses = new List<Address>()
            {
                new Address
                {
                    AddressId = 1,
                    Street1 = "123 Apple St NW",
                    Street2 = "Apt 100",
                    City = "Alpaca",
                    StateId = 3,
                    ZipCode = 55111,

                    State = _states[2]
                },
                new Address
                {
                    AddressId = 2,
                    Street1 = "234 Banana St NW",
                    Street2 = "Apt 200",
                    City = "Bat",
                    StateId = 6,
                    ZipCode = 55222,

                    State = _states[5]
                },
                new Address
                {
                    AddressId = 3,
                    Street1 = "345 Cantalope St NW",
                    Street2 = "Apt 300",
                    City = "Catfish",
                    StateId = 9,
                    ZipCode = 55333,

                    State = _states[8]
                },
                new Address
                {
                    AddressId = 4,
                    Street1 = "456 Durian St NW",
                    Street2 = "Apt 400",
                    City = "Dog",
                    StateId = 12,
                    ZipCode = 55444,

                    State = _states[11]
                },
            };
            
            _customers = new List<Customer>()
            {
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Jake Ganser",
                    Email = "Jake.Ganser@gmail.com",
                    Phone = "763-555-1111",
                    AddressId = 1,

                    Address = _addresses[0]
                },
                new Customer
                {
                    CustomerId = 2,
                    CustomerName = "Judy Thao",
                    Email = "Judy.Thao@gmail.com",
                    Phone = "763-555-2222",
                    AddressId = 2,

                    Address = _addresses[1]
                },
                new Customer
                {
                    CustomerId = 3,
                    CustomerName = "Nik Clay",
                    Email = "Nik.Clay@gmail.com",
                    Phone = "612-555-4444",
                    AddressId = 3,

                    Address = _addresses[2]
                },
            };


            //_employees = new List<Employee>()
            //{
            //    new Employee
            //    {
            //        EmployeeId = 1,
            //        LastName = "Rohde",
            //        FirstName = "AJ",
            //        Email = "AJ.Rohde@gmail.com",
            //        Password = "ARohde123"
            //    },
            //    new Employee
            //    {
            //        EmployeeId = 2,
            //        LastName = "Hirsi",
            //        FirstName = "Ali",
            //        Email = "Ali.Hirsi@gmail.com",
            //        Password = "AHirsi123"
            //    },
            //    new Employee
            //    {
            //        EmployeeId = 3,
            //        LastName = "Doul",
            //        FirstName = "Na",
            //        Email = "Na.Doul@gmail.com",
            //        Password = "NDoul123"
            //    },
            //};
            _appUsers = new List<AppUser>()
            {
                new AppUser
                {
                    Id = "user1",
                    FirstName = "Mark",
                    LastName = "Johnson"
                },
                new AppUser
                {
                    Id = "user2",
                    FirstName = "AJ",
                    LastName = "Rohde"
                },
                new AppUser
                {
                    Id = "user3",
                    FirstName = "Lindsey",
                    LastName = "Parlow"
                },
            };

            _appRoles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = "role1",
                    Name = "Admin"
                },
                new IdentityRole
                {
                    Id = "role2",
                    Name = "Sales"
                },
                new IdentityRole
                {
                    Id = "role3",
                    Name = "Disabled"
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
                    PurchaseStatusId = 2,
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
                    SpecialDescription = "Any truck purchase is an extra 10% off sale price!"
                },
                new Special
                {
                    SpecialId = 2,
                    SpecialTitle = "New Vehicle Weekend",
                    SpecialDescription = "Get an extra $500 off when you purchase a new vehicle!"
                },
                new Special
                {
                    SpecialId = 3,
                    SpecialTitle = "Oldy But A Good Extravaganza",
                    SpecialDescription = "Purchase a vehicle over 15 years old and get a 15% discount!"
                },
                new Special
                {
                    SpecialId = 4,
                    SpecialTitle = "Special 4",
                    SpecialDescription = "This is special 4's description!"
                },
                new Special
                {
                    SpecialId = 5,
                    SpecialTitle = "Special 5",
                    SpecialDescription = "This is special 5's description!"
                },
                new Special
                {
                    SpecialId = 6,
                    SpecialTitle = "Special 6",
                    SpecialDescription = "This is special 6's description!"
                }
            };
            
            _transmissions = new List<Transmission>()
            {
                new Transmission
                {
                    TransmissionId = 1,
                    TransmissionType = "Automatic"
                },
                new Transmission
                {
                    TransmissionId = 2,
                    TransmissionType = "Manual"
                },
            };

            _vehicleBodies = new List<VehicleBody>()
            {
                new VehicleBody
                {
                    VehicleBodyId = 1,
                    VehicleBodyDescription = "Car"
                },
                new VehicleBody
                {
                    VehicleBodyId = 2,
                    VehicleBodyDescription = "SUV"
                },
                new VehicleBody
                {
                    VehicleBodyId = 3,
                    VehicleBodyDescription = "Truck"
                },
                new VehicleBody
                {
                    VehicleBodyId = 4,
                    VehicleBodyDescription = "Van"
                },
            };

            _vehicleMakes = new List<VehicleMake>()
            {
                new VehicleMake
                {
                    VehicleMakeId = 1,
                    VehicleMakeDescription = "Ford",
                    DateAdded = new DateTime(2000, 03, 01),

                    User = _appUsers[1]
                },
                new VehicleMake
                {
                    VehicleMakeId = 2,
                    VehicleMakeDescription = "Dodge",
                    DateAdded = new DateTime(2000, 03, 01),

                    User = _appUsers[2]
                },
                new VehicleMake
                {
                    VehicleMakeId = 3,
                    VehicleMakeDescription = "Jeep",
                    DateAdded = new DateTime(2000, 03, 01),

                    User = _appUsers[0]
                },
            };

            _vehicleModels = new List<VehicleModel>()
            {
                new VehicleModel
                {
                    VehicleModelId = 1,
                    VehicleModelDescription = "Escape",
                    DateAdded = new DateTime(2009,03, 02),
                    VehicleMakeId = 1,

                    User = _appUsers[1],
                    VehicleMake = _vehicleMakes[0]
                },
                new VehicleModel
                {
                    VehicleModelId = 2,
                    VehicleModelDescription = "Escort",
                    DateAdded = new DateTime(2009,03, 02),
                    VehicleMakeId = 1,

                    User = _appUsers[1],
                    VehicleMake = _vehicleMakes[0]
                },
                new VehicleModel
                {
                    VehicleModelId = 3,
                    VehicleModelDescription = "Ram 1500",
                    DateAdded = new DateTime(2005,05, 09),
                    VehicleMakeId = 2,

                    User = _appUsers[0],
                    VehicleMake = _vehicleMakes[1]
                },
                new VehicleModel
                {
                    VehicleModelId = 4,
                    VehicleModelDescription = "Renegade",
                    DateAdded = new DateTime(2005, 05, 09),
                    VehicleMakeId = 3,

                    User = _appUsers[2],
                    VehicleMake = _vehicleMakes[2]
                },
                new VehicleModel
                {
                    VehicleModelId = 5,
                    VehicleModelDescription = "Focus",
                    DateAdded = new DateTime(2000, 06, 06),
                    VehicleMakeId = 1,

                    User = _appUsers[2],
                    VehicleMake = _vehicleMakes[0]
                }
            };

            _VehicleTypes = new List<VehicleType>()
            {
                new VehicleType
                {
                    VehicleTypeId = 1,
                    VehicleTypeDescription = "New"
                },
                new VehicleType
                {
                    VehicleTypeId = 2,
                    VehicleTypeDescription = "Used"
                }
            };

            _vehicles = new List<Vehicle>()
            {
                new Vehicle
                {
                    VehicleId = 1,
                    ImagePath = "redcar.png",
                    VehicleTypeId = 1,
                    VehicleModelId = 2,
                    TransmissionId = 2,
                    SalePrice = 16500,
                    MSRPPrice = 18750,
                    VehicleBodyId = 1,
                    Year = 2017,
                    VehicleColor = "Red",
                    InteriorColor = "Gray",
                    VinNumber = "1NXBR32EX6Z624118",
                    Mileage = 500,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2017, 09, 03),
                    PurchaseStatusId = 2,
                    IsFeatured = true,

                    VehicleType = _VehicleTypes[0],
                    VehicleModel = _vehicleModels[1],
                    Transmission = _transmissions[1],
                    VehicleBody = _vehicleBodies[0],
                    PurchaseStatus = _purchaseStatus[1]
                },
                new Vehicle
                {
                    VehicleId = 2,
                    ImagePath = "greentruck.jpg",
                    VehicleTypeId = 2,
                    VehicleModelId = 3,
                    TransmissionId = 1,
                    SalePrice = 7250,
                    MSRPPrice = 8000,
                    VehicleBodyId = 3,
                    Year = 1998,
                    VehicleColor = "Green",
                    InteriorColor = "Gray",
                    VinNumber = "3C3CFFFH0CT163609",
                    Mileage = 62000,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2014, 02, 08),
                    PurchaseStatusId = 2,
                    IsFeatured = true,

                    VehicleType = _VehicleTypes[1],
                    VehicleModel = _vehicleModels[2],
                    Transmission = _transmissions[0],
                    VehicleBody = _vehicleBodies[2],
                    PurchaseStatus = _purchaseStatus[1]
                },
                new Vehicle
                {
                    VehicleId = 3,
                    ImagePath = "whitevan.jpg",
                    VehicleTypeId = 1,
                    VehicleModelId = 2,
                    TransmissionId = 2,
                    SalePrice = 22875,
                    MSRPPrice = 26250,
                    VehicleBodyId = 4,
                    Year = 2016,
                    VehicleColor = "White",
                    InteriorColor = "Black",
                    VinNumber = "2P4FP25B2VR305648",
                    Mileage = 850,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2017, 01, 20),
                    PurchaseStatusId = 2,
                    IsFeatured = true,

                    VehicleType = _VehicleTypes[0],
                    VehicleModel = _vehicleModels[1],
                    Transmission = _transmissions[1],
                    VehicleBody = _vehicleBodies[3],
                    PurchaseStatus = _purchaseStatus[1]
                },
                new Vehicle
                {
                    VehicleId = 4,
                    ImagePath = "redcar.png",
                    VehicleTypeId = 2,
                    VehicleModelId = 1,
                    TransmissionId = 1,
                    SalePrice = 6800,
                    MSRPPrice = 7500,
                    VehicleBodyId = 1,
                    Year = 2003,
                    VehicleColor = "Red",
                    InteriorColor = "Black",
                    VinNumber = "1B7FL26P6XS316728",
                    Mileage = 120000,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2015, 05, 28),
                    PurchaseStatusId = 2,
                    IsFeatured = false,

                    VehicleType = _VehicleTypes[1],
                    VehicleModel = _vehicleModels[0],
                    Transmission = _transmissions[0],
                    VehicleBody = _vehicleBodies[0],
                    PurchaseStatus = _purchaseStatus[1]
                },
                new Vehicle
                {
                    VehicleId = 5,
                    ImagePath = "yellowcar.png",
                    VehicleTypeId = 1,
                    VehicleModelId = 2,
                    TransmissionId = 2,
                    SalePrice = 18500,
                    MSRPPrice = 21000,
                    VehicleBodyId = 1,
                    Year = 2017,
                    VehicleColor = "Yellow",
                    InteriorColor = "Black",
                    VinNumber = "1GDJC34J6YF591469",
                    Mileage = 350,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2017, 10, 01),
                    PurchaseStatusId = 1,
                    IsFeatured = false,

                    VehicleType = _VehicleTypes[0],
                    VehicleModel = _vehicleModels[1],
                    Transmission = _transmissions[1],
                    VehicleBody = _vehicleBodies[0],
                    PurchaseStatus = _purchaseStatus[0]
                },
                new Vehicle
                {
                    VehicleId = 6,
                    ImagePath = "redsuv.jpg",
                    VehicleTypeId = 2,
                    VehicleModelId = 1,
                    TransmissionId = 1,
                    SalePrice = 9900,
                    MSRPPrice = 10250,
                    VehicleBodyId = 2,
                    Year = 2005,
                    VehicleColor = "Red",
                    InteriorColor = "White",
                    VinNumber = "JD1EG1122M4427105",
                    Mileage = 28500,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2011, 01, 20),
                    PurchaseStatusId = 2,
                    IsFeatured = true,

                    VehicleType = _VehicleTypes[1],
                    VehicleModel = _vehicleModels[0],
                    Transmission = _transmissions[0],
                    VehicleBody = _vehicleBodies[1],
                    PurchaseStatus = _purchaseStatus[1]
                },
                new Vehicle
                {
                    VehicleId = 7,
                    ImagePath = "bluesuv.png",
                    VehicleTypeId = 1,
                    VehicleModelId = 1,
                    TransmissionId = 2,
                    SalePrice = 16500,
                    MSRPPrice = 18000,
                    VehicleBodyId = 2,
                    Year = 2017,
                    VehicleColor = "Blue",
                    InteriorColor = "Black",
                    VinNumber = "1GNFK16397J314592",
                    Mileage = 900,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2017, 02, 18),
                    PurchaseStatusId = 2,
                    IsFeatured = true,

                    VehicleType = _VehicleTypes[0],
                    VehicleModel = _vehicleModels[0],
                    Transmission = _transmissions[1],
                    VehicleBody = _vehicleBodies[1],
                    PurchaseStatus = _purchaseStatus[1]
                },
                new Vehicle
                {
                    VehicleId = 8,
                    ImagePath = "greencar.jpg",
                    VehicleTypeId = 2,
                    VehicleModelId = 2,
                    TransmissionId = 1,
                    SalePrice = 11250,
                    MSRPPrice = 11750,
                    VehicleBodyId = 1,
                    Year = 2003,
                    VehicleColor = "Green",
                    InteriorColor = "Gray",
                    VinNumber = "JA3AJ36B23U019320",
                    Mileage = 48000,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2008, 09, 15),
                    PurchaseStatusId = 1,
                    IsFeatured = false,

                    VehicleType = _VehicleTypes[1],
                    VehicleModel = _vehicleModels[1],
                    Transmission = _transmissions[0],
                    VehicleBody = _vehicleBodies[0],
                    PurchaseStatus = _purchaseStatus[0]
                },
                new Vehicle
                {
                    VehicleId = 9,
                    ImagePath = "whitetruck.jpg",
                    VehicleTypeId = 1,
                    VehicleModelId = 3,
                    TransmissionId = 2,
                    SalePrice = 14900,
                    MSRPPrice = 15800,
                    VehicleBodyId = 3,
                    Year = 2016,
                    VehicleColor = "White",
                    InteriorColor = "Black",
                    VinNumber = "LM4AC11A7T1159824",
                    Mileage = 500,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2014, 11, 04),
                    PurchaseStatusId = 2,
                    IsFeatured = false,

                    VehicleType = _VehicleTypes[0],
                    VehicleModel = _vehicleModels[2],
                    Transmission = _transmissions[1],
                    VehicleBody = _vehicleBodies[2],
                    PurchaseStatus = _purchaseStatus[1]
                },
                new Vehicle
                {
                    VehicleId = 10,
                    ImagePath = "greenvan.png",
                    VehicleTypeId = 2,
                    VehicleModelId = 4,
                    TransmissionId = 2,
                    SalePrice = 8500,
                    MSRPPrice = 10250,
                    VehicleBodyId = 4,
                    Year = 2007,
                    VehicleColor = "Green",
                    InteriorColor = "Gray",
                    VinNumber = "1B7HM26Y9KS023056",
                    Mileage = 78000,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2009, 08, 8),
                    PurchaseStatusId = 2,
                    IsFeatured = true,

                    VehicleType = _VehicleTypes[1],
                    VehicleModel = _vehicleModels[3],
                    Transmission = _transmissions[1],
                    VehicleBody = _vehicleBodies[3],
                    PurchaseStatus = _purchaseStatus[1]
                },
                new Vehicle
                {
                    VehicleId = 11,
                    ImagePath = "bluecar.jpg",
                    VehicleTypeId = 1,
                    VehicleModelId = 5,
                    TransmissionId = 1,
                    SalePrice = 29000,
                    MSRPPrice = 33000,
                    VehicleBodyId = 1,
                    Year = 2018,
                    VehicleColor = "Blue",
                    InteriorColor = "White",
                    VinNumber = "1FMJK1J50BEA31636",
                    Mileage = 200,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2010, 10,10),
                    PurchaseStatusId = 1,
                    IsFeatured = true,

                    VehicleType = _VehicleTypes[0],
                    VehicleModel = _vehicleModels[4],
                    Transmission = _transmissions[0],
                    VehicleBody = _vehicleBodies[0],
                    PurchaseStatus = _purchaseStatus[0]
                },
                new Vehicle
                {
                    VehicleId = 12,
                    ImagePath = "redcar.png",
                    VehicleTypeId = 2,
                    VehicleModelId = 5,
                    TransmissionId = 1,
                    SalePrice = 12750,
                    MSRPPrice = 13500,
                    VehicleBodyId = 1,
                    Year = 2010,
                    VehicleColor = "Red",
                    InteriorColor = "Black",
                    VinNumber = "JH4CL95946C070364",
                    Mileage = 6000,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2006, 01, 24),
                    PurchaseStatusId = 2,
                    IsFeatured = false,

                    VehicleType = _VehicleTypes[1],
                    VehicleModel = _vehicleModels[4],
                    Transmission = _transmissions[0],
                    VehicleBody = _vehicleBodies[0],
                    PurchaseStatus = _purchaseStatus[1]
                },
                new Vehicle
                {
                    VehicleId = 13,
                    ImagePath = "whitesuv.jpg",
                    VehicleTypeId = 1,
                    VehicleModelId = 1,
                    TransmissionId = 2,
                    SalePrice = 21500,
                    MSRPPrice = 22750,
                    VehicleBodyId = 2,
                    Year = 2018,
                    VehicleColor = "White",
                    InteriorColor = "White",
                    VinNumber = "2P4FP25B2VR305648",
                    Mileage = 150,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2007, 10, 17),
                    PurchaseStatusId = 2,
                    IsFeatured = false,

                    VehicleType = _VehicleTypes[0],
                    VehicleModel = _vehicleModels[0],
                    Transmission = _transmissions[1],
                    VehicleBody = _vehicleBodies[1],
                    PurchaseStatus = _purchaseStatus[1]
                },
                new Vehicle
                {
                    VehicleId = 14,
                    ImagePath = "yellowsuv.jpg",
                    VehicleTypeId = 2,
                    VehicleModelId = 5,
                    TransmissionId = 2,
                    SalePrice = 6750,
                    MSRPPrice = 8250,
                    VehicleBodyId = 2,
                    Year = 2003,
                    VehicleColor = "Yellow",
                    InteriorColor = "Gray",
                    VinNumber = "1HTSLAAL7VH407274",
                    Mileage = 85000,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2017, 03, 09),
                    PurchaseStatusId = 2,
                    IsFeatured = false,

                    VehicleType = _VehicleTypes[1],
                    VehicleModel = _vehicleModels[4],
                    Transmission = _transmissions[1],
                    VehicleBody = _vehicleBodies[1],
                    PurchaseStatus = _purchaseStatus[1]
                },
                new Vehicle
                {
                    VehicleId = 15,
                    ImagePath = "greentruck.jpg",
                    VehicleTypeId = 1,
                    VehicleModelId = 3,
                    TransmissionId = 1,
                    SalePrice = 17500,
                    MSRPPrice = 19000,
                    VehicleBodyId = 3,
                    Year = 2017,
                    VehicleColor = "Green",
                    InteriorColor = "Black",
                    VinNumber = "1FUYDMCB9SP577754",
                    Mileage = 850,
                    VehicleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
                    DateAdded = new DateTime(2016, 06, 24),
                    PurchaseStatusId = 2,
                    IsFeatured = true,

                    VehicleType = _VehicleTypes[0],
                    VehicleModel = _vehicleModels[2],
                    Transmission = _transmissions[0],
                    VehicleBody = _vehicleBodies[2],
                    PurchaseStatus = _purchaseStatus[1]
                },
            };

            _contactUsQueries = new List<ContactUsQuery>()
            {
                new ContactUsQuery
                {
                    ContactUsQueryId = 1,
                    FullName = "Mark Johnson",
                    Email = "Mark.Johnson@gmail.com",
                    Phone = "651-555-6666",
                    Message = "Hey, will you find me a car like this but in blue?",
                    VehicleId = 2,

                    Vehicle = _vehicles[1]
                },
                new ContactUsQuery
                {
                    ContactUsQueryId = 2,
                    FullName = "Rob Reynolds",
                    Email = "Rob.Reynolds@gmail.com",
                    Phone = "651-555-9999",
                    Message = "Do you accept trades?",
                    VehicleId = null,
                },
                new ContactUsQuery
                {
                    ContactUsQueryId = 3,
                    FullName = "Javier Aguirre",
                    Email = "Javier.Aguirre@gmail.com",
                    Phone = "763-555-1212",
                    Message = "I need a sweet truck!",
                    VehicleId = null
                },
            };

            _purchases = new List<Purchase>()
            {
                new Purchase
                {
                    PurchaseId = 1,
                    PurchasePrice = 18300,
                    PurchaseTypeId = 3,
                    CustomerId = 2,
                    VehicleId = 5,
                    DatePurchased = new DateTime(2017, 10, 26),

                    PurchaseType = _purchaseType[2],
                    User = _appUsers[0],
                    Customer = _customers[1],
                    Vehicle = _vehicles[4]
                },
                new Purchase
                {
                    PurchaseId = 2,
                    PurchasePrice = 10900,
                    PurchaseTypeId = 2,
                    CustomerId = 3,
                    VehicleId = 8,
                    DatePurchased = new DateTime(2017, 10, 01),

                    PurchaseType = _purchaseType[1],
                    User = _appUsers[1],
                    Customer = _customers[2],
                    Vehicle = _vehicles[7]
                },
                new Purchase
                {
                    PurchaseId = 3,
                    PurchasePrice = 27750,
                    PurchaseTypeId = 1,
                    CustomerId = 1,
                    VehicleId = 11,
                    DatePurchased = new DateTime(2017, 09, 13),

                    PurchaseType = _purchaseType[0],
                    User = _appUsers[1],
                    Customer = _customers[0],
                    Vehicle = _vehicles[10]
                },
            };

            _phones = new List<Phone>()
            {
                new Phone
                {
                    PhoneId = 1,
                    PhoneType = "Office",
                    PhoneNumber = "555-555-1111",
                },
                new Phone
                {
                    PhoneId = 2,
                    PhoneType = "Sales",
                    PhoneNumber = "555-555-2222",
                },
                new Phone
                {
                    PhoneId = 3,
                    PhoneType = "Service",
                    PhoneNumber = "555-555-3333",
                },
            };

            _dealerships = new List<Dealership>()
            {
                new Dealership
                {
                    DealershipId = 1,
                    DealerShipName = "Lindsey's Amazing Car Dealership",
                    AddressId = 4,
                    Phones = _phones,

                    Address = _addresses[3]
                }
            };
        }

        //public void AddUser(AppUser userToAdd)
        //{
        //    if (_appUsers.Any())
        //    {
        //        userToAdd.Id = _appUsers.Max(e => e.Id) + 1;
        //    }
        //    else
        //    {
        //        userToAdd.Id = 1;
        //    }

        //    _appUsers.Add(userToAdd);
        //}

        public void AddMake(VehicleMake vehicleMake)
        {
            if (_vehicleMakes.Any())
            {
                vehicleMake.VehicleMakeId = _vehicleMakes.Max(m => m.VehicleMakeId) + 1;
            }
            else
            {
                vehicleMake.VehicleMakeId = 1;
            }

            _vehicleMakes.Add(vehicleMake);
        }

        public void AddModel(VehicleModel vehicleModel)
        {
            if (_vehicleModels.Any())
            {
                vehicleModel.VehicleModelId = _vehicleModels.Max(m => m.VehicleModelId) + 1;
            }
            else
            {
                vehicleModel.VehicleModelId = 1;
            }

            _vehicleModels.Add(vehicleModel);
        }

        public void AddContactUsQuery(ContactUsQuery contactUsQueryToAdd)
        {
            if (_contactUsQueries.Any())
            {
                contactUsQueryToAdd.ContactUsQueryId = _contactUsQueries.Max(s => s.ContactUsQueryId) + 1;
            }
            else
            {
                contactUsQueryToAdd.ContactUsQueryId = 1;
            }

            _contactUsQueries.Add(contactUsQueryToAdd);
        }

        public void AddSpecial(Special specialToAdd)
        {
            if (_specials.Any())
            {
                specialToAdd.SpecialId = _specials.Max(s => s.SpecialId) + 1;
            }
            else
            {
                specialToAdd.SpecialId = 1;
            }

            _specials.Add(specialToAdd);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (_vehicles.Any())
            {
                vehicle.VehicleId = _vehicles.Max(v => v.VehicleId) + 1;
            }
            else
            {
                vehicle.VehicleId = 1;
            }

            _vehicles.Add(vehicle);
        }

        public void DeleteSpecial(int specialId)
        {
            _specials.RemoveAll(s => s.SpecialId == specialId);
        }

        public void DeleteVehicle(int vehicleId)
        {
            _vehicles.RemoveAll(v => v.VehicleId == vehicleId);
        }

        public void EditVehicle(Vehicle vehicleToEdit)
        {
            _vehicles.RemoveAll(v => v.VehicleId == vehicleToEdit.VehicleId);
            _vehicles.Add(vehicleToEdit);
        }

        public List<Vehicle> GetAllFeaturedVehicles()
        {
            return _vehicles.Where(v => v.IsFeatured && v.PurchaseStatus.PurchaseStatusDescription == "Available").ToList();
        }

        public List<Special> GetAllSpecials()
        {
            return _specials;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicles;
        }

        public List<Vehicle> GetTop20NewVehicles()
        {
            var vehicles = _vehicles.Where(t => t.VehicleType.VehicleTypeDescription == "New").OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20UsedVehicles()
        {
            var vehicles = _vehicles.Where(t => t.VehicleType.VehicleTypeDescription == "Used").OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public List<ContactUsQuery> GetAllContactUsQueries()
        {
            return _contactUsQueries;
        }

        public List<Vehicle> GetNewVehicleByMegaSearchFilter(string input, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            var vehicles = _vehicles.Where(p => p.VehicleType.VehicleTypeDescription == "New" && p.SalePrice >= minPrice && p.SalePrice <= maxPrice && p.Year >= minYear && p.Year <= maxYear);

            if (input == "noVehicleInput")
            {
                return vehicles.ToList();
            }
            else
            {
                return vehicles.Where(v => v.VehicleModel.VehicleMake.VehicleMakeDescription.Contains(input) || v.VehicleModel.VehicleModelDescription.Contains(input) || v.Year.ToString().Contains(input)).ToList();
            }
        }

        public List<Vehicle> GetUsedVehicleByMegaSearchFilter(string input, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            var vehicles = _vehicles.Where(p => p.VehicleType.VehicleTypeDescription == "Used" && p.SalePrice >= minPrice && p.SalePrice <= maxPrice && p.Year >= minYear && p.Year <= maxYear);

            if (input == "noVehicleInput")
            {
                return vehicles.ToList();
            }
            else
            {
                return vehicles.Where(v => v.VehicleModel.VehicleMake.VehicleMakeDescription.Contains(input) || v.VehicleModel.VehicleModelDescription.Contains(input) || v.Year.ToString().Contains(input)).ToList();
            }
        }

        public Vehicle GetVehicleDetailsByVehicleId(int vehicleId)
        {
            return _vehicles.Single(v => v.VehicleId == vehicleId);
        }

        public List<Vehicle> GetNewAndUsedVehiclesForSales()
        {
            var vehicles = _vehicles.Where(v => v.PurchaseStatus.PurchaseStatusDescription == "Available").OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetFilteredNewAndUsedVehiclesForSales(string input, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            var vehicles = _vehicles.Where(p => p.PurchaseStatus.PurchaseStatusDescription == "Available" && p.SalePrice >= minPrice && p.SalePrice <= maxPrice && p.Year >= minYear && p.Year <= maxYear);

            if (input == "noVehicleInput")
            {
                return vehicles.ToList();
            }
            else
            {
                return vehicles.Where(v => v.VehicleModel.VehicleMake.VehicleMakeDescription.Contains(input) || v.VehicleModel.VehicleModelDescription.Contains(input) || v.Year.ToString().Contains(input)).ToList();
            }
        }

        public List<State> GetAllStates()
        {
            return _states;
        }

        public List<PurchaseType> GetAllPurchaseTypes()
        {
            return _purchaseType;
        }

        public List<Phone> GetAllDealershipPhoneNumbers()
        {
            return _dealerships.SelectMany(p => p.Phones).ToList();
        }

        public List<VehicleMake> GetAllMakes()
        {
            return _vehicleMakes;
        }

        public List<VehicleModel> GetAllModels()
        {
            return _vehicleModels;
        }

        public List<VehicleType> GetAllVehicleTypes()
        {
            return _VehicleTypes;
        }

        public List<VehicleBody> GetAllBodyStyles()
        {
            return _vehicleBodies;
        }

        public List<Transmission> GetAllTransmissionTypes()
        {
            return _transmissions;
        }

        public List<VehicleMake> GetAllVehicleMakes()
        {
            return _vehicleMakes;
        }

        public List<VehicleModel> GetVehicleModelsByVehicleMake(int makeId)
        {
            return _vehicleModels.Where(v => v.VehicleMake.VehicleMakeId == makeId).ToList();
        }

        public PurchaseStatus GetPurchaseStatus(int purchaseStatusId)
        {
            return _purchaseStatus.Single(p => p.PurchaseStatusId == purchaseStatusId);
        }

        public Transmission GetTransmission(int transmissionId)
        {
            return _transmissions.Single(t => t.TransmissionId == transmissionId);
        }

        public VehicleBody GetVehicleBody(int vehicleBodyId)
        {
            return _vehicleBodies.Single(v => v.VehicleBodyId == vehicleBodyId);
        }

        public VehicleModel GetVehicleModel(int modelId)
        {
            return _vehicleModels.Single(v => v.VehicleModelId == modelId);
        }

        public VehicleType GetVehicleType(int vehicleTypeId)
        {
            return _VehicleTypes.Single(v => v.VehicleTypeId == vehicleTypeId);
        }

        public PurchaseStatus GetPuchaseStatusForAddedVehicle()
        {
            return _purchaseStatus.Single(v => v.PurchaseStatusDescription == "Available");
        }

        public List<AppUser> GetAllUsers()
        {
            return _appUsers;
        }

        public List<IdentityRole> GetAllRoles()
        {
            return _appRoles;
        }
    }
}

