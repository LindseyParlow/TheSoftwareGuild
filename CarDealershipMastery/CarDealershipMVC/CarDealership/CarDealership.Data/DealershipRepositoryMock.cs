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
        private static List<Transmission> _transmissions;
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
                    ZipCode = 55111,

                    State = _states[0]
                },
                new Address
                {
                    AddressId = 2,
                    Street1 = "234 Banana St NW",
                    Street2 = "Apt 200",
                    City = "Bat",
                    StateId = 6,
                    ZipCode = 55222,

                    State = _states[1]
                },
                new Address
                {
                    AddressId = 3,
                    Street1 = "345 Cantalope St NW",
                    Street2 = "Apt 300",
                    City = "Catfish",
                    StateId = 9,
                    ZipCode = 55000,

                    State = _states[2]
                },
                new Address
                {
                    AddressId = 4,
                    Street1 = "456 Durian St NW",
                    Street2 = "Apt 400",
                    City = "Dog",
                    StateId = 12,
                    ZipCode = 55000,

                    State = _states[3]
                },
            };

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
            
            _customers = new List<Customer>()
            {
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Jake",
                    LastName = "Ganser",
                    Email = "Jake.Ganser@gmail.com",
                    Phone = "763-555-1111",
                    AddressId = 1,

                    Address = _addresses[0]
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Judy",
                    LastName = "Thao",
                    Email = "Judy.Thao@gmail.com",
                    Phone = "763-555-2222",
                    AddressId = 2,

                    Address = _addresses[1]
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Nik",
                    LastName = "Clay",
                    Email = "Nik.Clay@gmail.com",
                    Phone = "612-555-4444",
                    AddressId = 3,

                    Address = _addresses[2]
                },
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
                    SpecialType = "Percent Off",
                    SpecialValue = .10M
                },
                new Special
                {
                    SpecialId = 2,
                    SpecialTitle = "First Buyer Weekend",
                    SpecialDescription = "If this is your first vehicle, get an extra $500 off your new vehicle purchase!",
                    StartDate = new DateTime(2017, 10, 27),
                    EndDate = new DateTime(2017, 10, 30),
                    SpecialType = "Dollar Off",
                    SpecialValue = 500M
                },
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
                    EmployeeId = 2,
                    DateAdded = new DateTime(2000, 03, 01),

                    Employee = _employees[1]
                },
                new VehicleMake
                {
                    VehicleMakeId = 1,
                    VehicleMakeDescription = "Dodge",
                    EmployeeId = 3,
                    DateAdded = new DateTime(2000, 03, 01),

                    Employee = _employees[2]
                },
                new VehicleMake
                {
                    VehicleMakeId = 1,
                    VehicleMakeDescription = "Jeep",
                    EmployeeId = 1,
                    DateAdded = new DateTime(2000, 03, 01),

                    Employee = _employees[0]
                },
            };

            _vehicleModels = new List<VehicleModel>()
            {
                new VehicleModel
                {
                    VehicleModelId = 1,
                    VehicleModelDescription = "Escape",
                    EmployeeId = 2,
                    DateAdded = new DateTime(2009,03, 02),
                    VehicleMakeId = 1,

                    Employee = _employees[1],
                    VehicleMake = _vehicleMakes[0]
                },
                new VehicleModel
                {
                    VehicleModelId = 2,
                    VehicleModelDescription = "Escort",
                    EmployeeId = 2,
                    DateAdded = new DateTime(2009,03, 02),
                    VehicleMakeId = 1,

                    Employee = _employees[1],
                    VehicleMake = _vehicleMakes[0]
                },
                new VehicleModel
                {
                    VehicleModelId = 3,
                    VehicleModelDescription = "Ram 1500",
                    EmployeeId = 1,
                    DateAdded = new DateTime(2005,05, 09),
                    VehicleMakeId = 2,

                    Employee = _employees[0],
                    VehicleMake = _vehicleMakes[1]
                },
                new VehicleModel
                {
                    VehicleModelId = 4,
                    VehicleModelDescription = "Renegade",
                    EmployeeId = 3,
                    DateAdded = new DateTime(2005, 05, 09),
                    VehicleMakeId = 3,

                    Employee = _employees[2],
                    VehicleMake = _vehicleMakes[2]
                },
                new VehicleModel
                {
                    VehicleModelId = 5,
                    VehicleModelDescription = "Focus",
                    EmployeeId = 3,
                    DateAdded = new DateTime(2000, 06, 06),
                    VehicleMakeId = 1,

                    Employee = _employees[2],
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
                    VehicleTypeId = 1,
                    VehicleModelId = 2,
                    TransmissionId = 2,
                    SalePrice = 10000,
                    MSRPPrice = 10000,
                    VehicleBodyId = 3,
                    Year = 2017,
                    VehicleColor = "Red",
                    InteriorColor = "Gray",
                    VinNumber = "1NXBR32EX6Z624118",
                    Mileage = 500,
                    VehicleDescription = "This new vehicle is super fast and super red!",
                    SpecialId = 1,
                    DateAdded = new DateTime(2017, 09, 03),
                    PurchaseStatusId = 2,
                    IsFeatured = true,

                    VehicleType = _VehicleTypes[0],
                    VehicleModel = _vehicleModels[1],
                    Transmission = _transmissions[1],
                    VehicleBody = _vehicleBodies[2],
                    Special = _specials[0],
                    PurchaseStatus = _purchaseStatus[1]
                },
                new Vehicle
                {
                    VehicleId = 2,
                    VehicleTypeId = 2,
                    VehicleModelId = 3,
                    TransmissionId = 1,
                    SalePrice = 10000,
                    MSRPPrice = 10000,
                    VehicleBodyId = 2,
                    Year = 1998,
                    VehicleColor = "Green",
                    InteriorColor = "Gray",
                    VinNumber = "3C3CFFFH0CT163609",
                    Mileage = 62000,
                    VehicleDescription = "This vehicle might have some years, but it we call it experience",
                    SpecialId = null,
                    DateAdded = new DateTime(2014, 02, 08),
                    PurchaseStatusId = 1,
                    IsFeatured = false,

                    VehicleType = _VehicleTypes[1],
                    VehicleModel = _vehicleModels[2],
                    Transmission = _transmissions[0],
                    VehicleBody = _vehicleBodies[1],
                    PurchaseStatus = _purchaseStatus[0]
                },
                new Vehicle
                {
                    VehicleId = 3,
                    VehicleTypeId = 1,
                    VehicleModelId = 2,
                    TransmissionId = 2,
                    SalePrice = 10000,
                    MSRPPrice = 10000,
                    VehicleBodyId = 1,
                    Year = 20016,
                    VehicleColor = "White",
                    InteriorColor = "Black",
                    VinNumber = "2P4FP25B2VR305648",
                    Mileage = 850,
                    VehicleDescription = "Fast and sleak. Polished. Perfect for any vehicle enthusiast.",
                    SpecialId = 1,
                    DateAdded = new DateTime(2017, 01, 20),
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
                    VehicleId = 4,
                    VehicleTypeId = 2,
                    VehicleModelId = 1,
                    TransmissionId = 1,
                    SalePrice = 10000,
                    MSRPPrice = 10000,
                    VehicleBodyId = 3,
                    Year = 2003,
                    VehicleColor = "Red",
                    InteriorColor = "Black",
                    VinNumber = "1B7FL26P6XS316728",
                    Mileage = 120000,
                    VehicleDescription = "I'm still rolling. Don't be hating.",
                    SpecialId = null,
                    DateAdded = new DateTime(2015, 05, 28),
                    PurchaseStatusId = 2,
                    IsFeatured = false,

                    VehicleType = _VehicleTypes[1],
                    VehicleModel = _vehicleModels[0],
                    Transmission = _transmissions[0],
                    VehicleBody = _vehicleBodies[2],
                    PurchaseStatus = _purchaseStatus[1]
                },
                new Vehicle
                {
                    VehicleId = 5,
                    VehicleTypeId = 1,
                    VehicleModelId = 2,
                    TransmissionId = 2,
                    SalePrice = 10000,
                    MSRPPrice = 10000,
                    VehicleBodyId = 2,
                    Year = 2017,
                    VehicleColor = "Yellow",
                    InteriorColor = "Black",
                    VinNumber = "1GDJC34J6YF591469",
                    Mileage = 350,
                    VehicleDescription = "Buy me if you like yellow.",
                    SpecialId = null,
                    DateAdded = new DateTime(2017, 10, 01),
                    PurchaseStatusId = 1,
                    IsFeatured = false,

                    VehicleType = _VehicleTypes[0],
                    VehicleModel = _vehicleModels[1],
                    Transmission = _transmissions[1],
                    VehicleBody = _vehicleBodies[1],
                    PurchaseStatus = _purchaseStatus[0]
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
                    Phone = "651-555-6666",
                    Message = "Hey, will you find me a car like this but in blue?",
                    DateQueryToCustomer = new DateTime(2017, 10, 01),
                    DateQueryToDealership = new DateTime(2017, 10, 02),
                    VehicleId = 2,

                    Vehicle = _vehicles[1]
                },
                new ContactUsQuery
                {
                    ContactUsQueryId = 2,
                    FirstName = "Rob",
                    LastName = "Reynolds",
                    Email = "Rob.Reynolds@gmail.com",
                    Phone = "651-555-9999",
                    Message = "Do you accept trades?",
                    DateQueryToCustomer = new DateTime(2017, 10, 13),
                    DateQueryToDealership = new DateTime(2017, 10, 14),
                    VehicleId = null,
                },
                new ContactUsQuery
                {
                    ContactUsQueryId = 3,
                    FirstName = "Javier",
                    LastName = "Aguirre",
                    Email = "Javier.Aguirre@gmail.com",
                    Phone = "763-555-1212",
                    Message = "I need a sweet truck!",
                    DateQueryToCustomer = new DateTime(2017, 10, 26),
                    DateQueryToDealership = new DateTime(2017, 10, 27),
                    VehicleId = null
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
                    DatePurchased = new DateTime(2017, 10, 26),

                    PurchaseType = _purchaseType[0],
                    Employee = _employees[0],
                    Customer = _customers[0],
                    Vehicle = _vehicles[0]
                },
                new Purchase
                {
                    PurchaseId = 2,
                    PurchasePrice = 12000,
                    PurchaseTypeId = 1,
                    EmployeeId = 1,
                    CustomerId = 1,
                    VehicleId = 1,
                    DatePurchased = new DateTime(2017, 10, 01),

                    PurchaseType = _purchaseType[0],
                    Employee = _employees[0],
                    Customer = _customers[0],
                    Vehicle = _vehicles[0]
                },
                new Purchase
                {
                    PurchaseId = 3,
                    PurchasePrice = 13000,
                    PurchaseTypeId = 1,
                    EmployeeId = 1,
                    CustomerId = 1,
                    VehicleId = 1,
                    DatePurchased = new DateTime(2017, 09, 13),

                    PurchaseType = _purchaseType[0],
                    Employee = _employees[0],
                    Customer = _customers[0],
                    Vehicle = _vehicles[0]
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

            _dealerships = new List<Dealership>()
            {
                new Dealership
                {
                    DealershipId = 1,
                    DealerShipName = "Lindsey's Amazing Car Dealership",
                    AddressId = 4,
                    Phone = _phones.Where(p => p.PhoneId == 7 || p.PhoneId == 8).ToList(),

                    Address = _addresses[3]
                }
            };
        }

        public void AddEmployee(Employee employeeToAdd)
        {
            if (_employees.Any())
            {
                employeeToAdd.EmployeeId = _employees.Max(e => e.EmployeeId) + 1;
            }
            else
            {
                employeeToAdd.EmployeeId = 1;
            }

            _employees.Add(employeeToAdd);
        }

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

        public void EditEmployee(Employee employeeToEdit)
        {
            _employees.RemoveAll(e => e.EmployeeId == employeeToEdit.EmployeeId);
            _employees.Add(employeeToEdit);
        }

        public void EditVehicle(Vehicle vehicleToEdit)
        {
            _vehicles.RemoveAll(v => v.VehicleId == vehicleToEdit.VehicleId);
            _vehicles.Add(vehicleToEdit);
        }

        public List<Vehicle> GetAllFeaturedVehicles()
        {
            return _vehicles.Where(v => v.IsFeatured && v.PurchaseStatus.PurchaseStatusDescription == "Avaliable").ToList();
        }

        public List<Special> GetAllSpecials()
        {
            return _specials;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicles;
        }

        public List<Vehicle> GetAllVehiclesByMake(string makeName)
        {
            return _vehicles.Where(v => v.VehicleModel.VehicleMake.VehicleMakeDescription.Contains(makeName)).ToList();
        }
       
        public List<Vehicle> GetAllVehiclesByYear(int vehicleYear)
        {
            return _vehicles.Where(v => v.Year == vehicleYear).ToList();
        }

        public List<Vehicle> GetAllVehiclesByModel(string modelName)
        {
            return _vehicles.Where(v => v.VehicleModel.VehicleModelDescription.Contains(modelName)).ToList();
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

        public List<Vehicle> GetTop20NewVehiclesByMake(string makeName)
        {
            var vehicles = _vehicles.Where(t => t.VehicleType.VehicleTypeDescription == "New").Where(v => v.VehicleModel.VehicleMake.VehicleMakeDescription.Contains(makeName)).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20NewVehiclesByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var vehicles = _vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "New" && v.SalePrice >= minPrice && v.SalePrice <=maxPrice).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20NewVehiclesByPriceMin(decimal minPrice)
        {
            var vehicles = _vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "New" && v.SalePrice >= minPrice).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20NewVehiclesByPriceMax(decimal maxPrice)
        {
            var vehicles = _vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "New" && v.SalePrice <= maxPrice).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20NewVehiclesByYear(int vehicleYear)
        {
            var vehicles = _vehicles.Where(t => t.VehicleType.VehicleTypeDescription == "New").Where(y => y.Year == vehicleYear).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20NewVehiclesByYearRange(int minYear, int maxYear)
        {
            var vehicles = _vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "New" && v.Year >= minYear && v.Year <= maxYear).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20NewVehiclesByYearMin(int minYear)
        {
            var vehicles = _vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "New" && v.Year >= minYear).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20NewVehiclesByYearMax(int maxYear)
        {
            var vehicles = _vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "New" && v.Year <= maxYear).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20NewVehiclesModel(string modelName)
        {
            var vehicles = _vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "New" && v.VehicleModel.VehicleModelDescription.Contains(modelName)).OrderByDescending(p => p.MSRPPrice).ToList();
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

        public List<Vehicle> GetTop20UsedVehiclesByMake(string makeName)
        {
            var vehicles = _vehicles.Where(t => t.VehicleType.VehicleTypeDescription == "Used").Where(v => v.VehicleModel.VehicleMake.VehicleMakeDescription.Contains(makeName)).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20UsedVehiclesByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var vehicles = _vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "Used" && v.SalePrice >= minPrice && v.SalePrice <= maxPrice).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20UsedVehiclesByPriceMin(decimal minPrice)
        {
            var vehicles = _vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "Used" && v.SalePrice >= minPrice).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20UsedVehiclesByPriceMax(decimal maxPrice)
        {
            var vehicles = _vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "Used" && v.SalePrice <= maxPrice).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20UsedVehiclesByYear(int vehicleYear)
        {
            var vehicles = _vehicles.Where(t => t.VehicleType.VehicleTypeDescription == "Used").Where(y => y.Year == vehicleYear).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20UsedVehiclesByYearRange(int minYear, int maxYear)
        {
            var vehicles = _vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "Used" && v.Year >= minYear && v.Year <= maxYear).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20UsedVehiclesByYearMin(int minYear)
        {
            var vehicles = _vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "Used" && v.Year >= minYear).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20UsedVehiclesByYearMax(int maxYear)
        {
            var vehicles = _vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "Used" && v.Year <= maxYear).OrderByDescending(p => p.MSRPPrice).ToList();
            if (vehicles.Count < 20)
            {
                return vehicles;
            }
            else
            {
                return vehicles.Take(20).ToList();
            }
        }

        public List<Vehicle> GetTop20UsedVehiclesModel(string modelName)
        {
            var vehicles = _vehicles.Where(v => v.VehicleType.VehicleTypeDescription == "Used" && v.VehicleModel.VehicleModelDescription.Contains(modelName)).OrderByDescending(p => p.MSRPPrice).ToList();
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
}
