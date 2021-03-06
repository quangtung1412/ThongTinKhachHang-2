USE [AGRIBANKHD]
GO
/****** Object:  StoredProcedure [dbo].[Capnhat_CBTD]    Script Date: 02/26/2016 15:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Capnhat_CBTD] 
	-- Add the parameters for the stored procedure here
	@ma_cn nvarchar(5),
	@ma_pgd nvarchar(50),
	@ten_dang_nhap nvarchar(50),
	@ho_ten nvarchar(MAX),
	@chuc_vu nvarchar(MAX),
	@giay_uy_quyen nvarchar(max),
	@dien_thoai nvarchar(15),
	@fax nvarchar(15),
	@mat_khau nvarchar(50),
	@danh_xung nvarchar(50),
	@ma_pb nvarchar(50)
AS
UPDATE [dbo].[TD.CAN_BO] SET 
    [MA_CN]=@ma_cn,
    [MA_PGD]=@ma_pgd,
    [HO_TEN]=@ho_ten,
    [CHUC_VU]=@chuc_vu,
    [GIAY_UY_QUYEN]=@giay_uy_quyen,
    [DIEN_THOAI]=@dien_thoai,
    [FAX]=@fax,
    [MAT_KHAU]=@mat_khau,
    [DANH_XUNG]=@danh_xung,
    [MA_PB]=@ma_pb
    WHERE [TEN_DANG_NHAP]=@ten_dang_nhap
