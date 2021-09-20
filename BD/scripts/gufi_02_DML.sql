USE GUFI;
GO

INSERT INTO tipoUsuario(tituloTipoUsuario) VALUES ('Administrador'), ('Comum');
GO

INSERT INTO tipoEvento(tituloTipoEvento) VALUES ('C#'), ('ReactJS'), ('SQL');
GO

INSERT INTO instituicao(cnpj, nomeFantasia, endereco) VALUES ('99999999999999', 'Escola SENAI de Informática', 'Al. Barão de Limeira, 539');
GO

INSERT INTO situacao(descricao) VALUES ('Aprovada'), ('Recusada'), ('Aguardando');
GO

INSERT INTO usuario(idTipoUsuario, nomeUsuario, email, senha) VALUES 	(1, 'Administrador', 'adm@adm.com', 'adm123'), 
	(2, 'Lucas', 'lucas@email.com', 'lucas123'), 
	(2, 'Saulo', 'saulo@email.com', 'saulo123');
GO

INSERT INTO evento(idTipoEvento, idInstituicao, nomeEvento, acessoLivre, dataEvento, descricao) VALUES
	(1, 1, 'Orientação a objetos', 1, '18/08/2021 11:00', 'Conceitos sobre os pilares da programação orientada a objetos'), 
	( 2, 1, 'Ciclo de vida', 0, '19/08/2021 12:00', 'Como utilizar ciclos de vida com a biblioteca ReactJS');
GO

INSERT INTO presenca(idUsuario, idEvento, idSituacao) VALUES
	(2, 2, 3),
	(3, 1, 1);
GO