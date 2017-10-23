use DvdLibrary;
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdDelete')
		drop procedure DvdDelete
go

create procedure DvdDelete(
	@DvdId int
) as
begin
	begin transaction

	delete from Dvds where DvdId = @DvdId;

	commit transaction
end
go