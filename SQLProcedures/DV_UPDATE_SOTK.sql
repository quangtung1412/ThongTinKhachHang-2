use crm;
go
create procedure dbo.dv_update_sotk
@makh nvarchar(20),
@sotk nvarchar(20)
as
if (select sotk from TAIKHOAN where SOTK = @sotk) != @sotk
insert into TAIKHOAN (MAKH, SOTK) values (@makh,@sotk)