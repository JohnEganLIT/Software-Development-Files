CREATE DATABASE  IF NOT EXISTS `dbppb` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `dbppb`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: dbppb
-- ------------------------------------------------------
-- Server version	5.6.27-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `assignment`
--

DROP TABLE IF EXISTS `assignment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `assignment` (
  `EventID` int(11) NOT NULL,
  `GroupID` int(11) NOT NULL,
  `UserName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`GroupID`,`EventID`),
  UNIQUE KEY `EventID_UNIQUE` (`EventID`),
  KEY `fk_Assignment_Event1_idx` (`EventID`),
  KEY `fk_Assignment_Group1_idx` (`GroupID`),
  KEY `fk_assignment_user1_idx` (`UserName`),
  CONSTRAINT `fk_Assignment_Event1` FOREIGN KEY (`EventID`) REFERENCES `event` (`EventID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Assignment_Group1` FOREIGN KEY (`GroupID`) REFERENCES `group` (`GroupID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_assignment_user1` FOREIGN KEY (`UserName`) REFERENCES `user` (`UserName`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assignment`
--

LOCK TABLES `assignment` WRITE;
/*!40000 ALTER TABLE `assignment` DISABLE KEYS */;
/*!40000 ALTER TABLE `assignment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event` (
  `EventID` int(11) NOT NULL AUTO_INCREMENT,
  `EventCodeID` int(11) NOT NULL,
  `OffenceID` int(11) NOT NULL,
  `UserName` varchar(100) NOT NULL,
  `DateProcessed` date NOT NULL,
  `Photograph` text,
  PRIMARY KEY (`EventID`),
  UNIQUE KEY `EventID_UNIQUE` (`EventID`),
  KEY `fk_Event_EventCode1_idx` (`EventCodeID`),
  KEY `fk_Event_Offence1_idx` (`OffenceID`),
  KEY `fk_Event_User1_idx` (`UserName`),
  CONSTRAINT `fk_Event_EventCode1` FOREIGN KEY (`EventCodeID`) REFERENCES `eventcode` (`EventCodeID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Event_Offence1` FOREIGN KEY (`OffenceID`) REFERENCES `offence` (`OffenceID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Event_User1` FOREIGN KEY (`UserName`) REFERENCES `user` (`UserName`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event`
--

LOCK TABLES `event` WRITE;
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
/*!40000 ALTER TABLE `event` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventcode`
--

DROP TABLE IF EXISTS `eventcode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `eventcode` (
  `EventCodeID` int(11) NOT NULL,
  `Title` text NOT NULL,
  PRIMARY KEY (`EventCodeID`),
  UNIQUE KEY `EventCode_UNIQUE` (`EventCodeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventcode`
--

LOCK TABLES `eventcode` WRITE;
/*!40000 ALTER TABLE `eventcode` DISABLE KEYS */;
INSERT INTO `eventcode` VALUES (101,'Report Offence'),(102,'Notify Driver of Offence'),(103,'Fine Payment'),(104,'Fine Settled'),(105,'Fine Deadline Expired'),(106,'Report Court Summons'),(107,'Notify Driver of Court Summons'),(108,'Endorsement of Penalty Points'),(109,'Notify Driver of Endorsement'),(110,'Report Acquittal'),(111,'Notify Driver of Acquittal'),(112,'Report Conviction'),(113,'Notify Driver of Conviction'),(114,'Report Disqualification'),(115,'Notify Driver of Disqualification'),(116,'Report Unsuccessful Appeal'),(117,'Notify Driver of Unsuccessful Appeal'),(118,'Report Successful Appeal'),(119,'Notify Driver of Successful Appeal'),(120,'Automatic Disqualification'),(121,'Report Fine'),(122,'Notify Driver of Fine'),(201,'Public Notice of Regulations'),(202,'Staff Productivity'),(203,'Garda Productivity'),(204,'Speed Camera Effectiveness'),(206,'Offences by Roads'),(207,'Offences by County'),(208,'Offences by Age'),(209,'Penalty Points by Roads'),(210,'Penalty Points by County'),(211,'Penalty Points by Age'),(301,'New Amendment'),(302,'Regulation Terminated');
/*!40000 ALTER TABLE `eventcode` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fine`
--

DROP TABLE IF EXISTS `fine`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fine` (
  `FineID` int(11) NOT NULL AUTO_INCREMENT,
  `EventID` int(11) NOT NULL,
  `AmountPayable` decimal(10,0) NOT NULL,
  `CurrentBalance` decimal(10,0) NOT NULL,
  `OutstandingBalance` decimal(10,0) NOT NULL,
  `PaymentDeadline` date NOT NULL,
  PRIMARY KEY (`FineID`),
  UNIQUE KEY `FineID_UNIQUE` (`FineID`),
  UNIQUE KEY `EventID_UNIQUE` (`EventID`),
  KEY `fk_Fine_Event1_idx` (`EventID`),
  CONSTRAINT `fk_Fine_Event1` FOREIGN KEY (`EventID`) REFERENCES `event` (`EventID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fine`
--

LOCK TABLES `fine` WRITE;
/*!40000 ALTER TABLE `fine` DISABLE KEYS */;
/*!40000 ALTER TABLE `fine` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `group`
--

DROP TABLE IF EXISTS `group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `group` (
  `GroupID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text NOT NULL,
  `Leader` varchar(100) NOT NULL,
  `StandIn` varchar(100) NOT NULL,
  PRIMARY KEY (`GroupID`),
  UNIQUE KEY `GroupID_UNIQUE` (`GroupID`),
  KEY `fk_group_user1_idx` (`Leader`),
  KEY `fk_group_user2_idx` (`StandIn`),
  CONSTRAINT `fk_group_user1` FOREIGN KEY (`Leader`) REFERENCES `user` (`UserName`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_group_user2` FOREIGN KEY (`StandIn`) REFERENCES `user` (`UserName`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `group`
--

LOCK TABLES `group` WRITE;
/*!40000 ALTER TABLE `group` DISABLE KEYS */;
/*!40000 ALTER TABLE `group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `identity`
--

DROP TABLE IF EXISTS `identity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `identity` (
  `UserName` varchar(100) NOT NULL,
  `FirstName` text NOT NULL,
  `LastName` text NOT NULL,
  `StreetAddress` text NOT NULL,
  `CityAddress` text,
  `City` text NOT NULL,
  `County` text NOT NULL,
  `DateOfBirth` date NOT NULL,
  `Telephone` varchar(45) NOT NULL,
  `Photograph` text,
  PRIMARY KEY (`UserName`),
  UNIQUE KEY `UserID_UNIQUE` (`UserName`),
  KEY `fk_Identitiy_User1_idx` (`UserName`),
  CONSTRAINT `fk_Identitiy_User1` FOREIGN KEY (`UserName`) REFERENCES `user` (`UserName`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `identity`
--

LOCK TABLES `identity` WRITE;
/*!40000 ALTER TABLE `identity` DISABLE KEYS */;
INSERT INTO `identity` VALUES ('100','Gavin','O Dwyer','Marian Pk','','Clara','Offaly','1982-01-11','(062) 12345 Ext. 0',NULL),('101','Philip','Gray','38 Healy St','Bohercuill','Cork','Cork','1977-10-14','(062) 12345 Ext. 1',NULL),('102','Caitlin','Healy','27 Hillview Ard Mhuire Pk','Curragh Bridge','Galway','Galway','1992-05-29','(062) 12345 Ext. 2',NULL),('103','Dan','James','13 Main Street','Castleclose','Kilkenny Borough','Kilkenny','1997-01-08','(062) 12345 Ext. 3',NULL),('104','Keith','Tucker','Laragh','','Ballina','Tipperary','1965-11-15','(062) 12345 Ext. 4',NULL),('105','Mick','Taylor','Forramoyle','','Graiguenamanagh','Carlow','1982-03-26','(062) 12345 Ext. 5',NULL),('106','Richard','Campbell','48 Castle Riada Gro','Hillside','Kilkenny Borough','Kilkenny','1976-07-11','(062) 12345 Ext. 6',NULL),('107','Colin','McLean','Blackacre','','Askeaton','Limerick','1977-07-19','(062) 12345 Ext. 7',NULL),('108','Rosie','Marshall','10 The Mews','Cluain','Kilkenny Borough','Kilkenny','1999-12-29','(062) 12345 Ext. 8',NULL),('109','Madison','Davies','36 Rosmeen Pk','Baltinakin','Cork','Cork','1963-11-29','(062) 12345 Ext. 9',NULL),('110','Nathan','Moran','Castleboy','','Cahir','Tipperary','1983-04-08','(062) 12345 Ext. 0',NULL),('111','Laura','MacLeod','46 Monksfield Ave','Corabbey','Clonmel Borough','Tipperary','1982-11-07','(062) 12345 Ext. 1',NULL),('112','Madison','McGrath','Canrower','','Graiguenamanagh','Carlow','1995-12-14','(062) 12345 Ext. 2',NULL),('113','Ryan','Gray','26 Sunnyside','Honeypound','Carrigaline','Cork','1992-09-03','(062) 12345 Ext. 3',NULL),('114','Ethan','MacQuaid','Killagoola','','Oranmore','Galway','1988-02-06','(062) 12345 Ext. 4',NULL),('115','Julie','O Sullivan','30 Redwood Lawn','Glenbrack','Nenagh','Tipperary','1990-10-25','(062) 12345 Ext. 5',NULL),('116','Michael','Kane','Ballygulleen','','Kilrush','Clare','1978-11-07','(062) 12345 Ext. 6',NULL),('117','Lilly','Dyer','Ballyneelish','','Callan','Kilkenny','1994-02-10','(062) 12345 Ext. 7',NULL),('118','Louise','Bell','Baltinakin','','Emly','Tipperary','1979-02-21','(062) 12345 Ext. 8',NULL),('119','Diarmuid','Jones','45 Hillview Ard Mhuire Pk','Cahergowan','Clonmel Borough','Tipperary','1960-10-19','(062) 12345 Ext. 9',NULL),('120','Eva','Barry','36 Nutley Rd','Holly Pk','Kilkenny Borough','Kilkenny','1987-06-06','(062) 12345 Ext. 0',NULL),('121','Oran','Greene','6 Marlborough Rd','Carrabane','Carrick-on-Suir','Tipperary','1968-06-01','(062) 12345 Ext. 1',NULL),('122','Marcus','Randall','Gortnahorna','','Banagher','Offaly','2001-09-03','(062) 12345 Ext. 2',NULL),('123','Jason','O Brien','Embury Close','','Newport','Tipperary','1967-09-30','(062) 12345 Ext. 3',NULL),('124','Oliver','Mac Namara','Cloonkeen','','Cloghan','Offaly','1982-05-01','(062) 12345 Ext. 4',NULL),('125','Muireann','Wallace','31 Pine Valley Dr','Brierfield','Kilkenny Borough','Kilkenny','1970-02-24','(062) 12345 Ext. 5',NULL),('126','Denis','Nolan','44 Daarwood Cres','Ballyrune','Clonmel Borough','Tipperary','1975-07-11','(062) 12345 Ext. 6',NULL),('127','Mila','Dawley','45 St Brennans','Parkroe','Carrigaline','Cork','1964-06-20','(062) 12345 Ext. 7',NULL),('128','Mollie','Fitzgerald','49 Allenton Ave','Brooklawn','Cork','Cork','1958-03-07','(062) 12345 Ext. 8',NULL),('129','Caitlin','Dwyer','Brierfield','','Urlingford','Kilkenny','1974-08-19','(062) 12345 Ext. 9',NULL),('130','Stephanie','Marshall','Bungowla','','Roscrea','Tipperary','1992-07-31','(062) 12345 Ext. 0',NULL),('131','Laura','Peters','24 The Woods','Ballymarchaun','Ennis','Clare','1982-11-11','(062) 12345 Ext. 1',NULL),('132','Claire','Kelly','Newborough','','Tipperary','Tipperary','1959-02-01','(062) 12345 Ext. 2',NULL),('133','Brian','MacAteer','16 Estuary Rd','Creagh','Nenagh','Tipperary','1989-02-20','(062) 12345 Ext. 3',NULL),('134','Casey','McLean','39 Carrick Rd','Sunview','Carlow','Carlow','1981-09-11','(062) 12345 Ext. 4',NULL),('135','Mairead','Grant','2 Offington Ave','Ballycolgan','Waterford','Waterford','2000-07-24','(062) 12345 Ext. 5',NULL),('136','Emma','MacLeod','29 Cathedral Ave','Powersfield','Waterford','Waterford','1970-02-20','(062) 12345 Ext. 6',NULL),('137','Ciaran','Bailey','3 Wilson Rd','Rahard','Kilkenny Borough','Kilkenny','1955-10-31','(062) 12345 Ext. 7',NULL),('138','Christian','Wallace','5 Commons Upr','Ballycolgan','Ennis','Clare','1959-04-03','(062) 12345 Ext. 8',NULL),('139','Steven','MacCabe','7 Rowan Ave','Copperhill','Shannon','Clare','1973-05-29','(062) 12345 Ext. 9',NULL),('140','Jade','Hogan','39 Castlerock Ave','Fanamore','Thurles','Tipperary','1974-01-30','(062) 12345 Ext. 0',NULL),('141','Hanna','Mac Fadden','Kilmagoura','','Ballinakill','Laois','1999-05-19','(062) 12345 Ext. 1',NULL),('142','Martin','Mackay','Ahascragh','','Roscrea','Tipperary','1966-03-14','(062) 12345 Ext. 2',NULL),('143','Franky','Hughes','50 Friary Ct','Blackacre','Clonmel Borough','Tipperary','1992-07-03','(062) 12345 Ext. 3',NULL),('144','Meabh','Martin','Carragh','','Moneenroe','Kilkenny','1986-06-13','(062) 12345 Ext. 4',NULL),('145','Holly','MacGrath','14 Avonbeg Rd','Kilkerrin','Limerick','Limerick','1958-03-31','(062) 12345 Ext. 5',NULL),('146','Aoibhe','Bell','39 Bellevue','Ballyfleming','Clonmel Borough','Tipperary','1996-12-31','(062) 12345 Ext. 6',NULL),('147','Amy','Delaney','8 Geraldine Pl','Holycross','Tramore','Waterford','1997-05-02','(062) 12345 Ext. 7',NULL),('148','Lilly','Allen','Derryvode','','Clonlara','Clare','1999-07-04','(062) 12345 Ext. 8',NULL),('149','Emmet','Clery','26 Shielmartin Rd','Drumacoo','Tullamore','Offaly','1967-04-10','(062) 12345 Ext. 9',NULL),('150','Mia','MacGrath','Gouldavoher','','Rathdowney','Laois','1980-07-05','(062) 12345 Ext. 0',NULL),('151','Michael','Daly','45 Fairhill Dr','Kilmagoura','Galway','Galway','1994-04-02','(062) 12345 Ext. 1',NULL),('152','Ellie','O Riordan','42 Whitechurch Rd','Caherdaniel','Carrick-on-Suir','Tipperary','1990-09-25','(062) 12345 Ext. 2',NULL),('153','Matt','Conroy','36 Chapel Cl','Portacarron','Portlaoise','Laois','1955-01-18','(062) 12345 Ext. 3',NULL),('154','Chloe','Kelly','Lackaneen','','Holycross','Tipperary','1991-05-15','(062) 12345 Ext. 4',NULL),('155','Conor','Jones','2 The Woods','Carheeny','Limerick','Limerick','1998-08-04','(062) 12345 Ext. 5',NULL),('156','Julia','Hart','Hilltop','','Moroe','Limerick','1981-02-27','(062) 12345 Ext. 6',NULL),('157','Jasmine','Cameron','37 Belcamp Ave','Tobernea','Midleton','Cork','1985-01-30','(062) 12345 Ext. 7',NULL),('158','Marcus','Brown','34 Saggart Vlge','Canrower','Ennis','Clare','1958-06-30','(062) 12345 Ext. 8',NULL),('159','Victoria','McDonald','Portumna','','Cloghan','Offaly','1987-05-20','(062) 12345 Ext. 9',NULL),('160','Jade','Jackson','32 Ardcollum Ave','Brackvoan','Limerick','Limerick','1976-01-05','(062) 12345 Ext. 0',NULL),('161','Siobhan','Mills','Curragh Bridge','','Castlecomer','Kilkenny','2000-09-19','(062) 12345 Ext. 1',NULL),('162','Alanna','Fitzpatrick','17 Thornberry Ldg','Brackloon','Clonmel Borough','Tipperary','1980-02-27','(062) 12345 Ext. 2',NULL),('163','Evan','Higgins','Carheeny','','Rhode','Offaly','1981-10-15','(062) 12345 Ext. 3',NULL),('164','Connor','Hart','40 Cowper Rd','Kilconly','Clonmel Borough','Tipperary','1990-04-11','(062) 12345 Ext. 4',NULL),('165','Lily','Spillane','Cregduff','','Moneenroe','Kilkenny','1967-02-19','(062) 12345 Ext. 5',NULL),('166','Margaret','Mac Mahon','Whitehaven','','Kilrush','Clare','1997-04-21','(062) 12345 Ext. 6',NULL),('167','Maja','Brown','21 Meadows Vale','Riversview','Galway','Galway','2001-03-02','(062) 12345 Ext. 7',NULL),('168','Caoimhe','Bailey','40 CREMONA ROAD','Rockbrook','Cork','Cork','1971-10-31','(062) 12345 Ext. 8',NULL),('169','Maja','Kennedy','3 Ennafort Rd Raheny','Carnagopple','Kilkenny Borough','Kilkenny','1964-12-31','(062) 12345 Ext. 9',NULL),('170','Ritchie','Short','Ballinacourty','','Kilmacow','Kilkenny','1959-02-19','(062) 12345 Ext. 0',NULL),('171','Reece','Scott','22 Sunberry Dr','Farrihy','Galway','Galway','2001-10-17','(062) 12345 Ext. 1',NULL),('172','Oisin','MacGrath','Mountbellew','','Edenderry','Offaly','1992-05-22','(062) 12345 Ext. 2',NULL),('173','Kevin','Donohoe','39 Highfield Park','Ballinaboy','Limerick','Limerick','1971-02-02','(062) 12345 Ext. 3',NULL),('174','Millie','O Connor','40 Ardmore Park','Drinane','Cork','Cork','1966-08-31','(062) 12345 Ext. 4',NULL),('175','Poppy','Watson','33 Clontarf Rd','Gortmore','Cork','Cork','1962-02-16','(062) 12345 Ext. 5',NULL),('176','Noel','Flanagan','Castlelambert','','Two-Mile Borris','Tipperary','1997-02-23','(062) 12345 Ext. 6',NULL),('177','Margaret','Davidson','Annaghbane','','Clonbullogue','Offaly','2000-11-05','(062) 12345 Ext. 7',NULL),('178','Michael','James','27 Lauderdale Terrace','Silversprings','Carrick-on-Suir','Tipperary','1971-10-06','(062) 12345 Ext. 8',NULL),('179','Aimee','Coleman','26 Rush Rd','Sunberry','Kilkenny Borough','Kilkenny','1962-10-14','(062) 12345 Ext. 9',NULL),('180','Mary','Roberts','Ballinakill','','Roscrea','Tipperary','1998-07-24','(062) 12345 Ext. 0',NULL),('181','Abbie','Short','Millcove','','Ballycumber','Offaly','2001-06-16','(062) 12345 Ext. 1',NULL),('182','Bobby','Dowd','31 Oakcourt Ave','Ardskeaghmore','Carlow','Carlow','1978-09-19','(062) 12345 Ext. 2',NULL),('183','Amelia','Anderson','48 Mccurtain Hl','Blackacre','Shannon','Clare','1992-11-17','(062) 12345 Ext. 3',NULL),('184','Ryan','Higgins','6 Kellys Bay Dr','Castletownshend','Portlaoise','Laois','1990-10-03','(062) 12345 Ext. 4',NULL),('185','Jakub','Leahy','41 Fairlawns','Tobernea','Cork','Cork','1996-06-26','(062) 12345 Ext. 5',NULL),('186','Zoe','Harris','37 Constitution Hl','Dunganville','Clonmel Borough','Tipperary','1985-01-26','(062) 12345 Ext. 6',NULL),('187','Jamie','Flynn','The Weir','','Emly','Tipperary','1960-06-15','(062) 12345 Ext. 7',NULL),('188','Jodie','Campbell','9 Glen Ave','Tobernea','Portlaoise','Laois','1964-08-29','(062) 12345 Ext. 8',NULL),('189','Cillian','Whelan','38 Carrow Rd','The Weir','Dungarvan','Waterford','1987-06-18','(062) 12345 Ext. 9',NULL),('190','Abby','White','42 Foley St','Aughrim','Tullamore','Offaly','1991-03-02','(062) 12345 Ext. 0',NULL),('191','Chris','Daly','33 Limekiln Ave','Yellowbrick','Clonmel Borough','Tipperary','1961-09-12','(062) 12345 Ext. 1',NULL),('192','Brandon','Mac Nally','Ballymarchaun','','Edenderry','Offaly','1978-01-19','(062) 12345 Ext. 2',NULL),('193','Rian','Healy','Holly Pk','','Hacketstown','Carlow','1984-01-12','(062) 12345 Ext. 3',NULL),('194','Abbie','Fitzgerald','26 Chapel St','Castleboy','Nenagh','Tipperary','1976-03-31','(062) 12345 Ext. 4',NULL),('195','Shane','Bell','31 Canon Sheehan Tce','Windfield','Portlaoise','Laois','1958-04-25','(062) 12345 Ext. 5',NULL),('196','Aidan','Miller','42 Rockville Rd','Ballyneelish','Clonmel Borough','Tipperary','1992-05-06','(062) 12345 Ext. 6',NULL),('197','Marty','Sweeney','Corbally','','Newcastle West','Limerick','1953-08-08','(062) 12345 Ext. 7',NULL),('198','Alisha','Mac Loughlin','Caheradine','','Bennettsbridge','Kilkenny','1959-03-12','(062) 12345 Ext. 8',NULL),('199','Mary','Hogan','32 Shelton Pk','Ballyfleming','Nenagh','Tipperary','2001-05-05','(062) 12345 Ext. 9',NULL),('200','Denis','O Sullivan','9 Bakers Hill','Kilconly','Thurles','Tipperary','2001-03-02','(062) 12345 Ext. 0',NULL),('201','Ellen','Gallagher','10 Thomas St','Coolflugh Tower','Limerick','Limerick','1981-11-01','(062) 12345 Ext. 1',NULL),('202','Ruby','Hagan','Yellowbrick','','Ballina','Tipperary','1977-01-23','(062) 12345 Ext. 2',NULL),('203','Kayla','MacQuaid','11 St Fintans Pk','Newborough','Waterford','Waterford','1992-08-29','(062) 12345 Ext. 3',NULL),('204','Grace','Oliver','13 St Endas Rd','Friarstown','Clonmel Borough','Tipperary','1982-09-06','(062) 12345 Ext. 4',NULL),('205','Donnacha','O Hara','Moylan Pk','','Fethard','Tipperary','1960-06-29','(062) 12345 Ext. 5',NULL),('206','Aimee','O Shea','Ballymarchaun','','Askeaton','Limerick','1974-11-22','(062) 12345 Ext. 6',NULL),('207','Louise','Graham','37 Prague Castleknock Rd','Kilbeg','Galway','Galway','1988-01-12','(062) 12345 Ext. 7',NULL),('208','Heather','Manning','44 Woodlawn Way','Ballinakill','Cork','Cork','1997-03-24','(062) 12345 Ext. 8',NULL),('209','Jake','Johnston','34 Blackglen Rd','Ballygulleen','Galway','Galway','1955-06-07','(062) 12345 Ext. 9',NULL),('210','Clara','Darcy','43 St Endas Rd','Greenhills','Nenagh','Tipperary','1980-05-10','(062) 12345 Ext. 0',NULL),('211','Sofia','Edmunds','Drominboy','','Leighlinbridge','Carlow','1991-08-15','(062) 12345 Ext. 1',NULL),('212','Louise','Higgins','16 Sean Moylan Pk','Lurriga','Thurles','Tipperary','1972-09-11','(062) 12345 Ext. 2',NULL),('213','George','Darcy','24 Griffith Ave','Killpatrick','Dungarvan','Waterford','1999-04-02','(062) 12345 Ext. 3',NULL),('214','Eddy','Coleman','23 Clonkeen Dr','Coolreagh','Clonmel Borough','Tipperary','1955-12-07','(062) 12345 Ext. 4',NULL),('215','Maeve','Collins','Killimordaly','','Mooncoin','Kilkenny','1960-08-09','(062) 12345 Ext. 5',NULL),('216','Alicia','Dickens','46 Skreen Rd','Cloonkeen','Waterford','Waterford','1959-07-09','(062) 12345 Ext. 6',NULL),('217','Colm','Sharp','Ballyfruta','','Cashel','Tipperary','1989-07-23','(062) 12345 Ext. 7',NULL),('218','Cara','Paterson','Gortmore','','Foynes','Limerick','1978-01-14','(062) 12345 Ext. 8',NULL),('219','Mila','Duncan','Powersfield','','Edenderry','Offaly','1974-04-22','(062) 12345 Ext. 9',NULL);
/*!40000 ALTER TABLE `identity` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `login` (
  `UserName` varchar(100) NOT NULL,
  `Cipher` varchar(64) NOT NULL,
  PRIMARY KEY (`UserName`),
  UNIQUE KEY `UserID_UNIQUE` (`UserName`),
  KEY `fk_Cipher_User1_idx` (`UserName`),
  CONSTRAINT `fk_Cipher_User1` FOREIGN KEY (`UserName`) REFERENCES `user` (`UserName`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login`
--

LOCK TABLES `login` WRITE;
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` VALUES ('Ben','ce671754688f5dc1b25be14a4bb23f8f649cf697bb7dc086058f642265790b9f'),('Colin','70954e87ec733be4c7808e1f49726424020a3be163ce8b3a434a484daaff50d2'),('Ian','15d248124bc6cb0abf7838fa241c9b9aca22f7d53478a2fec7a50f9d9f8b4246'),('Mike','e436593ebe33b52f4ba3f658f65ff1850d4cd84f7bf571a0c7e01d69f31a84fb'),('Steve','f69aa1afe6cdbee93bf8dc6e6eee04c4e5a1beaf989e4f2e3858d80b8a8af558');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `member`
--

DROP TABLE IF EXISTS `member`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `member` (
  `UserName` varchar(100) NOT NULL,
  `GroupID` int(11) NOT NULL,
  PRIMARY KEY (`UserName`,`GroupID`),
  KEY `fk_Member_Group1_idx` (`GroupID`),
  CONSTRAINT `fk_Member_Group1` FOREIGN KEY (`GroupID`) REFERENCES `group` (`GroupID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Member_User1` FOREIGN KEY (`UserName`) REFERENCES `user` (`UserName`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `member`
--

LOCK TABLES `member` WRITE;
/*!40000 ALTER TABLE `member` DISABLE KEYS */;
/*!40000 ALTER TABLE `member` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `offence`
--

DROP TABLE IF EXISTS `offence`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `offence` (
  `OffenceID` int(11) NOT NULL AUTO_INCREMENT,
  `RegulationID` int(11) NOT NULL,
  `LicenceNo` int(11) NOT NULL,
  `VehicleReg` varchar(10) NOT NULL,
  `TimeAndDate` datetime NOT NULL,
  `Road` text NOT NULL,
  `County` text NOT NULL,
  PRIMARY KEY (`OffenceID`),
  UNIQUE KEY `OffenceID_UNIQUE` (`OffenceID`),
  KEY `fk_Offence_Regulation1_idx` (`RegulationID`),
  CONSTRAINT `fk_Offence_Regulation1` FOREIGN KEY (`RegulationID`) REFERENCES `regulation` (`RegulationID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `offence`
--

LOCK TABLES `offence` WRITE;
/*!40000 ALTER TABLE `offence` DISABLE KEYS */;
/*!40000 ALTER TABLE `offence` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organization`
--

DROP TABLE IF EXISTS `organization`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `organization` (
  `OrganizationID` varchar(3) NOT NULL,
  `Name` text NOT NULL,
  `Photograph` text,
  PRIMARY KEY (`OrganizationID`),
  UNIQUE KEY `OrganzationID_UNIQUE` (`OrganizationID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organization`
--

LOCK TABLES `organization` WRITE;
/*!40000 ALTER TABLE `organization` DISABLE KEYS */;
INSERT INTO `organization` VALUES ('GS','An Garda Síochána',NULL),('MLA','Motor Licencing Authority',NULL),('PPB','Penalty Points Bureau',NULL);
/*!40000 ALTER TABLE `organization` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment`
--

DROP TABLE IF EXISTS `payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment` (
  `PaymentID` int(11) NOT NULL AUTO_INCREMENT,
  `FineID` int(11) NOT NULL,
  `AmountPaid` decimal(10,0) NOT NULL,
  `DateAndTime` date NOT NULL,
  PRIMARY KEY (`PaymentID`),
  UNIQUE KEY `PaymentID_UNIQUE` (`PaymentID`),
  KEY `fk_Payment_Fine1_idx` (`FineID`),
  CONSTRAINT `fk_Payment_Fine1` FOREIGN KEY (`FineID`) REFERENCES `fine` (`FineID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `penaltypoints`
--

DROP TABLE IF EXISTS `penaltypoints`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `penaltypoints` (
  `PenaltyPointsID` int(11) NOT NULL AUTO_INCREMENT,
  `OffenceID` int(11) NOT NULL,
  `NumPoints` varchar(45) NOT NULL,
  `IssueDate` date DEFAULT NULL,
  `EffectiveDate` date DEFAULT NULL,
  `ExpiryDate` date DEFAULT NULL,
  PRIMARY KEY (`PenaltyPointsID`),
  UNIQUE KEY `PenaltyPointsID_UNIQUE` (`PenaltyPointsID`),
  KEY `fk_PenaltyPoints_Offence1_idx` (`OffenceID`),
  CONSTRAINT `fk_PenaltyPoints_Offence1` FOREIGN KEY (`OffenceID`) REFERENCES `offence` (`OffenceID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `penaltypoints`
--

LOCK TABLES `penaltypoints` WRITE;
/*!40000 ALTER TABLE `penaltypoints` DISABLE KEYS */;
/*!40000 ALTER TABLE `penaltypoints` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `regulation`
--

DROP TABLE IF EXISTS `regulation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `regulation` (
  `RegulationID` int(11) NOT NULL AUTO_INCREMENT,
  `AmendedID` int(11) DEFAULT NULL,
  `Description` text NOT NULL,
  `IssueDate` date NOT NULL,
  `EffectiveDate` date NOT NULL,
  `EndDate` date DEFAULT NULL,
  `PenaltyPointsOnPayment` varchar(8) DEFAULT NULL,
  `PnealtyPointsOnConviction` varchar(8) DEFAULT NULL,
  `AmountPaidFirstMonth` varchar(45) DEFAULT NULL,
  `AmountPaidOnConviction` varchar(45) DEFAULT NULL,
  `SectionActArticle` text NOT NULL,
  PRIMARY KEY (`RegulationID`),
  UNIQUE KEY `RegulationID_UNIQUE` (`RegulationID`),
  KEY `fk_Regulation_Regulation1_idx` (`AmendedID`),
  CONSTRAINT `fk_Regulation_Regulation1` FOREIGN KEY (`AmendedID`) REFERENCES `regulation` (`RegulationID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=164 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `regulation`
--

LOCK TABLES `regulation` WRITE;
/*!40000 ALTER TABLE `regulation` DISABLE KEYS */;
INSERT INTO `regulation` VALUES (101,NULL,'Using a vehicle with defective or worn tyres','2016-01-01','2016-04-17',NULL,'2','4','80','120','Section 2, Road Traffic Act 2005'),(102,NULL,'Learner permit holder driving unaccompanied by qualified person ','2016-01-01','2016-04-17',NULL,'2','4','80','120','Section 2, Road Traffic Act 2005'),(103,NULL,'Failure to display N Plate or tabard ','2016-01-01','2016-04-17',NULL,'2','4','60','90','Section 2, Road Traffic Act 2005'),(104,NULL,'Failure to display L-Plate or tabard','2016-01-01','2016-04-17',NULL,'2','4','60','90','Section 2, Road Traffic Act 2005'),(105,NULL,'Contravention of ban on U-turns ','2016-01-01','2016-04-17',NULL,'2 ','4','60','90','Section 2, Road Traffic Act 2005'),(106,NULL,'Contravention of rules for use of mini roundabouts','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(107,NULL,'Proceeding beyond no entry to vehicles sign','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(108,NULL,'Proceeding beyond a traffic lane control sign other than in accordance with such sign or without yielding','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(109,NULL,'Using vehicle in a public place without an authorisation plate ','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005'),(110,NULL,'Using vehicle in a public place that has been modified or altered such that authorisation plate is inaccurate','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005'),(111,NULL,'Using vehicle not equipped with a speed limitation device or using a vehicle equipped with a speed limitation device not complying with requirements specified in Regulation','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005'),(112,NULL,'Proceeding beyond maximum vehicle length sign where length exceeds maximum displayed','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(113,NULL,'Proceeding beyond maximum vehicle width sign where width exceeds maximum displayed','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(114,NULL,'Proceeding beyond maximum design gross vehicle weight (safety) sign where design gross vehicle weight exceeds maximum displayed','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(115,NULL,'Proceeding beyond maximum vehicle axle loading weight sign where vehicle axle loading weight exceeds maximum specified','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(116,NULL,'Using vehicle (car) without valid test certificate (NCT)','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005'),(117,NULL,'Parking a vehicle in a dangerous position','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005'),(118,NULL,'Failure to drive on the left hand side of the road ','2016-01-01','2016-04-17',NULL,'2','4','60','90','Section 2, Road Traffic Act 2005'),(119,NULL,'Dangerous overtaking','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005'),(120,NULL,'Contravention of prohibition of driving vehicle along or across median strip','2016-01-01','2016-04-17',NULL,'2','4','60','90','Section 2, Road Traffic Act 2005'),(121,NULL,'Failure to stop a vehicle before stop sign/stop line ','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005'),(122,NULL,'Failure to yield right of way at a yield sign/yield line','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005'),(123,NULL,'Failure to comply with mandatory traffic signs at junctions','2016-01-01','2016-04-17',NULL,'2','4','80','120','Section 2, Road Traffic Act 2005'),(124,NULL,'Crossing continuous white line','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005'),(125,NULL,'Failure by vehicle to obey traffic lights','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005'),(126,NULL,'Failure to leave appropriate distance between you and the vehicle in front','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005'),(127,NULL,'Driving vehicle before remedying dangerous defect','2016-01-01','2016-04-17',NULL,'m*','3','m*','m*','Section 2, Road Traffic Act 2005'),(128,NULL,'Driving dangerously defective vehicle','2016-01-01','2016-04-17',NULL,'m*','5','m*','m*','Section 2, Road Traffic Act 2005'),(129,NULL,'Using commercial vehicle without certificate of roadworthiness','2016-01-01','2016-04-17',NULL,'m*','5','m*','m*','Section 2, Road Traffic Act 2005'),(130,NULL,'Bridge strikes, etc.','2016-01-01','2016-04-17',NULL,'m*','3','m*','m*','Section 2, Road Traffic Act 2005'),(131,NULL,'Holding a mobile phone while driving','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005'),(132,NULL,'Failure to act in accordance with a Garda signal','2016-01-01','2016-04-17',NULL,'1','3','80','120','Section 2, Road Traffic Act 2005'),(133,NULL,'Entry by driver into hatched marked area of roadway, e.g. Carriageway reduction lane ','2016-01-01','2016-04-17',NULL,'1','3','80','120','Section 2, Road Traffic Act 2005'),(134,NULL,'Failure to obey traffic rules at railway level crossing','2016-01-01','2016-04-17',NULL,'2','5','80','120','Section 2, Road Traffic Act 2005'),(135,NULL,'Driving a vehicle on a motorway against the flow of traffic','2016-01-01','2016-04-17',NULL,'2','4','80','120','Section 2, Road Traffic Act 2005'),(136,NULL,'Driving on the hard shoulder on a motorway','2016-01-01','2016-04-17',NULL,'1','3','80','120','Section 2, Road Traffic Act 2005'),(137,NULL,'Driving a vehicle (subject to an ordinary speed limit of 90 kms per hour or less on the outside lane on a motorway or dual carriageway','2016-01-01','2016-04-17',NULL,'1','3','80','120','Section 2, Road Traffic Act 2005'),(138,NULL,'Failure to obey requirements at junctions, e.g. Not being in the correct lane when turning onto another road','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(139,NULL,'Failure to obey requirements regarding reversing of vehicles, e.g. Reversing from minor road onto main road','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(140,NULL,'Driving on a footpath','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(141,NULL,'Driving on a cycle track','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(142,NULL,'Failure to turn left when entering a roundabout','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(143,NULL,'Failure to stop for school warden sign','2016-01-01','2016-04-17',NULL,'2','5','80','120','Section 2, Road Traffic Act 2005'),(144,NULL,'Failure to stop when so required by a member of the Garda Síochána','2016-01-01','2016-04-17',NULL,'2','5','80','120','Section 2, Road Traffic Act 2005'),(145,NULL,'Failure to yield','2016-01-01','2016-04-17',NULL,'2','4','80','120','Section 2, Road Traffic Act 2005'),(146,NULL,'Driving without reasonable consideration','2016-01-01','2016-04-17',NULL,'2','4','80','120','Section 2, Road Traffic Act 2005'),(147,NULL,'Failure to comply with prohibitory traffic signs','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(148,NULL,'Failure to comply with keep left/keep right signs','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(149,NULL,'Failure to comply with traffic lane markings','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(150,NULL,'Illegal entry onto a one-way street','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005'),(151,NULL,'Driving a vehicle when unfit','2016-01-01','2016-04-17',NULL,'m*','3','m*','m*','Section 2, Road Traffic Act 2005'),(152,NULL,'Breach of duties at an accident','2016-01-01','2016-04-17',NULL,'m*','5','80','120','Section 2, Road Traffic Act 2005'),(153,NULL,'Speeding','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005'),(154,NULL,'Driving without insurance','2016-01-01','2016-04-17',NULL,'m*','5','m*','m*','Section 2, Road Traffic Act 2005'),(155,NULL,'Driver of Car or Goods vehicle not wearing Safety belt','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005'),(156,NULL,'Failure by Driver to comply with rear seat belt requirements for passengers under 17 years','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005'),(157,NULL,'Driver of car or goods vehicle permitting child under 3 years of age to travel in it without being restrained by appropriate child restraint','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005'),(158,NULL,'Driver of car or goods vehicle permitting child over 3 years of age to travel in it without being restrained by appropriate child restraint','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005'),(159,NULL,'Driver of car or goods vehicle permitting child to be restrained by rearward facing child restraint fitted to a seat protected by active frontal air-bag','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005'),(160,NULL,'Driver of bus not wearing safety belt','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005'),(161,NULL,'Driver found to be driving carelessly','2016-01-01','2016-04-17',NULL,'m*','5','m*','m*','Section 2, Road Traffic Act 2005'),(162,NULL,'Using vehicle – (a) whose weight un-laden exceeds maximum permitted weight, (b) whose weight laden exceeds maximum permitted weight, or (c) any part of which transmits to ground greater weight than maximum permitted weight','2016-01-01','2016-04-17',NULL,'1  ','3','200','300','Section 2, Road Traffic Act 2005'),(163,NULL,'Drink driving offences (In all cases where the BAC is between 50mg and 80mg)','2016-01-01','2016-04-17',NULL,'3','na','200','na','Section 2, Road Traffic Act 2005');
/*!40000 ALTER TABLE `regulation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `UserName` varchar(100) NOT NULL,
  `OrganizationID` varchar(3) NOT NULL,
  `Position` varchar(45) NOT NULL,
  `Email` text,
  `DateAdded` date NOT NULL,
  `DateRevoked` date DEFAULT NULL,
  `DateLastAccessed` datetime DEFAULT NULL,
  PRIMARY KEY (`UserName`),
  UNIQUE KEY `UserID_UNIQUE` (`UserName`),
  KEY `fk_user_organization1_idx` (`OrganizationID`),
  CONSTRAINT `fk_user_organization1` FOREIGN KEY (`OrganizationID`) REFERENCES `organization` (`OrganizationID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('100','PPB','Supervisor','test@ppb.ie','1966-05-06',NULL,NULL),('101','PPB','Staff','test@ppb.ie','2013-11-20',NULL,NULL),('102','PPB','Staff','test@ppb.ie','2013-11-13',NULL,NULL),('103','PPB','Staff','test@ppb.ie','2016-03-04',NULL,NULL),('104','PPB','Staff','test@ppb.ie','2016-06-13',NULL,NULL),('105','PPB','Staff','test@ppb.ie','2012-01-06',NULL,NULL),('106','PPB','Staff','test@ppb.ie','2012-09-21',NULL,NULL),('107','PPB','Staff','test@ppb.ie','2017-01-07',NULL,NULL),('108','PPB','Staff','test@ppb.ie','2016-05-25',NULL,NULL),('109','PPB','Staff','test@ppb.ie','2011-02-23',NULL,NULL),('110','PPB','Staff','test@ppb.ie','2014-05-26',NULL,NULL),('111','PPB','Staff','test@ppb.ie','2009-11-13',NULL,NULL),('112','PPB','Staff','test@ppb.ie','2012-10-22',NULL,NULL),('113','PPB','Staff','test@ppb.ie','2016-10-06',NULL,NULL),('114','PPB','Staff','test@ppb.ie','2013-10-14',NULL,NULL),('115','PPB','Supervisor','test@ppb.ie','2011-03-23',NULL,NULL),('116','PPB','Staff','test@ppb.ie','2012-09-26',NULL,NULL),('117','PPB','Staff','test@ppb.ie','2013-02-20',NULL,NULL),('118','PPB','Staff','test@ppb.ie','2010-05-22',NULL,NULL),('119','PPB','Staff','test@ppb.ie','2010-10-19',NULL,NULL),('120','PPB','Staff','test@ppb.ie','2014-05-15',NULL,NULL),('121','PPB','Staff','test@ppb.ie','2013-01-11',NULL,NULL),('122','PPB','Staff','test@ppb.ie','2010-04-27',NULL,NULL),('123','PPB','Staff','test@ppb.ie','2014-08-08',NULL,NULL),('124','PPB','Staff','test@ppb.ie','2014-12-30',NULL,NULL),('125','PPB','Staff','test@ppb.ie','2011-10-26',NULL,NULL),('126','PPB','Staff','test@ppb.ie','2009-11-11',NULL,NULL),('127','PPB','Staff','test@ppb.ie','2014-10-14',NULL,NULL),('128','PPB','Supervisor','test@ppb.ie','2017-05-02',NULL,NULL),('129','PPB','Staff','test@ppb.ie','2011-09-28',NULL,NULL),('130','PPB','Staff','test@ppb.ie','2013-04-27',NULL,NULL),('131','PPB','Staff','test@ppb.ie','2015-12-05',NULL,NULL),('132','PPB','Supervisor','test@ppb.ie','2009-11-15',NULL,NULL),('133','PPB','Supervisor','test@ppb.ie','2013-07-04',NULL,NULL),('134','PPB','Staff','test@ppb.ie','2012-05-21',NULL,NULL),('135','PPB','Staff','test@ppb.ie','2010-01-16',NULL,NULL),('136','PPB','Supervisor','test@ppb.ie','2014-10-22',NULL,NULL),('137','PPB','Supervisor','test@ppb.ie','2010-11-28',NULL,NULL),('138','PPB','Staff','test@ppb.ie','2015-07-03',NULL,NULL),('139','PPB','Staff','test@ppb.ie','2017-05-13',NULL,NULL),('140','PPB','Staff','test@ppb.ie','2017-10-14',NULL,NULL),('141','PPB','Staff','test@ppb.ie','2013-03-15',NULL,NULL),('142','PPB','Staff','test@ppb.ie','2010-06-11',NULL,NULL),('143','PPB','Staff','test@ppb.ie','2017-07-12',NULL,NULL),('144','PPB','Staff','test@ppb.ie','2012-07-06',NULL,NULL),('145','PPB','Admin','test@ppb.ie','2012-05-26',NULL,NULL),('146','PPB','Staff','test@ppb.ie','2013-11-21',NULL,NULL),('147','PPB','Staff','test@ppb.ie','2015-08-19',NULL,NULL),('148','PPB','Staff','test@ppb.ie','2011-07-09',NULL,NULL),('149','PPB','Staff','test@ppb.ie','2010-05-22',NULL,NULL),('150','PPB','Staff','test@ppb.ie','2012-03-12',NULL,NULL),('151','PPB','Staff','test@ppb.ie','2010-02-05',NULL,NULL),('152','PPB','Staff','test@ppb.ie','2011-02-08',NULL,NULL),('153','PPB','Staff','test@ppb.ie','2011-08-05',NULL,NULL),('154','PPB','Staff','test@ppb.ie','2012-08-30',NULL,NULL),('155','PPB','Staff','test@ppb.ie','2011-12-05',NULL,NULL),('156','PPB','Staff','test@ppb.ie','2014-05-10',NULL,NULL),('157','PPB','Staff','test@ppb.ie','2016-12-05',NULL,NULL),('158','PPB','Staff','test@ppb.ie','2015-03-07',NULL,NULL),('159','PPB','Staff','test@ppb.ie','2017-01-16',NULL,NULL),('160','PPB','Staff','test@ppb.ie','2017-06-04',NULL,NULL),('161','PPB','Supervisor','test@ppb.ie','2011-12-23',NULL,NULL),('162','PPB','Staff','test@ppb.ie','2014-02-06',NULL,NULL),('163','PPB','Staff','test@ppb.ie','2015-03-31',NULL,NULL),('164','PPB','Staff','test@ppb.ie','2013-07-18',NULL,NULL),('165','PPB','Staff','test@ppb.ie','2015-11-11',NULL,NULL),('166','PPB','Staff','test@ppb.ie','2010-02-15',NULL,NULL),('167','PPB','Staff','test@ppb.ie','2015-11-09',NULL,NULL),('168','PPB','Staff','test@ppb.ie','2015-05-03',NULL,NULL),('169','PPB','Supervisor','test@ppb.ie','2016-12-15',NULL,NULL),('170','PPB','Staff','test@ppb.ie','2010-07-27',NULL,NULL),('171','PPB','Staff','test@ppb.ie','2014-04-02',NULL,NULL),('172','PPB','Staff','test@ppb.ie','2015-07-09',NULL,NULL),('173','PPB','Staff','test@ppb.ie','2016-07-05',NULL,NULL),('174','PPB','Staff','test@ppb.ie','2011-11-28',NULL,NULL),('175','PPB','Staff','test@ppb.ie','2014-09-29',NULL,NULL),('176','PPB','Staff','test@ppb.ie','2014-02-19',NULL,NULL),('177','PPB','Staff','test@ppb.ie','2011-08-20',NULL,NULL),('178','PPB','Supervisor','test@ppb.ie','2011-08-18',NULL,NULL),('179','PPB','Staff','test@ppb.ie','2015-11-28',NULL,NULL),('180','PPB','Staff','test@ppb.ie','2013-06-07',NULL,NULL),('181','PPB','Staff','test@ppb.ie','2013-01-04',NULL,NULL),('182','PPB','Staff','test@ppb.ie','2010-12-03',NULL,NULL),('183','PPB','Staff','test@ppb.ie','2017-01-19',NULL,NULL),('184','PPB','Staff','test@ppb.ie','2015-01-12',NULL,NULL),('185','PPB','Staff','test@ppb.ie','2016-10-10',NULL,NULL),('186','PPB','Staff','test@ppb.ie','2012-05-15',NULL,NULL),('187','PPB','Staff','test@ppb.ie','2010-05-03',NULL,NULL),('188','PPB','Staff','test@ppb.ie','2017-10-01',NULL,NULL),('189','PPB','Staff','test@ppb.ie','2015-10-12',NULL,NULL),('190','PPB','Staff','test@ppb.ie','2012-06-14',NULL,NULL),('191','PPB','Staff','test@ppb.ie','2014-01-10',NULL,NULL),('192','PPB','Staff','test@ppb.ie','2014-06-19',NULL,NULL),('193','PPB','Supervisor','test@ppb.ie','2012-11-24',NULL,NULL),('194','PPB','Supervisor','test@ppb.ie','2014-02-18',NULL,NULL),('195','PPB','Staff','test@ppb.ie','2011-05-12',NULL,NULL),('196','PPB','Staff','test@ppb.ie','2015-06-04',NULL,NULL),('197','PPB','Staff','test@ppb.ie','2012-09-02',NULL,NULL),('198','PPB','Supervisor','test@ppb.ie','2010-10-26',NULL,NULL),('199','PPB','Staff','test@ppb.ie','2013-02-14',NULL,NULL),('200','PPB','Staff','test@ppb.ie','2011-11-21',NULL,NULL),('201','PPB','Staff','test@ppb.ie','2014-04-21',NULL,NULL),('202','PPB','Staff','test@ppb.ie','2014-07-07',NULL,NULL),('203','PPB','Staff','test@ppb.ie','2014-11-30',NULL,NULL),('204','PPB','Staff','test@ppb.ie','2011-02-14',NULL,NULL),('205','PPB','Supervisor','test@ppb.ie','2011-09-15',NULL,NULL),('206','PPB','Staff','test@ppb.ie','2014-07-31',NULL,NULL),('207','PPB','Staff','test@ppb.ie','2014-05-20',NULL,NULL),('208','PPB','Staff','test@ppb.ie','2010-01-13',NULL,NULL),('209','PPB','Staff','test@ppb.ie','2012-09-13',NULL,NULL),('210','PPB','Staff','test@ppb.ie','2016-02-17',NULL,NULL),('211','PPB','Staff','test@ppb.ie','2012-03-24',NULL,NULL),('212','PPB','Staff','test@ppb.ie','2010-06-20',NULL,NULL),('213','PPB','Supervisor','test@ppb.ie','2014-05-21',NULL,NULL),('214','PPB','Staff','test@ppb.ie','2016-06-24',NULL,NULL),('215','PPB','Staff','test@ppb.ie','2015-06-14',NULL,NULL),('216','PPB','Staff','test@ppb.ie','2011-05-10',NULL,NULL),('217','PPB','Staff','test@ppb.ie','2012-08-19',NULL,NULL),('218','PPB','Staff','test@ppb.ie','2015-06-21',NULL,NULL),('219','PPB','Supervisor','test@ppb.ie','2011-01-31',NULL,NULL),('220','MLA','Staff','test@mla.ie','2011-02-08',NULL,NULL),('221','MLA','Supervisor','test@mla.ie','2012-04-01',NULL,NULL),('222','MLA','Staff','test@mla.ie','2016-08-13',NULL,NULL),('223','MLA','Staff','test@mla.ie','2016-03-02',NULL,NULL),('224','MLA','Staff','test@mla.ie','2012-11-16',NULL,NULL),('225','MLA','Staff','test@mla.ie','2016-03-18',NULL,NULL),('226','MLA','Staff','test@mla.ie','2014-03-15',NULL,NULL),('227','MLA','Staff','test@mla.ie','2013-03-01',NULL,NULL),('228','MLA','Staff','test@mla.ie','2014-07-20',NULL,NULL),('229','MLA','Staff','test@mla.ie','2015-02-02',NULL,NULL),('230','MLA','Staff','test@mla.ie','2014-09-01',NULL,NULL),('231','MLA','Supervisor','test@mla.ie','2010-08-04',NULL,NULL),('232','MLA','Staff','test@mla.ie','2016-08-09',NULL,NULL),('233','MLA','Staff','test@mla.ie','2016-06-03',NULL,NULL),('234','MLA','Supervisor','test@mla.ie','2014-06-06',NULL,NULL),('235','MLA','Staff','test@mla.ie','2014-12-12',NULL,NULL),('236','MLA','Staff','test@mla.ie','2013-01-04',NULL,NULL),('237','MLA','Staff','test@mla.ie','2010-04-18',NULL,NULL),('238','MLA','Supervisor','test@mla.ie','2015-04-11',NULL,NULL),('239','MLA','Supervisor','test@mla.ie','2015-03-18',NULL,NULL),('240','MLA','Staff','test@mla.ie','2017-01-17',NULL,NULL),('241','MLA','Staff','test@mla.ie','2016-12-27',NULL,NULL),('242','MLA','Staff','test@mla.ie','2016-07-15',NULL,NULL),('243','MLA','Staff','test@mla.ie','2015-12-23',NULL,NULL),('244','MLA','Staff','test@mla.ie','2016-03-27',NULL,NULL),('245','MLA','Staff','test@mla.ie','2016-02-14',NULL,NULL),('246','MLA','Supervisor','test@mla.ie','2010-04-27',NULL,NULL),('247','MLA','Supervisor','test@mla.ie','2013-02-05',NULL,NULL),('248','MLA','Staff','test@mla.ie','2010-02-07',NULL,NULL),('249','MLA','Staff','test@mla.ie','2010-10-02',NULL,NULL),('250','MLA','Staff','test@mla.ie','2016-06-13',NULL,NULL),('251','MLA','Staff','test@mla.ie','2014-05-04',NULL,NULL),('252','MLA','Staff','test@mla.ie','2012-11-08',NULL,NULL),('253','MLA','Supervisor','test@mla.ie','2017-06-26',NULL,NULL),('254','MLA','Staff','test@mla.ie','2016-07-07',NULL,NULL),('255','MLA','Staff','test@mla.ie','2014-12-06',NULL,NULL),('256','MLA','Staff','test@mla.ie','2014-03-28',NULL,NULL),('257','MLA','Supervisor','test@mla.ie','2013-09-30',NULL,NULL),('258','MLA','Staff','test@mla.ie','2017-07-21',NULL,NULL),('259','MLA','Staff','test@mla.ie','2012-09-28',NULL,NULL),('260','MLA','Staff','test@mla.ie','2011-09-09',NULL,NULL),('261','MLA','Staff','test@mla.ie','2017-01-03',NULL,NULL),('262','MLA','Staff','test@mla.ie','2016-03-08',NULL,NULL),('263','MLA','Supervisor','test@mla.ie','2012-11-03',NULL,NULL),('264','MLA','Staff','test@mla.ie','2013-04-09',NULL,NULL),('265','MLA','Staff','test@mla.ie','2013-05-07',NULL,NULL),('266','MLA','Staff','test@mla.ie','2013-10-22',NULL,NULL),('267','MLA','Supervisor','test@mla.ie','2011-11-06',NULL,NULL),('268','MLA','Staff','test@mla.ie','2016-04-15',NULL,NULL),('269','MLA','Staff','test@mla.ie','2013-01-25',NULL,NULL),('270','MLA','Staff','test@mla.ie','2014-12-15',NULL,NULL),('271','MLA','Staff','test@mla.ie','2017-10-15',NULL,NULL),('272','MLA','Staff','test@mla.ie','2013-01-23',NULL,NULL),('273','MLA','Staff','test@mla.ie','2011-08-29',NULL,NULL),('274','MLA','Staff','test@mla.ie','2015-01-21',NULL,NULL),('275','MLA','Staff','test@mla.ie','2011-07-22',NULL,NULL),('276','MLA','Staff','test@mla.ie','2015-02-22',NULL,NULL),('277','MLA','Staff','test@mla.ie','2012-03-23',NULL,NULL),('278','MLA','Staff','test@mla.ie','2014-10-12',NULL,NULL),('279','MLA','Staff','test@mla.ie','2010-07-07',NULL,NULL),('280','MLA','Staff','test@mla.ie','2013-12-17',NULL,NULL),('281','MLA','Staff','test@mla.ie','2014-08-31',NULL,NULL),('282','MLA','Staff','test@mla.ie','2013-09-02',NULL,NULL),('283','MLA','Staff','test@mla.ie','2012-10-29',NULL,NULL),('284','MLA','Staff','test@mla.ie','2012-11-24',NULL,NULL),('285','MLA','Staff','test@mla.ie','2012-07-09',NULL,NULL),('286','MLA','Staff','test@mla.ie','2016-10-12',NULL,NULL),('287','MLA','Staff','test@mla.ie','2010-06-30',NULL,NULL),('288','MLA','Staff','test@mla.ie','2010-10-22',NULL,NULL),('289','MLA','Staff','test@mla.ie','2013-10-07',NULL,NULL),('290','MLA','Staff','test@mla.ie','2012-11-05',NULL,NULL),('291','MLA','Staff','test@mla.ie','2014-03-16',NULL,NULL),('292','MLA','Supervisor','test@mla.ie','2016-06-27',NULL,NULL),('293','MLA','Supervisor','test@mla.ie','2015-10-16',NULL,NULL),('294','MLA','Staff','test@mla.ie','2016-07-19',NULL,NULL),('295','MLA','Staff','test@mla.ie','2011-09-20',NULL,NULL),('296','MLA','Staff','test@mla.ie','2010-04-24',NULL,NULL),('297','MLA','Staff','test@mla.ie','2013-08-23',NULL,NULL),('298','MLA','Staff','test@mla.ie','2011-07-08',NULL,NULL),('299','MLA','Staff','test@mla.ie','2012-09-10',NULL,NULL),('300','MLA','Admin','test@mla.ie','2013-05-18',NULL,NULL),('301','MLA','Staff','test@mla.ie','2016-04-18',NULL,NULL),('302','MLA','Staff','test@mla.ie','2010-12-10',NULL,NULL),('303','MLA','Supervisor','test@mla.ie','2016-05-15',NULL,NULL),('304','MLA','Staff','test@mla.ie','2017-05-10',NULL,NULL),('305','MLA','Admin','test@mla.ie','2017-09-18',NULL,NULL),('306','MLA','Staff','test@mla.ie','2013-06-17',NULL,NULL),('307','MLA','Staff','test@mla.ie','2014-08-14',NULL,NULL),('308','MLA','Staff','test@mla.ie','2014-04-19',NULL,NULL),('309','MLA','Staff','test@mla.ie','2014-04-26',NULL,NULL),('310','MLA','Staff','test@mla.ie','2013-04-09',NULL,NULL),('311','MLA','Staff','test@mla.ie','2013-04-03',NULL,NULL),('312','MLA','Staff','test@mla.ie','2012-03-28',NULL,NULL),('313','MLA','Admin','test@mla.ie','2014-11-29',NULL,NULL),('314','MLA','Staff','test@mla.ie','2010-11-08',NULL,NULL),('315','MLA','Staff','test@mla.ie','2011-01-13',NULL,NULL),('316','MLA','Staff','test@mla.ie','2011-10-22',NULL,NULL),('317','MLA','Supervisor','test@mla.ie','2010-06-15',NULL,NULL),('318','MLA','Admin','test@mla.ie','2012-04-23',NULL,NULL),('319','MLA','Staff','test@mla.ie','2012-01-29',NULL,NULL),('320','MLA','Staff','test@mla.ie','2017-08-24',NULL,NULL),('321','MLA','Staff','test@mla.ie','2015-08-25',NULL,NULL),('322','MLA','Staff','test@mla.ie','2013-10-04',NULL,NULL),('323','MLA','Staff','test@mla.ie','2009-12-23',NULL,NULL),('324','MLA','Staff','test@mla.ie','2013-03-25',NULL,NULL),('325','MLA','Staff','test@mla.ie','2011-12-24',NULL,NULL),('326','MLA','Staff','test@mla.ie','2013-06-27',NULL,NULL),('327','MLA','Staff','test@mla.ie','2015-02-17',NULL,NULL),('328','MLA','Staff','test@mla.ie','2010-02-06',NULL,NULL),('329','MLA','Staff','test@mla.ie','2013-04-08',NULL,NULL),('330','MLA','Staff','test@mla.ie','2010-04-28',NULL,NULL),('331','MLA','Staff','test@mla.ie','2011-02-22',NULL,NULL),('332','MLA','Staff','test@mla.ie','2013-09-02',NULL,NULL),('333','MLA','Staff','test@mla.ie','2017-01-10',NULL,NULL),('334','MLA','Staff','test@mla.ie','2012-05-05',NULL,NULL),('335','MLA','Staff','test@mla.ie','2015-10-03',NULL,NULL),('336','MLA','Staff','test@mla.ie','2014-10-28',NULL,NULL),('337','MLA','Supervisor','test@mla.ie','2016-07-15',NULL,NULL),('338','MLA','Staff','test@mla.ie','2017-06-05',NULL,NULL),('339','MLA','Staff','test@mla.ie','2016-02-25',NULL,NULL),('340','GS','Garda','test@gs.ie','2017-10-06',NULL,NULL),('341','GS','Garda','test@gs.ie','2011-08-11',NULL,NULL),('342','GS','Garda','test@gs.ie','2012-02-23',NULL,NULL),('343','GS','Garda','test@gs.ie','2016-01-24',NULL,NULL),('344','GS','Sergent','test@gs.ie','2011-11-27',NULL,NULL),('345','GS','Garda','test@gs.ie','2016-02-21',NULL,NULL),('346','GS','Garda','test@gs.ie','2011-07-10',NULL,NULL),('347','GS','SpeedCamera','test@gs.ie','2014-01-21',NULL,NULL),('348','GS','Garda','test@gs.ie','2013-01-31',NULL,NULL),('349','GS','Garda','test@gs.ie','2017-10-19',NULL,NULL),('350','GS','Garda','test@gs.ie','2013-07-02',NULL,NULL),('351','GS','Garda','test@gs.ie','2012-12-16',NULL,NULL),('352','GS','Garda','test@gs.ie','2014-03-23',NULL,NULL),('353','GS','Garda','test@gs.ie','2012-01-26',NULL,NULL),('354','GS','Garda','test@gs.ie','2013-11-11',NULL,NULL),('355','GS','Garda','test@gs.ie','2012-05-29',NULL,NULL),('356','GS','Garda','test@gs.ie','2011-07-11',NULL,NULL),('357','GS','Garda','test@gs.ie','2010-02-03',NULL,NULL),('358','GS','SpeedCamera','test@gs.ie','2014-01-01',NULL,NULL),('359','GS','Garda','test@gs.ie','2015-12-16',NULL,NULL),('360','GS','Garda','test@gs.ie','2010-10-05',NULL,NULL),('361','GS','Garda','test@gs.ie','2010-03-29',NULL,NULL),('362','GS','Garda','test@gs.ie','2012-05-26',NULL,NULL),('363','GS','Garda','test@gs.ie','2013-06-14',NULL,NULL),('364','GS','Garda','test@gs.ie','2010-02-09',NULL,NULL),('365','GS','Garda','test@gs.ie','2012-09-18',NULL,NULL),('366','GS','Garda','test@gs.ie','2009-11-24',NULL,NULL),('367','GS','Garda','test@gs.ie','2010-11-24',NULL,NULL),('368','GS','Garda','test@gs.ie','2010-05-20',NULL,NULL),('369','GS','SpeedCamera','test@gs.ie','2012-04-20',NULL,NULL),('370','GS','Garda','test@gs.ie','2016-05-23',NULL,NULL),('371','GS','Garda','test@gs.ie','2015-05-15',NULL,NULL),('372','GS','Garda','test@gs.ie','2010-04-01',NULL,NULL),('373','GS','Garda','test@gs.ie','2013-10-13',NULL,NULL),('374','GS','SpeedCamera','test@gs.ie','2017-09-29',NULL,NULL),('375','GS','Garda','test@gs.ie','2016-02-15',NULL,NULL),('376','GS','SpeedCamera','test@gs.ie','2010-06-11',NULL,NULL),('377','GS','SpeedCamera','test@gs.ie','2017-08-11',NULL,NULL),('378','GS','Garda','test@gs.ie','2015-03-08',NULL,NULL),('379','GS','SpeedCamera','test@gs.ie','2010-06-02',NULL,NULL),('380','GS','Garda','test@gs.ie','2010-12-15',NULL,NULL),('381','GS','Garda','test@gs.ie','2010-12-07',NULL,NULL),('382','GS','Garda','test@gs.ie','2016-10-25',NULL,NULL),('383','GS','SpeedCamera','test@gs.ie','2012-04-09',NULL,NULL),('384','GS','Garda','test@gs.ie','2015-08-29',NULL,NULL),('385','GS','Garda','test@gs.ie','2017-06-02',NULL,NULL),('386','GS','Garda','test@gs.ie','2011-09-27',NULL,NULL),('387','GS','Garda','test@gs.ie','2014-02-20',NULL,NULL),('388','GS','Sergent','test@gs.ie','2014-12-03',NULL,NULL),('389','GS','Garda','test@gs.ie','2014-09-29',NULL,NULL),('390','GS','Garda','test@gs.ie','2013-01-16',NULL,NULL),('391','GS','Garda','test@gs.ie','2012-11-01',NULL,NULL),('392','GS','Garda','test@gs.ie','2013-01-26',NULL,NULL),('393','GS','SpeedCamera','test@gs.ie','2015-02-17',NULL,NULL),('394','GS','Garda','test@gs.ie','2009-12-12',NULL,NULL),('395','GS','Garda','test@gs.ie','2014-08-25',NULL,NULL),('396','GS','Garda','test@gs.ie','2010-09-20',NULL,NULL),('397','GS','Garda','test@gs.ie','2010-05-17',NULL,NULL),('398','GS','Garda','test@gs.ie','2013-11-23',NULL,NULL),('399','GS','Garda','test@gs.ie','2017-05-04',NULL,NULL),('400','GS','Garda','test@gs.ie','2013-06-30',NULL,NULL),('401','GS','Sergent','test@gs.ie','2017-03-17',NULL,NULL),('402','GS','Garda','test@gs.ie','2016-08-15',NULL,NULL),('403','GS','Garda','test@gs.ie','2011-09-29',NULL,NULL),('404','GS','Garda','test@gs.ie','2010-04-19',NULL,NULL),('405','GS','Garda','test@gs.ie','2011-12-08',NULL,NULL),('406','GS','Sergent','test@gs.ie','2016-07-26',NULL,NULL),('407','GS','Garda','test@gs.ie','2016-03-02',NULL,NULL),('408','GS','Garda','test@gs.ie','2016-07-31',NULL,NULL),('409','GS','Garda','test@gs.ie','2015-03-19',NULL,NULL),('410','GS','Garda','test@gs.ie','2016-07-04',NULL,NULL),('411','GS','Garda','test@gs.ie','2013-05-28',NULL,NULL),('412','GS','Garda','test@gs.ie','2016-03-23',NULL,NULL),('413','GS','Garda','test@gs.ie','2013-05-27',NULL,NULL),('414','GS','Sergent','test@gs.ie','2014-11-30',NULL,NULL),('415','GS','SpeedCamera','test@gs.ie','2015-06-20',NULL,NULL),('416','GS','Garda','test@gs.ie','2009-12-19',NULL,NULL),('417','GS','Garda','test@gs.ie','2011-11-21',NULL,NULL),('418','GS','Garda','test@gs.ie','2011-02-19',NULL,NULL),('419','GS','Sergent','test@gs.ie','2014-07-11',NULL,NULL),('420','GS','Garda','test@gs.ie','2016-06-11',NULL,NULL),('421','GS','Garda','test@gs.ie','2016-05-13',NULL,NULL),('422','GS','Garda','test@gs.ie','2017-06-19',NULL,NULL),('423','GS','Sergent','test@gs.ie','2013-10-05',NULL,NULL),('424','GS','Garda','test@gs.ie','2010-05-30',NULL,NULL),('425','GS','Garda','test@gs.ie','2010-03-21',NULL,NULL),('426','GS','Garda','test@gs.ie','2012-09-28',NULL,NULL),('427','GS','Garda','test@gs.ie','2013-04-01',NULL,NULL),('428','GS','SpeedCamera','test@gs.ie','2010-07-05',NULL,NULL),('429','GS','Garda','test@gs.ie','2014-04-24',NULL,NULL),('430','GS','Garda','test@gs.ie','2014-09-01',NULL,NULL),('431','GS','Garda','test@gs.ie','2013-05-16',NULL,NULL),('432','GS','Garda','test@gs.ie','2016-04-14',NULL,NULL),('433','GS','Garda','test@gs.ie','2016-05-09',NULL,NULL),('434','GS','SpeedCamera','test@gs.ie','2015-02-16',NULL,NULL),('435','GS','SpeedCamera','test@gs.ie','2016-11-07',NULL,NULL),('436','GS','Garda','test@gs.ie','2017-01-12',NULL,NULL),('437','GS','Garda','test@gs.ie','2015-10-06',NULL,NULL),('438','GS','Garda','test@gs.ie','2010-08-23',NULL,NULL),('439','GS','Garda','test@gs.ie','2011-11-19',NULL,NULL),('440','GS','Garda','test@gs.ie','2015-01-20',NULL,NULL),('441','GS','Garda','test@gs.ie','2012-12-30',NULL,NULL),('442','GS','Garda','test@gs.ie','2010-10-19',NULL,NULL),('443','GS','Sergent','test@gs.ie','2014-03-04',NULL,NULL),('444','GS','SpeedCamera','test@gs.ie','2017-10-13',NULL,NULL),('445','GS','SpeedCamera','test@gs.ie','2011-03-03',NULL,NULL),('446','GS','SpeedCamera','test@gs.ie','2016-11-06',NULL,NULL),('447','GS','Garda','test@gs.ie','2011-06-27',NULL,NULL),('448','GS','Garda','test@gs.ie','2016-03-01',NULL,NULL),('449','GS','Garda','test@gs.ie','2013-10-31',NULL,NULL),('450','GS','Garda','test@gs.ie','2010-07-18',NULL,NULL),('451','GS','Garda','test@gs.ie','2015-03-07',NULL,NULL),('452','GS','Garda','test@gs.ie','2011-04-12',NULL,NULL),('453','GS','Garda','test@gs.ie','2015-07-18',NULL,NULL),('454','GS','Garda','test@gs.ie','2010-06-01',NULL,NULL),('455','GS','Garda','test@gs.ie','2010-07-23',NULL,NULL),('456','GS','Garda','test@gs.ie','2012-02-17',NULL,NULL),('457','GS','Garda','test@gs.ie','2012-03-02',NULL,NULL),('458','GS','SpeedCamera','test@gs.ie','2015-10-11',NULL,NULL),('459','GS','Garda','test@gs.ie','2013-02-14',NULL,NULL),('Ben','PPB','Supervisor','ben@ppb.ie','2013-02-14',NULL,NULL),('Colin','PPB','Supervisor','colin@ppb.ie','2013-02-14',NULL,NULL),('Ian','PPB','Supervisor','ian@ppb.ie','2013-02-14',NULL,NULL),('Mike','PPB','Supervisor','mike@ppb.ie','2013-02-14',NULL,NULL),('Steve','PPB','Supervisor','steve@ppb.ie','2013-02-14',NULL,NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'dbppb'
--

--
-- Dumping routines for database 'dbppb'
--
/*!50003 DROP PROCEDURE IF EXISTS `ProcLogin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ProcLogin`(IN UserName VARCHAR(100), IN Cipher VARCHAR(64))
BEGIN
	SELECT *
    FROM   `Login`
    WHERE (`Login`.`UserName` = UserName
    AND    `Login`.`Cipher` = Cipher);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-11-25 11:18:25
