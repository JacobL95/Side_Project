use Marriage_Database;

Create table `Dispensation` (
`Dispensation_ID` smallint auto_increment not null unique,
`Dispensation_Category` varchar(20) not null,
primary key (`Dispensation_Category`)
);