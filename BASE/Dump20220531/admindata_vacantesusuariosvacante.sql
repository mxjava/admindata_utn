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
-- Table structure for table `vacantesusuariosvacante`
--

DROP TABLE IF EXISTS `vacantesusuariosvacante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vacantesusuariosvacante` (
  `Vacantes_Id` int NOT NULL,
  `UsuariosId` mediumint NOT NULL,
  `UsuariosVacanteEstatus` smallint NOT NULL,
  `SUBT_ReclutadorId` mediumint NOT NULL,
  `VacantesUsuariosExTec` smallint DEFAULT NULL,
  `VacantesUsuariosCV` smallint DEFAULT NULL,
  `VacantesUsuariosPrefiltro` smallint DEFAULT NULL,
  `VacantesUsuariosEstatus` smallint DEFAULT NULL,
  `VacantesUsuariosFechaD` datetime DEFAULT NULL,
  `VacantesUsuariosFechaP` datetime NOT NULL,
  `VacantesUsuariosMotD` varchar(2048) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `VacantesUsuariosFechaE` datetime DEFAULT NULL,
  `VacantesUsuariosDocCV` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `VacantesUsuariosDocP` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `VacantesUsuariosDocTec` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `VacantesUsuariosDocAvConf` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `VacantesUsuariosDocAvPriv` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `VacantesUsuariosDocBusWeb` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `VacantesUsuariosDocExPsi` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `VacantesUsuariosDocRefLab` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `VacantesUsuariosDocCVRec` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `VacantesUsuariosAvConf` smallint DEFAULT NULL,
  `VacantesUsuariosAvPriv` smallint DEFAULT NULL,
  `VacantesUsuariosBusWeb` smallint DEFAULT NULL,
  `VacantesUsuariosExPsi` smallint DEFAULT NULL,
  `VacantesUsuariosRefLab` smallint DEFAULT NULL,
  `VacantesUsuariosCVRec` smallint DEFAULT NULL,
  `VacantesUsuariosFechaEnvCli` datetime DEFAULT NULL,
  `VacantesUsuariosFechaEnvOp` datetime DEFAULT NULL,
  `VacantesUsuariosFechaA` datetime DEFAULT NULL,
  `VacantesUsuariosFecha3` datetime DEFAULT NULL,
  PRIMARY KEY (`Vacantes_Id`,`UsuariosId`),
  KEY `IVACANTESUSUARIOSVACANTE1` (`UsuariosId`),
  KEY `IVACANTESUSUARIOSVACANTE2` (`SUBT_ReclutadorId`),
  KEY `UVACANTESUSUARIOSVACANTE` (`Vacantes_Id`,`SUBT_ReclutadorId`,`VacantesUsuariosEstatus`),
  KEY `UVACANTESUSUARIOSVACANTE1` (`VacantesUsuariosEstatus`),
  CONSTRAINT `IVACANTESUSUARIOSVACANTE1` FOREIGN KEY (`UsuariosId`) REFERENCES `usuarios` (`UsuariosId`),
  CONSTRAINT `IVACANTESUSUARIOSVACANTE2` FOREIGN KEY (`SUBT_ReclutadorId`) REFERENCES `usuarios` (`UsuariosId`),
  CONSTRAINT `IVACANTESUSUARIOSVACANTE3` FOREIGN KEY (`Vacantes_Id`) REFERENCES `vacantes` (`Vacantes_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vacantesusuariosvacante`
--

LOCK TABLES `vacantesusuariosvacante` WRITE;
/*!40000 ALTER TABLE `vacantesusuariosvacante` DISABLE KEYS */;
INSERT INTO `vacantesusuariosvacante` VALUES (1,7,1,4,0,0,0,0,'1000-01-01 00:00:00','2022-05-31 08:02:42','','1000-01-01 00:00:00','','','','','','','','','',0,0,0,0,0,0,'1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00'),(1,9,1,4,0,0,0,0,'1000-01-01 00:00:00','2022-05-31 08:05:53','','1000-01-01 00:00:00','','','','','','','','','',0,0,0,0,0,0,'1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00'),(2,7,1,4,1,1,1,3,'1000-01-01 00:00:00','2022-05-31 08:02:45','','2022-05-31 08:10:35','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\CV_ROMI921022HMCMRV52.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\PREF_ROMI921022HMCMRV52.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\EX_TEC_ROMI921022HMCMRV52.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\AV_CONF_ROMI921022HMCMRV52.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\AV_PRIV_ROMI921022HMCMRV52.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\BUS_WEB_ROMI921022HMCMRV52.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\EX_PSICO_ROMI921022HMCMRV52.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\REF_ROMI921022HMCMRV52.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\CV_R_ROMI921022HMCMRV52.pdf',1,1,1,1,1,1,'1000-01-01 00:00:00','1000-01-01 00:00:00','2022-05-31 08:11:36','2022-05-31 08:10:42'),(2,9,1,4,0,0,0,0,'1000-01-01 00:00:00','2022-05-31 08:05:57','','1000-01-01 00:00:00','','','','','','','','','',0,0,0,0,0,0,'1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00'),(4,10,1,3,0,0,0,0,'1000-01-01 00:00:00','2022-05-31 09:14:43','','1000-01-01 00:00:00','','','','','','','','','',0,0,0,0,0,0,'1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00'),(11,5,1,3,0,0,0,0,'1000-01-01 00:00:00','2022-05-31 09:19:02','','1000-01-01 00:00:00','','','','','','','','','',0,0,0,0,0,0,'1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00'),(11,10,1,3,0,0,0,0,'1000-01-01 00:00:00','2022-05-31 09:14:47','','1000-01-01 00:00:00','','','','','','','','','',0,0,0,0,0,0,'1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00'),(12,8,1,3,1,1,1,3,'1000-01-01 00:00:00','2022-05-31 08:04:14','','2022-05-31 09:06:12','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\CV_ROMI921022HMCMRV53.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\PREF_ROMI921022HMCMRV53.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\EX_TEC_ROMI921022HMCMRV53.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\AV_CONF_ROMI921022HMCMRV53.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\AV_PRIV_ROMI921022HMCMRV53.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\BUS_WEB_ROMI921022HMCMRV53.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\EX_PSICO_ROMI921022HMCMRV53.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\REF_ROMI921022HMCMRV53.pdf','C:\\Users\\Equipo01\\Downloads\\AdminData\\Archivos\\CV_R_ROMI921022HMCMRV53.pdf',1,1,1,1,1,1,'1000-01-01 00:00:00','1000-01-01 00:00:00','2022-05-31 09:07:40','2022-05-31 09:06:17'),(15,8,1,3,0,0,0,0,'1000-01-01 00:00:00','2022-05-31 08:04:18','','1000-01-01 00:00:00','','','','','','','','','',0,0,0,0,0,0,'1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00'),(17,5,0,3,0,0,0,0,'1000-01-01 00:00:00','2022-05-31 07:59:42','','1000-01-01 00:00:00','','','','','','','','','',0,0,0,0,0,0,'1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00'),(17,6,0,4,0,0,0,0,'1000-01-01 00:00:00','2022-05-31 07:59:46','','1000-01-01 00:00:00','','','','','','','','','',0,0,0,0,0,0,'1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00'),(17,7,0,4,0,0,0,0,'1000-01-01 00:00:00','2022-05-31 08:02:38','','1000-01-01 00:00:00','','','','','','','','','',0,0,0,0,0,0,'1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00'),(17,8,0,3,0,0,0,0,'1000-01-01 00:00:00','2022-05-31 08:03:56','','1000-01-01 00:00:00','','','','','','','','','',0,0,0,0,0,0,'1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00'),(17,9,0,4,0,0,0,0,'1000-01-01 00:00:00','2022-05-31 08:05:47','','1000-01-01 00:00:00','','','','','','','','','',0,0,0,0,0,0,'1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00'),(17,10,0,3,0,0,0,0,'1000-01-01 00:00:00','2022-05-31 09:14:34','','1000-01-01 00:00:00','','','','','','','','','',0,0,0,0,0,0,'1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00','1000-01-01 00:00:00');
/*!40000 ALTER TABLE `vacantesusuariosvacante` ENABLE KEYS */;
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
