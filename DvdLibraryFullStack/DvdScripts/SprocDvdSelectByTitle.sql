use DvdLibrary;
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdSelectByTitle')
		drop procedure DvdSelectByTitle
go

create procedure DvdSelectByTitle(
	@Title nvarchar(max)
) as
begin
	select DvdId, Title, Director, Rating, ReleaseDate, Notes
	from Dvds
	where Title = @Title
	order by DvdId
end
go