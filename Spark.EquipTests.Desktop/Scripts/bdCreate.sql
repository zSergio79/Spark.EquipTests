USE [master]
GO

/****** Object:  Database [SparcEquipTest]    Script Date: 16.06.2024 21:42:58 ******/
CREATE DATABASE [SparcEquipTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SparcEquipTest', FILENAME = N'C:\Users\*\SparcEquipTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SparcEquipTest_log', FILENAME = N'C:\Users\*\SparcEquipTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SparcEquipTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [SparcEquipTest] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [SparcEquipTest] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [SparcEquipTest] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [SparcEquipTest] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [SparcEquipTest] SET ARITHABORT OFF 
GO

ALTER DATABASE [SparcEquipTest] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [SparcEquipTest] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [SparcEquipTest] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [SparcEquipTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [SparcEquipTest] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [SparcEquipTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [SparcEquipTest] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [SparcEquipTest] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [SparcEquipTest] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [SparcEquipTest] SET  DISABLE_BROKER 
GO

ALTER DATABASE [SparcEquipTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [SparcEquipTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [SparcEquipTest] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [SparcEquipTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [SparcEquipTest] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [SparcEquipTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [SparcEquipTest] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [SparcEquipTest] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [SparcEquipTest] SET  MULTI_USER 
GO

ALTER DATABASE [SparcEquipTest] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [SparcEquipTest] SET DB_CHAINING OFF 
GO

ALTER DATABASE [SparcEquipTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [SparcEquipTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [SparcEquipTest] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [SparcEquipTest] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [SparcEquipTest] SET QUERY_STORE = OFF
GO

ALTER DATABASE [SparcEquipTest] SET  READ_WRITE 
GO
