use Marriage_Database;

Create table `Groom` (
`Groom_ID` int auto_increment not null unique,
`Groom_First_Name` varchar(50) not null,
`Groom_Middle_Int` varchar(2) not null,
`Groom_Last_Name` varchar (50) not null,
primary key (`Groom_ID`)
);