USE [CRM]
GO
/****** Object:  StoredProcedure [dbo].[DV_NGUOIDAIDIEN]    Script Date: 04/20/2018 08:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DV_NGUOIDAIDIEN]
@mapb nvarchar(50)
as 
if (select hs from PHONGBAN where MAPB = @mapb) = 0
select
HOTEN,
CHUCVU,
UYQUYEN2,
SDT,
FAX
from NHANVIEN, PHONGBAN where NHANVIEN.MAPB = @mapb and 
(CHUCVU = N'Giám đốc'or CHUCVU = N'Phó Giám đốc') and
NHANVIEN.MAPB = PHONGBAN.MAPB
else
select
HOTEN,
CHUCVU,
UYQUYEN2,
SDT,
FAX
from NHANVIEN, CHINHANH 
where 
chinhanh.macn = (select macn from phongban where mapb = @mapb) and
(CHUCVU = N'Giám đốc'or CHUCVU = N'Phó Giám đốc') and
NHANVIEN.MACN = CHINHANH.MACN