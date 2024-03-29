USE [master]
GO
/****** Object:  Database [PPAI_IVS_DB]    Script Date: 12/11/2023 16:11:03 ******/
CREATE DATABASE [PPAI_IVS_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PPAI_IVS_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PPAI_IVS_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PPAI_IVS_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PPAI_IVS_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PPAI_IVS_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PPAI_IVS_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PPAI_IVS_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PPAI_IVS_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PPAI_IVS_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PPAI_IVS_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PPAI_IVS_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PPAI_IVS_DB] SET  MULTI_USER 
GO
ALTER DATABASE [PPAI_IVS_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PPAI_IVS_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PPAI_IVS_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PPAI_IVS_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PPAI_IVS_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PPAI_IVS_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PPAI_IVS_DB] SET QUERY_STORE = OFF
GO
USE [PPAI_IVS_DB]
GO
/****** Object:  Table [dbo].[Acciones]    Script Date: 12/11/2023 16:11:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acciones](
	[id_accion] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Acciones] PRIMARY KEY CLUSTERED 
(
	[id_accion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cambios Estado]    Script Date: 12/11/2023 16:11:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cambios Estado](
	[id_llamada] [int] NOT NULL,
	[fecha_hora_inicio] [datetime] NOT NULL,
	[id_estado] [int] NULL,
	[fecha_hora_fin] [datetime] NULL,
 CONSTRAINT [PK_Cambios Estado] PRIMARY KEY CLUSTERED 
(
	[id_llamada] ASC,
	[fecha_hora_inicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 12/11/2023 16:11:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[id_categoria] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[orden] [int] NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 12/11/2023 16:11:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[dni] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[celular] [varchar](50) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 12/11/2023 16:11:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[id_estado] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[id_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Informaciones Clientes]    Script Date: 12/11/2023 16:11:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Informaciones Clientes](
	[dni_cliente] [int] NOT NULL,
	[id_validacion] [int] NOT NULL,
	[dato] [varchar](50) NULL,
 CONSTRAINT [PK_Informaciones Clientes] PRIMARY KEY CLUSTERED 
(
	[dni_cliente] ASC,
	[id_validacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Llamadas]    Script Date: 12/11/2023 16:11:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Llamadas](
	[id_llamada] [int] NOT NULL,
	[dni_cliente] [int] NULL,
	[duracion] [int] NULL,
	[id_accion] [int] NULL,
	[detalle_accion] [varchar](50) NULL,
	[descripcion_operador] [varchar](50) NULL,
	[id_opcion] [int] NULL,
	[id_subopcion] [int] NULL,
 CONSTRAINT [PK_Llamadas] PRIMARY KEY CLUSTERED 
(
	[id_llamada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Opciones]    Script Date: 12/11/2023 16:11:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Opciones](
	[id_opcion] [int] NOT NULL,
	[id_categoria] [int] NULL,
	[nombre] [varchar](50) NULL,
	[orden] [int] NULL,
 CONSTRAINT [PK_Opciones] PRIMARY KEY CLUSTERED 
(
	[id_opcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subopciones]    Script Date: 12/11/2023 16:11:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subopciones](
	[id_subopcion] [int] NOT NULL,
	[id_opcion] [int] NULL,
	[nombre] [varchar](50) NULL,
	[orden] [int] NULL,
 CONSTRAINT [PK_Subopciones] PRIMARY KEY CLUSTERED 
(
	[id_subopcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Validaciones]    Script Date: 12/11/2023 16:11:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Validaciones](
	[id_validacion] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[orden] [int] NULL,
 CONSTRAINT [PK_Validaciones] PRIMARY KEY CLUSTERED 
(
	[id_validacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Validaciones X Opcion]    Script Date: 12/11/2023 16:11:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Validaciones X Opcion](
	[id_opcion] [int] NOT NULL,
	[id_validacion] [int] NOT NULL,
 CONSTRAINT [PK_Validaciones X Opcion] PRIMARY KEY CLUSTERED 
(
	[id_opcion] ASC,
	[id_validacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Validaciones X Subopcion]    Script Date: 12/11/2023 16:11:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Validaciones X Subopcion](
	[id_subopcion] [int] NOT NULL,
	[id_validacion] [int] NOT NULL,
 CONSTRAINT [PK_Validaciones X Subopcion] PRIMARY KEY CLUSTERED 
(
	[id_subopcion] ASC,
	[id_validacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cambios Estado]  WITH CHECK ADD  CONSTRAINT [FK_Cambios Estado_Estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[Estados] ([id_estado])
GO
ALTER TABLE [dbo].[Cambios Estado] CHECK CONSTRAINT [FK_Cambios Estado_Estados]
GO
ALTER TABLE [dbo].[Cambios Estado]  WITH CHECK ADD  CONSTRAINT [FK_Cambios Estado_Llamadas] FOREIGN KEY([id_llamada])
REFERENCES [dbo].[Llamadas] ([id_llamada])
GO
ALTER TABLE [dbo].[Cambios Estado] CHECK CONSTRAINT [FK_Cambios Estado_Llamadas]
GO
ALTER TABLE [dbo].[Informaciones Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Informaciones Clientes_Clientes] FOREIGN KEY([dni_cliente])
REFERENCES [dbo].[Clientes] ([dni])
GO
ALTER TABLE [dbo].[Informaciones Clientes] CHECK CONSTRAINT [FK_Informaciones Clientes_Clientes]
GO
ALTER TABLE [dbo].[Informaciones Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Informaciones Clientes_Validaciones] FOREIGN KEY([id_validacion])
REFERENCES [dbo].[Validaciones] ([id_validacion])
GO
ALTER TABLE [dbo].[Informaciones Clientes] CHECK CONSTRAINT [FK_Informaciones Clientes_Validaciones]
GO
ALTER TABLE [dbo].[Llamadas]  WITH CHECK ADD  CONSTRAINT [FK_Llamadas_Acciones] FOREIGN KEY([id_accion])
REFERENCES [dbo].[Acciones] ([id_accion])
GO
ALTER TABLE [dbo].[Llamadas] CHECK CONSTRAINT [FK_Llamadas_Acciones]
GO
ALTER TABLE [dbo].[Llamadas]  WITH CHECK ADD  CONSTRAINT [FK_Llamadas_Clientes] FOREIGN KEY([dni_cliente])
REFERENCES [dbo].[Clientes] ([dni])
GO
ALTER TABLE [dbo].[Llamadas] CHECK CONSTRAINT [FK_Llamadas_Clientes]
GO
ALTER TABLE [dbo].[Llamadas]  WITH CHECK ADD  CONSTRAINT [FK_Llamadas_Opciones] FOREIGN KEY([id_opcion])
REFERENCES [dbo].[Opciones] ([id_opcion])
GO
ALTER TABLE [dbo].[Llamadas] CHECK CONSTRAINT [FK_Llamadas_Opciones]
GO
ALTER TABLE [dbo].[Llamadas]  WITH CHECK ADD  CONSTRAINT [FK_Llamadas_Subopciones] FOREIGN KEY([id_subopcion])
REFERENCES [dbo].[Subopciones] ([id_subopcion])
GO
ALTER TABLE [dbo].[Llamadas] CHECK CONSTRAINT [FK_Llamadas_Subopciones]
GO
ALTER TABLE [dbo].[Opciones]  WITH CHECK ADD  CONSTRAINT [FK_Opciones_Categorias] FOREIGN KEY([id_categoria])
REFERENCES [dbo].[Categorias] ([id_categoria])
GO
ALTER TABLE [dbo].[Opciones] CHECK CONSTRAINT [FK_Opciones_Categorias]
GO
ALTER TABLE [dbo].[Subopciones]  WITH CHECK ADD  CONSTRAINT [FK_Subopciones_Opciones] FOREIGN KEY([id_opcion])
REFERENCES [dbo].[Opciones] ([id_opcion])
GO
ALTER TABLE [dbo].[Subopciones] CHECK CONSTRAINT [FK_Subopciones_Opciones]
GO
ALTER TABLE [dbo].[Validaciones X Opcion]  WITH CHECK ADD  CONSTRAINT [FK_Validaciones X Opcion_Opciones] FOREIGN KEY([id_opcion])
REFERENCES [dbo].[Opciones] ([id_opcion])
GO
ALTER TABLE [dbo].[Validaciones X Opcion] CHECK CONSTRAINT [FK_Validaciones X Opcion_Opciones]
GO
ALTER TABLE [dbo].[Validaciones X Opcion]  WITH CHECK ADD  CONSTRAINT [FK_Validaciones X Opcion_Validaciones] FOREIGN KEY([id_validacion])
REFERENCES [dbo].[Validaciones] ([id_validacion])
GO
ALTER TABLE [dbo].[Validaciones X Opcion] CHECK CONSTRAINT [FK_Validaciones X Opcion_Validaciones]
GO
ALTER TABLE [dbo].[Validaciones X Subopcion]  WITH CHECK ADD  CONSTRAINT [FK_Validaciones X Subopcion_Subopciones] FOREIGN KEY([id_subopcion])
REFERENCES [dbo].[Subopciones] ([id_subopcion])
GO
ALTER TABLE [dbo].[Validaciones X Subopcion] CHECK CONSTRAINT [FK_Validaciones X Subopcion_Subopciones]
GO
ALTER TABLE [dbo].[Validaciones X Subopcion]  WITH CHECK ADD  CONSTRAINT [FK_Validaciones X Subopcion_Validaciones] FOREIGN KEY([id_validacion])
REFERENCES [dbo].[Validaciones] ([id_validacion])
GO
ALTER TABLE [dbo].[Validaciones X Subopcion] CHECK CONSTRAINT [FK_Validaciones X Subopcion_Validaciones]
GO
USE [master]
GO
ALTER DATABASE [PPAI_IVS_DB] SET  READ_WRITE 
GO
