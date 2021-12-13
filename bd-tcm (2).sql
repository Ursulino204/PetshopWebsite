create database db_tcm
default character set utf8
default collate utf8_general_ci;

use db_tcm;

create table tbl_usuarios(
    cd_usuario int primary key auto_increment,
    cpf_usuario varchar(11),
    nome_usuario varchar(80) not null,
    email_usuario varchar (80) not null,
    senha_usuario varchar(6) not null,
    endereco_usuario varchar(80) not null,
    cidade_usuario varchar(30) not null,
    cep_usuario char(9) not null,
    estado_usuario varchar (50)
 )   
 default charset utf8;
 
 create table tbl_pedidos(
    cod_pedido int primary key auto_increment,
    descr_pedido varchar(70) not null,
    data_pedido date,
    cod_cli int,
    cod_especie int,	
    cod_func int,
    cod_id_pag int,
    cod_pet int, 
    cod_raca int,
    constraint fk_cli foreign key(cod_cli) references tbl_clientes(cod_cli),
    constraint fk_especie foreign key(cod_especie) references tbl_especies(cod_especie),
    constraint fk_func foreign key(cod_func) references tbl_funcionarios(cod_func),
    constraint fk_pet foreign key(cod_pet) references tbl_pets(cod_pet),
	constraint fk_raca foreign key(cod_raca) references tbl_racas(cod_raca),
    constraint fk_pag foreign key(cod_id_pag) references tbl_pagamentos(cod_id_pag)
     )   
 default charset utf8;

select * from tbl_pedidos;

create table tbl_clientes(
	cod_cli int primary key auto_increment,
    cpf_cli varchar (15),
	nome_cli varchar (50),
	endereco_cli varchar (100),
	cidade_cli	varchar  (50),
	telefone_cli varchar(20),
	email_cli varchar (50),
	cep_cli varchar(10)
)
default charset utf8;

create table tbl_agendamentos(
 	cod_agen int primary key auto_increment,
    cod_servico int,
	data_agen date not null,
	categoria_agen varchar (20),
    constraint fk_serv foreign key(cod_servico) references tbl_servicos(cod_servico)
)
default charset utf8;

create table tbl_funcionarios(
	cod_func int primary key auto_increment,
	nome_func varchar(50)
)
default charset utf8;

create table tbl_servicos(
	cod_servico int primary key auto_increment,
    cod_funcionario int,
	cod_pet int,
	desc_servico varchar(100),
	valor_servico decimal (10,2),
	status_servico int(1) ,
	constraint fk_func foreign key (cod_funcionario ) references tbl_funcionarios(cod_funcionario ),
    constraint fk_pet foreign key (cod_pet ) references tbl_pets(cod_pet)
)
default charset utf8;

create table tbl_pagamentos(
	cod_id_pag int primary key auto_increment,
	metodo_pag varchar(30),
    valor_total float,
    cod_pedido int,
    constraint fk_pag foreign key(cod_pedido) references tbl_pedidos(cod_pedidos)
    )
default charset utf8;

create table tbl_especies(
	cod_especie int primary key ,
	nome_especie varchar(30)
)
default charset utf8;
ALTER TABLE tbl_especies
ADD cod_pet int;
ALTER TABLE tbl_especies ADD constraint fk_pets foreign key(cod_pet) references tbl_pets(cod_pet);

/** ----- tabela racas -----*/
create table tbl_racas(
	cod_raca int primary key,
	nome_raca varchar(30)
)
default charset utf8;
ALTER TABLE tbl_racas
ADD cod_especie int;
ALTER TABLE tbl_racas ADD constraint fk_especies foreign key(cod_especie) references tbl_especies(cod_especie);

/** ----- tabela pets -----*/
create table tbl_pets(
	cod_pet int primary key auto_increment,
	cod_especie int,
	nome_pet varchar (50),
	idade_pet decimal,
	sexo_pet varchar (20),
	constraint fk_especies foreign key(cod_especie) references tbl_especies(cod_especie)
)
default charset utf8;
/** ----- inserindo na tabela pets-----*/
insert into tbl_pets values(default,1,'zed',10,'M');
insert into tbl_pets values(default,2,'lux',6,'F');
insert into tbl_pets values(default,1,'Lulu',3,'F');
insert into tbl_pets values(default,1,'Nasus',2,'M');
insert into tbl_pets values(default,2,'yummi',2,'F');
/** ----- inserindo na tabela especie -----*/
	insert into tbl_especies values(1,'cachorro');
	insert into tbl_especies values(2,'gato');
/*---------------------------------*/
/*---------- consulta pet por especies ----------------*/ 
    select
    tbl_pets.cod_pet,
    tbl_pets.nome_pet,
    tbl_pets.idade_pet,
    tbl_pets.sexo_pet,
    tbl_pets.cod_especie,
    tbl_especies.nome_especie
    from tbl_pets 
    inner join tbl_especies
    on tbl_pets.cod_especie = tbl_especies.cod_especie ;    
    select
    tbl_racas.cod_raca,
    tbl_racas.nome_raca,
    tbl_especies.cod_especie,
    tbl_especies.nome_especie
    from tbl_racas
    inner join tbl_especies
    on tbl_racas.cod_raca = tbl_especies.cod_especie;
/*--------------------------------------------------------*/
	UPDATE tbl_pets
	SET cod_especie = 1, nome_pet = 'Talon', idade_pet = 5, sexo_pet = 'M'
	WHERE cod_pet = 3;
    select * from tbl_pets;
/** ----- inserindo na tabela especie -----*/
insert into tbl_especies values(1,'macho',3);
insert into tbl_especies values(2,'femea',2);
/*--------------------------------------------------------*/
ALTER TABLE tbl_especie ADD CONSTRAINT cod_fk_especie
FOREIGN KEY(fk_especie) REFERENCES tbl_especie (cod_petz);
Alter table tbl_especie
add constraint especie_fk
foreign key (cod_especie)
references tbl_especie (cod_especie);
/*------inserindo na tabela funcionarios--------*/
 insert into tbl_funcionario values(null,'sir','xd', 1500);
 /*--------------------------------------------------------*/ 
/*---------- Resetar a table auto increment  ----- */
 alter table tbl_pets auto_increment = 1;
 /*---------- fechar o reset da table auto increment  ----- */
 
 /*---------- deletar registros das tabela  ----- */
 delete  from tbl_pets where cod_pet = 3;  
/*---------- selects  ----- */
select * from tbl_funcionario;
select * from tbl_clientes;
select * from tbl_racas;
select * from tbl_especies;
select * from tbl_pagamentos;
select * from tbl_pets;
select * from tbl_servicos;
select * from tbl_agendamentos;
select * from tbl_usuarios;

/** insert pagamentos **/
insert into tbl_pagamentos values(null,'Débito','1');
insert into tbl_pagamentos values(null,'Crédito','2');

/** Insert Funcionarios **/
insert into tbl_funcionarios values(null,'alessandro');
/** Insert Clientes **/
insert into tbl_clientes values (null,'willian','rua americana n8','carapicuiba','novo brasil','32151111','hydrante@gmail.com','01466444','São Paulo');
/*-------------- inserts na tabela raca cachorros -----------------*/
insert into tbl_racas values (1,'Akita',1);
insert into tbl_racas values (2,'basset hound',1);
insert into tbl_racas values (3,'beagle',1);
insert into tbl_racas values (4,'Bichon frisé',1);
insert into tbl_racas values (5,'Boiadeiro australiano',1);
insert into tbl_racas values (6,'Border collie',1);
insert into tbl_racas values (7,'Boston terrier',1);
insert into tbl_racas values (8,'Buldogue francês',1);
insert into tbl_racas values (9,'Buldogue inglês',1);
insert into tbl_racas values (10,'Bull terrier',1);
insert into tbl_racas values (11,'Cane corso',1);
insert into tbl_racas values (12,'Cavalier king charles spaniel',1);
insert into tbl_racas values (13,'Chihuahua',1);
insert into tbl_racas values (14,'Chow chow',1);
insert into tbl_racas values (15,'Cocker spaniel inglês',1);
insert into tbl_racas values (16,'Dachshund',1);
insert into tbl_racas values (17,'Dálmata',1);
insert into tbl_racas values (18,'Doberman',1);
insert into tbl_racas values (19,'Dogo argentino',1);
insert into tbl_racas values (20,'Dogue alemão',1);
insert into tbl_racas values (21,'Fila brasileiro',1);
insert into tbl_racas values (22,'Golden retriever',1);
insert into tbl_racas values (23,'Husky siberiano',1);
insert into tbl_racas values (24,'Jack russell terrier',1);
insert into tbl_racas values (25,'Labrador retriever',1);
insert into tbl_racas values (26,'Lhasa apso',1);
insert into tbl_racas values (27,'Lulu da pomerânia',1);
insert into tbl_racas values (28,'Maltês',1);
insert into tbl_racas values (29,'Mastiff inglês',1);
insert into tbl_racas values (30,'Mastim tibetano',1);
insert into tbl_racas values (31,'Pastor alemão',1);
insert into tbl_racas values (32,'Pastor australiano',1);
insert into tbl_racas values (33,'Pastor de Shetland',1);
insert into tbl_racas values (34,'Pequinês',1);
insert into tbl_racas values (35,'Pinscher',1);
insert into tbl_racas values (36,'Pit bull',1);
insert into tbl_racas values (37,'Poodle',1);
insert into tbl_racas values (38,'Pug',1);
insert into tbl_racas values (39,'Rottweiler',1);
insert into tbl_racas values (40,'Schnauzer',1);
insert into tbl_racas values (41,'Shar-pei',1);
insert into tbl_racas values (42,'Shiba',1);
insert into tbl_racas values (43,'Shih tzu',1);
insert into tbl_racas values (44,'Staffordshire bull terrier',1);
insert into tbl_racas values (45,'Weimaraner',1);
insert into tbl_racas values (46,'Yorkshire',1);
/*------- fechamento da inserção na tabela raças de cachorros--------*/
/*-------------- inserts na tabela raça gatos -----------------*/
insert into tbl_racas values (47,'Abissínio',2);
insert into tbl_racas values (48,'Angorá',2);
insert into tbl_racas values (49,'Ashera',2);
insert into tbl_racas values (50,'Balinês',2);
insert into tbl_racas values (51,'Bengal',2);
insert into tbl_racas values (52,'Bombay',2);
insert into tbl_racas values (53,'Bobtail japonês',2);
insert into tbl_racas values (54,'Burmês',2);
insert into tbl_racas values (55,'Chartreux',2);
insert into tbl_racas values (56,'Cornish Rex',2);
insert into tbl_racas values (57,'Devon Rex',2);
insert into tbl_racas values (58,'Himalaio',2);
insert into tbl_racas values (59,'Jaguatirica',2);
insert into tbl_racas values (60,'Javanês',2);
insert into tbl_racas values (61,'Korat',2);
insert into tbl_racas values (62,'Maine Coon',2);
insert into tbl_racas values (63,'Manx',2);
insert into tbl_racas values (64,'Mau Egípcio',2);
insert into tbl_racas values (65,'Mist Australiano',2);
insert into tbl_racas values (66,'Munchkin',2);
insert into tbl_racas values (67,'Norueguês da Floresta',2);
insert into tbl_racas values (68,'Pelo curto americano',2);
insert into tbl_racas values (69,'Pelo curto brasileiro',2);
insert into tbl_racas values (70,'Pelo curto europeu',2);
insert into tbl_racas values (71,'Pelo curto inglês',2);
insert into tbl_racas values (72,'Persa',2);
insert into tbl_racas values (73,'Pixie-bob',2);
insert into tbl_racas values (74,'Ragdoll',2);
insert into tbl_racas values (75,'Ocicat',2);
insert into tbl_racas values (76,'Russo Azul',2);
insert into tbl_racas values (77,'Sagrado da Birmânia',2);
insert into tbl_racas values (78,'Savannah',2);
insert into tbl_racas values (79,'Scottish Fold',2);
insert into tbl_racas values (80,'Selkirk Rex',2);
insert into tbl_racas values (81,'Siamês',2);
insert into tbl_racas values (82,'Siberiano',2);
insert into tbl_racas values (83,'Singapura',2);
insert into tbl_racas values (84,'Somali',2);
insert into tbl_racas values (85,'Sphynx',2);
insert into tbl_racas values (86,'Thai',2);
insert into tbl_racas values (87,'Tonquinês',2);
insert into tbl_racas values (88,'Toyger',2);
insert into tbl_racas values (89,'Usuri',2);
insert into tbl_racas values (90,'Sem raça definida (SRD)',2);
/*-------- FECHAMENTO DA INSERÇÃO DE TABELA RAÇA GATOS ---------*/

