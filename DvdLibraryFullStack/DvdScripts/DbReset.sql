use DvdLibrary;
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DbReset')
		drop procedure DbReset
go

create procedure DbReset as 
begin
	delete from Dvds;
	DBCC CHECKIDENT ('dvds', RESEED, 0)

	insert into Dvds (Title, Director, Rating, ReleaseDate, Notes)
	values ('Finding Nemo', 'Judy Thao', 'G', 2003, 'Great fun for the whole family!'),
			('The Shawshank Redemption', 'Jake Ganser', 'R', 1994, 'Adults only. Great until the very end!'),
			('Beauty and the Beast', 'Javier Aguirre', 'G', 1991, 'Disney has another fantastic masterpiece on their hands!'),
			('IT', 'Mark Johnson', 'R', 2017, 'Disney has another fantastic masterpiece on their hands!'),
			('Jurassic Park', 'Nikolas Clay', 'PG-13', 2005, 'Rawr!');

end