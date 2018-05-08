USE [AGRIBANKHD]
GO

/****** Object:  StoredProcedure [dbo].[DS_PB]    Script Date: 02/26/2016 15:15:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[DS_PB] 
-- Add the parameters for the stored procedure here
	@ma_cn nvarchar(5)
AS
SELECT MA_CN, MA_PB, TEN_PB FROM [dbo].[VBA.PHONG_BAN] WHERE [MA_CN] = @ma_cn ORDER BY MA_PB ASC


GO

