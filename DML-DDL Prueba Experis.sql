CREATE DATABASE pruebaExperis
USE pruebaExperis

CREATE TABLE dbo.Productos(
Id Int Identity,
Nombre VARCHAR(100),
Precio DECIMAL(10,2),
Stock Int ,
FechaRegistro DATETIME
)


INSERT INTO [dbo].[Productos] ([Nombre], [Precio], [Stock], [FechaRegistro]) VALUES ( N'Leche', CAST(2.50 AS Decimal(18, 2)), 100, CAST(N'2023-08-01T00:31:47.300' AS DateTime))
INSERT INTO [dbo].[Productos] ([Nombre], [Precio], [Stock], [FechaRegistro]) VALUES ( N'Arroz', CAST(1.75 AS Decimal(18, 2)), 50, CAST(N'2023-07-31T11:30:00.000' AS DateTime))
INSERT INTO [dbo].[Productos] ([Nombre], [Precio], [Stock], [FechaRegistro]) VALUES ( N'Pan', CAST(3.99 AS Decimal(18, 2)), 200, CAST(N'2023-07-31T14:15:00.000' AS DateTime))
INSERT INTO [dbo].[Productos] ([Nombre], [Precio], [Stock], [FechaRegistro]) VALUES ( N'Pescado', CAST(8.99 AS Decimal(18, 2)), 75, CAST(N'2023-07-31T16:45:00.000' AS DateTime))

------create producto
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateProducto]
    @Nombre NVARCHAR(100),
    @Precio DECIMAL(18, 2),
    @Stock INT,
    @FechaRegistro DATETIME
AS
BEGIN
    INSERT INTO Productos (Nombre, Precio, Stock, FechaRegistro)
    VALUES (@Nombre, @Precio, @Stock, @FechaRegistro);

    SELECT SCOPE_IDENTITY();
END;
GO
------delete producto
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteProducto]
    @Id INT
AS
BEGIN
    DELETE FROM Productos WHERE Id = @Id;
END;
GO

------select all producto
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROCEDURE [dbo].[sp_GetAllProductos]
AS
BEGIN
    SELECT Id, Nombre, Precio, Stock, Convert(varchar,FechaRegistro,13)as FechaRegistro FROM Productos;
END;
GO

------single producto
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetProductoById]
    @Id INT
AS
BEGIN
    SELECT Id, Nombre, Precio, Stock, Convert(varchar,FechaRegistro,13)as FechaRegistro FROM Productos WHERE Id = @Id;
END;
GO
------update producto
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateProducto]
    @Id INT,
    @Nombre NVARCHAR(100),
    @Precio DECIMAL(18, 2),
    @Stock INT,
    @FechaRegistro DATETIME
AS
BEGIN
    UPDATE Productos
    SET Nombre = @Nombre, Precio = @Precio, Stock = @Stock, FechaRegistro = @FechaRegistro
    WHERE Id = @Id;
END;
GO