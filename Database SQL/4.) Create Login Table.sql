use Marriage_Database;

Create table `Login` (
`User_Name` varchar(20) not null unique,
`Password` varchar(20) not null,
primary key (`User_Name`)
);