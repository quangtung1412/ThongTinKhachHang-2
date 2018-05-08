USE [AGRIBANKHD]
GO

/****** Object:  StoredProcedure [dbo].[CAP_NHAT_GIAY_NHAN_NO]    Script Date: 05/08/2017 13:49:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[CAP_NHAT_GIAY_NHAN_NO] 
	-- Add the parameters for the stored procedure here
	@id_giay_nhan_no int,
	--@ma_hd_vay nvarchar(50),
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
UPDATE [dbo].[TD.GIAY_NHAN_NO] SET
	--[MA_HD_VAY]=@ma_hd_vay
	[NGAY_NHAN_NO] = @ngay_nhan_no
	,[DU_NO_TRUOC] = @du_no_truoc
	,[SO_TIEN_NHAN_NO] = @so_tien_nhan_no
	,[DU_NO_HIEN_TAI] = @du_no_hien_tai
	,[NGUOI_THU_HUONG_1] = @nguoi_thu_huong_1
	,[SO_TAI_KHOAN_1] = @so_tai_khoan_1
	,[NGAN_HANG_1] = @ngan_hang_1
	,[SO_TIEN_NHAN_NO_1] = @so_tien_nhan_no_1
	,[NGUOI_THU_HUONG_2] = @nguoi_thu_huong_2
	,[SO_TAI_KHOAN_2] = @so_tai_khoan_2
	,[NGAN_HANG_2] = @ngan_hang_2
	,[SO_TIEN_NHAN_NO_2] = @so_tien_nhan_no_2
	,[NGUOI_THU_HUONG_3] = @nguoi_thu_huong_3
	,[SO_TAI_KHOAN_3] = @so_tai_khoan_3
	,[NGAN_HANG_3] = @ngan_hang_3
	,[SO_TIEN_NHAN_NO_3] =@so_tien_nhan_no_3
	,[SO_GIAY_NHAN_NO] = @so_giay_nhan_no
	,[HAN_TRA_NO_GOC] = @han_tra_no_goc
	,[MUC_DICH_SU_DUNG_TIEN_VAY] = @muc_dich_su_dung_tien_vay
	,[CHUNG_TU_GIAI_NGAN] = @chung_tu_giai_ngan
	,[NGAY_DE_XUAT_GIAI_NGAN] = @ngay_de_xuat_giai_ngan
    WHERE [ID_GIAY_NHAN_NO] = @id_giay_nhan_no

GO


