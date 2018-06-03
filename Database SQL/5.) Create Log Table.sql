use Marriage_Database;

Create table `Log` (
`Log_ID` int auto_increment not null unique,
`User_Name` varchar(20) not null,
`Note` varchar(150) not null,
primary key (`Log_ID`),
foreign key(`User_Name`) references `Login`(`User_Name`) on delete restrict
);