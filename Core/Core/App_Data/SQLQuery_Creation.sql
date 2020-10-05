--drop table Tbl_Usuario

CREATE TABLE [dbo].[Tbl_Usuario]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[UserName] VARCHAR(25) NOT NULL,
	[Password] VARBINARY NOT NULL,
	[Salt] VARCHAR(25) NOT NULL,
	[Nombre] VARCHAR(30) NOT NULL,
	[Apellido] VARCHAR(30) NOT NULL,
	[Telefono] VARCHAR(10) NOT NULL,
	[Cedula] VARCHAR(13) NOT NULL,
	[Perfil_Id] VARCHAR(25) NOT NULL,
	[FechaCreacion] DATETIME NOT NULL,
	[Estado] SMALLINT NOT NULL,
)

GO

CREATE TABLE [dbo].[Tbl_Beneficiario]
(
	[IdCuenta] INT NOT NULL,
	[IdCuentaDestino] INT NOT NULL,
	[FechaCreacion] DATETIME NOT NULL,
	[Estado] SMALLINT NOT NULL,
	PRIMARY KEY(IdCuenta, IdCuentaDestino)
)

GO

CREATE TABLE [dbo].[Tbl_Cuenta]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[ClienteId] INT NOT NULL,
	[Monto] Decimal(20,2) NOT NULL,
	[FechaCreacion] Datetime NOT NULL,
	PRIMARY KEY(Id)
)

GO

CREATE TABLE [dbo].[Tbl_Cliente]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Direccion] varchar(50) NOT NULL,
	[FechaCreacion] DATETIME NOT NULL,
	[UsuarioId] Int NOT NULL,
	PRIMARY KEY(Id)
)

GO

CREATE TABLE [dbo].[Tbl_BeneficiarioEstado]
(
	[Id] SmallINT IDENTITY(1, 1) NOT NULL,
	[Nombre] varchar(50) NOT NULL,
	[FechaCreacion] DATETIME NOT NULL
	PRIMARY KEY(Id)
)

GO

CREATE TABLE [dbo].[Tbl_Transaccion]
(
	[Id] BigINT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[TipoTransaccionId] smallint NOT NULL,
	[Monto] decimal(20,2) NOT NULL,
	[Fecha] DATETIME NOT NULL,
	[CuentaId] INT NOT NULL,
	[CajaId] INT NOT NULL
)

GO

CREATE TABLE [dbo].[Tbl_TipoTransaccion]
(
	[Id] SmallINT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Nombre] varchar(50) NOT NULL
)

GO

CREATE TABLE [dbo].[Tbl_EstadoUsuario]
(
	[Id] SmallINT IDENTITY(1, 1) NOT NULL,
	[Nombre] varchar(20) NOT NULL,
	[Estado] bit NOT NULL
	PRIMARY KEY(Id)
)

GO

CREATE TABLE [dbo].[Tbl_Perfil]
(
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[Nombre] varchar(50) NOT NULL,
	[Descripcion] varchar(200) NOT NULL,
	[Estado] bit NOT NULL
	PRIMARY KEY(Id)
)

GO

CREATE TABLE [dbo].[Tbl_Caja]
(
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[Descripcion] varchar(200) NOT NULL,
	[FechaCreacion] Datetime NOT NULL,
	[Monto] decimal(20,2) NOT NULL,
	[Estado] smallint NOT NULL
	PRIMARY KEY(Id)
)

CREATE TABLE [dbo].[Tbl_OperacionCaja]
(
	[Id] smallINT IDENTITY(1, 1) NOT NULL,
	[TipoId] smallint NOT NULL,
	[Fecha] Datetime NOT NULL,
	[Monto] decimal(20,2) NOT NULL,
	[Estado] bit NOT NULL
	PRIMARY KEY(Id)
)

GO

CREATE TABLE [dbo].[Tbl_OperacionCajaTipo]
(
	[Id] smallINT IDENTITY(1, 1) NOT NULL,
	[Nombre] varchar(50) NOT NULL,
	[Estado] bit NOT NULL
	PRIMARY KEY(Id)
)

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
--ALTER TABLE [Tbl_Beneficiario]
	--ADD FOREIGN KEY (IdCuenta) REFERENCES Tbl_Cuenta(Id);

--ALTER TABLE [Tbl_Beneficiario]
	--ADD FOREIGN KEY (IdCuentaDestino) REFERENCES Tbl_Cuenta(Id);
