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
	@ReleaseDate int 
) as 
begin
	insert into Dvds(Title, Director, Rating, ReleaseDate)
	values (@Title, @Director, @Rating, @ReleaseDate);

	set @DvdId = SCOPE_IDENTITY();
end
