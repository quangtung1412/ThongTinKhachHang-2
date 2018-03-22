USE [AGRIBANKHD]
GO
/****** Object:  StoredProcedure [dbo].[CBTD_theo_ten_dang_nhap]    Script Date: 03/15/2017 16:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[CBTD_theo_ten_dang_nhap]
@ten_dang_nhap nvarchar(50)
AS
SELECT MA_CN, MA_PGD, HO_TEN, CHUC_VU, GIAY_UY_QUYEN, DIEN_THOAI,FAX, MAT_KHAU,KICH_HOAT ADMIN, DANH_XUNG, MA_PB, KICH_HOAT FROM [dbo].[TD.CAN_BO] WHERE TEN_DANG_NHAP=@ten_dang_nhap


