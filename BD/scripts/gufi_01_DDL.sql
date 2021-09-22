CREATE DATABASE GUFI;
GO

USE GUFI;
GO

CREATE TABLE tipoUsuario (
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	tituloTipoUsuario VARCHAR(30) UNIQUE NOT NULL
);
GO

CREATE TABLE tipoEvento (
	IdTipoEvento INT PRIMARY KEY IDENTITY,
	tituloTipoEvento VARCHAR(100) UNIQUE NOT NULL
);
GO

CREATE TABLE instituicao (
	idInstituicao INT PRIMARY KEY IDENTITY,
	cnpj CHAR(14) UNIQUE NOT NULL,
	nomeFantasia VARCHAR(100) NOT NULL,
	endereco VARCHAR(250) UNIQUE NOT NULL
);
GO

CREATE TABLE situacao (
	idSituacao INT PRIMARY KEY IDENTITY,
	descricao VARCHAR(50)
);
GO

CREATE TABLE usuario (
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	nomeUsuario VARCHAR(50) NOT NULL,
	email VARCHAR(200) UNIQUE NOT NULL,
	senha VARCHAR(10) NOT NULL
);
GO

CREATE TABLE evento (
	idEvento INT PRIMARY KEY IDENTITY,
	idTipoEvento INT FOREIGN KEY REFERENCES tipoEvento(idTipoEvento),
	idInstituicao INT FOREIGN KEY REFERENCES instituicao (idInstituicao),
	nomeEvento VARCHAR(100) NOT NULL,
	descricao VARCHAR(400) NOT NULL,
	dataEvento DATETIME NOT NULL,
	acessoLivre BIT DEFAULT(1)
);
GO

CREATE TABLE presenca (
	idPresenca INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	idEvento INT FOREIGN KEY REFERENCES evento(idEvento),
	idSituacao INT FOREIGN KEY REFERENCES situacao(idSituacao) DEFAULT(3)
);
GO


CREATE TABLE ImagemPerfil (
	idImagemPerfil INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario) NOT NULL UNIQUE,
	binario VARBINARY(MAX) NOT NULL,
	dataCriacao DATETIME NOT NULL DEFAULT(GetDate()),
	mimeType VARCHAR(80) NOT NULL,
	nomeArquivo VARCHAR(50) NOT NULL
);
GO