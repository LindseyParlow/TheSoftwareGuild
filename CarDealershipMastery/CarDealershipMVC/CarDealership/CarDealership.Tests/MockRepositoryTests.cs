using CarDealership.Data;
using CarDealership.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests
{
    [TestFixture]
    public class MockRepositoryTests
    {
        [Test]
        public void CanGetTop20AvailableNewVehicles()
        {
            var repo = DealershipRepositoryFactory.Create();
            
            var vehicles = repo.GetTop20NewVehicles();

            Assert.AreEqual(2, vehicles.Count);
        }

        //public void CanGetTop20NewVehiclesByMake()
        //{

        //}

        //public void CanGetTop20NewVehiclesModel()
        //{

        //}

        //public void CanGetTop20NewVehiclesByYear()
        //{

        //}

        //public void CanGetTop20NewVehiclesByPriceRange()
        //{

        //}

        //public void CanGetTop20NewVehiclesByPriceMin()
        //{

        //}

        //public void CanGetTop20NewVehiclesByPriceMax()
        //{

        //}

        //public void CanGetTop20NewVehiclesByYearRange()
        //{

        //}

        //public void CanGetTop2NewVehiclesByYearMin()
        //{

        //}

        //public void CanGetTop20NewVehiclesByYearMax()
        //{

        //}

        //public void CanGetTop20UsedVehicles()
        //{

        //}

        //public void CanGetTop20UsedVehiclesByMake()
        //{

        //}

        //public void CanGetTop20UsedVehiclesModel()
        //{

        //}

        //public void CanGetTop20UsedVehiclesByYear()
        //{

        //}

        //public void CanGetTop20UsedVehiclesByYearRange()
        //{

        //}

        //public void CanGetTop20UsedVehiclesByYearMin()
        //{

        //}

        //public void CanGetTop20UsedVehiclesByYearMax()
        //{

        //}

        //public void CanGetTop20UsedVehiclesByPriceRange()
        //{

        //}

        //public void CanGetTop20UsedVehiclesByPriceMin()
        //{

        //}

        //public void CanGetTop20UsedVehiclesByPriceMax()
        //{

        //}

        //public void CanGetAllVehicles()
        //{

        //}

        //public void CanGetAllVehiclesByMake()
        //{

        //}

        //public void CanGetAllVehiclesByModel()
        //{

        //}

        //public void CanGetAllVehiclesByYear()
        //{

        //}

        //public void CanGetAllFeaturedVehicles()
        //{

        //}

        //public void CanGetAllSpecials()
        //{

        //}

        //public void CanAddMake()
        //{

        //}

        //public void CanAddModel()
        //{

        //}

        //public void CanAddVehicle()
        //{

        //}

        //public void CanEditVehicle()
        //{

        //}

        //[Test]
        //public void CanAddEmployee()
        //{
        //    var repo = DealershipRepositoryFactory.Create();

        //    Employee employeeToAdd = new Employee();

        //    employeeToAdd.LastName = "Swenson";
        //    employeeToAdd.FirstName = "Blayn";
        //    employeeToAdd.Email = "BSwenson@gmail.com";
        //    employeeToAdd.Password = "Swenson123";

        //    repo.AddEmployee(employeeToAdd);

        //    Assert.AreEqual(4, employeeToAdd.EmployeeId);
        //}

        //public void CanEditEmployee()
        //{
           
        //}

        //public void CanAddSpecial()
        //{
        //    var repo = DealershipRepositoryFactory.Create();

        //    Special specialToAdd = new Special();

        //    specialToAdd.SpecialTitle = "Dumpy Special";
        //    specialToAdd.SpecialDescription = "Buy a dumpy car for 50% off";
        //    specialToAdd.StartDate = 
        //}

        //public void CanDeleteSpecial()
        //{

        //}
    }
}
