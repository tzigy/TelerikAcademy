USE [master]
GO

/****** Object:  Database [University]    Script Date: 09.10.2015 22:22:41 ******/
CREATE DATABASE [University]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SofiaUniversity', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SofiaUniversity.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SofiaUniversity_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SofiaUniversity_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [University] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [University].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [University] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [University] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [University] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [University] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [University] SET ARITHABORT OFF 
GO

ALTER DATABASE [University] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [University] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [University] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [University] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [University] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [University] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [University] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [University] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [University] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [University] SET  DISABLE_BROKER 
GO

ALTER DATABASE [University] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [University] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [University] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [University] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [University] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [University] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [University] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [University] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [University] SET  MULTI_USER 
GO

ALTER DATABASE [University] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [University] SET DB_CHAINING OFF 
GO

ALTER DATABASE [University] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [University] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [University] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [University] SET  READ_WRITE 
GO

