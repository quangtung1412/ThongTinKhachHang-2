use CRM;
go
create procedure dbo.dv_get_noicapcmnd
@ma nvarchar(10)
as
select NOICAP from NOICAPCMND where MA_NOICAP = @ma