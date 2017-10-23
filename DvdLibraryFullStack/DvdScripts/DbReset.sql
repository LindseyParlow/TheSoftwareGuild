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

	insert into Dvds (Title, Director, Rating, ReleaseDate)
	values ('Finding Nemo', 'Judy Thao', 'G', 2003),
			('The Shawshank Redemption', 'Jake Ganser', 'R', 1994),
			('Beauty and the Beast', 'Javier Aguirre', 'G', 1991),
			('IT', 'Mark Johnson', 'R', 2017),
			('Jurassic Park', 'Nikolas Clay', 'PG-13', 2005);

end