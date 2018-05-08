USE [AGRIBANKHD]
GO

/****** Object:  StoredProcedure [dbo].[DS_CBTD_THEO_CV_MA_PB]    Script Date: 02/26/2016 15:16:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[DS_CBTD_THEO_CV_MA_PB]
@ma_cn nvarchar(5),
@chuc_vu nvarchar(MAX),
@ma_pb nvarchar(50)
AS
SELECT MA_PGD, TEN_DANG_NHAP, HO_TEN, CHUC_VU, GIAY_UY_QUYEN, DIEN_THOAI,FAX, MA_PB FROM [dbo].[TD.CAN_BO] WHERE MA_CN=@ma_cn AND CHUC_VU=@chuc_vu AND MA_PB=@ma_pb



GO

