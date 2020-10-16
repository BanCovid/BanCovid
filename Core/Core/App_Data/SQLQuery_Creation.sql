
GO
--DROP TABLE [Tbl_EstadoUsuario]
CREATE TABLE [dbo].[Tbl_EstadoUsuario]
(
	[Id] SMALLINT PRIMARY KEY NOT NULL ,
	[Nombre] VARCHAR(20) NOT NULL,
	[Estado] BIT NOT NULL
)

INSERT INTO [dbo].[Tbl_EstadoUsuario] VALUES (0, 'Inactivo', 1);
INSERT INTO [dbo].[Tbl_EstadoUsuario] VALUES (1, 'Activo', 1);
INSERT INTO [dbo].[Tbl_EstadoUsuario] VALUES (2, 'Bloqueado', 1);

GO

--DROP TABLE [Tbl_Perfil]
CREATE TABLE [dbo].[Tbl_Perfil]
(
	[Id] SMALLINT NOT NULL,
	[Nombre] VARCHAR(50) NOT NULL,
	[Descripcion] VARCHAR(200) NOT NULL,
	[Estado] BIT NOT NULL
	PRIMARY KEY(Id)
)

INSERT INTO [dbo].[Tbl_Perfil] VALUES (1, 'Admin', 'Usuario que puede utilizar la aplicación de core visual', 1);
INSERT INTO [dbo].[Tbl_Perfil] VALUES (2, 'Caja', 'Usuario que puede utilizar la aplicación de caja', 1);
INSERT INTO [dbo].[Tbl_Perfil] VALUES (3, 'Cliente', 'Usuario final que existe como cliente del banco', 1);

GO
--DROP TABLE [Tbl_Usuario]
CREATE TABLE [dbo].[Tbl_Usuario]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[UserName] VARCHAR(25) NOT NULL,
	[Password] VARCHAR(200) NOT NULL,
	[Nombre] VARCHAR(30) NOT NULL,
	[Apellido] VARCHAR(30) NOT NULL,
	[Telefono] VARCHAR(10) NOT NULL,
	[Cedula] VARCHAR(13) NOT NULL,
	[Perfil_Id] SMALLINT NOT NULL,
	[FechaCreacion] DATETIME NOT NULL,
	[Estado] SMALLINT NOT NULL,
)

ALTER TABLE [Tbl_Usuario]
	ADD CONSTRAINT UC_Cedula_Usuario UNIQUE (Cedula);

ALTER TABLE [Tbl_Usuario]
	ADD FOREIGN KEY (Estado) REFERENCES Tbl_EstadoUsuario(Id);

ALTER TABLE [Tbl_Usuario]
	ADD FOREIGN KEY (Perfil_Id) REFERENCES Tbl_Perfil(Id);

GO

--DROP TABLE [Tbl_Cliente]
CREATE TABLE [dbo].[Tbl_Cliente]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Direccion] VARCHAR(50) NOT NULL,
	[FechaCreacion] DATETIME NOT NULL
)

ALTER TABLE [Tbl_Cliente]
	ADD FOREIGN KEY (Id) REFERENCES Tbl_Usuario(Id);



GO

--DROP TABLE [Tbl_Cuenta]
CREATE TABLE [dbo].[Tbl_Cuenta]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[NoCuenta] VARCHAR(12) NOT NULL UNIQUE,
	[ClienteId] INT NOT NULL,
	[Monto] Decimal(20,2) NOT NULL,
	[FechaCreacion] Datetime NOT NULL
)

ALTER TABLE [Tbl_Cuenta]
	ADD [MontoAlCorte] DECIMAL (20, 2) NOT NULL DEFAULT (0)

ALTER TABLE [Tbl_Cuenta]
	ADD FOREIGN KEY (ClienteId) REFERENCES Tbl_Cliente(Id);

GO

--update [Tbl_Cuenta] set Monto = 500

--DROP TABLE [Tbl_BeneficiarioEstado]
CREATE TABLE [dbo].[Tbl_BeneficiarioEstado]
(
	[Id] SMALLINT PRIMARY KEY NOT NULL,
	[Nombre] VARCHAR(50) NOT NULL,
	[FechaCreacion] DATETIME NOT NULL
)

INSERT INTO [dbo].[Tbl_BeneficiarioEstado] VALUES (0, 'Inactivo', GETDATE());
INSERT INTO [dbo].[Tbl_BeneficiarioEstado] VALUES (1, 'Activo', GETDATE());

GO
--DROP TABLE [Tbl_Beneficiario]
CREATE TABLE [dbo].[Tbl_Beneficiario]
(
	[ClienteId] INT NOT NULL,
	[Alias] VARCHAR(100) NULL,
	[CuentaDestinoId] INT NOT NULL,
	[FechaCreacion] DATETIME NOT NULL,
	[Estado] SMALLINT NOT NULL,
	PRIMARY KEY(ClienteId, CuentaDestinoId)
)

--delete [Tbl_Beneficiario]

ALTER TABLE [Tbl_Beneficiario]
	ADD FOREIGN KEY (ClienteId) REFERENCES Tbl_Usuario(Id);

ALTER TABLE [Tbl_Beneficiario]
	ADD FOREIGN KEY (CuentaDestinoId) REFERENCES Tbl_Cuenta(Id);

ALTER TABLE [Tbl_Beneficiario]
	ADD FOREIGN KEY (Estado) REFERENCES Tbl_BeneficiarioEstado(Id);


GO

--DROP TABLE [Tbl_TipoTransaccion]
CREATE TABLE [dbo].[Tbl_TipoTransaccion]
(
	[Id] SMALLINT NOT NULL PRIMARY KEY,
	[Nombre] VARCHAR(50) NOT NULL,
	[Estado] BIT NOT NULL
)

INSERT INTO [dbo].[Tbl_TipoTransaccion] VALUES (1, 'Deposito', 1);
INSERT INTO [dbo].[Tbl_TipoTransaccion] VALUES (2, 'Retiro', 1);
INSERT INTO [dbo].[Tbl_TipoTransaccion] VALUES (3, 'Transferencia Interna', 1);
INSERT INTO [dbo].[Tbl_TipoTransaccion] VALUES (4, 'Transferencia Externa', 1);

GO
CREATE TABLE [dbo].[Tbl_EstadoTransaccion]
(
	[Id] SMALLINT NOT NULL PRIMARY KEY,
	[Nombre] VARCHAR(50) NOT NULL
)

INSERT INTO [dbo].[Tbl_EstadoTransaccion] VALUES (0, 'Cancelado');
INSERT INTO [dbo].[Tbl_EstadoTransaccion] VALUES (1, 'En proceso');
INSERT INTO [dbo].[Tbl_EstadoTransaccion] VALUES (2, 'Realizado');

GO


--DROP TABLE [Tbl_OperacionCajaTipo]
CREATE TABLE [dbo].[Tbl_OperacionCajaTipo]
(
	[Id] SMALLINT NOT NULL,
	[Nombre] VARCHAR(50) NOT NULL,
	[Estado] BIT NOT NULL
	PRIMARY KEY(Id)
)

INSERT INTO [dbo].[Tbl_OperacionCajaTipo] VALUES (1, 'Apertura de caja', 1);
INSERT INTO [dbo].[Tbl_OperacionCajaTipo] VALUES (2, 'Cierre de caja', 1);
INSERT INTO [dbo].[Tbl_OperacionCajaTipo] VALUES (3, 'Entrada de efectivo', 1);
INSERT INTO [dbo].[Tbl_OperacionCajaTipo] VALUES (4, 'Salida de efectivo', 1);

--DROP TABLE [Tbl_Sucursal]
CREATE TABLE [dbo].[Tbl_Sucursal]
(
	[Id] SMALLINT IDENTITY(1, 1)  NOT NULL,
	[Descripcion] VARCHAR(200) NOT NULL,
	[Estado] BIT NOT NULL -- 0 - No disponible, 1 - Disponible
	PRIMARY KEY(Id)
)

GO

--DROP TABLE [Tbl_Caja]
CREATE TABLE [dbo].[Tbl_Caja]
(
	[Id] INT  NOT NULL,
	[Descripcion] VARCHAR(200) NOT NULL,
	[FechaCreacion] DATETIME NOT NULL,
	[Monto] DECIMAL(20,2) NOT NULL,
	[Estado] BIT NOT NULL -- 0 - No disponible, 1 - Disponible
	PRIMARY KEY(Id)
)

ALTER TABLE [Tbl_Caja]
	ADD [SucursalId] SMALLINT NULL;

ALTER TABLE [Tbl_Caja]
	ADD FOREIGN KEY (SucursalId) REFERENCES Tbl_Sucursal(Id);

ALTER TABLE [Tbl_Caja]
	ADD FOREIGN KEY (Id) REFERENCES Tbl_Usuario(Id);

GO

--DROP TABLE [Tbl_OperacionCaja]
CREATE TABLE [dbo].[Tbl_OperacionCaja]
(
	[Id] BIGINT IDENTITY(1, 1) NOT NULL,
	[TipoId] SMALLINT NOT NULL,
	[CajaId] INT NOT NULL,
	[Fecha] DATETIME NOT NULL,
	[Monto] DECIMAL(20,2) NOT NULL,
	[Estado] BIT NOT NULL
	PRIMARY KEY(Id)
)

ALTER TABLE [Tbl_OperacionCaja]
	ADD FOREIGN KEY (TipoId) REFERENCES Tbl_OperacionCajaTipo(Id);

	
ALTER TABLE [Tbl_OperacionCaja]
	ADD FOREIGN KEY (CajaId) REFERENCES Tbl_Caja(Id);


GO
--DROP TABLE [Tbl_Transaccion]
CREATE TABLE [dbo].[Tbl_Transaccion]
(
	[Id] BIGINT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[TipoTransaccionId] SMALLINT NOT NULL,
	[Monto] DECIMAL(20,2) NOT NULL,
	[Fecha] DATETIME NOT NULL,
	[CuentaId] INT NOT NULL,
	[CuentaDestinoId] INT NULL,
	[OperacionCajaId] BIGINT NULL,
	[Estado] SMALLINT NOT NULL
)

ALTER TABLE [Tbl_Transaccion] 
	ADD [Concepto] VARCHAR(200) NOT NULL DEFAULT ('')

ALTER TABLE [Tbl_Transaccion]
	ADD FOREIGN KEY (TipoTransaccionId) REFERENCES Tbl_TipoTransaccion(Id);

ALTER TABLE [Tbl_Transaccion]
	ADD FOREIGN KEY (Estado) REFERENCES Tbl_EstadoTransaccion(Id);

ALTER TABLE [Tbl_Transaccion]
	ADD FOREIGN KEY (CuentaId) REFERENCES Tbl_Cuenta(Id);

ALTER TABLE [Tbl_Transaccion]
	ADD FOREIGN KEY (CuentaDestinoId) REFERENCES Tbl_Cuenta(Id);
	
ALTER TABLE [Tbl_Transaccion]
	ADD FOREIGN KEY (OperacionCajaId) REFERENCES Tbl_OperacionCaja(Id);



GO

CREATE TABLE [dbo].[Log4NetLog] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Date]      DATETIME       NOT NULL,
    [Thread]    VARCHAR (255)  NOT NULL,
    [Level]     VARCHAR (50)   NOT NULL,
    [Logger]    VARCHAR (255)  NOT NULL,
    [Message]   VARCHAR (4000) NOT NULL,
    [Exception] VARCHAR (2000) NULL,
    CONSTRAINT [PK_Log4NetLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO

CREATE PROCEDURE [dbo].[ppLog4net]

    @log_date datetime,  
    @Thread varchar(255),  
    @log_level varchar(50),  
    @Logger varchar(255),  
    @Message varchar(4000),  
    @Exception varchar(2000)
AS
	INSERT INTO dbo.Log4NetLog ([Date],[Thread],[Level],[Logger],[Message],[Exception]) VALUES (@log_date, @thread, @log_level,@Logger, @message, @exception)
RETURN 0