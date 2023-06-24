--CREAR TABALA
CREATE TABLE [dbo].[vh_vehiculosTest](
	[id]			int identity(1,1) primary key,
	[codigo]		varchar(20) NOT NULL,
	[chasis]		varchar(20) NULL,
	[marca]		varchar(50) NULL,
	[modelo]		varchar(50) NULL,
	[anio_modelo]		int NULL,
	[color]		varchar(50) NULL,
	[estado]		varchar(50) NULL,
	[fecha_registro]	datetime null)
GO

--Creación de Stored Procedures (SP)
--SP para obtener todos los registros:
CREATE PROCEDURE ListarVehiculos 
AS
BEGIN
	select * from vh_vehiculosTest
END

GO

--SP para obtener un registro:
CREATE PROCEDURE ObtenerVehiculo 
(
   @id int
)
AS
BEGIN
	select * from vh_vehiculosTest WHERE id = @id
END

GO

--SP para insertar un nuevo registro:
CREATE PROCEDURE InsertarVehiculo
(
   @codigo varchar(20),
   @chasis varchar(20),
   @marca varchar(50),
   @modelo varchar(50),
   @anio_modelo int,
   @color varchar(50),
   @estado varchar(50),
   @fecha_registro datetime
)
AS
BEGIN
   INSERT INTO vh_vehiculosTest (codigo, chasis, marca, modelo, anio_modelo, color, estado, fecha_registro)
   VALUES (@codigo, @chasis, @marca, @modelo, @anio_modelo, @color, @estado, @fecha_registro)
END

GO

--SP para actualizar un registro existente:
CREATE PROCEDURE ActualizarVehiculo
(
   @id int,
   @codigo varchar(20),
   @chasis varchar(20),
   @marca varchar(50),
   @modelo varchar(50),
   @anio_modelo int,
   @color varchar(50),
   @estado varchar(50),
   @fecha_registro datetime
)
AS
BEGIN
   UPDATE vh_vehiculosTest
   SET codigo = @codigo, chasis = @chasis, marca = @marca, modelo = @modelo,
       anio_modelo = @anio_modelo, color = @color, estado = @estado, fecha_registro = @fecha_registro
   WHERE id = @id
END

GO

--SP para eliminar un registro:
CREATE PROCEDURE EliminarVehiculo
(
   @id int
)
AS
BEGIN
   DELETE FROM vh_vehiculosTest WHERE id = @id
END

GO