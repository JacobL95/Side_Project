Create Database Marriage_Database;

use Marriage_Database;

Create table `Groom` (
`Groom_ID` int auto_increment not null unique,
`Groom_First_Name` varchar(50) not null,
`Groom_Middle_Int` varchar(2) not null,
`Groom_Last_Name` varchar (50) not null,
primary key (`Groom_ID`)
);

insert into `Groom`(`Groom_ID`,`Groom_First_Name`,`Groom_Middle_Int`,`Groom_Last_Name`) values

(default, 'Christopher', 'R', 'Adair'),
(default, 'Scott', 'A', 'Adams');


Create table `Bride` (
`Bride_ID` int auto_increment not null unique,
`Bride_First_Name` varchar(50) not null,
`Bride_Middle_Int` varchar(2) not null,
`Bride_Last_Name` varchar (50) not null,
primary key (`Bride_ID`)
);

insert into `Bride`(`Bride_ID`,`Bride_First_Name`,`Bride_Middle_Int`,`Bride_Last_Name`) values

(default, 'Kelly', 'M', 'Harmon'),
(default, 'Erica', 'M', 'Weiser');

Create table `Login` (
`User_Name` varchar(20) not null unique,
`Password` varchar(20) not null,
primary key (`User_Name`)
);

insert into `Login`(`User_Name`,`Password`) values

('Admin', 'password');

Create table `Log` (
`Log_ID` int auto_increment not null unique,
`User_Name` varchar(20) not null,
`Note` varchar(150) not null,
primary key (`Log_ID`),
foreign key(`User_Name`) references `Login`(`User_Name`) on delete restrict
);

Create table `Dispensation_Type` (
`Dispensation_Type_Number` smallint auto_increment not null unique,
`Dispensation_Type` varchar(23) not null,
primary key (`Dispensation_Type_Number`)
);

insert into `Dispensation_Type`(`Dispensation_Type_Number`,`Dispensation_Type`) values

(default, 'NIHIL Obstat'),
(default, 'Ltr of Testimonial');

Create table `Dispensation` (
`Dispensation_ID` smallint auto_increment not null unique,
`Dispensation_Category` varchar(20) not null,
primary key (`Dispensation_Category`)
);

insert into `Dispensation`(`Dispensation_ID`,`Dispensation_Category`) values

(default, 'None'),
(default, 'Disparity of Cult'),
(default, 'Mixed Religon');

Create table `Catholic_Party` (
`Catholic_Party_ID` smallint auto_increment not null unique,
`Catholic_Party_Category` varchar(5) not null,
primary key (`Catholic_Party_ID`)
);

insert into `Catholic_Party`(`Catholic_Party_ID`,`Catholic_Party_Category`) values

(default, 'Both'),
(default, 'Bride'),
(default, 'Groom');


Create table `Parish` (
`Parish_ID` smallint auto_increment not null unique,
`Parish` varchar(60) not null,
primary key (`Parish_ID`)
);

insert into `Parish`(`Parish_ID`, `Parish`) values

(default, 'Blessed Sacrament, Bethany'),
(default, 'Cathedral of the Immaculate Conception, Kansas City'),
(default, 'Christ the King, Kansas City'),
(default, 'Church of the Annunciation, Kearney'),
(default, 'Church of the Good Shepherd, Smithville'),
(default, 'Church of the Holy Martyrs, Kansas City'),
(default, 'Church of the Santa Fe, Buckner'),
(default, 'Co-Cathedral of St. Joseph, St. Joseph'),
(default, 'Coronation of Our Lady, Grandview'),
(default, 'Guardian Angels, Kansas City'),
(default, 'Holy Cross, Kansas City'),
(default, 'Holy Family, Kansas City'),
(default, 'Holy Rosary, Clinton'),
(default, 'Holy Rosary, Kansas City'),
(default, 'Holy Spirit, Lee''s Summit'),
(default, 'Holy Trinity, Urich'),
(default, 'Holy Trinity, Weston'),
(default, 'Immaculate Conception, Lexington'),
(default, 'Immaculate Conception, Montrose'),
(default, 'Immaculate Conception, Richmond'),
(default, 'Immaculate Heart of Mary, Princeton'),
(default, 'Mary Immaculate, Gallatin '),
(default, 'Nativity of Blessed Virgin Mary, Independence'),
(default, 'Oratory of Old St. Patrick, Kansas City'),
(default, 'Our Lady of Good Counsel, Kansas City'),
(default, 'Our Lady of Guadalupe, St. Joseph'),
(default, 'Our Lady of Lourdes, Harrisonville'),
(default, 'Our Lady of Lourdes, Kansas City'),
(default, 'Our Lady of Peace, Kansas City'),
(default, 'Our Lady of Perpetual Help, Kansas City'),
(default, 'Our Lady of Sorrows, Kansas City'),
(default, 'Our Lady of the Presentation, Lee''s Summit'),
(default, 'Sacred Heart, Hamilton'),
(default, 'Sacred Heart, Norborne '),
(default, 'Sacred Heart, Warrensburg'),
(default, 'Sacred Heart-Guadalupe, Kansas City'),
(default, 'Seven Dolors, Hurlingen'),
(default, 'St. Aloysius, Maysville'),
(default, 'St. Andrew the Apostle, Kansas City'),
(default, 'St. Ann, Excelsior Springs'),
(default, 'St. Ann, Independence'),
(default, 'St. Ann, Plattsburg '),
(default, 'St. Anthony, Kansas City'),
(default, 'St. Bartholomew, Windsor'),
(default, 'St. Benedict, Burlington Junction'),
(default, 'St. Bernadette, Kansas City'),
(default, 'St. Bridget, Pleasant Hill'),
(default, 'St. Bridget, Rich Hill'),
(default, 'St. Catherine, Osceola'),
(default, 'St. Catherine of Siena, Kansas City'),
(default, 'St. Charles Borromeo, Kansas City'),
(default, 'St. Columba, Conception Junction '),
(default, 'St. Columban, Chillicothe'),
(default, 'St. Cyril, Sugar Creek'),
(default, 'St. Elizabeth, Kansas City'),
(default, 'St. Francis Xavier, Kansas City'),
(default, 'St. Francis Xavier, St. Joseph'),
(default, 'St. Gabriel Archangel, Kansas City'),
(default, 'St. George, Odessa'),
(default, 'St. Gregory Barbarigo, Maryville'),
(default, 'St. James, Kansas City'),
(default, 'St. James, Liberty'),
(default, 'St. James, St. Joseph'),
(default, 'St. John Francis Regis, Kansas City'),
(default, 'St. John LaLande, Blue Springs'),
(default, 'St. Joseph  the Worker, Independence'),
(default, 'St. Joseph, Easton'),
(default, 'St. Joseph, Parnell'),
(default, 'St. Joseph, Trenton'),
(default, 'St. Jude the Apostle, Oak Grove'),
(default, 'St. Louis, Kansas City'),
(default, 'St. Margaret  of Scotland, Lee''s Summit'),
(default, 'St. Mark, Independence'),
(default, 'St. Mary, Carrollton '),
(default, 'St. Mary, Higginsville'),
(default, 'St. Mary, Independence'),
(default, 'St. Mary, Nevada'),
(default, 'St. Mary, St. Joseph'),
(default, 'St. Matthew Apostle, Kansas City'),
(default, 'St. Monica, Kansas City'),
(default, 'St. Munchin, Cameron'),
(default, 'St. Patrick, Butler'),
(default, 'St. Patrick, Ford City'),
(default, 'St. Patrick, Forest City'),
(default, 'St. Patrick, Holden '),
(default, 'St. Patrick, Kansas City'),
(default, 'St. Patrick, St. Joseph'),
(default, 'St. Paul the Apostle, Tarkio'),
(default, 'St. Peter, Kansas City'),
(default, 'St. Peter, Stanberry'),
(default, 'St. Robert Bellarmine, Blue Springs '),
(default, 'St. Rose of Lima, Savannah'),
(default, 'St. Sabina, Belton'),
(default, 'St. Therese, Kansas City'),
(default, 'St. Therese Little Flower, Kansas City'),
(default, 'St. Thomas More, Kansas City'),
(default, 'Twelve Apostles Parish, Platte City'),
(default, 'Visitation, Kansas City');

create table `Record` (
`RecordID` bigint auto_increment not null unique,
`Groom_ID` int not null,
`Bride_ID` int not null,
`Wedding_Date` varchar(10) not null,
`Dispensation_ID` smallint not null unique,
`Parish_Of_Wedding` smallint not null,
`Is_Parish_Outside_Of_Diocese` varchar(200) not null,
`Catholic_Party_ID` smallint not null unique,
`Is_Convalidated` boolean not null,
`Civil_Marriage_Date` varchar(10) not null,
`Has_Been_Annulled` varchar(200) not null,
`Paperwork_Originated` smallint not null unique,
`Officiant_Name` varchar(150) not null,
`Papers_Recieved_Date` varchar(10) not null,
`Papers_Mailed` varchar(10) not null,
`Approved_By` varchar(150) not null,
`Additional_Circumstances_Note` varchar(256) not null,
primary key(`RecordID`),
foreign key (`Groom_ID`) references `Groom`(`Groom_ID`) on delete restrict,
foreign key (`Bride_ID`) references `Bride`(`Bride_ID`) on delete restrict,
foreign key (`Dispensation_ID`) references `Dispensation`(`Dispensation_ID`) on delete restrict,
foreign key (`Catholic_Party_ID`) references `Catholic_Party`(`Catholic_Party_ID`) on delete restrict,
foreign key (`Paperwork_Originated`) references `Parish`(`Parish_ID`) on delete restrict,
foreign key (`Parish_Of_Wedding`) references `Parish`(`Parish_ID`) on delete restrict
);

insert into `Record`(`RecordID`,`Groom_ID`,`Bride_ID`, `Wedding_Date`, `Dispensation_ID`, `Parish_Of_Wedding`,
`Is_Parish_Outside_Of_Diocese`, `Catholic_Party_ID`, `Is_Convalidated`, `Civil_Marriage_Date`, `Has_Been_Annulled`,
`Paperwork_Originated`, `Officiant_Name`, `Papers_Recieved_Date`, `Papers_Mailed`, `Approved_By`, `Additional_Circumstances_Note`)values


(default, 1, 1, '3/17/2018', 1, 40, 'No', 1, 1, '10/7/2000',
'No', 40, 'Rev. Daniel Gill', '3/9/2018', '3/9/2018',
'Fr. Riley-VG-Chancellor', 'N/A');
