use master
go

create database CarDealership;
go

create table BodyStyles (
	BodyStyleId int identity(1,1) primary key,
	BodyDescription varchar(30) not null
)
 
create table VehicleTypes (
	VehicleTypeId int identity(1,1) primary key,
	TypeDescription varchar(30) not null
)

create table PhoneNumbers (
	PhoneId int identity(1,1) primary key,
	PhoneType varchar(30) not null,
	PhoneNumber varchar(30) not null
)

create table PurchaseStatus (
	PurchaseStatusId int identity(1,1) primary key,
	StatusDescription varchar(30) not null
)

create table 

CREATE TABLE CarDealership.PurchaseType ( 
	PurchaseTypeId       int NOT NULL   IDENTITY,
	PurchaseTypeDescription varchar(30)    ,
	CONSTRAINT Pk_PurchaseType PRIMARY KEY  ( PurchaseTypeId )
 );

CREATE TABLE CarDealership.Specials ( 
	SpecialId            int NOT NULL   IDENTITY,
	SpecialTitle         varchar(30)    ,
	SpecialDescription   varchar(max)    ,
	StartDate            date    ,
	EndDate              date    ,
	Value                decimal    ,
	CONSTRAINT Pk_Specials PRIMARY KEY  ( SpecialId )
 );

CREATE TABLE CarDealership.States ( 
	StateId              int NOT NULL   IDENTITY,
	StateName            varchar(20)    ,
	CONSTRAINT Pk_States PRIMARY KEY  ( StateId )
 );

CREATE TABLE CarDealership.TransmissionTypes ( 
	TransmissionTypeId   int NOT NULL   IDENTITY,
	TransmissionTypeDescription varchar(30)    ,
	CONSTRAINT Pk_TransmissionTypes PRIMARY KEY  ( TransmissionTypeId )
 );

CREATE TABLE CarDealership.Users ( 
	UserId               int NOT NULL   IDENTITY,
	LastName             varchar(30)    ,
	FirstName            varchar(30)    ,
	Email                nvarchar(50)    ,
	Role                 varchar(20)    ,
	Password             nvarchar(30)    ,
	CONSTRAINT Pk_Users PRIMARY KEY  ( UserId )
 );

CREATE TABLE CarDealership.Addresses ( 
	AddressId            int NOT NULL   IDENTITY,
	Street1              varchar(50)    ,
	Street2              varchar(50)    ,
	City                 varchar(50)    ,
	StateId              int    ,
	ZipCode              varchar(20)    ,
	CONSTRAINT Pk_Addresses PRIMARY KEY  ( AddressId )
 );

CREATE  INDEX idx_Addresses ON CarDealership.Addresses ( StateId );

CREATE TABLE CarDealership.CarModels ( 
	CarModelId           int NOT NULL   IDENTITY,
	CarModelDescription  varchar(50)    ,
	UserId               int    ,
	DateAdded            date    ,
	CONSTRAINT Pk_CarModels PRIMARY KEY  ( CarModelId )
 );

CREATE  INDEX idx_CarModels ON CarDealership.CarModels ( UserId );

CREATE TABLE CarDealership.Cars ( 
	CarId                int NOT NULL   IDENTITY,
	CarTypeId            int    ,
	CarModelId           int    ,
	TransmissionTypeId   int    ,
	SalePrice            decimal    ,
	MSRPPrice            decimal    ,
	BodyStyleId          int    ,
	Year                 date    ,
	Color                varchar(30)    ,
	Interior             varchar(max)    ,
	VIN#                 varchar(30)    ,
	Mileage              int    ,
	Description          varchar(max)    ,
	Image                varchar(max)    ,
	SpecialId            int    ,
	DateAdded            date    ,
	PurchaseStatusId     int    ,
	CONSTRAINT Pk_Cars PRIMARY KEY  ( CarId )
 );

CREATE  INDEX idx_Cars ON CarDealership.Cars ( CarTypeId );

CREATE  INDEX idx_Cars_1 ON CarDealership.Cars ( BodyStyleId );

CREATE  INDEX idx_Cars_2 ON CarDealership.Cars ( CarModelId );

CREATE  INDEX idx_Cars_3 ON CarDealership.Cars ( TransmissionTypeId );

CREATE  INDEX idx_Cars_4 ON CarDealership.Cars ( SalePrice );

CREATE  INDEX idx_Cars_5 ON CarDealership.Cars ( SpecialId );

CREATE  INDEX idx_Cars_0 ON CarDealership.Cars ( PurchaseStatusId );

CREATE TABLE CarDealership.ContactUsResponses ( 
	ContactUsResponseId  int NOT NULL   IDENTITY,
	FirstName            varchar(20)    ,
	LastName             varchar(20)    ,
	Email                nvarchar(50)    ,
	PhoneId              int    ,
	Message              varchar(max)    ,
	DateOfResponseToDealership date    ,
	DateOfResponseToCustomer date    ,
	CONSTRAINT Pk_Contacts PRIMARY KEY  ( ContactUsResponseId )
 );

CREATE  INDEX idx_ContactUsResponses ON CarDealership.ContactUsResponses ( PhoneId );

CREATE TABLE CarDealership.Customers ( 
	CustomerId           int NOT NULL   IDENTITY,
	FirstName            varchar(30)    ,
	LastName             varchar(30)    ,
	Email                nvarchar(50)    ,
	PhoneId              int    ,
	CustomerMessage      varchar(max)    ,
	AddressId            int    ,
	CONSTRAINT Pk_Customers PRIMARY KEY  ( CustomerId )
 );

CREATE  INDEX idx_Customers ON CarDealership.Customers ( PhoneId );

CREATE  INDEX idx_Customers_0 ON CarDealership.Customers ( AddressId );

CREATE TABLE CarDealership.Dealership ( 
	DealershipId         int NOT NULL   IDENTITY,
	DealershipName       varchar(50)    ,
	AddressId            int    ,
	PhoneId              int    ,
	CONSTRAINT Pk_Dealership PRIMARY KEY  ( DealershipId )
 );

CREATE  INDEX idx_Dealership ON CarDealership.Dealership ( AddressId );

CREATE TABLE CarDealership.DealershipPhoneNumbers ( 
	DealershipId         int    ,
	PhoneId              int    
 );

CREATE  INDEX idx_DealershipPhoneNumbers ON CarDealership.DealershipPhoneNumbers ( DealershipId );

CREATE  INDEX idx_DealershipPhoneNumbers_0 ON CarDealership.DealershipPhoneNumbers ( PhoneId );

CREATE TABLE CarDealership.Purchases ( 
	PurchasesId          int NOT NULL   IDENTITY,
	PurchasePrice        decimal    ,
	PurchaseTypeId       int    ,
	UserId               int    ,
	CustomerId           int    ,
	CarId                int    ,
	CONSTRAINT Pk_Sales PRIMARY KEY  ( PurchasesId )
 );

CREATE  INDEX idx_Sales ON CarDealership.Purchases ( PurchaseTypeId );

CREATE  INDEX idx_Sales_0 ON CarDealership.Purchases ( UserId );

CREATE  INDEX idx_Sales_1 ON CarDealership.Purchases ( CarId );

CREATE  INDEX idx_Sales_2 ON CarDealership.Purchases ( CustomerId );

CREATE TABLE CarDealership.CarMake ( 
	CarMakeId            int NOT NULL   IDENTITY,
	CakeMakeDescription  varchar(50)    ,
	CarModelId           int    ,
	UserId               int    ,
	DateAdded            date    ,
	CONSTRAINT Pk_CarMake PRIMARY KEY  ( CarMakeId )
 );