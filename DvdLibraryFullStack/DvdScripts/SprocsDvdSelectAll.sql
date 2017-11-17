use DvdLibrary;
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdSelectAll')
		drop procedure DvdSelectAll
go

create procedure DvdSelectAll as 
begin
	select DvdId, Title, Director, Rating, ReleaseDate, Notes
	from Dvds
end