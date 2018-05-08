USE [AGRIBANKHD]
GO

/****** Object:  StoredProcedure [dbo].[DS_GIAY_NHAN_NO_THEO_MA_HD_VAY]    Script Date: 05/08/2017 13:50:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DS_GIAY_NHAN_NO_THEO_MA_HD_VAY] 
	-- Add the parameters for the stored procedure here
	@ma_hd_vay nvarchar(50)
AS
SELECT * FROM [dbo].[TD.GIAY_NHAN_NO] WHERE [MA_HD_VAY]=@ma_hd_vay ORDER BY ID_GIAY_NHAN_NO ASC



GO


