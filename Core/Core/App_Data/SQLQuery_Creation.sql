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


ALTER TABLE [Tbl_Beneficiario]
	ADD FOREIGN KEY (IdCuenta) REFERENCES Tbl_Cuenta(Id);

ALTER TABLE [Tbl_Beneficiario]
	ADD FOREIGN KEY (IdCuentaDestino) REFERENCES Tbl_Cuenta(Id);
