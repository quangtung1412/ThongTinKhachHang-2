USE [AGRIBANKHD]
GO
/****** Object:  StoredProcedure [dbo].[Danhsach_CBTD_theo_chuc_vu]    Script Date: 02/26/2016 15:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Danhsach_CBTD_theo_chuc_vu]
@ma_cn nvarchar(5),
@chuc_vu nvarchar(MAX)
AS
SELECT MA_PGD, TEN_DANG_NHAP, HO_TEN, CHUC_VU, GIAY_UY_QUYEN, DIEN_THOAI,FAX, MA_PB FROM [dbo].[TD.CAN_BO] WHERE MA_CN=@ma_cn AND CHUC_VU=@chuc_vu

