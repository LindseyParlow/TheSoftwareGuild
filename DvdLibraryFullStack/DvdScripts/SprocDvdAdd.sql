use DvdLibrary;
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdAddNew')
		drop procedure DvdAddNew
go

create procedure DvdAddNew(
	@DvdId int output,
	@Title nvarchar(max),
	@Director nvarchar(max),
	@Rating nvarchar(max),
	@ReleaseDate int,
	@Notes nvarchar(max)
) as 
begin
	insert into Dvds(Title, Director, Rating, ReleaseDate, Notes)
	values (@Title, @Director, @Rating, @ReleaseDate, @Notes);

	set @DvdId = SCOPE_IDENTITY();
end
