CREATE DATABASE  IF NOT EXISTS `socialnetwork` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `socialnetwork`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: socialnetwork
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.10-MariaDB

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
-- Table structure for table `friends`
--

DROP TABLE IF EXISTS `friends`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `friends` (
  `friend1` varchar(45) NOT NULL,
  `friend2` varchar(45) NOT NULL,
  `dateAdded` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`friend1`,`friend2`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `friends`
--

LOCK TABLES `friends` WRITE;
/*!40000 ALTER TABLE `friends` DISABLE KEYS */;
INSERT INTO `friends` VALUES ('57190b5b6355c','5719166886e1c','2016-04-27 05:20:42'),('57190b5b6355c','571ae046efdc7','2016-04-27 02:33:06'),('57190b5b6355c','571ae0f1bf084','2016-04-27 02:25:21'),('57190b5b6355c','571ae141bc8f7','2016-04-26 22:55:21'),('57190b5b6355c','571ae26468c51','2016-04-27 02:32:40'),('57190b5b6355c','571e0ab5c28cf','2016-04-27 03:02:44'),('57190b5b6355c','571e441eb05e2','2016-04-27 03:02:53'),('5719166886e1c','571ae141bc8f7','2016-04-27 03:35:44'),('5719166886e1c','571ae26468c51','2016-04-27 03:36:13'),('5719166886e1c','57201588a7312','2016-04-27 03:18:19'),('571ae046efdc7','5719166886e1c','2016-04-27 04:42:39'),('571ae046efdc7','57202644a11bc','2016-04-27 04:42:46'),('571ae0f1bf084','571ae26468c51','2016-04-27 02:26:06'),('571ae141bc8f7','571e441eb05e2','2016-04-27 04:45:42'),('571ae26468c51','571e441eb05e2','2016-04-27 04:33:07'),('571ae26468c51','57201588a7312','2016-04-27 04:43:05'),('571ae35470aeb','57190b5b6355c','2016-04-27 01:04:46'),('571ae35470aeb','571ae046efdc7','2016-04-27 04:41:58'),('571ae35470aeb','571ae141bc8f7','2016-04-27 04:42:14'),('571ae35470aeb','571e441eb05e2','2016-04-27 04:41:52'),('57201588a7312','57190b5b6355c','2016-04-27 02:32:13'),('57202644a11bc','57190b5b6355c','2016-04-27 03:48:37'),('57202644a11bc','571e0ab5c28cf','2016-04-27 03:48:16'),('57202644a11bc','57201588a7312','2016-04-27 03:48:31');
/*!40000 ALTER TABLE `friends` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profile`
--

DROP TABLE IF EXISTS `profile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `profile` (
  `profileID` varchar(45) NOT NULL,
  `description` varchar(250) DEFAULT NULL,
  `origFrom` varchar(45) DEFAULT NULL,
  `lives` varchar(45) DEFAULT NULL,
  `relationship` varchar(45) DEFAULT 'Private',
  `profilePic` varchar(45) DEFAULT 'images/profilepic.jpg',
  PRIMARY KEY (`profileID`),
  UNIQUE KEY `profileID_UNIQUE` (`profileID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profile`
--

LOCK TABLES `profile` WRITE;
/*!40000 ALTER TABLE `profile` DISABLE KEYS */;
INSERT INTO `profile` VALUES ('57190b5b6355c','I am a multi-billionaire, genius inventor and self proclaimed master of the universe.                                         ','Boherlahan, Tipperary','Limerick City','It\'s complicated','images/57190b5b6355c/profilePic..jpg'),('5719166886e1c','I like long walks on the beach, a good book and DEATH METAL!    ','Croagh, Limerick','Croagh, Limerick','Single','images/5719166886e1c/profilePic.png'),('571ae046efdc7','I love ham   ','Carrick-On-Suir','Limerick','In a relationship','images/571ae046efdc7/profilePic..jpg'),('571ae0f1bf084','I like playing piano and going to mass.    ','Athenry, Galway','Cratloe, Limerick','Married','images/571ae0f1bf084/profilePic..jpg'),('571ae141bc8f7','I love cheese pizza and vans.','Rathkeale','Limerick','Divorced','images/571ae141bc8f7/profilePic..jpg'),('571ae26468c51','I <3 Conor Mcgregor 4eva. ','CourtMatrix, Limerick','Cratloe, Limerick','Private','images/571ae26468c51/profilePic..jpg'),('571ae35470aeb','I love swamp donkeys.','Balingarry, Limerick','Limerick City, Limerick','Divorced','images/571ae35470aeb/profilePic..jpg'),('571e0ab5c28cf',NULL,NULL,NULL,'Private','images/571e0ab5c28cf/profilePic..jpg'),('571e441eb05e2',NULL,NULL,NULL,'Private','images/profilepic.jpg'),('57201588a7312',' I am the greatest actor of all time.','','','Fucking bitches','images/57201588a7312/profilePic..jpg'),('57202644a11bc',' ','','','Private','images/57202644a11bc/profilePic..jpg'),('Admin',NULL,NULL,NULL,'Private','images/profilepic.jpg');
/*!40000 ALTER TABLE `profile` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `userID` varchar(45) NOT NULL,
  `firstName` varchar(45) DEFAULT NULL,
  `lastName` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  `dateOfBirth` date DEFAULT NULL,
  `gender` varchar(45) DEFAULT NULL,
  `dateCreated` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`userID`),
  UNIQUE KEY `userID_UNIQUE` (`userID`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  CONSTRAINT `userprofileFK` FOREIGN KEY (`userID`) REFERENCES `profile` (`profileID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('57190b5b6355c','Colin','Maher','colinmaher94@gmail.com','a237daedeb1c1d7641153fe5bc6956d66f660b15a8d3fd5b270a16d8161fde27','1994-09-27','male','2016-04-21 18:18:19'),('5719166886e1c','Tom ','Reidy','tomreidy@gmail.com','d128e8949b839dc0cc00a26137f2fe331f62f9b2d2b95d487c09da6eb7b283c4','1994-03-18','male','2016-04-21 19:05:28'),('571ae046efdc7','James ','Croke','jamescroke@gmail.com','c4a86cf5850063763ec9a116361694992105afeedd849d9f8cd7ef33a73c9aee','1993-02-13','male','2016-04-23 03:39:02'),('571ae0f1bf084','Mickey','Ryan','mickeyryan@gmail.com','24aa9992df16c45b246edde7efbfe75d58ebbd91e39a2e20093e2975db4ffa0d','1995-02-13','male','2016-04-23 03:41:53'),('571ae141bc8f7','Nick','Sheahan','nicksheahan@gmail.com','35853deb523a42741577086d70d3bc9094cf21fd671a70d21cb644a2103ec164','1972-06-16','male','2016-04-23 03:43:13'),('571ae26468c51','John','Egan','johnton@gmail.com','760c8855ba669636f5a13fa130e94c8642da7fe5d32c7a6c5c3cbc3207cf5669','1996-04-19','male','2016-04-23 03:48:04'),('571ae35470aeb','Cian','O\'Flynn','cian@gmail.com','bac46570a924e0a51bd162c4db51eefb1cff56f3ee6ad76098e93bbca2ea9eba','1993-05-18','male','2016-04-23 03:52:04'),('571e0ab5c28cf','Dan The Man','Malone','danmalone@gmail.com','c20a56c011075f445de46aacd3acf2d79f57d2a8c4e9472fdee7913550e495e0','1995-02-13','male','2016-04-25 13:16:53'),('571e441eb05e2','Tim','Mcinerney','tim@gmail.com','773ba82b197659338212e88d93ace643918fbfe14616e5c7180e28f38008512c','1995-02-13','male','2016-04-25 17:21:50'),('57201588a7312','Leo','Dicraprio','leod@gmail.com','675de54a769a26c85b1d760d2ab5801bd90d85820385560c8a39cfeb83290436','1995-02-13','male','2016-04-27 02:27:36'),('57202644a11bc','Michael D','Higgins','mdh@gmail.com','45e07ab66fa6619627a480026427e276fc7c31737685fc24fb3d854903460eab','0000-00-00','male','2016-04-27 03:39:00'),('Admin','Admin',NULL,NULL,'d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892',NULL,NULL,'2016-04-27 06:10:41');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-04-27  6:28:59
