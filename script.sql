USE [master]
GO
/****** Object:  Database [GD1C22016]    Script Date: jueves, 19 de mayo de 2016 11:12:53 ******/
CREATE DATABASE [GD1C22016]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GD1C22016', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\DATA\GD1C22016.mdf' , SIZE = 359424KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GD1C22016_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\DATA\GD1C22016_log.ldf' , SIZE = 2560KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GD1C22016] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GD1C22016].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GD1C22016] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GD1C22016] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GD1C22016] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GD1C22016] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GD1C22016] SET ARITHABORT OFF 
GO
ALTER DATABASE [GD1C22016] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GD1C22016] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [GD1C22016] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GD1C22016] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GD1C22016] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GD1C22016] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GD1C22016] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GD1C22016] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GD1C22016] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GD1C22016] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GD1C22016] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GD1C22016] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GD1C22016] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GD1C22016] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GD1C22016] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GD1C22016] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GD1C22016] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GD1C22016] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GD1C22016] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GD1C22016] SET  MULTI_USER 
GO
ALTER DATABASE [GD1C22016] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GD1C22016] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GD1C22016] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GD1C22016] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [GD1C22016]
GO
/****** Object:  User [gd]    Script Date: jueves, 19 de mayo de 2016 11:12:54 ******/
CREATE USER [gd] FOR LOGIN [gd] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [gd_esquema]    Script Date: jueves, 19 de mayo de 2016 11:12:54 ******/
CREATE SCHEMA [gd_esquema]
GO
/****** Object:  Schema [LOS_GDDS]    Script Date: jueves, 19 de mayo de 2016 11:12:54 ******/
CREATE SCHEMA [LOS_GDDS]
GO
/****** Object:  Table [dbo].[Funcionalidad]    Script Date: jueves, 19 de mayo de 2016 11:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionalidad](
	[func_nombre] [nvarchar](50) NOT NULL,
	[func_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[func_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: jueves, 19 de mayo de 2016 11:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[rol_nombre] [nvarchar](50) NOT NULL,
	[rol_habilitado] [bit] NULL,
	[rol_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rolfunc]    Script Date: jueves, 19 de mayo de 2016 11:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rolfunc](
	[rolfunc_rol] [int] NOT NULL,
	[rolfunc_func] [int] NOT NULL,
 CONSTRAINT [PK_rolfunc] PRIMARY KEY CLUSTERED 
(
	[rolfunc_rol] ASC,
	[rolfunc_func] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: jueves, 19 de mayo de 2016 11:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuario_name] [nvarchar](20) NOT NULL,
	[usuario_password] [nvarchar](max) NOT NULL,
	[usuario_habilitado] [bit] NULL,
	[usuario_intentos] [int] NULL,
	[usuarios_id] [int] IDENTITY(1,1) NOT NULL,
	[usuario_rol] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuarios_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [gd_esquema].[Maestra]    Script Date: jueves, 19 de mayo de 2016 11:12:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Maestra](
	[Publ_Cli_Dni] [numeric](18, 0) NULL,
	[Publ_Cli_Apeliido] [nvarchar](255) NULL,
	[Publ_Cli_Nombre] [nvarchar](255) NULL,
	[Publ_Cli_Fecha_Nac] [datetime] NULL,
	[Publ_Cli_Mail] [nvarchar](255) NULL,
	[Publ_Cli_Dom_Calle] [nvarchar](255) NULL,
	[Publ_Cli_Nro_Calle] [numeric](18, 0) NULL,
	[Publ_Cli_Piso] [numeric](18, 0) NULL,
	[Publ_Cli_Depto] [nvarchar](50) NULL,
	[Publ_Cli_Cod_Postal] [nvarchar](50) NULL,
	[Publ_Empresa_Razon_Social] [nvarchar](255) NULL,
	[Publ_Empresa_Cuit] [nvarchar](50) NULL,
	[Publ_Empresa_Fecha_Creacion] [datetime] NULL,
	[Publ_Empresa_Mail] [nvarchar](50) NULL,
	[Publ_Empresa_Dom_Calle] [nvarchar](100) NULL,
	[Publ_Empresa_Nro_Calle] [numeric](18, 0) NULL,
	[Publ_Empresa_Piso] [numeric](18, 0) NULL,
	[Publ_Empresa_Depto] [nvarchar](50) NULL,
	[Publ_Empresa_Cod_Postal] [nvarchar](50) NULL,
	[Publicacion_Cod] [numeric](18, 0) NULL,
	[Publicacion_Descripcion] [nvarchar](255) NULL,
	[Publicacion_Stock] [numeric](18, 0) NULL,
	[Publicacion_Fecha] [datetime] NULL,
	[Publicacion_Fecha_Venc] [datetime] NULL,
	[Publicacion_Precio] [numeric](18, 2) NULL,
	[Publicacion_Tipo] [nvarchar](255) NULL,
	[Publicacion_Visibilidad_Cod] [numeric](18, 0) NULL,
	[Publicacion_Visibilidad_Desc] [nvarchar](255) NULL,
	[Publicacion_Visibilidad_Precio] [numeric](18, 2) NULL,
	[Publicacion_Visibilidad_Porcentaje] [numeric](18, 2) NULL,
	[Publicacion_Estado] [nvarchar](255) NULL,
	[Publicacion_Rubro_Descripcion] [nvarchar](255) NULL,
	[Cli_Dni] [numeric](18, 0) NULL,
	[Cli_Apeliido] [nvarchar](255) NULL,
	[Cli_Nombre] [nvarchar](255) NULL,
	[Cli_Fecha_Nac] [datetime] NULL,
	[Cli_Mail] [nvarchar](255) NULL,
	[Cli_Dom_Calle] [nvarchar](255) NULL,
	[Cli_Nro_Calle] [numeric](18, 0) NULL,
	[Cli_Piso] [numeric](18, 0) NULL,
	[Cli_Depto] [nvarchar](50) NULL,
	[Cli_Cod_Postal] [nvarchar](50) NULL,
	[Compra_Fecha] [datetime] NULL,
	[Compra_Cantidad] [numeric](18, 0) NULL,
	[Oferta_Fecha] [datetime] NULL,
	[Oferta_Monto] [numeric](18, 2) NULL,
	[Calificacion_Codigo] [numeric](18, 0) NULL,
	[Calificacion_Cant_Estrellas] [numeric](18, 0) NULL,
	[Calificacion_Descripcion] [nvarchar](255) NULL,
	[Item_Factura_Monto] [numeric](18, 2) NULL,
	[Item_Factura_Cantidad] [numeric](18, 0) NULL,
	[Factura_Nro] [numeric](18, 0) NULL,
	[Factura_Fecha] [datetime] NULL,
	[Factura_Total] [numeric](18, 2) NULL,
	[Forma_Pago_Desc] [nvarchar](255) NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[rolfunc]  WITH CHECK ADD  CONSTRAINT [FK_rolfunc_Funcionalidad] FOREIGN KEY([rolfunc_func])
REFERENCES [dbo].[Funcionalidad] ([func_id])
GO
ALTER TABLE [dbo].[rolfunc] CHECK CONSTRAINT [FK_rolfunc_Funcionalidad]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([usuario_rol])
REFERENCES [dbo].[Rol] ([rol_id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
USE [master]
GO
ALTER DATABASE [GD1C22016] SET  READ_WRITE 
GO
