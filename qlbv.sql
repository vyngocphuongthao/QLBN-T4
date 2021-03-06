USE [QLBenhNhan]
GO
/****** Object:  Table [dbo].[BenhNhan]    Script Date: 05/25/2020 14:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenhNhan](
	[msbn] [nvarchar](15) NOT NULL,
	[scmnd] [nvarchar](25) NULL,
	[hoten] [nvarchar](150) NULL,
	[diachi] [nvarchar](250) NULL,
 CONSTRAINT [PK_BenhNhan] PRIMARY KEY CLUSTERED 
(
	[msbn] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BenhNhan] ([msbn], [scmnd], [hoten], [diachi]) VALUES (N'dgdf', N'fe434', N'fưefsdf', N'fdsfsd')
INSERT [dbo].[BenhNhan] ([msbn], [scmnd], [hoten], [diachi]) VALUES (N'fdgfd', N'fdgdf', N'gdfgdfg', N'df')
INSERT [dbo].[BenhNhan] ([msbn], [scmnd], [hoten], [diachi]) VALUES (N'fgdgfd', N'gfdg', N'gfdgdfgdf', N'dfgdf')
INSERT [dbo].[BenhNhan] ([msbn], [scmnd], [hoten], [diachi]) VALUES (N'gf', N'gfhgf', N'ghfg', N'')
INSERT [dbo].[BenhNhan] ([msbn], [scmnd], [hoten], [diachi]) VALUES (N'hfgh', N'ghfghh', N'hgfh', N'gfhgf')
INSERT [dbo].[BenhNhan] ([msbn], [scmnd], [hoten], [diachi]) VALUES (N'sdfs', N'dsf', N'fsdf', N'fsd')
INSERT [dbo].[BenhNhan] ([msbn], [scmnd], [hoten], [diachi]) VALUES (N'sdfsdf', NULL, NULL, NULL)
/****** Object:  Table [dbo].[BacSy]    Script Date: 05/25/2020 14:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BacSy](
	[msbacsy] [nvarchar](25) NOT NULL,
	[hotenbacsy] [nvarchar](150) NULL,
 CONSTRAINT [PK_BacSy] PRIMARY KEY CLUSTERED 
(
	[msbacsy] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhamBenh]    Script Date: 05/25/2020 14:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhamBenh](
	[msbn] [nvarchar](15) NOT NULL,
	[msbacsy] [nvarchar](25) NOT NULL,
	[ngaykham] [date] NULL,
	[ghichu] [text] NULL,
 CONSTRAINT [PK_KhamBenh] PRIMARY KEY CLUSTERED 
(
	[msbn] ASC,
	[msbacsy] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_KhamBenh_BacSy]    Script Date: 05/25/2020 14:25:51 ******/
ALTER TABLE [dbo].[KhamBenh]  WITH CHECK ADD  CONSTRAINT [FK_KhamBenh_BacSy] FOREIGN KEY([msbacsy])
REFERENCES [dbo].[BacSy] ([msbacsy])
GO
ALTER TABLE [dbo].[KhamBenh] CHECK CONSTRAINT [FK_KhamBenh_BacSy]
GO
/****** Object:  ForeignKey [FK_KhamBenh_BenhNhan]    Script Date: 05/25/2020 14:25:51 ******/
ALTER TABLE [dbo].[KhamBenh]  WITH CHECK ADD  CONSTRAINT [FK_KhamBenh_BenhNhan] FOREIGN KEY([msbn])
REFERENCES [dbo].[BenhNhan] ([msbn])
GO
ALTER TABLE [dbo].[KhamBenh] CHECK CONSTRAINT [FK_KhamBenh_BenhNhan]
GO
