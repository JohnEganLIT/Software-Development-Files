CREATE DATABASE  IF NOT EXISTS `dbppb` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `dbppb`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: dbppb
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.13-MariaDB

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
INSERT INTO `identity` VALUES ('100','Gavin','O Dwyer','Marian Pk','Clara','Offaly','1982-01-11','(062) 12345 Ext. 0',NULL),('10089327498','fsdjkfsd','lkjlk','kljlkj','kljlk','jkljl','0000-00-00','0838747','kjfsdh.jpg'),('101','Philip','Gray','38 Healy St','Cork','Cork','1977-10-14','(062) 12345 Ext. 1',NULL),('102','Caitlin','Healy','27 Hillview Ard Mhuire Pk','Galway','Galway','1992-05-29','(062) 12345 Ext. 2',NULL),('103','Dan','James','13 Main Street','Kilkenny Borough','Kilkenny','1997-01-08','(062) 12345 Ext. 3',NULL),('104','Keith','Tucker','Laragh','Ballina','Tipperary','1965-11-15','(062) 12345 Ext. 4',NULL),('105','Mick','Taylor','Forramoyle','Graiguenamanagh','Carlow','1982-03-26','(062) 12345 Ext. 5',NULL),('106','Richard','Campbell','48 Castle Riada Gro','Kilkenny Borough','Kilkenny','1976-07-11','(062) 12345 Ext. 6',NULL),('107','Colin','McLean','Blackacre','Askeaton','Limerick','1977-07-19','(062) 12345 Ext. 7',NULL),('108','Rosie','Marshall','10 The Mews','Kilkenny Borough','Kilkenny','1999-12-29','(062) 12345 Ext. 8',NULL),('109','Madison','Davies','36 Rosmeen Pk','Cork','Cork','1963-11-29','(062) 12345 Ext. 9',NULL),('110','Nathan','Moran','Castleboy','Cahir','Tipperary','1983-04-08','(062) 12345 Ext. 0',NULL),('111','Laura','MacLeod','46 Monksfield Ave','Clonmel Borough','Tipperary','1982-11-07','(062) 12345 Ext. 1',NULL),('112','Madison','McGrath','Canrower','Graiguenamanagh','Carlow','1995-12-14','(062) 12345 Ext. 2',NULL),('113','Ryan','Gray','26 Sunnyside','Carrigaline','Cork','1992-09-03','(062) 12345 Ext. 3',NULL),('114','Ethan','MacQuaid','Killagoola','Oranmore','Galway','1988-02-06','(062) 12345 Ext. 4',NULL),('115','Julie','O Sullivan','30 Redwood Lawn','Nenagh','Tipperary','1990-10-25','(062) 12345 Ext. 5',NULL),('116','Michael','Kane','Ballygulleen','Kilrush','Clare','1978-11-07','(062) 12345 Ext. 6',NULL),('117','Lilly','Dyer','Ballyneelish','Callan','Kilkenny','1994-02-10','(062) 12345 Ext. 7',NULL),('118','Louise','Bell','Baltinakin','Emly','Tipperary','1979-02-21','(062) 12345 Ext. 8',NULL),('119','Diarmuid','Jones','45 Hillview Ard Mhuire Pk','Clonmel Borough','Tipperary','1960-10-19','(062) 12345 Ext. 9',NULL),('120','Eva','Barry','36 Nutley Rd','Kilkenny Borough','Kilkenny','1987-06-06','(062) 12345 Ext. 0',NULL),('121','Oran','Greene','6 Marlborough Rd','Carrick-on-Suir','Tipperary','1968-06-01','(062) 12345 Ext. 1',NULL),('122','Marcus','Randall','Gortnahorna','Banagher','Offaly','2001-09-03','(062) 12345 Ext. 2',NULL),('123','Jason','O Brien','Embury Close','Newport','Tipperary','1967-09-30','(062) 12345 Ext. 3',NULL),('124','Oliver','Mac Namara','Cloonkeen','Cloghan','Offaly','1982-05-01','(062) 12345 Ext. 4',NULL),('125','Muireann','Wallace','31 Pine Valley Dr','Kilkenny Borough','Kilkenny','1970-02-24','(062) 12345 Ext. 5',NULL),('126','Denis','Nolan','44 Daarwood Cres','Clonmel Borough','Tipperary','1975-07-11','(062) 12345 Ext. 6',NULL),('127','Mila','Dawley','45 St Brennans','Carrigaline','Cork','1964-06-20','(062) 12345 Ext. 7',NULL),('128','Mollie','Fitzgerald','49 Allenton Ave','Cork','Cork','1958-03-07','(062) 12345 Ext. 8',NULL),('129','Caitlin','Dwyer','Brierfield','Urlingford','Kilkenny','1974-08-19','(062) 12345 Ext. 9',NULL),('130','Stephanie','Marshall','Bungowla','Roscrea','Tipperary','1992-07-31','(062) 12345 Ext. 0',NULL),('131','Laura','Peters','24 The Woods','Ennis','Clare','1982-11-11','(062) 12345 Ext. 1',NULL),('132','Claire','Kelly','Newborough','Tipperary','Tipperary','1959-02-01','(062) 12345 Ext. 2',NULL),('133','Brian','MacAteer','16 Estuary Rd','Nenagh','Tipperary','1989-02-20','(062) 12345 Ext. 3',NULL),('134','Casey','McLean','39 Carrick Rd','Carlow','Carlow','1981-09-11','(062) 12345 Ext. 4',NULL),('135','Mairead','Grant','2 Offington Ave','Waterford','Waterford','2000-07-24','(062) 12345 Ext. 5',NULL),('136','Emma','MacLeod','29 Cathedral Ave','Waterford','Waterford','1970-02-20','(062) 12345 Ext. 6',NULL),('137','Ciaran','Bailey','3 Wilson Rd','Kilkenny Borough','Kilkenny','1955-10-31','(062) 12345 Ext. 7',NULL),('138','Christian','Wallace','5 Commons Upr','Ennis','Clare','1959-04-03','(062) 12345 Ext. 8',NULL),('139','Steven','MacCabe','7 Rowan Ave','Shannon','Clare','1973-05-29','(062) 12345 Ext. 9',NULL),('140','Jade','Hogan','39 Castlerock Ave','Thurles','Tipperary','1974-01-30','(062) 12345 Ext. 0',NULL),('141','Hanna','Mac Fadden','Kilmagoura','Ballinakill','Laois','1999-05-19','(062) 12345 Ext. 1',NULL),('142','Martin','Mackay','Ahascragh','Roscrea','Tipperary','1966-03-14','(062) 12345 Ext. 2',NULL),('143','Franky','Hughes','50 Friary Ct','Clonmel Borough','Tipperary','1992-07-03','(062) 12345 Ext. 3',NULL),('144','Meabh','Martin','Carragh','Moneenroe','Kilkenny','1986-06-13','(062) 12345 Ext. 4',NULL),('145','Holly','MacGrath','14 Avonbeg Rd','Limerick','Limerick','1958-03-31','(062) 12345 Ext. 5',NULL),('146','Aoibhe','Bell','39 Bellevue','Clonmel Borough','Tipperary','1996-12-31','(062) 12345 Ext. 6',NULL),('147','Amy','Delaney','8 Geraldine Pl','Tramore','Waterford','1997-05-02','(062) 12345 Ext. 7',NULL),('148','Lilly','Allen','Derryvode','Clonlara','Clare','1999-07-04','(062) 12345 Ext. 8',NULL),('149','Emmet','Clery','26 Shielmartin Rd','Tullamore','Offaly','1967-04-10','(062) 12345 Ext. 9',NULL),('150','Mia','MacGrath','Gouldavoher','Rathdowney','Laois','1980-07-05','(062) 12345 Ext. 0',NULL),('151','Michael','Daly','45 Fairhill Dr','Galway','Galway','1994-04-02','(062) 12345 Ext. 1',NULL),('152','Ellie','O Riordan','42 Whitechurch Rd','Carrick-on-Suir','Tipperary','1990-09-25','(062) 12345 Ext. 2',NULL),('153','Matt','Conroy','36 Chapel Cl','Portlaoise','Laois','1955-01-18','(062) 12345 Ext. 3',NULL),('154','Chloe','Kelly','Lackaneen','Holycross','Tipperary','1991-05-15','(062) 12345 Ext. 4',NULL),('155','Conor','Jones','2 The Woods','Limerick','Limerick','1998-08-04','(062) 12345 Ext. 5',NULL),('156','Julia','Hart','Hilltop','Moroe','Limerick','1981-02-27','(062) 12345 Ext. 6',NULL),('157','Jasmine','Cameron','37 Belcamp Ave','Midleton','Cork','1985-01-30','(062) 12345 Ext. 7',NULL),('158','Marcus','Brown','34 Saggart Vlge','Ennis','Clare','1958-06-30','(062) 12345 Ext. 8',NULL),('159','Victoria','McDonald','Portumna','Cloghan','Offaly','1987-05-20','(062) 12345 Ext. 9',NULL),('160','Jade','Jackson','32 Ardcollum Ave','Limerick','Limerick','1976-01-05','(062) 12345 Ext. 0',NULL),('161','Siobhan','Mills','Curragh Bridge','Castlecomer','Kilkenny','2000-09-19','(062) 12345 Ext. 1',NULL),('162','Alanna','Fitzpatrick','17 Thornberry Ldg','Clonmel Borough','Tipperary','1980-02-27','(062) 12345 Ext. 2',NULL),('163','Evan','Higgins','Carheeny','Rhode','Offaly','1981-10-15','(062) 12345 Ext. 3',NULL),('164','Connor','Hart','40 Cowper Rd','Clonmel Borough','Tipperary','1990-04-11','(062) 12345 Ext. 4',NULL),('165','Lily','Spillane','Cregduff','Moneenroe','Kilkenny','1967-02-19','(062) 12345 Ext. 5',NULL),('166','Margaret','Mac Mahon','Whitehaven','Kilrush','Clare','1997-04-21','(062) 12345 Ext. 6',NULL),('167','Maja','Brown','21 Meadows Vale','Galway','Galway','2001-03-02','(062) 12345 Ext. 7',NULL),('168','Caoimhe','Bailey','40 CREMONA ROAD','Cork','Cork','1971-10-31','(062) 12345 Ext. 8',NULL),('169','Maja','Kennedy','3 Ennafort Rd Raheny','Kilkenny Borough','Kilkenny','1964-12-31','(062) 12345 Ext. 9',NULL),('170','Ritchie','Short','Ballinacourty','Kilmacow','Kilkenny','1959-02-19','(062) 12345 Ext. 0',NULL),('171','Reece','Scott','22 Sunberry Dr','Galway','Galway','2001-10-17','(062) 12345 Ext. 1',NULL),('172','Oisin','MacGrath','Mountbellew','Edenderry','Offaly','1992-05-22','(062) 12345 Ext. 2',NULL),('173','Kevin','Donohoe','39 Highfield Park','Limerick','Limerick','1971-02-02','(062) 12345 Ext. 3',NULL),('174','Millie','O Connor','40 Ardmore Park','Cork','Cork','1966-08-31','(062) 12345 Ext. 4',NULL),('175','Poppy','Watson','33 Clontarf Rd','Cork','Cork','1962-02-16','(062) 12345 Ext. 5',NULL),('176','Noel','Flanagan','Castlelambert','Two-Mile Borris','Tipperary','1997-02-23','(062) 12345 Ext. 6',NULL),('177','Margaret','Davidson','Annaghbane','Clonbullogue','Offaly','2000-11-05','(062) 12345 Ext. 7',NULL),('178','Michael','James','27 Lauderdale Terrace','Carrick-on-Suir','Tipperary','1971-10-06','(062) 12345 Ext. 8',NULL),('179','Aimee','Coleman','26 Rush Rd','Kilkenny Borough','Kilkenny','1962-10-14','(062) 12345 Ext. 9',NULL),('180','Mary','Roberts','Ballinakill','Roscrea','Tipperary','1998-07-24','(062) 12345 Ext. 0',NULL),('181','Abbie','Short','Millcove','Ballycumber','Offaly','2001-06-16','(062) 12345 Ext. 1',NULL),('182','Bobby','Dowd','31 Oakcourt Ave','Carlow','Carlow','1978-09-19','(062) 12345 Ext. 2',NULL),('183','Amelia','Anderson','48 Mccurtain Hl','Shannon','Clare','1992-11-17','(062) 12345 Ext. 3',NULL),('184','Ryan','Higgins','6 Kellys Bay Dr','Portlaoise','Laois','1990-10-03','(062) 12345 Ext. 4',NULL),('185','Jakub','Leahy','41 Fairlawns','Cork','Cork','1996-06-26','(062) 12345 Ext. 5',NULL),('186','Zoe','Harris','37 Constitution Hl','Clonmel Borough','Tipperary','1985-01-26','(062) 12345 Ext. 6',NULL),('187','Jamie','Flynn','The Weir','Emly','Tipperary','1960-06-15','(062) 12345 Ext. 7',NULL),('188','Jodie','Campbell','9 Glen Ave','Portlaoise','Laois','1964-08-29','(062) 12345 Ext. 8',NULL),('189','Cillian','Whelan','38 Carrow Rd','Dungarvan','Waterford','1987-06-18','(062) 12345 Ext. 9',NULL),('190','Abby','White','42 Foley St','Tullamore','Offaly','1991-03-02','(062) 12345 Ext. 0',NULL),('191','Chris','Daly','33 Limekiln Ave','Clonmel Borough','Tipperary','1961-09-12','(062) 12345 Ext. 1',NULL),('192','Brandon','Mac Nally','Ballymarchaun','Edenderry','Offaly','1978-01-19','(062) 12345 Ext. 2',NULL),('193','Rian','Healy','Holly Pk','Hacketstown','Carlow','1984-01-12','(062) 12345 Ext. 3',NULL),('194','Abbie','Fitzgerald','26 Chapel St','Nenagh','Tipperary','1976-03-31','(062) 12345 Ext. 4',NULL),('195','Shane','Bell','31 Canon Sheehan Tce','Portlaoise','Laois','1958-04-25','(062) 12345 Ext. 5',NULL),('196','Aidan','Miller','42 Rockville Rd','Clonmel Borough','Tipperary','1992-05-06','(062) 12345 Ext. 6',NULL),('197','Marty','Sweeney','Corbally','Newcastle West','Limerick','1953-08-08','(062) 12345 Ext. 7',NULL),('198','Alisha','Mac Loughlin','Caheradine','Bennettsbridge','Kilkenny','1959-03-12','(062) 12345 Ext. 8',NULL),('199','Mary','Hogan','32 Shelton Pk','Nenagh','Tipperary','2001-05-05','(062) 12345 Ext. 9',NULL),('200','Denis','O Sullivan','9 Bakers Hill','Thurles','Tipperary','2001-03-02','(062) 12345 Ext. 0',NULL),('201','Ellen','Gallagher','10 Thomas St','Limerick','Limerick','1981-11-01','(062) 12345 Ext. 1',NULL),('202','Ruby','Hagan','Yellowbrick','Ballina','Tipperary','1977-01-23','(062) 12345 Ext. 2',NULL),('203','Kayla','MacQuaid','11 St Fintans Pk','Waterford','Waterford','1992-08-29','(062) 12345 Ext. 3',NULL),('204','Grace','Oliver','13 St Endas Rd','Clonmel Borough','Tipperary','1982-09-06','(062) 12345 Ext. 4',NULL),('205','Donnacha','O Hara','Moylan Pk','Fethard','Tipperary','1960-06-29','(062) 12345 Ext. 5',NULL),('206','Aimee','O Shea','Ballymarchaun','Askeaton','Limerick','1974-11-22','(062) 12345 Ext. 6',NULL),('207','Louise','Graham','37 Prague Castleknock Rd','Galway','Galway','1988-01-12','(062) 12345 Ext. 7',NULL),('208','Heather','Manning','44 Woodlawn Way','Cork','Cork','1997-03-24','(062) 12345 Ext. 8',NULL),('209','Jake','Johnston','34 Blackglen Rd','Galway','Galway','1955-06-07','(062) 12345 Ext. 9',NULL),('210','Clara','Darcy','43 St Endas Rd','Nenagh','Tipperary','1980-05-10','(062) 12345 Ext. 0',NULL),('211','Sofia','Edmunds','Drominboy','Leighlinbridge','Carlow','1991-08-15','(062) 12345 Ext. 1',NULL),('212','Louise','Higgins','16 Sean Moylan Pk','Thurles','Tipperary','1972-09-11','(062) 12345 Ext. 2',NULL),('213','George','Darcy','24 Griffith Ave','Dungarvan','Waterford','1999-04-02','(062) 12345 Ext. 3',NULL),('214','Eddy','Coleman','23 Clonkeen Dr','Clonmel Borough','Tipperary','1955-12-07','(062) 12345 Ext. 4',NULL),('215','Maeve','Collins','Killimordaly','Mooncoin','Kilkenny','1960-08-09','(062) 12345 Ext. 5',NULL),('216','Alicia','Dickens','46 Skreen Rd','Waterford','Waterford','1959-07-09','(062) 12345 Ext. 6',NULL),('217','Colm','Sharp','Ballyfruta','Cashel','Tipperary','1989-07-23','(062) 12345 Ext. 7',NULL),('218','Cara','Paterson','Gortmore','Foynes','Limerick','1978-01-14','(062) 12345 Ext. 8',NULL),('219','Mila','Duncan','Powersfield','Edenderry','Offaly','1974-04-22','(062) 12345 Ext. 9',NULL);
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
  `PointsOnPayment` varchar(8) DEFAULT NULL,
  `PointsOnConviction` varchar(8) DEFAULT NULL,
  `FineFirstMonth` varchar(45) DEFAULT NULL,
  `FineOnConviction` varchar(45) DEFAULT NULL,
  `SectionActArticle` text NOT NULL,
  `mandatoryCourt` bit(1) DEFAULT NULL,
  PRIMARY KEY (`RegulationID`),
  UNIQUE KEY `RegulationID_UNIQUE` (`RegulationID`),
  KEY `fk_Regulation_Regulation1_idx` (`AmendedID`),
  CONSTRAINT `fk_Regulation_Regulation1` FOREIGN KEY (`AmendedID`) REFERENCES `regulation` (`RegulationID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=165 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `regulation`
--

LOCK TABLES `regulation` WRITE;
/*!40000 ALTER TABLE `regulation` DISABLE KEYS */;
INSERT INTO `regulation` VALUES (101,NULL,'Using a vehicle with defective or worn tyres','2016-01-01','2016-04-17',NULL,'2','4','80','120','Section 2, Road Traffic Act 2005',NULL),(102,NULL,'Learner permit holder driving unaccompanied by qualified person ','2016-01-01','2016-04-17',NULL,'2','4','80','120','Section 2, Road Traffic Act 2005',NULL),(103,NULL,'Failure to display N Plate or tabard ','2016-01-01','2016-04-17',NULL,'2','4','60','90','Section 2, Road Traffic Act 2005',NULL),(104,NULL,'Failure to display L-Plate or tabard','2016-01-01','2016-04-17',NULL,'2','4','60','90','Section 2, Road Traffic Act 2005',NULL),(105,NULL,'Contravention of ban on U-turns ','2016-01-01','2016-04-17',NULL,'2 ','4','60','90','Section 2, Road Traffic Act 2005',NULL),(106,NULL,'Contravention of rules for use of mini roundabouts','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(107,NULL,'Proceeding beyond no entry to vehicles sign','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(108,NULL,'Proceeding beyond a traffic lane control sign other than in accordance with such sign or without yielding','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(109,NULL,'Using vehicle in a public place without an authorisation plate ','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005',NULL),(110,NULL,'Using vehicle in a public place that has been modified or altered such that authorisation plate is inaccurate','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005',NULL),(111,NULL,'Using vehicle not equipped with a speed limitation device or using a vehicle equipped with a speed limitation device not complying with requirements specified in Regulation','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005',NULL),(112,NULL,'Proceeding beyond maximum vehicle length sign where length exceeds maximum displayed','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(113,NULL,'Proceeding beyond maximum vehicle width sign where width exceeds maximum displayed','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(114,NULL,'Proceeding beyond maximum design gross vehicle weight (safety) sign where design gross vehicle weight exceeds maximum displayed','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(115,NULL,'Proceeding beyond maximum vehicle axle loading weight sign where vehicle axle loading weight exceeds maximum specified','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(116,NULL,'Using vehicle (car) without valid test certificate (NCT)','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005',NULL),(117,NULL,'Parking a vehicle in a dangerous position','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005',NULL),(118,NULL,'Failure to drive on the left hand side of the road ','2016-01-01','2016-04-17',NULL,'2','4','60','90','Section 2, Road Traffic Act 2005',NULL),(119,NULL,'Dangerous overtaking','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005',NULL),(120,NULL,'Contravention of prohibition of driving vehicle along or across median strip','2016-01-01','2016-04-17',NULL,'2','4','60','90','Section 2, Road Traffic Act 2005',NULL),(121,NULL,'Failure to stop a vehicle before stop sign/stop line ','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005',NULL),(122,NULL,'Failure to yield right of way at a yield sign/yield line','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005',NULL),(123,NULL,'Failure to comply with mandatory traffic signs at junctions','2016-01-01','2016-04-17',NULL,'2','4','80','120','Section 2, Road Traffic Act 2005',NULL),(124,NULL,'Crossing continuous white line','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005',NULL),(125,NULL,'Failure by vehicle to obey traffic lights','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005',NULL),(126,NULL,'Failure to leave appropriate distance between you and the vehicle in front','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005',NULL),(127,NULL,'Driving vehicle before remedying dangerous defect','2016-01-01','2016-04-17',NULL,'m*','3','m*','m*','Section 2, Road Traffic Act 2005',NULL),(128,NULL,'Driving dangerously defective vehicle','2016-01-01','2016-04-17',NULL,'m*','5','m*','m*','Section 2, Road Traffic Act 2005',NULL),(129,NULL,'Using commercial vehicle without certificate of roadworthiness','2016-01-01','2016-04-17',NULL,'m*','5','m*','m*','Section 2, Road Traffic Act 2005',NULL),(130,NULL,'Bridge strikes, etc.','2016-01-01','2016-04-17',NULL,'m*','3','m*','m*','Section 2, Road Traffic Act 2005',NULL),(131,NULL,'Holding a mobile phone while driving','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005',NULL),(132,NULL,'Failure to act in accordance with a Garda signal','2016-01-01','2016-04-17',NULL,'1','3','80','120','Section 2, Road Traffic Act 2005',NULL),(133,NULL,'Entry by driver into hatched marked area of roadway, e.g. Carriageway reduction lane ','2016-01-01','2016-04-17',NULL,'1','3','80','120','Section 2, Road Traffic Act 2005',NULL),(134,NULL,'Failure to obey traffic rules at railway level crossing','2016-01-01','2016-04-17',NULL,'2','5','80','120','Section 2, Road Traffic Act 2005',NULL),(135,NULL,'Driving a vehicle on a motorway against the flow of traffic','2016-01-01','2016-04-17',NULL,'2','4','80','120','Section 2, Road Traffic Act 2005',NULL),(136,NULL,'Driving on the hard shoulder on a motorway','2016-01-01','2016-04-17',NULL,'1','3','80','120','Section 2, Road Traffic Act 2005',NULL),(137,NULL,'Driving a vehicle (subject to an ordinary speed limit of 90 kms per hour or less on the outside lane on a motorway or dual carriageway','2016-01-01','2016-04-17',NULL,'1','3','80','120','Section 2, Road Traffic Act 2005',NULL),(138,NULL,'Failure to obey requirements at junctions, e.g. Not being in the correct lane when turning onto another road','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(139,NULL,'Failure to obey requirements regarding reversing of vehicles, e.g. Reversing from minor road onto main road','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(140,NULL,'Driving on a footpath','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(141,NULL,'Driving on a cycle track','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(142,NULL,'Failure to turn left when entering a roundabout','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(143,NULL,'Failure to stop for school warden sign','2016-01-01','2016-04-17',NULL,'2','5','80','120','Section 2, Road Traffic Act 2005',NULL),(144,NULL,'Failure to stop when so required by a member of the Garda Síochána','2016-01-01','2016-04-17',NULL,'2','5','80','120','Section 2, Road Traffic Act 2005',NULL),(145,NULL,'Failure to yield','2016-01-01','2016-04-17',NULL,'2','4','80','120','Section 2, Road Traffic Act 2005',NULL),(146,NULL,'Driving without reasonable consideration','2016-01-01','2016-04-17',NULL,'2','4','80','120','Section 2, Road Traffic Act 2005',NULL),(147,NULL,'Failure to comply with prohibitory traffic signs','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(148,NULL,'Failure to comply with keep left/keep right signs','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(149,NULL,'Failure to comply with traffic lane markings','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(150,NULL,'Illegal entry onto a one-way street','2016-01-01','2016-04-17',NULL,'1','3','60','90','Section 2, Road Traffic Act 2005',NULL),(151,NULL,'Driving a vehicle when unfit','2016-01-01','2016-04-17',NULL,'m*','3','m*','m*','Section 2, Road Traffic Act 2005',NULL),(152,NULL,'Breach of duties at an accident','2016-01-01','2016-04-17',NULL,'m*','5','80','120','Section 2, Road Traffic Act 2005',NULL),(153,NULL,'Speeding','2016-01-01','2016-04-17',NULL,'3','5','80','120','Section 2, Road Traffic Act 2005',NULL),(154,NULL,'Driving without insurance','2016-01-01','2016-04-17',NULL,'m*','5','m*','m*','Section 2, Road Traffic Act 2005',NULL),(155,NULL,'Driver of Car or Goods vehicle not wearing Safety belt','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005',NULL),(156,NULL,'Failure by Driver to comply with rear seat belt requirements for passengers under 17 years','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005',NULL),(157,NULL,'Driver of car or goods vehicle permitting child under 3 years of age to travel in it without being restrained by appropriate child restraint','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005',NULL),(158,NULL,'Driver of car or goods vehicle permitting child over 3 years of age to travel in it without being restrained by appropriate child restraint','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005',NULL),(159,NULL,'Driver of car or goods vehicle permitting child to be restrained by rearward facing child restraint fitted to a seat protected by active frontal air-bag','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005',NULL),(160,NULL,'Driver of bus not wearing safety belt','2016-01-01','2016-04-17',NULL,'3','5','60','90','Section 2, Road Traffic Act 2005',NULL),(161,NULL,'Driver found to be driving carelessly','2016-01-01','2016-04-17',NULL,'m*','5','m*','m*','Section 2, Road Traffic Act 2005',NULL),(162,NULL,'Using vehicle – (a) whose weight un-laden exceeds maximum permitted weight, (b) whose weight laden exceeds maximum permitted weight, or (c) any part of which transmits to ground greater weight than maximum permitted weight','2016-01-01','2016-04-17',NULL,'1  ','3','200','300','Section 2, Road Traffic Act 2005',NULL),(163,NULL,'Drink driving offences (In all cases where the BAC is between 50mg and 80mg)','2016-01-01','2016-04-17',NULL,'3','na','200','na','Section 2, Road Traffic Act 2005',NULL);
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
  `Email` text,
  `DateAdded` date NOT NULL,
  `DateRevoked` date DEFAULT NULL,
  `DateLastAccessed` datetime DEFAULT NULL,
  `Position` varchar(45) DEFAULT NULL,
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
INSERT INTO `user` VALUES ('100','PPB','test@ppb.ie','1966-05-06','2111-01-01',NULL,NULL),('10089327498','PPB','sdfdfs','0000-00-00',NULL,NULL,'sueprkjhf'),('101','PPB','test@ppb.ie','2013-11-20',NULL,NULL,NULL),('102','PPB','test@ppb.ie','2013-11-13',NULL,NULL,NULL),('103','PPB','test@ppb.ie','2016-03-04',NULL,NULL,NULL),('104','PPB','test@ppb.ie','2016-06-13',NULL,NULL,NULL),('105','PPB','test@ppb.ie','2012-01-06',NULL,NULL,NULL),('106','PPB','test@ppb.ie','2012-09-21',NULL,NULL,NULL),('107','PPB','test@ppb.ie','2017-01-07',NULL,NULL,NULL),('108','PPB','test@ppb.ie','2016-05-25',NULL,NULL,NULL),('109','PPB','test@ppb.ie','2011-02-23',NULL,NULL,NULL),('110','PPB','test@ppb.ie','2014-05-26',NULL,NULL,NULL),('111','PPB','test@ppb.ie','2009-11-13',NULL,NULL,NULL),('112','PPB','test@ppb.ie','2012-10-22',NULL,NULL,NULL),('113','PPB','test@ppb.ie','2016-10-06',NULL,NULL,NULL),('114','PPB','test@ppb.ie','2013-10-14',NULL,NULL,NULL),('115','PPB','test@ppb.ie','2011-03-23',NULL,NULL,NULL),('116','PPB','test@ppb.ie','2012-09-26',NULL,NULL,NULL),('117','PPB','test@ppb.ie','2013-02-20',NULL,NULL,NULL),('118','PPB','test@ppb.ie','2010-05-22',NULL,NULL,NULL),('119','PPB','test@ppb.ie','2010-10-19',NULL,NULL,NULL),('120','PPB','test@ppb.ie','2014-05-15',NULL,NULL,NULL),('121','PPB','test@ppb.ie','2013-01-11',NULL,NULL,NULL),('122','PPB','test@ppb.ie','2010-04-27',NULL,NULL,NULL),('123','PPB','test@ppb.ie','2014-08-08',NULL,NULL,NULL),('124','PPB','test@ppb.ie','2014-12-30',NULL,NULL,NULL),('125','PPB','test@ppb.ie','2011-10-26',NULL,NULL,NULL),('126','PPB','test@ppb.ie','2009-11-11',NULL,NULL,NULL),('127','PPB','test@ppb.ie','2014-10-14',NULL,NULL,NULL),('128','PPB','test@ppb.ie','2017-05-02',NULL,NULL,NULL),('129','PPB','test@ppb.ie','2011-09-28',NULL,NULL,NULL),('130','PPB','test@ppb.ie','2013-04-27',NULL,NULL,NULL),('131','PPB','test@ppb.ie','2015-12-05',NULL,NULL,NULL),('132','PPB','test@ppb.ie','2009-11-15',NULL,NULL,NULL),('133','PPB','test@ppb.ie','2013-07-04',NULL,NULL,NULL),('134','PPB','test@ppb.ie','2012-05-21',NULL,NULL,NULL),('135','PPB','test@ppb.ie','2010-01-16',NULL,NULL,NULL),('136','PPB','test@ppb.ie','2014-10-22',NULL,NULL,NULL),('137','PPB','test@ppb.ie','2010-11-28',NULL,NULL,NULL),('138','PPB','test@ppb.ie','2015-07-03',NULL,NULL,NULL),('139','PPB','test@ppb.ie','2017-05-13',NULL,NULL,NULL),('140','PPB','test@ppb.ie','2017-10-14',NULL,NULL,NULL),('141','PPB','test@ppb.ie','2013-03-15',NULL,NULL,NULL),('142','PPB','test@ppb.ie','2010-06-11',NULL,NULL,NULL),('143','PPB','test@ppb.ie','2017-07-12',NULL,NULL,NULL),('144','PPB','test@ppb.ie','2012-07-06',NULL,NULL,NULL),('145','PPB','test@ppb.ie','2012-05-26',NULL,NULL,NULL),('146','PPB','test@ppb.ie','2013-11-21',NULL,NULL,NULL),('147','PPB','test@ppb.ie','2015-08-19',NULL,NULL,NULL),('148','PPB','test@ppb.ie','2011-07-09',NULL,NULL,NULL),('149','PPB','test@ppb.ie','2010-05-22',NULL,NULL,NULL),('150','PPB','test@ppb.ie','2012-03-12',NULL,NULL,NULL),('151','PPB','test@ppb.ie','2010-02-05',NULL,NULL,NULL),('152','PPB','test@ppb.ie','2011-02-08',NULL,NULL,NULL),('153','PPB','test@ppb.ie','2011-08-05',NULL,NULL,NULL),('154','PPB','test@ppb.ie','2012-08-30',NULL,NULL,NULL),('155','PPB','test@ppb.ie','2011-12-05',NULL,NULL,NULL),('156','PPB','test@ppb.ie','2014-05-10',NULL,NULL,NULL),('157','PPB','test@ppb.ie','2016-12-05',NULL,NULL,NULL),('158','PPB','test@ppb.ie','2015-03-07',NULL,NULL,NULL),('159','PPB','test@ppb.ie','2017-01-16',NULL,NULL,NULL),('160','PPB','test@ppb.ie','2017-06-04',NULL,NULL,NULL),('161','PPB','test@ppb.ie','2011-12-23',NULL,NULL,NULL),('162','PPB','test@ppb.ie','2014-02-06',NULL,NULL,NULL),('163','PPB','test@ppb.ie','2015-03-31',NULL,NULL,NULL),('164','PPB','test@ppb.ie','2013-07-18',NULL,NULL,NULL),('165','PPB','test@ppb.ie','2015-11-11',NULL,NULL,NULL),('166','PPB','test@ppb.ie','2010-02-15',NULL,NULL,NULL),('167','PPB','test@ppb.ie','2015-11-09',NULL,NULL,NULL),('168','PPB','test@ppb.ie','2015-05-03',NULL,NULL,NULL),('169','PPB','test@ppb.ie','2016-12-15',NULL,NULL,NULL),('170','PPB','test@ppb.ie','2010-07-27',NULL,NULL,NULL),('171','PPB','test@ppb.ie','2014-04-02',NULL,NULL,NULL),('172','PPB','test@ppb.ie','2015-07-09',NULL,NULL,NULL),('173','PPB','test@ppb.ie','2016-07-05',NULL,NULL,NULL),('174','PPB','test@ppb.ie','2011-11-28',NULL,NULL,NULL),('175','PPB','test@ppb.ie','2014-09-29',NULL,NULL,NULL),('176','PPB','test@ppb.ie','2014-02-19',NULL,NULL,NULL),('177','PPB','test@ppb.ie','2011-08-20',NULL,NULL,NULL),('178','PPB','test@ppb.ie','2011-08-18',NULL,NULL,NULL),('179','PPB','test@ppb.ie','2015-11-28',NULL,NULL,NULL),('180','PPB','test@ppb.ie','2013-06-07',NULL,NULL,NULL),('181','PPB','test@ppb.ie','2013-01-04',NULL,NULL,NULL),('182','PPB','test@ppb.ie','2010-12-03',NULL,NULL,NULL),('183','PPB','test@ppb.ie','2017-01-19',NULL,NULL,NULL),('184','PPB','test@ppb.ie','2015-01-12',NULL,NULL,NULL),('185','PPB','test@ppb.ie','2016-10-10',NULL,NULL,NULL),('186','PPB','test@ppb.ie','2012-05-15',NULL,NULL,NULL),('187','PPB','test@ppb.ie','2010-05-03',NULL,NULL,NULL),('188','PPB','test@ppb.ie','2017-10-01',NULL,NULL,NULL),('189','PPB','test@ppb.ie','2015-10-12',NULL,NULL,NULL),('190','PPB','test@ppb.ie','2012-06-14',NULL,NULL,NULL),('191','PPB','test@ppb.ie','2014-01-10',NULL,NULL,NULL),('192','PPB','test@ppb.ie','2014-06-19',NULL,NULL,NULL),('193','PPB','test@ppb.ie','2012-11-24',NULL,NULL,NULL),('194','PPB','test@ppb.ie','2014-02-18',NULL,NULL,NULL),('195','PPB','test@ppb.ie','2011-05-12',NULL,NULL,NULL),('196','PPB','test@ppb.ie','2015-06-04',NULL,NULL,NULL),('197','PPB','test@ppb.ie','2012-09-02',NULL,NULL,NULL),('198','PPB','test@ppb.ie','2010-10-26',NULL,NULL,NULL),('199','PPB','test@ppb.ie','2013-02-14',NULL,NULL,NULL),('200','PPB','test@ppb.ie','2011-11-21',NULL,NULL,NULL),('201','PPB','test@ppb.ie','2014-04-21',NULL,NULL,NULL),('202','PPB','test@ppb.ie','2014-07-07',NULL,NULL,NULL),('203','PPB','test@ppb.ie','2014-11-30',NULL,NULL,NULL),('204','PPB','test@ppb.ie','2011-02-14',NULL,NULL,NULL),('205','PPB','test@ppb.ie','2011-09-15',NULL,NULL,NULL),('206','PPB','test@ppb.ie','2014-07-31',NULL,NULL,NULL),('207','PPB','test@ppb.ie','2014-05-20',NULL,NULL,NULL),('208','PPB','test@ppb.ie','2010-01-13',NULL,NULL,NULL),('209','PPB','test@ppb.ie','2012-09-13',NULL,NULL,NULL),('210','PPB','test@ppb.ie','2016-02-17',NULL,NULL,NULL),('211','PPB','test@ppb.ie','2012-03-24',NULL,NULL,NULL),('212','PPB','test@ppb.ie','2010-06-20',NULL,NULL,NULL),('213','PPB','test@ppb.ie','2014-05-21',NULL,NULL,NULL),('214','PPB','test@ppb.ie','2016-06-24',NULL,NULL,NULL),('215','PPB','test@ppb.ie','2015-06-14',NULL,NULL,NULL),('216','PPB','test@ppb.ie','2011-05-10',NULL,NULL,NULL),('217','PPB','test@ppb.ie','2012-08-19',NULL,NULL,NULL),('218','PPB','test@ppb.ie','2015-06-21',NULL,NULL,NULL),('219','PPB','test@ppb.ie','2011-01-31',NULL,NULL,NULL),('220','MLA','test@mla.ie','2011-02-08',NULL,NULL,NULL),('221','MLA','test@mla.ie','2012-04-01',NULL,NULL,NULL),('222','MLA','test@mla.ie','2016-08-13',NULL,NULL,NULL),('223','MLA','test@mla.ie','2016-03-02',NULL,NULL,NULL),('224','MLA','test@mla.ie','2012-11-16',NULL,NULL,NULL),('225','MLA','test@mla.ie','2016-03-18',NULL,NULL,NULL),('226','MLA','test@mla.ie','2014-03-15',NULL,NULL,NULL),('227','MLA','test@mla.ie','2013-03-01',NULL,NULL,NULL),('228','MLA','test@mla.ie','2014-07-20',NULL,NULL,NULL),('229','MLA','test@mla.ie','2015-02-02',NULL,NULL,NULL),('230','MLA','test@mla.ie','2014-09-01',NULL,NULL,NULL),('231','MLA','test@mla.ie','2010-08-04',NULL,NULL,NULL),('232','MLA','test@mla.ie','2016-08-09',NULL,NULL,NULL),('233','MLA','test@mla.ie','2016-06-03',NULL,NULL,NULL),('234','MLA','test@mla.ie','2014-06-06',NULL,NULL,NULL),('234234','ppb','kjsh','2016-09-09',NULL,NULL,NULL),('235','MLA','test@mla.ie','2014-12-12',NULL,NULL,NULL),('236','MLA','test@mla.ie','2013-01-04',NULL,NULL,NULL),('237','MLA','test@mla.ie','2010-04-18',NULL,NULL,NULL),('238','MLA','test@mla.ie','2015-04-11',NULL,NULL,NULL),('239','MLA','test@mla.ie','2015-03-18',NULL,NULL,NULL),('240','MLA','test@mla.ie','2017-01-17',NULL,NULL,NULL),('241','MLA','test@mla.ie','2016-12-27',NULL,NULL,NULL),('242','MLA','test@mla.ie','2016-07-15',NULL,NULL,NULL),('243','MLA','test@mla.ie','2015-12-23',NULL,NULL,NULL),('244','MLA','test@mla.ie','2016-03-27',NULL,NULL,NULL),('245','MLA','test@mla.ie','2016-02-14',NULL,NULL,NULL),('246','MLA','test@mla.ie','2010-04-27',NULL,NULL,NULL),('247','MLA','test@mla.ie','2013-02-05',NULL,NULL,NULL),('248','MLA','test@mla.ie','2010-02-07',NULL,NULL,NULL),('249','MLA','test@mla.ie','2010-10-02',NULL,NULL,NULL),('250','MLA','test@mla.ie','2016-06-13',NULL,NULL,NULL),('251','MLA','test@mla.ie','2014-05-04',NULL,NULL,NULL),('252','MLA','test@mla.ie','2012-11-08',NULL,NULL,NULL),('253','MLA','test@mla.ie','2017-06-26',NULL,NULL,NULL),('254','MLA','test@mla.ie','2016-07-07',NULL,NULL,NULL),('255','MLA','test@mla.ie','2014-12-06',NULL,NULL,NULL),('256','MLA','test@mla.ie','2014-03-28',NULL,NULL,NULL),('257','MLA','test@mla.ie','2013-09-30',NULL,NULL,NULL),('258','MLA','test@mla.ie','2017-07-21',NULL,NULL,NULL),('259','MLA','test@mla.ie','2012-09-28',NULL,NULL,NULL),('260','MLA','test@mla.ie','2011-09-09',NULL,NULL,NULL),('261','MLA','test@mla.ie','2017-01-03',NULL,NULL,NULL),('262','MLA','test@mla.ie','2016-03-08',NULL,NULL,NULL),('263','MLA','test@mla.ie','2012-11-03',NULL,NULL,NULL),('264','MLA','test@mla.ie','2013-04-09',NULL,NULL,NULL),('265','MLA','test@mla.ie','2013-05-07',NULL,NULL,NULL),('266','MLA','test@mla.ie','2013-10-22',NULL,NULL,NULL),('267','MLA','test@mla.ie','2011-11-06',NULL,NULL,NULL),('268','MLA','test@mla.ie','2016-04-15',NULL,NULL,NULL),('269','MLA','test@mla.ie','2013-01-25',NULL,NULL,NULL),('270','MLA','test@mla.ie','2014-12-15',NULL,NULL,NULL),('271','MLA','test@mla.ie','2017-10-15',NULL,NULL,NULL),('272','MLA','test@mla.ie','2013-01-23',NULL,NULL,NULL),('273','MLA','test@mla.ie','2011-08-29',NULL,NULL,NULL),('274','MLA','test@mla.ie','2015-01-21',NULL,NULL,NULL),('275','MLA','test@mla.ie','2011-07-22',NULL,NULL,NULL),('276','MLA','test@mla.ie','2015-02-22',NULL,NULL,NULL),('277','MLA','test@mla.ie','2012-03-23',NULL,NULL,NULL),('278','MLA','test@mla.ie','2014-10-12',NULL,NULL,NULL),('279','MLA','test@mla.ie','2010-07-07',NULL,NULL,NULL),('280','MLA','test@mla.ie','2013-12-17',NULL,NULL,NULL),('281','MLA','test@mla.ie','2014-08-31',NULL,NULL,NULL),('282','MLA','test@mla.ie','2013-09-02',NULL,NULL,NULL),('283','MLA','test@mla.ie','2012-10-29',NULL,NULL,NULL),('284','MLA','test@mla.ie','2012-11-24',NULL,NULL,NULL),('285','MLA','test@mla.ie','2012-07-09',NULL,NULL,NULL),('286','MLA','test@mla.ie','2016-10-12',NULL,NULL,NULL),('287','MLA','test@mla.ie','2010-06-30',NULL,NULL,NULL),('288','MLA','test@mla.ie','2010-10-22',NULL,NULL,NULL),('289','MLA','test@mla.ie','2013-10-07',NULL,NULL,NULL),('290','MLA','test@mla.ie','2012-11-05',NULL,NULL,NULL),('291','MLA','test@mla.ie','2014-03-16',NULL,NULL,NULL),('292','MLA','test@mla.ie','2016-06-27',NULL,NULL,NULL),('293','MLA','test@mla.ie','2015-10-16',NULL,NULL,NULL),('294','MLA','test@mla.ie','2016-07-19',NULL,NULL,NULL),('295','MLA','test@mla.ie','2011-09-20',NULL,NULL,NULL),('296','MLA','test@mla.ie','2010-04-24',NULL,NULL,NULL),('297','MLA','test@mla.ie','2013-08-23',NULL,NULL,NULL),('298','MLA','test@mla.ie','2011-07-08',NULL,NULL,NULL),('299','MLA','test@mla.ie','2012-09-10',NULL,NULL,NULL),('300','MLA','test@mla.ie','2013-05-18',NULL,NULL,NULL),('301','MLA','test@mla.ie','2016-04-18',NULL,NULL,NULL),('302','MLA','test@mla.ie','2010-12-10',NULL,NULL,NULL),('303','MLA','test@mla.ie','2016-05-15',NULL,NULL,NULL),('304','MLA','test@mla.ie','2017-05-10',NULL,NULL,NULL),('305','MLA','test@mla.ie','2017-09-18',NULL,NULL,NULL),('306','MLA','test@mla.ie','2013-06-17',NULL,NULL,NULL),('307','MLA','test@mla.ie','2014-08-14',NULL,NULL,NULL),('308','MLA','test@mla.ie','2014-04-19',NULL,NULL,NULL),('309','MLA','test@mla.ie','2014-04-26',NULL,NULL,NULL),('310','MLA','test@mla.ie','2013-04-09',NULL,NULL,NULL),('311','MLA','test@mla.ie','2013-04-03',NULL,NULL,NULL),('312','MLA','test@mla.ie','2012-03-28',NULL,NULL,NULL),('313','MLA','test@mla.ie','2014-11-29',NULL,NULL,NULL),('314','MLA','test@mla.ie','2010-11-08',NULL,NULL,NULL),('315','MLA','test@mla.ie','2011-01-13',NULL,NULL,NULL),('316','MLA','test@mla.ie','2011-10-22',NULL,NULL,NULL),('317','MLA','test@mla.ie','2010-06-15',NULL,NULL,NULL),('318','MLA','test@mla.ie','2012-04-23',NULL,NULL,NULL),('319','MLA','test@mla.ie','2012-01-29',NULL,NULL,NULL),('320','MLA','test@mla.ie','2017-08-24',NULL,NULL,NULL),('321','MLA','test@mla.ie','2015-08-25',NULL,NULL,NULL),('322','MLA','test@mla.ie','2013-10-04',NULL,NULL,NULL),('323','MLA','test@mla.ie','2009-12-23',NULL,NULL,NULL),('324','MLA','test@mla.ie','2013-03-25',NULL,NULL,NULL),('325','MLA','test@mla.ie','2011-12-24',NULL,NULL,NULL),('326','MLA','test@mla.ie','2013-06-27',NULL,NULL,NULL),('327','MLA','test@mla.ie','2015-02-17',NULL,NULL,NULL),('328','MLA','test@mla.ie','2010-02-06',NULL,NULL,NULL),('329','MLA','test@mla.ie','2013-04-08',NULL,NULL,NULL),('330','MLA','test@mla.ie','2010-04-28',NULL,NULL,NULL),('331','MLA','test@mla.ie','2011-02-22',NULL,NULL,NULL),('332','MLA','test@mla.ie','2013-09-02',NULL,NULL,NULL),('333','MLA','test@mla.ie','2017-01-10',NULL,NULL,NULL),('334','MLA','test@mla.ie','2012-05-05',NULL,NULL,NULL),('335','MLA','test@mla.ie','2015-10-03',NULL,NULL,NULL),('336','MLA','test@mla.ie','2014-10-28',NULL,NULL,NULL),('337','MLA','test@mla.ie','2016-07-15',NULL,NULL,NULL),('338','MLA','test@mla.ie','2017-06-05',NULL,NULL,NULL),('339','MLA','test@mla.ie','2016-02-25',NULL,NULL,NULL),('340','GS','test@gs.ie','2017-10-06',NULL,NULL,NULL),('341','GS','test@gs.ie','2011-08-11',NULL,NULL,NULL),('342','GS','test@gs.ie','2012-02-23',NULL,NULL,NULL),('343','GS','test@gs.ie','2016-01-24',NULL,NULL,NULL),('344','GS','test@gs.ie','2011-11-27',NULL,NULL,NULL),('345','GS','test@gs.ie','2016-02-21',NULL,NULL,NULL),('346','GS','test@gs.ie','2011-07-10',NULL,NULL,NULL),('347','GS','test@gs.ie','2014-01-21',NULL,NULL,NULL),('348','GS','test@gs.ie','2013-01-31',NULL,NULL,NULL),('349','GS','test@gs.ie','2017-10-19',NULL,NULL,NULL),('350','GS','test@gs.ie','2013-07-02',NULL,NULL,NULL),('351','GS','test@gs.ie','2012-12-16',NULL,NULL,NULL),('352','GS','test@gs.ie','2014-03-23',NULL,NULL,NULL),('353','GS','test@gs.ie','2012-01-26',NULL,NULL,NULL),('354','GS','test@gs.ie','2013-11-11',NULL,NULL,NULL),('355','GS','test@gs.ie','2012-05-29',NULL,NULL,NULL),('356','GS','test@gs.ie','2011-07-11',NULL,NULL,NULL),('357','GS','test@gs.ie','2010-02-03',NULL,NULL,NULL),('358','GS','test@gs.ie','2014-01-01',NULL,NULL,NULL),('359','GS','test@gs.ie','2015-12-16',NULL,NULL,NULL),('360','GS','test@gs.ie','2010-10-05',NULL,NULL,NULL),('361','GS','test@gs.ie','2010-03-29',NULL,NULL,NULL),('362','GS','test@gs.ie','2012-05-26',NULL,NULL,NULL),('363','GS','test@gs.ie','2013-06-14',NULL,NULL,NULL),('364','GS','test@gs.ie','2010-02-09',NULL,NULL,NULL),('365','GS','test@gs.ie','2012-09-18',NULL,NULL,NULL),('366','GS','test@gs.ie','2009-11-24',NULL,NULL,NULL),('367','GS','test@gs.ie','2010-11-24',NULL,NULL,NULL),('368','GS','test@gs.ie','2010-05-20',NULL,NULL,NULL),('369','GS','test@gs.ie','2012-04-20',NULL,NULL,NULL),('370','GS','test@gs.ie','2016-05-23',NULL,NULL,NULL),('371','GS','test@gs.ie','2015-05-15',NULL,NULL,NULL),('372','GS','test@gs.ie','2010-04-01',NULL,NULL,NULL),('373','GS','test@gs.ie','2013-10-13',NULL,NULL,NULL),('374','GS','test@gs.ie','2017-09-29',NULL,NULL,NULL),('375','GS','test@gs.ie','2016-02-15',NULL,NULL,NULL),('376','GS','test@gs.ie','2010-06-11',NULL,NULL,NULL),('377','GS','test@gs.ie','2017-08-11',NULL,NULL,NULL),('378','GS','test@gs.ie','2015-03-08',NULL,NULL,NULL),('379','GS','test@gs.ie','2010-06-02',NULL,NULL,NULL),('380','GS','test@gs.ie','2010-12-15',NULL,NULL,NULL),('381','GS','test@gs.ie','2010-12-07',NULL,NULL,NULL),('382','GS','test@gs.ie','2016-10-25',NULL,NULL,NULL),('383','GS','test@gs.ie','2012-04-09',NULL,NULL,NULL),('384','GS','test@gs.ie','2015-08-29',NULL,NULL,NULL),('385','GS','test@gs.ie','2017-06-02',NULL,NULL,NULL),('386','GS','test@gs.ie','2011-09-27',NULL,NULL,NULL),('387','GS','test@gs.ie','2014-02-20',NULL,NULL,NULL),('388','GS','test@gs.ie','2014-12-03',NULL,NULL,NULL),('389','GS','test@gs.ie','2014-09-29',NULL,NULL,NULL),('390','GS','test@gs.ie','2013-01-16',NULL,NULL,NULL),('391','GS','test@gs.ie','2012-11-01',NULL,NULL,NULL),('392','GS','test@gs.ie','2013-01-26',NULL,NULL,NULL),('393','GS','test@gs.ie','2015-02-17',NULL,NULL,NULL),('394','GS','test@gs.ie','2009-12-12',NULL,NULL,NULL),('395','GS','test@gs.ie','2014-08-25',NULL,NULL,NULL),('396','GS','test@gs.ie','2010-09-20',NULL,NULL,NULL),('397','GS','test@gs.ie','2010-05-17',NULL,NULL,NULL),('398','GS','test@gs.ie','2013-11-23',NULL,NULL,NULL),('399','GS','test@gs.ie','2017-05-04',NULL,NULL,NULL),('400','GS','test@gs.ie','2013-06-30',NULL,NULL,NULL),('401','GS','test@gs.ie','2017-03-17',NULL,NULL,NULL),('402','GS','test@gs.ie','2016-08-15',NULL,NULL,NULL),('403','GS','test@gs.ie','2011-09-29',NULL,NULL,NULL),('404','GS','test@gs.ie','2010-04-19',NULL,NULL,NULL),('405','GS','test@gs.ie','2011-12-08',NULL,NULL,NULL),('406','GS','test@gs.ie','2016-07-26',NULL,NULL,NULL),('407','GS','test@gs.ie','2016-03-02',NULL,NULL,NULL),('408','GS','test@gs.ie','2016-07-31',NULL,NULL,NULL),('409','GS','test@gs.ie','2015-03-19',NULL,NULL,NULL),('410','GS','test@gs.ie','2016-07-04',NULL,NULL,NULL),('411','GS','test@gs.ie','2013-05-28',NULL,NULL,NULL),('412','GS','test@gs.ie','2016-03-23',NULL,NULL,NULL),('413','GS','test@gs.ie','2013-05-27',NULL,NULL,NULL),('414','GS','test@gs.ie','2014-11-30',NULL,NULL,NULL),('415','GS','test@gs.ie','2015-06-20',NULL,NULL,NULL),('416','GS','test@gs.ie','2009-12-19',NULL,NULL,NULL),('417','GS','test@gs.ie','2011-11-21',NULL,NULL,NULL),('418','GS','test@gs.ie','2011-02-19',NULL,NULL,NULL),('419','GS','test@gs.ie','2014-07-11',NULL,NULL,NULL),('420','GS','test@gs.ie','2016-06-11',NULL,NULL,NULL),('421','GS','test@gs.ie','2016-05-13',NULL,NULL,NULL),('422','GS','test@gs.ie','2017-06-19',NULL,NULL,NULL),('423','GS','test@gs.ie','2013-10-05',NULL,NULL,NULL),('424','GS','test@gs.ie','2010-05-30',NULL,NULL,NULL),('425','GS','test@gs.ie','2010-03-21',NULL,NULL,NULL),('426','GS','test@gs.ie','2012-09-28',NULL,NULL,NULL),('427','GS','test@gs.ie','2013-04-01',NULL,NULL,NULL),('428','GS','test@gs.ie','2010-07-05',NULL,NULL,NULL),('429','GS','test@gs.ie','2014-04-24',NULL,NULL,NULL),('430','GS','test@gs.ie','2014-09-01',NULL,NULL,NULL),('431','GS','test@gs.ie','2013-05-16',NULL,NULL,NULL),('432','GS','test@gs.ie','2016-04-14',NULL,NULL,NULL),('433','GS','test@gs.ie','2016-05-09',NULL,NULL,NULL),('434','GS','test@gs.ie','2015-02-16',NULL,NULL,NULL),('435','GS','test@gs.ie','2016-11-07',NULL,NULL,NULL),('436','GS','test@gs.ie','2017-01-12',NULL,NULL,NULL),('437','GS','test@gs.ie','2015-10-06',NULL,NULL,NULL),('438','GS','test@gs.ie','2010-08-23',NULL,NULL,NULL),('439','GS','test@gs.ie','2011-11-19',NULL,NULL,NULL),('440','GS','test@gs.ie','2015-01-20',NULL,NULL,NULL),('441','GS','test@gs.ie','2012-12-30',NULL,NULL,NULL),('442','GS','test@gs.ie','2010-10-19',NULL,NULL,NULL),('443','GS','test@gs.ie','2014-03-04',NULL,NULL,NULL),('444','GS','test@gs.ie','2017-10-13',NULL,NULL,NULL),('445','GS','test@gs.ie','2011-03-03',NULL,NULL,NULL),('446','GS','test@gs.ie','2016-11-06',NULL,NULL,NULL),('447','GS','test@gs.ie','2011-06-27',NULL,NULL,NULL),('448','GS','test@gs.ie','2016-03-01',NULL,NULL,NULL),('449','GS','test@gs.ie','2013-10-31',NULL,NULL,NULL),('450','GS','test@gs.ie','2010-07-18',NULL,NULL,NULL),('451','GS','test@gs.ie','2015-03-07',NULL,NULL,NULL),('452','GS','test@gs.ie','2011-04-12',NULL,NULL,NULL),('453','GS','test@gs.ie','2015-07-18',NULL,NULL,NULL),('454','GS','test@gs.ie','2010-06-01',NULL,NULL,NULL),('455','GS','test@gs.ie','2010-07-23',NULL,NULL,NULL),('456','GS','test@gs.ie','2012-02-17',NULL,NULL,NULL),('457','GS','test@gs.ie','2012-03-02',NULL,NULL,NULL),('458','GS','test@gs.ie','2015-10-11',NULL,NULL,NULL),('459','GS','test@gs.ie','2013-02-14',NULL,NULL,NULL),('Ben','PPB','ben@ppb.ie','2013-02-14',NULL,NULL,NULL),('Colin','PPB','colin@ppb.ie','2013-02-14',NULL,NULL,NULL),('Ian','PPB','ian@ppb.ie','2013-02-14',NULL,NULL,NULL),('Mike','PPB','mike@ppb.ie','2013-02-14',NULL,NULL,NULL),('sdfs','ppb','colinsdkfn@gmail.com','2016-09-12',NULL,NULL,NULL),('Steve','PPB','steve@ppb.ie','2013-02-14',NULL,NULL,NULL),('test','ppb','test@test.ie','2013-02-02',NULL,NULL,NULL),('test2','ppb','test@test.ie','2013-02-02',NULL,NULL,NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'dbppb'
--

--
-- Dumping routines for database 'dbppb'
--
/*!50003 DROP PROCEDURE IF EXISTS `addRegulation` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `addRegulation`(IN description TEXT, IN issueDate DATE, IN effectiveDate DATE, IN pointsOnPayment VARCHAR(8), IN pointsOnConviction VARCHAR(8), 
IN fineFirstMonth VARCHAR(45), IN fineOnConviction VARCHAR(45), IN sectionActArcticle TEXT, IN mandatoryCourt BIT)
BEGIN
	INSERT INTO regulation
    (
		Description,
        IssueDate,
        EffectiveDate,
		PointsOnPayment,
        PointsOnConviction,
        FineFirstMonth,
        FineOnConviction,
        SectionActArticle,
        MandatoryCourt
    )
    VALUES 
    (
		description,
        issueDate,
        effectiveDate,
        pointsOnPayment,
        pointsOnConviction,
		fineFirstMonth,
        fineOnConviction,
        sectionActArcticle,
		mandatoryCourt
    );
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `addUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `addUser`(IN userName VARCHAR(100), IN organizationID VARCHAR(3), IN position VARCHAR(45), IN email TEXT, IN dateAdded DATE)
BEGIN
	INSERT INTO dbppb.user
    (
		UserName,
		OrganizationID,
		Position,
		Email,
		DateAdded,
        DateRevoked,
        DateLastAccessed
    )
    VALUES 
    (
		userName,
		organizationID,
		position, 
		email, 
		dateAdded,
        NULL,
        NULL
    );
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `addUserIdentity` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `addUserIdentity`(IN userName VARCHAR(100), IN firstName TEXT, 
IN lastName TEXT, IN streetAddress TEXT, IN city TEXT, IN county TEXT, 
IN dateOfBirth DATE, IN telephone VARCHAR(45), IN photograph TEXT)
BEGIN
	INSERT INTO identity
    (
		UserName,
		FirstName,
		LastName,
		StreetAddress,
        City,
        County,
        DateOfBirth,
        Telephone,
        Photograph
        
    )
    VALUES 
    (
		userName,
        firstName,
        lastName,
        streetAddress,
        city,
        county,
        dateOfBirth,
        telephone,
        photograph
    );
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `listUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `listUser`()
BEGIN
	SELECT * FROM user;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `loginUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `loginUser`(IN UserName VARCHAR(100), IN Cipher VARCHAR(64))
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
/*!50003 DROP PROCEDURE IF EXISTS `ProcLogin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
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
/*!50003 DROP PROCEDURE IF EXISTS `reactivateUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `reactivateUser`(IN userName VARCHAR(100))
BEGIN
	UPDATE user
    SET DateRevoked = NULL
    WHERE UserName = userName
    LIMIT 1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `removeRegulation` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `removeRegulation`(IN regulationID INT(11), IN endDate DATE)
BEGIN
	Update regulation
    SET EndDate = endDate
    WHERE RegulationID = regulationID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `revokeUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `revokeUser`(IN userName VARCHAR(100),IN dateRevoked Date)
BEGIN
	UPDATE user
    
    SET DateRevoked = dateRevoked
    WHERE UserName = userName
    LIMIT 1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `viewUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `viewUser`(IN userName VARCHAR(100))
BEGIN
	SELECT * FROM user
    WHERE UserName = userName
    LIMIT 1;
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

-- Dump completed on 2016-11-25 18:59:23
