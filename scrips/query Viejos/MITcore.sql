USE [MITCore]
GO
/****** Object:  User [IET\desarrollo1]    Script Date: 13/10/2020 12:19:11 ******/
CREATE USER [IET\desarrollo1] WITH DEFAULT_SCHEMA=[IET\desarrollo1]
GO
/****** Object:  User [IET\desarrollo2]    Script Date: 13/10/2020 12:19:11 ******/
CREATE USER [IET\desarrollo2] WITH DEFAULT_SCHEMA=[IET\desarrollo2]
GO
/****** Object:  User [NT AUTHORITY\Usuarios autentificados]    Script Date: 13/10/2020 12:19:11 ******/
CREATE USER [NT AUTHORITY\Usuarios autentificados] FOR LOGIN [NT AUTHORITY\Usuarios autentificados]
GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\Usuarios autentificados]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [NT AUTHORITY\Usuarios autentificados]
GO
/****** Object:  Schema [IET\desarrollo1]    Script Date: 13/10/2020 12:19:11 ******/
CREATE SCHEMA [IET\desarrollo1]
GO
/****** Object:  Schema [IET\desarrollo2]    Script Date: 13/10/2020 12:19:11 ******/
CREATE SCHEMA [IET\desarrollo2]
GO
/****** Object:  UserDefinedTableType [dbo].[EliminarUsuarioModuloTem]    Script Date: 13/10/2020 12:19:11 ******/
CREATE TYPE [dbo].[EliminarUsuarioModuloTem] AS TABLE(
	[usMod_Usua] [nvarchar](100) NULL,
	[usMod_modId] [smallint] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[nombreTemp]    Script Date: 13/10/2020 12:19:11 ******/
CREATE TYPE [dbo].[nombreTemp] AS TABLE(
	[usMod_Usua] [nvarchar](100) NULL,
	[usMod_modId] [smallint] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[RespuestasUsuarios]    Script Date: 13/10/2020 12:19:11 ******/
CREATE TYPE [dbo].[RespuestasUsuarios] AS TABLE(
	[res_codUer] [nvarchar](100) NULL,
	[res_codPreg] [int] NULL,
	[res_res] [nvarchar](100) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[RespuestasUsuariosPru]    Script Date: 13/10/2020 12:19:11 ******/
CREATE TYPE [dbo].[RespuestasUsuariosPru] AS TABLE(
	[res_codUer] [nvarchar](100) NULL,
	[res_codPreg] [int] NULL,
	[res_res] [nvarchar](100) NULL,
	[usua_clave] [nvarchar](100) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[RespuestasUsuariosTEM]    Script Date: 13/10/2020 12:19:11 ******/
CREATE TYPE [dbo].[RespuestasUsuariosTEM] AS TABLE(
	[res_codUerT] [nvarchar](100) NULL,
	[res_codPregT] [int] NULL,
	[res_resT] [nvarchar](100) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[UsuarioModuloTEM]    Script Date: 13/10/2020 12:19:11 ******/
CREATE TYPE [dbo].[UsuarioModuloTEM] AS TABLE(
	[usMod_Usua] [nvarchar](100) NOT NULL,
	[usMod_modId] [smallint] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [IET\desarrollo2].[EmpresaMonedaTem]    Script Date: 13/10/2020 12:19:11 ******/
CREATE TYPE [IET\desarrollo2].[EmpresaMonedaTem] AS TABLE(
	[EmpM_codEmp] [int] NOT NULL,
	[EmpM_codMon] [int] NOT NULL
)
GO
/****** Object:  Table [dbo].[Almacen_Sucursal_Empresa]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacen_Sucursal_Empresa](
	[alm_empcod] [int] NOT NULL,
	[alm_succod] [int] NOT NULL,
	[alm_almcod] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Almacenes]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacenes](
	[alm_cod] [int] IDENTITY(1,1) NOT NULL,
	[alm_nombre] [nvarchar](200) NOT NULL,
	[alm_desc] [nvarchar](200) NOT NULL,
	[alm_dir] [nvarchar](200) NOT NULL,
	[alm_contacto] [nvarchar](200) NOT NULL,
	[alm_telef1] [nvarchar](50) NOT NULL,
	[alm_telef2] [nvarchar](50) NOT NULL,
	[alm_fechaCreacion] [nvarchar](100) NOT NULL,
	[alm_eliminado] [int] NOT NULL,
 CONSTRAINT [PK__Almacene__AA9B233C68B77500] PRIMARY KEY CLUSTERED 
(
	[alm_cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[empresa]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empresa](
	[empr_dni] [int] IDENTITY(0,1) NOT NULL,
	[empr_desc] [nvarchar](200) NOT NULL,
	[empr_dir] [nvarchar](300) NOT NULL,
	[empr_rif] [nvarchar](100) NOT NULL,
	[empr_nit] [nvarchar](100) NOT NULL,
	[empr_telef1] [nvarchar](50) NOT NULL,
	[empr_telef2] [nvarchar](50) NOT NULL,
	[empr_email] [nvarchar](100) NOT NULL,
	[empr_web] [nvarchar](100) NOT NULL,
	[empr_Eliminadas] [int] NOT NULL,
	[empr_FechaCreacion] [date] NOT NULL,
	[empr_nombre] [nvarchar](200) NOT NULL,
	[empr_contacto] [nvarchar](200) NOT NULL,
	[empr_nombCorto] [nvarchar](10) NOT NULL,
	[empr_Bd] [nchar](10) NOT NULL,
 CONSTRAINT [PK_empresa] PRIMARY KEY CLUSTERED 
(
	[empr_dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empresa_Sucusal]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa_Sucusal](
	[emp_Cod] [int] NOT NULL,
	[emp_SucCod] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmpresaMoneda]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaMoneda](
	[EmpM_codEmp] [int] NOT NULL,
	[EmpM_codMon] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FactoresConversion]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FactoresConversion](
	[FU_U1] [nvarchar](10) NOT NULL,
	[FU_U2] [nvarchar](10) NOT NULL,
	[FU_Factor] [decimal](28, 11) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FactorLongitud]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FactorLongitud](
	[FU_U1] [nvarchar](10) NOT NULL,
	[FU_U2] [nvarchar](10) NOT NULL,
	[FU_Factor] [decimal](20, 10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FactorMasa]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FactorMasa](
	[FU_U1] [nvarchar](10) NOT NULL,
	[FU_U2] [nvarchar](10) NOT NULL,
	[FU_Factor] [decimal](20, 10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FactorTiempo]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FactorTiempo](
	[FU_U1] [nvarchar](10) NOT NULL,
	[FU_U2] [nvarchar](10) NOT NULL,
	[FU_Factor] [decimal](28, 11) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FactorVolumen]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FactorVolumen](
	[FU_U1] [nvarchar](10) NOT NULL,
	[FU_U2] [nvarchar](10) NOT NULL,
	[FU_Factor] [decimal](20, 10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Modulos]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulos](
	[mod_Id] [smallint] IDENTITY(0,1) NOT NULL,
	[mod_Descripcion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK__Modulos__656687D66CE21169] PRIMARY KEY CLUSTERED 
(
	[mod_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Moneda]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moneda](
	[mon_codID] [int] IDENTITY(0,1) NOT NULL,
	[mon_cod] [nvarchar](10) NOT NULL,
	[mon_Descripcion] [nvarchar](70) NOT NULL,
	[mon_simbolo] [nchar](10) NOT NULL,
	[Eliminar] [int] NOT NULL,
 CONSTRAINT [PK_Moneda] PRIMARY KEY CLUSTERED 
(
	[mon_codID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OpcionesGenerales]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpcionesGenerales](
	[OpcionesGen_Id] [int] IDENTITY(0,1) NOT NULL,
	[OpcionesGen_CodModulo] [int] NOT NULL,
	[OpcionesGen_Nombre] [nvarchar](100) NOT NULL,
	[OpcionesGen_Valor] [nvarchar](100) NOT NULL,
	[OpcionesGen_Configurar] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OpcionesGen_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PreguntasSeguridad]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntasSeguridad](
	[pr_cod] [int] IDENTITY(1,1) NOT NULL,
	[pr_pregunta] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pr_cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productoMit]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productoMit](
	[prdmit_id] [smallint] NOT NULL,
	[prdmit_name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_productoMit] PRIMARY KEY CLUSTERED 
(
	[prdmit_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RespuestasUsuarios]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RespuestasUsuarios](
	[res_codUser] [nvarchar](100) NOT NULL,
	[res_codPreg] [int] NOT NULL,
	[res_resp] [nvarchar](100) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RolesDeUsuario]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesDeUsuario](
	[rol_cod] [int] IDENTITY(1,1) NOT NULL,
	[rol_descrip] [nvarchar](100) NOT NULL,
	[rol_empr_cod] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[rol_cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StatusUser]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StatusUser](
	[st_status] [smallint] IDENTITY(0,1) NOT NULL,
	[st_descripcion] [varchar](100) NOT NULL,
	[st_eliminados] [int] NULL,
 CONSTRAINT [PK_StatusUser] PRIMARY KEY CLUSTERED 
(
	[st_status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sucursales]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursales](
	[suc_cod] [int] IDENTITY(0,1) NOT NULL,
	[suc_descripcion] [nvarchar](100) NOT NULL,
	[suc_dir] [nvarchar](300) NOT NULL,
	[suc_telf1] [nvarchar](50) NOT NULL,
	[suc_telf2] [nvarchar](50) NOT NULL,
	[suc_email] [nvarchar](50) NOT NULL,
	[suc_eliminadas] [int] NOT NULL,
	[suc_fechaCreacion] [date] NOT NULL,
	[suc_nombre] [nvarchar](200) NOT NULL,
	[suc_contacto] [nvarchar](200) NOT NULL,
	[suc_mon] [nvarchar](200) NULL,
 CONSTRAINT [PK__Sucursal__E256D492A1B632B4] PRIMARY KEY CLUSTERED 
(
	[suc_cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnidadDescrip]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadDescrip](
	[UnidDes_codUniEst] [int] NOT NULL,
	[UnidDes_codUni] [nvarchar](10) NOT NULL,
	[UnidDes_Descripcion] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UnidDes_codUni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnidadesEstandar]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadesEstandar](
	[UniEstandar_Cod] [int] IDENTITY(0,1) NOT NULL,
	[UniEstandar_Desc] [nvarchar](100) NOT NULL,
	[UniEstandar_Eliminar] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UniEstandar_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[us_username] [varchar](100) NOT NULL,
	[us_password] [varchar](100) NOT NULL,
	[us_status] [smallint] NOT NULL,
	[us_nombre] [varchar](100) NOT NULL,
	[us_eliminados] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios_principal_sara] PRIMARY KEY CLUSTERED 
(
	[us_username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuariosModulos]    Script Date: 13/10/2020 12:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuariosModulos](
	[usMod_Usua] [varchar](100) NOT NULL,
	[usMod_modId] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[usMod_Usua] ASC,
	[usMod_modId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Almacen_Sucursal_Empresa] ([alm_empcod], [alm_succod], [alm_almcod]) VALUES (1, 0, 2)
GO
INSERT [dbo].[Almacen_Sucursal_Empresa] ([alm_empcod], [alm_succod], [alm_almcod]) VALUES (1, 0, 3)
GO
INSERT [dbo].[Almacen_Sucursal_Empresa] ([alm_empcod], [alm_succod], [alm_almcod]) VALUES (1, 0, 4)
GO
INSERT [dbo].[Almacen_Sucursal_Empresa] ([alm_empcod], [alm_succod], [alm_almcod]) VALUES (1, 1, 5)
GO
SET IDENTITY_INSERT [dbo].[empresa] ON 

GO
INSERT [dbo].[empresa] ([empr_dni], [empr_desc], [empr_dir], [empr_rif], [empr_nit], [empr_telef1], [empr_telef2], [empr_email], [empr_web], [empr_Eliminadas], [empr_FechaCreacion], [empr_nombre], [empr_contacto], [empr_nombCorto], [empr_Bd]) VALUES (1, N'Empresa lider en telecomunicaciones, asosiada por peticion de Gerencia', N'Calle La Castellana, Caracas 1060, Distrito Capital', N'G-1536248P', N'11,338,854-3', N'04128226870', N'04169198412', N'digitelC.A@digitel.com.ve', N'www.digitel.com.ve', 0, CAST(N'2019-07-30' AS Date), N'Corporacion Digitel', N'Jose Alberto Ramos', N'Digitel', N'si        ')
GO
INSERT [dbo].[empresa] ([empr_dni], [empr_desc], [empr_dir], [empr_rif], [empr_nit], [empr_telef1], [empr_telef2], [empr_email], [empr_web], [empr_Eliminadas], [empr_FechaCreacion], [empr_nombre], [empr_contacto], [empr_nombCorto], [empr_Bd]) VALUES (2, N'Empresa lider en telecomunicaciones, asosiada por peticion de Gerencia', N'Ave. Francisco de Miranda., Caracas 1060, Miranda', N'G-1746248w', N'11,118,794-8', N'04128223256', N'20129199332', N'movistarC.A@movistar.com.ve', N'www.movistar.com.ve', 0, CAST(N'2018-02-01' AS Date), N'Corporacion Movistar C.A', N'Cristian Ramon Perez', N'Movistar', N'si        ')
GO
INSERT [dbo].[empresa] ([empr_dni], [empr_desc], [empr_dir], [empr_rif], [empr_nit], [empr_telef1], [empr_telef2], [empr_email], [empr_web], [empr_Eliminadas], [empr_FechaCreacion], [empr_nombre], [empr_contacto], [empr_nombCorto], [empr_Bd]) VALUES (3, N'Banca Institucional Caracas, en revision para acoplar', N'Centro Financiero Provincial, Av. Este 0, San Bernardino, Caracas', N'G-1755118L', N'99,568,791-3', N'(0212) 504-6834', N'(0212) 504-6834', N'Provincial@Provincial.com.ve', N'www.Provincial.com.ve', 0, CAST(N'2019-06-30' AS Date), N'BBVA Provincial, Banca Institucional Caracas', N'Leonardo Jose Martinez', N'Provincial', N'no        ')
GO
INSERT [dbo].[empresa] ([empr_dni], [empr_desc], [empr_dir], [empr_rif], [empr_nit], [empr_telef1], [empr_telef2], [empr_email], [empr_web], [empr_Eliminadas], [empr_FechaCreacion], [empr_nombre], [empr_contacto], [empr_nombCorto], [empr_Bd]) VALUES (4, N'Integrador de Soluciones para Centros de Contacto que ofrece una infraestructura completamente acondicionada', N'Centro Empresarial Don Bosco, Oficina 4C. Los Cortijos, Caracas Venezuela', N'J123456789', N'11,338,854-3', N'0212 208-58-11', N'0212 208-58-88', N'rrhh@tecno-red.com.ve', N'http://www.tecno-red.com.ve/website/', 0, CAST(N'2019-08-21' AS Date), N'TECNO RED Soluciones 14 C.A', N'Recursos Humanos', N'tecnoRed', N'si        ')
GO
INSERT [dbo].[empresa] ([empr_dni], [empr_desc], [empr_dir], [empr_rif], [empr_nit], [empr_telef1], [empr_telef2], [empr_email], [empr_web], [empr_Eliminadas], [empr_FechaCreacion], [empr_nombre], [empr_contacto], [empr_nombCorto], [empr_Bd]) VALUES (7, N'Distribuidores de Alimentos, Productos Alimenticios,', N'4ta. Transv., Centro Empresarial Polar, Los Cortijos de Lourdes, Caracas', N'Rif: J-00006372-9', N'000063729', N'04123655981', N'04128336598', N'empresaspolar@polar.com', N'http://empresaspolar.com/', 0, CAST(N'2019-09-06' AS Date), N'Empresas Polar', N'Andres Jose Blanco', N'Polar', N'no        ')
GO
INSERT [dbo].[empresa] ([empr_dni], [empr_desc], [empr_dir], [empr_rif], [empr_nit], [empr_telef1], [empr_telef2], [empr_email], [empr_web], [empr_Eliminadas], [empr_FechaCreacion], [empr_nombre], [empr_contacto], [empr_nombCorto], [empr_Bd]) VALUES (11, N'Empresa multinacional suiza ', N'Calle Altagracia, Edificio P&G, Piso 3, Urbanización Sorokaima, Sector La Trinidad.', N'Rif: G-00001524-2', N'99,568,791-3', N'04128223256', N'0212 208-58-88', N' talentonestle@ve.nestle.com', N'https://www.nestle.com.ve
', 0, CAST(N'2019-09-06' AS Date), N'Nestlé', N'Jose Florez', N'Nestle', N'no        ')
GO
SET IDENTITY_INSERT [dbo].[empresa] OFF
GO
INSERT [dbo].[Empresa_Sucusal] ([emp_Cod], [emp_SucCod]) VALUES (1, 4)
GO
INSERT [dbo].[Empresa_Sucusal] ([emp_Cod], [emp_SucCod]) VALUES (1, 0)
GO
INSERT [dbo].[Empresa_Sucusal] ([emp_Cod], [emp_SucCod]) VALUES (1, 1)
GO
INSERT [dbo].[Empresa_Sucusal] ([emp_Cod], [emp_SucCod]) VALUES (2, 3)
GO
INSERT [dbo].[Empresa_Sucusal] ([emp_Cod], [emp_SucCod]) VALUES (2, 18)
GO
INSERT [dbo].[Empresa_Sucusal] ([emp_Cod], [emp_SucCod]) VALUES (1, 19)
GO
INSERT [dbo].[Empresa_Sucusal] ([emp_Cod], [emp_SucCod]) VALUES (1, 20)
GO
INSERT [dbo].[Empresa_Sucusal] ([emp_Cod], [emp_SucCod]) VALUES (1, 21)
GO
INSERT [dbo].[Empresa_Sucusal] ([emp_Cod], [emp_SucCod]) VALUES (2, 2)
GO
INSERT [dbo].[EmpresaMoneda] ([EmpM_codEmp], [EmpM_codMon]) VALUES (1, 0)
GO
INSERT [dbo].[EmpresaMoneda] ([EmpM_codEmp], [EmpM_codMon]) VALUES (3, 5)
GO
INSERT [dbo].[EmpresaMoneda] ([EmpM_codEmp], [EmpM_codMon]) VALUES (4, 3)
GO
INSERT [dbo].[EmpresaMoneda] ([EmpM_codEmp], [EmpM_codMon]) VALUES (1, 3)
GO
INSERT [dbo].[EmpresaMoneda] ([EmpM_codEmp], [EmpM_codMon]) VALUES (11, 2)
GO
INSERT [dbo].[EmpresaMoneda] ([EmpM_codEmp], [EmpM_codMon]) VALUES (11, 3)
GO
INSERT [dbo].[EmpresaMoneda] ([EmpM_codEmp], [EmpM_codMon]) VALUES (1, 4)
GO
INSERT [dbo].[EmpresaMoneda] ([EmpM_codEmp], [EmpM_codMon]) VALUES (1, 3)
GO
INSERT [dbo].[EmpresaMoneda] ([EmpM_codEmp], [EmpM_codMon]) VALUES (1, 5)
GO
INSERT [dbo].[EmpresaMoneda] ([EmpM_codEmp], [EmpM_codMon]) VALUES (1, 2)
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'kg', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'hg', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'dag', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'g', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'dg', CAST(10000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'cg', CAST(100000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'mg', CAST(1000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'lb', CAST(2.20462000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'tn', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'kg', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'hg', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'dag', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'g', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'dg', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'cg', CAST(10000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'mg', CAST(100000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'lb', CAST(0.22046200000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'tn', CAST(0.00010000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'kg', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'hg', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'dag', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'g', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'dg', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'cg', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'mg', CAST(10000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'lb', CAST(0.02204620000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'tn', CAST(0.00001000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'kg', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'hg', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'dag', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'g', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'dg', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'cg', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'mg', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'lb', CAST(0.00220462000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'tn', CAST(0.00000100000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'kg', CAST(0.00010000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'hg', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'dag', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'g', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'dg', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'cg', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'mg', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'lb', CAST(0.00022046200 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'tn', CAST(0.00000010000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'kg', CAST(0.00001000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'hg', CAST(0.00010000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'dag', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'g', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'dg', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'cg', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'mg', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'lb', CAST(0.00002204620 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'tn', CAST(0.00000001000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'kg', CAST(0.00000100000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'hg', CAST(0.00001000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'dag', CAST(0.00010000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'g', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'dg', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'cg', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'mg', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'lb', CAST(0.00000220460 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'tn', CAST(0.00000000010 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'kg', CAST(0.45359200000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'hg', CAST(4.53592000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'dag', CAST(45.35920000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'g', CAST(453.59200000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'dg', CAST(4535.92000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'cg', CAST(45359.20000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'mg', CAST(453592.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'lb', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'tn', CAST(0.00045359200 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'kg', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'hg', CAST(10000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'dag', CAST(100000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'g', CAST(1000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'dg', CAST(10000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'cg', CAST(100000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'mg', CAST(1000000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'lb', CAST(2204.62000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'tn', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kl', N'kl', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kl', N'hl', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kl', N'dal', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kl', N'l', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kl', N'dl', CAST(10000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kl', N'cl', CAST(100000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kl', N'ml', CAST(1000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hl', N'kl', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hl', N'hl', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hl', N'dal', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hl', N'l', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hl', N'dl', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hl', N'cl', CAST(10000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hl', N'ml', CAST(100000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dal', N'kl', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dal', N'hl', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dal', N'dal', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dal', N'l', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dal', N'dl', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dal', N'cl', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dal', N'ml', CAST(10000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'kl', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'hl', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'dal', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'l', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'dl', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'cl', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'ml', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dl', N'kl', CAST(0.00010000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dl', N'hl', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dl', N'dal', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dl', N'l', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dl', N'dl', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dl', N'cl', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dl', N'ml', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cl', N'kl', CAST(0.00001000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cl', N'hl', CAST(0.00010000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cl', N'dal', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cl', N'l', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cl', N'dl', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cl', N'cl', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cl', N'ml', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ml', N'kl', CAST(0.00000100000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ml', N'hl', CAST(0.00001000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ml', N'dal', CAST(0.00010000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ml', N'l', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ml', N'dl', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ml', N'cl', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ml', N'ml', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'km', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'hm', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'dam', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'm', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'dm', CAST(10000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'cm', CAST(100000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'mm', CAST(1000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'yd', CAST(1093.61000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'ft', CAST(3280.84000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'in', CAST(39370.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'km', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'hm', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'dam', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'm', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'dm', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'cm', CAST(10000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'mm', CAST(100000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'yd', CAST(109.36100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'ft', CAST(328.08400000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'in', CAST(3937.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'km', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'hm', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'dam', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'm', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'dm', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'cm', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'mm', CAST(10000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'yd', CAST(10.93610000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'ft', CAST(32.80840000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'in', CAST(393.70100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'km', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'hm', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'dam', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'm', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'dm', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'cm', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'mm', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'yd', CAST(1.09361000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'ft', CAST(3.28084000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'in', CAST(39.37010000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'km', CAST(0.00010000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'hm', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'dam', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'm', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'dm', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'cm', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'mm', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'yd', CAST(0.10936100000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'ft', CAST(0.32808400000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'in', CAST(3.93701000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'km', CAST(0.00001000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'hm', CAST(0.00010000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'dam', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'm', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'dm', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'cm', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'mm', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'yd', CAST(0.01093610000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'ft', CAST(0.03280840000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'in', CAST(0.39370100000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'km', CAST(0.00000100000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'hm', CAST(0.00001000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'dam', CAST(0.00010000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'm', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'dm', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'cm', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'mm', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'yd', CAST(0.00109361000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'ft', CAST(0.00328084000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'in', CAST(0.03937010000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'km', CAST(0.00091440000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'hm', CAST(0.00914400000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'dam', CAST(0.09144000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'm', CAST(0.91440000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'dm', CAST(9.14400000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'cm', CAST(91.44000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'mm', CAST(914.40000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'yd', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'ft', CAST(3.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'in', CAST(36.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'km', CAST(0.00030480000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'hm', CAST(0.00304800000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'dam', CAST(0.03048000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'm', CAST(0.30480000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'dm', CAST(3.04800000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'cm', CAST(30.48000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'mm', CAST(304.80000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'yd', CAST(0.33333300000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'ft', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'in', CAST(12.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'km', CAST(0.00002540000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'hm', CAST(0.00025400000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'dam', CAST(0.00254000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'm', CAST(0.02540000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'dm', CAST(0.25400000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'cm', CAST(2.54000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'mm', CAST(25.40000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'yd', CAST(0.02777780000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'ft', CAST(0.08333330000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'in', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'ms', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'seg', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'min', CAST(0.00001666700 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'hr', CAST(0.00000027778 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'd', CAST(0.00000001157 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'sem', CAST(0.00000000165 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'quin', CAST(0.00000000083 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'mes', CAST(0.00000000038 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'trim', CAST(0.00000000114 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'a', CAST(0.00000000003 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'lus', CAST(0.00000000016 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'dec', CAST(0.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'sig', CAST(0.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'ms', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'seg', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'min', CAST(0.01666670000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'hr', CAST(0.00027777800 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'd', CAST(0.00001157400 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'sem', CAST(0.00000165340 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'quin', CAST(0.00000082672 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'mes', CAST(0.00000038052 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'trim', CAST(0.00000114156 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'a', CAST(0.00000003171 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'lus', CAST(0.00000015855 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'dec', CAST(0.00000000317 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'sig', CAST(0.00000000032 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'ms', CAST(60000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'seg', CAST(60.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'min', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'hr', CAST(0.01666670000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'd', CAST(0.00069444400 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'sem', CAST(0.00009920600 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'quin', CAST(0.00004960300 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'mes', CAST(0.00002283100 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'trim', CAST(0.00006849300 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'a', CAST(0.00000190260 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'lus', CAST(0.00000951300 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'dec', CAST(0.00000019026 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'sig', CAST(0.00000001903 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'ms', CAST(36000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'seg', CAST(3600.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'min', CAST(60.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'hr', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'd', CAST(0.04166670000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'sem', CAST(0.00595238000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'quin', CAST(0.00297619000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'mes', CAST(0.00136986000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'trim', CAST(0.00410958000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'a', CAST(0.00011415500 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'lus', CAST(0.00057077500 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'dec', CAST(0.00001141600 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'sig', CAST(0.00000114160 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'ms', CAST(86400000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'seg', CAST(86400.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'min', CAST(1440.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'hr', CAST(24.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'd', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'sem', CAST(0.14285700000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'quin', CAST(0.04142860000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'mes', CAST(0.03287670000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'trim', CAST(0.09863010000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'a', CAST(0.00273973000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'lus', CAST(0.01369865000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'dec', CAST(0.00027397300 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N's', CAST(0.00002739700 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'ms', CAST(604800000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'seg', CAST(604800.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'min', CAST(10080.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'hr', CAST(168.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'd', CAST(7.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'sem', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'quin', CAST(0.50000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'mes', CAST(0.23013700000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'trim', CAST(0.69041100000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'a', CAST(0.01917810000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'lus', CAST(0.09589050000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'dec', CAST(0.00191781000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'sig', CAST(0.00019178100 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'ms', CAST(1210000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'seg', CAST(1210000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'min', CAST(20160.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'hr', CAST(336.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'd', CAST(14.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'sem', CAST(2.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'quin', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'mes', CAST(0.46027300000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'trim', CAST(1.38081900000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'a', CAST(0.03835620000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'l', CAST(0.19178100000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'dec', CAST(0.00383562000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'sig', CAST(0.00038356200 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'ms', CAST(2628000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'seg', CAST(2628000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'min', CAST(43800.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'hr', CAST(730.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'd', CAST(30.41670000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'sem', CAST(4.34524000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'quin', CAST(2.17262000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'mes', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'trim', CAST(0.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'a', CAST(0.08333340000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'l', CAST(0.01666670000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'dec', CAST(0.00833334000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'sig', CAST(0.00083333400 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'ms', CAST(7884000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'seg', CAST(7884000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'min', CAST(131400.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'hr', CAST(2190.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'd', CAST(91.25010000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'sem', CAST(13.03570000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'quin', CAST(6.51786000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'mes', CAST(3.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'trim', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'a', CAST(0.25000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'l', CAST(1.25000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'dec', CAST(0.02500000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'sig', CAST(0.00250000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'ms', CAST(31540000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'seg', CAST(31540000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'min', CAST(525600.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'hr', CAST(8760.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'd', CAST(365.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'sem', CAST(52.14290000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'quin', CAST(26.07140000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'mes', CAST(12.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'trim', CAST(0.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'a', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'l', CAST(0.20000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'dec', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'sig', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'ms', CAST(157700000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'seg', CAST(157700000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'min', CAST(2628000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'hr', CAST(43800.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'd', CAST(1825.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'sem', CAST(260.71400000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'quin', CAST(130.35700000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'mes', CAST(59.99990000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'trim', CAST(0.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'a', CAST(5.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'l', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'dec', CAST(0.50000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'sig', CAST(0.05000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'ms', CAST(315400000000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'seg', CAST(315400000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'min', CAST(5256000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'hr', CAST(87600.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'd', CAST(3650.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'sem', CAST(521.42900000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'quin', CAST(260.71400000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'mes', CAST(120.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'trim', CAST(0.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'a', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'l', CAST(2.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'dec', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'sig', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'ms', CAST(3154000000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'seg', CAST(3154000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'min', CAST(52560000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'hr', CAST(876000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'd', CAST(36500.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'sem', CAST(5214.29000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'quin', CAST(2607.14000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'mes', CAST(1200.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'trim', CAST(0.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'a', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'l', CAST(20.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'dec', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactoresConversion] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'sig', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'km', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'hm', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'dam', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'm', CAST(1000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'dm', CAST(10000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'cm', CAST(100000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'mm', CAST(1000000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'yd', CAST(1093.6100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'ft', CAST(3280.8400000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'km', N'in', CAST(39370.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'km', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'hm', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'dam', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'm', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'dm', CAST(1000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'cm', CAST(10000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'mm', CAST(100000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'yd', CAST(109.3610000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'ft', CAST(328.0840000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hm', N'in', CAST(3937.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'km', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'hm', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'dam', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'm', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'dm', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'cm', CAST(1000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'mm', CAST(10000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'yd', CAST(10.9361000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'ft', CAST(32.8084000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dam', N'in', CAST(393.7010000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'km', CAST(0.0010000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'hm', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'dam', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'm', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'dm', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'cm', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'mm', CAST(1000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'yd', CAST(1.0936100000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'ft', CAST(3.2808400000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'm', N'in', CAST(39.3701000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'km', CAST(0.0001000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'hm', CAST(0.0010000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'dam', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'm', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'dm', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'cm', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'mm', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'yd', CAST(0.1093610000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'ft', CAST(0.3280840000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dm', N'in', CAST(3.9370100000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'km', CAST(0.0000100000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'hm', CAST(0.0001000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'dam', CAST(0.0010000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'm', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'dm', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'cm', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'mm', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'yd', CAST(0.0109361000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'ft', CAST(0.0328084000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cm', N'in', CAST(0.3937010000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'km', CAST(0.0000010000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'hm', CAST(0.0000100000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'dam', CAST(0.0001000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'm', CAST(0.0010000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'dm', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'cm', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'mm', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'yd', CAST(0.0010936100 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'ft', CAST(0.0032808400 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mm', N'in', CAST(0.0393701000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'km', CAST(0.0009144000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'hm', CAST(0.0091440000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'dam', CAST(0.0914400000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'm', CAST(0.9144000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'dm', CAST(9.1440000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'cm', CAST(91.4400000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'mm', CAST(914.4000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'yd', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'ft', CAST(3.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'yd', N'in', CAST(36.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'km', CAST(0.0003048000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'hm', CAST(0.0030480000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'dam', CAST(0.0304800000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'm', CAST(0.3048000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'dm', CAST(3.0480000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'cm', CAST(30.4800000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'mm', CAST(304.8000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'yd', CAST(0.3333330000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'ft', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ft', N'in', CAST(12.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'km', CAST(0.0000254000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'hm', CAST(0.0002540000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'dam', CAST(0.0025400000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'm', CAST(0.0254000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'dm', CAST(0.2540000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'cm', CAST(2.5400000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'mm', CAST(25.4000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'yd', CAST(0.0277778000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'ft', CAST(0.0833333000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorLongitud] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'in', N'in', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'kg', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'hg', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'dag', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'g', CAST(1000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'dg', CAST(10000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'cg', CAST(100000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'mg', CAST(1000000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'lb', CAST(2.2046200000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kg', N'tn', CAST(0.0010000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'kg', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'hg', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'dag', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'g', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'dg', CAST(1000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'cg', CAST(10000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'mg', CAST(100000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'lb', CAST(0.2204620000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hg', N'tn', CAST(0.0001000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'kg', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'hg', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'dag', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'g', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'dg', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'cg', CAST(1000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'mg', CAST(10000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'lb', CAST(0.0220462000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dag', N'tn', CAST(0.0000100000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'kg', CAST(0.0010000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'hg', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'dag', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'g', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'dg', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'cg', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'mg', CAST(1000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'lb', CAST(0.0022046200 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'g', N'tn', CAST(0.0000010000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'kg', CAST(0.0001000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'hg', CAST(0.0010000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'dag', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'g', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'dg', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'cg', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'mg', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'lb', CAST(0.0002204620 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dg', N'tn', CAST(0.0000001000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'kg', CAST(0.0000100000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'hg', CAST(0.0001000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'dag', CAST(0.0010000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'g', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'dg', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'cg', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'mg', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'lb', CAST(0.0000220462 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cg', N'tn', CAST(0.0000000100 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'kg', CAST(0.0000010000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'hg', CAST(0.0000100000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'dag', CAST(0.0001000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'g', CAST(0.0010000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'dg', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'cg', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'mg', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'lb', CAST(0.0000022046 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mg', N'tn', CAST(0.0000000001 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'kg', CAST(0.4535920000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'hg', CAST(4.5359200000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'dag', CAST(45.3592000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'g', CAST(453.5920000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'dg', CAST(4535.9200000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'cg', CAST(45359.2000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'mg', CAST(453592.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'lb', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'lb', N'tn', CAST(0.0004535920 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'kg', CAST(1000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'hg', CAST(10000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'dag', CAST(100000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'g', CAST(1000000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'dg', CAST(10000000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'cg', CAST(100000000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'mg', CAST(1000000000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'lb', CAST(2204.6200000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorMasa] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'tn', N'tn', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'ms', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'seg', CAST(0.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'min', CAST(0.00001666700 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'hr', CAST(0.00000027778 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'd', CAST(0.00000001157 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'sem', CAST(0.00000000165 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'quin', CAST(0.00000000083 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'mes', CAST(0.00000000038 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'trim', CAST(0.00000000114 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'a', CAST(0.00000000003 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'lus', CAST(0.00000000016 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'dec', CAST(0.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ms', N'sig', CAST(0.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'ms', CAST(1000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'seg', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'min', CAST(0.01666670000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'hr', CAST(0.00027777800 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'd', CAST(0.00001157400 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'sem', CAST(0.00000165340 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'quin', CAST(0.00000082672 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'mes', CAST(0.00000038052 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'trim', CAST(0.00000114156 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'a', CAST(0.00000003171 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'lus', CAST(0.00000015855 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'dec', CAST(0.00000000317 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'seg', N'sig', CAST(0.00000000032 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'ms', CAST(60000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'seg', CAST(60.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'min', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'hr', CAST(0.01666670000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'd', CAST(0.00069444400 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'sem', CAST(0.00009920600 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'quin', CAST(0.00004960300 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'mes', CAST(0.00002283100 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'trim', CAST(0.00006849300 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'a', CAST(0.00000190260 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'lus', CAST(0.00000951300 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'dec', CAST(0.00000019026 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'min', N'sig', CAST(0.00000001903 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'ms', CAST(36000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'seg', CAST(3600.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'min', CAST(60.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'hr', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'd', CAST(0.04166670000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'sem', CAST(0.00595238000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'quin', CAST(0.00297619000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'mes', CAST(0.00136986000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'trim', CAST(0.00410958000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'a', CAST(0.00011415500 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'lus', CAST(0.00057077500 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'dec', CAST(0.00001141600 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hr', N'sig', CAST(0.00000114160 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'ms', CAST(86400000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'seg', CAST(86400.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'min', CAST(1440.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'hr', CAST(24.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'd', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'sem', CAST(0.14285700000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'quin', CAST(0.04142860000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'mes', CAST(0.03287670000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'trim', CAST(0.09863010000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'a', CAST(0.00273973000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'lus', CAST(0.01369865000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N'dec', CAST(0.00027397300 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'd', N's', CAST(0.00002739700 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'ms', CAST(604800000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'seg', CAST(604800.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'min', CAST(10080.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'hr', CAST(168.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'd', CAST(7.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'sem', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'quin', CAST(0.50000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'mes', CAST(0.23013700000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'trim', CAST(0.69041100000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'a', CAST(0.01917810000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'lus', CAST(0.09589050000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'dec', CAST(0.00191781000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sem', N'sig', CAST(0.00019178100 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'ms', CAST(1210000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'seg', CAST(1210000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'min', CAST(20160.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'hr', CAST(336.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'd', CAST(14.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'sem', CAST(2.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'quin', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'mes', CAST(0.46027300000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'trim', CAST(1.38081900000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'a', CAST(0.03835620000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'l', CAST(0.19178100000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'dec', CAST(0.00383562000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'quin', N'sig', CAST(0.00038356200 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'ms', CAST(2628000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'seg', CAST(2628000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'min', CAST(43800.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'hr', CAST(730.00100000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'd', CAST(30.41670000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'sem', CAST(4.34524000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'quin', CAST(2.17262000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'mes', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'trim', CAST(0.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'a', CAST(0.08333340000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'l', CAST(0.01666670000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'dec', CAST(0.00833334000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'mes', N'sig', CAST(0.00083333400 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'ms', CAST(7884000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'seg', CAST(7884000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'min', CAST(131400.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'hr', CAST(2190.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'd', CAST(91.25010000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'sem', CAST(13.03570000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'quin', CAST(6.51786000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'mes', CAST(3.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'trim', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'a', CAST(0.25000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'l', CAST(1.25000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'dec', CAST(0.02500000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'trim', N'sig', CAST(0.00250000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'ms', CAST(31540000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'seg', CAST(31540000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'min', CAST(525600.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'hr', CAST(8760.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'd', CAST(365.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'sem', CAST(52.14290000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'quin', CAST(26.07140000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'mes', CAST(12.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'trim', CAST(0.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'a', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'l', CAST(0.20000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'dec', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'a', N'sig', CAST(0.01000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'ms', CAST(157700000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'seg', CAST(157700000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'min', CAST(2628000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'hr', CAST(43800.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'd', CAST(1825.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'sem', CAST(260.71400000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'quin', CAST(130.35700000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'mes', CAST(59.99990000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'trim', CAST(0.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'a', CAST(5.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'l', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'dec', CAST(0.50000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'sig', CAST(0.05000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'ms', CAST(315400000000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'seg', CAST(315400000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'min', CAST(5256000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'hr', CAST(87600.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'd', CAST(3650.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'sem', CAST(521.42900000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'quin', CAST(260.71400000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'mes', CAST(120.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'trim', CAST(0.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'a', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'l', CAST(2.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'dec', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dec', N'sig', CAST(0.10000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'ms', CAST(3154000000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'seg', CAST(3154000000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'min', CAST(52560000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'hr', CAST(876000.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'd', CAST(36500.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'sem', CAST(5214.29000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'quin', CAST(2607.14000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'mes', CAST(1200.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'trim', CAST(0.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'a', CAST(100.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'l', CAST(20.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'dec', CAST(10.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorTiempo] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'sig', N'sig', CAST(1.00000000000 AS Decimal(28, 11)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kl', N'kl', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kl', N'hl', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kl', N'dal', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kl', N'l', CAST(1000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kl', N'dl', CAST(10000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kl', N'cl', CAST(100000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'kl', N'ml', CAST(1000000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hl', N'kl', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hl', N'hl', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hl', N'dal', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hl', N'l', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hl', N'dl', CAST(1000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hl', N'cl', CAST(10000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'hl', N'ml', CAST(100000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dal', N'kl', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dal', N'hl', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dal', N'dal', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dal', N'l', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dal', N'dl', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dal', N'cl', CAST(1000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dal', N'ml', CAST(10000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'kl', CAST(0.0010000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'hl', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'dal', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'l', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'dl', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'cl', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'l', N'ml', CAST(1000.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dl', N'kl', CAST(0.0001000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dl', N'hl', CAST(0.0010000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dl', N'dal', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dl', N'l', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dl', N'dl', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dl', N'cl', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'dl', N'ml', CAST(100.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cl', N'kl', CAST(0.0000100000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cl', N'hl', CAST(0.0001000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cl', N'dal', CAST(0.0010000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cl', N'l', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cl', N'dl', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cl', N'cl', CAST(1.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'cl', N'ml', CAST(10.0000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ml', N'kl', CAST(0.0000010000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ml', N'hl', CAST(0.0000100000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ml', N'dal', CAST(0.0001000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ml', N'l', CAST(0.0010000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ml', N'dl', CAST(0.0100000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ml', N'cl', CAST(0.1000000000 AS Decimal(20, 10)))
GO
INSERT [dbo].[FactorVolumen] ([FU_U1], [FU_U2], [FU_Factor]) VALUES (N'ml', N'ml', CAST(1.0000000000 AS Decimal(20, 10)))
GO
SET IDENTITY_INSERT [dbo].[Modulos] ON 

GO
INSERT [dbo].[Modulos] ([mod_Id], [mod_Descripcion]) VALUES (0, N'Administracion')
GO
INSERT [dbo].[Modulos] ([mod_Id], [mod_Descripcion]) VALUES (1, N'Produccion')
GO
INSERT [dbo].[Modulos] ([mod_Id], [mod_Descripcion]) VALUES (2, N'Contabilidad')
GO
INSERT [dbo].[Modulos] ([mod_Id], [mod_Descripcion]) VALUES (3, N'Tesoreria')
GO
INSERT [dbo].[Modulos] ([mod_Id], [mod_Descripcion]) VALUES (4, N'Compras EDITADO')
GO
INSERT [dbo].[Modulos] ([mod_Id], [mod_Descripcion]) VALUES (101, N'prueba')
GO
INSERT [dbo].[Modulos] ([mod_Id], [mod_Descripcion]) VALUES (103, N'Opciones Generales')
GO
SET IDENTITY_INSERT [dbo].[Modulos] OFF
GO
SET IDENTITY_INSERT [dbo].[Moneda] ON 

GO
INSERT [dbo].[Moneda] ([mon_codID], [mon_cod], [mon_Descripcion], [mon_simbolo], [Eliminar]) VALUES (0, N'CNY', N'Yuan Chino', N'¥         ', 0)
GO
INSERT [dbo].[Moneda] ([mon_codID], [mon_cod], [mon_Descripcion], [mon_simbolo], [Eliminar]) VALUES (1, N'EUR', N'Euro', N'€         ', 0)
GO
INSERT [dbo].[Moneda] ([mon_codID], [mon_cod], [mon_Descripcion], [mon_simbolo], [Eliminar]) VALUES (2, N'JPY', N'Yen', N'¥         ', 0)
GO
INSERT [dbo].[Moneda] ([mon_codID], [mon_cod], [mon_Descripcion], [mon_simbolo], [Eliminar]) VALUES (3, N'RUB', N'Rublo Ruso', N'₽         ', 0)
GO
INSERT [dbo].[Moneda] ([mon_codID], [mon_cod], [mon_Descripcion], [mon_simbolo], [Eliminar]) VALUES (4, N'USD', N'Dolar estadounidence', N'$         ', 0)
GO
INSERT [dbo].[Moneda] ([mon_codID], [mon_cod], [mon_Descripcion], [mon_simbolo], [Eliminar]) VALUES (5, N'VEF', N'Bolivares', N'bs        ', 0)
GO
INSERT [dbo].[Moneda] ([mon_codID], [mon_cod], [mon_Descripcion], [mon_simbolo], [Eliminar]) VALUES (12, N'dzxvxcv', N'edit', N'm         ', 1)
GO
INSERT [dbo].[Moneda] ([mon_codID], [mon_cod], [mon_Descripcion], [mon_simbolo], [Eliminar]) VALUES (13, N'ghuj³', N'kjgk', N'hjgj      ', 1)
GO
SET IDENTITY_INSERT [dbo].[Moneda] OFF
GO
SET IDENTITY_INSERT [dbo].[OpcionesGenerales] ON 

GO
INSERT [dbo].[OpcionesGenerales] ([OpcionesGen_Id], [OpcionesGen_CodModulo], [OpcionesGen_Nombre], [OpcionesGen_Valor], [OpcionesGen_Configurar]) VALUES (0, 103, N'Configurar Decimales', N'Coma (,)', 1)
GO
INSERT [dbo].[OpcionesGenerales] ([OpcionesGen_Id], [OpcionesGen_CodModulo], [OpcionesGen_Nombre], [OpcionesGen_Valor], [OpcionesGen_Configurar]) VALUES (1, 103, N'Configurar Nro. de Decimales', N'Coma (,)', 1)
GO
INSERT [dbo].[OpcionesGenerales] ([OpcionesGen_Id], [OpcionesGen_CodModulo], [OpcionesGen_Nombre], [OpcionesGen_Valor], [OpcionesGen_Configurar]) VALUES (2, 103, N'Configuracion IVA', N'Coma (,)', 1)
GO
INSERT [dbo].[OpcionesGenerales] ([OpcionesGen_Id], [OpcionesGen_CodModulo], [OpcionesGen_Nombre], [OpcionesGen_Valor], [OpcionesGen_Configurar]) VALUES (4, 103, N'Cambiar Temas del Sistema', N'Coma (,)', 1)
GO
SET IDENTITY_INSERT [dbo].[OpcionesGenerales] OFF
GO
SET IDENTITY_INSERT [dbo].[PreguntasSeguridad] ON 

GO
INSERT [dbo].[PreguntasSeguridad] ([pr_cod], [pr_pregunta]) VALUES (1, N'¿Cual es su color favorito?')
GO
INSERT [dbo].[PreguntasSeguridad] ([pr_cod], [pr_pregunta]) VALUES (2, N'¿Cual es el nombre de su primera mascota?')
GO
INSERT [dbo].[PreguntasSeguridad] ([pr_cod], [pr_pregunta]) VALUES (3, N'¿Cual es su lugar de nacimiento?')
GO
INSERT [dbo].[PreguntasSeguridad] ([pr_cod], [pr_pregunta]) VALUES (4, N'¿Cual es el nombre de su madre?')
GO
SET IDENTITY_INSERT [dbo].[PreguntasSeguridad] OFF
GO
INSERT [dbo].[productoMit] ([prdmit_id], [prdmit_name]) VALUES (1, N'gjku')
GO
INSERT [dbo].[productoMit] ([prdmit_id], [prdmit_name]) VALUES (2, N'hgj')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'squintero', 1, N'azul')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'squintero', 2, N'luna')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'squintero', 3, N'trujillo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'squintero', 4, N'olida')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aavila', 1, N'fucsia')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aavila', 2, N'guardia')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aavila', 3, N'ssan lazaro')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aavila', 4, N'erminda')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'vrodriguez', 1, N'morado')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'vrodriguez', 2, N'hunter')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'vrodriguez', 3, N'san felipe')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'vrodriguez', 4, N'norys')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'gtoro', 1, N'negro')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'gtoro', 2, N'campana')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'gtoro', 3, N'san lazaro')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'gtoro', 4, N'negra')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aprado', 1, N'rosado')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aprado', 2, N'mozart')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aprado', 3, N'coro')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aprado', 4, N'yolanda')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'ealvarez', 1, N'red')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'ealvarez', 2, N'luna')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'ealvarez', 3, N'trujillo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'ealvarez', 4, N'olida')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'egalvis', 1, N'rojo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'egalvis', 2, N'luna')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'egalvis', 3, N'trujillo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'egalvis', 4, N'olida')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'ktoro', 1, N'rojo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'ktoro', 2, N'luna')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'ktoro', 3, N'trujillo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'ktoro', 4, N'olida')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aramos', 1, N'rojo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aramos', 2, N'luna')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aramos', 3, N'trujillo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aramos', 4, N'olida')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'hperez', 1, N'verde')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'hperez', 2, N'coco')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'hperez', 3, N'merida')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'hperez', 4, N'anastasia')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'lbello', 1, N'rojo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'lbello', 2, N'dargo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'lbello', 3, N'caracas')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'lbello', 4, N'miriam')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'jflorez', 1, N'luna')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'jflorez', 2, N'luna')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'jflorez', 3, N'trujillo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'jflorez', 4, N'olida')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'elopez', 1, N'amarillo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'elopez', 2, N'luna')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'elopez', 3, N'trujillo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'elopez', 4, N'rosa')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aguedez', 1, N'rojo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aguedez', 2, N'luna')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aguedez', 3, N'trujillo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'aguedez', 4, N'olida')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'ainojosa', 1, N'red')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'ainojosa', 2, N'champion')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'ainojosa', 3, N'trujillo')
GO
INSERT [dbo].[RespuestasUsuarios] ([res_codUser], [res_codPreg], [res_resp]) VALUES (N'ainojosa', 4, N'louise')
GO
SET IDENTITY_INSERT [dbo].[RolesDeUsuario] ON 

GO
INSERT [dbo].[RolesDeUsuario] ([rol_cod], [rol_descrip], [rol_empr_cod]) VALUES (1, N'Administrador', N'')
GO
INSERT [dbo].[RolesDeUsuario] ([rol_cod], [rol_descrip], [rol_empr_cod]) VALUES (2, N'Usuario de Confianza', N'')
GO
INSERT [dbo].[RolesDeUsuario] ([rol_cod], [rol_descrip], [rol_empr_cod]) VALUES (3, N'Usuario Estandar', N'')
GO
INSERT [dbo].[RolesDeUsuario] ([rol_cod], [rol_descrip], [rol_empr_cod]) VALUES (4, N'Editor', N'')
GO
SET IDENTITY_INSERT [dbo].[RolesDeUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[StatusUser] ON 

GO
INSERT [dbo].[StatusUser] ([st_status], [st_descripcion], [st_eliminados]) VALUES (0, N'Activo', 0)
GO
INSERT [dbo].[StatusUser] ([st_status], [st_descripcion], [st_eliminados]) VALUES (1, N'Bloqueado', 0)
GO
INSERT [dbo].[StatusUser] ([st_status], [st_descripcion], [st_eliminados]) VALUES (2, N'Reportado', 0)
GO
INSERT [dbo].[StatusUser] ([st_status], [st_descripcion], [st_eliminados]) VALUES (3, N'Suspendido', 0)
GO
INSERT [dbo].[StatusUser] ([st_status], [st_descripcion], [st_eliminados]) VALUES (4, N'Reportar al Dpto. de Administracion', 0)
GO
INSERT [dbo].[StatusUser] ([st_status], [st_descripcion], [st_eliminados]) VALUES (5, N'Bloqueado por seguridad', 0)
GO
INSERT [dbo].[StatusUser] ([st_status], [st_descripcion], [st_eliminados]) VALUES (6, N'En proceso', 0)
GO
INSERT [dbo].[StatusUser] ([st_status], [st_descripcion], [st_eliminados]) VALUES (7, N'Suspendido Temporalmente', 0)
GO
INSERT [dbo].[StatusUser] ([st_status], [st_descripcion], [st_eliminados]) VALUES (8, N'Reportado por Dpto. Seguridad', 0)
GO
INSERT [dbo].[StatusUser] ([st_status], [st_descripcion], [st_eliminados]) VALUES (9, N'En revisión', 0)
GO
INSERT [dbo].[StatusUser] ([st_status], [st_descripcion], [st_eliminados]) VALUES (10, N'prueba 001', 0)
GO
SET IDENTITY_INSERT [dbo].[StatusUser] OFF
GO
SET IDENTITY_INSERT [dbo].[Sucursales] ON 

GO
INSERT [dbo].[Sucursales] ([suc_cod], [suc_descripcion], [suc_dir], [suc_telf1], [suc_telf2], [suc_email], [suc_eliminadas], [suc_fechaCreacion], [suc_nombre], [suc_contacto], [suc_mon]) VALUES (0, N'Sucursal bellas Artes, por ahoro solo telefonos locales', N'Av. Bellas Artes, parque Caracas', N'04128996514', N'02126558792', N'digitelBellasArtes@digitel.com.ve', 0, CAST(N'2019-07-31' AS Date), N'Digitel-Sucursal Bellas Artes', N'Juan Godoy', N'0')
GO
INSERT [dbo].[Sucursales] ([suc_cod], [suc_descripcion], [suc_dir], [suc_telf1], [suc_telf2], [suc_email], [suc_eliminadas], [suc_fechaCreacion], [suc_nombre], [suc_contacto], [suc_mon]) VALUES (1, N'Solo telefonos ceulares y repuestos', N'Local 171, C.C. Chacaíto, 172 Av Francisco Solano Lopez, Caracas, Miranda', N'04128996800', N'02126512192', N'digitelchacaito@digitel.com.ve', 0, CAST(N'2019-07-31' AS Date), N'Digitel-Sucursal chacaito', N'alejandro Hernandez', N'0')
GO
INSERT [dbo].[Sucursales] ([suc_cod], [suc_descripcion], [suc_dir], [suc_telf1], [suc_telf2], [suc_email], [suc_eliminadas], [suc_fechaCreacion], [suc_nombre], [suc_contacto], [suc_mon]) VALUES (2, N'Proveedor de banda ancha (ADSL/fibra) y TV digital. También vende smartphones y accesorios.', N'Jirón Bolivar 629, Trujillo 13001', N'04168996559', N'02126513311', N'Movistartrujillo@Movistar.com.ve', 0, CAST(N'2019-07-31' AS Date), N'Movistar-Trujillo', N'Anastasia Rodriguez', N'1')
GO
INSERT [dbo].[Sucursales] ([suc_cod], [suc_descripcion], [suc_dir], [suc_telf1], [suc_telf2], [suc_email], [suc_eliminadas], [suc_fechaCreacion], [suc_nombre], [suc_contacto], [suc_mon]) VALUES (3, N'Proveedor smartphones y accesorios.', N'Jirón Bolivar 629, Trujillo 13001', N'04142136577', N'02121002289', N'Movistarmerida@Movistar.com.ve', 0, CAST(N'2019-03-21' AS Date), N'Movistar-Merida', N'albeto Rodriguez', N'0')
GO
INSERT [dbo].[Sucursales] ([suc_cod], [suc_descripcion], [suc_dir], [suc_telf1], [suc_telf2], [suc_email], [suc_eliminadas], [suc_fechaCreacion], [suc_nombre], [suc_contacto], [suc_mon]) VALUES (4, N'Sucursal De tachira En remodelacion', N'Av. Bolivar, calle los Rosales', N'02543625987', N'02126235487', N'digitelTachira@Gmail.com', 0, CAST(N'2019-07-10' AS Date), N'Digitel Sucursal Bello Campo-Tachira', N'Felipe Hernandez', N'0')
GO
INSERT [dbo].[Sucursales] ([suc_cod], [suc_descripcion], [suc_dir], [suc_telf1], [suc_telf2], [suc_email], [suc_eliminadas], [suc_fechaCreacion], [suc_nombre], [suc_contacto], [suc_mon]) VALUES (21, N'Sucursal bellas Artes, por ahoro solo telefonos locales', N'Av. Bellas Artes, parque Caracas', N'04128996514', N'02126558792', N'digitelBellasArtes@digitel.com.ve', 0, CAST(N'2019-08-26' AS Date), N'Sucursal-Bellas Artes', N'Juan Godoy', N'0')
GO
SET IDENTITY_INSERT [dbo].[Sucursales] OFF
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (3, N'a', N'Año')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (0, N'cg', N'Centigramo')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (1, N'cl', N'Centílitro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (2, N'cm', N'Centímetro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (3, N'd', N'Día')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (0, N'dag', N'Decagramo')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (1, N'dal', N'Decalitro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (2, N'dam', N'Decámetro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (3, N'dec', N'Decada')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (1, N'dl', N'Decílitro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (2, N'dm', N'Decímetro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (2, N'ft', N'Pie')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (0, N'g', N'Gramo')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (0, N'hg', N'Hectogramo')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (1, N'hl', N'Hectolitro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (2, N'hm', N'Hectómetro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (3, N'hr', N'Hora')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (2, N'in', N'Pulgada')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (0, N'kg', N'Kilogramo')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (1, N'kl', N'Kilolitro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (2, N'km', N'Kilómetro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (1, N'l', N'Litro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (0, N'lb', N'Libra')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (3, N'lus', N'Lustro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (2, N'm', N'Metro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (3, N'mes', N'Mes')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (0, N'mg', N'Miligramo')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (3, N'min', N'Minuto')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (1, N'ml', N'Mililitro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (2, N'mm', N'Milímetro')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (3, N'ms', N'Milisegundo')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (3, N'quin', N'Quincena')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (3, N'seg', N'Segundo')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (3, N'sem', N'Semana')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (3, N'sig', N'Siglo')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (0, N'tn', N'Tonelada')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (3, N'trim', N'Trimestre')
GO
INSERT [dbo].[UnidadDescrip] ([UnidDes_codUniEst], [UnidDes_codUni], [UnidDes_Descripcion]) VALUES (2, N'yd', N'Yarda')
GO
SET IDENTITY_INSERT [dbo].[UnidadesEstandar] ON 

GO
INSERT [dbo].[UnidadesEstandar] ([UniEstandar_Cod], [UniEstandar_Desc], [UniEstandar_Eliminar]) VALUES (0, N'Masa', 0)
GO
INSERT [dbo].[UnidadesEstandar] ([UniEstandar_Cod], [UniEstandar_Desc], [UniEstandar_Eliminar]) VALUES (1, N'Volumen', 0)
GO
INSERT [dbo].[UnidadesEstandar] ([UniEstandar_Cod], [UniEstandar_Desc], [UniEstandar_Eliminar]) VALUES (2, N'Longitud', 0)
GO
INSERT [dbo].[UnidadesEstandar] ([UniEstandar_Cod], [UniEstandar_Desc], [UniEstandar_Eliminar]) VALUES (3, N'Tiempo', 0)
GO
SET IDENTITY_INSERT [dbo].[UnidadesEstandar] OFF
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'aangel', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 4, N'Alberto Angel modificado', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'aavila', N'5F6955D227A320C7F1F6C7DA2A6D96A851A8118F', 2, N'Ana Avila', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'aguedez', N'CFA1150F1787186742A9A884B73A43D8CF219F9B', 0, N'Angela Guedez', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'ainojosa', N'5F6955D227A320C7F1F6C7DA2A6D96A851A8118F', 0, N'Anderson Inojosa', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'aprado', N'CFA1150F1787186742A9A884B73A43D8CF219F9B', 0, N'Ana Prado', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'aramos', N'CFA1150F1787186742A9A884B73A43D8CF219F9B', 6, N'Angel Ramos', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'arodriguez', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 1, N'Arantxa Paola Rodriguez', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'ealvarez', N'CFA1150F1787186742A9A884B73A43D8CF219F9B', 0, N'Ester Alvarez', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'egalvis', N'5F6955D227A320C7F1F6C7DA2A6D96A851A8118F', 0, N'Eddy Galvis', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'egonzalez', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Efrain Golzalez', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'elopez', N'CFA1150F1787186742A9A884B73A43D8CF219F9B', 0, N'Eli Lopez', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'fmoro', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 3, N'Francisco Moro', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'gtoro', N'5F6955D227A320C7F1F6C7DA2A6D96A851A8118F', 0, N'Gustavo Toro', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'hperez', N'5F6955D227A320C7F1F6C7DA2A6D96A851A8118F', 0, N'Hugo Perez', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'jcabrita', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'jesus cabrita', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'jduarte', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Juana Duarte', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'jflorez', N'5F6955D227A320C7F1F6C7DA2A6D96A851A8118F', 0, N'Juan Florez', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'kmora', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Karen Mora', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'ktoro', N'CFA1150F1787186742A9A884B73A43D8CF219F9B', 0, N'Karina Toro', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'lbello', N'5F6955D227A320C7F1F6C7DA2A6D96A851A8118F', 0, N'Luis Bello', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'lperez', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'leonardo Peres', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'lquintero', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Liseet Quintero', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'mgalvis', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Maria Galvis', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'mquintero', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 2, N'Melvin Quintero', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'ndelgado', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Norelis Delgado', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'norysT', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 1, N'norys torres', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'nserrano', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Nathaly Serrano', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'otiano', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Oscar Tiano', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'plopez', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Pablo Lopez', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'rmolina', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Rosa Molina', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'rvalerie', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 3, N'Valerie Rodriguez', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'sdelgado', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Steven Delgado', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'sprueba', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Desde mi pc', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'squintero', N'5F6955D227A320C7F1F6C7DA2A6D96A851A8118F', 0, N'Sarahi Quintero', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'tavila', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Teresa Avila', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'valerie2', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 1, N'Valerie 2 prueba', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'valerie3', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 1, N'Valerie 3', 1)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'valerprueba', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 1, N'vall', 1)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'vpacheco', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Vanessa Pacheco', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'vrodriguez', N'0B00F9448FAD5A01F16257DD6EBDED4E11846354', 0, N'Valerie Rodriguez', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'wavila', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 6, N'William Avila', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'ygomez', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Yordan Gomez', 0)
GO
INSERT [dbo].[Usuarios] ([us_username], [us_password], [us_status], [us_nombre], [us_eliminados]) VALUES (N'ytorbello', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', 0, N'Yordan Torbello', 0)
GO
INSERT [dbo].[UsuariosModulos] ([usMod_Usua], [usMod_modId]) VALUES (N'aavila', 0)
GO
ALTER TABLE [dbo].[EmpresaMoneda]  WITH CHECK ADD  CONSTRAINT [FK_EmpresaMoneda_empresa] FOREIGN KEY([EmpM_codEmp])
REFERENCES [dbo].[empresa] ([empr_dni])
GO
ALTER TABLE [dbo].[EmpresaMoneda] CHECK CONSTRAINT [FK_EmpresaMoneda_empresa]
GO
ALTER TABLE [dbo].[EmpresaMoneda]  WITH CHECK ADD  CONSTRAINT [FK_EmpresaMoneda_Moneda] FOREIGN KEY([EmpM_codMon])
REFERENCES [dbo].[Moneda] ([mon_codID])
GO
ALTER TABLE [dbo].[EmpresaMoneda] CHECK CONSTRAINT [FK_EmpresaMoneda_Moneda]
GO
ALTER TABLE [dbo].[RespuestasUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_RespuestasUsuarios2_PreguntasSeguridad_RecuperarClave] FOREIGN KEY([res_codPreg])
REFERENCES [dbo].[PreguntasSeguridad] ([pr_cod])
GO
ALTER TABLE [dbo].[RespuestasUsuarios] CHECK CONSTRAINT [FK_RespuestasUsuarios2_PreguntasSeguridad_RecuperarClave]
GO
ALTER TABLE [dbo].[StatusUser]  WITH CHECK ADD  CONSTRAINT [FK_StatusUser_StatusUser1] FOREIGN KEY([st_status])
REFERENCES [dbo].[StatusUser] ([st_status])
GO
ALTER TABLE [dbo].[StatusUser] CHECK CONSTRAINT [FK_StatusUser_StatusUser1]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_StatusUser] FOREIGN KEY([us_status])
REFERENCES [dbo].[StatusUser] ([st_status])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_StatusUser]
GO
ALTER TABLE [dbo].[UsuariosModulos]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosModulos_Modulos] FOREIGN KEY([usMod_modId])
REFERENCES [dbo].[Modulos] ([mod_Id])
GO
ALTER TABLE [dbo].[UsuariosModulos] CHECK CONSTRAINT [FK_UsuariosModulos_Modulos]
GO
ALTER TABLE [dbo].[UsuariosModulos]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosModulos_Usuarios] FOREIGN KEY([usMod_Usua])
REFERENCES [dbo].[Usuarios] ([us_username])
GO
ALTER TABLE [dbo].[UsuariosModulos] CHECK CONSTRAINT [FK_UsuariosModulos_Usuarios]
GO
/****** Object:  StoredProcedure [dbo].[sp__ListadoMonedas]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp__ListadoMonedas]
AS
	BEGIN
		SELECT*FROM Moneda
	END
GO
/****** Object:  StoredProcedure [dbo].[Sp_ActualizarDeciamal]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ActualizarDeciamal]
(
	@Valor NVARCHAR (50),
	@Mensaje NVARCHAR (50) OUT
)
AS
	BEGIN
		UPDATE OpcionesGenerales
		SET OpcionesGen_Valor=@Valor
		SET @Mensaje='Actualizacion Exitosa'
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarModulos]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ActualizarModulos]
(@id int,
 @descripcion NVARCHAR (100),
 @mensaje NVARCHAR (100) OUT
 )

 AS
	BEGIN
		UPDATE Modulos
		SET mod_Descripcion=@descripcion WHERE (mod_Id=@id)
		SET @mensaje='Actualizacion Exitosa'
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarMoneda]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ActualizarMoneda]
(
@CodigoIso NVARCHAR(50),
@simbolo NVARCHAR(50),
@descripcion NVARCHAR (200),
@Mensaje NVARCHAR (100) OUT
--@id INT OUT
)
AS
	BEGIN
		UPDATE Moneda
			SET mon_Descripcion = @descripcion, mon_simbolo = @simbolo
		WHERE (/*mon_codID = @id  AND */ mon_cod = @CodigoIso)
	SET @Mensaje ='Actualizacion Exitosa'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarRespuestas]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_ActualizarRespuestas]
@dtRespuestasT [dbo].[RespuestasUsuariosTEM] ReadOnly

AS
BEGIN
	UPDATE RespuestasUsuarios
	SET
	res_resp = r.[res_resT]
	FROM @dtRespuestasT r
	WHERE res_codUser= r.[res_codUerT] AND res_codPreg= r.[res_codPregT]
	END

GO
/****** Object:  StoredProcedure [dbo].[Sp_ActualizarStatus]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ActualizarStatus]
(
	@status int,
	@descripcion nvarchar(50),
	@mensaje nvarchar(100) OUT
)

AS
	BEGIN
		UPDATE [dbo].[StatusUser]
		SET st_descripcion=@descripcion
		WHERE (st_status=@status)
		SET @mensaje ='Actualizacion Exitosa'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarUsuario]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------
CREATE PROCEDURE [dbo].[sp_ActualizarUsuario] 
	-- Add the parameters for the stored procedure here
	@username nvarchar(50),	
	@status smallint,
	@nombre nvarchar(150),
	@Mensaje varchar(100) out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.Usuarios
	    SET us_nombre = @nombre,
	        us_status = @status
		WHERE  (us_username = @username)
		SET @mensaje ='Actualizacion Exitosa'

END
GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarModulos]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_AgregarModulos]
(@descripcion NVARCHAR (100),
 @mensaje NVARCHAR (50) OUT,
 @id INT OUT
 )
 AS
	BEGIN
		INSERT Modulos VALUES (@descripcion)
		SELECT @id=mod_Id FROM Modulos WHERE (mod_Descripcion=@descripcion)
		SET @mensaje='Registro Exitoso'
	END 
GO
/****** Object:  StoredProcedure [dbo].[sp_agregarStatus]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE	PROC [dbo].[sp_agregarStatus]
(
	/*@status int,*/
	@descripcion nvarchar(50),
	@mensaje nvarchar(50) OUT,
	@status INT OUT 
)
AS
	BEGIN
	/*	IF(EXISTS(SELECT*FROM UserStatus WHERE st_status=@status))
			SET @mensaje = 'Este valor de Status ya exite'
		ELSE
		BEGIN*/
		INSERT StatusUser VALUES (@descripcion,0)	

		 SELECT  @status = st_status FROM StatusUser WHERE (st_descripcion = @descripcion)

		 SET @mensaje = 'Registro exitoso'
		/*SET @MEN CAST (st_status as nvarchar) FROM UserStatus where (st_descripcion=@descripcion) */
		
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarUsuario]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--------------------------------------------------

CREATE PROCEDURE [dbo].[sp_AgregarUsuario] 
	-- Add the parameters for the stored procedure here
	@username nvarchar(50),	
	@status nvarchar(1),
	@nombre nvarchar(150),
	@Mensaje varchar(100) out
AS
 BEGIN
	IF (exists(SELECT * FROM Usuarios WHERE us_username=@username))
		SET @Mensaje='Usuario ya está Registrado'
	ELSE
	 BEGIN
		INSERT INTO dbo.Usuarios (us_username, us_password, us_status, us_nombre, us_eliminados)
	       VALUES (@username, '40BD001563085FC35165329EA1FF5C5ECBDBBEEF', @status, @nombre,0)
		
		SET @Mensaje='Registro exitoso'
	 END
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarEstatus_Activo]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROC [dbo].[sp_BuscarEstatus_Activo]
(
	@status int,
	@status_activo nvarchar(50) out
)
AS
BEGIN 
	IF (exists(SELECT*FROM Usuarios WHERE us_status=@status AND us_eliminados=0 ))
	SET @status_activo='activo'
	ELSE
		BEGIN
			IF (exists(SELECT*FROM Usuarios WHERE us_status=@status AND us_eliminados=1 ))			
			SET @status_activo='desactivado'
			ELSE
			BEGIN 
			SET @status_activo='no'
		END
	END

END

GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarUsuarioRespuestas]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_BuscarUsuarioRespuestas]
(
@username nvarchar(50)
--@mensaje nvarchar(100) OUT
)
AS
	BEGIN
		IF (exists(SELECT*FROM Usuarios WHERE us_username=@username))
		--BEGIN
			SELECT P.pr_cod, 
			P.pr_pregunta,
			R.res_resp
			FROM
				PreguntasSeguridad P, RespuestasUsuarios R
			WHERE 
				R.res_codUser=@username AND P.pr_cod=R.res_codPreg
	
END

GO
/****** Object:  StoredProcedure [dbo].[sp_CambiarClaveUser]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CambiarClaveUser]
	
	@usuario varchar(30),
	@password varchar(40),
	@mensaje varchar (100) out
AS
BEGIN
	
	UPDATE Usuarios
	    SET us_password = @password
		WHERE  (us_username = @usuario)

		set @mensaje = 'Contraseña Actualizada con exito'
		
END

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarAlmacenDefinitivo]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_EliminarAlmacenDefinitivo]
(
	@alm_cod int,
	@mensaje nvarchar(50) OUT
)
AS
BEGIN
	DELETE FROM Almacenes WHERE (alm_cod = @alm_cod) 
	SET @mensaje= 'El Registro se ha eliminado correctamente'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminarAlmacenLogico]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROC [dbo].[sp_eliminarAlmacenLogico]
(
	@alm_Cod nvarchar(50),
	@mensaje nvarchar(50) OUT
)
AS
BEGIN
	--DELETE FROM Usuarios_principal_sara WHERE (us_username=@username)
	UPDATE Almacenes SET alm_eliminado=1 WHERE (alm_cod = @alm_Cod)	
	SET @mensaje= 'El Registro se ha eliminado correctamente'
END


GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarEmpresaDefinitivo]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[sp_EliminarEmpresaDefinitivo]
(
	@empr_dni nvarchar(50),
	@mensaje nvarchar(50) OUT
)
AS
BEGIN
	DELETE FROM empresa WHERE (empr_dni=@empr_dni) 
	SET @mensaje= 'El Registro se ha eliminado correctamente'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminarEmpresaLogico]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[sp_eliminarEmpresaLogico]
(
	@emp_Cod nvarchar(50),
	@mensaje nvarchar(50) OUT
)
AS
BEGIN
	--DELETE FROM Usuarios_principal_sara WHERE (us_username=@username)
	UPDATE empresa SET empr_Eliminadas=1 WHERE (empr_dni = @emp_Cod)	
	SET @mensaje= 'El Registro se ha eliminado correctamente'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarModulo]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_EliminarModulo]
(
 @dtEliminarM dbo.EliminarUsuarioModuloTem readonly
)
as
	begin
		delete from UsuariosModulos
		where exists(select T.usMod_Usua, T.usMod_modId 
		from @dtEliminarM T
		where UsuariosModulos.usMod_modId=T.usMod_modId and
		      UsuariosModulos.usMod_Usua=T.usMod_Usua)
	end

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarModulos]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_EliminarModulos]
(@id INT,
 @mensaje NVARCHAR (50) OUT
 )
 AS
	BEGIN
		DELETE FROM Modulos WHERE (mod_Id=@id)
		SET @mensaje='Eliminacion Exitosa'
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarMoneda]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_EliminarMoneda]
(
@id NVARCHAR (10),
--@Eliminar NVARCHAR (50),
@Mensaje NVARCHAR (100) OUT
)
AS
	BEGIN
		DELETE FROM Moneda WHERE (@id = mon_cod)
	SET @Mensaje = 'Eliminacion Exitosa'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_eliminarStatus]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_eliminarStatus]
(
@status int,
@mensaje varchar(100) OUT
)
AS
BEGIN
	UPDATE StatusUser SET st_eliminados=1 WHERE (st_status=@status)
	SET @mensaje = 'Eliminacion exitosa'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarStatusDefinitivo]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_EliminarStatusDefinitivo]
(	
	@status nvarchar(50),
	@mensaje nvarchar(50) OUT
)
AS
BEGIN
	DELETE FROM StatusUser WHERE (st_status=@status) 
	SET @mensaje= 'Eliminacion exitosa'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarStatusTodos]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_EliminarStatusTodos]
(
	@mensaje nvarchar(50) OUT
)
AS
BEGIN
	DELETE FROM StatusUser WHERE (st_eliminados=1)
	SET @mensaje='Eliminacion exitosa'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarSucursalDefinitivo]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[sp_EliminarSucursalDefinitivo]
(
	@suc_cod int,
	@mensaje nvarchar(50) OUT
)
AS
BEGIN
	DELETE FROM Sucursales WHERE (suc_cod = @suc_cod) 
	SET @mensaje= 'El Registro se ha eliminado correctamente'
END

SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[sp_eliminarSucursalLogico]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[sp_eliminarSucursalLogico]
(
	@suc_Cod nvarchar(50),
	@mensaje nvarchar(50) OUT
)
AS
BEGIN
	--DELETE FROM Usuarios_principal_sara WHERE (us_username=@username)
	UPDATE Sucursales SET suc_eliminadas=1 WHERE (suc_cod = @suc_Cod)	
	SET @mensaje= 'El Registro se ha eliminado correctamente'
END

SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarUserDefinitivo]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_EliminarUserDefinitivo]
(
	@username nvarchar(50),
	@mensaje nvarchar(50) OUT
)
AS
BEGIN
	DELETE FROM Usuarios WHERE (us_username=@username) 
	SET @mensaje= 'Eliminacion exitosa'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarUserTodos]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_EliminarUserTodos]
(
	@mensaje nvarchar(50) OUT
)
AS
BEGIN
	DELETE FROM Usuarios WHERE (us_eliminados=1)
	SET @mensaje= 'Eliminacion exitosa'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminarUsuario]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_eliminarUsuario]
(
	@username nvarchar(50),
	@mensaje nvarchar(50) OUT
)
AS
BEGIN
	--DELETE FROM Usuarios_principal_sara WHERE (us_username=@username)
	UPDATE Usuarios SET us_eliminados=1 WHERE (us_username= @username)	
	SET @mensaje='Eliminacion exitosa'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarRespuestas]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_InsertarRespuestas]

@dtRespuestas dbo.RespuestasUsuariosPru ReadOnly--,
--@Error INT OUT

AS
BEGIN --TRAN
	BEGIN
		INSERT INTO RespuestasUsuarios
				(res_codUser,res_codPreg,res_resp)
			SELECT 
			[res_codUer],
			[res_codPreg],
			[res_res]
			FROM 
			@dtRespuestas
		--SET @Error=@@ERROR
	--	IF (@Error<>0) GOTO TratarError
		BEGIN 
			UPDATE Usuarios						--LA PRIMERA VEZ QUE INSERTA LA RESPUESTAS CAMBIA LA CLAVE
			SET us_password= r.[usua_clave]
			FROM @dtRespuestas r
			WHERE us_username= r.[res_codUer]
		--SET @Error=@@ERROR
	--	IF (@Error<>0) GOTO TratarError
		END
	END
--COMMIT TRAN
--TratarError:
	--If @Error<>0 
	--BEGIN
	--	PRINT 'Ha ecorrido un error. Abortamos la transacción'
	--Se lo comunicamos al usuario y deshacemos la transacción
	--todo volverá a estar como si nada hubiera ocurrido
		--ROLLBACK TRAN
END

GO
/****** Object:  StoredProcedure [dbo].[sp_listadoAlm_Suc_Emp]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_listadoAlm_Suc_Emp]
AS
	BEGIN
		SELECT ASE.alm_almcod,
		ASE.alm_empcod,
		ASE.alm_succod,
		E.empr_nombre,
		S.suc_nombre,
		A.alm_nombre
		 
		FROM 
		Almacenes A,
		Sucursales S,
		Almacen_Sucursal_Empresa ASE,
		empresa E

		WHERE A.alm_cod = ASE.alm_almcod AND S.suc_cod = ASE.alm_succod AND E.empr_dni = ASE.alm_empcod
		
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_listadoAlmacenes]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[sp_listadoAlmacenes]
AS
	BEGIN
		SELECT a.alm_cod,
		A.alm_contacto,
		a.alm_desc,
		A.alm_dir,
		A.alm_fechaCreacion,
		A.alm_nombre,
	--	A.alm_telef1,
		--A.alm_telef2
		ASE.alm_almcod,
		ASE.alm_empcod,
		ASE.alm_succod

		FROM
			Almacenes A,
			Almacen_Sucursal_Empresa ASE,
			empresa E,
			Sucursales S
			

		WHERE E.empr_dni = ASE.alm_empcod 
		AND A.alm_cod = ASE.alm_almcod 
		AND S.suc_cod = ASE.alm_succod
END
GO
/****** Object:  StoredProcedure [dbo].[sp_listadoEmpresas]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_listadoEmpresas]
AS
	BEGIN
		SELECT E.empr_dni,
		E.empr_desc,
		E.empr_dir,
		E.empr_rif,
		E.empr_nit,
		E.empr_telef1,
		E.empr_telef2,
		E.empr_email,
		E.empr_web,
		E.empr_FechaCreacion,
		E.empr_contacto,
		E.empr_nombre,
		--E.empr_moneda,
		E.empr_nombCorto,	   
		E.empr_Bd
		FROM
			empresa E
			
		--WHERE
		--  E.empr_dni = empr_dni 
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListadoEstadosEliminados]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ListadoEstadosEliminados]
AS
	BEGIN
		SELECT Us.st_status, Us.st_descripcion FROM StatusUser Us WHERE st_eliminados=1
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_listadoSucursalEmpresa]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_listadoSucursalEmpresa]
AS
	BEGIN
		select ES.emp_Cod,
		ES.emp_SucCod,
		E.empr_nombre,
		S.suc_nombre
		 
		from 
		Sucursales S,
		Empresa_Sucusal ES,
		empresa E

		where E.empr_dni= ES.emp_Cod AND S.suc_cod= ES.emp_SucCod
		
	end 
GO
/****** Object:  StoredProcedure [dbo].[sp_listadoSucursales]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_listadoSucursales]
AS
	BEGIN
		SELECT S.suc_cod,
		S.suc_descripcion,
		S.suc_dir,	
		S.suc_telf1,
		S.suc_telf2,
		S.suc_email,
		S.suc_FechaCreacion,
		S.suc_contacto,
		S.suc_nombre,
		S.suc_mon,
		ES.emp_Cod,
		ES.emp_SucCod

		FROM
			Sucursales S,
			Empresa_Sucusal ES,
			empresa E
		WHERE E.empr_dni= ES.emp_Cod AND S.suc_cod= ES.emp_SucCod
END
GO
/****** Object:  StoredProcedure [dbo].[sp_listadoUsuarios]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE[dbo].[sp_listadoUsuarios]
AS
	BEGIN
		SELECT U.us_username,
			  U.us_status,
			  U.us_nombre,
			  S.st_descripcion
			  
		FROM
			Usuarios U,
			StatusUser S
		WHERE
		   U.us_status = S.st_status AND us_eliminados=0
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_listadoUsuariosEliminados]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_listadoUsuariosEliminados]
AS
	BEGIN
		SELECT U.us_username,
			  U.us_status,
			  U.us_nombre,
			  S.st_descripcion
			  
		FROM
			Usuarios U,
			StatusUser S
		WHERE
		   U.us_status = S.st_status AND us_eliminados=1
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_ListaEmpMoneda]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROC [dbo].[sp_ListaEmpMoneda]
	AS
		BEGIN
		SELECT*FROM [EmpresaMoneda]
		 END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListaModulosCBO]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[sp_ListaModulosCBO]
as
	begin
		select*from Modulos
	end

GO
/****** Object:  StoredProcedure [dbo].[SP_ListarConversionSegundos]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_ListarConversionSegundos]
	AS
		BEGIN
				SELECT*FROM FactorTiempo
				WHERE FU_U2 = 'seg'

		END

GO
/****** Object:  StoredProcedure [dbo].[SP_ListarFactorLongitud]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_ListarFactorLongitud]
AS
	BEGIN
		SELECT*FROM FactorLongitud
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ListarFactorMasa]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_ListarFactorMasa]
AS
	BEGIN
		SELECT*FROM FactorMasa
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ListarFactorTiempo]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_ListarFactorTiempo]
AS
	BEGIN
		SELECT*FROM FactorTiempo
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ListarFactorVolumen]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_ListarFactorVolumen]
AS
	BEGIN
		SELECT*FROM FactorVolumen
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarModulos]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ListarModulos]
	AS
		BEGIN
			SELECT U.usMod_modId,
				   U.usMod_Usua,
				   M.Mod_Descripcion
			from UsuariosModulos U, Modulos M
			Where U.usMod_modId=M.Mod_Id
		END

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarOpcionesGenerales]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[sp_ListarOpcionesGenerales]
as
	begin
		select*from OpcionesGenerales
	end

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarUnidaddDeTiempo]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ListarUnidaddDeTiempo]

AS
BEGIN
	SELECT 
	UD.UnidDes_codUniEst,
	UD.UnidDes_codUni,
	UD.UnidDes_Descripcion
	
	
	FROM UnidadDescrip UD
		 
		WHERE UD.UnidDes_codUniEst = '3'  
		 
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarUnidadesDeMasa]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ListarUnidadesDeMasa]

AS
	
BEGIN
	SELECT 
	UD.UnidDes_codUniEst,
	UD.UnidDes_codUni,
	UD.UnidDes_Descripcion
	
	
	FROM UnidadDescrip UD
		 
		WHERE UD.UnidDes_codUniEst = '0'  
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarUnidadesDescripMVL]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ListarUnidadesDescripMVL]

AS
	BEGIN
	SELECT*FROM UnidadDescrip
	WHERE UnidDes_codUniEst != '3'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarUnidadesDeVolumen]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ListarUnidadesDeVolumen]

AS
	BEGIN
	SELECT 
	UD.UnidDes_codUniEst,
	UD.UnidDes_codUni,
	UD.UnidDes_Descripcion
	
	
	FROM UnidadDescrip UD
		 
		WHERE UD.UnidDes_codUniEst = '1'  
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarUnidadesEstarMVL]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ListarUnidadesEstarMVL]

AS
	BEGIN
	SELECT*FROM UnidadesEstandar
	WHERE UniEstandar_Cod != '3'

END

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarUnidadLongitud]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ListarUnidadLongitud]

AS
BEGIN
	SELECT 
	UD.UnidDes_codUniEst,
	UD.UnidDes_codUni,
	UD.UnidDes_Descripcion
	
	
	FROM UnidadDescrip UD--,
	--UnidadesEstandar UE
		 
		WHERE UD.UnidDes_codUniEst = '2' 
		 
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarUsuarios]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ListarUsuarios]
AS
	BEGIN
		SELECT*FROM Usuarios
	END 
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistarMonedas]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistarMonedas]
(
	@dtMonedas EmpresaMonedaTem READONLY
)
AS
	BEGIN
	INSERT INTO EmpresaMoneda (EmpM_codEmp,EmpM_codMon)
	SELECT
	[EmpM_codEmp],
	[EmpM_codMon]
	FROM
	@dtMonedas
	END 
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarMoneda]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistrarMoneda]
(
@CodigoIso Nvarchar (10),
@Descripcion NVARCHAR (200),
@Simbolo NCHAR (10),
@ELIMINAR INT OUT,
@Mensaje nvarchar(100) OUT, 
@id int out 
)
AS  

BEGIN  
	IF(EXISTS (SELECT*FROM Moneda WHERE mon_cod = @CodigoIso))
		SET @mensaje = 'Ya existe'
			ELSE
				INSERT Moneda VALUES 
				(@CodigoIso,
				@Descripcion,
				@Simbolo,
				'1') 
		SELECT @id = M.mon_codID FROM Moneda M  WHERE @Descripcion = M.mon_Descripcion 
	SET @Mensaje = 'Registro Exitoso'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarUsuaModulo]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROC [dbo].[sp_RegistrarUsuaModulo]
(
	@dtUsuaModulo UsuarioModuloTEM READONLY
)
AS
	BEGIN
	INSERT INTO UsuariosModulos (usMod_Usua,usMod_modid)
	SELECT
	[usMod_Usua],
	[usMod_modid]
	FROM
	@dtUsuaModulo
	END 

GO
/****** Object:  StoredProcedure [dbo].[sp_RegistroAlmacen]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistroAlmacen]
(
 @empresa int,
 @sucursal int,
 @almNomb nvarchar(200),
 @almDesc nvarchar(200),
 @almDirec nvarchar(200),
 @almContacto nvarchar(200),
 @almTelf1 nvarchar(50),
 @almTelf2 nvarchar(50),
 @almFechaCreacion date, 
 @almMensaje nvarchar(100) OUT,
 @codAlm int OUT
)
AS
BEGIN
	BEGIN
		INSERT Almacenes
		VALUES (@almNomb,@almDesc,
				@almDirec,@almContacto,@almTelf1,
				@almTelf2,@almFechaCreacion,0)
		SELECT  @codAlm= A.alm_cod FROM Almacenes A WHERE A.alm_nombre=@almNomb
		SET @almMensaje='Registro exitoso'
	END
	BEGIN
		INSERT Almacen_Sucursal_Empresa VALUES (@empresa,@sucursal,@codAlm)
	END
END

GO
/****** Object:  StoredProcedure [dbo].[sp_RegistroEmpresa]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistroEmpresa]
(@emprNomb nvarchar(200),
 @emprDesc nvarchar(200),
 @emprDirec nvarchar(200),
 @empContacto nvarchar(200),
 @emprTelf1 nvarchar(50),
 @emprTelf2 nvarchar(50),
 @emprRif nvarchar(100),
-- @emprMoneda int,
 @emprEmail nvarchar(100),
 @emprWeb nvarchar(100),
 @emprFechaCreacion date,
 @emprNit nvarchar(100), 
 @empNombCorto nvarchar(10),
 @empMensaje nvarchar(100) OUT,
 @codEmp int OUT
)
AS
BEGIN
	INSERT empresa VALUES (@emprDesc,@emprDirec,
					@emprRif,@emprNit,
					@emprTelf1,@emprTelf2,
					@emprEmail,@emprWeb,
					0,@emprFechaCreacion,@emprNomb,@empContacto,@empNombCorto,'no')
			SET @empMensaje='Registro exitoso'
			SELECT @codEmp= empr_dni FROM empresa WHERE (empr_nombCorto=@empNombCorto)

	END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistroSucursal]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistroSucursal]
(@empresa int,
 @sucNomb nvarchar(200),
 @sucDesc nvarchar(200),
 @sucDirec nvarchar(200),
 @sucContacto nvarchar(200),
 @sucTelf1 nvarchar(50),
 @sucTelf2 nvarchar(50), 
 @sucMoneda int,
 @sucEmail nvarchar(100),
 @sucFechaCreacion date,
 --@empNombCorto nvarchar(10), 
 @sucMensaje nvarchar(100) OUT,
 @CodSuc int OUT
)
AS
BEGIN 
	BEGIN
		INSERT Sucursales VALUES (@sucDesc,@sucDirec,
					@sucTelf1,@sucTelf2,@sucEmail,0,
					@sucFechaCreacion,@sucNomb,@sucContacto,@sucMoneda)
		SELECT @CodSuc= suc_cod FROM Sucursales WHERE suc_nombre=@sucNomb
		SET @sucMensaje='Registro exitoso'
	END
	BEGIN
		INSERT Empresa_Sucusal VALUES (@empresa, @CodSuc)
		
		
	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistroUsuario]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC	[dbo].[sp_RegistroUsuario]
(
@username nvarchar(50),
@status int,
@nombre nvarchar(50),
@mensaje nvarchar(100) OUT
)
AS
BEGIN
	 IF (exists(SELECT*FROM Usuarios WHERE us_username=@username))
			SET @mensaje = 'Este usuario ya existe'
	 ELSE
		BEGIN
			INSERT Usuarios VALUES (@username,'40BD001563085FC35165329EA1FF5C5ECBDBBEEF',@status,@nombre,0)
			SET @mensaje='Registro exitoso'
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_RestaurarStatus]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_RestaurarStatus]
(
	@status nvarchar(100),
	@mensaje nvarchar(50) OUT
)
AS
	BEGIN
	UPDATE StatusUser SET st_eliminados=0 WHERE (st_status= @status)
	SET @mensaje= 'Restauracion Exitosa'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_RestaurarStatusTodos]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_RestaurarStatusTodos]
(
	@mensaje nvarchar(50) OUT
)
AS
BEGIN
	UPDATE StatusUser SET st_eliminados=0 WHERE (st_eliminados=1)
	SET @mensaje= 'Restauracion Exitosa'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RestaurarUserTodos]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_RestaurarUserTodos]
(
	@mensaje nvarchar(50) OUT
)
AS
BEGIN
	UPDATE Usuarios SET us_eliminados=0 WHERE (us_eliminados=1)
	SET @mensaje= 'Restauracion Exitosa'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RestaurarUsuario]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_RestaurarUsuario]
(
	@username nvarchar(100),
	@mensaje nvarchar(50) OUT
)
AS
	BEGIN
	UPDATE Usuarios SET us_eliminados=0 WHERE (us_username= @username)
	SET @mensaje= 'Restauracion Exitosa'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_TablaPreguntas]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_TablaPreguntas]
AS
	BEGIN
	SELECT * FROM PreguntasSeguridad
END


GO
/****** Object:  StoredProcedure [dbo].[sp_TablaStatus]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[sp_TablaStatus]
AS
	BEGIN
	SELECT 
	st_status, st_descripcion 
	FROM 
	StatusUser
	WHERE
	st_eliminados=0 
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ValidarUsuario]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_ValidarUsuario]
(
@username nvarchar (50)
)
AS
BEGIN
	SELECT us_username,us_nombre,us_status,us_nombre,us_eliminados, us_password, st_descripcion FROM Usuarios, StatusUser where (us_username=@username
	and 
	us_status=st_status)
END

GO
/****** Object:  StoredProcedure [dbo].[SPpruebaBorrar]    Script Date: 13/10/2020 12:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SPpruebaBorrar]
AS
	begin
	 UPDATE empresa SET empr_Bd= 'si' WHERE empr_nombCorto= 'Movistar'
	end
GO
