USE [AGRIBANKHD]
GO

/****** Object:  StoredProcedure [dbo].[CAP_NHAT_NGAY_HD_VAY]    Script Date: 05/08/2017 13:53:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[CAP_NHAT_NGAY_HD_VAY] 
	-- Add the parameters for the stored procedure here
	@ma_hd_vay nvarchar(50),
	@ngay_hd_vay nvarchar(15)
AS
UPDATE [dbo].[TD.HOP_DONG] SET
	[NGAY_HD_VAY] = @ngay_hd_vay
WHERE [MA_HD_VAY]=@ma_hd_vay


GO


