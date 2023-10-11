USE [master]
GO
/****** Object:  Database [Animate]    Script Date: 10/10/2023 23:51:17 ******/
CREATE DATABASE [Animate]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Animate', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Animate.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Animate_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Animate_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Animate] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Animate].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Animate] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Animate] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Animate] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Animate] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Animate] SET ARITHABORT OFF 
GO
ALTER DATABASE [Animate] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Animate] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Animate] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Animate] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Animate] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Animate] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Animate] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Animate] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Animate] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Animate] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Animate] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Animate] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Animate] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Animate] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Animate] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Animate] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Animate] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Animate] SET RECOVERY FULL 
GO
ALTER DATABASE [Animate] SET  MULTI_USER 
GO
ALTER DATABASE [Animate] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Animate] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Animate] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Animate] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Animate] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Animate] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Animate', N'ON'
GO
ALTER DATABASE [Animate] SET QUERY_STORE = ON
GO
ALTER DATABASE [Animate] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Animate]
GO
/****** Object:  Table [dbo].[Horarios]    Script Date: 10/10/2023 23:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horarios](
	[id_horario] [int] IDENTITY(1,1) NOT NULL,
	[hora_inicio] [time](7) NOT NULL,
	[hora_fin] [time](7) NOT NULL,
	[tipo_horario] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_horario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Horario]    Script Date: 10/10/2023 23:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Horario] AS SELECT id_horario, CONCAT (
	CONVERT(VARCHAR, hora_inicio, 108) , ' ',
		CASE
			WHEN DATEPART (HOUR, hora_inicio) >= 12 THEN ' PM '
			ELSE ' AM'
		END
		,  ' - ', CONVERT(VARCHAR, hora_fin, 108),
		CASE
			WHEN DATEPART (HOUR, hora_fin) >= 12 THEN ' PM '
			ELSE ' AM' 
		END) AS 'Horario: ' FROM [dbo].[Horarios];
GO
/****** Object:  Table [dbo].[Animador]    Script Date: 10/10/2023 23:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animador](
	[id_animador] [int] IDENTITY(1,1) NOT NULL,
	[nombre_animador] [varchar](100) NOT NULL,
	[apellido_animador] [varchar](100) NOT NULL,
	[documento_animador] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_animador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 10/10/2023 23:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre_Cliente] [varchar](200) NOT NULL,
	[apellido_Cliente] [varchar](200) NOT NULL,
	[usuario_Cliente] [varchar](100) NOT NULL,
	[password_Cliente] [varchar](250) NOT NULL,
	[documento_Cliente] [varchar](12) NOT NULL,
	[telefono_Cliente] [varchar](10) NOT NULL,
	[correo_Cliente] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 10/10/2023 23:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[id_detalleFactura] [int] IDENTITY(1,1) NOT NULL,
	[codigo_Factura] [int] NOT NULL,
	[id_servicios] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_detalleFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Disfraz]    Script Date: 10/10/2023 23:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disfraz](
	[id_disfraz] [int] IDENTITY(1,1) NOT NULL,
	[tipo_disfraz] [varchar](100) NOT NULL,
	[descripcion] [varchar](300) NOT NULL,
	[precio_alquiler] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_disfraz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoReserva]    Script Date: 10/10/2023 23:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoReserva](
	[id_estadoReserva] [int] IDENTITY(1,1) NOT NULL,
	[estado_reserva] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_estadoReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evento]    Script Date: 10/10/2023 23:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[id_codigo] [int] IDENTITY(1,1) NOT NULL,
	[nombre_Evento] [varchar](500) NOT NULL,
	[descripcion_Evento] [varchar](100) NOT NULL,
	[costo_Base] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 10/10/2023 23:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[codigo_Factura] [int] IDENTITY(1,1) NOT NULL,
	[direccion_evento] [varchar](600) NOT NULL,
	[id_reserva] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[codigo_Factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presentador]    Script Date: 10/10/2023 23:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presentador](
	[id_presentador] [int] IDENTITY(1,1) NOT NULL,
	[nombre_presentador] [varchar](150) NOT NULL,
	[apellido_presentador] [varchar](150) NOT NULL,
	[documento_presentador] [varchar](12) NOT NULL,
	[id_evento] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_presentador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 10/10/2023 23:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservas](
	[id_reserva] [int] IDENTITY(1,1) NOT NULL,
	[id_evento] [int] NOT NULL,
	[id_cliente] [int] NOT NULL,
	[id_horario] [int] NOT NULL,
	[id_animador] [int] NOT NULL,
	[id_disfraz] [int] NOT NULL,
	[fecha_reserva] [date] NOT NULL,
	[id_estadoReservar] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicios]    Script Date: 10/10/2023 23:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicios](
	[id_servicios] [int] IDENTITY(1,1) NOT NULL,
	[tipo_servicio] [varchar](100) NOT NULL,
	[precio_servicio] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_servicios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Animador] ON 

INSERT [dbo].[Animador] ([id_animador], [nombre_animador], [apellido_animador], [documento_animador]) VALUES (1, N'Milton Josué', N'Perez Salamanca', N'04305204-3')
INSERT [dbo].[Animador] ([id_animador], [nombre_animador], [apellido_animador], [documento_animador]) VALUES (2, N'Mirna María', N'Cruz de la O', N'23409423-4')
INSERT [dbo].[Animador] ([id_animador], [nombre_animador], [apellido_animador], [documento_animador]) VALUES (3, N'Daniel Steve', N'Hernández Hernández', N'23452558-3')
INSERT [dbo].[Animador] ([id_animador], [nombre_animador], [apellido_animador], [documento_animador]) VALUES (4, N'Jefrey Gilberto', N'Panameño Reyes', N'42614532-7')
INSERT [dbo].[Animador] ([id_animador], [nombre_animador], [apellido_animador], [documento_animador]) VALUES (5, N'Leslie María', N'Masin Reyes', N'43617772-5')
SET IDENTITY_INSERT [dbo].[Animador] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([id_Cliente], [nombre_Cliente], [apellido_Cliente], [usuario_Cliente], [password_Cliente], [documento_Cliente], [telefono_Cliente], [correo_Cliente]) VALUES (1, N'Nelson José', N'Almendares', N'NelsonAlmendares', N'admin', N'36042341-2', N'3452-4231', N'Nelsonjosealmendares1999@gmail.com')
INSERT [dbo].[Clientes] ([id_Cliente], [nombre_Cliente], [apellido_Cliente], [usuario_Cliente], [password_Cliente], [documento_Cliente], [telefono_Cliente], [correo_Cliente]) VALUES (2, N'Nelson José', N'Almendares Ruiz', N'Administrador', N'admin', N'06385663-0', N'7823-2341', N'Nelsonjosealmendares1999@gmail.com')
INSERT [dbo].[Clientes] ([id_Cliente], [nombre_Cliente], [apellido_Cliente], [usuario_Cliente], [password_Cliente], [documento_Cliente], [telefono_Cliente], [correo_Cliente]) VALUES (3, N'Camila Michelle', N'Centeno Sánchez', N'Camichelle', N'123456', N'3422342-1', N'3143-4561', N'Camilamichelle1212@gmail.com')
INSERT [dbo].[Clientes] ([id_Cliente], [nombre_Cliente], [apellido_Cliente], [usuario_Cliente], [password_Cliente], [documento_Cliente], [telefono_Cliente], [correo_Cliente]) VALUES (4, N'Laura Elisabeth', N'Granados Ramirez', N'Lau123', N'12345', N'36614241-2', N'2345-6522', N'Lauragranados@gmail.com')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[DetalleFactura] ON 

INSERT [dbo].[DetalleFactura] ([id_detalleFactura], [codigo_Factura], [id_servicios]) VALUES (2, 2, 1)
INSERT [dbo].[DetalleFactura] ([id_detalleFactura], [codigo_Factura], [id_servicios]) VALUES (3, 3, 2)
SET IDENTITY_INSERT [dbo].[DetalleFactura] OFF
GO
SET IDENTITY_INSERT [dbo].[Disfraz] ON 

INSERT [dbo].[Disfraz] ([id_disfraz], [tipo_disfraz], [descripcion], [precio_alquiler]) VALUES (1, N'Traje de Gala', N'Ideal par fiestas de gala con una temática elegante y de alta sociedad', 50.95)
INSERT [dbo].[Disfraz] ([id_disfraz], [tipo_disfraz], [descripcion], [precio_alquiler]) VALUES (2, N'Playero', N'Con toda la energía de las playas de las costas salvadoreñas', 35.9)
INSERT [dbo].[Disfraz] ([id_disfraz], [tipo_disfraz], [descripcion], [precio_alquiler]) VALUES (3, N'Ayer y hoy', N'Una retrospéctiva para los 80s y 90s ideal para los conocedores', 60)
INSERT [dbo].[Disfraz] ([id_disfraz], [tipo_disfraz], [descripcion], [precio_alquiler]) VALUES (4, N'De los 80', N'Para las ocaciones especiales', 25.99)
SET IDENTITY_INSERT [dbo].[Disfraz] OFF
GO
SET IDENTITY_INSERT [dbo].[EstadoReserva] ON 

INSERT [dbo].[EstadoReserva] ([id_estadoReserva], [estado_reserva]) VALUES (1, N'Activa')
INSERT [dbo].[EstadoReserva] ([id_estadoReserva], [estado_reserva]) VALUES (2, N'Cancelada')
INSERT [dbo].[EstadoReserva] ([id_estadoReserva], [estado_reserva]) VALUES (3, N'Finalizada')
SET IDENTITY_INSERT [dbo].[EstadoReserva] OFF
GO
SET IDENTITY_INSERT [dbo].[Evento] ON 

INSERT [dbo].[Evento] ([id_codigo], [nombre_Evento], [descripcion_Evento], [costo_Base]) VALUES (2, N'Fiesta Rosa', N'Ofreciendo la mejor calidad y atención a los comensales, ubicados en zona accesible para el públicp.', 200)
INSERT [dbo].[Evento] ([id_codigo], [nombre_Evento], [descripcion_Evento], [costo_Base]) VALUES (4, N'Cumpleaños', N'Ofreciendo la mejor calidad y atención a los comensales, ubicados en zona accesible para el público', 300)
INSERT [dbo].[Evento] ([id_codigo], [nombre_Evento], [descripcion_Evento], [costo_Base]) VALUES (5, N'Primera Comunión', N'Para que celebres ese gran momento a lo grande.', 250)
INSERT [dbo].[Evento] ([id_codigo], [nombre_Evento], [descripcion_Evento], [costo_Base]) VALUES (6, N'Fiesta en la playa', N'Para que todos tus invitados y tu se den un buen chapuzón.', 450)
SET IDENTITY_INSERT [dbo].[Evento] OFF
GO
SET IDENTITY_INSERT [dbo].[Factura] ON 

INSERT [dbo].[Factura] ([codigo_Factura], [direccion_evento], [id_reserva]) VALUES (2, N'Urb Santísima Trinidad, Block g Norte departamento 5B, frente a la Iglesia Católica', 2)
INSERT [dbo].[Factura] ([codigo_Factura], [direccion_evento], [id_reserva]) VALUES (3, N'Urb Santísima Trinidad, Block g Norte departamento 5B, frente a la Iglesia Católica', 3)
SET IDENTITY_INSERT [dbo].[Factura] OFF
GO
SET IDENTITY_INSERT [dbo].[Horarios] ON 

INSERT [dbo].[Horarios] ([id_horario], [hora_inicio], [hora_fin], [tipo_horario]) VALUES (1, CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), N'Matutino')
INSERT [dbo].[Horarios] ([id_horario], [hora_inicio], [hora_fin], [tipo_horario]) VALUES (2, CAST(N'13:00:00' AS Time), CAST(N'15:00:00' AS Time), N'Vespertino')
INSERT [dbo].[Horarios] ([id_horario], [hora_inicio], [hora_fin], [tipo_horario]) VALUES (3, CAST(N'16:00:00' AS Time), CAST(N'18:00:00' AS Time), N'Vespertino')
INSERT [dbo].[Horarios] ([id_horario], [hora_inicio], [hora_fin], [tipo_horario]) VALUES (4, CAST(N'18:00:00' AS Time), CAST(N'21:00:00' AS Time), N'Nocturno')
INSERT [dbo].[Horarios] ([id_horario], [hora_inicio], [hora_fin], [tipo_horario]) VALUES (5, CAST(N'22:00:00' AS Time), CAST(N'00:00:00' AS Time), N'Nocturno')
SET IDENTITY_INSERT [dbo].[Horarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Presentador] ON 

INSERT [dbo].[Presentador] ([id_presentador], [nombre_presentador], [apellido_presentador], [documento_presentador], [id_evento]) VALUES (1, N'Milton Edgardo', N'Perez', N'949852354-3', 4)
SET IDENTITY_INSERT [dbo].[Presentador] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservas] ON 

INSERT [dbo].[Reservas] ([id_reserva], [id_evento], [id_cliente], [id_horario], [id_animador], [id_disfraz], [fecha_reserva], [id_estadoReservar]) VALUES (2, 2, 2, 3, 1, 1, CAST(N'2023-08-10' AS Date), 1)
INSERT [dbo].[Reservas] ([id_reserva], [id_evento], [id_cliente], [id_horario], [id_animador], [id_disfraz], [fecha_reserva], [id_estadoReservar]) VALUES (3, 4, 3, 1, 2, 2, CAST(N'2023-10-10' AS Date), 1)
INSERT [dbo].[Reservas] ([id_reserva], [id_evento], [id_cliente], [id_horario], [id_animador], [id_disfraz], [fecha_reserva], [id_estadoReservar]) VALUES (4, 4, 3, 3, 1, 2, CAST(N'2023-10-11' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Reservas] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicios] ON 

INSERT [dbo].[Servicios] ([id_servicios], [tipo_servicio], [precio_servicio]) VALUES (1, N'No deseo otro Servicio', 0)
INSERT [dbo].[Servicios] ([id_servicios], [tipo_servicio], [precio_servicio]) VALUES (2, N'Montaje de Escenario y escenografía', 25.99)
INSERT [dbo].[Servicios] ([id_servicios], [tipo_servicio], [precio_servicio]) VALUES (3, N'Tarimas y columnas de luz', 85.99)
INSERT [dbo].[Servicios] ([id_servicios], [tipo_servicio], [precio_servicio]) VALUES (4, N'Humo en hielo seco', 20.99)
INSERT [dbo].[Servicios] ([id_servicios], [tipo_servicio], [precio_servicio]) VALUES (5, N'Destellos de cerpentinas', 10.99)
INSERT [dbo].[Servicios] ([id_servicios], [tipo_servicio], [precio_servicio]) VALUES (6, N'Bocina extra', 19.99)
INSERT [dbo].[Servicios] ([id_servicios], [tipo_servicio], [precio_servicio]) VALUES (7, N'Recuerdos iluminativos', 20.99)
INSERT [dbo].[Servicios] ([id_servicios], [tipo_servicio], [precio_servicio]) VALUES (8, N'Bocinas Extras', 19.99)
SET IDENTITY_INSERT [dbo].[Servicios] OFF
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura] FOREIGN KEY([codigo_Factura])
REFERENCES [dbo].[Factura] ([codigo_Factura])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_Servicios] FOREIGN KEY([id_servicios])
REFERENCES [dbo].[Servicios] ([id_servicios])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_Servicios]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Reserva] FOREIGN KEY([codigo_Factura])
REFERENCES [dbo].[Reservas] ([id_reserva])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Reserva]
GO
ALTER TABLE [dbo].[Presentador]  WITH CHECK ADD  CONSTRAINT [FK_presentador] FOREIGN KEY([id_evento])
REFERENCES [dbo].[Evento] ([id_codigo])
GO
ALTER TABLE [dbo].[Presentador] CHECK CONSTRAINT [FK_presentador]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Animador] FOREIGN KEY([id_animador])
REFERENCES [dbo].[Animador] ([id_animador])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Animador]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Clientes] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Clientes] ([id_Cliente])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Clientes]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Disfraz] FOREIGN KEY([id_disfraz])
REFERENCES [dbo].[Disfraz] ([id_disfraz])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Disfraz]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_EstadoReserva] FOREIGN KEY([id_estadoReservar])
REFERENCES [dbo].[EstadoReserva] ([id_estadoReserva])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_EstadoReserva]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Eventos] FOREIGN KEY([id_evento])
REFERENCES [dbo].[Evento] ([id_codigo])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Eventos]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Horarios] FOREIGN KEY([id_horario])
REFERENCES [dbo].[Horarios] ([id_horario])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Horarios]
GO
/****** Object:  StoredProcedure [dbo].[Add_Factura]    Script Date: 10/10/2023 23:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_Factura] 
	@direccion VARCHAR(500), @id_reserva INT, @servicios INT
	AS
	BEGIN
		DECLARE @last_id INT;
		-- Inserto los datos de la tabla de Factura:
		INSERT INTO [dbo].[Factura] (direccion_evento, id_reserva) VALUES (@direccion, @id_reserva);

		SET @last_id = SCOPE_IDENTITY();
		INSERT INTO [dbo].[DetalleFactura] (codigo_Factura, id_servicios) VALUES (@last_id, @servicios);
	END;
GO
/****** Object:  StoredProcedure [dbo].[ValidateReservas]    Script Date: 10/10/2023 23:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- **************************************** Procedimientos Almacenados **************************************** -- 
CREATE PROCEDURE [dbo].[ValidateReservas] 
	@evento INT, @cliente INT, @horario INT, @animador INT, @disfraz INT, @fecha DATE, @estado INT
AS
BEGIN
	
	IF NOT EXISTS (
		SELECT 1 FROM [dbo].[Reservas]
		WHERE id_horario = @horario AND fecha_reserva = @fecha
	)
	BEGIN
		INSERT INTO [dbo].[Reservas] (id_evento, id_cliente, id_horario, id_animador, id_disfraz, fecha_reserva, id_estadoReservar)
		VALUES (@evento, @cliente, @horario, @animador, @disfraz, @fecha, @estado);
	END
	ELSE
		BEGIN
			PRINT 'El horario ya ha sido utilizado';
		END;
END;
GO
USE [master]
GO
ALTER DATABASE [Animate] SET  READ_WRITE 
GO
