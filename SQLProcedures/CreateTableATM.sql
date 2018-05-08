USE [CRM]
GO

/****** Object:  Table [dbo].[ATM]    Script Date: 04/20/2018 11:08:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ATM](
	[ID] [nvarchar](20) NOT NULL,
	[DIADIEM] [nvarchar](max) NULL,
	[MACN] [nvarchar](10) NULL,
 CONSTRAINT [PK_ATM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


