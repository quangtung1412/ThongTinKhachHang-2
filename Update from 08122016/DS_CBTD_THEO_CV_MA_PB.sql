USE [AGRIBANKHD]
GO
/****** Object:  StoredProcedure [dbo].[DS_CBTD_THEO_CV_MA_PB]    Script Date: 03/15/2017 16:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[DS_CBTD_THEO_CV_MA_PB]
@ma_cn nvarchar(5),
@chuc_vu nvarchar(MAX),
@ma_pb nvarchar(50)
AS
SELECT MA_PGD, TEN_DANG_NHAP, HO_TEN, CHUC_VU, GIAY_UY_QUYEN, DIEN_THOAI,FAX, MA_PB FROM [dbo].[TD.CAN_BO] WHERE MA_CN=@ma_cn AND CHUC_VU=@chuc_vu AND MA_PB=@ma_pb AND [KICH_HOAT] = '1'

