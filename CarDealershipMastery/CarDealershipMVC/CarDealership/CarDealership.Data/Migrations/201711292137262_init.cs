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
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
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
                        FullName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                        VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.ContactUsQueryId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
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
                        PurchaseStatusId = c.Int(nullable: false),
                        IsFeatured = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.PurchaseStatus", t => t.PurchaseStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Transmissions", t => t.TransmissionId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleBodies", t => t.VehicleBodyId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.VehicleTypeId)
                .Index(t => t.VehicleModelId)
                .Index(t => t.TransmissionId)
                .Index(t => t.VehicleBodyId)
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
                        DateAdded = c.DateTime(nullable: false),
                        VehicleMakeId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VehicleModelId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.VehicleMakes", t => t.VehicleMakeId, cascadeDelete: true)
                .Index(t => t.VehicleMakeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.VehicleMakes",
                c => new
                    {
                        VehicleMakeId = c.Int(nullable: false, identity: true),
                        VehicleMakeDescription = c.String(),
                        UserId = c.String(maxLength: 128),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleMakeId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
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
                        CustomerName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Dealerships",
                c => new
                    {
                        DealershipId = c.Int(nullable: false, identity: true),
                        DealerShipName = c.String(),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DealershipId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneId = c.Int(nullable: false, identity: true),
                        PhoneType = c.String(),
                        PhoneNumber = c.String(),
                        Dealership_DealershipId = c.Int(),
                    })
                .PrimaryKey(t => t.PhoneId)
                .ForeignKey("dbo.Dealerships", t => t.Dealership_DealershipId)
                .Index(t => t.Dealership_DealershipId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseTypeId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CustomerId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        DatePurchased = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseTypes", t => t.PurchaseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.PurchaseTypeId)
                .Index(t => t.UserId)
                .Index(t => t.CustomerId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.PurchaseTypes",
                c => new
                    {
                        PurchaseTypeId = c.Int(nullable: false, identity: true),
                        PurchaseTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseTypeId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Specials",
                c => new
                    {
                        SpecialId = c.Int(nullable: false, identity: true),
                        SpecialTitle = c.String(),
                        SpecialDescription = c.String(),
                    })
                .PrimaryKey(t => t.SpecialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Purchases", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Purchases", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Purchases", "PurchaseTypeId", "dbo.PurchaseTypes");
            DropForeignKey("dbo.Purchases", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Phones", "Dealership_DealershipId", "dbo.Dealerships");
            DropForeignKey("dbo.Dealerships", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.ContactUsQueries", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleModels", "VehicleMakeId", "dbo.VehicleMakes");
            DropForeignKey("dbo.VehicleMakes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.VehicleModels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vehicles", "VehicleBodyId", "dbo.VehicleBodies");
            DropForeignKey("dbo.Vehicles", "TransmissionId", "dbo.Transmissions");
            DropForeignKey("dbo.Vehicles", "PurchaseStatusId", "dbo.PurchaseStatus");
            DropForeignKey("dbo.Addresses", "StateId", "dbo.States");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Purchases", new[] { "VehicleId" });
            DropIndex("dbo.Purchases", new[] { "CustomerId" });
            DropIndex("dbo.Purchases", new[] { "UserId" });
            DropIndex("dbo.Purchases", new[] { "PurchaseTypeId" });
            DropIndex("dbo.Phones", new[] { "Dealership_DealershipId" });
            DropIndex("dbo.Dealerships", new[] { "AddressId" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropIndex("dbo.VehicleMakes", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.VehicleModels", new[] { "UserId" });
            DropIndex("dbo.VehicleModels", new[] { "VehicleMakeId" });
            DropIndex("dbo.Vehicles", new[] { "PurchaseStatusId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleBodyId" });
            DropIndex("dbo.Vehicles", new[] { "TransmissionId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleModelId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeId" });
            DropIndex("dbo.ContactUsQueries", new[] { "VehicleId" });
            DropIndex("dbo.Addresses", new[] { "StateId" });
            DropTable("dbo.Specials");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PurchaseTypes");
            DropTable("dbo.Purchases");
            DropTable("dbo.Phones");
            DropTable("dbo.Dealerships");
            DropTable("dbo.Customers");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.VehicleMakes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleBodies");
            DropTable("dbo.Transmissions");
            DropTable("dbo.PurchaseStatus");
            DropTable("dbo.Vehicles");
            DropTable("dbo.ContactUsQueries");
            DropTable("dbo.States");
            DropTable("dbo.Addresses");
        }
    }
}
