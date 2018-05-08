USE [AGRIBANKHD]
GO

/****** Object:  StoredProcedure [dbo].[THEM_GIAY_NHAN_NO]    Script Date: 05/08/2017 13:49:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[THEM_GIAY_NHAN_NO] 
	-- Add the parameters for the stored procedure here
	--@id_giay_nhan_no int,
	@ma_hd_vay nvarchar(50),
	@ngay_nhan_no nvarchar(15),
	@du_no_truoc bigint,
	@so_tien_nhan_no bigint,
	@du_no_hien_tai bigint,
	@nguoi_thu_huong_1 nvarchar(50),
	@so_tai_khoan_1 nvarchar(50),
	@ngan_hang_1 nvarchar(MAX),
	@so_tien_nhan_no_1 bigint,
	@nguoi_thu_huong_2 nvarchar(50),
	@so_tai_khoan_2 nvarchar(50),
	@ngan_hang_2 nvarchar(MAX),
	@so_tien_nhan_no_2 bigint,
	@nguoi_thu_huong_3 nvarchar(50),
	@so_tai_khoan_3 nvarchar(50),
	@ngan_hang_3 nvarchar(MAX),
	@so_tien_nhan_no_3 bigint,
	@so_giay_nhan_no nvarchar(50),
	@han_tra_no_goc nvarchar(15),
	@muc_dich_su_dung_tien_vay nvarchar(MAX),
	@chung_tu_giai_ngan nvarchar(MAX),
	@ngay_de_xuat_giai_ngan nvarchar(15)
	
AS
INSERT INTO [dbo].[TD.GIAY_NHAN_NO]
           (--[MA_TS_THE_CHAP],
			[MA_HD_VAY],
			[NGAY_NHAN_NO],
			[DU_NO_TRUOC],
			[SO_TIEN_NHAN_NO],
			[DU_NO_HIEN_TAI],
			[NGUOI_THU_HUONG_1],
			[SO_TAI_KHOAN_1],
			[NGAN_HANG_1],
			[SO_TIEN_NHAN_NO_1],
			[NGUOI_THU_HUONG_2],
			[SO_TAI_KHOAN_2],
			[NGAN_HANG_2],
			[SO_TIEN_NHAN_NO_2],
			[NGUOI_THU_HUONG_3],
			[SO_TAI_KHOAN_3],
			[NGAN_HANG_3],
			[SO_TIEN_NHAN_NO_3],
			[SO_GIAY_NHAN_NO],
			[HAN_TRA_NO_GOC],
			[MUC_DICH_SU_DUNG_TIEN_VAY],
			[CHUNG_TU_GIAI_NGAN],
			[NGAY_DE_XUAT_GIAI_NGAN]
           )
     VALUES
           (--@ma_ts_the_chap
			@ma_hd_vay,
			@ngay_nhan_no,
			@du_no_truoc,
			@so_tien_nhan_no,
			@du_no_hien_taI,
			@nguoi_thu_huong_1,
			@so_tai_khoan_1,
			@ngan_hang_1,
			@so_tien_nhan_no_1,
			@nguoi_thu_huong_2,
			@so_tai_khoan_2,
			@ngan_hang_2,
			@so_tien_nhan_no_2,
			@nguoi_thu_huong_3,
			@so_tai_khoan_3,
			@ngan_hang_3,
			@so_tien_nhan_no_3,
			@so_giay_nhan_no,
			@han_tra_no_goc,
			@muc_dich_su_dung_tien_vay,
			@chung_tu_giai_ngan,
			@ngay_de_xuat_giai_ngan
		   )

GO


