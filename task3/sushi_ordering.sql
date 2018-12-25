-- MySQL dump 10.16  Distrib 10.1.37-MariaDB, for Linux (x86_64)
--
-- Host: localhost    Database: sushi_ordering
-- ------------------------------------------------------
-- Server version	10.1.37-MariaDB

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
-- Table structure for table `meal`
--

DROP TABLE IF EXISTS `meal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meal` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `price` double NOT NULL,
  `image_path` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `meal_group_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `meal_group_id_FK_idx` (`meal_group_id`),
  CONSTRAINT `meal_group_id_FK` FOREIGN KEY (`meal_group_id`) REFERENCES `meal_group` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meal`
--

LOCK TABLES `meal` WRITE;
/*!40000 ALTER TABLE `meal` DISABLE KEYS */;
INSERT INTO `meal` VALUES (9,'Hamachi',3,'/Assets/Meals/hamachi.jpg',1),(10,'Spicy Tuna',5.5,'/Assets/Meals/spicy_tuna.jpg',3),(11,'California',4,'/Assets/Meals/california.jpg',3),(12,'Dynamite',12.95,'/Assets/Meals/dynamite.jpg',3),(13,'Baked Salmon',9.95,'/Assets/Meals/baked_salmon.jpg',3),(14,'Vocano',12.95,'/Assets/Meals/vocano.jpg',3),(15,'Chicago',13.95,'/Assets/Meals/chicago.jpg',3),(16,'Paradise',9.95,'/Assets/Meals/paradise.jpg',5),(17,'Spider',11.95,'/Assets/Meals/spider.jpg',4),(18,'Rosell',9.5,'/Assets/Meals/rosell.jpg',4),(19,'Tiger',9.95,'/Assets/Meals/tiger.jpg',4),(20,'Cazy',7.95,'/Assets/Meals/cazy.jpg',3),(21,'Hurricane',10.95,'/Assets/Meals/hurricane.jpg',3),(22,'Lobster',10.95,'/Assets/Meals/lobster.jpg',3),(23,'Fire',11.95,'/Assets/Meals/fire.jpg',3),(24,'Vegetable',6.95,'/Assets/Meals/vegetable.jpg',2),(25,'Ika',2.25,'/Assets/Meals/ika.jpg',2),(26,'Ikura',4,'/Assets/Meals/ikura.jpg',2),(27,'Amaebi',3.5,'/Assets/Meals/amaebi.jpg',2),(28,'Tamago',1.5,'/Assets/Meals/tamago.jpg',1),(29,'Saba',2,'/Assets/Meals/saba.jpg',1),(30,'Uni',4.5,'/Assets/Meals/uni.jpg',1),(31,'Sake',2.5,'/Assets/Meals/sake.jpg',1),(32,'Maguro',2.75,'/Assets/Meals/maguro.jpg',1),(33,'Cucumber',3.5,'/Assets/Meals/cucumber.jpg',3),(34,'Salmon',5,'/Assets/Meals/salmon.jpg',3);
/*!40000 ALTER TABLE `meal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meal_group`
--

DROP TABLE IF EXISTS `meal_group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meal_group` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meal_group`
--

LOCK TABLES `meal_group` WRITE;
/*!40000 ALTER TABLE `meal_group` DISABLE KEYS */;
INSERT INTO `meal_group` VALUES (1,'NIGIRI'),(2,'Frech Rolls'),(3,'Tempura Rolls'),(4,'Cooked Rolls'),(5,'Regular Rolls');
/*!40000 ALTER TABLE `meal_group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `submission_time` datetime NOT NULL,
  `status` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_item`
--

DROP TABLE IF EXISTS `order_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_item` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `amount` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_item`
--

LOCK TABLES `order_item` WRITE;
/*!40000 ALTER TABLE `order_item` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_item` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-12-26  1:08:49
