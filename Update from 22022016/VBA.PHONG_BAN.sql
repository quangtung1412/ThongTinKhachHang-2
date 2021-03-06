USE [AGRIBANKHD]
GO
/****** Object:  Table [dbo].[VBA.PHONG_BAN]    Script Date: 02/29/2016 11:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VBA.PHONG_BAN](
	[MA_CN] [nvarchar](5) NULL,
	[MA_PB] [nvarchar](50) NOT NULL,
	[TEN_PB] [nvarchar](max) NULL,
 CONSTRAINT [PK_VBA.PHONG_BAN] PRIMARY KEY CLUSTERED 
(
	[MA_PB] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2300', N'2300-ADMIN', N'Quản trị')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2300', N'2300-BGD', N'Ban Giám đốc')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2300', N'2300-KHDN', N'Khách hàng Doanh nghiệp')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2300', N'2300-KHHSXCN', N'Khách hàng Hộ sản xuất và Cá nhân')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2301', N'2301-BGD', N'Ban Giám đốc')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2301', N'2301-KHKD', N'Kế hoạch & Kinh doanh')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2302', N'2302-BGD', N'Ban Giám đốc')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2302', N'2302-KHKD', N'Kế hoạch & Kinh doanh')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2303', N'2303-BGD', N'Ban Giám đốc')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2303', N'2303-KHKD', N'Kế hoạch & Kinh doanh')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2304', N'2304-BGD', N'Ban Giám đốc')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2304', N'2304-KHKD', N'Kế hoạch & Kinh doanh')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2305', N'2305-BGD', N'Ban Giám đốc')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2305', N'2305-KHKD', N'Kế hoạch & Kinh doanh')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2306', N'2306-BGD', N'Ban Giám đốc')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2306', N'2306-KHKD', N'Kế hoạch & Kinh doanh')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2307', N'2307-BGD', N'Ban Giám đốc')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2307', N'2307-KHKD', N'Kế hoạch & Kinh doanh')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2308', N'2308-BGD', N'Ban Giám đốc')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2308', N'2308-KHKD', N'Kế hoạch & Kinh doanh')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2309', N'2309-BGD', N'Ban Giám đốc')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2309', N'2309-KHKD', N'Kế hoạch & Kinh doanh')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2310', N'2310-BGD', N'Ban Giám đốc')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2310', N'2310-KHKD', N'Kế hoạch & Kinh doanh')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2312', N'2312-BGD', N'Ban Giám đốc')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2312', N'2312-KHKD', N'Kế hoạch & Kinh doanh')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2313', N'2313-BGD', N'Ban Giám đốc')
INSERT [dbo].[VBA.PHONG_BAN] ([MA_CN], [MA_PB], [TEN_PB]) VALUES (N'2313', N'2313-KHKD', N'Kế hoạch & Kinh doanh')
