use Marriage_Database;

Create table `Bride` (
`Bride_ID` int auto_increment not null unique,
`Bride_First_Name` varchar(50) not null,
`Bride_Middle_Int` varchar(2) not null,
`Bride_Last_Name` varchar (50) not null,
primary key (`Bride_ID`)
);