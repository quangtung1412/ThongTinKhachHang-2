USE [AGRIBANKHD]
GO

/****** Object:  StoredProcedure [dbo].[THEM_HD_VAY]    Script Date: 05/08/2017 13:53:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[THEM_HD_VAY] 
	-- Add the parameters for the stored procedure here
	@ma_hd_vay nvarchar(50),
	@ma_cn nvarchar(5),
	@ma_kh_vay nvarchar(50),
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
INSERT INTO [dbo].[TD.HOP_DONG]
           ([MA_HD_VAY],
			[MA_CN],
			[MA_KH_VAY],
			[PHUONG_THUC],
			[TONG_HAN_MUC_TIN_DUNG],
			[HAN_MUC_TIN_DUNG],
			[HAN_MUC_BAO_LANH],
			[MUC_DICH_VAY],
			[LAI_SUAT],
			[PHUONG_THUC_TRA_LAI],
			[PHUONG_THUC_TRA_GOC],
			[THOI_HAN_VAY],
			[HAN_TRA_NO_CUOI],
			[THOI_HAN_RUT_VON],
			[THOI_GIAN_AN_HAN],
			[BAO_DAM_TIEN_VAY],
			[HINH_THUC_BAO_DAM],
			[TAI_SAN_BAO_DAM],
			[GIA_TRI_TAI_SAN_BAO_DAM],
			[DAI_DIEN_AGRIBANK],
			[KIEM_SOAT_TIN_DUNG],
			[CAN_BO_TIN_DUNG],
			[MA_HD_VAY_CU],
			[NGAY_HD_VAY_CU],
			[NGAY_HD_VAY]
           )
     VALUES
           (@ma_hd_vay
			,@ma_cn
			,@ma_kh_vay
			,@phuong_thuc
			,@tong_han_muc_tin_dung
			,@han_muc_tin_dung
			,@han_muc_bao_lanh
			,@muc_dich_vay
			,@lai_suat
			,@phuong_thuc_tra_lai
			,@phuong_thuc_tra_goc
			,@thoi_han_vay
			,@han_tra_no_cuoi
			,@thoi_han_rut_von
			,@thoi_gian_an_han
			,@bao_dam_tien_vay
			,@hinh_thuc_bao_dam
			,@tai_san_bao_dam
			,@gia_tri_tai_san_bao_dam
			,@dai_dien_agribank
			,@kiem_soat_tin_dung
			,@can_bo_tin_dung
			,@ma_hd_vay_cu
			,@ngay_hd_vay_cu
			,@ngay_hd_vay
		   )


GO


