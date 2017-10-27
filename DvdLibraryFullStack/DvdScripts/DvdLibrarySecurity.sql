use master
go

if exists (select * from sys.server_principals WHERE name = N'DvdLibraryApp')
drop login DvdLibraryApp
go

create login DvdLibraryApp with password='testing123'
go

use DvdLibrary
go

if exists (select * from sys.database_principals WHERE name = N'DvdApp')
drop user DvdApp
go

create user DvdApp for login DvdLibraryApp
go

grant execute on DbReset to DvdApp
grant execute on DvdAddNew to DvdApp
grant execute on DvdDelete to DvdApp
grant execute on DvdSelectAll to DvdApp
grant execute on DvdSelectById to DvdApp
grant execute on DvdSelectByDate to DvdApp
grant execute on DvdSelectByDirector to DvdApp
grant execute on DvdSelectByRating to DvdApp
grant execute on DvdSelectByTitle to DvdApp
grant execute on DvdUpdate to DvdApp

go

grant select on Dvds to DvdApp
grant insert on Dvds to DvdApp
grant update on Dvds to DvdApp
grant delete on Dvds to DvdApp

go
