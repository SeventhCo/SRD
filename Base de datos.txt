create database MySQLbdsdco;
use MySQLbdsdco;

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

primary key(nombreSist,id,pointName),
foreign key (nombreSist,id) references setData(nombreSist,id) on delete cascade	on update cascade
);

create table magnitud (
nombreSist varchar(30) not null,
magnitud int not null,

foreign key (nombreSist) references sistema(nombre) on delete cascade	on update cascade,
primary key(nombreSist)
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

create table deporte (
sisPuntaje varchar(30) not null,
nombreDep varchar(30) not null,
nombreCorto varchar(12) not null,
indiv_Equip bool not null,    # Individual 1    equipo 0
N_titulares int not null,
logo longtext not null,
descripcion text,

primary key (nombreDep),
foreign key (sisPuntaje) references sistema(nombre) on delete cascade	on update cascade
);

create table torneo (
tipo varchar(30) not null,
nombreTorn varchar(30) not null,
nombreCorto varchar(12) not null,
nac_inter bool not null, #nacional 0 ; internacional 1
Trofeo varchar(30), #nombre del trofeo
icono longtext,
estado int not null,
nombreDep varchar(30) not null,
continuidad varchar(30) not null,


foreign key (nombreDep) references deporte(nombreDep) on delete cascade	on update cascade,
primary key (nombreTorn,nombreDep)
);

create table equipo (
nombreEqu varchar(30) not null,
nombreCorto varchar(12) not null,
logo longtext not null,
texto1 text,
texto2 text,
Presidente varchar(100),
Fundacion date,
primary key (nombreEqu)
);

create table deportista(
cedula int not null,
nombre varchar(30) not null,
edad date not null,
pais varchar(30) not null,
altura varchar(30) not null,

primary key (cedula,pais)
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

create table Evento (
fecha datetime not null,
estado int not null,
id int not null,
plantel longtext,
primary key (id)
);

create table arbitros (
id int not null,
arbitro varchar(30),

foreign key (id) references Evento(id) on delete cascade on update cascade,
primary key (id,arbitro)
);

create table equiposEvento(
id int not null,
nombreEqu varchar(30) not null,
foreign key (id) references Evento (id) on delete cascade	on update cascade,
foreign key (nombreEqu) references equipo (nombreEqu) on delete cascade	on update cascade,
primary key(nombreEqu,id)
);

create table deportistaEquipo(
nombreEqu varchar(30) not null,
cedula int not null,
pais varchar(30) not null,

foreign key (nombreEqu) references equipo(nombreEqu) on delete cascade	on update cascade,
foreign key (cedula,pais) references deportista(cedula,pais) on delete cascade	on update cascade,
primary key (cedula,pais,nombreEqu)
);

create table deportistaEvento(
id int not null,
nombreEqu varchar(30) not null,
cedula int not null,
pais varchar(30) not null,

foreign key (id,nombreEqu) references equiposEvento(id,nombreEqu) on delete cascade	on update cascade,
foreign key (nombreEqu,cedula,pais) references deportistaEquipo(nombreEqu,cedula,pais) on delete cascade	on update cascade,

primary key (id,nombreEqu,cedula,pais)
);

create table suceso (
idEvento int not null,
nombreEqu varchar(30) not null,
cedula int not null,
pais varchar(30) not null,

id int not null,
tipo int,
hora datetime,
comentario varchar(100),

foreign key (idEvento,nombreEqu,cedula,pais) references deportistaEvento(id,nombreEqu,cedula,pais) on delete cascade	on update cascade,

primary key (idEvento,nombreEqu,cedula,pais,id)
);


