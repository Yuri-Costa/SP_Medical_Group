---------------------------DDL---------------------------

CREATE DATABASE SP_MEDICAL_GROUP;
GO

USE SP_MEDICAL_GROUP;
GO
---------------------------------------------------

CREATE TABLE Clinicas
(
	IdClinica		INT PRIMARY KEY IDENTITY,  -- INT NESSE CASO RETORNA UM NUMERO INTEIRO
	Cnpj			VARCHAR(200) NOT NULL,  -- CHAR USADOS PARA VALORES QUE NÃO IRÃO MUDAR
	Endereco		VARCHAR(200),				-- VARCHAR USADO PARA TEXTOS QUE PODEM MUDAR
	NomeFantasia	VARCHAR(200) NOT NULL, 
	RazaoSocial		VARCHAR(200)
);
GO

---------------------------------------------------

CREATE TABLE Especialidades
(
	IdEspecialidade		INT PRIMARY KEY IDENTITY,
	Especialidade		VARCHAR(200) UNIQUE,	-- VARCHAR USADO PARA TEXTOS QUE PODEM MUDAR
);
GO

---------------------------------------------------

CREATE TABLE Situacao
(
	IdSituacao			INT PRIMARY KEY IDENTITY,
	Situacao			VARCHAR(200)			-- VARCHAR USADO PARA TEXTOS QUE PODEM MUDAR
);
GO

---------------------------------------------------

CREATE TABLE TipoUsuarios
(
	IdTipoUsuario		INT PRIMARY KEY IDENTITY,
	TipoUsuario			VARCHAR(200)			-- VARCHAR USADO PARA TEXTOS QUE PODEM MUDAR);
);
GO

---------------------------------------------------

CREATE TABLE Usuarios
(
	IdUsuario			INT PRIMARY KEY IDENTITY,
	IdTipoUsuario		INT FOREIGN KEY REFERENCES TipoUsuarios(IdTipoUsuario),
	Email				VARCHAR(200) UNIQUE NOT NULL,	-- VARCHAR USADO PARA TEXTOS QUE PODEM MUDAR
	Senha				VARCHAR(200) NOT NULL,			-- VARCHAR USADO PARA TEXTOS QUE PODEM MUDAR
	DataNascimento		Date NOT NULL,					-- DATE PARA DEFINIR UMA DATA 
	Rg					CHAR(9) UNIQUE NOT NULL,		-- CHAR USADOS PARA VALORES QUE NÃO IRÃO MUDAR
	Telefone			INT NOT NULL,					-- INT NESSE CASO RETORNA MULTIVALORES
	Cpf					CHAR(11) UNIQUE NOT NULL,		-- CHAR USADOS PARA VALORES QUE NÃO IRÃO MUDAR
	Endereco			VARCHAR(200) NOT NULL			-- VARCHAR USADO PARA TEXTOS QUE PODEM MUDAR
);
GO

---------------------------------------------------

CREATE TABLE Medicos
(
	IdMedico			INT PRIMARY KEY IDENTITY,		-- INT NESSE CASO RETORNA UM NUMERO INTEIRO
	IdEspecialidade		INT FOREIGN KEY REFERENCES Especialidades(IdEspecialidade),
	IdUsuario			INT FOREIGN KEY REFERENCES Usuarios(IdUsuario),
	IdClinica			INT FOREIGN KEY REFERENCES Clinicas(IdClinica),
	Nome				VARCHAR(200),					-- VARCHAR USADO PARA TEXTOS QUE PODEM MUDAR
	Crm					CHAR(5) UNIQUE NOT NULL,		-- CHAR USADOS PARA VALORES QUE NÃO IRÃO MUDAR
);
GO

---------------------------------------------------

CREATE TABLE Pacientes
(
	IdPaciente			INT PRIMARY KEY IDENTITY,		-- INT NESSE CASO RETORNA UM NUMERO INTEIRO
	IdUsuario			INT FOREIGN KEY REFERENCES Usuarios(IdUsuario),
	Nome				VARCHAR(200),					-- VARCHAR USADO PARA TEXTOS QUE PODEM MUDAR
	Rg					VARCHAR(200),			-- INT COM UNIQUE RETORNA UM NUMERO INTEIRO QUE NÃO IRÁ SE REPETIR
	Telefone			VARCHAR(200),					-- INT NESSE CASO RETORNA MULTIVALORES
	Cpf					VARCHAR(200),			-- INT COM UNIQUE RETORNA UM NUMERO INTEIRO QUE NÃO IRÁ SE REPETIR
	NumCartao			VARCHAR(200),			-- INT COM UNIQUE RETORNA UM NUMERO INTEIRO QUE NÃO IRÁ SE REPETIR
);
GO

---------------------------------------------------

CREATE TABLE Consultas
(
	IdConsulta			INT PRIMARY KEY IDENTITY,		-- INT NESSE CASO RETORNA UM NUMERO INTEIRO
	IdPaciente			INT FOREIGN KEY REFERENCES Pacientes(IdPaciente),
	IdMedico			INT FOREIGN KEY REFERENCES Medicos(IdMedico),
	IdSituacao			INT FOREIGN KEY REFERENCES Situacao(IdSituacao),
	DataConsulta		DATE NOT NULL					-- DATE PARA DEFINIR UMA DATA 
);
GO

---------------------------------------------------
