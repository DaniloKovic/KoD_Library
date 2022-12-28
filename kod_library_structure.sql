CREATE DATABASE  IF NOT EXISTS `kod_library` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `kod_library`;
-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: localhost    Database: kod_library
-- ------------------------------------------------------
-- Server version	8.0.29

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
-- Table structure for table `autor`
--

DROP TABLE IF EXISTS `autor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `autor` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `imePrezime` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `autor_imePrezime` (`imePrezime`)
) ENGINE=InnoDB AUTO_INCREMENT=476 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `autorknjiga`
--

DROP TABLE IF EXISTS `autorknjiga`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `autorknjiga` (
  `knjigaId` int unsigned NOT NULL,
  `autorId` int unsigned NOT NULL,
  PRIMARY KEY (`knjigaId`,`autorId`),
  KEY `fk_KNJIGA_has_AUTOR_AUTOR1_idx` (`autorId`),
  KEY `fk_knjiga_has_autor_knjiga1_idx` (`knjigaId`) /*!80000 INVISIBLE */,
  CONSTRAINT `fk_knjiga_has_autor_autor1` FOREIGN KEY (`autorId`) REFERENCES `autor` (`Id`) ON UPDATE CASCADE,
  CONSTRAINT `fk_knjiga_has_autor_knjiga1` FOREIGN KEY (`knjigaId`) REFERENCES `knjiga` (`Id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `iznajmljuje`
--

DROP TABLE IF EXISTS `iznajmljuje`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `iznajmljuje` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `knjigaId` int unsigned NOT NULL,
  `nalogId` int unsigned NOT NULL,
  `datumOd` date NOT NULL,
  `datumDo` date NOT NULL,
  `isVracena` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `fk_iznajmljuje_knjiga1_idx` (`knjigaId`),
  KEY `fk_iznajmljuje_nalog1_idx` (`nalogId`),
  CONSTRAINT `fk_iznajmljuje_knjiga` FOREIGN KEY (`knjigaId`) REFERENCES `knjiga` (`Id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_iznajmljuje_nalog1` FOREIGN KEY (`nalogId`) REFERENCES `nalog` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `knjiga`
--

DROP TABLE IF EXISTS `knjiga`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `knjiga` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `naslov` varchar(255) NOT NULL,
  `godinaIzdanja` int unsigned NOT NULL DEFAULT '2000',
  `opis` varchar(255) DEFAULT 'opis',
  `kolicina` int unsigned NOT NULL DEFAULT '1',
  `dostupnaKolicina` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=75 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `knjigazanr`
--

DROP TABLE IF EXISTS `knjigazanr`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `knjigazanr` (
  `knjigaId` int unsigned NOT NULL,
  `zanrId` int unsigned NOT NULL,
  PRIMARY KEY (`knjigaId`,`zanrId`),
  KEY `fk_knjiga_has_zanr_zanr1_idx` (`zanrId`) /*!80000 INVISIBLE */,
  KEY `fk_knjiga_has_zanr_knjiga1_idx` (`knjigaId`) /*!80000 INVISIBLE */,
  CONSTRAINT `fk_knjiga_has_zanr_knjiga1` FOREIGN KEY (`knjigaId`) REFERENCES `knjiga` (`Id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_knjiga_has_zanr_zanr1` FOREIGN KEY (`zanrId`) REFERENCES `zanr` (`Id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `knjige_autori`
--

DROP TABLE IF EXISTS `knjige_autori`;
/*!50001 DROP VIEW IF EXISTS `knjige_autori`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `knjige_autori` AS SELECT 
 1 AS `Knjiga_Id`,
 1 AS `naslov`,
 1 AS `Autor_Id`,
 1 AS `imePrezime`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `nalog`
--

DROP TABLE IF EXISTS `nalog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nalog` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `imePrezime` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8_unicode_ci NOT NULL,
  `korisnickoIme` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8_unicode_ci NOT NULL,
  `lozinka` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8_unicode_ci NOT NULL,
  `brojTelefona` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8_unicode_ci NOT NULL,
  `eMail` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8_unicode_ci NOT NULL,
  `datumRegistracije` date NOT NULL,
  `tipNalogaId` int unsigned NOT NULL,
  `userTemplate` int unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `korisnickoIme_UNIQUE` (`korisnickoIme`),
  UNIQUE KEY `lozinka_UNIQUE` (`lozinka`),
  KEY `fk_nalog_tipNaloga1_idx` (`tipNalogaId`),
  CONSTRAINT `fk_nalog_tipNaloga1` FOREIGN KEY (`tipNalogaId`) REFERENCES `tipnaloga` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tipnaloga`
--

DROP TABLE IF EXISTS `tipnaloga`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipnaloga` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `naziv` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `zanr`
--

DROP TABLE IF EXISTS `zanr`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zanr` (
  `Id` int unsigned NOT NULL AUTO_INCREMENT,
  `naziv` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping routines for database 'kod_library'
--
/*!50003 DROP PROCEDURE IF EXISTS `insert_into_threeTables_autor_knjiga` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_into_threeTables_autor_knjiga`(in knjigaId int, in naslovKnjige varchar(255), in godinaIzdanja int, in opis varchar(255), in kolicina int, 
																				   in autorId int, in autorImePrezime varchar(45))
BEGIN
		DECLARE lastInsertedKnjigaId int;
		DECLARE lastInsertedAutorId int;
		
		IF knjigaId is null AND autorId is null THEN
			INSERT INTO knjiga (naslov, godinaIzdanja, opis, kolicina) VALUES(naslovKnjige, godinaIzdanja, opis, kolicina);
			SET lastInsertedKnjigaId = LAST_INSERT_ID();
            INSERT INTO autor (imePrezime) VALUES(autorImePrezime);
			SET lastInsertedAutorId = LAST_INSERT_ID();
			INSERT INTO autorknjiga (knjigaId, autorId) VALUES(lastInsertedKnjigaId, lastInsertedAutorId);
		ELSEIF knjigaId is not null AND autorId is not null THEN
			INSERT INTO autorknjiga (knjigaId, autorId) VALUES(knjigaId, autorId);
		ELSEIF knjigaId is not null AND autorId is null THEN
			INSERT INTO autor (imePrezime) VALUES(autorImePrezime);
			SET lastInsertedAutorId = LAST_INSERT_ID();
			INSERT INTO autorknjiga (knjigaId, autorId) VALUES(knjigaId, lastInsertedAutorId);
		ELSEIF knjigaId is null AND autorId is not null THEN
			INSERT INTO knjiga (naslov, godinaIzdanja, opis, kolicina) VALUES(naslovKnjige, godinaIzdanja, opis, kolicina);
			SET lastInsertedKnjigaId = LAST_INSERT_ID();
            INSERT INTO autorknjiga (knjigaId, autorId) VALUES(lastInsertedKnjigaId, autorId);
		END IF;
	END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `insert_into_threeTables_knjiga_zanr` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_into_threeTables_knjiga_zanr`(in knjigaId int, in naslovKnjige varchar(255), in godinaIzdanja int, in opis varchar(255), in kolicina int, 
													  in zanrId int, in zanrNaziv varchar(45))
BEGIN
		DECLARE lastInsertedKnjigaId int;
		DECLARE lastInsertedZanrId int;
		
		IF knjigaId is null AND zanrId is null THEN
			INSERT INTO knjiga (naslov, godinaIzdanja, opis, kolicina) VALUES(naslovKnjige, godinaIzdanja, opis, kolicina);
			SET lastInsertedKnjigaId = LAST_INSERT_ID();
            INSERT INTO zanr (naziv) VALUES(zanrNaziv);
			SET lastInsertedZanrId = LAST_INSERT_ID();
			INSERT INTO knjigazanr (knjigaId, zanrId) VALUES(lastInsertedKnjigaId, lastInsertedZanrId);
		ELSEIF knjigaId is not null AND zanrId is not null THEN
			INSERT INTO knjigazanr (knjigaId, zanrId) VALUES(knjigaId, zanrId);
		ELSEIF knjigaId is not null AND zanrId is null THEN
			INSERT INTO zanr (naziv) VALUES(zanrNaziv);
			SET lastInsertedZanrId = LAST_INSERT_ID();
			INSERT INTO knjigazanr (knjigaId, zanrId) VALUES(knjigaId, lastInsertedZanrId);
		ELSEIF knjigaId is null AND zanrId is not null THEN
			INSERT INTO knjiga (naslov, godinaIzdanja, opis, kolicina) VALUES(naslovKnjige, godinaIzdanja, opis, kolicina);
			SET lastInsertedKnjigaId = LAST_INSERT_ID();
            INSERT INTO knjigazanr (knjigaId, zanrId) VALUES(lastInsertedKnjigaId, zanrId);
		END IF;
	END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `insert_into_threeTables_procedure2` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_into_threeTables_procedure2`(in naslovKnjige varchar(255), in godinaIzdanja int, in opis varchar(255), in kolicina int, in autorImePrezime varchar(45), 
																				 out lastInsertedKnjigaId int, out lastInsertedAutorId int)
BEGIN
         INSERT INTO knjiga (naslov, godinaIzdanja, opis, kolicina) VALUES(naslovKnjige, godinaIzdanja, opis, kolicina);
		 SET lastInsertedKnjigaId = LAST_INSERT_ID();
         INSERT INTO autor (imePrezime) VALUES(autorImePrezime);
         SET lastInsertedAutorId = LAST_INSERT_ID();
         INSERT INTO autorknjiga (knjigaId, autorId) VALUES(lastInsertedKnjigaId, lastInsertedAutorId);
	END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `knjiga_zanr_procedure` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `knjiga_zanr_procedure`(in knjigaId int, in zanrId int)
BEGIN
	INSERT INTO knjigazanr (knjigaId, zanrId) VALUES(knjigaId, zanrId);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `knjige_autori`
--

/*!50001 DROP VIEW IF EXISTS `knjige_autori`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `knjige_autori` AS select `k`.`Id` AS `Knjiga_Id`,`k`.`naslov` AS `naslov`,`a`.`Id` AS `Autor_Id`,`a`.`imePrezime` AS `imePrezime` from ((`knjiga` `k` join `autorknjiga` `ak` on((`k`.`Id` = `ak`.`knjigaId`))) join `autor` `a` on((`a`.`Id` = `ak`.`autorId`))) */;
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

-- Dump completed on 2022-12-22 13:32:10
