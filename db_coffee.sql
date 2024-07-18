USE [master]
GO
/****** Object:  Database [QuanLyQuanCafe]    Script Date: 7/18/2024 9:12:04 PM ******/
CREATE DATABASE [QuanLyQuanCafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyQuanCafe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\QuanLyQuanCafe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyQuanCafe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\Log\QuanLyQuanCafe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyQuanCafe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyQuanCafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyQuanCafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyQuanCafe] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyQuanCafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyQuanCafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyQuanCafe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyQuanCafe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLyQuanCafe] SET QUERY_STORE = OFF
GO
USE [QuanLyQuanCafe]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/18/2024 9:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[PassWord] [nvarchar](1000) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 7/18/2024 9:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [datetime] NOT NULL,
	[DateCheckOut] [datetime] NULL,
	[IdTable] [int] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 7/18/2024 9:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[BillInfoId] [int] IDENTITY(1,1) NOT NULL,
	[IdBill] [int] NOT NULL,
	[IdDrink] [int] NOT NULL,
	[count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BillInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drink]    Script Date: 7/18/2024 9:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drink](
	[DrinkId] [int] IDENTITY(1,1) NOT NULL,
	[DrinkName] [nvarchar](100) NOT NULL,
	[IdCategory] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[Image] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[DrinkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DrinkCategory]    Script Date: 7/18/2024 9:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrinkCategory](
	[DrinkCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[DrinkCategoryName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DrinkCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 7/18/2024 9:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[TableId] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](100) NOT NULL,
	[TableStatus] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountId], [UserName], [PassWord], [Type]) VALUES (1, N'admin', N'admin', 1)
INSERT [dbo].[Account] ([AccountId], [UserName], [PassWord], [Type]) VALUES (2, N'employee1', N'employee1', 0)
INSERT [dbo].[Account] ([AccountId], [UserName], [PassWord], [Type]) VALUES (3, N'employee2', N'employee2', 0)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([BillId], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (2, CAST(N'2023-12-12T00:00:00.000' AS DateTime), CAST(N'2023-12-12T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Bill] ([BillId], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (3, CAST(N'2024-12-01T00:00:00.000' AS DateTime), CAST(N'2024-12-01T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Bill] ([BillId], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (5, CAST(N'2024-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime), 3, 1)
INSERT [dbo].[Bill] ([BillId], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (6, CAST(N'2024-12-03T00:00:00.000' AS DateTime), CAST(N'2024-12-03T00:00:00.000' AS DateTime), 4, 1)
INSERT [dbo].[Bill] ([BillId], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (7, CAST(N'2024-03-03T00:00:00.000' AS DateTime), CAST(N'2024-03-03T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Bill] ([BillId], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (9, CAST(N'2024-02-02T00:00:00.000' AS DateTime), CAST(N'2024-02-02T00:00:00.000' AS DateTime), 3, 1)
INSERT [dbo].[Bill] ([BillId], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (14, CAST(N'2024-07-17T17:03:17.323' AS DateTime), CAST(N'2024-07-18T15:33:23.703' AS DateTime), 2, 1)
INSERT [dbo].[Bill] ([BillId], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (19, CAST(N'2024-07-18T14:39:57.173' AS DateTime), NULL, 1, 0)
INSERT [dbo].[Bill] ([BillId], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (21, CAST(N'2024-07-18T15:34:01.107' AS DateTime), CAST(N'2024-07-18T15:34:11.697' AS DateTime), 3, 1)
INSERT [dbo].[Bill] ([BillId], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (22, CAST(N'2024-07-18T17:59:50.520' AS DateTime), NULL, 5, 0)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([BillInfoId], [IdBill], [IdDrink], [count]) VALUES (3, 2, 2, 2)
INSERT [dbo].[BillInfo] ([BillInfoId], [IdBill], [IdDrink], [count]) VALUES (5, 2, 1, 1)
INSERT [dbo].[BillInfo] ([BillInfoId], [IdBill], [IdDrink], [count]) VALUES (6, 3, 4, 2)
INSERT [dbo].[BillInfo] ([BillInfoId], [IdBill], [IdDrink], [count]) VALUES (12, 14, 3, 2)
INSERT [dbo].[BillInfo] ([BillInfoId], [IdBill], [IdDrink], [count]) VALUES (14, 14, 12, 1)
INSERT [dbo].[BillInfo] ([BillInfoId], [IdBill], [IdDrink], [count]) VALUES (15, 19, 1, 1)
INSERT [dbo].[BillInfo] ([BillInfoId], [IdBill], [IdDrink], [count]) VALUES (16, 21, 7, 2)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[Drink] ON 

INSERT [dbo].[Drink] ([DrinkId], [DrinkName], [IdCategory], [Price], [Image]) VALUES (1, N'Milk Coffee', 1, 20000.0000, NULL)
INSERT [dbo].[Drink] ([DrinkId], [DrinkName], [IdCategory], [Price], [Image]) VALUES (2, N'Americano', 1, 30000.0000, NULL)
INSERT [dbo].[Drink] ([DrinkId], [DrinkName], [IdCategory], [Price], [Image]) VALUES (3, N'Latte', 1, 35000.0000, NULL)
INSERT [dbo].[Drink] ([DrinkId], [DrinkName], [IdCategory], [Price], [Image]) VALUES (4, N'Cold Brew', 1, 30000.0000, NULL)
INSERT [dbo].[Drink] ([DrinkId], [DrinkName], [IdCategory], [Price], [Image]) VALUES (5, N'Matcha Tea', 4, 20000.0000, NULL)
INSERT [dbo].[Drink] ([DrinkId], [DrinkName], [IdCategory], [Price], [Image]) VALUES (6, N'Chai Tea', 4, 40000.0000, NULL)
INSERT [dbo].[Drink] ([DrinkId], [DrinkName], [IdCategory], [Price], [Image]) VALUES (7, N'Redbush Tea', 4, 35000.0000, NULL)
INSERT [dbo].[Drink] ([DrinkId], [DrinkName], [IdCategory], [Price], [Image]) VALUES (8, N'Iced Tea', 4, 30000.0000, NULL)
INSERT [dbo].[Drink] ([DrinkId], [DrinkName], [IdCategory], [Price], [Image]) VALUES (9, N'Orange Smoothie', 3, 45000.0000, NULL)
INSERT [dbo].[Drink] ([DrinkId], [DrinkName], [IdCategory], [Price], [Image]) VALUES (10, N'Chocolate Smoothie', 3, 37000.0000, NULL)
INSERT [dbo].[Drink] ([DrinkId], [DrinkName], [IdCategory], [Price], [Image]) VALUES (11, N'Strawberry Smoothie', 3, 42000.0000, NULL)
INSERT [dbo].[Drink] ([DrinkId], [DrinkName], [IdCategory], [Price], [Image]) VALUES (12, N'Black milk tea', 2, 45000.0000, NULL)
INSERT [dbo].[Drink] ([DrinkId], [DrinkName], [IdCategory], [Price], [Image]) VALUES (13, N'Pearl Milk Tea', 2, 42000.0000, NULL)
INSERT [dbo].[Drink] ([DrinkId], [DrinkName], [IdCategory], [Price], [Image]) VALUES (14, N'Wintermelon Milk Tea', 2, 55000.0000, NULL)
SET IDENTITY_INSERT [dbo].[Drink] OFF
GO
SET IDENTITY_INSERT [dbo].[DrinkCategory] ON 

INSERT [dbo].[DrinkCategory] ([DrinkCategoryId], [DrinkCategoryName]) VALUES (1, N'Coffee')
INSERT [dbo].[DrinkCategory] ([DrinkCategoryId], [DrinkCategoryName]) VALUES (2, N'Milk Tea')
INSERT [dbo].[DrinkCategory] ([DrinkCategoryId], [DrinkCategoryName]) VALUES (3, N'Smoothie')
INSERT [dbo].[DrinkCategory] ([DrinkCategoryId], [DrinkCategoryName]) VALUES (4, N'Tea')
SET IDENTITY_INSERT [dbo].[DrinkCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([TableId], [TableName], [TableStatus]) VALUES (1, N'Table 1', N'Có người')
INSERT [dbo].[Table] ([TableId], [TableName], [TableStatus]) VALUES (2, N'Table 2', N'Trống')
INSERT [dbo].[Table] ([TableId], [TableName], [TableStatus]) VALUES (3, N'Table 3', N'Trống')
INSERT [dbo].[Table] ([TableId], [TableName], [TableStatus]) VALUES (4, N'Table 4', N'Trống')
INSERT [dbo].[Table] ([TableId], [TableName], [TableStatus]) VALUES (5, N'Table 5', N'Có người')
SET IDENTITY_INSERT [dbo].[Table] OFF
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (N'Noob') FOR [UserName]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [PassWord]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[Drink] ADD  DEFAULT (N'Chưa đặt tên') FOR [DrinkName]
GO
ALTER TABLE [dbo].[Drink] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[DrinkCategory] ADD  DEFAULT (N'Chưa đặt tên') FOR [DrinkCategoryName]
GO
ALTER TABLE [dbo].[Table] ADD  DEFAULT (N'Bàn chưa có tên') FOR [TableName]
GO
ALTER TABLE [dbo].[Table] ADD  DEFAULT (N'Trống') FOR [TableStatus]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([IdTable])
REFERENCES [dbo].[Table] ([TableId])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([IdBill])
REFERENCES [dbo].[Bill] ([BillId])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([IdDrink])
REFERENCES [dbo].[Drink] ([DrinkId])
GO
ALTER TABLE [dbo].[Drink]  WITH CHECK ADD FOREIGN KEY([IdCategory])
REFERENCES [dbo].[DrinkCategory] ([DrinkCategoryId])
GO
USE [master]
GO
ALTER DATABASE [QuanLyQuanCafe] SET  READ_WRITE 
GO
