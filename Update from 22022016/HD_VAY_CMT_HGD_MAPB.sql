USE [AGRIBANKHD]
GO

/****** Object:  StoredProcedure [dbo].[HD_VAY_CMT_HGD_MAPB]    Script Date: 02/26/2016 15:19:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[HD_VAY_CMT_HGD_MAPB] 
	-- Add the parameters for the stored procedure here
	@ma_cn nvarchar(5),
	@loai_kh nvarchar(50),
	@cmnd nvarchar(50),
	@ma_pb nvarchar(50)
AS
SELECT
	  [MA_HD_VAY]	  
      ,[dbo].[TD.HOP_DONG].[MA_KH_VAY]
      ,[HGD_TEN_CHONG]
      ,[HGD_CMND_CHONG]
      ,[HGD_TEN_VO]
      ,[HGD_CMND_VO]
      ,[CN_TEN]
      ,[CN_CMND]
      ,[TC_TEN]
      ,[TC_CMND_DAI_DIEN]
      ,[PHUONG_THUC]
      ,[TONG_HAN_MUC_TIN_DUNG]
      ,[HAN_MUC_TIN_DUNG]
      ,[HAN_MUC_BAO_LANH]
      ,[MUC_DICH_VAY]
      ,[LAI_SUAT]
      ,[THOI_HAN_VAY]
      ,[TAI_SAN_BAO_DAM]
      ,[GIA_TRI_TAI_SAN_BAO_DAM]
      ,[DAI_DIEN_AGRIBANK]
      ,[KIEM_SOAT_TIN_DUNG]
      ,[dbo].[TD.HOP_DONG].[CAN_BO_TIN_DUNG]
FROM [dbo].[TD.HOP_DONG],[dbo].[TD.KH_VAY],[dbo].[TD.CAN_BO]  
WHERE [dbo].[TD.HOP_DONG].MA_KH_VAY = [dbo].[TD.KH_VAY].MA_KH_VAY 
      AND ([dbo].[TD.KH_VAY].[HGD_CMND_CHONG]=@cmnd OR [dbo].[TD.KH_VAY].[HGD_CMND_VO]=@cmnd) 
      AND [dbo].[TD.KH_VAY].[LOAI_KH] = @loai_kh 
      AND [dbo].[TD.HOP_DONG].[MA_CN]=@ma_cn
      AND [dbo].[TD.HOP_DONG].CAN_BO_TIN_DUNG = [dbo].[TD.CAN_BO].TEN_DANG_NHAP
      AND [dbo].[TD.CAN_BO].MA_PB = @ma_pb

GO

