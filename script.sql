
--create database estagio;
--use estagio;
-- Criação da tabela tb_usuario
CREATE TABLE tb_usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nom_usuario VARCHAR(50) NOT NULL,
    lgn_usuario VARCHAR(50) NOT NULL,
	dsc_email varchar(max) NOT NULL,
	dat_atualizacao datetime NOT NULL,
    psw_hash VARBINARY(MAX) NULL,
    psw_salt VARBINARY(MAX) NULL,
    id_tpperfil INT NOT NULL
);

-- Criação da tabela tb_tarefa
CREATE TABLE tb_tpperfil (
    id_tpperfil INT PRIMARY KEY,
    dsc_tpperfil VARCHAR(50) NULL
);

-- Criação da tabela tb_tarefa
CREATE TABLE tb_tarefa (
    id_tarefa INT IDENTITY(1,1) PRIMARY KEY,
    dsc_tarefa VARCHAR(50) NULL
);

-- Criação da tabela tb_tarefausuario
CREATE TABLE tb_tarefausuario (
    id_usuario INT NOT NULL,
    id_tarefa INT NOT NULL,
    flg_concluida BIT NOT NULL DEFAULT 0, -- Coluna booleana com valor padrão false
    PRIMARY KEY (id_usuario, id_tarefa),
    FOREIGN KEY (id_usuario) REFERENCES tb_usuario(id_usuario),
    FOREIGN KEY (id_tarefa) REFERENCES tb_tarefa(id_tarefa)
);


INSERT INTO tb_tarefa (dsc_tarefa) VALUES ('Instalação');
INSERT INTO tb_tarefa (dsc_tarefa) VALUES ('Configuração');
INSERT INTO tb_tarefa (dsc_tarefa) VALUES ('Criar Projeto');
INSERT INTO tb_tarefa (dsc_tarefa) VALUES ('Exercício Prático');
INSERT INTO tb_tarefa (dsc_tarefa) VALUES ('Teste');