USE [master]
GO
/****** Object:  Database [EnesAtacDB]    Script Date: 21.02.2021 01:28:30 ******/
CREATE DATABASE [EnesAtacDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EnesAtacDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EnesAtacDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EnesAtacDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EnesAtacDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EnesAtacDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EnesAtacDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EnesAtacDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EnesAtacDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EnesAtacDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EnesAtacDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EnesAtacDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [EnesAtacDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EnesAtacDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EnesAtacDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EnesAtacDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EnesAtacDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EnesAtacDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EnesAtacDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EnesAtacDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EnesAtacDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EnesAtacDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EnesAtacDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EnesAtacDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EnesAtacDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EnesAtacDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EnesAtacDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EnesAtacDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EnesAtacDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EnesAtacDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EnesAtacDB] SET  MULTI_USER 
GO
ALTER DATABASE [EnesAtacDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EnesAtacDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EnesAtacDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EnesAtacDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EnesAtacDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EnesAtacDB] SET QUERY_STORE = OFF
GO
USE [EnesAtacDB]
GO
/****** Object:  Table [dbo].[Article_Tags]    Script Date: 21.02.2021 01:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article_Tags](
	[Article_Id] [int] NOT NULL,
	[Tag_Id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 21.02.2021 01:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Article_Id] [int] IDENTITY(1,1) NOT NULL,
	[Article_Title] [nvarchar](100) NOT NULL,
	[Article_Content] [nvarchar](max) NOT NULL,
	[Article_Date] [datetime] NOT NULL,
	[Category_Id] [int] NOT NULL,
	[Article_View_Count] [int] NOT NULL,
	[Article_Like_Count] [int] NOT NULL,
	[Author_Id] [int] NOT NULL,
	[Is_Active] [bit] NOT NULL,
	[Article_Is_Active_On_Last_Artices] [bit] NOT NULL,
	[Article_Meta_Tags] [nvarchar](max) NULL,
	[Article_Meta_Description] [nvarchar](250) NULL,
	[Article_Cover_Image] [nvarchar](100) NULL,
 CONSTRAINT [PK_Makale] PRIMARY KEY CLUSTERED 
(
	[Article_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 21.02.2021 01:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Auther_Id] [int] IDENTITY(1,1) NOT NULL,
	[Author_Name] [nvarchar](50) NOT NULL,
	[Author_Surname] [nvarchar](50) NOT NULL,
	[Author_Mail] [nvarchar](50) NOT NULL,
	[Author_Description] [nvarchar](max) NOT NULL,
	[Author_PictureUrl] [nvarchar](100) NOT NULL,
	[Author_Password] [nvarchar](50) NOT NULL,
	[Author_Nickname] [nvarchar](50) NOT NULL,
	[Author_Article_Description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Yazar] PRIMARY KEY CLUSTERED 
(
	[Auther_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorys]    Script Date: 21.02.2021 01:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorys](
	[Category_Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [nvarchar](50) NOT NULL,
	[Category_Ranking] [int] NOT NULL,
 CONSTRAINT [PK_Kategori] PRIMARY KEY CLUSTERED 
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CKEditor_Images]    Script Date: 21.02.2021 01:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CKEditor_Images](
	[CKEditor_Id] [int] IDENTITY(1,1) NOT NULL,
	[CKEditor_Url] [text] NOT NULL,
 CONSTRAINT [PK_CKEditor_Images] PRIMARY KEY CLUSTERED 
(
	[CKEditor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 21.02.2021 01:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Comment_Id] [int] IDENTITY(1,1) NOT NULL,
	[Comment_Username] [nvarchar](25) NOT NULL,
	[Comment_Content] [nvarchar](500) NOT NULL,
	[Comment_Date] [datetime] NULL,
	[Comment_Article_İd] [int] NOT NULL,
	[Comment_Is_Active] [bit] NOT NULL,
	[Comment_Email] [nvarchar](50) NOT NULL,
	[Comment_Website] [nvarchar](100) NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Comment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log_Records]    Script Date: 21.02.2021 01:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log_Records](
	[IpAddress] [varchar](50) NOT NULL,
	[Date] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pictures]    Script Date: 21.02.2021 01:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pictures](
	[Picture_Id] [int] IDENTITY(1,1) NOT NULL,
	[Small_Picture_Url] [nvarchar](250) NOT NULL,
	[Medium_Picture_Url] [nvarchar](250) NOT NULL,
	[Big_Picture_Url] [nvarchar](250) NOT NULL,
	[Cover_Photo_Url] [nvarchar](250) NOT NULL,
	[Video] [nvarchar](250) NOT NULL,
	[Article_Id] [int] NOT NULL,
 CONSTRAINT [PK_Resim] PRIMARY KEY CLUSTERED 
(
	[Picture_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sliders]    Script Date: 21.02.2021 01:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sliders](
	[Slider_Id] [int] IDENTITY(1,1) NOT NULL,
	[Slider_Url] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 21.02.2021 01:28:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Tag_Id] [int] IDENTITY(1,1) NOT NULL,
	[Tag_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Etiket] PRIMARY KEY CLUSTERED 
(
	[Tag_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Articles] ADD  CONSTRAINT [DF_Makale_EklenmeTarihi]  DEFAULT (getdate()) FOR [Article_Date]
GO
ALTER TABLE [dbo].[Articles] ADD  CONSTRAINT [DF_Articles_Article_View_Count]  DEFAULT ((0)) FOR [Article_View_Count]
GO
ALTER TABLE [dbo].[Articles] ADD  CONSTRAINT [DF_Articles_Article_Like_Count]  DEFAULT ((0)) FOR [Article_Like_Count]
GO
ALTER TABLE [dbo].[Articles] ADD  CONSTRAINT [DF_Makale_Aktif]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Articles] ADD  CONSTRAINT [DF_Articles_Article_ShowOnLastArticles]  DEFAULT ((1)) FOR [Article_Is_Active_On_Last_Artices]
GO
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_Comment_Date]  DEFAULT (getdate()) FOR [Comment_Date]
GO
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_Comment_Is_Active]  DEFAULT ((0)) FOR [Comment_Is_Active]
GO
ALTER TABLE [dbo].[Article_Tags]  WITH CHECK ADD  CONSTRAINT [FK_Article_Tags_Articles] FOREIGN KEY([Article_Id])
REFERENCES [dbo].[Articles] ([Article_Id])
GO
ALTER TABLE [dbo].[Article_Tags] CHECK CONSTRAINT [FK_Article_Tags_Articles]
GO
ALTER TABLE [dbo].[Article_Tags]  WITH CHECK ADD  CONSTRAINT [FK_Article_Tags_Tags] FOREIGN KEY([Tag_Id])
REFERENCES [dbo].[Tags] ([Tag_Id])
GO
ALTER TABLE [dbo].[Article_Tags] CHECK CONSTRAINT [FK_Article_Tags_Tags]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Authors1] FOREIGN KEY([Author_Id])
REFERENCES [dbo].[Authors] ([Auther_Id])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Authors1]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Categorys] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Categorys] ([Category_Id])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Categorys]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Articles] FOREIGN KEY([Comment_Article_İd])
REFERENCES [dbo].[Articles] ([Article_Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Articles]
GO
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Articles] FOREIGN KEY([Article_Id])
REFERENCES [dbo].[Articles] ([Article_Id])
GO
ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Articles]
GO
USE [master]
GO
ALTER DATABASE [EnesAtacDB] SET  READ_WRITE 
GO
