use Marriage_Database;

Create table `Catholic_Party` (
`Catholic_Party_ID` smallint auto_increment not null unique,
`Catholic_Party_Category` varchar(5) not null,
primary key (`Catholic_Party_ID`)
);