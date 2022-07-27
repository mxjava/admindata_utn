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
-- Table structure for table `perfiles`
--

DROP TABLE IF EXISTS `perfiles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `perfiles` (
  `Perfiles_Id` int NOT NULL AUTO_INCREMENT,
  `Perfiles_Nombre` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Perfiles_Estatus` smallint NOT NULL,
  PRIMARY KEY (`Perfiles_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=100000000 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perfiles`
--

LOCK TABLES `perfiles` WRITE;
/*!40000 ALTER TABLE `perfiles` DISABLE KEYS */;
INSERT INTO `perfiles` VALUES (1,'Desarrollador de Software',1),(2,'Desarrollador Móvile',1),(3,'Desarrollador Front-End',1),(4,'Desarrollador Web',1),(5,'Desarrollador Back-End',1),(6,'Full - Stack',1),(7,'Desarrollador Aplicaciones de Escritorio',1),(8,'Analista de Sistemas',1),(9,'Diseñador UX',1),(10,'Testing',1),(11,'DevOps',1),(12,'Ciberseguridad',1),(13,'Analista Base de Datos',1),(14,'SAP Basic Consultant',1),(15,'Consultor SAP Basis',1),(16,'Redes y Telecomunicaciones',1),(17,'Administrador de Redes y Sistemas',1),(18,'Tecnico en Redes',1),(19,'Administrador de Redes y Servidores',1),(20,'Programador JR',1),(21,'Programador Manager',1),(22,'Licenciado en Informatica',1),(23,'Ingeniero de Servicio',1),(24,'Ingeniero de Requerimientos',1),(25,'Ingeniero de Automatización',1),(26,'Arquiteco de TI',1),(27,'Arquitecto de soluciones',1),(28,'Arquitecto Empresaril',1),(29,'Aplicaciones Empresariales',2),(30,'Diseño',2),(31,'Gestión de Información',2),(32,'Gestión de Infraestructura',2),(33,'Gestión de Proyectos y procesos',2),(34,'Ingeniería de Software',2),(35,'Marketing Digital',2),(36,'Programación',2),(37,'Recursos Humanos',2),(38,'Redes y Telecomunicaciones',2),(39,'Seguridad',2),(40,'Ventas',2),(41,'Experto en Ciberseguridad',2),(42,'Cloud Arquitect',2),(43,'Help Desk y Soporte Remoto',2),(99999999,'No cuenta con perfil',1);
/*!40000 ALTER TABLE `perfiles` ENABLE KEYS */;
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
