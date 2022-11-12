use mauricio_ferraguz;

drop table if exists favEvento;
drop table if exists favEquipo;
drop table if exists usuario;
drop table if exists publicidadEquipo;
drop table if exists publicidadDeporte;
drop table if exists publicidad;
drop table if exists suceso;
drop table if exists Alineacion;
drop table if exists deportistaEquipo;
drop table if exists equiposEvento;
drop table if exists Evento;
drop table if exists club;
drop table if exists seleccion;
drop table if exists deportista;
drop table if exists EquipoFase;
drop table if exists EquipoTorneo;
drop table if exists equipo;
drop table if exists fase;
drop table if exists torneoNacional;
drop table if exists Torneo;
drop table if exists deporte;
drop table if exists magnitud;
drop table if exists pointDataSet;
drop table if exists setData;
drop table if exists sets;
drop table if exists pointData;
drop table if exists puntos;
drop table if exists sistema;

create table sistema (
nombre varchar(30) not null,
primary key (nombre)
);

create table puntos (
nombreSist varchar(30) not null,

primary key(nombreSist),
foreign key(nombreSist) references sistema(nombre) on delete cascade	on update cascade
);

create table pointData (
nombreSist varchar(30) not null,
pointName varchar(30) not null,
pointValue int not null,

unique(pointName),

primary key(nombreSist,pointName),
foreign key	(nombreSist) references puntos(nombreSist) on delete cascade on update cascade
);

create table sets (
nombreSist varchar(30) not null,

primary key(nombreSist),
foreign key (nombreSist) references sistema(nombre) on delete cascade	on update cascade
);

create table setData (
nombreSist varchar(30) not null,
id int not null,
cantSets int not null,
delimitadorSet int not null,
suma_Indiv bool not null, # suma 0 individual 1

primary key(nombreSist,id),
foreign key (nombreSist) references sets(nombreSist) on delete cascade	on update cascade
);

create table pointDataSet (
nombreSist varchar(30) not null,
id int not null,
pointName varchar(30) not null,
pointValue int not null,
unique(id,pointName),

primary key(nombreSist,id,pointName),
foreign key (nombreSist,id) references setData(nombreSist,id) on delete cascade	on update cascade
);

create table magnitud (
nombreSist varchar(30) not null,
magnitud int not null,  #index del comboBox

foreign key (nombreSist) references sistema(nombre) on delete cascade	on update cascade,
primary key(nombreSist)
);

create table deporte (
sisPuntaje varchar(30) not null,
nombreDep varchar(30) not null,
nombreCorto varchar(12) not null unique,
indiv_Equip bool not null,    # Individual 1    equipo 0
N_titulares int not null,
logo longtext not null,
descripcion text,
cantEquipos int not null, #Cantidad de equipos en un enfrentamiento simultaneamente

primary key (nombreDep),
foreign key (sisPuntaje) references sistema(nombre) on delete cascade	on update cascade
);

create table Torneo (
nombreTorn varchar(30) not null,
nombreCorto varchar(12) not null unique,
Trofeo varchar(30), #nombre del trofeo
icono longtext,
estado int not null, # 0 pendiente , 1 en proceso, 2 terminado
nombreDep varchar(30) not null,

foreign key (nombreDep) references deporte(nombreDep) on delete cascade	on update cascade,
primary key (nombreTorn)
);

create table torneoNacional (
nombreTorn varchar(30) not null,
pais varchar(30) not null,

foreign key (nombreTorn) references Torneo(nombreTorn) on delete cascade	on update cascade,
primary key (nombreTorn)
);

create table fase (
idfase int not null, #para ordenar visualmente
cantEnfrentamientos int not null,
nombreFase varchar(50) not null,
fechaPrevista date not null,
estado int not null, # 0 pendiente , 1 en proceso, 2 terminado
nombreTorn varchar(30) not null,
final bool not null,
CondIngreso int, # 0 Derrota, 1 Victoria, 2 Personalizado  

foreign key (nombreTorn) references Torneo(nombreTorn) on delete cascade	on update cascade,
primary key (nombreFase,nombreTorn)
);

create table equipo (
nombreEqu varchar(30) not null,
nombreCorto varchar(12) not null,
logo longtext not null,
texto1 text,
texto2 text,
nombreDep varchar(30) not null,

foreign key (nombreDep) references deporte(nombreDep) on delete cascade	on update cascade,
primary key (nombreEqu)
);

create table EquipoTorneo (
nombreEqu varchar(30) not null,
nombreTorn varchar(50) not null,
foreign key (nombreTorn) references Torneo(nombreTorn) on delete cascade	on update cascade,
foreign key (nombreEqu) references equipo(nombreEqu) on delete cascade	on update cascade,
primary key (nombreEqu,nombreTorn)
);

create table EquipoFase (
nombreEqu varchar(30) not null,
nombreTorn varchar(30) not null,
nombreFase varchar(50) not null,

foreign key (nombreEqu,nombreTorn) references EquipoTorneo(nombreEqu,nombreTorn) on delete cascade	on update cascade,
foreign key (nombreFase,nombreTorn) references fase(nombreFase,nombreTorn) on delete cascade	on update cascade,
primary key (nombreEqu,nombreTorn,nombreFase)
);

create table deportista(
cedula int not null,
nombre varchar(30) not null,
edad int not null,
altura varchar(30) not null,
logo longtext not null,

primary key (cedula)
);

create table seleccion (
nombreEqu varchar(30) not null,
foreign key (nombreEqu) references equipo (nombreEqu) on delete cascade	on update cascade,
primary key (nombreEqu)
);

create table club (
nombreEqu varchar(30) not null,
pais varchar(30) not null,
foreign key (nombreEqu) references equipo (nombreEqu) on delete cascade	on update cascade,
primary key (nombreEqu,pais)
);

create table Evento(
fecha datetime not null,
estado int not null, #0 pendiente, 1 en proceso, 2 terminado
id int not null,
Titulo varchar(30) not null,
arbitros json,

nombreFase varchar(50) not null,
nombreTorn varchar(30) not null,

foreign key (nombreFase,nombreTorn) references fase(nombreFase,nombreTorn) on delete cascade	on update cascade,

primary key(id,nombreFase,nombreTorn)
);

create table equiposEvento(
id int not null,
nombreEqu varchar(30) not null,
nombreFase varchar(50) not null,
nombreTorn varchar(30) not null,

foreign key (id,nombreFase,nombreTorn) references Evento(id,nombreFase,nombreTorn) on delete cascade	on update cascade,
foreign key (nombreEqu,nombreTorn,nombreFase) references EquipoFase(nombreEqu,nombreTorn,nombreFase) on delete cascade	on update cascade,
primary key(id,nombreEqu,nombreFase,nombreTorn)
);

create table deportistaEquipo( 
nombreEqu varchar(30) not null,
cedula int not null,
numero int not null,
unique (nombreEqu,numero),
foreign key (nombreEqu) references equipo(nombreEqu) on delete cascade	on update cascade,
foreign key (cedula) references deportista(cedula) on delete cascade	on update cascade,
primary key (cedula,nombreEqu)
);

create table Alineacion(
id int not null,
nombreEqu varchar(30) not null,
numero int not null,
nombreFase varchar(50) not null,
nombreTorn varchar(30) not null,

posicion varchar(30) not null,

primary key (id,nombreEqu,numero,nombreFase,nombreTorn),
foreign key (id,nombreEqu,nombreFase,nombreTorn) references equiposEvento(id,nombreEqu,nombreFase,nombreTorn) on delete cascade	on update cascade,
foreign key (nombreEqu,numero) references deportistaEquipo(nombreEqu,numero) on delete cascade	on update cascade
);


create table suceso (
id int not null,
nombreEqu varchar(30) not null,
nombreFase varchar(50) not null,
numero int unique not null,
nombreTorn varchar(30) not null,

idSuceso int not null,
tipo int, #gol, falta, etc

jsons json,

hora int,

foreign key (id,nombreEqu,numero,nombreFase,nombreTorn) references Alineacion(id,nombreEqu,numero,nombreFase,nombreTorn) on delete cascade	on update cascade,
primary key (id,nombreEqu,numero,nombreFase,nombreTorn,idSuceso)
);

create table publicidad(
pais varchar(30),
tipo int not null, #banner 1 sky 0
imagen longtext not null,
identificador varchar(30) not null,

primary key (identificador)
);

create table publicidadDeporte(
identificador varchar(30) not null,
nombreDep varchar(30) not null,

primary key (identificador,nombreDep),
foreign key (nombreDep) references deporte(nombreDep) on delete cascade	on update cascade,
foreign key (identificador) references publicidad(identificador) on delete cascade on update cascade
);

create table publicidadEquipo(
identificador varchar(30) not null,
nombreEqu varchar(30) not null,

primary key (identificador,nombreEqu),
foreign key (nombreEqu) references equipo(nombreEqu) on delete cascade	on update cascade,
foreign key (identificador) references publicidad(identificador) on delete cascade on update cascade
);

create table usuario (
gmail varchar(50) not null,
dominio varchar(50) not null,
contra varchar(50) not null,
rol int not null not null,
nacimiento date not null,
nombre varchar(30) not null,
apellido varchar(30) not null,
pais varchar(30),
vencimiento date,

primary key (gmail,dominio)
);

create table favEquipo(
gmail varchar(50) not null,
dominio varchar(50) not null,
nombreEqu varchar(30) not null,

primary key (gmail,dominio,nombreEqu),
foreign key (gmail,dominio) references usuario(gmail,dominio) on delete cascade	on update cascade,
foreign key (nombreEqu) references equipo(nombreEqu) on delete cascade	on update cascade
);

create table favEvento(
gmail varchar(50) not null,
dominio varchar(50) not null,
id int not null,

primary key (gmail,dominio,id),
foreign key (gmail,dominio) references usuario(gmail,dominio) on delete cascade	on update cascade,
foreign key (id) references Evento(id) on delete cascade	on update cascade
);

/*

drop user if EXISTS 'User'@'localhost';
CREATE USER 'User'@'localhost' IDENTIFIED BY 'Ubdsdco.1';
GRANT SELECT ON TABLE arbitros TO 'User'@'localhost';
GRANT SELECT ON TABLE club TO 'User'@'localhost';
GRANT SELECT ON TABLE deporte TO 'User'@'localhost';
GRANT SELECT ON TABLE deportista TO 'User'@'localhost';
GRANT SELECT ON TABLE deportistaequipo TO 'User'@'localhost';
GRANT SELECT ON TABLE equipo TO 'User'@'localhost';
GRANT SELECT ON TABLE equipofase TO 'User'@'localhost';
GRANT SELECT ON TABLE equiposevento  TO 'User'@'localhost';
GRANT SELECT ON TABLE evento TO 'User'@'localhost';
GRANT SELECT ON TABLE eventofase TO 'User'@'localhost';
GRANT SELECT ON TABLE fase TO 'User'@'localhost';
GRANT SELECT ON TABLE publicidad TO 'User'@'localhost';
GRANT SELECT ON TABLE publicidaddeporte TO 'User'@'localhost';
GRANT SELECT ON TABLE publicidadequipo TO 'User'@'localhost';
GRANT SELECT ON TABLE seleccion TO 'User'@'localhost';
GRANT SELECT ON TABLE suceso TO 'User'@'localhost';
GRANT SELECT ON TABLE torneo TO 'User'@'localhost'; 
GRANT SELECT,INSERT,DELETE,UPDATE ON usuario TO 'User'@'localhost';

drop user if EXISTS 'PaidUser'@'localhost' ;
CREATE USER 'PaidUser'@'localhost' IDENTIFIED BY 'PUbdsdco.1253';
GRANT SELECT ON TABLE alineacion TO 'PaidUser'@'localhost';
GRANT SELECT ON TABLE arbitros TO 'PaidUser'@'localhost';
GRANT SELECT ON TABLE club TO 'PaidUser'@'localhost';
GRANT SELECT ON TABLE deporte TO 'PaidUser'@'localhost';
GRANT SELECT ON TABLE deportista TO 'PaidUser'@'localhost';
GRANT SELECT ON TABLE deportistaequipo TO 'PaidUser'@'localhost';
GRANT SELECT ON TABLE equipo TO 'PaidUser'@'localhost';
GRANT SELECT ON TABLE equipofase TO 'PaidUser'@'localhost';
GRANT SELECT ON TABLE equiposevento  TO 'PaidUser'@'localhost';
GRANT SELECT ON TABLE evento TO 'PaidUser'@'localhost';
GRANT SELECT ON TABLE eventofase TO 'PaidUser'@'localhost';
GRANT SELECT ON TABLE fase TO 'PaidUser'@'localhost';
GRANT SELECT ON TABLE seleccion TO 'PaidUser'@'localhost';
GRANT SELECT ON TABLE suceso TO 'PaidUser'@'localhost';
GRANT SELECT ON TABLE torneo TO 'PaidUser'@'localhost';
GRANT SELECT,INSERT,DELETE,UPDATE ON TABLE favequipo TO 'PaidUser'@'localhost';           
GRANT SELECT,INSERT,DELETE,UPDATE ON TABLE favevento TO 'PaidUser'@'localhost';
GRANT SELECT,INSERT,DELETE,UPDATE ON TABLE usuario TO 'PaidUser'@'localhost'; 

drop user if EXISTS 'Admin'@'localhost' ;
CREATE USER 'Admin'@'localhost' IDENTIFIED BY 'DBAdsdco_%.2';
GRANT ALL PRIVILEGES ON mysqlbdsdco TO 'Admin'@'localhost';

CREATE USER 'User'@'localhost' IDENTIFIED BY 'Ubdsdco.1';
CREATE USER 'Admin'@'localhost' IDENTIFIED BY 'DBAdsdco_%.2'
CREATE USER 'PaidUser'@'localhost' IDENTIFIED BY 'PUbdsdco.1253';
GRANT ALL PRIVILEGES ON mysqlbdsdco TO 'User'@'localhost';
GRANT ALL PRIVILEGES ON mysqlbdsdco TO 'Admin'@'localhost';
GRANT ALL PRIVILEGES ON mysqlbdsdco TO 'PaidUser'@'localhost';