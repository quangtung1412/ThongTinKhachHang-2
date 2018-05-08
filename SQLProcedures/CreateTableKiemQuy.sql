USE [CRM]
GO

/****** Object:  Table [dbo].[KIEMQUY]    Script Date: 04/30/2018 21:32:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[KIEMQUY](
	[TUNGAY] [date] NULL,
	[DENNGAY] [date] NULL,
	[ID] [nchar](10) NULL,
	[CANBOKIEMQUY] [nvarchar](256) NULL,
	[QT_TIEN_THT] [int] NULL,
	[QT_MON_CHT] [int] NULL,
	[QT_TIEN_CHT] [int] NULL,
	[TIME_TCO] [time](7) NULL,
	[TIME_CO] [time](7) NULL,
	[TIME_CI] [time](7) NULL,
	[SODU_TCO] [int] NULL,
	[SODU_CO] [int] NULL,
	[SODU_CI] [int] NULL,
	[GHICHU_TCO] [nvarchar](50) NULL,
	[GHICHU_CO] [nvarchar](50) NULL,
	[GHICHU_CI] [nvarchar](50) NULL,
	[FIMI_TIME_SC] [time](7) NULL,
	[FIMI_TIME_CE] [time](7) NULL,
	[FIMI_SC_50] [int] NULL,
	[FIMI_SC_100] [int] NULL,
	[FIMI_SC_200] [int] NULL,
	[FIMI_SC_500] [int] NULL,
	[FIMI_CE_50] [int] NULL,
	[FIMI_CE_100] [int] NULL,
	[FIMI_CE_200] [int] NULL,
	[FIMI_CE_500] [int] NULL,
	[DEM_B_50] [int] NULL,
	[DEM_B_100] [int] NULL,
	[DEM_B_200] [int] NULL,
	[DEM_B_500] [int] NULL,
	[DEM_CC_50] [int] NULL,
	[DEM_CC_100] [int] NULL,
	[DEM_CC_200] [int] NULL,
	[DEM_CC_500] [int] NULL,
	[DEM_CL_50] [int] NULL,
	[DEM_CL_100] [int] NULL,
	[DEM_CL_200] [int] NULL,
	[DEM_CL_500] [int] NULL,
	[THUATHIEU] [int] NULL,
	[NGUYENNHAN] [nvarchar](max) NULL,
	[KHACPHUC] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


