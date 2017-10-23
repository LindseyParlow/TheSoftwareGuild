use DvdLibrary;
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdSelectById')
		drop procedure DvdSelectById
go

create procedure DvdSelectById(
	@DvdId int
) as
begin
	select DvdId, Title, Director, Rating, ReleaseDate
	from Dvds
	where DvdId = @DvdId
end
go