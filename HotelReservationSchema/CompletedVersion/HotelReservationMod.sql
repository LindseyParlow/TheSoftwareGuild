use master;
go

if exists (select * from sysdatabases where name='HotelReservationMods')
        drop database HotelReservationMods
go

create database HotelReservationMods;
go
use HotelReservationMods;
go

create table Guests (
	GuestID int identity(1,1) primary key,
	FirstName varchar(30) not null,
	LastName varchar(30) not null,
	Age int not null
)

create table Discounts (
	DiscountID int identity(1,1) primary key,
	Description varchar(30) not null,
	Code varchar(50) not null,
	CodeType varchar(30) not null,
	Amount int not null,
	StartDate date not null,
	EndDate date not null
)

create table Customers (
	CustomerID int identity(1,1) primary key,
	FirstName varchar(30) not null,
	LastName varchar(30) not null,
	PhoneNumber nvarchar(30) not null,
	Email nvarchar(50) not null
)

create table Billing (
	BillingID int identity(1,1) primary key,
	Subtotal money not null,
	Total money not null,
	Tax money not null
)

create table AddOns (
	AddOnID int identity(1,1) primary key,
	Description varchar(30) not null,
	FeeType varchar(30) not null,
	Fee int not null,
	StartDate date not null,
	EndDate date not null
)

create table Amenities (
	AmenityID int identity(1,1) primary key,
	Description varchar(30) not null
)

create table RoomTypes (
	RoomTypeID int identity(1,1) primary key,
	Size varchar(30) not null,
	OccupanyLimit int not null
)

create table Reservations (
	ReservationID int identity(1,1) primary key,
	StartDate date not null,
	EndDate date not null,
	DiscountID int foreign key references Discounts(DiscountID) null,
	BillingID int foreign key references Billing(BillingID) null,
	CustomerID int foreign key references Customers(CustomerID) not null
)
 
create table ReservationGuests (
	ReservationID int not null,
	GuestID int not null,
	constraint PK_ReservationGuests
		primary key (ReservationID, GuestID),
	constraint FK_Reservation_ReservationGuests
		foreign key (ReservationID)
		references Reservations(ReservationID),
	constraint FK_Guests_ReservationGuests
		foreign key (GuestID)
		references Guests(GuestID),
)

create table Rooms (
	RoomID int identity(1,1) primary key,
	RoomNumber int not null,
	[Floor] int not null,
	RoomTypeID int foreign key references RoomTypes(RoomTypeID) not null
)

create table RoomRates (
	RoomRateID int identity(1,1) primary key,
	Price money not null,
	StartDate date not null,
	EndDate date not null,
	RoomTypeID int foreign key references RoomTypes(RoomTypeID)
)

create table RoomAmenities (
	RoomID int not null,
	AmenityID int not null,
	constraint PK_RoomAmenities
		primary key (RoomID, AmenityID),
	constraint FK_Room_RoomAmenities
		foreign key (RoomID)
		references Rooms(RoomID),
	constraint FK_Amenity_RoomAmenities
		foreign key (AmenityID)
		references Amenities(AmenityID),
)

create table Details (
	DetailID int identity(1,1) primary key,
	Total money not null,
	BillingID int foreign key references Billing(BillingID) not null
)

create table DetailAddOns (
	DetailID int not null,
	AddOnID int not null,
	constraint PK_DetailAddOns
		primary key (DetailID, AddOnID),
	constraint FK_Detail_DetailAddOns
		foreign key (DetailID)
		references Details(DetailID),
	constraint FK_AddOns_DetailAddOns
		foreign key (AddOnID)
		references AddOns(AddOnID),
)

Create table RoomReservations (
	RoomID int not null,
	ReservationID int not null,
	Constraint PK_RoomReservations
		Primary key (RoomID, ReservationID),
	Constraint FK_Room_RoomReservations
		Foreign key (RoomID)
		References Rooms(RoomID),
	Constraint FK_Reservations_RoomReservations
		Foreign key (ReservationID)
		References Reservations(ReservationID)
	)
go

