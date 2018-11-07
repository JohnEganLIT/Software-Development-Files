CREATE DATABASE  IF NOT EXISTS `litrealty` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `litrealty`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: litrealty
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.19-MariaDB

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
-- Table structure for table `agents`
--

DROP TABLE IF EXISTS `agents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `agents` (
  `agentId` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `phone` varchar(12) DEFAULT NULL,
  `fax` varchar(12) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `username` varchar(50) NOT NULL,
  `password` text NOT NULL,
  PRIMARY KEY (`agentId`),
  KEY `agentId` (`agentId`)
) ENGINE=MyISAM AUTO_INCREMENT=123 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agents`
--

LOCK TABLES `agents` WRITE;
/*!40000 ALTER TABLE `agents` DISABLE KEYS */;
INSERT INTO `agents` VALUES (1,'Sue Roberts','555-1234','555-9876','sue@homesellers.com','Sue.Roberts','suepass'),(2,'Natasha Watkins','555-1357','555-9876','tasha@homesellers.com','Natasha.Watkins','natashapass'),(3,'Chris Clarkson','555-2468','555-6767','chris@homesellers.com','Chris.Clarkson','chrispass'),(4,'Laura Blain','555-9898','555-6767','laura@homesellers.com','Laura.Blain','laurapass'),(5,'Dave Lindale','555-8833','555-9876','dave@homesellers.com','Dave.Lindale','davepass'),(122,'Ger Hynes','09878778','09878778','ger.hynes@homesellers.com','ger,hynes','gerpass');
/*!40000 ALTER TABLE `agents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `garagetypes`
--

DROP TABLE IF EXISTS `garagetypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `garagetypes` (
  `garageId` int(11) NOT NULL AUTO_INCREMENT,
  `gType` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`garageId`),
  KEY `garageId` (`garageId`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `garagetypes`
--

LOCK TABLES `garagetypes` WRITE;
/*!40000 ALTER TABLE `garagetypes` DISABLE KEYS */;
INSERT INTO `garagetypes` VALUES (1,'attached'),(2,'detached'),(3,'carport');
/*!40000 ALTER TABLE `garagetypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `properties`
--

DROP TABLE IF EXISTS `properties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `properties` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `street` varchar(50) DEFAULT NULL,
  `city` varchar(25) DEFAULT NULL,
  `listingNum` int(11) DEFAULT '0',
  `styleId` int(11) DEFAULT '0',
  `typeId` int(11) DEFAULT '0',
  `bedrooms` int(11) DEFAULT '0',
  `bathrooms` float DEFAULT '0',
  `squarefeet` int(11) DEFAULT '0',
  `description` text,
  `lotsize` varchar(25) DEFAULT NULL,
  `garagesize` tinyint(4) DEFAULT '0',
  `garageId` int(11) DEFAULT '0',
  `agentId` int(11) DEFAULT '0',
  `photo` varchar(50) DEFAULT NULL,
  `price` double DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `id` (`id`),
  KEY `listingNum` (`listingNum`)
) ENGINE=MyISAM AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `properties`
--

LOCK TABLES `properties` WRITE;
/*!40000 ALTER TABLE `properties` DISABLE KEYS */;
INSERT INTO `properties` VALUES (9,'42 Canalside Dr.','Limerick',443499,9,2,5,1.5,1100,'Water-side condo living! Less than three years old with updated kitchen. Private deck overlooks semi-private yard and a beautiful water view. Includes private dock space for your boat.','20x45',1,1,3,'443499.jpg',82000),(10,'1209 Dockside Trail','Dublin',141136,1,1,5,2,1700,'River-side living awaits you in this updated 1970s-built quality home. Large private yard with huge deck and all the amenities. Call today!','70x250',2,1,1,'141136.jpg',203500),(11,'143 Main St.','Cork',598495,8,1,2,4,1800,'Showpiece historic home. Lovingly restored but with all the modern conveniences. New furnace and central air. Enclosed porch and backyard patio.','60x120',2,2,4,'598495.jpg',249900),(12,'55 Packetsmith Circle','Galway',128365,3,1,2,1,1200,'Great starter home at a fantastic price! Own for less than you pay in rent. Great condition on a quiet street.','60x90',1,1,4,'128365.jpg',93900),(6,'sdfjhgskagfuyasgdfh','gkhjgjkhg',288644,1,1,12,23,3261,'Classsajkdhjksdhfkjasdf','120x150',0,4,3,'288644.jpg',103900),(14,'123 Horsham Lane','Dublin',387190,4,1,3,2,1800,'This lovingly updated country Victorian sits on a huge lot in the midst of a lovely village. Quiet side street, great schools. This is the home for you.','70x200',2,2,1,'387190.jpg',178900),(15,'481 Monmouth St.','Kilkenny',727218,1,1,5,2.5,2100,'Huge addition and many updates on this lovely old home. Large back deck. Barn for plenty of storage.','70x140',2,2,5,'727218.jpg',159900),(16,'90 Hidden Valley Way','Waterford',727213,1,1,3,2,1800,'Lovely recent home with large yard. New driveway and new paint. Mechanicals in great condition. Ready for you to move in.','70x110',1,2,4,'727213.jpg',99900),(17,'61 Mull Dr.','Cork',197681,4,1,3,1.5,1650,'A brick beauty! Large barn with second-floor loft/office. Quiet side street in a great location. ','100x110',2,1,1,'197681.jpg',159500),(40,'Ludlow St','Limerick',0,0,0,3,2,0,'Nice old spot',NULL,0,0,0,NULL,0),(1,'sdfjhgskagfuyasgdfh','gkhjgjkhg',784571,1,2,12,23,3261,'Classsajkdhjksdhfkjasdf','80x110',1,1,2,'466794.jpg',200800),(13,'1021 Cambridge Dr.','Galway',941895,3,1,2,1.5,1300,'With some TLC, this could be your dream home. Large back yard overlooks undeveloped wooded land. Wonderful neighborhood and great schools. Grab your tools and make this your new home today!','60x120',0,4,2,'941895.jpg',89900),(19,'184 Whispering Pines','Kilkenny',778954,5,1,2,1,950,'Charming modern showpiece of a home. You simply must see this architect-designed interior! ','80x100',1,1,3,'778954.jpg',106900),(20,'14 West Ave','Limerick',377190,8,1,4,2,2100,'Grand old home in need of loving owners. Beautiful hardwoods throughout. Two fireplaces. New front portico.','70x200',0,4,1,'377190.jpg',179000),(21,'32 Lincoln St.','Derry',368089,4,1,4,1.5,1800,'Grand victorian home with gumwood trim throughout. Private yard on very quiet side street. Close to everything. Owner anxious to sell.','70x120',1,2,5,'368089.jpg',185900),(22,'134 Islay Dr.','Cork',132927,1,1,5,1.5,1750,'Quality 10-year old home in a great location. Corner lot with plenty of space. Large two-tiered deck and inground pool.','100x100',2,1,2,'132927.jpg',132900),(23,'985 Andover Lane','Derry',493498,1,1,3,2,1575,'All the conveniences...air, new kitchen, whirlpool tub, deck. This is the home for you!','80x110',2,1,5,'493498.jpg',139900),(24,'451 Briggs Ave','Dublin',335965,5,1,3,1.5,1900,'Beautiful home waiting for you! Gorgeous interior is matched by wonderful private gardens outside.','80x110',2,1,3,'335965.jpg',145900),(25,'148 Pineview Park','Derry',854600,8,1,5,2.5,2500,'This huge home awaits your family. Spacious interior. Vaulted ceiling in enormous family room. Wired for audio, video, Internet throughout.','120x150',3,1,1,'854600.jpg',145000),(26,'1398 Marsh Drive','Limerick',466794,1,1,4,1.5,1775,'Convenience is the name of this home\'s game. Close to work and fun. Maintenance free exterior and updated interior. Move-in ready.','120x150',2,1,3,'466794.jpg',139500),(27,'1452 Winding Meadow','Derry',141036,9,2,2,2,1400,'Modern carefree living awaits you in this brand new condo. Low association dues. All maintenance provided. Great for a busy executive like you.','60x60',2,1,4,'141036.jpg',159900),(29,'1582 MacIntyre Lane','Cork',424375,8,1,4,2,2100,'Large home on huge corner lot. Modern-built, but with all the charm of a grand old home. Fantastic low-maintenance landscaping means less work and more enjoyment.','150x200',3,2,2,'424375.jpg',162900),(30,'98 Warwick Drive','Belfast',491686,1,1,1500,244,1500,'Quiet street, great schools, close to work. This is the home for you. 2 year warranty on mechanicals. Lovely gardens\nLovely and a agreat Place to live.','80x100',2,1,5,'491686.jpg',119900),(31,'22 Edinburough St.','Limerick',664622,3,1,2,1,975,'Great starter home for a single or small family. Ready for you to move in today. Updated kitchen and new bath.','70x100',1,1,1,'664622.jpg',125900),(7,'84 Crumlin Way','Dublin',281903,11,3,1700,0,3800,'Money-maker! -- 1800s home sensitively converted to an historic office building. Three current tenants will stay. 1800 sq. ft. vacant space awaiting your business. Rents pay all the bills.','80x120',0,4,5,'281903.jpg',599900),(8,'67 Leeds Park Dr.','Derry',490686,10,1,2,1,1990,'Apartment living at its best! Private entrance to downstairs aparment. Only three units per building makes for quiet living arrangements. Convenient access to business districts.','0',0,4,3,'490686.jpg',350000);
/*!40000 ALTER TABLE `properties` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `propertytypes`
--

DROP TABLE IF EXISTS `propertytypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `propertytypes` (
  `typeId` int(11) NOT NULL AUTO_INCREMENT,
  `pType` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`typeId`),
  KEY `typeId` (`typeId`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `propertytypes`
--

LOCK TABLES `propertytypes` WRITE;
/*!40000 ALTER TABLE `propertytypes` DISABLE KEYS */;
INSERT INTO `propertytypes` VALUES (1,'Residential-single'),(2,'Residential-multi'),(3,'Commercial');
/*!40000 ALTER TABLE `propertytypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `styles`
--

DROP TABLE IF EXISTS `styles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `styles` (
  `styleId` int(11) NOT NULL AUTO_INCREMENT,
  `pStyle` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`styleId`),
  KEY `styleId` (`styleId`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `styles`
--

LOCK TABLES `styles` WRITE;
/*!40000 ALTER TABLE `styles` DISABLE KEYS */;
INSERT INTO `styles` VALUES (1,'Colonial'),(2,'Tudor'),(3,'Ranch'),(4,'Victorian'),(5,'Modern'),(8,'Traditional'),(9,'Condo'),(10,'Apartment'),(11,'Other');
/*!40000 ALTER TABLE `styles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'litrealty'
--

--
-- Dumping routines for database 'litrealty'
--
/*!50003 DROP PROCEDURE IF EXISTS `DeleteProperty` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteProperty`(IN ID INT(11))
BEGIN
SET SQL_SAFE_UPDATES=0;
DELETE FROM properties WHERE properties.id = ID; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertProperty` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertProperty`(IN Street VARCHAR(50), IN City VARCHAR(25), IN ListingNum INT(11), IN StyleID INT(11), IN TypeID INT(11), IN Bedrooms INT(11), IN Bathrooms INT(11), IN Squarefeet INT(11), IN Description TEXT, IN Lotsize VARCHAR(25), IN GarageSize TINYINT(4), IN GarageID INT(11), IN AgentID INT(11), IN Photo VARCHAR(50), IN price DOUBLE)
BEGIN
SET SQL_SAFE_UPDATES=0;
INSERT INTO properties (street, city, listingnum, styleId, typeId, bedrooms, bathrooms, squarefeet, description, lotsize, garagesize, garageId, agentId, photo, price) VALUES (Street, City, ListingNum, StyleID, Bedrooms, Bathrooms, Squarefeet, Description, Lotsize, GarageSize, GarageID, AgentID, Photo, Price);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Login` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Login`(IN user VARCHAR(50), IN pass TEXT)
BEGIN
SELECT * FROM agents WHERE username = user AND password = pass;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SearchProperties` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SearchProperties`(IN location VARCHAR(25), IN lowPrice Double, IN highPrice Double)
BEGIN
SELECT * FROM properties WHERE city = location AND price >= lowPrice AND price < highPrice;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UpdateProperty` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateProperty`(IN ID INT(11), IN Street VARCHAR(50), IN Bedrooms INT(11), IN Bathrooms INT(11), IN Squarefeet INT(11), IN Description TEXT)
BEGIN
SET SQL_SAFE_UPDATES=0;
UPDATE properties SET street=Street, bedrooms=Bedrooms, bathrooms=Bathrooms, squarefeet=Squarefeet, description=Description WHERE properties.id = ID;
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

-- Dump completed on 2017-01-18 14:05:27
