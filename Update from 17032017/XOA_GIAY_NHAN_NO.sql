USE [AGRIBANKHD]
GO

/****** Object:  StoredProcedure [dbo].[XOA_GIAY_NHAN_NO]    Script Date: 05/08/2017 13:50:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[XOA_GIAY_NHAN_NO] 
	-- Add the parameters for the stored procedure here
	@id_giay_nhan_no int
AS
DELETE FROM [dbo].[TD.GIAY_NHAN_NO] WHERE [ID_GIAY_NHAN_NO]=@id_giay_nhan_no


GO


