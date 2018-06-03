use Marriage_Database;

Create table `Dispensation_Type` (
`Dispensation_Type_Number` smallint auto_increment not null unique,
`Dispensation_Type` varchar(23) not null,
primary key (`Dispensation_Type_Number`)
);