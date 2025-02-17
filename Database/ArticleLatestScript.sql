USE [master]
GO
/****** Object:  Database [Article]    Script Date: 7/28/2024 11:19:21 AM ******/
CREATE DATABASE [Article]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Shop', FILENAME = N'F:\Github\Article-Branch\Databae\Article1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Shop_log', FILENAME = N'F:\Github\Article-Branch\Databae\Article1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Article] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Article].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Article] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Article] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Article] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Article] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Article] SET ARITHABORT OFF 
GO
ALTER DATABASE [Article] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Article] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Article] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Article] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Article] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Article] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Article] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Article] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Article] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Article] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Article] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Article] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Article] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Article] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Article] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Article] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Article] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Article] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Article] SET  MULTI_USER 
GO
ALTER DATABASE [Article] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Article] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Article] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Article] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Article] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Article] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Article] SET QUERY_STORE = OFF
GO
USE [Article]
GO
/****** Object:  UserDefinedFunction [dbo].[CalculatePendingAmount]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CalculatePendingAmount]
(
    @PartyCode INT
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @PendingAmount NVARCHAR(MAX),
	@TotalAmount DECIMAL(18, 2),
	@SumAmount DECIMAL(18, 2)

    SELECT @TotalAmount = SUM(TotalAmount) 
    FROM PurchaseMaster
    WHERE PartyCode = @PartyCode

    SELECT @SumAmount = SUM(Amount) 
    FROM Vouchers
    WHERE PartyID = @PartyCode

    SET @PendingAmount = CAST(@TotalAmount - COALESCE(@SumAmount, 0) AS NVARCHAR(MAX))

    RETURN @PendingAmount
END
GO
/****** Object:  Table [dbo].[ArticleInfo]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleInfo](
	[ArticleId] [int] NULL,
	[Article] [nvarchar](max) NULL,
	[SaleRate] [float] NULL,
	[IsDeleted] [bit] NULL,
	[PurchaseRate] [float] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expense]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expense](
	[ID] [int] NULL,
	[Date] [datetime] NULL,
	[Purpose] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[IsDeleted] [bit] NULL,
	[Amount] [decimal](18, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpenseCoding]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenseCoding](
	[ID] [int] NULL,
	[Type] [nvarchar](max) NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartyInfo]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartyInfo](
	[PartyCode] [int] NULL,
	[PartyName] [nvarchar](max) NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
	[Contact] [nvarchar](max) NOT NULL,
	[DateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseDetail]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDetail](
	[PurchaseDetailId] [nvarchar](max) NULL,
	[PurchaseId] [nvarchar](max) NULL,
	[Article] [nvarchar](50) NULL,
	[Pair] [int] NULL,
	[Rate] [decimal](18, 2) NULL,
	[Discount] [int] NULL,
	[NetAmount] [decimal](18, 2) NULL,
	[PurchaseDate] [datetime] NULL,
	[UnitPrice] [decimal](18, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseMaster]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseMaster](
	[PurchaseId] [nvarchar](max) NULL,
	[PurchaseDate] [datetime] NULL,
	[SaleMen] [nvarchar](50) NULL,
	[PartyCode] [nvarchar](50) NULL,
	[PartyName] [nvarchar](50) NULL,
	[TotalAmount] [decimal](18, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseReturnDetail]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseReturnDetail](
	[PurchaseReturnDetailId] [nvarchar](max) NULL,
	[PurchaseReturnId] [nvarchar](max) NULL,
	[Article] [nvarchar](max) NULL,
	[PurchaseRate] [float] NULL,
	[ReturnQuantity] [decimal](18, 2) NULL,
	[NetAmount] [decimal](18, 2) NULL,
	[PurchaseReturnDate] [datetime] NULL,
	[Discount] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseReturnMaster]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseReturnMaster](
	[PurchaseReturnId] [nvarchar](max) NULL,
	[PurchaseReturnDate] [datetime] NULL,
	[SaleMan] [nvarchar](max) NULL,
	[PartyCode] [int] NULL,
	[PartyName] [nvarchar](max) NULL,
	[TotalAmount] [float] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleDetail]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleDetail](
	[SaleDetailId] [nvarchar](max) NULL,
	[SaleId] [nvarchar](max) NULL,
	[SaleDate] [datetime] NULL,
	[Article] [nvarchar](50) NULL,
	[SaleRate] [decimal](18, 2) NULL,
	[NetAmount] [decimal](18, 2) NULL,
	[Pair] [int] NULL,
	[TotalSaleRate] [decimal](18, 2) NULL,
	[Discount] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleMaster]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleMaster](
	[SaleId] [nvarchar](max) NULL,
	[SaleDate] [datetime] NULL,
	[SaleMan] [nvarchar](50) NULL,
	[PartyCode] [nvarchar](50) NULL,
	[PartyName] [nvarchar](50) NULL,
	[TotalAmount] [float] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleReturnDetail]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleReturnDetail](
	[SaleReturnDetailId] [nvarchar](max) NULL,
	[SaleReturnId] [nvarchar](max) NULL,
	[Article] [nvarchar](max) NULL,
	[SaleRate] [decimal](18, 2) NULL,
	[ReturnQuantity] [decimal](18, 2) NULL,
	[NetAmount] [decimal](18, 2) NULL,
	[SaleReturnDate] [datetime] NULL,
	[Discount] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleReturnMaster]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleReturnMaster](
	[SaleReturnId] [nvarchar](max) NULL,
	[SaleReturnDate] [datetime] NULL,
	[SaleMan] [nvarchar](max) NULL,
	[PartyCode] [int] NULL,
	[PartyName] [nvarchar](max) NULL,
	[TotalAmount] [float] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SizeInfo]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SizeInfo](
	[SizeCode] [int] NULL,
	[Size] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockId] [int] NULL,
	[InvType] [nvarchar](max) NULL,
	[InvId] [nvarchar](max) NULL,
	[Article] [nvarchar](50) NULL,
	[Pair] [float] NULL,
	[NetAmount] [decimal](18, 2) NULL,
	[DateTime] [datetime] NULL,
	[UserName] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreationDate] [nvarchar](50) NOT NULL,
	[UserAddress] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](50) NULL,
	[CNICNo] [nvarchar](50) NULL,
	[Remarks] [nvarchar](max) NULL,
	[Logintype] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Rights_junction]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Rights_junction](
	[Serial] [int] IDENTITY(1,1) NOT NULL,
	[Userid] [int] NULL,
	[Rightid] [int] NULL,
 CONSTRAINT [PK_User_Rights_junction] PRIMARY KEY CLUSTERED 
(
	[Serial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRights]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRights](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_UserRights] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[ID] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[VoucherID] [nvarchar](50) NULL,
	[VoucherDate] [datetime] NULL,
	[PartyID] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Discritipn] [nvarchar](max) NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[ArticleInfo] ([ArticleId], [Article], [SaleRate], [IsDeleted], [PurchaseRate]) VALUES (1, N'1256', NULL, 0, NULL)
INSERT [dbo].[ArticleInfo] ([ArticleId], [Article], [SaleRate], [IsDeleted], [PurchaseRate]) VALUES (2, N'27546', NULL, 0, NULL)
INSERT [dbo].[ArticleInfo] ([ArticleId], [Article], [SaleRate], [IsDeleted], [PurchaseRate]) VALUES (3, N'3875', NULL, 0, NULL)
GO
INSERT [dbo].[Expense] ([ID], [Date], [Purpose], [Description], [IsDeleted], [Amount]) VALUES (1, CAST(N'2024-07-27T10:29:12.147' AS DateTime), N'Salary Expense', N'Salary Paid', 0, CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[Expense] ([ID], [Date], [Purpose], [Description], [IsDeleted], [Amount]) VALUES (2, CAST(N'2024-07-27T10:29:18.583' AS DateTime), N'Chaii Expense', N'Cahii', 0, CAST(50.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ExpenseCoding] ([ID], [Type], [IsDeleted]) VALUES (1, N'Salary Expense', 0)
INSERT [dbo].[ExpenseCoding] ([ID], [Type], [IsDeleted]) VALUES (2, N'Chaii Expense', 0)
INSERT [dbo].[ExpenseCoding] ([ID], [Type], [IsDeleted]) VALUES (3, N'erewr4324', 1)
INSERT [dbo].[ExpenseCoding] ([ID], [Type], [IsDeleted]) VALUES (4, N'qweqwe', 1)
INSERT [dbo].[ExpenseCoding] ([ID], [Type], [IsDeleted]) VALUES (5, N'Electricity Exepsne', 0)
INSERT [dbo].[ExpenseCoding] ([ID], [Type], [IsDeleted]) VALUES (6, N'we2324', 1)
INSERT [dbo].[ExpenseCoding] ([ID], [Type], [IsDeleted]) VALUES (7, N'34343weew', 1)
GO
INSERT [dbo].[PartyInfo] ([PartyCode], [PartyName], [Location], [Contact], [DateTime], [IsDeleted]) VALUES (1, N'Bata', N'Lahore', N'042-123-4567', CAST(N'2024-01-01T10:00:00.000' AS DateTime), 0)
INSERT [dbo].[PartyInfo] ([PartyCode], [PartyName], [Location], [Contact], [DateTime], [IsDeleted]) VALUES (2, N'Servis Shoes', N'Karachi', N'021-234-5678', CAST(N'2024-02-15T14:30:00.000' AS DateTime), 0)
INSERT [dbo].[PartyInfo] ([PartyCode], [PartyName], [Location], [Contact], [DateTime], [IsDeleted]) VALUES (3, N'Hush Puppies', N'Islamabad', N'051-345-6789', CAST(N'2024-03-20T09:15:00.000' AS DateTime), 1)
INSERT [dbo].[PartyInfo] ([PartyCode], [PartyName], [Location], [Contact], [DateTime], [IsDeleted]) VALUES (4, N'ECS Shoes', N'Faisalabad', N'041-456-7890', CAST(N'2024-04-05T16:45:00.000' AS DateTime), 0)
INSERT [dbo].[PartyInfo] ([PartyCode], [PartyName], [Location], [Contact], [DateTime], [IsDeleted]) VALUES (5, N'Metro Shoes', N'Rawalpindi', N'051-567-8901', CAST(N'2024-05-10T12:00:00.000' AS DateTime), 0)
INSERT [dbo].[PartyInfo] ([PartyCode], [PartyName], [Location], [Contact], [DateTime], [IsDeleted]) VALUES (6, N'Borjan', N'Gujranwala', N'055-678-9012', CAST(N'2024-06-25T11:30:00.000' AS DateTime), 1)
INSERT [dbo].[PartyInfo] ([PartyCode], [PartyName], [Location], [Contact], [DateTime], [IsDeleted]) VALUES (7, N'Stylo Shoes', N'Multan A', N'061-789-0123', CAST(N'2024-05-28T17:57:45.480' AS DateTime), 0)
INSERT [dbo].[PartyInfo] ([PartyCode], [PartyName], [Location], [Contact], [DateTime], [IsDeleted]) VALUES (8, N'Ndure', N'Peshawar', N'091-890-1234', CAST(N'2024-08-30T17:50:00.000' AS DateTime), 1)
INSERT [dbo].[PartyInfo] ([PartyCode], [PartyName], [Location], [Contact], [DateTime], [IsDeleted]) VALUES (9, N'Shoe Planet', N'Quetta', N'081-901-2345', CAST(N'2024-09-05T13:10:00.000' AS DateTime), 0)
INSERT [dbo].[PartyInfo] ([PartyCode], [PartyName], [Location], [Contact], [DateTime], [IsDeleted]) VALUES (10, N'Urban Sole', N'Sialkot', N'052-012-3456', CAST(N'2024-10-10T15:40:00.000' AS DateTime), 0)
GO
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [Article], [Pair], [Rate], [Discount], [NetAmount], [PurchaseDate], [UnitPrice]) VALUES (N'1', N'PI-1', N'1256', 10, CAST(12500.00 AS Decimal(18, 2)), 23, CAST(9625.00 AS Decimal(18, 2)), CAST(N'2024-07-27T09:45:12.567' AS DateTime), CAST(1250.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [Article], [Pair], [Rate], [Discount], [NetAmount], [PurchaseDate], [UnitPrice]) VALUES (N'2', N'PI-2', N'27546', 15, CAST(17250.00 AS Decimal(18, 2)), 23, CAST(13282.50 AS Decimal(18, 2)), CAST(N'2024-07-27T11:11:42.833' AS DateTime), CAST(1150.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [Article], [Pair], [Rate], [Discount], [NetAmount], [PurchaseDate], [UnitPrice]) VALUES (N'3', N'PI-2', N'3875', 5, CAST(6750.00 AS Decimal(18, 2)), 23, CAST(5197.50 AS Decimal(18, 2)), CAST(N'2024-07-27T11:11:42.833' AS DateTime), CAST(1350.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [Article], [Pair], [Rate], [Discount], [NetAmount], [PurchaseDate], [UnitPrice]) VALUES (N'4', N'PI-3', N'1256', 12, CAST(15000.00 AS Decimal(18, 2)), 12, CAST(13200.00 AS Decimal(18, 2)), CAST(N'2024-07-27T23:43:55.627' AS DateTime), CAST(1250.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [Article], [Pair], [Rate], [Discount], [NetAmount], [PurchaseDate], [UnitPrice]) VALUES (N'5', N'PI-4', N'27546', 10, CAST(12500.00 AS Decimal(18, 2)), 23, CAST(9625.00 AS Decimal(18, 2)), CAST(N'2024-07-27T23:44:12.360' AS DateTime), CAST(1250.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [Article], [Pair], [Rate], [Discount], [NetAmount], [PurchaseDate], [UnitPrice]) VALUES (N'6', N'PI-5', N'3875', 15, CAST(18750.00 AS Decimal(18, 2)), 23, CAST(14437.50 AS Decimal(18, 2)), CAST(N'2024-07-27T23:44:30.147' AS DateTime), CAST(1250.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [Article], [Pair], [Rate], [Discount], [NetAmount], [PurchaseDate], [UnitPrice]) VALUES (N'8', N'PI-7', N'3875', 12, CAST(18600.00 AS Decimal(18, 2)), 23, CAST(14322.00 AS Decimal(18, 2)), CAST(N'2024-07-27T23:44:59.440' AS DateTime), CAST(1550.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [Article], [Pair], [Rate], [Discount], [NetAmount], [PurchaseDate], [UnitPrice]) VALUES (N'9', N'PI-8', N'27546', 1, CAST(1250.00 AS Decimal(18, 2)), 23, CAST(962.50 AS Decimal(18, 2)), CAST(N'2024-07-27T23:45:11.157' AS DateTime), CAST(1250.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [Article], [Pair], [Rate], [Discount], [NetAmount], [PurchaseDate], [UnitPrice]) VALUES (N'10', N'PI-10', N'3875', 12, CAST(15000.00 AS Decimal(18, 2)), 23, CAST(11550.00 AS Decimal(18, 2)), CAST(N'2024-07-27T23:45:40.407' AS DateTime), CAST(1250.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [Article], [Pair], [Rate], [Discount], [NetAmount], [PurchaseDate], [UnitPrice]) VALUES (N'10', N'PI-12', N'1256', 20, CAST(25000.00 AS Decimal(18, 2)), 23, CAST(19250.00 AS Decimal(18, 2)), CAST(N'2024-07-28T10:48:14.103' AS DateTime), CAST(1250.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [Article], [Pair], [Rate], [Discount], [NetAmount], [PurchaseDate], [UnitPrice]) VALUES (N'10', N'PI-12', N'27546', 15, CAST(23250.00 AS Decimal(18, 2)), 23, CAST(17902.50 AS Decimal(18, 2)), CAST(N'2024-07-28T10:48:14.103' AS DateTime), CAST(1550.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [Article], [Pair], [Rate], [Discount], [NetAmount], [PurchaseDate], [UnitPrice]) VALUES (N'7', N'PI-6', N'27546', 4, CAST(5000.00 AS Decimal(18, 2)), 23, CAST(3850.00 AS Decimal(18, 2)), CAST(N'2024-07-27T23:44:43.247' AS DateTime), CAST(1250.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [Article], [Pair], [Rate], [Discount], [NetAmount], [PurchaseDate], [UnitPrice]) VALUES (N'10', N'PI-9', N'3875', 1250, CAST(2687500.00 AS Decimal(18, 2)), 23, CAST(2069375.00 AS Decimal(18, 2)), CAST(N'2024-07-27T23:45:27.520' AS DateTime), CAST(2150.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseDetail] ([PurchaseDetailId], [PurchaseId], [Article], [Pair], [Rate], [Discount], [NetAmount], [PurchaseDate], [UnitPrice]) VALUES (N'10', N'PI-11', N'27546', 12, CAST(15000.00 AS Decimal(18, 2)), 25, CAST(11250.00 AS Decimal(18, 2)), CAST(N'2024-07-27T23:46:07.563' AS DateTime), CAST(1250.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseMaster] ([PurchaseId], [PurchaseDate], [SaleMen], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'PI-1', CAST(N'2024-07-27T09:45:12.553' AS DateTime), N'a', N'1', N'Bata', CAST(9625.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseMaster] ([PurchaseId], [PurchaseDate], [SaleMen], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'PI-2', CAST(N'2024-07-27T11:11:42.833' AS DateTime), N'a', N'2', N'Servis Shoes', CAST(18480.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseMaster] ([PurchaseId], [PurchaseDate], [SaleMen], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'PI-3', CAST(N'2024-07-27T23:43:55.613' AS DateTime), N'a', N'1', N'Bata', CAST(13200.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseMaster] ([PurchaseId], [PurchaseDate], [SaleMen], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'PI-4', CAST(N'2024-07-27T23:44:12.360' AS DateTime), N'a', N'2', N'Servis Shoes', CAST(9625.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseMaster] ([PurchaseId], [PurchaseDate], [SaleMen], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'PI-5', CAST(N'2024-07-27T23:44:30.147' AS DateTime), N'a', N'5', N'Metro Shoes', CAST(14437.50 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseMaster] ([PurchaseId], [PurchaseDate], [SaleMen], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'PI-7', CAST(N'2024-07-27T23:44:59.427' AS DateTime), N'a', N'2', N'Servis Shoes', CAST(14322.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseMaster] ([PurchaseId], [PurchaseDate], [SaleMen], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'PI-8', CAST(N'2024-07-27T23:45:11.157' AS DateTime), N'a', N'1', N'Bata', CAST(962.50 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseMaster] ([PurchaseId], [PurchaseDate], [SaleMen], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'PI-10', CAST(N'2024-07-27T23:45:40.407' AS DateTime), N'a', N'2', N'Servis Shoes', CAST(11550.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseMaster] ([PurchaseId], [PurchaseDate], [SaleMen], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'PI-11', CAST(N'2024-07-27T23:46:07.547' AS DateTime), N'a', N'4', N'ECS Shoes', CAST(11250.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseMaster] ([PurchaseId], [PurchaseDate], [SaleMen], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'PI-12', CAST(N'2024-07-28T10:48:14.087' AS DateTime), N'a', N'4', N'ECS Shoes', CAST(37152.50 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseMaster] ([PurchaseId], [PurchaseDate], [SaleMen], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'PI-6', CAST(N'2024-07-27T23:44:43.247' AS DateTime), N'a', N'5', N'Metro Shoes', CAST(3850.00 AS Decimal(18, 2)))
INSERT [dbo].[PurchaseMaster] ([PurchaseId], [PurchaseDate], [SaleMen], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'PI-9', CAST(N'2024-07-27T23:45:27.520' AS DateTime), N'a', N'2', N'Servis Shoes', CAST(2069375.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseReturnDetail] ([PurchaseReturnDetailId], [PurchaseReturnId], [Article], [PurchaseRate], [ReturnQuantity], [NetAmount], [PurchaseReturnDate], [Discount]) VALUES (N'1', N'PR-1', N'1256', 1250, CAST(2.00 AS Decimal(18, 2)), CAST(2500.00 AS Decimal(18, 2)), CAST(N'2024-07-27T09:46:21.880' AS DateTime), 23)
INSERT [dbo].[PurchaseReturnDetail] ([PurchaseReturnDetailId], [PurchaseReturnId], [Article], [PurchaseRate], [ReturnQuantity], [NetAmount], [PurchaseReturnDate], [Discount]) VALUES (N'2', N'PR-2', N'3875', 1350, CAST(1.00 AS Decimal(18, 2)), CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T11:44:16.333' AS DateTime), 23)
INSERT [dbo].[PurchaseReturnDetail] ([PurchaseReturnDetailId], [PurchaseReturnId], [Article], [PurchaseRate], [ReturnQuantity], [NetAmount], [PurchaseReturnDate], [Discount]) VALUES (N'3', N'PR-2', N'27546', 1150, CAST(3.00 AS Decimal(18, 2)), CAST(3450.00 AS Decimal(18, 2)), CAST(N'2024-07-27T11:44:16.333' AS DateTime), 23)
GO
INSERT [dbo].[PurchaseReturnMaster] ([PurchaseReturnId], [PurchaseReturnDate], [SaleMan], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'PR-1', CAST(N'2024-07-27T09:46:21.880' AS DateTime), N'a', 1, N'Bata', 2500)
INSERT [dbo].[PurchaseReturnMaster] ([PurchaseReturnId], [PurchaseReturnDate], [SaleMan], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'PR-2', CAST(N'2024-07-27T11:44:16.317' AS DateTime), N'a', 5, N'Metro Shoes', 4800)
GO
INSERT [dbo].[SaleDetail] ([SaleDetailId], [SaleId], [SaleDate], [Article], [SaleRate], [NetAmount], [Pair], [TotalSaleRate], [Discount]) VALUES (N'3', N'SI-1', CAST(N'2024-07-27T11:53:11.303' AS DateTime), N'1256', CAST(1250.00 AS Decimal(18, 2)), CAST(962.50 AS Decimal(18, 2)), 1, CAST(1250.00 AS Decimal(18, 2)), 23)
INSERT [dbo].[SaleDetail] ([SaleDetailId], [SaleId], [SaleDate], [Article], [SaleRate], [NetAmount], [Pair], [TotalSaleRate], [Discount]) VALUES (N'4', N'SI-2', CAST(N'2024-07-27T12:45:20.130' AS DateTime), N'3875', CAST(1350.00 AS Decimal(18, 2)), CAST(1350.00 AS Decimal(18, 2)), 1, CAST(1350.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SaleDetail] ([SaleDetailId], [SaleId], [SaleDate], [Article], [SaleRate], [NetAmount], [Pair], [TotalSaleRate], [Discount]) VALUES (N'5', N'SI-2', CAST(N'2024-07-27T12:45:20.147' AS DateTime), N'27546', CAST(1150.00 AS Decimal(18, 2)), CAST(1771.00 AS Decimal(18, 2)), 2, CAST(2300.00 AS Decimal(18, 2)), 23)
GO
INSERT [dbo].[SaleMaster] ([SaleId], [SaleDate], [SaleMan], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'SI-1', CAST(N'2024-07-27T11:53:11.303' AS DateTime), N'a', N'1', N'Bata', 962.5)
INSERT [dbo].[SaleMaster] ([SaleId], [SaleDate], [SaleMan], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'SI-2', CAST(N'2024-07-27T12:45:20.130' AS DateTime), N'a', N'2', N'Servis Shoes', 3121)
GO
INSERT [dbo].[SaleReturnDetail] ([SaleReturnDetailId], [SaleReturnId], [Article], [SaleRate], [ReturnQuantity], [NetAmount], [SaleReturnDate], [Discount]) VALUES (N'1', N'SR-1', N'3875', CAST(1350.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T15:43:38.213' AS DateTime), 0)
GO
INSERT [dbo].[SaleReturnMaster] ([SaleReturnId], [SaleReturnDate], [SaleMan], [PartyCode], [PartyName], [TotalAmount]) VALUES (N'SR-1', CAST(N'2024-07-27T15:43:38.200' AS DateTime), N'a', 1, N'Bata', 1350)
GO
INSERT [dbo].[SizeInfo] ([SizeCode], [Size], [IsDeleted]) VALUES (1, N'31
', 0)
INSERT [dbo].[SizeInfo] ([SizeCode], [Size], [IsDeleted]) VALUES (2, N'31', 0)
INSERT [dbo].[SizeInfo] ([SizeCode], [Size], [IsDeleted]) VALUES (3, N'32', 0)
INSERT [dbo].[SizeInfo] ([SizeCode], [Size], [IsDeleted]) VALUES (4, N'33', 0)
INSERT [dbo].[SizeInfo] ([SizeCode], [Size], [IsDeleted]) VALUES (5, N'34', 0)
INSERT [dbo].[SizeInfo] ([SizeCode], [Size], [IsDeleted]) VALUES (6, N'38
', 0)
INSERT [dbo].[SizeInfo] ([SizeCode], [Size], [IsDeleted]) VALUES (7, N'12', 0)
INSERT [dbo].[SizeInfo] ([SizeCode], [Size], [IsDeleted]) VALUES (8, N'12', 0)
INSERT [dbo].[SizeInfo] ([SizeCode], [Size], [IsDeleted]) VALUES (9, N'13', 0)
GO
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (1, N'PI', N'PI-1', N'1256', 10, CAST(9625.00 AS Decimal(18, 2)), CAST(N'2024-07-27T09:45:12.567' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (12, N'PI', N'PI-2', N'27546', 15, CAST(13282.50 AS Decimal(18, 2)), CAST(N'2024-07-27T11:11:42.833' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (13, N'PI', N'PI-2', N'3875', 5, CAST(5197.50 AS Decimal(18, 2)), CAST(N'2024-07-27T11:11:42.850' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (4, N'PR', N'PR-1', N'1256', 2, CAST(2500.00 AS Decimal(18, 2)), CAST(N'2024-07-27T09:46:21.880' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (14, N'PR', N'PR-2', N'3875', 1, CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T11:44:16.333' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (15, N'PR', N'PR-2', N'27546', 3, CAST(3450.00 AS Decimal(18, 2)), CAST(N'2024-07-27T11:44:16.333' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (9, N'SR', N'SR-1', N'3875', 1, CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T09:49:49.803' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (11, N'SR', N'SR-1', N'3875', 1, CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T11:10:54.850' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (17, N'SI', N'SI-1', N'1256', 1, CAST(962.50 AS Decimal(18, 2)), CAST(N'2024-07-27T11:45:29.707' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (18, N'SI', N'SI-1', N'1256', 1, CAST(962.50 AS Decimal(18, 2)), CAST(N'2024-07-27T11:47:42.067' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (19, N'SI', N'SI-1', N'1256', 1, CAST(962.50 AS Decimal(18, 2)), CAST(N'2024-07-27T11:53:11.317' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (20, N'SI', N'SI-2', N'3875', 1, CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T12:18:27.677' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (21, N'SI', N'SI-2', N'3875', 1, CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T12:28:24.303' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (22, N'SI', N'SI-2', N'3875', 1, CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T12:38:07.473' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (23, N'SI', N'SI-2', N'3875', 1, CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T12:39:19.520' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (28, N'SR', N'SR-1', N'3875', 1, CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T15:36:49.933' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (30, N'SR', N'SR-1', N'3875', 1, CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T15:39:14.463' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (31, N'SR', N'SR-1', N'3875', 1, CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T15:43:38.213' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (32, N'PI', N'PI-3', N'1256', 12, CAST(13200.00 AS Decimal(18, 2)), CAST(N'2024-07-27T23:43:55.643' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (33, N'PI', N'PI-4', N'27546', 10, CAST(9625.00 AS Decimal(18, 2)), CAST(N'2024-07-27T23:44:12.360' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (34, N'PI', N'PI-5', N'3875', 15, CAST(14437.50 AS Decimal(18, 2)), CAST(N'2024-07-27T23:44:30.147' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (36, N'PI', N'PI-7', N'3875', 12, CAST(14322.00 AS Decimal(18, 2)), CAST(N'2024-07-27T23:44:59.440' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (37, N'PI', N'PI-8', N'27546', 1, CAST(962.50 AS Decimal(18, 2)), CAST(N'2024-07-27T23:45:11.157' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (39, N'PI', N'PI-10', N'3875', 12, CAST(11550.00 AS Decimal(18, 2)), CAST(N'2024-07-27T23:45:40.407' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (41, N'PI', N'PI-12', N'1256', 20, CAST(19250.00 AS Decimal(18, 2)), CAST(N'2024-07-28T10:48:14.103' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (42, N'PI', N'PI-12', N'27546', 15, CAST(17902.50 AS Decimal(18, 2)), CAST(N'2024-07-28T10:48:14.103' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (7, N'SI', N'SI-1', N'1256', 1, CAST(962.50 AS Decimal(18, 2)), CAST(N'2024-07-27T09:47:11.583' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (8, N'SI', N'SI-2', N'3875', 1, CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T09:47:38.210' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (26, N'SI', N'SI-2', N'3875', 1, CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T12:45:20.130' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (27, N'SI', N'SI-2', N'27546', 2, CAST(1771.00 AS Decimal(18, 2)), CAST(N'2024-07-27T12:45:20.147' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (29, N'SR', N'SR-1', N'3875', 1, CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T15:38:10.417' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (10, N'SI', N'SI-1', N'1256', 1, CAST(962.50 AS Decimal(18, 2)), CAST(N'2024-07-27T11:06:38.647' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (16, N'SI', N'SI-1', N'1256', 1, CAST(962.50 AS Decimal(18, 2)), CAST(N'2024-07-27T11:45:19.410' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (24, N'SI', N'SI-2', N'3875', 1, CAST(1350.00 AS Decimal(18, 2)), CAST(N'2024-07-27T12:43:38.973' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (25, N'SI', N'SI-2', N'27546', 2, CAST(1771.00 AS Decimal(18, 2)), CAST(N'2024-07-27T12:43:38.973' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (35, N'PI', N'PI-6', N'27546', 4, CAST(3850.00 AS Decimal(18, 2)), CAST(N'2024-07-27T23:44:43.247' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (38, N'PI', N'PI-9', N'3875', 1250, CAST(2069375.00 AS Decimal(18, 2)), CAST(N'2024-07-27T23:45:27.520' AS DateTime), N'a')
INSERT [dbo].[Stock] ([StockId], [InvType], [InvId], [Article], [Pair], [NetAmount], [DateTime], [UserName]) VALUES (40, N'PI', N'PI-11', N'27546', 12, CAST(11250.00 AS Decimal(18, 2)), CAST(N'2024-07-27T23:46:07.563' AS DateTime), N'a')
GO
INSERT [dbo].[User] ([ID], [Name], [CreationDate], [UserAddress], [PhoneNo], [CNICNo], [Remarks], [Logintype], [UserName], [UserPassword], [isActive]) VALUES (1, N'Ali Bbatti', N'Jun 23 2024  9:54PM', N'1', N'1111', N'36302-0928380-1', N'11111', N'Admin', N'a', N'a', 1)
INSERT [dbo].[User] ([ID], [Name], [CreationDate], [UserAddress], [PhoneNo], [CNICNo], [Remarks], [Logintype], [UserName], [UserPassword], [isActive]) VALUES (2, N'Ahmad Bhatti', N'Jun 23 2024 10:36PM', N'1', N'1111', N'36302-0928380-1', N'11111', N'Admin', N'Ahmadn', N'123', 1)
INSERT [dbo].[User] ([ID], [Name], [CreationDate], [UserAddress], [PhoneNo], [CNICNo], [Remarks], [Logintype], [UserName], [UserPassword], [isActive]) VALUES (3, N'kamran', N'Jun 21 2024  7:41PM', NULL, N'030434224', N'36302-54533104-3', NULL, N'User', N'kamran', N'a', 1)
INSERT [dbo].[User] ([ID], [Name], [CreationDate], [UserAddress], [PhoneNo], [CNICNo], [Remarks], [Logintype], [UserName], [UserPassword], [isActive]) VALUES (4, N'Ahmad Bhatti', N'Jun 23 2024  9:54PM', N'1', N'1111', N'36302-0928380-1', N'11111', N'Admin', N'c', N'c', 0)
INSERT [dbo].[User] ([ID], [Name], [CreationDate], [UserAddress], [PhoneNo], [CNICNo], [Remarks], [Logintype], [UserName], [UserPassword], [isActive]) VALUES (5, N'Ali BHatti', N'Jun 23 2024 10:00PM', N'1', N'1111', N'36302-0928380-1', N'11111', N'Admin', N'd', N'd', 0)
GO
SET IDENTITY_INSERT [dbo].[User_Rights_junction] ON 

INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1, 3, 3)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (2, 3, 4)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (3, 3, 5)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (4, 3, 6)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (5, 3, 7)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1083, 1, 1)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1084, 1, 2)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1085, 1, 3)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1086, 1, 4)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1087, 1, 5)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1088, 1, 6)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1089, 1, 7)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1090, 1, 8)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1091, 1, 9)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1092, 4, 1)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1093, 4, 2)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1094, 4, 3)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1095, 4, 4)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1096, 4, 5)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1097, 4, 6)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1098, 4, 7)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1099, 4, 8)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1100, 4, 9)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1110, 2, 1)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1111, 2, 2)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1112, 2, 3)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1113, 2, 4)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1114, 2, 5)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1115, 2, 6)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1116, 2, 7)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1117, 2, 8)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1118, 2, 9)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1119, 2, 1)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1120, 2, 2)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1121, 2, 3)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1122, 2, 4)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1123, 2, 5)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1124, 2, 6)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1125, 2, 7)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1126, 2, 8)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1127, 2, 9)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1128, 2, 1)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1129, 2, 2)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1130, 2, 3)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1131, 2, 4)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1132, 2, 5)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1133, 2, 6)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1134, 2, 7)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1135, 2, 8)
INSERT [dbo].[User_Rights_junction] ([Serial], [Userid], [Rightid]) VALUES (1136, 2, 9)
SET IDENTITY_INSERT [dbo].[User_Rights_junction] OFF
GO
INSERT [dbo].[UserRights] ([ID], [Name]) VALUES (1, N'PartyCoding')
INSERT [dbo].[UserRights] ([ID], [Name]) VALUES (2, N'ProductCoding')
INSERT [dbo].[UserRights] ([ID], [Name]) VALUES (3, N'SizeCoding')
INSERT [dbo].[UserRights] ([ID], [Name]) VALUES (4, N'Purchase')
INSERT [dbo].[UserRights] ([ID], [Name]) VALUES (5, N'PurchaseReturn')
INSERT [dbo].[UserRights] ([ID], [Name]) VALUES (6, N'Sale')
INSERT [dbo].[UserRights] ([ID], [Name]) VALUES (7, N'SaleReturn')
INSERT [dbo].[UserRights] ([ID], [Name]) VALUES (8, N'PurchaeReportBetween')
INSERT [dbo].[UserRights] ([ID], [Name]) VALUES (9, N'User')
GO
INSERT [dbo].[Voucher] ([VoucherID], [VoucherDate], [PartyID], [Amount], [Discritipn], [IsDeleted]) VALUES (N'1', CAST(N'2024-07-27T09:50:31.473' AS DateTime), 2, CAST(10000.00 AS Decimal(18, 2)), N'Paid By Cash', 0)
INSERT [dbo].[Voucher] ([VoucherID], [VoucherDate], [PartyID], [Amount], [Discritipn], [IsDeleted]) VALUES (N'2', CAST(N'2024-07-27T09:51:52.880' AS DateTime), 1, CAST(5000.00 AS Decimal(18, 2)), N'Bank', 0)
GO
ALTER TABLE [dbo].[User_Rights_junction]  WITH NOCHECK ADD  CONSTRAINT [FK_RightID] FOREIGN KEY([Rightid])
REFERENCES [dbo].[UserRights] ([ID])
GO
ALTER TABLE [dbo].[User_Rights_junction] CHECK CONSTRAINT [FK_RightID]
GO
ALTER TABLE [dbo].[User_Rights_junction]  WITH NOCHECK ADD  CONSTRAINT [FK_UserID] FOREIGN KEY([Userid])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[User_Rights_junction] CHECK CONSTRAINT [FK_UserID]
GO
/****** Object:  StoredProcedure [dbo].[CalculateDifference]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[CalculateDifference]
    @PartyCode INT
AS
BEGIN
    -- Declare variables to store the results of the queries
    DECLARE @TotalPurchaseAmount DECIMAL(18, 2);
    DECLARE @TotalVoucherAmount DECIMAL(18, 2);
    DECLARE @Difference DECIMAL(18, 2);

    -- Get the total amount from PurchaseMaster
    SELECT @TotalPurchaseAmount = ISNULL(SUM(TotalAmount), 0)
    FROM PurchaseMaster
    WHERE PartyCode = @PartyCode;

    -- Get the total amount from Vouchers
    SELECT @TotalVoucherAmount = ISNULL(SUM(Amount), 0)
    FROM Voucher
    WHERE PartyID = @PartyCode;

    -- Calculate the difference
    SET @Difference = @TotalPurchaseAmount - @TotalVoucherAmount;

    -- Return the difference
    SELECT @Difference AS Difference;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteExpense]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[DeleteExpense]
(
    @ID INT,
	@IsDelete bit
)
AS
BEGIN
        UPDATE Expense
        SET  IsDeleted=1
        WHERE ID = @ID;
    END
   

GO
/****** Object:  StoredProcedure [dbo].[DeleteExpenseCoding]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteExpenseCoding]
(
    @ID INT,
	@IsDelete bit
)
AS
BEGIN
        UPDATE ExpenseCoding
        SET  IsDeleted=1
        WHERE ID = @ID;
    END
   

GO
/****** Object:  StoredProcedure [dbo].[DeleteParty]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[DeleteParty]
(
    @PartyCode INT,
	@IsDelete bit
)
AS
BEGIN
        UPDATE PartyInfo
        SET  IsDeleted=1
        WHERE PartyCode = @PartyCode;
    END
   

GO
/****** Object:  StoredProcedure [dbo].[DeletePartyPaymentInv]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeletePartyPaymentInv]
(
    @VoucherId int
)
AS
BEGIN
        update Voucher set IsDeleted='1' where VoucherID=@VoucherId
	
    END
   

GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProduct]
(
    @ProductCode INT,
	@IsDelete bit
)
AS
BEGIN
        UPDATE ProductInfo
        SET  IsDeleted=1
        WHERE ProductCode = @ProductCode;
END
GO
/****** Object:  StoredProcedure [dbo].[DeletePurchaseInv]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeletePurchaseInv]
(
    @PurchaseInv nvarchar(max)
)
AS
BEGIN
        Delete from PurchaseMaster where PurchaseId=@PurchaseInv;
		Delete from PurchaseDetail where PurchaseId=@PurchaseInv
    END
   

GO
/****** Object:  StoredProcedure [dbo].[DeletePurchaseReturnInv]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[DeletePurchaseReturnInv]
(
    @PurchaseReturnInv nvarchar(max)
)
AS
BEGIN
        Delete from PurchaseReturnMaster where PurchaseReturnId=@PurchaseReturnInv;
		Delete from PurchaseReturnDetail where PurchaseReturnId=@PurchaseReturnInv
    END
   

GO
/****** Object:  StoredProcedure [dbo].[DeleteSaleInv]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[DeleteSaleInv]
(
    @SaleInv nvarchar(max)
)
AS
BEGIN
        Delete from SaleMaster where SaleId=@SaleInv;
		Delete from SaleDetail where SaleId=@SaleInv
    END
   

GO
/****** Object:  StoredProcedure [dbo].[DeleteSize]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSize]
(
    @SizeCode INT,
	@IsDelete bit
)
AS
BEGIN
        UPDATE SizeInfo
        SET  IsDeleted=1
        WHERE SizeCode = @SizeCode;
    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteStock]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[DeleteStock]
(
    @ID nvarchar(max)
	
)
AS
BEGIN
        Delete from Stock 
        WHERE InvId = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
(
    @UserID INT,
	@IsActive bit
)
AS
BEGIN
        UPDATE [User]
        SET  IsActive=@IsActive
        WHERE ID = @UserID;
END
GO
/****** Object:  StoredProcedure [dbo].[GetStockInHand]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStockInHand]
    @Article nvarchar(50)
 
AS
BEGIN
    WITH StockCalculations AS (
        SELECT 
            SUM(CASE WHEN InvType = 'PI' THEN Pair ELSE 0 END) AS TotalPurchases,
            SUM(CASE WHEN InvType = 'PR' THEN Pair ELSE 0 END) AS TotalPurchaseReturns,
            SUM(CASE WHEN InvType = 'SI' THEN Pair ELSE 0 END) AS TotalSales,
            SUM(CASE WHEN InvType = 'SR' THEN Pair ELSE 0 END) AS TotalSalesReturns
        FROM Stock
        WHERE Article = @Article 
    )
    SELECT 
        TotalPurchases - TotalPurchaseReturns - TotalSales + TotalSalesReturns AS StockInHand
    FROM StockCalculations;
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertPurchaseDetail]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertPurchaseDetail]
  @PurchaseInv nvarchar(max),
    @Article nvarchar(max),
	@Pair  int,
	@Discount int,	
	 @Rate  decimal(18,2),
    @NetAmount  decimal(18,2),
	@UnitPrice decimal(18,2),
	@Date Datetime
AS
BEGIN
    DECLARE @id INT
    SELECT @id = ISNULL(MAX(PurchaseDetailId), 0) + 1 FROM PurchaseDetail

    INSERT INTO PurchaseDetail (PurchaseDetailId
      ,PurchaseId
      ,Article
      ,Rate
      ,NetAmount
      ,PurchaseDate,Pair,Discount,UnitPrice)
    VALUES (@id,@PurchaseInv,@Article,@Rate,@NetAmount,@Date,@Pair,@Discount,@UnitPrice)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertPurchaseReturnDetail]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertPurchaseReturnDetail]

  @PurchaseReturnInv nvarchar(max),
	@Article  nvarchar(max),
    @ReturnQuantity  decimal(18,2),
	 @PurchaseRate  float,
    @NetAmount  float,
	@Discount int,
	@Date Datetime

AS
BEGIN
    DECLARE @id INT	
    SELECT @id = ISNULL(MAX(PurchaseReturnDetailId), 0) + 1 FROM PurchaseReturnDetail
    INSERT INTO PurchaseReturnDetail([PurchaseReturnDetailId]
      ,[PurchaseReturnId]
      ,[Article]
      ,[PurchaseRate]
      ,[ReturnQuantity]
      ,[NetAmount]
      ,[PurchaseReturnDate],Discount)
    VALUES (@id,@PurchaseReturnInv,@Article,@PurchaseRate,@ReturnQuantity,@NetAmount,@Date,@Discount)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertSaleDetail]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[InsertSaleDetail]

  @SaleInv nvarchar(max),
	@Article  nvarchar(max),
    @Pair  decimal(18,2),
	 @SaleRate decimal(18,2),
	 @TotalSaleRate decimal(18,2),
	 @Discount int,
    @NetAmount  decimal(18,2),
	@Date Datetime
AS
BEGIN
    DECLARE @id INT	
    SELECT @id = ISNULL(MAX(SaleDetailId), 0) + 1 FROM SaleDetail
    INSERT INTO SaleDetail([SaleDetailId]
      ,[SaleId]
      ,[SaleDate]
      ,[Article]
      ,[SaleRate]
      ,[NetAmount]
      ,[Pair]
      ,[TotalSaleRate]
      ,[Discount])
    VALUES (@id,@SaleInv,@Date,@Article,@SaleRate,@NetAmount,@Pair,@TotalSaleRate,@Discount)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertSaleReturnDetail]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[InsertSaleReturnDetail]

  @SaleReturnInv nvarchar(max),
	@Article  nvarchar(max),
    @ReturnQuantity  decimal(18,2),
	 @SaleRate  decimal(18,2),
    @NetAmount  decimal(18,2),
	@Date Datetime,
	@Discount int
AS
BEGIN
    DECLARE @id INT	
    SELECT @id = ISNULL(MAX(SaleReturnDetailId), 0) + 1 FROM SaleReturnDetail
    INSERT INTO SaleReturnDetail
	([SaleReturnDetailId]
      ,[SaleReturnId]
      ,[Article]
      ,[SaleRate]
      ,[ReturnQuantity]
      ,[NetAmount]
      ,[SaleReturnDate]
      ,[Discount])
    VALUES 
	(@id,@SaleReturnInv,@Article,@SaleRate,@ReturnQuantity,@NetAmount,@Date,@Discount)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateArticle]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUpdateArticle]
(
    @ArticleId INT,
    @Article NVARCHAR(MAX),
    @IsUpdate BIT
)
AS
BEGIN
    IF @IsUpdate = 1
    BEGIN
        UPDATE ArticleInfo
        SET Article = @Article, IsDeleted = 0
        WHERE ArticleId = @ArticleId;
    END
    ELSE
    BEGIN
        INSERT INTO ArticleInfo (ArticleId, Article, IsDeleted)
        VALUES (@ArticleId, @Article ,0);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateExpense]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUpdateExpense]
(
    @ID INT,
	@Date DateTime,
    @Purpose NVARCHAR(MAX),
	@Description NVARCHAR(MAX),
	@Amount decimal(18,2),
    @IsUpdate BIT
)
AS
BEGIN
    IF @IsUpdate = 1
    BEGIN
        UPDATE Expense
        SET Date = @Date, Purpose = @Purpose, Description = @Description, IsDeleted=0, Amount=@Amount
        WHERE ID = @ID;
    END
    ELSE
    BEGIN
        INSERT INTO Expense(ID, Date, Purpose, Description, IsDeleted,Amount)
        VALUES (@ID, @Date, @Purpose, @Description, 0,@Amount);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateExpenseCoding]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUpdateExpenseCoding]
(
    @ID INT,
    @Type NVARCHAR(MAX),
    @IsUpdate BIT
)
AS
BEGIN
    IF @IsUpdate = 1
    BEGIN
        UPDATE ExpenseCoding
        SET Type = @Type, IsDeleted=0
        WHERE ID = @ID;
    END
    ELSE
    BEGIN
        INSERT INTO ExpenseCoding (ID, Type, IsDeleted)
        VALUES (@ID, @Type, 0);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateParty]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUpdateParty]
(
    @PartyCode INT,
    @PartyName NVARCHAR(MAX),
    @Location NVARCHAR(MAX),
    @Contact NVARCHAR(MAX),
   @DateTime Datetime,
    @IsUpdate BIT
)
AS
BEGIN
    IF @IsUpdate = 1
    BEGIN
        UPDATE PartyInfo
        SET PartyName = @PartyName, Location = @Location, Contact = @Contact,DateTime=@DateTime, IsDeleted=0
        WHERE PartyCode = @PartyCode;
    END
    ELSE
    BEGIN
        INSERT INTO PartyInfo (PartyCode, PartyName, Location, Contact,DateTime,IsDeleted)
        VALUES (@PartyCode, @PartyName, @Location, @Contact,@DateTime,0);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdatePartyPayment]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertUpdatePartyPayment]
(
    @VoId int,
    @dptDate datetime,
    @PartyId int,
    @Amount decimal(18,2),
	@Description nvarchar(max),
    @IsUpdate BIT
)
AS
BEGIN
    IF @IsUpdate = 1
    BEGIN
        UPDATE Voucher
        SET VoucherDate=@dptDate, PartyID= @PartyId, Amount=@Amount, Discritipn=@Description
        WHERE VoucherID = @VoId;
    END
    ELSE
    BEGIN
        INSERT INTO Voucher (VoucherID ,VoucherDate, PartyID, Amount, Discritipn, IsDeleted)
        VALUES (@VoId, @dptDate, @PartyId, @Amount, @Description, 0);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdatePurchaeMaster]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertUpdatePurchaeMaster]
(
    @PurchaseInv NVARCHAR(max),
    @dtpInv datetime,
   @SaleMan varchar(max),
    @PartyCode int,
	 @PartyName nvarchar(max),
   @TotalAmount decimal(18,2),
    @IsUpdate BIT
)
AS
BEGIN
    IF @IsUpdate = 1
    BEGIN
        UPDATE PurchaseMaster
        SET PurchaseDate=@dtpInv,SaleMen=@SaleMan,PartyCode= @PartyCode,PartyName=@PartyName,TotalAmount=@TotalAmount
        WHERE PurchaseId = @PurchaseInv;

		Delete from PurchaseDetail where PurchaseId=@PurchaseInv
    END
    ELSE
    BEGIN
        INSERT INTO PurchaseMaster (PurchaseId ,PurchaseDate,SaleMen ,PartyCode ,PartyName,TotalAmount)
        VALUES (@PurchaseInv,@dtpInv,@SaleMan,@PartyCode,@PartyName,@TotalAmount);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdatePurchaeReturnMaster]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[InsertUpdatePurchaeReturnMaster]
(
    @PurchaseReturnId NVARCHAR(max),
    @dtpInv datetime,
   @SaleMan varchar(max),
    @PartyCode int  Null,
	 @PartyName nvarchar(max)='',
   @TotalAmount float,
    @IsUpdate BIT
)
AS
BEGIN
    IF @IsUpdate = 1
    BEGIN
        UPDATE PurchaseReturnMaster
        SET PurchaseReturnDate=@dtpInv,SaleMan=@SaleMan,PartyCode= @PartyCode,PartyName=@PartyName,TotalAmount=@TotalAmount
        WHERE PurchaseReturnId = @PurchaseReturnId;

		Delete from PurchaseReturnDetail where PurchaseReturnId=@PurchaseReturnId
    END
    ELSE
    BEGIN
        INSERT INTO PurchaseReturnMaster(PurchaseReturnId ,PurchaseReturnDate,SaleMan ,PartyCode ,PartyName,TotalAmount)
        VALUES (@PurchaseReturnId,@dtpInv,@SaleMan,@PartyCode,@PartyName,@TotalAmount);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateSaleMaster]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[InsertUpdateSaleMaster]
(
    @SaleInv NVARCHAR(max),
    @dtpInv datetime,
   @SaleMan varchar(max),
    @PartyCode int,
	 @PartyName nvarchar(max),
   @TotalAmount float,
    @IsUpdate BIT
)
AS	
BEGIN
    IF @IsUpdate = 1
    BEGIN
        UPDATE SaleMaster
        SET SaleDate=@dtpInv,SaleMan=@SaleMan,PartyCode= @PartyCode,PartyName=@PartyName,TotalAmount=@TotalAmount
        WHERE SaleId = @SaleInv;

		Delete from SaleDetail where SaleId=@SaleInv
    END
    ELSE
    BEGIN
        INSERT INTO SaleMaster(SaleId ,SaleDate,SaleMan ,PartyCode ,PartyName,TotalAmount)
        VALUES (@SaleInv,@dtpInv,@SaleMan,@PartyCode,@PartyName,@TotalAmount);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateSaleReturnMaster]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [dbo].[InsertUpdateSaleReturnMaster]
(
    @SaleReturnId NVARCHAR(max),
    @dtpInv datetime,
   @SaleMan varchar(max),
    @PartyCode int,
	 @PartyName nvarchar(max),
   @TotalAmount float,
    @IsUpdate BIT
)
AS
BEGIN
    IF @IsUpdate = 1
    BEGIN 
        UPDATE SaleReturnMaster
        SET SaleReturnDate=@dtpInv,SaleMan=@SaleMan,PartyCode=@PartyCode,PartyName=@PartyName,TotalAmount=@TotalAmount
        WHERE SaleReturnId = @SaleReturnId;

		Delete from SaleReturnDetail where SaleReturnId=@SaleReturnId
    END
    ELSE
    BEGIN
        INSERT INTO SaleReturnMaster(SaleReturnId
      ,SaleReturnDate
      ,SaleMan
      ,PartyCode
      ,PartyName
      ,TotalAmount)
        VALUES (@SaleReturnId,@dtpInv,@SaleMan,@PartyCode,@PartyName,@TotalAmount);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateSize]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUpdateSize]
(
    @SizeCode INT,
    @Size NVARCHAR(MAX),
    @IsUpdate BIT
)
AS
BEGIN
    IF @IsUpdate = 1
    BEGIN
        UPDATE SizeInfo
        SET Size = @Size, IsDeleted=0
        WHERE SizeCode = @SizeCode;
    END
    ELSE
    BEGIN
        INSERT INTO SizeInfo (SizeCode, Size, IsDeleted)
        VALUES (@SizeCode, @Size ,0);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateStock]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertUpdateStock]
(
    @InvType NVARCHAR(MAX),
    @InvId NVARCHAR(MAX),
    @Pair int,
	@Article nvarchar(50), 
   @NetAmount float,
   @DateTime datetime,
   @UserName nvarchar(max)
   
)
AS
BEGIN
 DECLARE @id INT
    SELECT @id = ISNULL(MAX(StockId), 0) + 1 FROM Stock
        INSERT INTO Stock (StockId, InvType, InvId,Pair,NetAmount,DateTime,UserName,Article)
        VALUES (@id, @InvType, @InvId,@Pair,@NetAmount,@DateTime,@UserName,@Article);
    END

GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateUser]    Script Date: 7/28/2024 11:19:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUpdateUser]
(
    @UserID INT,
    @Name NVARCHAR(MAX),
	@CreationDate datetime,
    @PhoneNo NVARCHAR(MAX),
    @CNIC NVARCHAR(MAX),
    @LoginType NVARCHAR(MAX),
	@UserName NVARCHAR(MAX),
	@UserPassword NVARCHAR(MAX),
	@Active BIT,
	@IsUpdate BIT
)
AS
BEGIN
    IF @IsUpdate = 1
    BEGIN
        UPDATE [User]
        SET Name = @Name,CreationDate=@CreationDate,PhoneNo=@PhoneNo,
		CNICNo=@CNIC,Logintype=@LoginType,UserName=@UserName,IsActive = @Active,UserPassword =@UserPassword
        WHERE ID = @UserID;
    END
    ELSE
    BEGIN
        INSERT INTO [User] (ID, Name,CreationDate,PhoneNo, CNICNo, Logintype,UserName,UserPassword,isActive)
        VALUES (@UserID,@Name ,@CreationDate,@PhoneNo,@CNIC,@LoginType,@UserName,@UserPassword,@Active);
    END
END

GO
USE [master]
GO
ALTER DATABASE [Article] SET  READ_WRITE 
GO
