USE [AGRIBANKHD]
GO
/****** Object:  StoredProcedure [dbo].[Xac_thuc_dang_nhap]    Script Date: 02/26/2016 15:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Xac_thuc_dang_nhap]
@ma_cn nvarchar(5),
@ten_dang_nhap nvarchar(50),
@mat_khau nvarchar(50)
AS
SELECT MA_CN, HO_TEN, CHUC_VU, GIAY_UY_QUYEN, DIEN_THOAI,FAX, MA_PB FROM [dbo].[TD.CAN_BO] WHERE TEN_DANG_NHAP=@ten_dang_nhap AND [MAT_KHAU]=@mat_khau AND [MA_CN]=@ma_cn


