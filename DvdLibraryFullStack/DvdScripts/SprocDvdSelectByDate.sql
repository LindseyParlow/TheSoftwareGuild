use DvdLibrary;
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdSelectByDate')
		drop procedure DvdSelectByDate
go

create procedure DvdSelectByDate (
	@ReleaseDate int
) as
begin
	select DvdId, Title, Director, Rating, ReleaseDate
	from Dvds
	where ReleaseDate = @ReleaseDate 
end
go