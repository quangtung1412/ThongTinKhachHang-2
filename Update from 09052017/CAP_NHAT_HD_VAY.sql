USE [AGRIBANKHD]
GO
/****** Object:  StoredProcedure [dbo].[CAP_NHAT_HD_VAY]    Script Date: 05/08/2017 13:52:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[CAP_NHAT_HD_VAY] 
	-- Add the parameters for the stored procedure here
	@ma_hd_vay nvarchar(50),
	--@ma_cn nvarchar(5),
	--@ma_kh_vay nvarchar(50),
	@phuong_thuc nvarchar(50),	
	@tong_han_muc_tin_dung bigint,
	@han_muc_tin_dung bigint,
	@han_muc_bao_lanh bigint,
	@muc_dich_vay nvarchar(max),
	@lai_suat nvarchar(max),
	@phuong_thuc_tra_lai nvarchar(max),
	@phuong_thuc_tra_goc nvarchar(max),
	@thoi_han_vay nvarchar(50),
	@han_tra_no_cuoi nvarchar(15),
	@thoi_han_rut_von nvarchar(50),
	@thoi_gian_an_han nvarchar(50),
	@bao_dam_tien_vay nvarchar(50),
	@hinh_thuc_bao_dam nvarchar(50),
	@tai_san_bao_dam nvarchar(MAX),
	@gia_tri_tai_san_bao_dam bigint,
	@dai_dien_agribank nvarchar(50),
	@kiem_soat_tin_dung nvarchar(50),
	@can_bo_tin_dung nvarchar(50),
	@ma_hd_vay_cu nvarchar(50),
	@ngay_hd_vay_cu nvarchar(15),
	@ngay_hd_vay nvarchar(15)
AS
UPDATE [dbo].[TD.HOP_DONG] SET
	--[MA_CN]=@ma_cn,	--[MA_KH_VAY]=@ma_kh_vay,	[PHUONG_THUC]=@phuong_thuc,	[TONG_HAN_MUC_TIN_DUNG]=@tong_han_muc_tin_dung,	[HAN_MUC_TIN_DUNG]=@han_muc_tin_dung,	[HAN_MUC_BAO_LANH]=@han_muc_bao_lanh,	[MUC_DICH_VAY]=@muc_dich_vay,	[LAI_SUAT]=@lai_suat,	[PHUONG_THUC_TRA_LAI]=@phuong_thuc_tra_lai,	[PHUONG_THUC_TRA_GOC]=@phuong_thuc_tra_goc,	[THOI_HAN_VAY]=@thoi_han_vay,	[HAN_TRA_NO_CUOI]=@han_tra_no_cuoi,	[THOI_HAN_RUT_VON]=@thoi_han_rut_von,	[THOI_GIAN_AN_HAN]=@thoi_gian_an_han,	[BAO_DAM_TIEN_VAY]=@bao_dam_tien_vay,	[HINH_THUC_BAO_DAM]=@hinh_thuc_bao_dam,	[TAI_SAN_BAO_DAM]=@tai_san_bao_dam,	[GIA_TRI_TAI_SAN_BAO_DAM]=@gia_tri_tai_san_bao_dam,	[DAI_DIEN_AGRIBANK]=@dai_dien_agribank,	[KIEM_SOAT_TIN_DUNG]=@kiem_soat_tin_dung,	[CAN_BO_TIN_DUNG]=@can_bo_tin_dung,
	[MA_HD_VAY_CU]=@ma_hd_vay_cu,
	[NGAY_HD_VAY_CU]=@ngay_hd_vay_cu,
	[NGAY_HD_VAY] = @ngay_hd_vay
WHERE [MA_HD_VAY]=@ma_hd_vay

