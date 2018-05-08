USE [AGRIBANKHD]
GO

/****** Object:  StoredProcedure [dbo].[Danhsach_CBTD_chua_kich_hoat]    Script Date: 03/15/2017 16:26:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Danhsach_CBTD_chua_kich_hoat]
@ma_cn nvarchar(5)
AS
SELECT MA_PGD, TEN_DANG_NHAP, HO_TEN, CHUC_VU, GIAY_UY_QUYEN, DIEN_THOAI,FAX, MA_PB FROM [dbo].[TD.CAN_BO] WHERE MA_CN=@ma_cn AND [ADMIN]='FALSE' AND [KICH_HOAT]= '0'


GO

