use DvdLibrary;
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdUpdate')
		drop procedure DvdUpdate
go

create procedure DvdUpdate(
	@DvdId int,
	@Title nvarchar(max),
	@Director nvarchar(max),
	@Rating nvarchar(max),
	@ReleaseDate int 
) as 
begin
	update Dvds set
		Title = @Title,
		Director = @Director,
		Rating = @Rating,
		ReleaseDate = @ReleaseDate
	where DvdId = @DvdId
end

go