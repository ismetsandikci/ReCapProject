USE [master]
GO
/****** Object:  Database [ReCapProject]    Script Date: 9.04.2021 09:36:54 ******/
CREATE DATABASE [ReCapProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ReCapProject', FILENAME = N'C:\Users\ismetsandikci\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\ReCapProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ReCapProject_log', FILENAME = N'C:\Users\ismetsandikci\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\ReCapProject.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ReCapProject] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ReCapProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ReCapProject] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [ReCapProject] SET ANSI_NULLS ON 
GO
ALTER DATABASE [ReCapProject] SET ANSI_PADDING ON 
GO
ALTER DATABASE [ReCapProject] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [ReCapProject] SET ARITHABORT ON 
GO
ALTER DATABASE [ReCapProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ReCapProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ReCapProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ReCapProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ReCapProject] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [ReCapProject] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [ReCapProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ReCapProject] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [ReCapProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ReCapProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ReCapProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ReCapProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ReCapProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ReCapProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ReCapProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ReCapProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ReCapProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ReCapProject] SET RECOVERY FULL 
GO
ALTER DATABASE [ReCapProject] SET  MULTI_USER 
GO
ALTER DATABASE [ReCapProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ReCapProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ReCapProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ReCapProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ReCapProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ReCapProject] SET QUERY_STORE = OFF
GO
USE [ReCapProject]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ReCapProject]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 9.04.2021 09:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 9.04.2021 09:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[CarImageId] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[ImagePath] [nvarchar](150) NULL,
	[Date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CarImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 9.04.2021 09:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
	[ModelName] [varchar](50) NOT NULL,
	[ModelYear] [int] NOT NULL,
	[DailyPrice] [decimal](18, 0) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[MinFindeksScore] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 9.04.2021 09:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ColorId] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditCards]    Script Date: 9.04.2021 09:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCards](
	[CreditCardId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CardNameSurname] [varchar](75) NOT NULL,
	[CardNumber] [varchar](16) NOT NULL,
	[CardExpiryDateMonth] [varchar](5) NOT NULL,
	[CardExpiryDateYear] [varchar](5) NOT NULL,
	[CardCvv] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CreditCardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 9.04.2021 09:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Findeks]    Script Date: 9.04.2021 09:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Findeks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Score] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 9.04.2021 09:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 9.04.2021 09:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[RentalId] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CreditCardId] [int] NULL,
	[RentDate] [datetime] NOT NULL,
	[ReturnDate] [datetime] NULL,
	[amountPaye] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RentalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 9.04.2021 09:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9.04.2021 09:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CarImages]  WITH CHECK ADD  CONSTRAINT [FK_CarImages_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarId])
GO
ALTER TABLE [dbo].[CarImages] CHECK CONSTRAINT [FK_CarImages_Cars]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Brands] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([BrandId])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Brands]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Colors] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([ColorId])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Colors]
GO
ALTER TABLE [dbo].[CreditCards]  WITH CHECK ADD  CONSTRAINT [FK_CreditCards_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[CreditCards] CHECK CONSTRAINT [FK_CreditCards_Customers]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Users]
GO
ALTER TABLE [dbo].[Findeks]  WITH CHECK ADD  CONSTRAINT [FK_Findeks_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Findeks] CHECK CONSTRAINT [FK_Findeks_Customers]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarId])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_Cars]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_CreditCards] FOREIGN KEY([CreditCardId])
REFERENCES [dbo].[CreditCards] ([CreditCardId])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_CreditCards]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_Customers]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_OperationClaims] FOREIGN KEY([OperationClaimId])
REFERENCES [dbo].[OperationClaims] ([Id])
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_OperationClaims]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_Users]
GO
USE [master]
GO
ALTER DATABASE [ReCapProject] SET  READ_WRITE 
GO
