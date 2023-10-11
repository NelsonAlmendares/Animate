CREATE DATABASE [Animate]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Animate', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Animate.mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Animate_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Animate_log.ldf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
 WITH LEDGER = OFF
GO
ALTER DATABASE [Animate] SET ANSI_NULLS OFF 
GO
USE [Animate]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [Animate] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO
-- DROP DATABASE [Animate];

-- **************************************************** COMENTARIOS **************************************************** -- 
/* 
	-> Debo validar con un IF la insercciones de los eventos más adelante por que con eso defino los horarios que ya no están disponibles
	-> Al momento de realizar la reserva puedo crear un procedimiento para poder selaccionar los datos que quiero evaluar antes de ser ingresados (probar antes de dejar como cambio definiitvo)
	-> 
*/

SELECT @@SERVERNAME AS 'Nombre del servidor'

-- Tabla de Reservaciones de los clientes (Con esta tabla reservo un local para evento, un horario y los animadores para tener el orden de los próximos eventos que serán validados :] )
CREATE TABLE [dbo].[Reservas] (
	id_reserva INT NOT NULL IDENTITY (1,1),
	id_evento  INT NOT NULL,
	id_cliente INT NOT NULL,
	id_horario INT NOT NULL,
	id_animador INT NOT NULL,
	id_disfraz INT NOT NULL,
	fecha_reserva DATE NOT NULL,
	id_estadoReservar INT NOT NULL,
	-- fecha_Evento DATE NOT NULL, --> Lo tomaré con un data picker de C#
	PRIMARY KEY (id_reserva)
);
GO

-- Tabla de Eventos
CREATE TABLE [dbo].[Evento] (
	id_codigo INT NOT NULL IDENTITY(1,1),
	nombre_Evento VARCHAR (500) NOT NULL,
	descripcion_Evento VARCHAR (100) NOT NULL,
	costo_Base FLOAT NOT NULL,
	PRIMARY KEY (id_codigo)
);
SELECT * FROM [dbo].[Evento];
GO
-- TRUNCATE TABLE [dbo].[Evento];
SELECT CONCAT('$ ', costo_Base) AS Costo FROM [dbo].[Evento];
GO
SELECT nombre_Evento AS Evento, descripcion_Evento AS Desctipción  FROM [dbo].[Evento] WHERE id_codigo = 1;
GO

-- Tabla de Clientes
CREATE TABLE [dbo].[Clientes] (
	id_Cliente INT NOT NULL IDENTITY (1,1),
	nombre_Cliente VARCHAR (200) NOT NULL,
	apellido_Cliente VARCHAR (200) NOT NULL,
	usuario_Cliente VARCHAR (100) NOT NULL,
	password_Cliente VARCHAR (250) NOT NULL,
	documento_Cliente VARCHAR (12) NOT NULL,
	telefono_Cliente VARCHAR (10) NOT NULL,
	correo_Cliente VARCHAR (200) NOT NULL
	PRIMARY KEY (id_cliente)
);
GO
SELECT nombre_Cliente AS Nombre, apellido_Cliente AS Apellido, usuario_Cliente AS Usuario, documento_Cliente AS DUI, telefono_Cliente AS Teléfono, correo_Cliente AS Correo FROM [dbo].[Clientes];
GO
-- DELETE FROM [dbo].[Clientes] WHERE id_Cliente = 6;

SELECT id_Cliente, CONCAT (nombre_Cliente, ' ' , apellido_Cliente) AS Nombre FROM [dbo].[Clientes];

-- Tabla de Horarios 
CREATE TABLE [dbo].[Horarios] (
	id_horario INT NOT NULL IDENTITY (1,1),
	hora_inicio TIME NOT NULL,
	hora_fin TIME NOT NULL,
	tipo_horario VARCHAR (100),
	PRIMARY KEY (id_horario)
);
GO
SELECT * FROM [dbo].[Horarios];
SELECT id_horario AS ID, CONVERT(VARCHAR, hora_inicio, 108) AS Inicio, CONVERT(VARCHAR, hora_fin,108) AS Finalización, tipo_horario AS Horario FROM [dbo].[Horarios];
GO

-- Tabla de Facturas:
CREATE TABLE [dbo].[Factura] (
	codigo_Factura INT NOT NULL IDENTITY (1,1),
	direccion_evento VARCHAR (600) NOT NULL,
	id_reserva INT NOT NULL,
	PRIMARY KEY (codigo_Factura)
);
SELECT * FROM [dbo].[Factura];
-- ALTER TABLE [dbo].[Factura] ADD direccion_evento VARCHAR (100) NOT NULL;
-- DELETE FROM [dbo].[Factura] WHERE codigo_Factura = 1;

-- Tabla de Animador
CREATE TABLE [dbo].[Animador] (
	id_animador INT NOT NULL IDENTITY (1,1),
	nombre_animador VARCHAR (100) NOT NULL,
	apellido_animador VARCHAR (100) NOT NULL,
	documento_animador VARCHAR (12) NOT NULL,
	PRIMARY KEY (id_animador)
);
SELECT id_animador, CONCAT(nombre_animador, ' ' ,apellido_animador) AS Animador FROM [dbo].[Animador];

CREATE TABLE [dbo].[Presentador] (
	id_presentador INT NOT NULL IDENTITY (1,1),
	nombre_presentador VARCHAR (150) NOT NULL,
	apellido_presentador VARCHAR (150) NOT NULL,
	documento_presentador VARCHAR (12) NOT NULL,
	id_evento INT NOT NULL
	PRIMARY KEY(id_presentador)
);
SELECT * FROM [dbo].[Presentador];

-- Tabla de Disfraces para los eventos que se patrocinan
CREATE TABLE [dbo].[Disfraz] (
	id_disfraz INT NOT NULL IDENTITY (1,1),
	tipo_disfraz VARCHAR (100) NOT NULL,
	descripcion VARCHAR (300) NOT NULL,
	precio_alquiler FLOAT NOT NULL,
	PRIMARY KEY (id_disfraz)
);
SELECT * FROM [dbo].[Disfraz];
-- ALTER TABLE [dbo].[Disfraz] ADD tipo_disfraz VARCHAR (100) NOT NULL;

CREATE TABLE [dbo].[EstadoReserva] (
	id_estadoReserva INT NOT NULL IDENTITY(1,1),
	estado_reserva VARCHAR(100) NOT NULL,
	PRIMARY KEY (id_estadoReserva)
);
SELECT id_estadoReserva, estado_reserva FROM [dbo].[EstadoReserva];
GO

-- Tabla para los detalles de la Factura
CREATE TABLE [dbo].[DetalleFactura] (
	id_detalleFactura INT NOT NULL IDENTITY (1,1),
	codigo_Factura INT NOT NULL,
	id_servicios INT NULL,
	PRIMARY KEY (id_detalleFactura)
);
GO
-- ALTER TABLE [dbo].[DetalleFactura] ALTER COLUMN id_servicios INT NULL
SELECT * FROM [dbo].[DetalleFactura];
GO

-- Tabla para los servicios Ofrecidos
CREATE TABLE [dbo].[Servicios] (
	id_servicios INT NOT NULL IDENTITY(1,1),
	tipo_servicio VARCHAR (100) NOT NULL,
	precio_servicio FLOAT NOT NULL,
	PRIMARY KEY (id_servicios)
);
SELECT * FROM [dbo].[Servicios];
SELECT precio_servicio FROM [dbo].[Servicios] WHERE id_servicios = 2;
GO

-- ******************************************** FOREIGN KEYS ********************************************
-- -Reserva -> Eventos
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT FK_Eventos 
FOREIGN KEY (id_evento) 
REFERENCES [dbo].[Evento] (id_codigo);

-- Reserva -> Clientes
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT FK_Clientes
FOREIGN KEY (id_cliente) 
REFERENCES [dbo].[Clientes] (id_Cliente);

-- Reserva -> Horario
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT FK_Horarios
FOREIGN KEY (id_horario) 
REFERENCES [dbo].[Horarios] (id_horario);

-- Reserva -> Animador
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT FK_Animador
FOREIGN KEY (id_animador) 
REFERENCES [dbo].[Animador] (id_animador);

-- Reserva -> Animador
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT FK_Disfraz
FOREIGN KEY (id_disfraz) 
REFERENCES [dbo].[Disfraz] (id_disfraz);

-- Reserva -> Estado Reserva
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT FK_EstadoReserva
FOREIGN KEY (id_estadoReservar) 
REFERENCES [dbo].[EstadoReserva] (id_estadoReserva);

-- Factura -> Reserva
ALTER TABLE [dbo].[Factura]
ADD CONSTRAINT FK_Reserva
FOREIGN KEY (codigo_Factura) 
REFERENCES [dbo].[Reservas] (id_reserva);

-- Detalle Factura -> Factura 
ALTER TABLE [dbo].[DetalleFactura]
ADD CONSTRAINT FK_DetalleFactura
FOREIGN KEY (codigo_Factura)
REFERENCES [dbo].[Factura] (codigo_Factura);

-- Detalle Factura -> Servicios
ALTER TABLE [dbo].[DetalleFactura]
ADD CONSTRAINT FK_Servicios
FOREIGN KEY (id_servicios)
REFERENCES [dbo].[Servicios] (id_servicios);

-- Evento -> Presentador
ALTER TABLE [dbo].[Presentador]
ADD CONSTRAINT FK_presentador
FOREIGN KEY (id_evento)
REFERENCES [dbo].[Evento] (id_codigo);

-- ****************************************************** Selects para la base de datos ******************************************************

SELECT [dbo].[Reservas].id_reserva AS 'Reserva N°', nombre_Evento AS Evento, CONCAT (nombre_Cliente, ' ', apellido_Cliente) 
	AS Cliente, documento_Cliente  AS DUI, 
		CONCAT (
	CONVERT(VARCHAR, hora_inicio, 108) , ' ',
		CASE
			WHEN DATEPART (HOUR, hora_inicio) >= 12 THEN ' PM '
			ELSE ' AM'
		END
		,  ' - ', CONVERT(VARCHAR, hora_fin, 108),
		CASE
			WHEN DATEPART (HOUR, hora_fin) >= 12 THEN ' PM '
			ELSE ' AM' 
		END) AS 'Horario: ',
		estado_reserva AS Estado,
		fecha_reserva AS Fecha
	FROM [dbo].[Reservas]
	INNER JOIN [dbo].[Evento] ON [dbo].[Evento].id_codigo = [dbo].[Reservas].id_evento
	INNER JOIN [dbo].[Clientes] ON [dbo].[Reservas].id_cliente = [dbo].[Clientes].id_Cliente
	INNER JOIN [dbo].[Horarios] ON [dbo].[Horarios].id_horario = [dbo].[Reservas].id_horario
	INNER JOIN [dbo].[EstadoReserva] ON [dbo].[EstadoReserva].id_estadoReserva = [dbo].[Reservas].id_estadoReservar;
GO

SELECT * FROM [dbo].[Reservas];
GO

CREATE VIEW Horario AS SELECT id_horario, CONCAT (
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

-- **************************************** Procedimientos Almacenados **************************************** -- 
CREATE PROCEDURE ValidateReservas 
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
EXEC ValidateReservas @evento = 4, @cliente = 3 , @horario = 1,  @animador = 2, @disfraz = 2, @fecha = '10-10-2023', @estado = 1;
GO

CREATE PROCEDURE Add_Factura 
	@direccion VARCHAR(500), @id_reserva INT, @servicios INT
	AS
	BEGIN
		DECLARE @last_id INT;
		-- Inserto los datos de la tabla de Factura:
		INSERT INTO [dbo].[Factura] (direccion_evento, id_reserva) VALUES (@direccion, @id_reserva);

		SET @last_id = SCOPE_IDENTITY();
		INSERT INTO [dbo].[DetalleFactura] (codigo_Factura, id_servicios) VALUES (@last_id, @servicios);
	END;

EXEC Add_Factura @direccion = 'Urb Santísima Trinidad, Block g Norte departamento 5B, frente a la Iglesia Católica', @id_reserva = 3 , @servicios = 2;
GO

SELECT Fact.codigo_Factura, direccion_evento AS Dirección, fecha_reserva AS Fecha, CONCAT(nombre_Cliente, ' ', apellido_Cliente) AS Cliente, SUM(precio_servicio) + costo_Base AS Total
FROM [dbo].[Factura] AS Fact
INNER JOIN [dbo].[Reservas] ON [dbo].[Reservas].id_reserva = Fact.id_reserva
INNER JOIN [dbo].[Clientes] ON [dbo].[Reservas].id_cliente = [dbo].[Clientes].id_Cliente
INNER JOIN [dbo].[DetalleFactura] ON [dbo].[DetalleFactura].codigo_Factura = Fact.codigo_Factura
INNER JOIN [dbo].[Servicios] ON [dbo].[DetalleFactura].id_servicios = [dbo].[Servicios].id_servicios
INNER JOIN [dbo].[Evento] ON [dbo].[Evento].id_codigo = [dbo].[Reservas].id_evento
GROUP BY Fact.codigo_Factura, direccion_evento, fecha_reserva, nombre_Cliente, apellido_Cliente, precio_servicio, costo_Base


delete from [dbo].[DetalleFactura] where id_detalleFactura = 1
delete from [dbo].[Factura] where codigo_Factura = 2

SELECT * FROM [dbo].[Factura];
SELECT * FROM [dbo].[DetalleFactura];
SELECT * FROM [dbo].[Reservas];
SELECT * FROM [dbo].[Evento];
SELECT * FROM [dbo].[Servicios];
SELECT nombre_presentador, apellido_presentador, documento_presentador, id_evento FROM [dbo].[Presentador];

SELECT * FROM [dbo].[Clientes];
INSERT INTO [dbo].[Clientes] (nombre_Cliente, apellido_Cliente, usuario_Cliente, password_Cliente, documento_Cliente, telefono_Cliente, correo_Cliente) VALUES ('');

INSERT INTO [dbo].[Presentador] (nombre_presentador, apellido_presentador, documento_presentador, id_evento) VALUES ('')
SELECT * FROM [dbo].[Presentador];

SELECT nombre_animador, apellido_animador, documento_animador FROM [dbo].[Animador];
INSERT INTO [dbo].[Animador] (nombre_animador, apellido_animador, documento_animador) VALUES ('');

SELECT id_disfraz, tipo_disfraz, descripcion, precio_alquiler FROM [dbo].[Disfraz];
INSERT INTO [dbo].[Disfraz] (tipo_disfraz, descripcion, precio_alquiler) VALUES ('');

INSERT INTO [dbo].[Factura] (direccion_evento, id_reserva) VALUES ('Por la casa de pepito en la esquina de Don Juan', 2);
INSERT INTO [dbo].[DetalleFactura] (codigo_Factura, id_servicios) VALUES (2, 2);
INSERT INTO [dbo].[DetalleFactura] (codigo_Factura, id_servicios) VALUES (2, 4);

SELECT Fact.codigo_Factura AS Factura, CONCAT(nombre_Cliente, ' ', apellido_Cliente) AS Cliente, direccion_evento AS Dirección ,SUM(precio_servicio) + costo_Base AS Total, nombre_Evento AS Evento
FROM [dbo].[Factura] AS Fact
INNER JOIN [dbo].[DetalleFactura] ON [dbo].[DetalleFactura].codigo_Factura = Fact.codigo_Factura
INNER JOIN [dbo].[Servicios] ON [dbo].[DetalleFactura].id_servicios = [dbo].[Servicios].id_servicios
-- Para la tabla de reserrvas y mostrar los clientes
INNER JOIN [dbo].[Reservas] ON [dbo].[Reservas].id_reserva = Fact.codigo_Factura
INNER JOIN [dbo].[Clientes] ON [dbo].[Reservas].id_cliente = [dbo].[Clientes].id_Cliente
INNER JOIN [dbo].[Evento] ON [dbo].[Evento].id_codigo = [dbo].[Reservas].id_evento
GROUP BY Fact.codigo_Factura, costo_Base, direccion_evento, nombre_Cliente, apellido_Cliente, nombre_Evento;

-- **************************************** Triggers **************************************** -- 

-- **************************************** Funciones **************************************** -- 

SELECT id_reserva, CONCAT ('#',id_reserva, '. ',nombre_Cliente, ' ', apellido_Cliente) AS Cliente
	FROM [dbo].[Reservas] AS Re
	INNER JOIN [dbo].[Clientes] ON [dbo].[Clientes].id_Cliente = Re.id_cliente
GO