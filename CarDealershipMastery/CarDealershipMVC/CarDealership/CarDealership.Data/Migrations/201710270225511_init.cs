namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        StateId = c.Int(nullable: false),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.ContactUsQueries",
                c => new
                    {
                        ContactUsQueryId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneId = c.Int(nullable: false),
                        Message = c.String(),
                        DateQueryToDealership = c.DateTime(nullable: false),
                        DateQueryToCustomer = c.DateTime(nullable: true),
                        VehicleId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.ContactUsQueryId)
                .ForeignKey("dbo.Phones", t => t.PhoneId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.PhoneId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneId = c.Int(nullable: false, identity: true),
                        PhoneType = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.PhoneId);
            
            CreateTable(
                "dbo.Dealerships",
                c => new
                    {
                        DealershipId = c.Int(nullable: false, identity: true),
                        DealerShipName = c.String(),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DealershipId)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        VehicleTypeId = c.Int(nullable: false),
                        VehicleModelId = c.Int(nullable: false),
                        TransmissionId = c.Int(nullable: false),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MSRPPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VehicleBodyId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        VehicleColor = c.String(),
                        InteriorColor = c.String(),
                        VinNumber = c.String(),
                        Mileage = c.Int(nullable: false),
                        VehicleDescription = c.String(),
                        SpecialId = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        PurchaseStatusId = c.Int(nullable: false),
                        IsFeatured = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.PurchaseStatus", t => t.PurchaseStatusId)
                .ForeignKey("dbo.Specials", t => t.SpecialId)
                .ForeignKey("dbo.Transmissions", t => t.TransmissionId)
                .ForeignKey("dbo.VehicleBodies", t => t.VehicleBodyId)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId)
                .Index(t => t.VehicleTypeId)
                .Index(t => t.VehicleModelId)
                .Index(t => t.TransmissionId)
                .Index(t => t.VehicleBodyId)
                .Index(t => t.SpecialId)
                .Index(t => t.PurchaseStatusId);
            
            CreateTable(
                "dbo.PurchaseStatus",
                c => new
                    {
                        PurchaseStatusId = c.Int(nullable: false, identity: true),
                        PurchaseStatusDescription = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseStatusId);
            
            CreateTable(
                "dbo.Specials",
                c => new
                    {
                        SpecialId = c.Int(nullable: false),
                        SpecialTitle = c.String(),
                        SpecialDescription = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        SpecialValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SpecialId);
            
            CreateTable(
                "dbo.Transmissions",
                c => new
                    {
                        TransmissionId = c.Int(nullable: false, identity: true),
                        TransmissionType = c.String(),
                    })
                .PrimaryKey(t => t.TransmissionId);
            
            CreateTable(
                "dbo.VehicleBodies",
                c => new
                    {
                        VehicleBodyId = c.Int(nullable: false, identity: true),
                        VehicleBodyDescription = c.String(),
                    })
                .PrimaryKey(t => t.VehicleBodyId);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        VehicleModelId = c.Int(nullable: false, identity: true),
                        VehicleModelDescription = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        VehicleMakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleModelId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.VehicleMakes", t => t.VehicleMakeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.VehicleMakeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.VehicleMakes",
                c => new
                    {
                        VehicleMakeId = c.Int(nullable: false, identity: true),
                        VehicleMakeDescription = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleMakeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehicleTypeId = c.Int(nullable: false, identity: true),
                        VehicleTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.VehicleTypeId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneId = c.String(),
                        CustomerMessage = c.String(),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.PurchaseTypes",
                c => new
                    {
                        PurchaseTypeId = c.Int(nullable: false, identity: true),
                        PurchaseTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseTypeId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseTypeId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        DatePurchased = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.PurchaseTypes", t => t.PurchaseTypeId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.PurchaseTypeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.CustomerId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.DealershipPhones",
                c => new
                    {
                        Dealership_DealershipId = c.Int(nullable: false),
                        Phone_PhoneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dealership_DealershipId, t.Phone_PhoneId })
                .ForeignKey("dbo.Dealerships", t => t.Dealership_DealershipId)
                .ForeignKey("dbo.Phones", t => t.Phone_PhoneId)
                .Index(t => t.Dealership_DealershipId)
                .Index(t => t.Phone_PhoneId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Purchases", "PurchaseTypeId", "dbo.PurchaseTypes");
            DropForeignKey("dbo.Purchases", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Purchases", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.ContactUsQueries", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleModels", "VehicleMakeId", "dbo.VehicleMakes");
            DropForeignKey("dbo.VehicleMakes", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.VehicleModels", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Vehicles", "VehicleBodyId", "dbo.VehicleBodies");
            DropForeignKey("dbo.Vehicles", "TransmissionId", "dbo.Transmissions");
            DropForeignKey("dbo.Vehicles", "SpecialId", "dbo.Specials");
            DropForeignKey("dbo.Vehicles", "PurchaseStatusId", "dbo.PurchaseStatus");
            DropForeignKey("dbo.ContactUsQueries", "PhoneId", "dbo.Phones");
            DropForeignKey("dbo.DealershipPhones", "Phone_PhoneId", "dbo.Phones");
            DropForeignKey("dbo.DealershipPhones", "Dealership_DealershipId", "dbo.Dealerships");
            DropForeignKey("dbo.Dealerships", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "StateId", "dbo.States");
            DropIndex("dbo.DealershipPhones", new[] { "Phone_PhoneId" });
            DropIndex("dbo.DealershipPhones", new[] { "Dealership_DealershipId" });
            DropIndex("dbo.Purchases", new[] { "VehicleId" });
            DropIndex("dbo.Purchases", new[] { "CustomerId" });
            DropIndex("dbo.Purchases", new[] { "EmployeeId" });
            DropIndex("dbo.Purchases", new[] { "PurchaseTypeId" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropIndex("dbo.VehicleMakes", new[] { "EmployeeId" });
            DropIndex("dbo.VehicleModels", new[] { "VehicleMakeId" });
            DropIndex("dbo.VehicleModels", new[] { "EmployeeId" });
            DropIndex("dbo.Vehicles", new[] { "PurchaseStatusId" });
            DropIndex("dbo.Vehicles", new[] { "SpecialId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleBodyId" });
            DropIndex("dbo.Vehicles", new[] { "TransmissionId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleModelId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeId" });
            DropIndex("dbo.Dealerships", new[] { "AddressId" });
            DropIndex("dbo.ContactUsQueries", new[] { "VehicleId" });
            DropIndex("dbo.ContactUsQueries", new[] { "PhoneId" });
            DropIndex("dbo.Addresses", new[] { "StateId" });
            DropTable("dbo.DealershipPhones");
            DropTable("dbo.Purchases");
            DropTable("dbo.PurchaseTypes");
            DropTable("dbo.Customers");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.VehicleMakes");
            DropTable("dbo.Employees");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleBodies");
            DropTable("dbo.Transmissions");
            DropTable("dbo.Specials");
            DropTable("dbo.PurchaseStatus");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Dealerships");
            DropTable("dbo.Phones");
            DropTable("dbo.ContactUsQueries");
            DropTable("dbo.States");
            DropTable("dbo.Addresses");
        }
    }
}
