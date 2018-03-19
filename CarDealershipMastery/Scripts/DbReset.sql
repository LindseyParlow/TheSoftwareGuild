use CarDealership
go

if exists(Select * From INFORMATION_SCHEMA.Routines
where routine_name = 'DbReset')
drop procedure DbReset
go

Create Procedure DbReset As
Begin
	Delete from  Dealerships;
	Delete from  Phones;
	Delete from  Purchases;
	Delete from  ContactUsQueries;
	Delete from  Vehicles;
	Delete from  VehicleTypes;
	Delete from  VehicleModels;
	Delete from  VehicleMakes;
	Delete from  VehicleBodies;
	Delete from  Transmissions;
	Delete from  Specials;
	Delete from  PurchaseTypes;
	Delete from  PurchaseStatus;
	Delete from  Customers;
	Delete from  Addresses;
	Delete from  States;


	DBCC CHECKIDENT('States', reseed, 1)
	Set Identity_Insert States on;
		insert into States(StateId, StateName)
		values(1, 'Alabama'),
				(2, 'Alaska'),
				(3, 'Arizona'),
				(4, 'Arkansas'),
				(5, 'California'),
				(6, 'Colorado'),
				(7, 'Connecticut'),
				(8, 'Delaware'),
				(9, 'Florida'),
				(10, 'Georgia'),
				(11, 'Hawaii'),
				(12, 'Idaho'),
				(13, 'Illinois'),
				(14, 'Indiana'),
				(15, 'Iowa'),
				(16, 'Kansas'),
				(17, 'Kentucky'),
				(18, 'Louisiana'),
				(19, 'Maine'),
				(20, 'Maryland'),
				(21, 'Massachusetts'),
				(22, 'Michigan'),
				(23, 'Minnesota'),
				(24, 'Mississippi'),
				(25, 'Missouri'),
				(26, 'Montana'),
				(27, 'Nebraska'),
				(28, 'Nevada'),
				(29, 'New Hampshire'),
				(30, 'New Jersey'),
				(31, 'New Mexico'),
				(32, 'New York'),
				(33, 'North Carolina'),
				(34, 'North Dakota'),
				(35, 'Ohio'),
				(36, 'Oklahoma'),
				(37, 'Oregon'),
				(38, 'Pennsylvania'),
				(39, 'Rhode Island'),
				(40, 'South Carolina'),
				(41, 'South Dakota'),
				(42, 'Tennessee'),
				(43, 'Texas'),
				(44, 'Utah'),
				(45, 'Vermont'),
				(46, 'Virginia'),
				(47, 'Washington'),
				(48, 'West Virginia'),
				(49, 'Wisconsin'),
				(50, 'Wyoming')
	Set Identity_Insert States off;

	DBCC CHECKIDENT('Addresses', reseed, 1)
	Set Identity_Insert Addresses on;
		insert into Addresses(AddressId, Street1, Street2, City, StateId, ZipCode)
		values(1, '123 Apple St', 'Apt 100', 'Alpaca', 3, 55111),
				(2, '234 Banana St', 'Apt 200', 'Bat', 6, 55222),
				(3, '345 Cantalope St', 'Apt 300', 'Catfish', 9, 55333),
				(4, '456 Durian St', 'Apt 400', 'Dog', 12, 55444)
	Set Identity_Insert Addresses off;

	DBCC CHECKIDENT('Customers', reseed, 1)
	Set Identity_Insert Customers on;
		insert into Customers(CustomerId, CustomerName, Email, Phone, AddressId)
		values(1, 'Jake Ganser', 'Jake.Ganser@gmail.com', '763-555-1111', 1),
		(2, 'Judy Thao', 'Judy.Thao@gmail.com', '763-555-2222', 2),
		(3, 'Nik Clay', 'Nik.Clay@gmail.com', '763-555-3333', 3)
	Set Identity_Insert Customers off;

	DBCC CHECKIDENT('PurchaseStatus', reseed, 1)
	Set Identity_Insert PurchaseStatus on;
		insert into PurchaseStatus(PurchaseStatusId, PurchaseStatusDescription)
		values(1, 'Sold'),
				(2, 'Available')
	Set Identity_Insert PurchaseStatus off;

	DBCC CHECKIDENT('PurchaseTypes', reseed, 1)
	Set Identity_Insert PurchaseTypes on;
		insert into PurchaseTypes(PurchaseTypeId, PurchaseTypeDescription)
		values(1, 'Bank Finance'),
				(2, 'Cash'),
				(3, 'Dealer Finance')
	Set Identity_Insert PurchaseTypes off;

	DBCC CHECKIDENT('Specials', reseed, 1)
	Set Identity_Insert Specials on;
		insert into Specials(SpecialId, SpecialTitle, SpecialDescription)
		values(1, 'Truck Month', 'Any truck purchase is an extra 10% off sale price!'),
				(2, 'New Vehicle Weekend', 'Get an extra $500 off your new vehicle purchase!'),
				(3, 'Oldy But A Goody Extravaganza', 'Purchase a vehicle over 15 years old and get a 15% discount!'),
				(4, 'Special 4', 'This is special 4''s description!'),
				(5, 'Special 5', 'This is special 5''s description!'),
				(6, 'Special 6', 'This is special 6''s description!')
	Set Identity_Insert Specials off;

	DBCC CHECKIDENT('Transmissions', reseed, 1)
	Set Identity_Insert Transmissions on;
		insert into Transmissions(TransmissionId, TransmissionType)
		values(1, 'Automatic'),
				(2, 'Manual')
	Set Identity_Insert Transmissions off;

	DBCC CHECKIDENT('VehicleBodies', reseed, 1)
	Set Identity_Insert VehicleBodies on;
		insert into VehicleBodies(VehicleBodyId, VehicleBodyDescription)
		values(1, 'Car'),
				(2, 'SUV'),
				(3, 'Truck'),
				(4, 'Van')
	Set Identity_Insert VehicleBodies off;

	DBCC CHECKIDENT('VehicleMakes', reseed, 1)
	Set Identity_Insert VehicleMakes on;
		insert into VehicleMakes(VehicleMakeId, VehicleMakeDescription, UserId, DateAdded)
		values(1, 'Ford', (select Id from AspNetUsers where FirstName = 'Lindsey'), '03/01/2000'),
				(2, 'Dodge', (select Id from AspNetUsers where FirstName = 'Lindsey'), '03/01/2000'),
				(3, 'Jeep', (select Id from AspNetUsers where FirstName = 'Mark'), '03/01/2000')
	Set Identity_Insert VehicleMakes off;

	DBCC CHECKIDENT('VehicleModels', reseed, 1)
	Set Identity_Insert VehicleModels on;
		insert into VehicleModels(VehicleModelId, VehicleModelDescription, UserId, DateAdded, VehicleMakeId)
		values(1, 'Escape', (select Id from AspNetUsers where FirstName = 'Aj'), '03/02/2009', 1),
				(2, 'Escort', (select Id from AspNetUsers where FirstName = 'Aj'), '03/02/2009', 1),
				(3, 'Ram 1500', (select Id from AspNetUsers where FirstName = 'Mark'), '05/09/2005', 2),
				(4, 'Renegade', (select Id from AspNetUsers where FirstName = 'Lindsey'), '05/09/2005', 3),
				(5, 'Focus', (select Id from AspNetUsers where FirstName = 'Lindsey'), '06/06/2000', 1),
				(6, 'Charger', (select Id from AspNetUsers where FirstName = 'Mark'), '08/20/2010', 2),
				(7, 'Wrangler', (select Id from AspNetUsers where FirstName = 'Lindsey'), '10/30/2015', 3)
	Set Identity_Insert VehicleModels off;

	DBCC CHECKIDENT('VehicleTypes', reseed, 1)
	Set Identity_Insert VehicleTypes on;
		insert into VehicleTypes(VehicleTypeId, VehicleTypeDescription)
		values(1, 'New'),
				(2, 'Used')
	Set Identity_Insert VehicleTypes off;

	DBCC CHECKIDENT('Vehicles', reseed, 1)
	Set Identity_Insert Vehicles on;
		insert into Vehicles(VehicleId, ImagePath, VehicleTypeId, VehicleModelId, TransmissionId, SalePrice, MSRPPrice, VehicleBodyId, [Year], 
					VehicleColor, InteriorColor, VinNumber, Mileage, VehicleDescription, PurchaseStatusId, IsFeatured)
		values(1, 'redcar.png', 1, 2, 2, 16500, 18750, 1, 2017, 'Red', 'Gray', '1NXBR32EX6Z624118', 500, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 1),
				(2, 'greentruck.jpg', 2, 3, 1, 7250, 8000, 3, 1998, 'Green', 'Gray', '3C3CFFFH0CT163609', 62000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 1),
				(3, 'whitevan.jpg', 1, 2, 2, 22875, 26250, 4, 2016, 'White', 'Black', '2P4FP25B2VR305648', 850, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 1),
				(4, 'redcar.png', 2, 1, 1, 6800, 7500, 1, 2003, 'Red', 'Black', '1B7FL26P6XS316728', 120000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 0),
				(5, 'yellowcar.png', 1, 2, 2, 18500, 21000, 1, 2017, 'Yellow', 'Black', '1GDJC34J6YF591469', 350, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 1, 0),
				(6, 'redsuv.jpg', 2, 1, 1, 9900, 10250, 2, 2005, 'Red', 'White', 'JD1EG1122M4427105', 28500, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 1),
				(7, 'bluesuv.png', 1, 1, 2, 16500, 18000, 2, 2017, 'Blue', 'Black', '1GNFK16397J314592', 900, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 1),
				(8, 'greencar.jpg', 2, 2, 1, 11250, 11750, 1, 2003, 'Green', 'Gray', 'JA3AJ36B23U019320', 48000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 1, 0),
				(9, 'whitetruck.jpg', 1, 3, 2, 14900, 15800, 3, 2016, 'White', 'Black', 'LM4AC11A7T1159824', 500, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 0),
				(10, 'greenvan.png', 2, 4, 2, 8500, 10250, 4, 2007, 'Green', 'Gray', '1B7HM26Y9KS023056', 78000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 1),
				(11, 'bluecar.jpg', 1, 5, 1, 29000, 33000, 1, 2018, 'Blue', 'White', '1FMJK1J50BEA31636', 200, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 1, 1),
				(12, 'redcar.png', 2, 5, 1, 12750, 13500, 1, 2010, 'Red', 'Black', 'JH4CL95946C070364', 6000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 0),
				(13, 'whitesuv.jpg', 1, 1, 2, 21500, 22750, 2, 2018, 'White', 'White', '2P4FP25B2VR305648', 150, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 0),
				(14, 'yellowsuv.jpg', 2, 5, 2, 6750, 8250, 2, 2003, 'Yellow', 'Gray', '1HTSLAAL7VH407274', 85000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 0),
				(15, 'greentruck.jpg', 1, 1, 1, 15000, 16000, 3, 2017, 'Green', 'Black', '1FUYDMCB9SP577754', 850, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 1),
				(16, 'redcar.png', 2, 1, 1, 4500, 5000, 1, 2006, 'Red', 'Black', '1D7HW48JX7S198418', 45000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 1),
				(17, 'bluecar.jpg', 1, 2, 2, 14500, 15000, 1, 2017, 'Blue', 'Black', 'JM1EC4351R0329122', 400, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 0),
				(18, 'yellowsuv.jpg', 2, 2, 1, 8250, 8750, 2, 2002, 'Yellow', 'Black', '1HFSC18174A810010', 62000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 1),
				(19, 'greentruck.jpg', 1, 3, 1, 12500, 13000, 3, 2016, 'Green', 'Black', '1FVSALCV28DZ66924', 600, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 1, 0),
				(20, 'whitevan.jpg', 2, 3, 1, 7000, 8000, 4, 2010, 'White', 'Black', 'LVGBE42K76G010375', 96000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 0),
				(21, 'redsuv.jpg', 1, 4, 2, 26000, 27000, 2, 2018, 'Red', 'Black', '2GTEC19W711174616', 150, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 1),
				(22, 'bluevan.jpg', 2, 4, 1, 14500, 15250, 4, 2012, 'Blue', 'Black', '1JTML6511JT108915', 21000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 1),
				(23, 'yellowcar.png', 1, 5, 1, 9000, 9500, 1, 2017, 'Yellow', 'Black', 'JTHCE5C29D5094993', 225, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 0),
				(24, 'greensuv.jpg', 2, 5, 1, 2500, 3000, 2, 2007, 'Green', 'Black', '1FTZF1764WKC61845', 98000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 1, 1),
				(25, 'whitetruck.jpg', 1, 6, 2, 28000, 29750, 3, 2016, 'White', 'Black', '5KKHAECK36PW35965', 850, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 0),
				(26, 'redsuv.jpg', 2, 6, 2, 16750, 17500, 2, 2014, 'Red', 'Black', '1GNDM19X73B133415', 43000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 0),
				(27, 'bluesuv.png', 1, 7, 2, 24500, 25250, 2, 2018, 'Blue', 'Black', 'JE3CU24A4NU018849', 675, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 1),
				(28, 'greenvan.png', 2, 7, 1, 10000, 11000, 4, 2012, 'Green', 'Black', 'WDBSK71F47F113681', 45000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 0),
				(29, 'yellowcar.png', 1, 1, 1, 14000, 14750, 1, 2017, 'Yellow', 'Black', '1G1AL69K2BJ231975', 350, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 1, 1),
				(30, 'bluecar.jpg', 2, 1, 1, 4800, 5200, 1, 2001, 'Blue', 'Black', '2FWBA3AN13AK40250', 72000, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.', 2, 0)
	Set Identity_Insert Vehicles off;

	DBCC CHECKIDENT('ContactUsQueries', reseed, 1)
	Set Identity_Insert ContactUsQueries on;
		insert into ContactUsQueries(ContactUsQueryId, FullName, Email, Phone, [Message], VehicleId)
		values(1, 'Corbin March', 'Corbin.March@gmail.com', '651-555-6666', 'Hey, will you find me a car like this but in blue?', 2),
				(2, 'Rob Reynolds', 'Rob.Reynolds@gmail.com', '651-555-9999', 'Do you accept trades?', null),
				(3, 'Javier Aguirre', 'Javier.Aguirre@gmail.com', '651-555-7777', 'I need a sweet truck!', null)
	Set Identity_Insert ContactUsQueries off;

	DBCC CHECKIDENT('Purchases', reseed, 1)
	Set Identity_Insert Purchases on;
		insert into Purchases(PurchaseId, PurchasePrice, PurchaseTypeId, UserId, CustomerId, VehicleId, DatePurchased)
		values(1, 18300, 3, (select Id from AspNetUsers where FirstName = 'Mark'), 2, 5, '10/26/2017'),
				(2, 10900, 2, (select Id from AspNetUsers where FirstName = 'Aj'), 3, 8, '10/01/2017'),
				(3, 27750, 1, (select Id from AspNetUsers where FirstName = 'Aj'), 1, 11, '09/13/2017')
	Set Identity_Insert Purchases off;

	DBCC CHECKIDENT('Phones', reseed, 1)
	Set Identity_Insert Phones on;
		insert into Phones(PhoneId, PhoneType, PhoneNumber)
		values(1, 'Office', '555-555-1111'),
				(2, 'Sales', '555-555-2222'),
				(3, 'Service', '555-555-3333')
	Set Identity_Insert Phones off;

	DBCC CHECKIDENT('Dealerships', reseed, 1)
	Set Identity_Insert Dealerships on;
		insert into Dealerships(DealershipId, DealerShipName, AddressId)
		values(1, 'Lindsey''s Amazing Car Dealership', 4)
	Set Identity_Insert Dealerships off;

End