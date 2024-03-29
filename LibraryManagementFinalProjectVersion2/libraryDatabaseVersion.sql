USE [master]
GO
/****** Object:  Database [libraryDatabaseVersion]    Script Date: 1/7/2023 5:47:37 PM ******/
CREATE DATABASE [libraryDatabaseVersion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'libraryDatabaseVersion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\libraryDatabaseVersion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'libraryDatabaseVersion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\libraryDatabaseVersion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [libraryDatabaseVersion] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [libraryDatabaseVersion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [libraryDatabaseVersion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET ARITHABORT OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [libraryDatabaseVersion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [libraryDatabaseVersion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET  DISABLE_BROKER 
GO
ALTER DATABASE [libraryDatabaseVersion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [libraryDatabaseVersion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [libraryDatabaseVersion] SET  MULTI_USER 
GO
ALTER DATABASE [libraryDatabaseVersion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [libraryDatabaseVersion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [libraryDatabaseVersion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [libraryDatabaseVersion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [libraryDatabaseVersion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [libraryDatabaseVersion] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [libraryDatabaseVersion] SET QUERY_STORE = OFF
GO
USE [libraryDatabaseVersion]
GO
/****** Object:  Table [dbo].[book]    Script Date: 1/7/2023 5:47:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[book](
	[bookId] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](150) NOT NULL,
	[author] [nvarchar](100) NOT NULL,
	[description] [ntext] NOT NULL,
	[publication_date] [date] NOT NULL,
	[pages] [int] NOT NULL,
	[ISBN13] [int] NOT NULL,
	[genre] [varchar](50) NOT NULL,
	[quantity] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[borrowandreturn]    Script Date: 1/7/2023 5:47:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[borrowandreturn](
	[memberId] [int] NULL,
	[full name] [varchar](50) NULL,
	[title] [varchar](50) NULL,
	[borrow_date] [varchar](50) NULL,
	[return_date] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 1/7/2023 5:47:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[memberID] [int] IDENTITY(1,1) NOT NULL,
	[full name] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[phone] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [libraryDatabaseVersion] SET  READ_WRITE 
GO
