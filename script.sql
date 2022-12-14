USE [master]
GO
/****** Object:  Database [UniversityBD_29]    Script Date: 30/08/2022 3:45:10 PM ******/
CREATE DATABASE [UniversityBD_29]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityBD_29', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\UniversityBD_29.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityBD_29_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\UniversityBD_29_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityBD_29] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityBD_29].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityBD_29] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityBD_29] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityBD_29] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityBD_29] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityBD_29] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityBD_29] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityBD_29] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityBD_29] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityBD_29] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityBD_29] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityBD_29] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityBD_29] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityBD_29] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityBD_29] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityBD_29] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityBD_29] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityBD_29] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityBD_29] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityBD_29] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityBD_29] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityBD_29] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityBD_29] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityBD_29] SET RECOVERY FULL 
GO
ALTER DATABASE [UniversityBD_29] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityBD_29] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityBD_29] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityBD_29] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityBD_29] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [UniversityBD_29] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UniversityBD_29', N'ON'
GO
USE [UniversityBD_29]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 30/08/2022 3:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 30/08/2022 3:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [varchar](150) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentCourses]    Script Date: 30/08/2022 3:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourses](
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_StudentCourses] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 30/08/2022 3:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Email] [varchar](200) NULL,
	[RegNo] [varchar](100) NOT NULL,
	[Address] [varchar](200) NULL,
	[DepartmentId] [int] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[VW_GetAllStudentInfo]    Script Date: 30/08/2022 3:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VW_GetAllStudentInfo] as

Select s.*, d.Name as DepartmentName from Students s Inner Join Departments d on s.DepartmentId = d.Id
GO
/****** Object:  View [dbo].[VW_GetStudentCourseInfo]    Script Date: 30/08/2022 3:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VW_GetStudentCourseInfo]
As
Select s.*,c.Id As CourseId, c.Name As CourseName from Students s 
Left outer Join StudentCourses sc on sc.StudentId = s.id
Left outer Join Courses c on sc.CourseId = c.Id
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Name]) VALUES (1, N'CSE-101')
INSERT [dbo].[Courses] ([Id], [Name]) VALUES (2, N'CSE-102')
INSERT [dbo].[Courses] ([Id], [Name]) VALUES (3, N'EEE-101')
INSERT [dbo].[Courses] ([Id], [Name]) VALUES (4, N'EEE-102')
SET IDENTITY_INSERT [dbo].[Courses] OFF
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (1, N'1', N'BSc IT (Information Technology)')
INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (2, N'2', N'BSc Computer Science')
INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (3, N'3', N'BSc Microbiology ')
INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (4, N'4', N'BSc Biotechnology ')
INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (5, N'5', N'BSc Economics')
SET IDENTITY_INSERT [dbo].[Departments] OFF
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (1, 1)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (1, 2)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (1, 3)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (2, 2)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (2, 3)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (3, 3)
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([id], [Name], [Email], [RegNo], [Address], [DepartmentId]) VALUES (1, N'Istiaq Haider', N'istiaqhaider8@gmail.com', N'172159900', N'20 Sukrabad,Dhanmondi', 1)
INSERT [dbo].[Students] ([id], [Name], [Email], [RegNo], [Address], [DepartmentId]) VALUES (2, N'Istiaq Ajbi', N'istiaqhaider8@gmail.com', N'172159901', N'20 Sukrabad,Dhanmondi', 5)
INSERT [dbo].[Students] ([id], [Name], [Email], [RegNo], [Address], [DepartmentId]) VALUES (3, N'Nusaiba Nipa', N'kazinusaiba8@gmail.com', N'172159902', N'Ajagora, Waruk, Shahrasti, Chandpur', 2)
INSERT [dbo].[Students] ([id], [Name], [Email], [RegNo], [Address], [DepartmentId]) VALUES (4, N'Istiaq Haider', N'istiaq15-9601@gmail.com', N'172159903', N'20 Sukrabad,Dhanmondi', 3)
SET IDENTITY_INSERT [dbo].[Students] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Students]    Script Date: 30/08/2022 3:45:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Students] ON [dbo].[Students]
(
	[RegNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[StudentCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourses_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[StudentCourses] CHECK CONSTRAINT [FK_StudentCourses_Courses]
GO
ALTER TABLE [dbo].[StudentCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourses_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([id])
GO
ALTER TABLE [dbo].[StudentCourses] CHECK CONSTRAINT [FK_StudentCourses_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Departments]
GO
USE [master]
GO
ALTER DATABASE [UniversityBD_29] SET  READ_WRITE 
GO
