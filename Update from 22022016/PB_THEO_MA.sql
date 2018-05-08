USE [AGRIBANKHD]
GO

/****** Object:  StoredProcedure [dbo].[PB_THEO_MA]    Script Date: 02/26/2016 15:16:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[PB_THEO_MA]
@ma_pb nvarchar(50)
AS
SELECT MA_CN, MA_PB, TEN_PB FROM [dbo].[VBA.PHONG_BAN] WHERE MA_PB=@ma_pb

GO

