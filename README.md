Приложения для 42

Для работы приложения нужно создать локальную базу данных 

Пример для MySQL:

drop database if exists fortytwo_band;
create database if not exists fortytwo_band;

use fortytwo_band;

create table if not exists Participants(
id_participant int primary key auto_increment,
FirstName char(255) not null,
LastName char(255) not null,
nickname char(255) not null,
Star_of_hype int
);

create table if not exists Leaders(
id_leader int primary key auto_increment,
participants_id int,
foreign key (participants_id) references participants(id_participant) ON DELETE CASCADE
);

create table if not exists Socials(
id_social int primary key auto_increment,
account_name char(255),
follower int,
participant_id int,
foreign key (participant_id) references participants(id_participant) ON DELETE CASCADE
);

create table if not exists Costumes(
id_dress int primary key auto_increment,
headwear text not null,
wear text not null,
pants text not null,
boots text not null,
participant_id int,
foreign key (participant_id) references participants(id_participant) ON DELETE CASCADE
);
