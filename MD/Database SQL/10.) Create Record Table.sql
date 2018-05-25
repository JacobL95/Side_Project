use marriage_database;

create table `Record` (
`RecordID` bigint auto_increment not null unique,
`Groom_ID` int not null,
`Bride_ID` int not null,
`Papers_Recieved_Date` varchar(10) not null,
`Wedding_Date` varchar(10) not null,
`Dispensation_Type_Number` smallint not null unique,
`Additional_Circumstances_Note` varchar(256) not null,
`Dispensation_ID` smallint not null unique,
`Catholic_Party_ID` smallint not null unique,
`Approved_By` varchar(150) not null,
`Paperwork_Originated` smallint not null unique,
`Parish_Of_Wedding` smallint not null,
`Is_Parish_Outside_Of_Diocese` boolean not null,
`Officiant_Name` varchar(150) not null,
`Is_Convalidated` boolean not null,
`Has_Been_Annulled` boolean not null,
primary key(`RecordID`),
foreign key (`Groom_ID`) references `Groom`(`Groom_ID`) on delete restrict,
foreign key (`Bride_ID`) references `Bride`(`Bride_ID`) on delete restrict,
foreign key (`Dispensation_Type_Number`) references `Dispensation_Type`(`Dispensation_Type_Number`) on delete restrict,
foreign key (`Dispensation_ID`) references `Dispensation`(`Dispensation_ID`) on delete restrict,
foreign key (`Catholic_Party_ID`) references `Catholic_Party`(`Catholic_Party_ID`) on delete restrict,
foreign key (`Paperwork_Originated`) references `Parish`(`Parish_ID`) on delete restrict,
foreign key (`Parish_Of_Wedding`) references `Parish`(`Parish_ID`) on delete restrict
);