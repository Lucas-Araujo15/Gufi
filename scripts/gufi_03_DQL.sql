USE GUFI;
GO

SELECT * FROM usuario;
GO

SELECT * FROM tipoUsuario;
GO 

SELECT * FROM evento;
GO

SELECT * FROM instituicao;
GO

SELECT * FROM presenca;
GO

SELECT * FROM situacao;
GO

SELECT * FROM tipoEvento;
GO

SELECT nomeEvento, descricao, dataEvento, acessoLivre, nomeFantasia, tituloTipoEvento FROM evento 
INNER JOIN instituicao 
ON instituicao.idInstituicao = evento.idInstituicao
INNER JOIN tipoEvento
ON tipoEvento.IdTipoEvento = evento.idTipoEvento
GO

SELECT nomeUsuario Usuario, tituloTipoUsuario Tipo, email, senha FROM usuario
INNER JOIN tipoUsuario
ON tipoUsuario.idTipoUsuario = usuario.idTipoUsuario;
GO

SELECT nomeEvento, E.descricao, dataEvento, acessoLivre, nomeFantasia, tituloTipoEvento, nomeUsuario, tituloTipoUsuario, S.descricao FROM presenca
INNER JOIN usuario 
ON usuario.idUsuario = presenca.idUsuario
INNER JOIN tipoUsuario
ON tipoUsuario.idTipoUsuario = usuario.idTipoUsuario
INNER JOIN evento E
ON E.idEvento = presenca.idEvento
INNER JOIN instituicao
ON instituicao.idInstituicao = E.idInstituicao
INNER JOIN tipoEvento
ON tipoEvento.IdTipoEvento = E.idTipoEvento
INNER JOIN situacao S
ON S.idSituacao = presenca.idSituacao


SELECT nomeUsuario 'Nome do usuário', email Email FROM usuario WHERE email = 'lucas@email.com' AND senha = 'lucas123'
