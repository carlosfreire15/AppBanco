
drop database dbExemplo;
create database dbExemplo;
use dbExemplo;
create table tbUsuario(
IdUsu int auto_increment primary key,
NomeUsu varchar(50) not null,
Cargo varchar(50) not null,
DataNasc datetime not null
);

insert into tbUsuario(NomeUsu,Cargo,DataNasc) values ('Enildo','Professor',STR_TO_DATE('17/03/2020','%d/%m/%Y'));
insert into tbUsuario(NomeUsu,Cargo,DataNasc) values ('Maria','Professora',STR_TO_DATE('12/04/2020 01:00:22','%d/%m/%Y %h:%i:%s'));

select * from tbUsuario;
