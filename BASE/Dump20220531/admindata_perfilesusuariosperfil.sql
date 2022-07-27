-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: admindata
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `perfilesusuariosperfil`
--

DROP TABLE IF EXISTS `perfilesusuariosperfil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `perfilesusuariosperfil` (
  `Perfiles_Id` int NOT NULL,
  `UsuariosId` mediumint NOT NULL,
  `PerfilesUsuariosEstatus` smallint NOT NULL,
  PRIMARY KEY (`Perfiles_Id`,`UsuariosId`),
  KEY `IPERFILESUSUARIOSPERFIL1` (`UsuariosId`),
  CONSTRAINT `IPERFILESUSUARIOSPERFIL1` FOREIGN KEY (`UsuariosId`) REFERENCES `usuarios` (`UsuariosId`),
  CONSTRAINT `IPERFILESUSUARIOSPERFIL2` FOREIGN KEY (`Perfiles_Id`) REFERENCES `perfiles` (`Perfiles_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perfilesusuariosperfil`
--

LOCK TABLES `perfilesusuariosperfil` WRITE;
/*!40000 ALTER TABLE `perfilesusuariosperfil` DISABLE KEYS */;
INSERT INTO `perfilesusuariosperfil` VALUES (2,5,1),(6,7,1),(12,8,1),(18,10,1),(19,9,1);
/*!40000 ALTER TABLE `perfilesusuariosperfil` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-31 10:33:51
