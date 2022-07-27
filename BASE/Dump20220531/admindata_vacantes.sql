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
-- Table structure for table `vacantes`
--

DROP TABLE IF EXISTS `vacantes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vacantes` (
  `Vacantes_Id` int NOT NULL AUTO_INCREMENT,
  `Vacantes_Nombre` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Vacantes_Status` smallint NOT NULL,
  `Vacantes_FechaInicio` date NOT NULL,
  `Vacantes_Sueldo` decimal(5,3) NOT NULL,
  `Vacantes_Tipo` smallint NOT NULL,
  `Vacantes_Duracion` smallint NOT NULL,
  `Vacantes_Duracion_Nom` smallint NOT NULL,
  `Vacantes_Descripcion` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Vacantes_Plazas` smallint NOT NULL,
  PRIMARY KEY (`Vacantes_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vacantes`
--

LOCK TABLES `vacantes` WRITE;
/*!40000 ALTER TABLE `vacantes` DISABLE KEYS */;
INSERT INTO `vacantes` VALUES (1,'Desarrollador .Net SR',1,'2022-05-13',3.450,1,5,2,'Se solicita un programador Junior con conocimiento en java\n-- Que sepa de redes\n-- Que conozca de virtualización 1',10),(2,'Desarrollador DevOps SR',1,'2022-05-12',15.000,2,2,3,'Se solicita personal capas de desarrollar paginas web con buena presentación.\n- Conocimientos en informix\n- Conocimientos en Linux',5),(3,'Diseñador UX/UI sr',1,'2022-05-01',18.000,3,9,2,'Se solicita personal capas de demostrar las formas de diseño de una pantalla identificando lo mas funcional para el personal.',8),(4,'Lideres de Proyecto',1,'2021-06-02',40.500,2,5,3,'Empresa SERTEC, solicita personal con las características de líder de proyecto que sea capaz de mostrar una buena presentación.\n- Buena presentación',2),(5,'DBA Informix',1,'2022-05-18',55.350,2,10,3,'Se solicita personal con conocimientos en Informix, con la capacidad de realizar Store Procedure, Inner Join.',1),(6,'DBA ORACLE',1,'2022-05-16',45.000,1,6,3,'Conocimiento de BD en oracle con experiencia de 10 años',3),(7,'Programador en PHP',2,'2022-05-18',12.350,2,5,3,'Conocimiento básico en PHP, con características mínimas de programación que cuente con un año de experiencia .\n--- Buena presentacion\n',4),(8,'Arquitecto de Ciber Seguridad',3,'2022-05-17',28.400,2,3,3,'Gestionar auditorías internas, externas, de terceros, revisiones de control interno\nGestionar incidentes de seguridad realizar workshops periódicos para el equipo de TI\nSupervisar la administración de las plataformas de ciberseguridad (Antimalware, Filtrado Web, Firewalls, plataforma de concientización, etc.)\n\n- Realizar actividades de análisis y remediación de vulnerabilidades\n- Coordinar análisis de vulnerabilidades, pruebas de penetración y establecer los planes de mitigación.\n- Supervisar y mantener actualizados los casos de uso para el Centro de Operaciones de Seguridad',8),(9,'Docente de Informática',3,'2022-05-16',15.400,3,2,3,'Se necesita un docente informático capas de solventar los problemas relacionados con todos los inconvenientes que surgan.\n- Experiencia profesional\n- Conocimiento en paqueteria de Office\n- Licencia de Ingniera',7),(10,'Técnico en informática',1,'2022-05-16',7.500,2,9,2,'Técnico de mantenimiento en reparación de equipos de impresión y multifuncionales (egresados con bases en reparaciones técnicas) y en equipos de IMPRESIÓN.\n\n- Bachillerato técnico en mecatrónica, computación, electrónica, informática o electricidad\n- Proactivo, responsable y comprometido\n- Experiencia: Bases en el mantenimiento de equipos eléctricos, uso de desarmadores, ensamblado de equipos de impresión, mantenimiento preventivo y correctivo.\n- Gusto por el trabajo en campo\n- Licencia vigente',6),(11,'Director de informática',1,'2022-05-19',25.000,2,2,3,'Es el responsable de organizar y gestionar área de desarrollo de sistemas informáticos de la institución, procurando el uso óptimo y eficiente de recursos, liderara área proyectos desarrollo de sistemas para lograr resultados esperados en tiempo, costos y forma.\n\n- Organizar y gestionar el área de desarrollo de sistemas informáticos de la institución, procurando un uso óptimo y eficiente de los recursos tecnológicos y humanos mediante definición de estándares y metodologías de trabajo apropiadas.\n - Planear e Implementar sistemas y servicios tecnológicos e informáticos que coadyuven a la eficacia y eficiencia de las funciones.\n- Proponer, aplicar y controlar buenas prácticas en el proceso de desarrollo de sistemas\n- Elaborar el plan de trabajo del área de Desarrollo, con un enfoque en gestión (KPI\'s)\n- Coordinar la supervisión de la red para su correcto funcionamiento.',5),(12,'Analista de seguridad informática',1,'2022-05-16',22.700,2,5,3,'Somos una empresa dedicada a suministrar Servicios de TI y estamos en busca de:\n\nRequisitos:\n\n· Licenciatura en Ingeniería en Sistemas o afín.\n· Experiencia mínima de 1 año (Comprobables)\n· Disponibilidad para viajar\n\nConocimientos necesarios:\n\n· Manejo de Microsoft Office\n·  Manejo de Sistemas Operativos\n·  Conducir\n\nFunciones:\n\n·  Manejo de plataformas de seguridad\n·  Monitoreo de plataformas de seguridad\n·  Mantenimiento al CCTV\n·  Soporte técnico en sitio y remoto\n·  Generación de reportes.\n·  Soporte general a Software y Hardware',9),(13,'Auditor de TI y Seguridad informática',1,'2022-05-17',33.400,1,6,3,'Escolaridad: Licenciatura en Informática Administrativa, Ing. Sistemas Computacionales o carrera afín concluida (pasante o titulado).\n\nEXPERIENCIA mínima de 1 año realizando las siguientes actividades:\nAnálisis y administración de proyectos asignados.\nDocumentación de riesgos de seguridad informática.\nAnálisis de acciones correctivas, control interno y gestión de riesgos (Metodología COSO).\nDiagrama, identificación y seguimiento a controles implementados.\nConocimientos sólidos en auditorias Informáticas Información y comunicación de actividades de monitoreo.\n\nConocimientos Técnicos:\n- UNIX/WINDOWS\n- ITIL\n- COBIT\n- COSO\n- Conocimientos de ERP´S\n- Inglés (intermedio)\n- Disponibilidad de viaje (50%)\n- Zona de Trabajo: ZONA SUR DE CIUDAD DE MÉXICO ',12),(14,'Ejecutivo ventas informática',1,'2022-05-16',20.000,2,6,3,'Importante empresa de soluciones tecnológicas en seguridad, solicita:\nEjecutivo comercial\n\nRequisitos indispensables:\n\n*Presentación ejecutiva\n*Disponibilidad para viajar\n*Licenciatura o ingeniería en sistemas computacionales o afín, deseables titulados\n*inglés intermedio avanzado\n*Experiencia mínima de 2 años en área comercial de tecnologías de seguridad e información – prospección de clientes, propuestas, presentaciones, negociación-objeción, proceso completo de venta desde inicio hasta cierre y facturación\n*Manejo CRM (Salesforce), office, internet\n*Indispensable contar con automóvil propio, se brindar apoyo para gasolina',6),(15,'Ingeniero de seguridad informática',1,'2022-05-17',14.525,3,5,3,'Conocimiento:\n- Comprensión básico de redes (LAN, WAN y Wireless).\n- Conocimiento de los modelos de referencia OSI, TCP/IP.\n- Conocimiento de Switching y Routing.\n- Conocimiento básico de Seguridad Informática( protocolos de seguridad,NAT, PAT,VPN cliente y VPN Site-to-Site,Tipos de autenticación, Tipos de Cifrado, Puertos de red (http, SSL, SSH, etc), DoS y DDoS) .\n- Comprensión básica de conceptos (Filtrado de contenido Web, Filtrado de contenido SMTP, Antivirus, Anti Spyware, Botnets, APT`s, DHCP, DNS, NTP, RADIUS, TACACS+, LDAP, Kerberos.\n- Manejo de sistemas operativos Windows, Unix y/o Linux. \n\nActividades:\n* Soporte a la infraestructura de seguridad.\n* Generación de maquetas de seguridad.\n* Actualizaciones de firmware y bases de datos a los diferentes equipos de seguridad Mantenimiento preventivo y correctivo a equipos de seguridad\n* Generación de pruebas de concepto (POC) con los diferentes clientes\n    Instalación, configuración y puesta punto de ',5),(16,'Jefe de academia de informática',1,'2022-05-16',11.800,2,5,3,'Buscamos Jefe de academia de Informática\n\nEscolaridad: \n\n* Licenciatura en sistemas computacionales, Informática, Tecnologías de la información o carrera afín, indispensable contar con título profesional. \n* Preferentemente con estudios de posgrado. \n* Experiencia como docente a y por lo menos dos años como coordinador, jefe de academia o docente de tiempo completo.\n* Experiencia en el manejo de programas académicos de bachillerato, contenidos temáticos, planes y programas de estudio, trámites y gestión educativa, atención a alumnos, docentes y padres de familia. ',2),(17,'Aun no cuenta',9,'2022-05-13',9.000,9,9,9,'No tiene',9);
/*!40000 ALTER TABLE `vacantes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-31 10:33:50
