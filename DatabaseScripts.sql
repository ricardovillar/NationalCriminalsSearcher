CREATE DATABASE [NationalCriminals]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NationalCriminals', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\NationalCriminals.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NationalCriminals_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\NationalCriminals_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [NationalCriminals] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NationalCriminals].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [NationalCriminals] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [NationalCriminals] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [NationalCriminals] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [NationalCriminals] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [NationalCriminals] SET ARITHABORT OFF 
GO

ALTER DATABASE [NationalCriminals] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [NationalCriminals] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [NationalCriminals] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [NationalCriminals] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [NationalCriminals] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [NationalCriminals] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [NationalCriminals] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [NationalCriminals] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [NationalCriminals] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [NationalCriminals] SET  DISABLE_BROKER 
GO

ALTER DATABASE [NationalCriminals] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [NationalCriminals] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [NationalCriminals] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [NationalCriminals] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [NationalCriminals] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [NationalCriminals] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [NationalCriminals] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [NationalCriminals] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [NationalCriminals] SET  MULTI_USER 
GO

ALTER DATABASE [NationalCriminals] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [NationalCriminals] SET DB_CHAINING OFF 
GO

ALTER DATABASE [NationalCriminals] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [NationalCriminals] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [NationalCriminals] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [NationalCriminals] SET  READ_WRITE 
GO


USE [NationalCriminals]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Criminals](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[BirthDate] [date] NULL,
	[Gender] [char](1) NULL,
	[Height] [int] NULL,
	[Weight] [int] NULL,
	[Nationality] [nvarchar](250) NULL,
	[FatherName] [nvarchar](250) NULL,
	[MotherName] [nvarchar](250) NULL,
	[PassportNumber] [nvarchar](50) NULL,
	[DriverLicenseNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](2000) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('John Dylan', '19960315', 'M', 70, 220, 'Brazilian', 'Mark Dylan', 'Mary Dylan', '00123121456', '1098875-5X')
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Bob Dylan', NULL, 'M', NULL, 222, 'Chinese', 'Chandler Dylan', 'Phoebe Dylan', NULL, '1458875540')
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Bob Marley', '19900410', 'M', 88, NULL, 'American', 'Ross Marley', 'Mary Marley', NULL, '5645645-98')
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Elvis Presley', '19860519', 'M', 65, 245, 'Canadian', 'Jos Presley', 'Steff Presley', NULL, NULL)
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Bill Gates', NULL, 'M', 96, 198, 'Mexican', 'Hebert Gates', 'Mary Gates', NULL, '104353455X')
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Hillary Clinton', NULL, 'F', 71, 201, 'Japanese', 'Joseph Clinton', 'Mary Clinton', NULL, NULL)
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Steff Johson', '19750621', 'F', NULL, 233, 'German', 'Bill Johson', 'Leslie Johson', NULL, '4353356-45')
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Amy Winehouse', '19400705', 'F', 77, 197, 'English', 'Mark Winehouse', 'Mary Winehouse', '54578121444', NULL)
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Venus Willians', '19650801', 'F', 66, 200, 'Brazilian', 'Mark Willians', 'Alexia Willians', '84534534576', NULL)
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Fabiana Murer', NULL, 'F', 57, 210, 'Brazilian', 'John Murer', 'Rachel Murer', NULL, NULL)
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Claire Smith', NULL, 'F', 63, 216, 'Australian', 'David Smith', 'Mary Smith', '11233321256', '9089089-43')
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Takuma Sato', NULL, 'M', 81, 221, 'Japanese', 'Bill Sato', 'Akiuna Sato', '98765432117', '3456455-5X')
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Paul Gonzalez', '19920911', 'M', 89, NULL, 'American', 'Mark Gonzalez', 'Cindy Gonzalez', NULL, '4565644-33')
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('John Travolta', NULL, 'M', 80, 229, 'Brazilian', 'Gordon Travolta', 'Josephine Travolta', NULL, NULL)
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Joey Tribiani', '20001025', 'M', 49, 234, 'Chinese', 'Josh Tribiani', 'Martina Tribiani', NULL, '7897805-23')
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Chandler Bing', '19871231', 'M', 57, 224, 'Canadian', 'Edinson Bing', 'Silvia Bing', '12346668678', NULL)
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Ross Geller', '19781122', 'M', 66, 214, 'Mexican', 'Richard Geller', 'Claire Geller', '21455700900', '9988875-56')
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Monica Geller', '19760330', 'F', 69, 237, 'Brazilian', 'Richard Geller', 'Claire Geller', NULL, '4565667889')
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Phoebe Buffay', '19750929', 'F', 87, 236, 'Brazilian', 'John Buffay', 'Mary Buffay', NULL, NULL)
INSERT INTO Criminals (Name, BirthDate, Gender, Height, Weight, Nationality, FatherName, MotherName, PassportNumber, DriverLicenseNumber) VALUES ('Rachel Green', '19490227', 'F', 90, 221, 'Canadian', 'Bill Buffay', 'Hillary Buffay', NULL, NULL)
GO