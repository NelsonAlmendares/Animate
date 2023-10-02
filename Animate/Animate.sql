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

-- Tabla de Clientes
CREATE TABLE [dbo].[Clientes] (
	id_Cliente INT NOT NULL IDENTITY (1,1),
	nombre_Cliente VARCHAR (100) NOT NULL,
	apellido_Cliente VARCHAR (100) NOT NULL,
	usuario_Cliente VARCHAR (100) NOT NULL,
	password_Cliente VARCHAR (250) NOT NULL,
	documento_Cliente VARCHAR (12) NOT NULL,
	telefono_Cliente VARCHAR (10) NOT NULL,
	correo_Cliente VARCHAR (200) NOT NULL
	PRIMARY KEY (id_cliente)
);
GO
SELECT * FROM [dbo].[Clientes];
GO

-- Tabla de Eventos
CREATE TABLE [dbo].[Evento] (
	id_codigo INT NOT NULL IDENTITY(1,1),
	nombre_Evento TEXT NOT NULL,
	descripcion_Evento TEXT NOT NULL,
	costo_Base FLOAT NOT NULL,
	PRIMARY KEY (id_codigo)
);
GO
SELECT nombre_Evento AS Evento, descripcion_Evento AS Desctipción, CONCAT('$ ', costo_Base) AS Costo FROM [dbo].[Evento];
GO

-- Tabla de Horarios 
CREATE TABLE [dbo].[Horarios] (
	id_horario INT NOT NULL IDENTITY (1,1),
	hora_inicio TIME NOT NULL,
	hora_fin TIME NOT NULL,
	tipo_horario VARCHAR (100),
	PRIMARY KEY (id_horario)
);
GO
SELECT id_horario AS ID, CONVERT(VARCHAR, hora_inicio, 108) AS Inicio, CONVERT(VARCHAR, hora_fin,108) AS Finalización, tipo_horario AS Horario FROM [dbo].[Horarios];
GO

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
SELECT * FROM [dbo].[Reservas];
GO

CREATE TABLE [dbo].[EstadoReserva] (
	id_estadoReserva INT NOT NULL IDENTITY(1,1),
	estado_reserva VARCHAR(100) NOT NULL,
	PRIMARY KEY (id_estadoReserva)
);
SELECT * FROM [dbo].[EstadoReserva];
GO

CREATE TABLE [dbo].[Animador] (
	id_animador INT NOT NULL IDENTITY (1,1),
	nombre_animador VARCHAR (100) NOT NULL,
	apellido_animador VARCHAR (100) NOT NULL,
	documento_animador VARCHAR (12) NOT NULL,
	PRIMARY KEY (id_animador)
);
SELECT * FROM [dbo].[Animador];

INSERT INTO [dbo].[Animador] ()  VALUES

CREATE TABLE [dbo].[Disfraz] (
	id_disfraz INT NOT NULL IDENTITY (1,1),
	descripcion VARCHAR (300) NOT NULL,
	precio_alquiler FLOAT NOT NULL,
	PRIMARY KEY (id_disfraz)
);
SELECT * FROM [dbo].[Disfraz];

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

-- **************************************** Procedimientos Almacenados **************************************** -- 
ALTER PROCEDURE ValidateReservas 
	@horario INT, @evento INT, @cliente INT, @estado INT, @fecha DATE
AS
BEGIN
	
	IF NOT EXISTS (
		SELECT 1 FROM [dbo].[Reservas]
		WHERE id_horario = @horario AND fecha_reserva = @fecha
	)
	BEGIN
		INSERT INTO [dbo].[Reservas] (id_evento, id_cliente, id_horario, fecha_reserva, id_estadoReservar)
		VALUES (@evento, @cliente, @horario, @fecha, @estado);
	END
	ELSE
		BEGIN
			PRINT 'El horario ya ha sido utilizado';
		END;
END;
GO
EXEC ValidateReservas @horario = 2, @evento = 1, @cliente = 3, @estado = 1, @fecha = '2023-09-29';

-- **************************************** Triggers **************************************** -- 

-- **************************************** Funciones **************************************** -- 


-- **************************************** INSERCCIONES **************************************** -- 

SELECT usuario_Cliente, password_Cliente FROM [dbo].[Clientes] WHERE usuario_Cliente = 'NelsonAlmendares' AND password_Cliente = 'admin';

-- Para la tabla de Clientes
INSERT INTO [dbo].[Clientes] (nombre_Cliente, apellido_Cliente, usuario_Cliente, password_Cliente ,documento_Cliente, telefono_Cliente, correo_Cliente) 
	VALUES ('Nelson José', 'Almendares', 'NelsonAlmendares', 'admin','36042341-2', '3452-4231', 'Nelsonjosealmendares1999@gmail.com')
INSERT INTO [dbo].[Clientes] (nombre_Cliente, apellido_Cliente, usuario_Cliente, password_Cliente ,documento_Cliente, telefono_Cliente, correo_Cliente) 
	VALUES ('Nelson José', 'Almendares Ruiz', 'Administrador', 'admin','06385663-0', '7823-2341', 'Nelsonjosealmendares1999@gmail.com')
INSERT INTO [dbo].[Clientes] (nombre_Cliente, apellido_Cliente, usuario_Cliente, password_Cliente ,documento_Cliente, telefono_Cliente, correo_Cliente) 
	VALUES ('Camila Michelle', 'Centeno Sánchez', 'Camichelle', '123456','3422342-1', '3143-4561', 'Camilamichelle1212@gmail.com')
INSERT INTO [dbo].[Clientes] (nombre_Cliente, apellido_Cliente, usuario_Cliente, password_Cliente ,documento_Cliente, telefono_Cliente, correo_Cliente) 
	VALUES ('Laura Elisabeth', 'Granados Ramirez', 'Lau123', '12345','36614241-2', '2345-6522', 'Lauragranados@gmail.com')

-- Insercciones para la tabla de Eventos
INSERT INTO [dbo].[Evento] (nombre_Evento, descripcion_Evento, costo_Base) 
	VALUES ('');

-- Insercciones para la tabla de Horarios:
INSERT INTO [dbo].[Horarios] (hora_inicio,hora_fin, tipo_horario) VALUES ('10:00', '12:00', 'Matutino');
INSERT INTO [dbo].[Horarios] (hora_inicio,hora_fin, tipo_horario) VALUES ('13:00', '15:00', 'Vespertino');
INSERT INTO [dbo].[Horarios] (hora_inicio,hora_fin, tipo_horario) VALUES ('16:00', '18:00', 'Vespertino');
INSERT INTO [dbo].[Horarios] (hora_inicio,hora_fin, tipo_horario) VALUES ('18:00', '21:00', 'Nocturno');
INSERT INTO [dbo].[Horarios] (hora_inicio,hora_fin, tipo_horario) VALUES ('22:00', '00:00', 'Nocturno');

-- Insercciones de la tabla de estados de la reservaciones
INSERT INTO [dbo].[EstadoReserva] (estado_reserva) VALUES ('Activa');
INSERT INTO [dbo].[EstadoReserva] (estado_reserva) VALUES ('Cancelada');
INSERT INTO [dbo].[EstadoReserva] (estado_reserva) VALUES ('Finalizada');

-- Para la tabla de Eventos
INSERT INTO [dbo].[Evento] (nombre_Evento, descripcion_Evento, costo_Base) 
	VALUES ('Boda', 'Estamos basados en la calidad, rapidez y buen soporte, mostrando siempre un alto grado de profesionalidad y atención a los detalles. Capturar momentos mágicos para hacerlos eternos es nuestra misión.', 350.00);
INSERT INTO [dbo].[Evento] (nombre_Evento, descripcion_Evento, costo_Base) 
	VALUES ('Fiesta Rosa', 'Ofreciendo la mejor calidad y atención a los comensales, ubicados en zona accesible para el públicp.', 200.00);
INSERT INTO [dbo].[Evento] (nombre_Evento, descripcion_Evento, costo_Base) 
	VALUES ('Aniversario', 'Queremos que esta fecha quede en la memoria de cada uno de los asistentes ofreciendo la mejor atención.', 400.00);

-- CREATE TABLE [dbo].[Animadores] ();
-- CREATE TABLE [dbo].[Disfraz] ();
-- SELECT CAST(GETDATE() AS DATE) AS 'Fecha de Ahora';
-- Selecciono el nombre del servidor para la conexión de la base de datos
SELECT @@SERVERNAME AS 'Nombre del servidor'


-- **************************************** COMENTARIOS **************************************** -- 
/* 
	-> Debo validar con un IF la insercciones de los eventos más adelante por que con eso defino los horarios que ya no están disponibles
	-> Al momento de realizar la reserva puedo crear un procedimiento para poder selaccionar los datos que quiero evaluar antes de ser ingresados (probar antes de dejar como cambio definiitvo)
	-> 
* /

SELECT CONVERT(VARCHAR, hora_inicio, 108) AS Inicio,
	CASE
		WHEN DATEPART (HOUR, hora_inicio) >= 12 THEN 'PM'
		ELSE 'AM'
	END AS Hora
FROM [dbo].[Horarios];
-------------------------------------------------------------------------------------------
SELECT CONCAT (
	CONVERT(VARCHAR, hora_inicio, 108) , ' ',
		CASE
			WHEN DATEPART (HOUR, hora_inicio) >= 12 THEN 'PM '
			ELSE 'AM '
		END
		, CONVERT(VARCHAR, hora_fin, 108), 
		CASE
			WHEN DATEPART (HOUR, hora_fin) >= 12 THEN 'PM '
			ELSE 'AM ' 
		END) AS Horario
FROM [dbo].[Horarios];