USE [AGRIBANKHD]
GO
/****** Object:  StoredProcedure [dbo].[Them_CBTD]    Script Date: 02/26/2016 15:21:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Them_CBTD] 
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
INSERT INTO [dbo].[TD.CAN_BO]
           ([MA_CN]
           ,[MA_PGD]
           ,[TEN_DANG_NHAP]
           ,[HO_TEN]
           ,[CHUC_VU]
           ,[GIAY_UY_QUYEN]
           ,[DIEN_THOAI]
           ,[FAX]
           ,[MAT_KHAU]
           ,[DANH_XUNG]
           ,[MA_PB]
           )
     VALUES
           (@ma_cn
           ,@ma_pgd
           ,@ten_dang_nhap
           ,@ho_ten
           ,@chuc_vu
           ,@giay_uy_quyen
           ,@dien_thoai
           ,@fax
           ,@mat_khau
           ,@danh_xung
           ,@ma_pb
		   )


