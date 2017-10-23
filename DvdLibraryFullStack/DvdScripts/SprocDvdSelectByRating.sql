use DvdLibrary;
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdSelectByRating')
		drop procedure DvdSelectByRating
go

create procedure DvdSelectByRating (
	@Rating nvarchar(max)
) as
begin
	select DvdId, Title, Director, Rating, ReleaseDate
	from Dvds
	where Rating = @Rating
	order by DvdId
end
go