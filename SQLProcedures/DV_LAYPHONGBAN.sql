USE [CRM]
GO
/****** Object:  StoredProcedure [dbo].[DV_LAYPHONGBAN]    Script Date: 05/09/2018 09:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DV_LAYPHONGBAN]
@MAPB NVARCHAR(50)
AS
SELECT TENPB FROM PHONGBAN WHERE MAPB = @MAPB