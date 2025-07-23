-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: db_clinica
-- ------------------------------------------------------
-- Server version	8.0.42

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
-- Table structure for table `consulta`
--

DROP TABLE IF EXISTS `consulta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `consulta` (
  `id` int NOT NULL AUTO_INCREMENT,
  `numero` varchar(255) NOT NULL,
  `prioridad` varchar(45) NOT NULL,
  `fecha` datetime(6) NOT NULL,
  `sintomas` text,
  `padecimientos` text,
  `alergias` text,
  `presion` varchar(45) DEFAULT NULL,
  `temperatura` varchar(45) DEFAULT NULL,
  `peso` varchar(45) DEFAULT NULL,
  `estatura` varchar(45) DEFAULT NULL,
  `persona_id` int NOT NULL,
  `doctor_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_consulta_persona1_idx` (`persona_id`),
  KEY `fk_consulta_doctor1_idx` (`doctor_id`),
  CONSTRAINT `fk_consulta_doctor1` FOREIGN KEY (`doctor_id`) REFERENCES `doctor` (`id`),
  CONSTRAINT `fk_consulta_persona1` FOREIGN KEY (`persona_id`) REFERENCES `persona` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `consulta`
--

LOCK TABLES `consulta` WRITE;
/*!40000 ALTER TABLE `consulta` DISABLE KEYS */;
INSERT INTO `consulta` VALUES (2,'CLICONS-00001','Alta','2025-07-14 00:00:00.000000','Dolor de cabeza y garganta','Asma','Penicilina','125/75','38','57','1.58',1,1),(4,'CLICONS-00002','Alta','2025-07-20 00:00:00.000000',NULL,NULL,NULL,NULL,NULL,NULL,NULL,5,2),(5,'CLICONS-00003','Media','2025-07-22 00:00:00.000000','Le duele la garganta','N/A','N/A','120/80','37','80','1.7',3,3),(6,'CLICONS-00004','Baja','2025-07-22 00:00:00.000000',NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,2);
/*!40000 ALTER TABLE `consulta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doctor`
--

DROP TABLE IF EXISTS `doctor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doctor` (
  `id` int NOT NULL AUTO_INCREMENT,
  `identificacion` varchar(45) NOT NULL,
  `nombre_completo` varchar(50) NOT NULL,
  `apellido` varchar(45) NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `telefono` varchar(45) NOT NULL,
  `correo` varchar(45) NOT NULL,
  `edad` varchar(45) NOT NULL,
  `sexo` varchar(45) NOT NULL,
  `usuarios_idusuarios` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_doctor_usuarios1_idx` (`usuarios_idusuarios`),
  CONSTRAINT `fk_doctor_usuarios1` FOREIGN KEY (`usuarios_idusuarios`) REFERENCES `usuarios` (`idusuarios`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doctor`
--

LOCK TABLES `doctor` WRITE;
/*!40000 ALTER TABLE `doctor` DISABLE KEYS */;
INSERT INTO `doctor` VALUES (1,'1-1234-5678','Andrés','Solano','San José, Costa Rica','8898-1001','andres.solano@gmail.com','40','Masculino',7),(2,'2-2345-6789','Carolina','Mora','Cartago, Costa Rica','8825-0200','carolina.mora@hotmail.com','35','Femenino',8),(3,'3-3456-7890','Felipe','Castro','Heredia, Costa Rica','8845-2003','felipe.castro@gmail.com','42','Masculino',9),(4,'4-4567-8901','Natalia','Rojas','Alajuela, Costa Rica','8860-1004','natalia.rojas@yahoo.es','38','Femenino',10),(5,'5-5678-9012','Esteban','Núñez','Puntarenas, Costa Rica','8878-4005','esteban.nunez@hotmail.com','45','Masculino',11);
/*!40000 ALTER TABLE `doctor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doctor_especialidad`
--

DROP TABLE IF EXISTS `doctor_especialidad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doctor_especialidad` (
  `id` int NOT NULL AUTO_INCREMENT,
  `doctor_id` int NOT NULL,
  `especialidad_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_doctor_especialidad_doctor_idx` (`doctor_id`),
  KEY `fk_doctor_especialidad_especialidad1_idx` (`especialidad_id`),
  CONSTRAINT `fk_doctor_especialidad_doctor` FOREIGN KEY (`doctor_id`) REFERENCES `doctor` (`id`),
  CONSTRAINT `fk_doctor_especialidad_especialidad1` FOREIGN KEY (`especialidad_id`) REFERENCES `especialidad` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doctor_especialidad`
--

LOCK TABLES `doctor_especialidad` WRITE;
/*!40000 ALTER TABLE `doctor_especialidad` DISABLE KEYS */;
INSERT INTO `doctor_especialidad` VALUES (1,1,1),(2,2,3),(3,3,4),(4,4,5),(5,5,6);
/*!40000 ALTER TABLE `doctor_especialidad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `especialidad`
--

DROP TABLE IF EXISTS `especialidad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `especialidad` (
  `id` int NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `especialidad`
--

LOCK TABLES `especialidad` WRITE;
/*!40000 ALTER TABLE `especialidad` DISABLE KEYS */;
INSERT INTO `especialidad` VALUES (1,'Cardiología'),(3,'Ginecología'),(4,'Pediatría'),(5,'Urología'),(6,'Ortopedia');
/*!40000 ALTER TABLE `especialidad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `persona`
--

DROP TABLE IF EXISTS `persona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `persona` (
  `id` int NOT NULL AUTO_INCREMENT,
  `identificacion` varchar(45) NOT NULL,
  `nombre_completo` varchar(50) NOT NULL,
  `apellido` varchar(45) NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `telefono` varchar(45) NOT NULL,
  `correo` varchar(45) NOT NULL,
  `edad` varchar(45) NOT NULL,
  `sexo` varchar(45) NOT NULL,
  `fecha_nacimiento` date NOT NULL,
  `tipo_sangre` varchar(45) DEFAULT NULL,
  `contacto_emergencia` text,
  `usuarios_idusuarios` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_persona_usuarios1_idx` (`usuarios_idusuarios`),
  CONSTRAINT `fk_persona_usuarios1` FOREIGN KEY (`usuarios_idusuarios`) REFERENCES `usuarios` (`idusuarios`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persona`
--

LOCK TABLES `persona` WRITE;
/*!40000 ALTER TABLE `persona` DISABLE KEYS */;
INSERT INTO `persona` VALUES (1,'109250123','María','Fernández Ramírez','Barrio Escalante, San José','8888-0001','maria.fernandez@gmail.com','28','Femenino','1997-05-12','A+','Luis Ramírez - 8888-7771',4),(2,'110150456','José','Martínez Quesada','Cartago centro','8888-0002','jose.martinez@gmail.com','35','Masculino','1989-03-22','O+','Ana Quesada - 8888-7772',5),(3,'208430789','Lucía','Vega Hernández','Heredia, San Francisco','8888-0003','lucia.vega@gmail.com','30','Femenino','1994-08-09','B+','Gabriela Hernández - 8888-7773',6),(5,'602910060','Marcela','Jiménez','Desamparados, Alajuela','83641655','marcemja@gmail.com','47','Mujer','1978-06-24','O+','Eladio Valverde -- 83641656',2);
/*!40000 ALTER TABLE `persona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tratamiento`
--

DROP TABLE IF EXISTS `tratamiento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tratamiento` (
  `id` int NOT NULL AUTO_INCREMENT,
  `descripcion` text,
  `consulta_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_tratamiento_consulta1` (`consulta_id`),
  CONSTRAINT `fk_tratamiento_consulta1` FOREIGN KEY (`consulta_id`) REFERENCES `consulta` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tratamiento`
--

LOCK TABLES `tratamiento` WRITE;
/*!40000 ALTER TABLE `tratamiento` DISABLE KEYS */;
INSERT INTO `tratamiento` VALUES (2,'Se le receta acetaminofen c/d 6 hrs 2.5 ml. \r\nGraniodin para aliviar los sintomas c/d 2 si es necesario por 1 día',5),(4,'Acetaminofen c/d 8hr 500mg\r\nClorferamida c/d 8hrs 10mg',2);
/*!40000 ALTER TABLE `tratamiento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `idusuarios` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `password` varchar(255) NOT NULL,
  `correo` varchar(100) NOT NULL,
  `tipo_usuario` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idusuarios`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'Eladio Valverde Chaves','148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756','eladiovch@gmail.com','Administrador'),(2,'Marcela Jimenez','148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756','marcemja@gmail.com','Paciente'),(3,'Admin','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','admin@gmail.com','Administrador'),(4,'María Fernández','148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756','maria.fernandez@gmail.com','Paciente'),(5,'José Martínez','148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756','jose.martinez@gmail.com','Paciente'),(6,'Lucía Vega','148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756','lucia.vega@gmail.com','Paciente'),(7,'Andrés Solano','148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756','andres.solano@clinicacr.com','Doctor'),(8,'Carolina Mora','148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756','carolina.mora@clinicacr.com','Doctor'),(9,'Felipe Castro','148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756','felipe.castro@clinicacr.com','Doctor'),(10,'Natalia Rojas','148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756','natalia.rojas@clinicacr.com','Doctor'),(11,'Esteban Núñez','148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756','esteban.nunez@clinicacr.com','Doctor'),(12,'Laura Brenes','148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756','laura.brenes@clinicacr.com','Secretaria'),(13,'Camila Jiménez','148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756','camila.jimenez@clinicacr.com','Secretaria'),(18,'Prueba','e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855','Prueba@gmail.com','Administrador'),(19,'doctor','148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756','doctor@clinica.cr','Doctor');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `vdoctor`
--

DROP TABLE IF EXISTS `vdoctor`;
/*!50001 DROP VIEW IF EXISTS `vdoctor`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vdoctor` AS SELECT 
 1 AS `ID`,
 1 AS `NOMBRE`,
 1 AS `APELLIDOS`,
 1 AS `IDENTIFICACION`,
 1 AS `DIRECCION`,
 1 AS `TELEFONO`,
 1 AS `CORREO_PERSONAL`,
 1 AS `USUARIO`,
 1 AS `ESPECIALIDAD`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vdoctorconsultas`
--

DROP TABLE IF EXISTS `vdoctorconsultas`;
/*!50001 DROP VIEW IF EXISTS `vdoctorconsultas`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vdoctorconsultas` AS SELECT 
 1 AS `ID`,
 1 AS `CONSECUTIVO`,
 1 AS `FECHA_CONSULTA`,
 1 AS `PRIORIDAD`,
 1 AS `NUM_PRIORIDAD`,
 1 AS `CODIGO_DOCTOR`,
 1 AS `CODIGO_PACIENTE`,
 1 AS `IDENTIFICACION`,
 1 AS `PACIENTE`,
 1 AS `DOCTOR`,
 1 AS `ESPECIALIDAD`,
 1 AS `EDAD_PACIENTE`,
 1 AS `SEXO_PACIENTE`,
 1 AS `CONSULTA_FINALIZADA`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vdoctorsecretaria`
--

DROP TABLE IF EXISTS `vdoctorsecretaria`;
/*!50001 DROP VIEW IF EXISTS `vdoctorsecretaria`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vdoctorsecretaria` AS SELECT 
 1 AS `ID`,
 1 AS `NOMBRE`,
 1 AS `APELLIDOS`,
 1 AS `ESPECIALIDAD`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vnuevosusuariosdoctores`
--

DROP TABLE IF EXISTS `vnuevosusuariosdoctores`;
/*!50001 DROP VIEW IF EXISTS `vnuevosusuariosdoctores`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vnuevosusuariosdoctores` AS SELECT 
 1 AS `ID`,
 1 AS `NOMBRE_USUARIO`,
 1 AS `CODIGO_USUARIO`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vnuevosusuariospacientes`
--

DROP TABLE IF EXISTS `vnuevosusuariospacientes`;
/*!50001 DROP VIEW IF EXISTS `vnuevosusuariospacientes`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vnuevosusuariospacientes` AS SELECT 
 1 AS `ID`,
 1 AS `NOMBRE_USUARIO`,
 1 AS `CODIGO_USUARIO`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vpaciente`
--

DROP TABLE IF EXISTS `vpaciente`;
/*!50001 DROP VIEW IF EXISTS `vpaciente`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vpaciente` AS SELECT 
 1 AS `ID`,
 1 AS `NOMBRE`,
 1 AS `APELLIDO`,
 1 AS `CEDULA`,
 1 AS `TELEFONO`,
 1 AS `USUARIO`,
 1 AS `CONSULTAS_PENDIENTES`,
 1 AS `CONSULTAS_FINALIZADAS`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vpacienteconsultas`
--

DROP TABLE IF EXISTS `vpacienteconsultas`;
/*!50001 DROP VIEW IF EXISTS `vpacienteconsultas`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vpacienteconsultas` AS SELECT 
 1 AS `ID`,
 1 AS `CONSECUTIVO`,
 1 AS `FECHA_CONSULTA`,
 1 AS `DOCTOR`,
 1 AS `ESPECIALIDAD`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vpacientesecretaria`
--

DROP TABLE IF EXISTS `vpacientesecretaria`;
/*!50001 DROP VIEW IF EXISTS `vpacientesecretaria`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vpacientesecretaria` AS SELECT 
 1 AS `ID`,
 1 AS `NOMBRE`,
 1 AS `APELLIDO`,
 1 AS `CEDULA`,
 1 AS `TELEFONO`,
 1 AS `CORREO_ELECTRONICO`,
 1 AS `EDAD`,
 1 AS `GENERO`,
 1 AS `USUARIO`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vusuarios`
--

DROP TABLE IF EXISTS `vusuarios`;
/*!50001 DROP VIEW IF EXISTS `vusuarios`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vusuarios` AS SELECT 
 1 AS `ID`,
 1 AS `NOMBRE_USUARIO`,
 1 AS `CODIGO_USUARIO`,
 1 AS `TIPO_USUARIO`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `vdoctor`
--

/*!50001 DROP VIEW IF EXISTS `vdoctor`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vdoctor` AS select `doctor`.`id` AS `ID`,`doctor`.`nombre_completo` AS `NOMBRE`,`doctor`.`apellido` AS `APELLIDOS`,`doctor`.`identificacion` AS `IDENTIFICACION`,`doctor`.`direccion` AS `DIRECCION`,`doctor`.`telefono` AS `TELEFONO`,`doctor`.`correo` AS `CORREO_PERSONAL`,`usuarios`.`correo` AS `USUARIO`,`especialidad`.`descripcion` AS `ESPECIALIDAD` from (((`doctor` join `usuarios` on((`doctor`.`usuarios_idusuarios` = `usuarios`.`idusuarios`))) join `doctor_especialidad` on((`doctor`.`id` = `doctor_especialidad`.`doctor_id`))) join `especialidad` on((`doctor_especialidad`.`especialidad_id` = `especialidad`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vdoctorconsultas`
--

/*!50001 DROP VIEW IF EXISTS `vdoctorconsultas`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vdoctorconsultas` AS select `consulta`.`id` AS `ID`,`consulta`.`numero` AS `CONSECUTIVO`,`consulta`.`fecha` AS `FECHA_CONSULTA`,`consulta`.`prioridad` AS `PRIORIDAD`,(case when (`consulta`.`prioridad` = 'ALTA') then 1 when (`consulta`.`prioridad` = 'MEDIA') then 2 else 3 end) AS `NUM_PRIORIDAD`,`usdoc`.`idusuarios` AS `CODIGO_DOCTOR`,`uspac`.`idusuarios` AS `CODIGO_PACIENTE`,`persona`.`identificacion` AS `IDENTIFICACION`,concat(`persona`.`nombre_completo`,' ',`persona`.`apellido`) AS `PACIENTE`,concat(`doctor`.`nombre_completo`,' ',`doctor`.`apellido`) AS `DOCTOR`,`especialidad`.`descripcion` AS `ESPECIALIDAD`,`persona`.`edad` AS `EDAD_PACIENTE`,`persona`.`sexo` AS `SEXO_PACIENTE`,(select count(0) from `tratamiento` where (`tratamiento`.`consulta_id` = `consulta`.`id`)) AS `CONSULTA_FINALIZADA` from ((((((`consulta` join `doctor` on((`doctor`.`id` = `consulta`.`doctor_id`))) join `doctor_especialidad` on((`doctor_especialidad`.`doctor_id` = `doctor`.`id`))) join `especialidad` on((`especialidad`.`id` = `doctor_especialidad`.`especialidad_id`))) join `usuarios` `usdoc` on((`doctor`.`usuarios_idusuarios` = `usdoc`.`idusuarios`))) join `persona` on((`persona`.`id` = `consulta`.`persona_id`))) join `usuarios` `uspac` on((`persona`.`usuarios_idusuarios` = `uspac`.`idusuarios`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vdoctorsecretaria`
--

/*!50001 DROP VIEW IF EXISTS `vdoctorsecretaria`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vdoctorsecretaria` AS select `doctor`.`id` AS `ID`,`doctor`.`nombre_completo` AS `NOMBRE`,`doctor`.`apellido` AS `APELLIDOS`,`especialidad`.`descripcion` AS `ESPECIALIDAD` from ((`doctor` join `doctor_especialidad` on((`doctor`.`id` = `doctor_especialidad`.`doctor_id`))) join `especialidad` on((`doctor_especialidad`.`especialidad_id` = `especialidad`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vnuevosusuariosdoctores`
--

/*!50001 DROP VIEW IF EXISTS `vnuevosusuariosdoctores`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vnuevosusuariosdoctores` AS select `usuarios`.`idusuarios` AS `ID`,`usuarios`.`nombre` AS `NOMBRE_USUARIO`,`usuarios`.`correo` AS `CODIGO_USUARIO` from `usuarios` where ((0 = (select count(0) from `doctor` where (`doctor`.`usuarios_idusuarios` = `usuarios`.`idusuarios`))) and (`usuarios`.`tipo_usuario` = 'Doctor')) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vnuevosusuariospacientes`
--

/*!50001 DROP VIEW IF EXISTS `vnuevosusuariospacientes`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vnuevosusuariospacientes` AS select `usuarios`.`idusuarios` AS `ID`,`usuarios`.`nombre` AS `NOMBRE_USUARIO`,`usuarios`.`correo` AS `CODIGO_USUARIO` from `usuarios` where ((0 = (select count(0) from `persona` where (`persona`.`usuarios_idusuarios` = `usuarios`.`idusuarios`))) and (`usuarios`.`tipo_usuario` = 'Paciente')) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vpaciente`
--

/*!50001 DROP VIEW IF EXISTS `vpaciente`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vpaciente` AS select `persona`.`id` AS `ID`,`persona`.`nombre_completo` AS `NOMBRE`,`persona`.`apellido` AS `APELLIDO`,`persona`.`identificacion` AS `CEDULA`,`persona`.`telefono` AS `TELEFONO`,`usuarios`.`correo` AS `USUARIO`,(select count(0) from (`consulta` left join `tratamiento` on((`consulta`.`id` = `tratamiento`.`consulta_id`))) where ((`consulta`.`persona_id` = `persona`.`id`) and (`tratamiento`.`consulta_id` is null))) AS `CONSULTAS_PENDIENTES`,(select count(0) from (`consulta` join `tratamiento` on((`consulta`.`id` = `tratamiento`.`consulta_id`))) where (`consulta`.`persona_id` = `persona`.`id`)) AS `CONSULTAS_FINALIZADAS` from (`persona` join `usuarios` on((`persona`.`usuarios_idusuarios` = `usuarios`.`idusuarios`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vpacienteconsultas`
--

/*!50001 DROP VIEW IF EXISTS `vpacienteconsultas`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vpacienteconsultas` AS select `consulta`.`id` AS `ID`,`consulta`.`numero` AS `CONSECUTIVO`,`consulta`.`fecha` AS `FECHA_CONSULTA`,concat(`doctor`.`nombre_completo`,' ',`doctor`.`apellido`) AS `DOCTOR`,`especialidad`.`descripcion` AS `ESPECIALIDAD` from (((`consulta` join `doctor` on((`doctor`.`id` = `consulta`.`doctor_id`))) join `doctor_especialidad` on((`doctor`.`id` = `doctor_especialidad`.`doctor_id`))) join `especialidad` on((`doctor_especialidad`.`especialidad_id` = `especialidad`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vpacientesecretaria`
--

/*!50001 DROP VIEW IF EXISTS `vpacientesecretaria`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vpacientesecretaria` AS select `persona`.`id` AS `ID`,`persona`.`nombre_completo` AS `NOMBRE`,`persona`.`apellido` AS `APELLIDO`,`persona`.`identificacion` AS `CEDULA`,`persona`.`telefono` AS `TELEFONO`,`persona`.`correo` AS `CORREO_ELECTRONICO`,`persona`.`edad` AS `EDAD`,`persona`.`sexo` AS `GENERO`,`usuarios`.`correo` AS `USUARIO` from (`persona` join `usuarios` on((`persona`.`usuarios_idusuarios` = `usuarios`.`idusuarios`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vusuarios`
--

/*!50001 DROP VIEW IF EXISTS `vusuarios`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vusuarios` AS select `usuarios`.`idusuarios` AS `ID`,`usuarios`.`nombre` AS `NOMBRE_USUARIO`,`usuarios`.`correo` AS `CODIGO_USUARIO`,`usuarios`.`tipo_usuario` AS `TIPO_USUARIO` from `usuarios` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-07-22 23:52:14
