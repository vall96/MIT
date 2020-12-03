USE [Digitel]
GO
/****** Object:  User [IET\desarrollo2]    Script Date: 13/10/2020 12:17:45 ******/
CREATE USER [IET\desarrollo2] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [NT AUTHORITY\Usuarios autentificados]    Script Date: 13/10/2020 12:17:45 ******/
CREATE USER [NT AUTHORITY\Usuarios autentificados] FOR LOGIN [NT AUTHORITY\Usuarios autentificados]
GO
/****** Object:  Schema [IET\desarrollo1]    Script Date: 13/10/2020 12:17:45 ******/
CREATE SCHEMA [IET\desarrollo1]
GO
/****** Object:  Schema [IET\desarrollo2]    Script Date: 13/10/2020 12:17:45 ******/
CREATE SCHEMA [IET\desarrollo2]
GO
/****** Object:  UserDefinedTableType [dbo].[Cedula_AtributosTem]    Script Date: 13/10/2020 12:17:45 ******/
CREATE TYPE [dbo].[Cedula_AtributosTem] AS TABLE(
	[cedula_AtribId] [nvarchar](50) NOT NULL,
	[cedula_CedulaID] [nvarchar](50) NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Cedula_GastosFabricaTem]    Script Date: 13/10/2020 12:17:45 ******/
CREATE TYPE [dbo].[Cedula_GastosFabricaTem] AS TABLE(
	[cedula_GastFabId] [nvarchar](50) NOT NULL,
	[cedula_CedulaID] [nvarchar](50) NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Cedula_PerfilEmpTem]    Script Date: 13/10/2020 12:17:45 ******/
CREATE TYPE [dbo].[Cedula_PerfilEmpTem] AS TABLE(
	[cedula_CedulaID] [nvarchar](50) NOT NULL,
	[cedula_perfilID] [nvarchar](50) NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[CedulaArtTem]    Script Date: 13/10/2020 12:17:45 ******/
CREATE TYPE [dbo].[CedulaArtTem] AS TABLE(
	[CedArt_CedulaID] [nvarchar](50) NOT NULL,
	[CedArt_ArticuloId] [nvarchar](50) NOT NULL,
	[CedArt_CodUnidad] [nvarchar](10) NOT NULL,
	[CedArt_CantUnidad] [decimal](18, 0) NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[CedulaProductoTem]    Script Date: 13/10/2020 12:17:45 ******/
CREATE TYPE [dbo].[CedulaProductoTem] AS TABLE(
	[CedPro_Id] [nvarchar](50) NOT NULL,
	[CedPro_Descrip] [nvarchar](200) NOT NULL,
	[CedPro_Fecha] [date] NOT NULL,
	[CedPro_Unidad] [nvarchar](50) NOT NULL,
	[CedPro_Producto] [nvarchar](200) NOT NULL,
	[CedPro_Duracion] [int] NOT NULL,
	[CedPro_DuracionHoraDias] [nvarchar](50) NOT NULL,
	[CedPro_Cantidad] [int] NOT NULL,
	[CedPro_UnidadEstandar] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[CedulaTareaTem]    Script Date: 13/10/2020 12:17:45 ******/
CREATE TYPE [dbo].[CedulaTareaTem] AS TABLE(
	[CedTarea_IdCedProd] [nvarchar](50) NOT NULL,
	[CedTarea_IdTarea] [nvarchar](50) NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[InventarioTem]    Script Date: 13/10/2020 12:17:45 ******/
CREATE TYPE [dbo].[InventarioTem] AS TABLE(
	[Inv_CodArt] [nvarchar](50) NOT NULL,
	[Inv_Fecha] [nvarchar](50) NOT NULL,
	[Inv_TipoMov] [nvarchar](50) NOT NULL,
	[Inv_Almacen] [nvarchar](150) NOT NULL,
	[Inv_Cantidad] [int] NOT NULL,
	[Inv_Unidad] [nvarchar](50) NOT NULL,
	[Inv_Proceso] [nvarchar](200) NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Sucursal_AlmacenTem]    Script Date: 13/10/2020 12:17:45 ******/
CREATE TYPE [dbo].[Sucursal_AlmacenTem] AS TABLE(
	[alm_succod] [int] NOT NULL,
	[alm_almcod] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[TareasArtTem]    Script Date: 13/10/2020 12:17:45 ******/
CREATE TYPE [dbo].[TareasArtTem] AS TABLE(
	[TareasArt_TareaId] [nvarchar](50) NOT NULL,
	[TareasArt_ArtId] [nvarchar](50) NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[TareasAtribTem]    Script Date: 13/10/2020 12:17:45 ******/
CREATE TYPE [dbo].[TareasAtribTem] AS TABLE(
	[TareasAtrib_TareaId] [nvarchar](50) NOT NULL,
	[TareasAtrib_AtribId] [nvarchar](50) NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[TareasMaqTem]    Script Date: 13/10/2020 12:17:45 ******/
CREATE TYPE [dbo].[TareasMaqTem] AS TABLE(
	[TareasMaq_TareaId] [nvarchar](50) NOT NULL,
	[TareasMaq_MaqId] [nvarchar](50) NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[TiempoMaqTemp]    Script Date: 13/10/2020 12:17:45 ******/
CREATE TYPE [dbo].[TiempoMaqTemp] AS TABLE(
	[TareasMaq_TareaId] [nvarchar](50) NOT NULL,
	[TareasMaq_MaqId] [nvarchar](50) NOT NULL,
	[TareasMaq_CodUnidad] [nvarchar](10) NOT NULL,
	[TareasMaq_CantUnidad] [decimal](18, 0) NOT NULL,
	[TareasMaq_CodUnidadTrab] [nvarchar](10) NOT NULL,
	[TareasMaq_CantUnidadTrab] [decimal](18, 0) NOT NULL
)
GO
/****** Object:  UserDefinedTableType [IET\desarrollo2].[SucursalMonedaTemp]    Script Date: 13/10/2020 12:17:45 ******/
CREATE TYPE [IET\desarrollo2].[SucursalMonedaTemp] AS TABLE(
	[SucMon_codSuc] [int] NOT NULL,
	[SucMon_codMon] [int] NOT NULL
)
GO
/****** Object:  Table [dbo].[Almacenes]    Script Date: 13/10/2020 12:17:45 ******/
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
/****** Object:  Table [dbo].[ArticuloAlmancen]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticuloAlmancen](
	[art_almCod] [int] NOT NULL,
	[art_artCod] [smallint] NOT NULL,
	[art_UniCod] [int] NOT NULL,
	[art_cantAct] [decimal](10, 4) NOT NULL,
	[art_cantCompro] [decimal](10, 4) NULL,
	[art_cantAdquirir] [decimal](10, 4) NULL,
	[art_cantDespachar] [decimal](10, 4) NULL,
	[art_canDisponible] [decimal](10, 4) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[art_Id] [nvarchar](50) NOT NULL,
	[art_Nom] [nvarchar](100) NULL,
	[art_Garantia] [nvarchar](100) NULL,
	[art_Modelo] [nvarchar](100) NULL,
	[art_Unidad] [nvarchar](100) NULL,
	[art_UnidadFriltro] [nvarchar](100) NULL,
	[art_Medida] [nvarchar](100) NULL,
	[art_Catg] [nvarchar](100) NULL,
	[art_SubCatg] [nvarchar](100) NULL,
	[art_Procedencia] [nvarchar](100) NULL,
	[art_serial] [nvarchar](100) NULL,
	[art_Tipo] [nvarchar](20) NULL,
 CONSTRAINT [PK__Articulo__C4794368498B17F8] PRIMARY KEY CLUSTERED 
(
	[art_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Atributos]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atributos](
	[Atrib_id] [nvarchar](50) NOT NULL,
	[Atrib_descripcion] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Atrib_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[cat_id] [nvarchar](50) NOT NULL,
	[cat_descripcion] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cedula_Atributos]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cedula_Atributos](
	[cedula_AtribId] [nvarchar](50) NOT NULL,
	[cedula_CedulaID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CedAtributos] PRIMARY KEY CLUSTERED 
(
	[cedula_CedulaID] ASC,
	[cedula_AtribId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cedula_GastosFabrica]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cedula_GastosFabrica](
	[cedula_GastFabId] [nvarchar](50) NOT NULL,
	[cedula_CedulaID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CedGastosFab] PRIMARY KEY CLUSTERED 
(
	[cedula_CedulaID] ASC,
	[cedula_GastFabId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cedula_PerfilEmp]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cedula_PerfilEmp](
	[cedula_CedulaID] [nvarchar](50) NOT NULL,
	[cedula_perfilID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CedulaPerfil] PRIMARY KEY CLUSTERED 
(
	[cedula_perfilID] ASC,
	[cedula_CedulaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CedulaArticulos]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CedulaArticulos](
	[CedArt_CedulaID] [nvarchar](50) NOT NULL,
	[CedArt_ArticuloId] [nvarchar](50) NOT NULL,
	[CedArt_CodUnidad] [nvarchar](10) NOT NULL,
	[CedArt_CantUnidad] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CedArt_CedulaID] ASC,
	[CedArt_ArticuloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CedulaProducto]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CedulaProducto](
	[CedPro_Id] [nvarchar](50) NOT NULL,
	[CedPro_Descrip] [nvarchar](200) NOT NULL,
	[CedPro_Fecha] [date] NOT NULL,
	[CedPro_Unidad] [nvarchar](50) NOT NULL,
	[CedPro_Producto] [nvarchar](200) NOT NULL,
	[CedPro_Duracion] [int] NOT NULL,
	[CedPro_DuracionHoraDias] [nvarchar](50) NOT NULL,
	[CedPro_Cantidad] [int] NOT NULL,
	[CedPro_UnidadEstandar] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CedPro_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CedulaTareas]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CedulaTareas](
	[CedTarea_IdCedProd] [nvarchar](50) NOT NULL,
	[CedTarea_IdTarea] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CedulaTareas] PRIMARY KEY CLUSTERED 
(
	[CedTarea_IdCedProd] ASC,
	[CedTarea_IdTarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CodigoArticulo]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CodigoArticulo](
	[CodArt_Id] [int] IDENTITY(0,1) NOT NULL,
	[CodArt_Cod] [nvarchar](4) NULL,
	[CodArt_Descrip] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[CodArt_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[empresa]    Script Date: 13/10/2020 12:17:45 ******/
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
	[empr_moneda] [int] NOT NULL,
	[empr_contacto] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_empresa] PRIMARY KEY CLUSTERED 
(
	[empr_dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EstatusdeMaquinas]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstatusdeMaquinas](
	[EstMaq_id] [nvarchar](50) NOT NULL,
	[EstMaq_descripcion] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EstMaq_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FallasMaquina]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FallasMaquina](
	[FallasMaq_Id] [nvarchar](50) NOT NULL,
	[FallaMaq_Descripcion] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[FallasMaq_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GastosFabrica]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GastosFabrica](
	[GastosFab_id] [nvarchar](50) NOT NULL,
	[GastosFab_descripcion] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GastosFab_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[Inv_CodArt] [nvarchar](50) NOT NULL,
	[Inv_Fecha] [nvarchar](50) NOT NULL,
	[Inv_TipoMov] [nvarchar](50) NOT NULL,
	[Inv_Almacen] [nvarchar](150) NOT NULL,
	[Inv_Cantidad] [int] NOT NULL,
	[Inv_Unidad] [nvarchar](50) NOT NULL,
	[Inv_Proceso] [nvarchar](200) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inventario_Procesos]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario_Procesos](
	[Proc_Codigo] [nvarchar](50) NOT NULL,
	[Proc_Descrip] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Proc_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inventario_TipoMov]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario_TipoMov](
	[TipoMov_Codigo] [nvarchar](50) NOT NULL,
	[TipoMov_Descrip] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoMov_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Maquinas]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maquinas](
	[Maq_id] [nvarchar](50) NOT NULL,
	[Maq_descripcion] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Maq_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OpcionesGenerales]    Script Date: 13/10/2020 12:17:45 ******/
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
/****** Object:  Table [dbo].[PerfilesEmpleados]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilesEmpleados](
	[PerfilesEmp_Id] [nvarchar](50) NOT NULL,
	[PerfilesEmp_Descripcion] [nvarchar](200) NOT NULL,
	[PefilEmp_Sueldo] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK__Perfiles__CE0CC38CACE233FA] PRIMARY KEY CLUSTERED 
(
	[PerfilesEmp_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Procedencia]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Procedencia](
	[Proc_Id] [nvarchar](50) NOT NULL,
	[Proc_Descripcion] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Proc_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[prov_id] [int] IDENTITY(0,1) NOT NULL,
	[prov_nom] [nvarchar](100) NOT NULL,
	[prov_tipo] [nvarchar](30) NOT NULL,
	[prov_resp] [nvarchar](30) NOT NULL,
	[prov_telf1] [nvarchar](50) NOT NULL,
	[prov_telf2] [nvarchar](50) NOT NULL,
	[prov_direc] [nvarchar](300) NOT NULL,
	[prov_pais] [nvarchar](30) NOT NULL,
	[prov_estado] [nvarchar](30) NOT NULL,
	[prov_ciudad] [nvarchar](30) NOT NULL,
	[prov_municipio] [nvarchar](30) NOT NULL,
	[prov_tipoPersoJ] [nvarchar](30) NOT NULL,
	[prov_Rif] [nvarchar](100) NOT NULL,
	[prov_Fax] [nvarchar](30) NULL,
	[prov_Fecha] [date] NOT NULL,
	[prov_diasCred] [nvarchar](10) NULL,
	[prov_limiteCred] [nvarchar](10) NULL,
	[prov_Coment] [nvarchar](100) NULL,
	[prov_email] [nchar](100) NOT NULL,
	[prov_Referencia] [nchar](100) NULL,
 CONSTRAINT [PK__Proveedo__435F53268A8B548A] PRIMARY KEY CLUSTERED 
(
	[prov_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockArticulo]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockArticulo](
	[stock_ArtCod] [smallint] NULL,
	[stock_Minimo] [int] NULL,
	[stock_Maximo] [int] NULL,
	[stock_DiasInventaMin] [int] NULL,
	[stock_DiasInventaMax] [int] NULL,
	[stock_TiemDespacMin] [int] NULL,
	[stock_DiasDespaMax] [int] NULL,
	[stock_ptoPedido] [int] NULL,
	[stock_DiasPuntoReord] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubCategoria]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategoria](
	[SubCat_Id] [nvarchar](50) NOT NULL,
	[SubCat_codCat] [nvarchar](50) NOT NULL,
	[SubCat_Descripcion] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubCat_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sucursal_Almacen]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal_Almacen](
	[alm_succod] [int] NOT NULL,
	[alm_almcod] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[alm_succod] ASC,
	[alm_almcod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sucursales]    Script Date: 13/10/2020 12:17:45 ******/
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
 CONSTRAINT [PK__Sucursal__E256D492A1B632B4] PRIMARY KEY CLUSTERED 
(
	[suc_cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SucursalMoneda]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SucursalMoneda](
	[SucMon_codSuc] [int] NOT NULL,
	[SucMon_codMon] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SucMon_codSuc] ASC,
	[SucMon_codMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tareas]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tareas](
	[Tareas_Id] [nvarchar](50) NOT NULL,
	[Tareas_Descripcion] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK__Tareas__ADC034E39693EC92] PRIMARY KEY CLUSTERED 
(
	[Tareas_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TareasAtributos]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TareasAtributos](
	[TareasAtrib_TareaId] [nvarchar](50) NOT NULL,
	[TareasAtrib_AtribId] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TareasAtrib_TareaId] ASC,
	[TareasAtrib_AtribId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TareasMaquinas]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TareasMaquinas](
	[TareasMaq_TareaId] [nvarchar](50) NOT NULL,
	[TareasMaq_MaqId] [nvarchar](50) NOT NULL,
	[TareasMaq_CodUnidad] [nvarchar](10) NULL,
	[TareasMaq_CantUnidad] [decimal](18, 0) NULL,
	[TareasMaq_CodUnidadTrab] [nvarchar](10) NULL,
	[TareasMaq_CantUnidadTrab] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[TareasMaq_TareaId] ASC,
	[TareasMaq_MaqId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Unidades]    Script Date: 13/10/2020 12:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unidades](
	[Uni_Id] [nvarchar](50) NOT NULL,
	[Uni_Desc] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Uni_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Almacenes] ON 

GO
INSERT [dbo].[Almacenes] ([alm_cod], [alm_nombre], [alm_desc], [alm_dir], [alm_contacto], [alm_telef1], [alm_telef2], [alm_fechaCreacion], [alm_eliminado]) VALUES (1, N'Almacen de Empresa Digitel', N'Almacen cuatro de caracas con ofina 004 en contruccion', N'Calle Real de Los Frailes de con esquina el socorro, Caracas', N'Karina Herrera', N'02125046834', N'0212504-6834', N'2019-08-27', 0)
GO
INSERT [dbo].[Almacenes] ([alm_cod], [alm_nombre], [alm_desc], [alm_dir], [alm_contacto], [alm_telef1], [alm_telef2], [alm_fechaCreacion], [alm_eliminado]) VALUES (2, N'Centro de distribución "La garita". Empresa Digitel', N'Almacen pincipal', N'Av. Francisco de miranda, Altamira Torre Digitel', N'Angel Perez', N'04128996514', N'02126558792', N'2019-08-27', 0)
GO
INSERT [dbo].[Almacenes] ([alm_cod], [alm_nombre], [alm_desc], [alm_dir], [alm_contacto], [alm_telef1], [alm_telef2], [alm_fechaCreacion], [alm_eliminado]) VALUES (3, N'Almacenes CFG. Digitel', N'Almacenes CFG. Digitel, en recuperacion para 2020', N'Av. Intercomunal Valle-Coche', N'Sarahi Quintero', N'04128226870', N'04169198413', N'2019-08-27', 0)
GO
INSERT [dbo].[Almacenes] ([alm_cod], [alm_nombre], [alm_desc], [alm_dir], [alm_contacto], [alm_telef1], [alm_telef2], [alm_fechaCreacion], [alm_eliminado]) VALUES (4, N'Almacen Zulia 1500- Digitel', N'Almacen para productos importadod', N'Calle el Juez,Edo Zulia', N'Lucia Figuera', N'04128221523', N'04169198000', N'2019-08-28', 0)
GO
INSERT [dbo].[Almacenes] ([alm_cod], [alm_nombre], [alm_desc], [alm_dir], [alm_contacto], [alm_telef1], [alm_telef2], [alm_fechaCreacion], [alm_eliminado]) VALUES (5, N'almacen 203-Digitel', N'Almacen Secundario', N'Av. Intercomunal Francisco Fajardo', N'Luis Angel', N'04169198413', N'04129198555', N'2019-08-28', 0)
GO
INSERT [dbo].[Almacenes] ([alm_cod], [alm_nombre], [alm_desc], [alm_dir], [alm_contacto], [alm_telef1], [alm_telef2], [alm_fechaCreacion], [alm_eliminado]) VALUES (6, N'almacen 204-Digitel', N'Almacen en mal estado', N'Av. Intercomunal Francisco Fajardo. calle oeste', N'Luis Angel', N'04169198413', N'04129198555', N'2019-09-04', 0)
GO
SET IDENTITY_INSERT [dbo].[Almacenes] OFF
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'CED001', N'Prueba1', N'10', N'SDF5DS5FS', N'cg', N'0', N'0', N'C001', N'S1C', N'Contruido en galpon 00236', N'DSFSD4020', N'CED')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'CED002', N'Articulos Produccion', N'10', N'XSNWQP012SD', N'tn', N'0', N'0', N'C001', N'S1C', N'Contruido en galpon 00236', N'DSFSD402012', N'CED')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTA00', N'Aceite Ligero', N'30', N'Aceite Ligero 001', N'kg', N'0', N'2', N'C002', N'MZ005', N'Importado', N'A00-001', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTAG', N'Agua Limpia', N'30', N'Agua Purificada', N'cg', N'0', N'15', N'L1', N'SA01', N'Extranjero', N'No Aplica', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTB001', N'Baja Blanca especial 25', N'30', N'Traje de laboratorio 25', N'tn', N'0', N'0', N'UT001', N'UL002', N'Contruido en galpon 00236', N'XD-14141-KJ', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTC001', N'Cuero', N'30', N'Cuero Fino', N'kg', N'0', N'15', N'C002', N'MZ001', N'Importado', N'C001-INT', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTGA001', N'Guantes de Asbesto', N'30', N'Guantes de Asbesto Balncos', N'cg', N'0', N'0', N'UT001', N'UL001', N'Contruido en galpon 00236', N'00221001214-SAA3', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTH003', N'Hilo Negro', N'30', N'Hilo Negro Satinado', N'tn', N'0', N'0', N'C002', N'MZ006', N'Nacional', N'H003', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTR001', N'Router', N'13', N'FSEAF', N'kg', N'0', N'0', N'C1', N'S2A', N'Importado', N'16546954', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTS00', N'Suela ExtraFuerte', N'30', N'Suela ExtraFuerte N*15', N'cg', N'0', N'30', N'C002', N'MZ002', N'Importado', N'S00-EF012', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'VEN002', N'Tarjetas Madre', N'10', N'Asus', N'tn', N'0', N'0', N'C001', N'SC3', N'Contruido en galpon 00236', N'A68SD-KA2MD', N'VEN')
GO
INSERT [dbo].[Atributos] ([Atrib_id], [Atrib_descripcion]) VALUES (N'ACL', N'Solucion Transparente')
GO
INSERT [dbo].[Atributos] ([Atrib_id], [Atrib_descripcion]) VALUES (N'C003', N'Color azul')
GO
INSERT [dbo].[Atributos] ([Atrib_id], [Atrib_descripcion]) VALUES (N'C02', N'Color marron ')
GO
INSERT [dbo].[Atributos] ([Atrib_id], [Atrib_descripcion]) VALUES (N'Z001', N'Verde')
GO
INSERT [dbo].[Atributos] ([Atrib_id], [Atrib_descripcion]) VALUES (N'Z002', N'Negro')
GO
INSERT [dbo].[Atributos] ([Atrib_id], [Atrib_descripcion]) VALUES (N'Z003', N'Base Suave')
GO
INSERT [dbo].[Categorias] ([cat_id], [cat_descripcion]) VALUES (N'C001', N'Computradoras')
GO
INSERT [dbo].[Categorias] ([cat_id], [cat_descripcion]) VALUES (N'C002', N'Material Zapatos')
GO
INSERT [dbo].[Categorias] ([cat_id], [cat_descripcion]) VALUES (N'C1', N'Art. para Escribir')
GO
INSERT [dbo].[Categorias] ([cat_id], [cat_descripcion]) VALUES (N'L1', N'Agua')
GO
INSERT [dbo].[Categorias] ([cat_id], [cat_descripcion]) VALUES (N'UT001', N'Utensilios de laboratorio')
GO
INSERT [dbo].[Cedula_Atributos] ([cedula_AtribId], [cedula_CedulaID]) VALUES (N'ACL', N'CEDP001')
GO
INSERT [dbo].[Cedula_Atributos] ([cedula_AtribId], [cedula_CedulaID]) VALUES (N'C003', N'CEDP001')
GO
INSERT [dbo].[Cedula_Atributos] ([cedula_AtribId], [cedula_CedulaID]) VALUES (N'ACL', N'CEDP002')
GO
INSERT [dbo].[Cedula_Atributos] ([cedula_AtribId], [cedula_CedulaID]) VALUES (N'C003', N'CEDP002')
GO
INSERT [dbo].[Cedula_Atributos] ([cedula_AtribId], [cedula_CedulaID]) VALUES (N'C003', N'CEDP003')
GO
INSERT [dbo].[Cedula_Atributos] ([cedula_AtribId], [cedula_CedulaID]) VALUES (N'C02', N'CEDP003')
GO
INSERT [dbo].[Cedula_GastosFabrica] ([cedula_GastFabId], [cedula_CedulaID]) VALUES (N'123', N'CEDP001')
GO
INSERT [dbo].[Cedula_GastosFabrica] ([cedula_GastFabId], [cedula_CedulaID]) VALUES (N'AAA123', N'CEDP001')
GO
INSERT [dbo].[Cedula_GastosFabrica] ([cedula_GastFabId], [cedula_CedulaID]) VALUES (N'123', N'CEDP002')
GO
INSERT [dbo].[Cedula_GastosFabrica] ([cedula_GastFabId], [cedula_CedulaID]) VALUES (N'AAA123', N'CEDP002')
GO
INSERT [dbo].[Cedula_GastosFabrica] ([cedula_GastFabId], [cedula_CedulaID]) VALUES (N'123', N'CEDP003')
GO
INSERT [dbo].[Cedula_PerfilEmp] ([cedula_CedulaID], [cedula_perfilID]) VALUES (N'CEDP001', N'MH')
GO
INSERT [dbo].[Cedula_PerfilEmp] ([cedula_CedulaID], [cedula_perfilID]) VALUES (N'CEDP002', N'MH')
GO
INSERT [dbo].[Cedula_PerfilEmp] ([cedula_CedulaID], [cedula_perfilID]) VALUES (N'CEDP003', N'MH')
GO
INSERT [dbo].[Cedula_PerfilEmp] ([cedula_CedulaID], [cedula_perfilID]) VALUES (N'CEDP001', N'PE')
GO
INSERT [dbo].[Cedula_PerfilEmp] ([cedula_CedulaID], [cedula_perfilID]) VALUES (N'CEDP002', N'PE')
GO
INSERT [dbo].[CedulaArticulos] ([CedArt_CedulaID], [CedArt_ArticuloId], [CedArt_CodUnidad], [CedArt_CantUnidad]) VALUES (N'CEDP001', N'CED001', N'dam', CAST(1 AS Decimal(18, 0)))
GO
INSERT [dbo].[CedulaArticulos] ([CedArt_CedulaID], [CedArt_ArticuloId], [CedArt_CodUnidad], [CedArt_CantUnidad]) VALUES (N'CEDP001', N'CED002', N'in', CAST(2 AS Decimal(18, 0)))
GO
INSERT [dbo].[CedulaArticulos] ([CedArt_CedulaID], [CedArt_ArticuloId], [CedArt_CodUnidad], [CedArt_CantUnidad]) VALUES (N'CEDP001', N'INTA00', N'ft', CAST(225 AS Decimal(18, 0)))
GO
INSERT [dbo].[CedulaArticulos] ([CedArt_CedulaID], [CedArt_ArticuloId], [CedArt_CodUnidad], [CedArt_CantUnidad]) VALUES (N'CEDP001', N'INTB001', N'hm', CAST(125 AS Decimal(18, 0)))
GO
INSERT [dbo].[CedulaArticulos] ([CedArt_CedulaID], [CedArt_ArticuloId], [CedArt_CodUnidad], [CedArt_CantUnidad]) VALUES (N'CEDP002', N'CED001', N'cm', CAST(1 AS Decimal(18, 0)))
GO
INSERT [dbo].[CedulaArticulos] ([CedArt_CedulaID], [CedArt_ArticuloId], [CedArt_CodUnidad], [CedArt_CantUnidad]) VALUES (N'CEDP002', N'INTA00', N'dam', CAST(0 AS Decimal(18, 0)))
GO
INSERT [dbo].[CedulaArticulos] ([CedArt_CedulaID], [CedArt_ArticuloId], [CedArt_CodUnidad], [CedArt_CantUnidad]) VALUES (N'CEDP003', N'CED002', N'dam', CAST(20 AS Decimal(18, 0)))
GO
INSERT [dbo].[CedulaProducto] ([CedPro_Id], [CedPro_Descrip], [CedPro_Fecha], [CedPro_Unidad], [CedPro_Producto], [CedPro_Duracion], [CedPro_DuracionHoraDias], [CedPro_Cantidad], [CedPro_UnidadEstandar]) VALUES (N'CEDP001', N'cedula Producto 01', CAST(N'2020-03-03' AS Date), N'cg', N'Prueba1', 20, N'Horas', 121, 0)
GO
INSERT [dbo].[CedulaProducto] ([CedPro_Id], [CedPro_Descrip], [CedPro_Fecha], [CedPro_Unidad], [CedPro_Producto], [CedPro_Duracion], [CedPro_DuracionHoraDias], [CedPro_Cantidad], [CedPro_UnidadEstandar]) VALUES (N'CEDP002', N'produccion de Camisas', CAST(N'2020-03-03' AS Date), N'tn', N'Prueba1', 2, N'Días', 10, 0)
GO
INSERT [dbo].[CedulaProducto] ([CedPro_Id], [CedPro_Descrip], [CedPro_Fecha], [CedPro_Unidad], [CedPro_Producto], [CedPro_Duracion], [CedPro_DuracionHoraDias], [CedPro_Cantidad], [CedPro_UnidadEstandar]) VALUES (N'CEDP003', N'Cajas de Calzado Femenino', CAST(N'2020-03-10' AS Date), N'kg', N'Prueba1', 10, N'Días', 100, 0)
GO
INSERT [dbo].[CedulaTareas] ([CedTarea_IdCedProd], [CedTarea_IdTarea]) VALUES (N'CEDP001', N'TAR003')
GO
INSERT [dbo].[CedulaTareas] ([CedTarea_IdCedProd], [CedTarea_IdTarea]) VALUES (N'CEDP002', N'TAR003')
GO
INSERT [dbo].[CedulaTareas] ([CedTarea_IdCedProd], [CedTarea_IdTarea]) VALUES (N'CEDP003', N'TAR003')
GO
SET IDENTITY_INSERT [dbo].[CodigoArticulo] ON 

GO
INSERT [dbo].[CodigoArticulo] ([CodArt_Id], [CodArt_Cod], [CodArt_Descrip]) VALUES (0, N'VEN', N'Venta')
GO
INSERT [dbo].[CodigoArticulo] ([CodArt_Id], [CodArt_Cod], [CodArt_Descrip]) VALUES (1, N'INT', N'Interno')
GO
INSERT [dbo].[CodigoArticulo] ([CodArt_Id], [CodArt_Cod], [CodArt_Descrip]) VALUES (2, N'CED', N'Cedula')
GO
SET IDENTITY_INSERT [dbo].[CodigoArticulo] OFF
GO
INSERT [dbo].[EstatusdeMaquinas] ([EstMaq_id], [EstMaq_descripcion]) VALUES (N'R3', N'Falta de Lubricante')
GO
INSERT [dbo].[EstatusdeMaquinas] ([EstMaq_id], [EstMaq_descripcion]) VALUES (N'ZZZ', N'zzzzzzzz')
GO
INSERT [dbo].[FallasMaquina] ([FallasMaq_Id], [FallaMaq_Descripcion]) VALUES (N'F1', N'Motor quemado')
GO
INSERT [dbo].[FallasMaquina] ([FallasMaq_Id], [FallaMaq_Descripcion]) VALUES (N'F4', N'Valvulas Danadas')
GO
INSERT [dbo].[GastosFabrica] ([GastosFab_id], [GastosFab_descripcion]) VALUES (N'123', N'123456')
GO
INSERT [dbo].[GastosFabrica] ([GastosFab_id], [GastosFab_descripcion]) VALUES (N'AAA123', N'123123')
GO
INSERT [dbo].[GastosFabrica] ([GastosFab_id], [GastosFab_descripcion]) VALUES (N'COM', N'COMBUSTIBLE')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', N'25/09/2020', N'COM', N'Almacen de Empresa Digitel', 0, N'cg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', N'25/09/2020', N'COM', N'almacen 203-Digitel', 0, N'cg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Agua Limpia', N'25/09/2020', N'COM', N'almacen 204-Digitel', 15, N'cg', N'SAL')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', N'28/09/2020', N'COM', N'Centro de distribución "La garita". Empresa Digitel', 0, N'cg', N'SAL')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Aceite Ligero', N'28/09/2020', N'VENT', N'almacen 204-Digitel', 2, N'kg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', N'28/09/2020', N'VENT', N'Almacen de Empresa Digitel', 0, N'cg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Articulos Produccion', N'28/09/2020', N'PROD', N'Almacenes CFG. Digitel', 0, N'tn', N'SAL')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', N'10/08/2020', N'COM', N'Centro de distribución "La garita". Empresa Digitel', 0, N'cg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Tarjetas Madre', N'09/05/1996', N'COM', N'Centro de distribución "La garita". Empresa Digitel', 0, N'tn', N'AJUS')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', N'07/10/2020', N'COM', N'Centro de distribución "La garita". Empresa Digitel', 0, N'cg', N'AJUS')
GO
INSERT [dbo].[Inventario_Procesos] ([Proc_Codigo], [Proc_Descrip]) VALUES (N'AJUS', N'Ajuste')
GO
INSERT [dbo].[Inventario_Procesos] ([Proc_Codigo], [Proc_Descrip]) VALUES (N'ENT', N'Entrada')
GO
INSERT [dbo].[Inventario_Procesos] ([Proc_Codigo], [Proc_Descrip]) VALUES (N'SAL', N'Salida')
GO
INSERT [dbo].[Inventario_TipoMov] ([TipoMov_Codigo], [TipoMov_Descrip]) VALUES (N'COM', N'Compra')
GO
INSERT [dbo].[Inventario_TipoMov] ([TipoMov_Codigo], [TipoMov_Descrip]) VALUES (N'PROD', N'Producción')
GO
INSERT [dbo].[Inventario_TipoMov] ([TipoMov_Codigo], [TipoMov_Descrip]) VALUES (N'TRAS', N'Traslado')
GO
INSERT [dbo].[Inventario_TipoMov] ([TipoMov_Codigo], [TipoMov_Descrip]) VALUES (N'VENT', N'Venta')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ001', N'Etiquetadora')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ002', N'Cortadora')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ003', N'Lijadoras para madera Orbitales')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ004', N'Lijadoras Multifunción')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ005', N'Lijadora de Disco')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ006', N'Taladro angular')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ007', N'Dremel')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ008', N'Pulidora rotatoria')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ009', N'Pulidora de Doble Acción')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ010', N'Tijeras de Esculpir')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ011', N'Tijeras de Sastre')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ012', N'Tijeras de applique')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ013', N'Calibradores')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ014', N'Sierras')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ015', N'Esmerilador angular')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ016', N'Pistolas de calor')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ017', N'Fresadoras')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ018', N'Martillos Giratorios')
GO
INSERT [dbo].[Maquinas] ([Maq_id], [Maq_descripcion]) VALUES (N'MAQ019', N'Destornillador Eletrico')
GO
SET IDENTITY_INSERT [dbo].[OpcionesGenerales] ON 

GO
INSERT [dbo].[OpcionesGenerales] ([OpcionesGen_Id], [OpcionesGen_CodModulo], [OpcionesGen_Nombre], [OpcionesGen_Valor], [OpcionesGen_Configurar]) VALUES (0, 4, N'Configurar Decimales', N'Punto (.)', 1)
GO
SET IDENTITY_INSERT [dbo].[OpcionesGenerales] OFF
GO
INSERT [dbo].[PerfilesEmpleados] ([PerfilesEmp_Id], [PerfilesEmp_Descripcion], [PefilEmp_Sueldo]) VALUES (N'MH', N'MHHH', CAST(140 AS Decimal(18, 0)))
GO
INSERT [dbo].[PerfilesEmpleados] ([PerfilesEmp_Id], [PerfilesEmp_Descripcion], [PefilEmp_Sueldo]) VALUES (N'PE', N'DIRECTOR editado', CAST(23658 AS Decimal(18, 0)))
GO
INSERT [dbo].[PerfilesEmpleados] ([PerfilesEmp_Id], [PerfilesEmp_Descripcion], [PefilEmp_Sueldo]) VALUES (N'PE02', N'EDITADO', CAST(152 AS Decimal(18, 0)))
GO
INSERT [dbo].[Procedencia] ([Proc_Id], [Proc_Descripcion]) VALUES (N'c14', N'Contruido en galpon 00236')
GO
INSERT [dbo].[Procedencia] ([Proc_Id], [Proc_Descripcion]) VALUES (N'M14', N'Extranjero')
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

GO
INSERT [dbo].[Proveedores] ([prov_id], [prov_nom], [prov_tipo], [prov_resp], [prov_telf1], [prov_telf2], [prov_direc], [prov_pais], [prov_estado], [prov_ciudad], [prov_municipio], [prov_tipoPersoJ], [prov_Rif], [prov_Fax], [prov_Fecha], [prov_diasCred], [prov_limiteCred], [prov_Coment], [prov_email], [prov_Referencia]) VALUES (0, N'Distribuciones TecnoPORT, Soluciones E.T', N'Extranjero', N'Juan Camejo', N'04123665987', N'02123664587', N'Av. Intercomunal Fco. Miranda, Los Rosales', N'Venezuela', N'Dtto. Capital', N'Caracas', N'Libertador', N'Juridica-Domicialado', N'J303441151', N'0998 455879', CAST(N'2019-09-17' AS Date), N'0', N'0', N'sin comentarios...', N'JCamejo@TecnoPort.com.ve                                                                            ', N'Servicios                                                                                           ')
GO
INSERT [dbo].[Proveedores] ([prov_id], [prov_nom], [prov_tipo], [prov_resp], [prov_telf1], [prov_telf2], [prov_direc], [prov_pais], [prov_estado], [prov_ciudad], [prov_municipio], [prov_tipoPersoJ], [prov_Rif], [prov_Fax], [prov_Fecha], [prov_diasCred], [prov_limiteCred], [prov_Coment], [prov_email], [prov_Referencia]) VALUES (1, N'Distribuidora Nube Azul CA', N'Nacional', N'Karine Verde', N'(0212)242.1111', N'(0212)241.8132', N'Calle 10, con Calle 11, Edif. Plasencia, PB, Local S/N, La Urbina, Caracas', N'Venezuela', N'Dtto. Capital', N'Caracas', N'Libertador', N'Juridica-Domicialado', N'J563227756-8', N'', CAST(N'2019-09-17' AS Date), N'0', N'0', N'sin comentarios...', N'KVerde@NubeAzul.com.ve                                                                              ', N'Servicios                                                                                           ')
GO
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'MZ001', N'C002', N'Cuero')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'MZ002', N'C002', N'Suela')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'MZ003', N'C002', N'Sintetico')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'MZ004', N'C002', N'Crepe')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'MZ005', N'C002', N'Aceitado')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'MZ006', N'C002', N'Hilos')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'S1A', N'C1', N'Lapiz Mongol')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'S1C', N'C001', N'Monitor')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'S2A', N'C1', N'Boligrafo')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'S2C', N'C001', N'Mouse')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'S4C', N'C001', N'Disco Duro')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'SA01', N'L1', N'Agua Liquida Purificada')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'SC3', N'C001', N'Tarjeta Madre')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'UL001', N'UT001', N'Guantes')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'UL002', N'UT001', N'Bata Blanca')
GO
INSERT [dbo].[SubCategoria] ([SubCat_Id], [SubCat_codCat], [SubCat_Descripcion]) VALUES (N'UL003', N'UT001', N'Traje de Proteccion Quimica')
GO
INSERT [dbo].[Sucursal_Almacen] ([alm_succod], [alm_almcod]) VALUES (0, 6)
GO
INSERT [dbo].[Sucursal_Almacen] ([alm_succod], [alm_almcod]) VALUES (2, 5)
GO
SET IDENTITY_INSERT [dbo].[Sucursales] ON 

GO
INSERT [dbo].[Sucursales] ([suc_cod], [suc_descripcion], [suc_dir], [suc_telf1], [suc_telf2], [suc_email], [suc_eliminadas], [suc_fechaCreacion], [suc_nombre], [suc_contacto]) VALUES (0, N'Sucursal bellas Artes, por ahoro solo telefonos locales', N'Av. Bellas Artes, parque Caracas', N'04128996514', N'02126558792', N'digitelBellasArtes@digitel.com.ve', 0, CAST(N'2019-08-26' AS Date), N'Digitel-Sucursal Bellas Artes', N'Juan Godoy')
GO
INSERT [dbo].[Sucursales] ([suc_cod], [suc_descripcion], [suc_dir], [suc_telf1], [suc_telf2], [suc_email], [suc_eliminadas], [suc_fechaCreacion], [suc_nombre], [suc_contacto]) VALUES (2, N'Sucursal De tachira En remodelacion.', N'Av. Bolivar, calle los Rosales', N'02543625987', N'02126235487', N'digitelTachira@Gmail.com', 0, CAST(N'2019-08-26' AS Date), N'Sucursal de Tachira.', N'Felipe Hernandez')
GO
INSERT [dbo].[Sucursales] ([suc_cod], [suc_descripcion], [suc_dir], [suc_telf1], [suc_telf2], [suc_email], [suc_eliminadas], [suc_fechaCreacion], [suc_nombre], [suc_contacto]) VALUES (3, N'Solo telefonos ceulares y repuestos', N'Local Chacaito, diagonal al Sambil. Edif. Roa', N'04128996800', N'02126512192', N'digitelchacaito@digitel.com.ve', 0, CAST(N'2019-08-26' AS Date), N'Digitel Sucursal-Chacaito', N'Alejandro Hernandez')
GO
INSERT [dbo].[Sucursales] ([suc_cod], [suc_descripcion], [suc_dir], [suc_telf1], [suc_telf2], [suc_email], [suc_eliminadas], [suc_fechaCreacion], [suc_nombre], [suc_contacto]) VALUES (4, N'En reparacion', N'Av. Fco Fajardo, calle los Rosales', N'02126235487', N'02126235489', N'digitelaltamira@digitel.com.ve', 0, CAST(N'2019-09-04' AS Date), N'Sucursal Altamira', N'Jose Maria Inglesia')
GO
INSERT [dbo].[Sucursales] ([suc_cod], [suc_descripcion], [suc_dir], [suc_telf1], [suc_telf2], [suc_email], [suc_eliminadas], [suc_fechaCreacion], [suc_nombre], [suc_contacto]) VALUES (5, N'Sucusal Colombia 004', N'Av. Angel Doce, calle Leon joftre', N'04123662569', N'02121445879', N'Colombia@digitel.com.ve', 0, CAST(N'2019-09-09' AS Date), N'Sucursal Colombia', N'Miguel Angel')
GO
INSERT [dbo].[Sucursales] ([suc_cod], [suc_descripcion], [suc_dir], [suc_telf1], [suc_telf2], [suc_email], [suc_eliminadas], [suc_fechaCreacion], [suc_nombre], [suc_contacto]) VALUES (6, N'Sucusal Colombia 015', N'Av. Intercomunal Los frailes, cuadra los magos. Edi. Digitel', N'04128996514', N'02126235487', N'Colombia@digitel.com.ve', 0, CAST(N'2019-09-10' AS Date), N'Sucursal Colombia principal', N'Ana Delgado')
GO
INSERT [dbo].[Sucursales] ([suc_cod], [suc_descripcion], [suc_dir], [suc_telf1], [suc_telf2], [suc_email], [suc_eliminadas], [suc_fechaCreacion], [suc_nombre], [suc_contacto]) VALUES (7, N'Sucusal Panama ofic. Principal', N'Peblo Zaragosa, area los juaneses. Edi. Digitel', N'02126231111', N'02126235487', N'Panama15@digitel.com.ve', 0, CAST(N'2019-09-10' AS Date), N'Sucursal Panama principal', N'Ana Florez')
GO
INSERT [dbo].[Sucursales] ([suc_cod], [suc_descripcion], [suc_dir], [suc_telf1], [suc_telf2], [suc_email], [suc_eliminadas], [suc_fechaCreacion], [suc_nombre], [suc_contacto]) VALUES (8, N'Sucusal Panama En contruccion', N'Ciudad de Parama, La india edif. Los verdes', N'04128996659', N'02126212217', N'Panama15@digitel.com.ve', 0, CAST(N'2019-09-10' AS Date), N'Sucursal Panama 001', N'Tomas Verde')
GO
SET IDENTITY_INSERT [dbo].[Sucursales] OFF
GO
INSERT [dbo].[SucursalMoneda] ([SucMon_codSuc], [SucMon_codMon]) VALUES (0, 0)
GO
INSERT [dbo].[SucursalMoneda] ([SucMon_codSuc], [SucMon_codMon]) VALUES (0, 1)
GO
INSERT [dbo].[SucursalMoneda] ([SucMon_codSuc], [SucMon_codMon]) VALUES (0, 2)
GO
INSERT [dbo].[SucursalMoneda] ([SucMon_codSuc], [SucMon_codMon]) VALUES (0, 4)
GO
INSERT [dbo].[SucursalMoneda] ([SucMon_codSuc], [SucMon_codMon]) VALUES (2, 3)
GO
INSERT [dbo].[SucursalMoneda] ([SucMon_codSuc], [SucMon_codMon]) VALUES (4, 4)
GO
INSERT [dbo].[SucursalMoneda] ([SucMon_codSuc], [SucMon_codMon]) VALUES (5, 5)
GO
INSERT [dbo].[SucursalMoneda] ([SucMon_codSuc], [SucMon_codMon]) VALUES (6, 0)
GO
INSERT [dbo].[SucursalMoneda] ([SucMon_codSuc], [SucMon_codMon]) VALUES (6, 1)
GO
INSERT [dbo].[SucursalMoneda] ([SucMon_codSuc], [SucMon_codMon]) VALUES (6, 4)
GO
INSERT [dbo].[SucursalMoneda] ([SucMon_codSuc], [SucMon_codMon]) VALUES (7, 0)
GO
INSERT [dbo].[SucursalMoneda] ([SucMon_codSuc], [SucMon_codMon]) VALUES (8, 0)
GO
INSERT [dbo].[SucursalMoneda] ([SucMon_codSuc], [SucMon_codMon]) VALUES (8, 4)
GO
INSERT [dbo].[Tareas] ([Tareas_Id], [Tareas_Descripcion]) VALUES (N'TAR003', N'Fabricacion de Zapatos')
GO
INSERT [dbo].[TareasAtributos] ([TareasAtrib_TareaId], [TareasAtrib_AtribId]) VALUES (N'TAR003', N'ACL')
GO
INSERT [dbo].[TareasAtributos] ([TareasAtrib_TareaId], [TareasAtrib_AtribId]) VALUES (N'TAR003', N'C003')
GO
INSERT [dbo].[TareasMaquinas] ([TareasMaq_TareaId], [TareasMaq_MaqId], [TareasMaq_CodUnidad], [TareasMaq_CantUnidad], [TareasMaq_CodUnidadTrab], [TareasMaq_CantUnidadTrab]) VALUES (N'TAR003', N'MAQ002', N'dec', CAST(1 AS Decimal(18, 0)), N'cm', CAST(1 AS Decimal(18, 0)))
GO
INSERT [dbo].[TareasMaquinas] ([TareasMaq_TareaId], [TareasMaq_MaqId], [TareasMaq_CodUnidad], [TareasMaq_CantUnidad], [TareasMaq_CodUnidadTrab], [TareasMaq_CantUnidadTrab]) VALUES (N'TAR003', N'MAQ008', N'd', CAST(2 AS Decimal(18, 0)), N'dam', CAST(2 AS Decimal(18, 0)))
GO
INSERT [dbo].[TareasMaquinas] ([TareasMaq_TareaId], [TareasMaq_MaqId], [TareasMaq_CodUnidad], [TareasMaq_CantUnidad], [TareasMaq_CodUnidadTrab], [TareasMaq_CantUnidadTrab]) VALUES (N'TAR003', N'MAQ011', N'dec', CAST(3 AS Decimal(18, 0)), N'hm', CAST(3 AS Decimal(18, 0)))
GO
INSERT [dbo].[Unidades] ([Uni_Id], [Uni_Desc]) VALUES (N'NP', N'No Aplica')
GO
INSERT [dbo].[Unidades] ([Uni_Id], [Uni_Desc]) VALUES (N'U1', N'Kilos')
GO
INSERT [dbo].[Unidades] ([Uni_Id], [Uni_Desc]) VALUES (N'U2', N'Metros')
GO
INSERT [dbo].[Unidades] ([Uni_Id], [Uni_Desc]) VALUES (N'U3', N'Libras')
GO
INSERT [dbo].[Unidades] ([Uni_Id], [Uni_Desc]) VALUES (N'U4', N'Litros')
GO
INSERT [dbo].[Unidades] ([Uni_Id], [Uni_Desc]) VALUES (N'U5', N'Centimetros')
GO
ALTER TABLE [dbo].[Cedula_Atributos]  WITH CHECK ADD  CONSTRAINT [FK_cedula_AtributoId] FOREIGN KEY([cedula_AtribId])
REFERENCES [dbo].[Atributos] ([Atrib_id])
GO
ALTER TABLE [dbo].[Cedula_Atributos] CHECK CONSTRAINT [FK_cedula_AtributoId]
GO
ALTER TABLE [dbo].[Cedula_Atributos]  WITH CHECK ADD  CONSTRAINT [FK_cedula_CedulaId] FOREIGN KEY([cedula_CedulaID])
REFERENCES [dbo].[CedulaProducto] ([CedPro_Id])
GO
ALTER TABLE [dbo].[Cedula_Atributos] CHECK CONSTRAINT [FK_cedula_CedulaId]
GO
ALTER TABLE [dbo].[Cedula_GastosFabrica]  WITH CHECK ADD  CONSTRAINT [FK_cedula_CEdula] FOREIGN KEY([cedula_CedulaID])
REFERENCES [dbo].[CedulaProducto] ([CedPro_Id])
GO
ALTER TABLE [dbo].[Cedula_GastosFabrica] CHECK CONSTRAINT [FK_cedula_CEdula]
GO
ALTER TABLE [dbo].[Cedula_GastosFabrica]  WITH CHECK ADD  CONSTRAINT [FK_cedula_perfil] FOREIGN KEY([cedula_GastFabId])
REFERENCES [dbo].[GastosFabrica] ([GastosFab_id])
GO
ALTER TABLE [dbo].[Cedula_GastosFabrica] CHECK CONSTRAINT [FK_cedula_perfil]
GO
ALTER TABLE [dbo].[Cedula_PerfilEmp]  WITH CHECK ADD  CONSTRAINT [FK_CedulaPerfilEmp_CedulaProducto] FOREIGN KEY([cedula_CedulaID])
REFERENCES [dbo].[CedulaProducto] ([CedPro_Id])
GO
ALTER TABLE [dbo].[Cedula_PerfilEmp] CHECK CONSTRAINT [FK_CedulaPerfilEmp_CedulaProducto]
GO
ALTER TABLE [dbo].[Cedula_PerfilEmp]  WITH CHECK ADD  CONSTRAINT [FK_CedulaPerfilEmp_PerfilesEmpleados] FOREIGN KEY([cedula_perfilID])
REFERENCES [dbo].[PerfilesEmpleados] ([PerfilesEmp_Id])
GO
ALTER TABLE [dbo].[Cedula_PerfilEmp] CHECK CONSTRAINT [FK_CedulaPerfilEmp_PerfilesEmpleados]
GO
ALTER TABLE [dbo].[CedulaTareas]  WITH CHECK ADD  CONSTRAINT [FK_CedulaTareas_CedulaProducto] FOREIGN KEY([CedTarea_IdCedProd])
REFERENCES [dbo].[CedulaProducto] ([CedPro_Id])
GO
ALTER TABLE [dbo].[CedulaTareas] CHECK CONSTRAINT [FK_CedulaTareas_CedulaProducto]
GO
ALTER TABLE [dbo].[CedulaTareas]  WITH CHECK ADD  CONSTRAINT [FK_CedulaTareas_Tareas] FOREIGN KEY([CedTarea_IdTarea])
REFERENCES [dbo].[Tareas] ([Tareas_Id])
GO
ALTER TABLE [dbo].[CedulaTareas] CHECK CONSTRAINT [FK_CedulaTareas_Tareas]
GO
ALTER TABLE [dbo].[Sucursal_Almacen]  WITH CHECK ADD  CONSTRAINT [FK_Almacen_Sucursal_Empresa_Almacenes] FOREIGN KEY([alm_almcod])
REFERENCES [dbo].[Almacenes] ([alm_cod])
GO
ALTER TABLE [dbo].[Sucursal_Almacen] CHECK CONSTRAINT [FK_Almacen_Sucursal_Empresa_Almacenes]
GO
ALTER TABLE [dbo].[Sucursal_Almacen]  WITH CHECK ADD  CONSTRAINT [FK_Almacen_Sucursal_Empresa_Sucursales] FOREIGN KEY([alm_succod])
REFERENCES [dbo].[Sucursales] ([suc_cod])
GO
ALTER TABLE [dbo].[Sucursal_Almacen] CHECK CONSTRAINT [FK_Almacen_Sucursal_Empresa_Sucursales]
GO
ALTER TABLE [dbo].[SucursalMoneda]  WITH CHECK ADD  CONSTRAINT [FK_EmpresaMoneda_Sucursales] FOREIGN KEY([SucMon_codSuc])
REFERENCES [dbo].[Sucursales] ([suc_cod])
GO
ALTER TABLE [dbo].[SucursalMoneda] CHECK CONSTRAINT [FK_EmpresaMoneda_Sucursales]
GO
ALTER TABLE [dbo].[TareasAtributos]  WITH CHECK ADD  CONSTRAINT [FK_TareasAtributos_Atributos] FOREIGN KEY([TareasAtrib_AtribId])
REFERENCES [dbo].[Atributos] ([Atrib_id])
GO
ALTER TABLE [dbo].[TareasAtributos] CHECK CONSTRAINT [FK_TareasAtributos_Atributos]
GO
ALTER TABLE [dbo].[TareasAtributos]  WITH CHECK ADD  CONSTRAINT [FK_TareasAtributos_Tareas] FOREIGN KEY([TareasAtrib_TareaId])
REFERENCES [dbo].[Tareas] ([Tareas_Id])
GO
ALTER TABLE [dbo].[TareasAtributos] CHECK CONSTRAINT [FK_TareasAtributos_Tareas]
GO
ALTER TABLE [dbo].[TareasMaquinas]  WITH CHECK ADD  CONSTRAINT [FK_TareasMaquinas_Maquinas] FOREIGN KEY([TareasMaq_MaqId])
REFERENCES [dbo].[Maquinas] ([Maq_id])
GO
ALTER TABLE [dbo].[TareasMaquinas] CHECK CONSTRAINT [FK_TareasMaquinas_Maquinas]
GO
ALTER TABLE [dbo].[TareasMaquinas]  WITH CHECK ADD  CONSTRAINT [FK_TareasMaquinas_Tareas] FOREIGN KEY([TareasMaq_TareaId])
REFERENCES [dbo].[Tareas] ([Tareas_Id])
GO
ALTER TABLE [dbo].[TareasMaquinas] CHECK CONSTRAINT [FK_TareasMaquinas_Tareas]
GO
/****** Object:  StoredProcedure [dbo].[ListaCodArt]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[ListaCodArt]
AS
SELECT*FROM [dbo].[CodigoArticulo]
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarAtributo]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ActualizarAtributo]
(
@codigo NVARCHAR(50),
@descripcion NVARCHAR (200),
@mensaje NVARCHAR (20) OUT

)

AS 
	BEGIN
		UPDATE Atributos 
		SET Atrib_descripcion =  @descripcion
		WHERE (@codigo = Atrib_id)
		SET @mensaje = 'Actualizacion Exitosa'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarCategoria]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ActualizarCategoria]
(
@codigo NVARCHAR(50),
@descripcion NVARCHAR (200),
@mensaje NVARCHAR (20) OUT

)

AS 
	BEGIN
		UPDATE Categorias 
		SET  cat_descripcion =  @descripcion
		WHERE (@codigo = cat_Id)
		SET @mensaje = 'Actualizacion Exitosa'
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_ActualizarCedulaArticulo]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_ActualizarCedulaArticulo]
(
	@dtRelacion [dbo].[CedulaArtTem] READONLY
)
AS
	BEGIN
		UPDATE CedulaArticulos
		SET 
		CedArt_CodUnidad      =	R.CedArt_CodUnidad,
		CedArt_CantUnidad     =	R.CedArt_CantUnidad
		
		FROM	
		@dtRelacion R

		WHERE 
		 [dbo].[CedulaArticulos].CedArt_CedulaID	=R.[CedArt_CedulaID] AND
		 [dbo].[CedulaArticulos].CedArt_ArticuloId	=R.[CedArt_ArticuloId]
		
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarCedulaProducto]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ActualizarCedulaProducto]
(
@codigo NVARCHAR(50),
@descripcion NVARCHAR(50),
@Duracion INT,
@DuracionHoraDia NVARCHAR(50),
@unidad NVARCHAR(50),
@cantidad INT,
@unidadEst NVARCHAR(50),

@mensaje NVARCHAR(200) OUT       
)
AS
	BEGIN
	UPDATE CedulaProducto 
	SET CedPro_Descrip = @descripcion,
	CedPro_Duracion = @Duracion, 
	CedPro_DuracionHoraDias = @DuracionHoraDia,
	CedPro_Unidad = @unidad,
	CedPro_Cantidad = @cantidad,
	CedPro_UnidadEstandar = @unidadEst
	
	WHERE (@codigo = CedPro_Id)
	SET @mensaje = 'Actualizacion Exitosa'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarEstatusDeMaquina]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ActualizarEstatusDeMaquina]
(
@codigo NVARCHAR(50),
@descripcion NVARCHAR (200),
@mensaje NVARCHAR (20) OUT

)

AS 
	BEGIN
		UPDATE EstatusdeMaquinas
		SET EstMaq_descripcion  = @descripcion
		WHERE (@codigo = EstMaq_id)
		SET @mensaje = 'Actualizacion Exitosa'
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_ActualizarFallasMaquinas]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ActualizarFallasMaquinas]
(
	@Id NVARCHAR (50),
	@Descripcion NVARCHAR (100),
	@Mensaje NVARCHAR (50) OUT
)
AS
	BEGIN
		UPDATE FallasMaquina
		SET FallaMaq_Descripcion=@Descripcion WHERE (FallasMaq_Id=@Id)
		SET @Mensaje='Actualizacion Exitosa'
	END

GO
/****** Object:  StoredProcedure [dbo].[Sp_ActualizarGastoFabrica]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ActualizarGastoFabrica]
(
	@Id NVARCHAR (50),
	@Descripcion NVARCHAR (100),
	@Mensaje NVARCHAR (50) OUT
)
AS
	BEGIN
		UPDATE GastosFabrica
		SET GastosFab_descripcion=@Descripcion WHERE (GastosFab_id=@Id)
		SET @Mensaje='Actualizacion Exitosa'
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarMaquina]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ActualizarMaquina]
(
@codigo NVARCHAR(50),
@descripcion NVARCHAR (200),
@mensaje NVARCHAR (20) OUT

)

AS 
	BEGIN
		UPDATE Maquinas 
		SET  Maq_descripcion= @descripcion
		WHERE (@codigo = Maq_id)
		SET @mensaje = 'Actualizacion Exitosa'
END

GO
/****** Object:  StoredProcedure [dbo].[Sp_ActualizarPerfilesEmpleados]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ActualizarPerfilesEmpleados]
(
	@Id NVARCHAR (50),
	@Descripcion NVARCHAR (100),
	@Sueldo	DECIMAL (18,0),
	@Mensaje NVARCHAR (50) OUT
)
AS
	BEGIN
		UPDATE PerfilesEmpleados
		SET PerfilesEmp_Descripcion=@Descripcion,PefilEmp_Sueldo=@Sueldo WHERE (PerfilesEmp_Id=@Id)
		SET @Mensaje='Actualizacion Exitosa'
	END

GO
/****** Object:  StoredProcedure [dbo].[Sp_ActualizarProcedencia]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ActualizarProcedencia]
(
	@Id NVARCHAR (50),
	@Descripcion NVARCHAR (100),
	@Mensaje NVARCHAR (50) OUT
)
AS
	BEGIN
		UPDATE Procedencia
		SET Proc_Descripcion=@Descripcion WHERE (Proc_Id=@Id)
		SET @Mensaje='Actualizacion Exitosa'
	END

GO
/****** Object:  StoredProcedure [dbo].[Sp_ActualizarTarea]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ActualizarTarea]
(
	@codigo NVARCHAR(50),
	@descripcion NVARCHAR (200),
	@mensaje NVARCHAR (20) OUT
)
AS
	BEGIN
		UPDATE Tareas
		SET Tareas_Descripcion=@descripcion
		WHERE @codigo=Tareas_Id
	SET @mensaje = 'Actualizacion Exitosa'
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_ActualizarTareaTM]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ActualizarTareaTM]
(
	@dtRelacion dbo.TiempoMaqTemp READONLY
)
AS
	BEGIN
		UPDATE TareasMaquinas
		SET 
		TareasMaq_CodUnidad      =	R.TareasMaq_CodUnidad,
		TareasMaq_CantUnidad     =	R.TareasMaq_CantUnidad,
		TareasMaq_CodUnidadTrab  =	R.TareasMaq_CodUnidadTrab,
		TareasMaq_CantUnidadTrab =	R.TareasMaq_CantUnidadTrab
	
		FROM	
		@dtRelacion R

		WHERE 
		 [dbo].[TareasMaquinas].TareasMaq_TareaId			=R.[TareasMaq_TareaId] AND
		 [dbo].[TareasMaquinas].TareasMaq_MaqId				=R.[TareasMaq_MaqId] -- AND
		-- [dbo].[TareasMaquinas].TareasMaq_CodUnidadTrab		=R.[TareasMaq_CodUnidadTrab] AND
		-- [dbo].[TareasMaquinas].TareasMaq_CantUnidadTrab	=R.[TareasMaq_CantUnidadTrab] 
		
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarUnidad]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ActualizarUnidad]
(
@codigo NVARCHAR(50),
@descripcion NVARCHAR (200),
@mensaje NVARCHAR (20) OUT

)

AS 
	BEGIN
		UPDATE Unidades 
		SET Uni_Desc = @descripcion
		WHERE (@codigo = Uni_Id)
		SET @mensaje = 'Actualizacion Exitosa'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizaSubCategoria]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROC [dbo].[sp_ActualizaSubCategoria] 
(
@codigo NVARCHAR(50),
@descripcion NVARCHAR (200),
@categoria NVARCHAR(50),
@mensaje NVARCHAR (20) OUT
)

AS 
	BEGIN
		UPDATE SubCategoria 
		SET SubCat_Descripcion = @descripcion,codCat=@categoria
		WHERE (@codigo = SubCat_Id)
		SET @mensaje = 'Actualizacion Exitosa'
END

GO
/****** Object:  StoredProcedure [dbo].[Sp_AgregarFallasMaquinas]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_AgregarFallasMaquinas]
(
	@descripcion NVARCHAR (100),
	@Id NVARCHAR (100),
	@Mensaje NVARCHAR (50) OUT
)
AS
	BEGIN
		INSERT FallasMaquina VALUES(@Id,@descripcion)
		SELECT @Id=FallasMaq_Id FROM FallasMaquina WHERE (FallaMaq_Descripcion=@descripcion)
		SET @Mensaje='Registro Exitoso'
	END

GO
/****** Object:  StoredProcedure [dbo].[Sp_AgregarGastoFabrica]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Sp_AgregarGastoFabrica]
(
	@descripcion NVARCHAR (100),
	@Id NVARCHAR (100),
	@Mensaje NVARCHAR (50) OUT
)
AS
	BEGIN
		INSERT GastosFabrica VALUES(@Id,@descripcion)
		SELECT @Id=GastosFab_id FROM GastosFabrica WHERE (GastosFab_descripcion=@descripcion)
		SET @Mensaje='Registro Exitoso'
	END

GO
/****** Object:  StoredProcedure [dbo].[Sp_AgregarPerfilesEmpleados]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_AgregarPerfilesEmpleados]
(
	@descripcion NVARCHAR (100),
	@Id NVARCHAR (50),
	@Sueldo DECIMAL (18,0),
	@Mensaje NVARCHAR (50) OUT
)
AS
	BEGIN
		INSERT PerfilesEmpleados VALUES(@Id,@descripcion,@Sueldo)
		SELECT @Id=PerfilesEmp_Id,@Sueldo=PefilEmp_Sueldo FROM PerfilesEmpleados WHERE (PerfilesEmp_Descripcion=@descripcion)
		SET @Mensaje='Registro Exitoso'
	END

GO
/****** Object:  StoredProcedure [dbo].[Sp_AgregarProcedencia]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Sp_AgregarProcedencia]
(
	@descripcion NVARCHAR (100),
	@Id NVARCHAR (100),
	@Mensaje NVARCHAR (50) OUT
)
AS
	BEGIN
		INSERT Procedencia VALUES(@Id,@descripcion)
		SELECT @Id=Proc_Id FROM Procedencia WHERE (Proc_Descripcion=@descripcion)
		SET @Mensaje='Registro Exitoso'
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarAtributo]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_EliminarAtributo]
(
@codigo NVARCHAR(50),
@mensaje NVARCHAR(20) OUT
)
AS
BEGIN
	DELETE FROM Atributos WHERE (Atrib_id=@codigo)
	SET @mensaje='Eliminacion exitosa'
 END

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCategoria]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_EliminarCategoria]
(
@codigo NVARCHAR(50),
@mensaje NVARCHAR(20) OUT
)
AS
BEGIN
	DELETE FROM Categorias WHERE (cat_id=@codigo)
	SET @mensaje='Eliminacion exitosa'
 END
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarCedulaArticulo]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery26.sql|7|0|C:\Users\VRODRI~1\AppData\Local\Temp\~vsB3A7.sql

CREATE PROC [dbo].[SP_EliminarCedulaArticulo]
(
@dtRelacion dbo.CedulaArtTem READONLY
)
AS
	BEGIN	
		DELETE FROM [dbo].[CedulaArticulos]
		WHERE EXISTS(SELECT CA.CedArt_CedulaID, CA.CedArt_ArticuloId
		FROM @dtRelacion CA
		WHERE  CedulaArticulos.CedArt_CedulaID = CA.CedArt_CedulaID
	AND CedulaArticulos.CedArt_ArticuloId = CA.CedArt_ArticuloId)
END

GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarCedulaAtrib]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_EliminarCedulaAtrib]
(
@dtRelacion dbo.Cedula_AtributosTem READONLY
)
AS
	BEGIN	
		DELETE FROM Cedula_Atributos
		WHERE EXISTS(SELECT CA.cedula_AtribId, CA.cedula_CedulaID
		FROM @dtRelacion CA
		WHERE Cedula_Atributos.cedula_AtribId=CA.cedula_AtribId
		AND Cedula_Atributos.cedula_CedulaID=CA.cedula_CedulaID)
	END

GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarCedulaGastFab]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_EliminarCedulaGastFab]
(
@dtRelacion dbo.Cedula_GastosFabricaTem READONLY
)
AS
	BEGIN	
		DELETE FROM Cedula_GastosFabrica
		WHERE EXISTS(SELECT CGF.cedula_GastFabId, CGF.cedula_CedulaID
		FROM @dtRelacion CGF
		WHERE Cedula_GastosFabrica.cedula_GastFabId = CGF.cedula_GastFabId
		AND Cedula_GastosFabrica.cedula_CedulaID = CGF.cedula_CedulaID)
	END

GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarCedulaPerfEmp]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery26.sql|7|0|C:\Users\VRODRI~1\AppData\Local\Temp\~vsB3A7.sql

CREATE PROC [dbo].[SP_EliminarCedulaPerfEmp]
(
@dtRelacion dbo.Cedula_PerfilEmpTem READONLY
)
AS
	BEGIN	
		DELETE FROM Cedula_PerfilEmp
		WHERE EXISTS(SELECT CPE.cedula_CedulaID, CPE.cedula_perfilID
		FROM @dtRelacion CPE
		WHERE  Cedula_PerfilEmp.cedula_CedulaID = CPE.cedula_CedulaID
	AND Cedula_PerfilEmp.cedula_perfilID=CPE.cedula_perfilID)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCedulaProducto]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_EliminarCedulaProducto]
(
@codigo NVARCHAR(50),
@mensaje NVARCHAR(200) OUT
)
AS
BEGIN
	DELETE FROM CedulaProducto WHERE (CedPro_Id=@codigo)
	SET @mensaje='Eliminacion exitosa'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCedulaTarea]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_EliminarCedulaTarea]
(
@dtRelacion dbo.CedulaTareaTem ReadOnly
) 
AS
	BEGIN
		DELETE FROM CedulaTareas
		WHERE EXISTS(SELECT T.CedTarea_IdCedProd,T.CedTarea_IdTarea
		FROM @dtRelacion T
		WHERE CedulaTareas.CedTarea_IdCedProd = T.CedTarea_IdCedProd
		AND CedulaTareas.CedTarea_IdTarea = T.CedTarea_IdTarea)
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarEstatusMaquina]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_EliminarEstatusMaquina]
(
@codigo NVARCHAR(50),
@mensaje NVARCHAR(20) OUT
)
AS
BEGIN
	DELETE FROM EstatusdeMaquinas WHERE (EstMaq_id=@codigo)
	SET @mensaje='Eliminacion exitosa'
END
	
GO
/****** Object:  StoredProcedure [dbo].[Sp_EliminarFallasMaquinas]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_EliminarFallasMaquinas]
(
	@Id NVARCHAR (50),
	@Mensaje NVARCHAR (100) OUT
)
AS
	BEGIN
		DELETE FROM FallasMaquina WHERE  (FallasMaq_Id=@Id)
		SET @Mensaje='Eliminacion Exitosa'
	END

GO
/****** Object:  StoredProcedure [dbo].[Sp_EliminarGastoFabrica]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Sp_EliminarGastoFabrica]
(
	@Id NVARCHAR (50),
	@Mensaje NVARCHAR (100) OUT
)
AS
	BEGIN
		DELETE FROM GastosFabrica WHERE  (GastosFab_id=@Id)
		SET @Mensaje='Eliminacion Exitosa'
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarMaquina]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_EliminarMaquina]
(
@codigo NVARCHAR(50),
@mensaje NVARCHAR(20) OUT
)
AS
BEGIN
	DELETE FROM Maquinas WHERE (Maq_id=@codigo)
 	SET @mensaje='Eliminacion exitosa'
 END

GO
/****** Object:  StoredProcedure [dbo].[Sp_EliminarPerfilesEmpleados]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_EliminarPerfilesEmpleados]
(
	@Id NVARCHAR (50),
	@Mensaje NVARCHAR (100) OUT
)
AS
	BEGIN
		DELETE FROM PerfilesEmpleados WHERE  (PerfilesEmp_Id=@Id)
		SET @Mensaje='Eliminacion Exitosa'
	END

GO
/****** Object:  StoredProcedure [dbo].[Sp_EliminarProcedencia]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Sp_EliminarProcedencia]
(
	@Id NVARCHAR (50),
	@Mensaje NVARCHAR (100) OUT
)
AS
	BEGIN
		DELETE FROM Procedencia WHERE  (Proc_Id=@Id)
		SET @Mensaje='Eliminacion Exitosa'
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarSucAlm]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_EliminarSucAlm]
(
	@dtRelacion dbo.Sucursal_AlmacenTem ReadOnly
)
AS
	BEGIN
	DELETE FROM Sucursal_Almacen 
	WHERE EXISTS (SELECT 
	T.alm_succod,T.alm_almcod 
	FROM @dtRelacion T 
	WHERE alm_succod=T.alm_succod
	 AND  alm_almcod=T.alm_almcod)	
	END	
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarSucMon]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_EliminarSucMon]
(
@dtMonedas [IET\desarrollo2].[SucursalMonedaTemp] READONLY
)
AS
	BEGIN
		DELETE FROM [IET\desarrollo2].[SucursalMoneda]
		WHERE EXISTS (SELECT T.SucMon_codSuc, T.SucMon_codMon
		FROM @dtMonedas T
		WHERE [SucursalMoneda].SucMon_codSuc=T.SucMon_codSuc 
		AND [SucursalMoneda].SucMon_codMon=T.SucMon_codMon)
	END  

GO
/****** Object:  StoredProcedure [dbo].[Sp_EliminarTarea]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_EliminarTarea]
(
@codigo NVARCHAR(50),
@mensaje NVARCHAR(20) OUT
)
AS
BEGIN
	DELETE FROM Tareas WHERE (Tareas_Id=@codigo)
 	SET @mensaje='Eliminacion exitosa'
 END

GO
/****** Object:  StoredProcedure [dbo].[Sp_EliminarTareaArt]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_EliminarTareaArt]
(
	@dtRelacion dbo.TareasArtTem ReadOnly
)
AS
	BEGIN	
		DELETE FROM TareasArticulos
		WHERE EXISTS(SELECT T.TareasArt_TareaId,T.TareasArt_ArtId
		FROM @dtRelacion T
		WHERE TareasArticulos.TareasArt_TareaId=T.TareasArt_TareaId
		AND TareasArticulos.TareasArt_ArtId=T.TareasArt_ArtId)
	END
GO
/****** Object:  StoredProcedure [dbo].[Sp_EliminarTareaAtrib]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_EliminarTareaAtrib]
(
@dtRelacion dbo.TareasAtribTem ReadOnly
)
AS
	BEGIN
		DELETE FROM TareasAtributos
		WHERE EXISTS(SELECT T.TareasAtrib_TareaId,T.TareasAtrib_AtribId
		FROM @dtRelacion T
		WHERE TareasAtributos.TareasAtrib_TareaId=T.TareasAtrib_TareaId
		AND TareasAtributos.TareasAtrib_AtribId=T.TareasAtrib_AtribId)
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarTareaMaq]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_EliminarTareaMaq]
(
@dtRelacion dbo.TareasMaqTem ReadOnly
) 
AS
	BEGIN
		DELETE FROM TareasMaquinas
		WHERE EXISTS(SELECT T.TareasMaq_TareaId,T.TareasMaq_MaqId
		FROM @dtRelacion T
		WHERE TareasMaquinas.TareasMaq_TareaId=T.TareasMaq_TareaId
		AND TareasMaquinas.TareasMaq_MaqId=T.TareasMaq_MaqId)
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarUnidades]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_EliminarUnidades]
(
@codigo NVARCHAR(50),
@mensaje NVARCHAR(20) OUT
)
AS
BEGIN
	DELETE FROM Unidades WHERE (Uni_Id=@codigo)
	SET @mensaje='Eliminacion exitosa'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_listadoAlmacenes]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTOS ALMACENADOS

CREATE PROC [dbo].[sp_listadoAlmacenes]
AS
	BEGIN
		SELECT A.alm_cod,
		A.alm_contacto,
		A.alm_desc,
		A.alm_dir,
		A.alm_eliminado,
		A.alm_fechaCreacion,
		A.alm_nombre,
		A.alm_telef1,
		A.alm_telef2--,
		--ASE.alm_almcod,
		--ASE.alm_empcod,
		--ASE.alm_succod
		

		FROM
		Almacenes A
		
		--Sucursal_Almacen ASE--,
		--empresa E

		--WHERE A.alm_cod = ASE.alm_almcod AND S.suc_cod = ASE.alm_succod --AND E.empr_dni = ASE.alm_empcod
END
GO
/****** Object:  StoredProcedure [dbo].[sp_listadoEmpresas]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_listadoEmpresas]
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
		E.empr_moneda	   
		FROM
			empresa E
			
		--WHERE
		--  E.empr_dni = empr_dni 
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_listadoSucursales]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_listadoSucursales]
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
		S.suc_nombre

		FROM
			Sucursales S--,
			
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_listarAlmacenes]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_listarAlmacenes]
as
begin

select*from Almacenes
end

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarArticulos]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ListarArticulos]
AS
	BEGIN
		SELECT*FROM Articulos
	END 

GO
/****** Object:  StoredProcedure [dbo].[sp_listarAtributos]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_listarAtributos]
AS
BEGIN
	SELECT*FROM Atributos
END
GO
/****** Object:  StoredProcedure [dbo].[sp_listarCategoria]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_listarCategoria]
AS
BEGIN
	SELECT*FROM Categorias
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarCedulaAtrib]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ListarCedulaAtrib]
(
@codigo NVARCHAR(50)
)
AS
	BEGIN
		SELECT CA.cedula_CedulaID,
				CA.cedula_AtribId,
			   
			   A.Atrib_descripcion,
			   CP.CedPro_Descrip

		FROM Cedula_Atributos CA,
			 Atributos A,
			 CedulaProducto CP

		WHERE CA.cedula_AtribId = A.Atrib_id 
		AND CA.cedula_CedulaID = @codigo
		AND CP.CedPro_Id = @codigo

END

GO
/****** Object:  StoredProcedure [dbo].[SP_ListarCedulaGastfab]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ListarCedulaGastfab]
(
@codigo NVARCHAR(50)
)
AS
	BEGIN
		SELECT CG.cedula_CedulaID,
			   CG.cedula_GastFabId,
			   G.GastosFab_descripcion,
			   CP.CedPro_Descrip

		FROM Cedula_GastosFabrica CG,
			 GastosFabrica G,
			 CedulaProducto CP

		WHERE CG.cedula_GastFabId = G.GastosFab_id 
		AND CG.cedula_CedulaID = @codigo
		AND CP.CedPro_Id = @codigo

END
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarCedulaPerfEmpl]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ListarCedulaPerfEmpl]
(
@codigo NVARCHAR(50)
)
AS
	BEGIN
		SELECT CPE.cedula_perfilID,
			   CPE.cedula_CedulaID,

			   P.PerfilesEmp_Descripcion,
			   CP.CedPro_Descrip

		FROM Cedula_PerfilEmp CPE,
			 PerfilesEmpleados P,
			 CedulaProducto CP

		WHERE CPE.cedula_perfilID = P.PerfilesEmp_Id 
		AND CPE.cedula_CedulaID = @codigo
		AND CP.CedPro_Id = @codigo

END
GO
/****** Object:  StoredProcedure [dbo].[Sp_ListarCedulaProArticulo]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_ListarCedulaProArticulo]
(
@codigo NVARCHAR(50)
)
AS
	BEGIN
		SELECT  CA.CedArt_CedulaID,
				CA.CedArt_ArticuloId,
				A.art_Nom,
				CA.CedArt_CodUnidad,
				CA.CedArt_CantUnidad
				
				--C.CedPro_Descrip
				

		FROM	CedulaArticulos CA,
				CedulaProducto	C,
				Articulos A

		WHERE CA.CedArt_ArticuloId = A.art_Id
		AND CA.CedArt_CedulaID = @codigo 
		AND C.CedPro_Id = @codigo
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_listarCedulaProducto]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_listarCedulaProducto]
AS
BEGIN
	SELECT*FROM CedulaProducto
END

GO
/****** Object:  StoredProcedure [dbo].[Sp_ListarCedulaTarea]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_ListarCedulaTarea]
(
@codigo NVARCHAR(50)
)
AS
	BEGIN
		SELECT Ct.CedTarea_IdCedProd,
			   Ct.CedTarea_IdTarea,
			   T.Tareas_Descripcion

		FROM CedulaTareas	Ct,
			 CedulaProducto CP,
			 Tareas T
			 
			
		WHERE CP.CedPro_Id = @codigo
		AND  Ct.CedTarea_IdCedProd = @codigo AND Ct.CedTarea_IdTarea =  T.Tareas_Id 

	END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListaRelacionSucAlm]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ListaRelacionSucAlm]
AS
	SELECT *FROM [dbo].[Sucursal_Almacen]
GO
/****** Object:  StoredProcedure [dbo].[sp_listarEstatusMaquina]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROC [dbo].[sp_listarEstatusMaquina]
AS
BEGIN
	SELECT*FROM EstatusdeMaquinas
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_listarFallasMaquinas]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_listarFallasMaquinas]
AS
	BEGIN
		SELECT * FROM  FallasMaquina
	END

GO
/****** Object:  StoredProcedure [dbo].[Sp_ListarGastoFabrica]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Sp_ListarGastoFabrica]
AS
	BEGIN
		SELECT * FROM  GastosFabrica
	END

GO
/****** Object:  StoredProcedure [dbo].[Sp_ListarInvTipoMov]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ListarInvTipoMov]
AS
	BEGIN
		SELECT*FROM Inventario_TipoMov
	END

GO
/****** Object:  StoredProcedure [dbo].[Sp_ListarInvtProcesos]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ListarInvtProcesos]
AS
	BEGIN
		SELECT*FROM Inventario_Procesos
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_listarMaquina]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[sp_listarMaquina]
AS
BEGIN
	SELECT*FROM Maquinas
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_ListarPerfilesEmpleados]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Sp_ListarPerfilesEmpleados]
AS
	BEGIN
		SELECT * FROM  PerfilesEmpleados
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarProcedencia]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ListarProcedencia]
AS
	BEGIN
		SELECT * FROM  Procedencia
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarProductoCedula]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ListarProductoCedula]
AS
	BEGIN
		SELECT
		a.art_Id,
		A.art_Nom
		FROM
		Articulos A
		WHERE
		A.art_Tipo = 'CED'
		
	END

	execute sp_ListarProductoCedula
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarProveedores]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ListarProveedores]
AS
BEGIN
SELECT*FROM Proveedores
END

GO
/****** Object:  StoredProcedure [dbo].[sp_listarSubCategoria]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[sp_listarSubCategoria]
AS

SELECT S.SubCat_codCat,
		S.SubCat_Descripcion,
		S.SubCat_Id,
		C.cat_descripcion
FROM SubCategoria S,
	 Categorias C
WHERE S.SubCat_codCat=C.cat_id


GO
/****** Object:  StoredProcedure [dbo].[Sp_ListarTareaAtrib]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ListarTareaAtrib](
@codigo NVARCHAR(50)
)
AS
	BEGIN
		SELECT TA.TareasAtrib_AtribId,
				TA.TareasAtrib_TareaId,
				T.Tareas_Descripcion,
				A.Atrib_descripcion
		FROM TareasAtributos TA,
				Tareas T,
				Atributos A
		WHERE TA.TareasAtrib_AtribId= A.Atrib_id
		AND TA.TareasAtrib_TareaId=@codigo AND T.Tareas_Id=@codigo
	END
GO
/****** Object:  StoredProcedure [dbo].[Sp_ListarTareaMaquina]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ListarTareaMaquina](
@codigo NVARCHAR(50)
)
AS
	BEGIN
		SELECT	TM.TareasMaq_TareaId,
				TM.TareasMaq_MaqId,
				
				T.Tareas_Descripcion,
				M.Maq_descripcion

		FROM TareasMaquinas TM,
			 Tareas T,
			 Maquinas M

		WHERE TM.TareasMaq_TareaId = @codigo--T.Tareas_Id
		AND TM.TareasMaq_MaqId = Maq_id AND T.Tareas_Id = @codigo

	END

	
GO
/****** Object:  StoredProcedure [dbo].[Sp_ListarTareaMaquinaTime]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ListarTareaMaquinaTime](
@codigo NVARCHAR(50)
)
AS
	BEGIN
		SELECT	TM.TareasMaq_TareaId,
				TM.TareasMaq_MaqId,
				--UD.UnidDes_codUni,
				TM.TareasMaq_CodUnidadTrab,
				D.UnidDes_Descripcion,
				TM.TareasMaq_CodUnidad,
				UD.UnidDes_Descripcion,
				M.Maq_descripcion,
				TM.TareasMaq_CantUnidad,
				TM.TareasMaq_CantUnidadTrab
				

		FROM TareasMaquinas TM 
			 
			 INNER JOIN MITCore.dbo.UnidadDescrip UD ON TM.TareasMaq_CodUnidad = UD.UnidDes_codUni 
			 INNER JOIN MITCore.dbo.UnidadDescrip D ON TM.TareasMaq_CodUnidadTrab = D.UnidDes_codUni 
			 INNER JOIN Maquinas M ON  TM.TareasMaq_MaqId = M.Maq_id  
			 INNER JOIN Tareas T ON T.Tareas_Id = @codigo AND  TM.TareasMaq_TareaId = @codigo
	  
	 END

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarTareas]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_ListarTareas]
AS
BEGIN
	SELECT*FROM Tareas
END 
GO
/****** Object:  StoredProcedure [dbo].[sp_listarUnidades]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_listarUnidades]
AS
BEGIN
	SELECT*FROM Unidades
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistarArticulos]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistarArticulos]
(
@id NVARCHAR(100),
@nombre NVARCHAR(100),
@garantia NVARCHAR(100),
@modelo NVARCHAR(100),
@unidad NVARCHAR(100),
@unidadFiltro NVARCHAR(100),
@medida NVARCHAR(100),
@categoria NVARCHAR(100),
@subcategoria NVARCHAR(100),
@procedencia NVARCHAR(100),
@serial NVARCHAR(100),
@codigo NVARCHAR(50),
@mensaje NVARCHAR(20) OUT
)
AS
	BEGIN
		INSERT Articulos
		VALUES (@id,@nombre,@garantia,@modelo,
		@unidad,@unidadFiltro,@medida,@categoria,@subcategoria,
		@procedencia,@serial,@codigo)
		SET @mensaje='Registro Exitoso'
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistarMaquinas]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROC [dbo].[sp_RegistarMaquinas]
(
@Maq_id nvarchar (50),
@Maq_desc nvarchar(200),
@mensaje NVARCHAR(20) OUT
)
AS
	BEGIN
		INSERT Maquinas VALUES (@Maq_id,@Maq_desc)
	SET @mensaje='Registro Exitoso'	
END 
BEGIN  
	SELECT @Maq_id = @Maq_id FROM Maquinas WHERE @Maq_desc = Maq_descripcion
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistarMonedas]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistarMonedas]
(
@dtMonedas [IET\desarrollo2].[SucursalMonedaTemp] READONLY
)
AS
	BEGIN
		INSERT INTO [IET\desarrollo2].[SucursalMoneda] (SucMon_codSuc,SucMon_codMon)
		SELECT
		[SucMon_codSuc],
		[SucMon_codMon]
FROM
	@dtMonedas
	END 
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistarSubCatg]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[sp_RegistarSubCatg]
(
@categoria NVARCHAR(50),
@descripcion NVARCHAR(30),
@mensaje NVARCHAR(20) OUT,
@codigo NVARCHAR(50)
)
AS
	BEGIN
	INSERT SubCategoria VALUES (@codigo,@categoria,@descripcion)
	SET @mensaje='Registro Exitoso'
END

GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarAtributos]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistrarAtributos]
(
	@codigo NVARCHAR(50),
	@descripcion NVARCHAR(200),
	@mensaje NVARCHAR(20) OUT
)
AS
	BEGIN
	INSERT Atributos VALUES(@codigo,@descripcion)
	SET @mensaje='Registro Exitoso'
  END

GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarCategoria]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistrarCategoria]
(
	@codigo NVARCHAR(50),
	@descripcion NVARCHAR(200),
	@mensaje NVARCHAR(20) OUT
)
AS
	BEGIN
	INSERT Categorias VALUES(@codigo,@descripcion)
	SET @mensaje='Registro Exitoso'
  END

GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarCedulaArticulo]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistrarCedulaArticulo]
(
@dtRelacion [dbo].[CedulaArtTem] READONLY
)

AS
	BEGIN
		INSERT INTO CedulaArticulos
		(
		[CedArt_CedulaID],
		[CedArt_ArticuloId],
		[CedArt_CodUnidad],
		[CedArt_CantUnidad]
		
		)
		SELECT 
		[CedArt_CedulaID],
		[CedArt_ArticuloId],
		[CedArt_CodUnidad],
		[CedArt_CantUnidad]
		
		FROM
		@dtRelacion

END
GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarCedulaAtrib]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_RegistrarCedulaAtrib]
(
@dtRelacion dbo.Cedula_AtributosTem READONLY
)
AS
		BEGIN
		INSERT INTO Cedula_Atributos (cedula_AtribId, cedula_CedulaID)
		SELECT 
		[cedula_AtribId],
		[cedula_CedulaID]
		
		
		FROM
		@dtRelacion

END

GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarCedulaGastFab]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_RegistrarCedulaGastFab]
(
@dtRelacion dbo.Cedula_GastosFabricaTem READONLY
)
AS
		BEGIN
		INSERT INTO Cedula_GastosFabrica(cedula_GastFabId,cedula_CedulaID)
		SELECT 
		
		[cedula_GastFabId],
		[cedula_CedulaID]
		FROM
		@dtRelacion

END

GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarCedulaPerfEmp]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_RegistrarCedulaPerfEmp]
(
@dtRelacion dbo.Cedula_PerfilEmpTem READONLY
)
AS
		BEGIN
		INSERT INTO Cedula_PerfilEmp(cedula_CedulaID, cedula_perfilID)
		SELECT 
		[cedula_CedulaID],
		[cedula_perfilID]
		
		FROM
		@dtRelacion

END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarCedulaProducto]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC  [dbo].[sp_RegistrarCedulaProducto]
(
@codigo NVARCHAR(50),
@descripcion NVARCHAR(50),
@fecha DATE,
@unidad NVARCHAR(50),
@Producto NVARCHAR(50),
@Duracion INT,
@DuracionHoraDia NVARCHAR(50),
@cantidad INT,
@unidadEst NVARCHAR(50),

@mensaje NVARCHAR(200) OUT
)
AS
  BEGIN
	IF(EXISTS (SELECT*FROM CedulaProducto WHERE CedPro_Id = @codigo))
		SET @mensaje = 'Ya existe'
			ELSE
				INSERT CedulaProducto VALUES 
				(@codigo,
				@descripcion,
				@fecha,
				@unidad,
				@Producto,
				@Duracion,
				@DuracionHoraDia,
				@cantidad,
				@unidadEst )

			SET @mensaje = 'Registro Exitoso'
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarEstatusMaquina]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistrarEstatusMaquina]
(
	@codigo NVARCHAR(50),
	@descripcion NVARCHAR(200),
	@mensaje NVARCHAR(20) OUT
)
AS
	BEGIN
	INSERT EstatusdeMaquinas VALUES(@codigo,@descripcion)
	SET @mensaje='Registro Exitoso'
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarMaquinas]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistrarMaquinas]
(
	@codigo NVARCHAR(50),
	@descripcion NVARCHAR(200),
	@mensaje NVARCHAR(20) OUT
)
AS
	BEGIN
	INSERT Maquinas VALUES(@codigo,@descripcion)
	SET @mensaje='Registro Exitoso'
  END

GO
/****** Object:  StoredProcedure [dbo].[Sp_RegistrarMovInventario]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_RegistrarMovInventario]
(
@dtRelacion [dbo].[InventarioTem] READONLY

)
AS
	BEGIN
		INSERT INTO Inventario
		(
		[Inv_CodArt],
		[Inv_Fecha],
		[Inv_TipoMov],
		[Inv_Almacen],
		[Inv_Cantidad],
		[Inv_Unidad],
--		[Inv_UnidadDescrip],
		[Inv_Proceso]
		
		)
		SELECT 
		[Inv_CodArt],
		[Inv_Fecha],
		[Inv_TipoMov],
		[Inv_Almacen],
		[Inv_Cantidad],
		[Inv_Unidad],
	   -- [Inv_UnidadDescrip],
		[Inv_Proceso]
		
		FROM
		@dtRelacion

		

	END

GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarProcedencia]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistrarProcedencia]
(
@descripcion nvarchar(30),
@codigo INT OUT,
@mensaje nvarchar(20) OUT
)
AS
BEGIN
	INSERT Procedencia VALUES (@descripcion)
	SET @mensaje='Registro Exitoso'
END
BEGIN
	SELECT @codigo= Proc_Id FROM Procedencia WHERE Proc_Desc=@descripcion
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarProveedor]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_RegistrarProveedor]
(
	@nombre nvarchar(100),
	@tipo  nvarchar(30),
	@responsable nvarchar(30),
	@telefono1 nvarchar(50),
	@telefono2 nvarchar(50),
	@direccion nvarchar(300),
	@pais nvarchar(30),
	@estado nvarchar(30),
	@ciudad nvarchar(30),
	@municipio nvarchar(30),
	@tipoPerso nvarchar(30),
	@rif nvarchar(30),
	@fax nvarchar(30),
	@fecha date,
	@dias nvarchar(10),
	@limite nvarchar(10),
	@comentario nvarchar(100),
	@email nvarchar(100),
	@referencia nvarchar(100),
	@mensaje nvarchar(20) OUT
)
AS
	BEGIN 
	INSERT Proveedores 
	VALUES (@nombre,@tipo,@responsable,
	@telefono1,@telefono2,@direccion,@pais,
	@estado,@ciudad,@municipio,@tipoPerso,
	@rif,@fax,@fecha,@dias,@limite,@comentario,@email,@referencia	
	)
	SET @mensaje='Registro Exitoso'
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarRelacioSucAlm]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistrarRelacioSucAlm]
(
	@dtRelacion dbo.Sucursal_AlmacenTem ReadOnly
)
AS
	BEGIN
		INSERT INTO Sucursal_Almacen (alm_succod,alm_almcod)
		SELECT
		[alm_succod],
		[alm_almcod]
		FROM
		@dtRelacion 
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarTarea]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistrarTarea]
(
	@codigo NVARCHAR(50),
	@descripcion NVARCHAR(200),
	@mensaje NVARCHAR(20) OUT
)
AS
	BEGIN
		IF (EXISTS(SELECT*FROM Tareas WHERE Tareas_Id=@codigo))
			SET @mensaje = 'Ya existe'
		ELSE
			BEGIN
				INSERT INTO Tareas VALUES (@codigo,@descripcion)
				SET @mensaje='Registro Exitoso'
			END
	END


GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarTareaCedula]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistrarTareaCedula]
(
@dtRelacion dbo.CedulaTareaTem READONLY
)

AS

		BEGIN
		INSERT INTO CedulaTareas (CedTarea_IdCedProd,CedTarea_IdTarea)
		SELECT 
		[CedTarea_IdCedProd],
		[CedTarea_IdTarea]
		FROM
		@dtRelacion

END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarTarTiempoMaquina]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistrarTarTiempoMaquina]
(
@dtRelacion dbo.TiempoMaqTemp READONLY
)

AS

	BEGIN
		INSERT INTO TareasMaquinas(
		TareasMaq_TareaId,
		TareasMaq_MaqId,
		TareasMaq_CodUnidad,
		TareasMaq_CantUnidad,
		TareasMaq_CodUnidadTrab,
		TareasMaq_CantUnidadTrab
		)
		
		SELECT 
		[TareasMaq_TareaId],
		[TareasMaq_MaqId],
		[TareasMaq_CodUnidad],
		[TareasMaq_CantUnidad],
		[TareasMaq_CodUnidadTrab],
		[TareasMaq_CantUnidadTrab]
		
		FROM
	
		@dtRelacion

END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarUnidades]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_RegistrarUnidades]
(
	@codigo NVARCHAR(50),
	@descripcion NVARCHAR(200),
	@mensaje NVARCHAR(20) OUT
)
AS
	BEGIN
	INSERT Unidades VALUES(@codigo,@descripcion)
	SET @mensaje='Registro Exitoso'
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_RegistroAlmacen]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegistroAlmacen]
(
@empresa int, 
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
		SET @almMensaje='Registro exitoso'
	END

	BEGIN
	SELECT  @codAlm= A.alm_cod FROM Almacenes A WHERE A.alm_nombre=@almNomb
	END 
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistroEmpresa]    Script Date: 13/10/2020 12:17:46 ******/
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
 @emprMoneda int,
 @emprEmail nvarchar(100),
 @emprWeb nvarchar(100),
 @emprFechaCreacion date,
 @emprNit nvarchar(100), 
 @empMensaje nvarchar(100) OUT
)
AS
BEGIN
	INSERT empresa VALUES (@emprDesc,@emprDirec,
					@emprRif,@emprNit,
					@emprTelf1,@emprTelf2,
					@emprEmail,@emprWeb,
					0,@emprFechaCreacion,@emprNomb,
					@emprMoneda,@empContacto)
			SET @empMensaje='Registro exitoso'
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_RegistroSucursal]    Script Date: 13/10/2020 12:17:46 ******/
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
 --@sucMoneda int,
 @sucEmail nvarchar(100),
 @sucFechaCreacion date, 
 @sucMensaje nvarchar(100) OUT,
 @CodSuc int OUT
)
AS
BEGIN 
	BEGIN
		INSERT Sucursales VALUES (@sucDesc,@sucDirec,
					@sucTelf1,@sucTelf2,@sucEmail,0,
					@sucFechaCreacion,@sucNomb,@sucContacto)
		SELECT @CodSuc= suc_cod FROM Sucursales WHERE suc_nombre=@sucNomb
		SET @sucMensaje='Registro exitoso'
	END
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegitrarTareasAtributos]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_RegitrarTareasAtributos]
(
@dtRelacion TareasAtribTem ReadOnly
)
AS
	BEGIN
		INSERT INTO TareasAtributos (TareasAtrib_TareaId,TareasAtrib_AtribId)
		SELECT
		[TareasAtrib_TareaId],
		[TareasAtrib_AtribId]
		FROM
		@dtRelacion
		
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegitrarTareasMaquinas]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RegitrarTareasMaquinas]
(
@dtRelacion dbo.TareasMaqTem ReadOnly
)
AS
	BEGIN
		INSERT INTO TareasMaquinas (TareasMaq_TareaId,TareasMaq_MaqId)
		SELECT
		[TareasMaq_TareaId],
		[TareasMaq_MaqId]
		FROM
		@dtRelacion 
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_RelacionMonSuc]    Script Date: 13/10/2020 12:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_RelacionMonSuc]
AS
SELECT * FROM [SucursalMoneda]
GO
