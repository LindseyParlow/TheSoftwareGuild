use DvdLibrary;
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdSelectByDirector')
		drop procedure DvdSelectByDirector
go

create procedure DvdSelectByDirector (
	@Director nvarchar(max)
) as
begin
	select DvdId, Title, Director, Rating, ReleaseDate
	from Dvds
	where Director = @Director
	order by DvdId
end
go