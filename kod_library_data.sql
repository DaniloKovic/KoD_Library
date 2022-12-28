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
-- Dumping data for table `autor`
--

LOCK TABLES `autor` WRITE;
/*!40000 ALTER TABLE `autor` DISABLE KEYS */;
INSERT INTO `autor` VALUES (455,'aaaaaa'),(475,'Aleksandar Majić'),(47,'Aleksandar Tomić'),(15,'Aleksandra Smiljanić'),(21,'Antonije Đorđević'),(473,'Blagoje Bošković'),(28,'Branimir Nestorović'),(467,'Branislav boričić'),(463,'Branislav Mašić'),(9,'Branko Ćopić'),(40,'Branko Popović'),(14,'Danijel Mijić'),(23,'Dejan Tošić'),(18,'Dimitrije Hajduković'),(43,'Dobrica Ćosić'),(469,'Dragan Marinčić'),(20,'Dragan Olćan'),(17,'Dragan Vasiljević'),(474,'Draško Marinković'),(1,'Dražen Brđanin'),(462,'Evica Mratinić'),(12,'Fjodor Dostojevski'),(472,'Gojko Dimić'),(37,'Goran Banjac'),(19,'Gradimir Božilović'),(457,'Greg Perry'),(25,'Hans Breuer'),(458,'Ian Neil'),(459,'Igor Tartalja'),(8,'Ivo Andrić'),(13,'Jovan Surutka'),(454,'KOVkov'),(7,'Laslo Kraus'),(44,'Laza Lazarević'),(24,'Lazaro Dijaz'),(35,'Margaret Čejni'),(45,'Matija Bećković'),(34,'Mičio Kaku'),(451,'Mihailo Šćepanović'),(460,'Mihajlo Nikolić'),(38,'Mihajlo Pupin'),(41,'Mihajlo Vujović'),(46,'Milan Dimitrijević'),(4,'Milan Merkle'),(32,'Milan Pantić'),(11,'Milo Tomašević'),(456,'Miodrag Petrović'),(6,'Momir Ćelić'),(450,'Momo Kapor'),(27,'Novak Đokovic'),(33,'Oliver Stoun'),(464,'Pavle Milinčić'),(461,'Petar D. Mišić'),(10,'Petar Petrović Njegoš'),(468,'Rade Stankić'),(31,'Roj Medvedev'),(453,'RRR'),(2,'Slavko Marić'),(16,'Spasoje Tešić'),(39,'Stiven Hoking'),(42,'Tomas Man'),(22,'Viktor Pocajt'),(30,'Vladimir Ajdačić'),(465,'Vladimir Stojanović'),(29,'Vojislav Budo Gledić'),(26,'Wendell Odom'),(466,'Zoran Kadelburg'),(36,'Zoran Matić'),(5,'Zoran Mitrović'),(3,'Zoran Đurić');
/*!40000 ALTER TABLE `autor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `autorknjiga`
--

LOCK TABLES `autorknjiga` WRITE;
/*!40000 ALTER TABLE `autorknjiga` DISABLE KEYS */;
INSERT INTO `autorknjiga` VALUES (4,1),(49,1),(4,2),(49,2),(3,3),(8,3),(1,5),(2,6),(9,6),(10,6),(11,7),(12,7),(13,7),(62,7),(6,8),(17,8),(29,8),(14,9),(16,9),(7,10),(5,11),(27,12),(19,13),(24,14),(25,15),(21,16),(26,16),(21,17),(18,18),(22,19),(23,19),(22,20),(23,20),(22,21),(23,21),(58,23),(15,25),(30,26),(31,26),(32,26),(33,27),(34,28),(36,29),(37,29),(44,29),(45,29),(46,29),(47,29),(38,31),(39,32),(40,33),(28,34),(41,34),(42,34),(43,35),(35,36),(49,37),(50,38),(51,39),(52,39),(20,40),(48,41),(71,46),(71,47),(58,454),(58,455),(59,456),(60,457),(61,458),(62,459),(63,460),(64,461),(65,462),(66,463),(67,464),(67,465),(68,465),(69,465),(72,465),(67,466),(67,467),(70,468),(70,469),(73,472),(73,473),(74,474),(74,475);
/*!40000 ALTER TABLE `autorknjiga` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `iznajmljuje`
--

LOCK TABLES `iznajmljuje` WRITE;
/*!40000 ALTER TABLE `iznajmljuje` DISABLE KEYS */;
INSERT INTO `iznajmljuje` VALUES (9,58,2,'2022-11-23','2022-12-23',1),(10,4,2,'2022-11-23','2022-12-23',0),(12,12,2,'2022-12-11','2023-01-11',1),(13,8,4,'2022-12-11','2023-01-11',1),(14,9,2,'2022-12-14','2023-01-14',1),(15,12,10,'2022-12-22','2023-01-22',0),(16,59,10,'2022-12-22','2023-01-22',0);
/*!40000 ALTER TABLE `iznajmljuje` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `knjiga`
--

LOCK TABLES `knjiga` WRITE;
/*!40000 ALTER TABLE `knjiga` DISABLE KEYS */;
INSERT INTO `knjiga` VALUES (1,'Matematička analiza',2000,'matematika',1,1),(2,'Matematika 2',2000,'matematika',1,1),(3,'Java',2000,'programiranje',1,1),(4,'Baze podataka',2000,'Relacione baze podataka',1,0),(5,'Strukture podataka i algoritmi',2000,'programiranje',1,1),(6,'Na Drini ćuprija',2000,'roman',1,1),(7,'Gorski vijenac',2000,'poema',1,1),(8,'Mrežno i distribuirano programiranje',2000,'programiranje',1,1),(9,'Numerička matematika',2000,'matematika',1,1),(10,'Linearna alebra',2000,'matematika',1,1),(11,'Programski jezik C',2000,'Programski jezik C sa rešenim zadacima',1,1),(12,'Programski jezik Java',2000,'Programski jezik Java sa rešenim zadacima',2,1),(13,'Rešeni zadaci iz programskog jezika C',2000,'Rešeni zadaci iz programskog jezika C',1,1),(14,'Doživljaji mačka Toše',1954,'opis',1,1),(15,'Fizika',2007,'Atlas fizike',1,1),(16,'Pod Grmečom',1938,'opis',1,1),(17,'Travnička hronika',1954,'opis',1,1),(18,'Matematika 1',1995,'opis',1,1),(19,'Osnovi elektrotehnike Elektromagnetizam',2003,'opis',1,1),(20,'Osnovi elektrotehnike 1',1976,'opis',1,1),(21,'Zbirka zadataka iz digitalne elektronike',1981,'opis',1,1),(22,'Zbirka zadataka iz osnova elektrotehnike',2009,'Elektrostatika, prvi deo.  Izdavači: Akademska misao, Elektrotehnički fakultet Beograd.',1,1),(23,'Zbirka zadataka iz osnova elektrotehnike',2009,'Stalne struje, drugi deo',1,1),(24,'Uvod u veb programiranje',2019,'HTML, CSS i JavaScript',1,1),(25,'Osnove i primena interneta',2015,'opis',1,1),(26,'Internet poslovanje posle 2000.',2000,'Kako zaraditi uz pomoć interneta',1,1),(27,'Braća Karamazovi',1880,'opis',1,1),(28,'Fizika budućnosti',1954,'opis',1,1),(29,'Prokleta avlija',2000,'pripovjetka Ive Andrića',1,1),(30,'CCNA Routing and Switching',2019,'Vodič za dobijanje sertifikata',1,1),(31,'CCNA 200-301 Volume 1',2020,'Official Cert Guide, Advance your IT career',1,1),(32,'CCNA 200-301 Volume 2',2020,'Official Cert Guide, Advance your IT career',1,1),(33,'Serviraj za pobedu',2013,'opis',1,1),(34,'Između dva sveta',2021,'opis',1,1),(35,'Top 50 lokacija Bosne i Hercegovine',2020,'opis',1,1),(36,'Matematički priručnik',2012,'opis',1,1),(37,'Mihajlo Pupin - život i delo',2009,'opis',1,1),(38,'Putin - povratak Rusije',2007,'opis',1,1),(39,'Uvod u Ajnštajnovu teoriju gravitacije',2015,'opis',1,1),(40,'Intervjui sa Vladimirom Putinom',2017,'opis',1,1),(41,'Budućnost uma',2014,'Nauka u uzbudljivoj potrazi za naprednijim, savršenijim i moćnijim umom',1,1),(42,'Fizika budućnosti',2011,'Kako će nauka uticati na ljudsku sudbinu i naš svakodnevni život u 2100. godini',1,1),(43,'Tesla - čovek izvan vremena',1998,'opis',1,1),(44,'Mihajlo Petrović Alas',2016,'Knjiga o Alasu',1,1),(45,'Ruđer Bošković',2017,'Oči ka zvijezdama',1,1),(46,'Jovan Cvijić - geograf nacionalnog duha',2018,'opis',1,1),(47,'Leonardo Da Vinči - univerzalni genije renesanse',2019,'opis',1,1),(48,'Svjedočenja i rasuđivanja',2012,'opis',1,1),(49,'Projektovanje i eksploatacija baza podataka kroz primjere',2018,'opis',1,1),(50,'Sa pašnjaka do naučenjaka',1929,'opis',1,1),(51,'Kratka povest vremena',2010,'opis',1,1),(52,'Na plećima divova',2011,'opis',1,1),(58,'KnjigaTestTest',2014,'Neki novi opis',3,3),(59,'Matematička lektira - Dosjetke i trikovi',2006,'Matematička lektira - Dosjetke i trikovi. Zbirka od 110 kratkih zadataka iz raznih oblasti elementarne matematike.',1,0),(60,'Osnove programiranja',2002,'Naučite osnove programiranja za 24 sata. Prateći CD-ROM sadrži Basic i Java programske alate.',1,1),(61,'CompTIA Security+: SY0-601',2022,'Vodič za sertifikaciju. Više od 600 praktičnih pitanja sa detaljim objašnjenjima i dva testa za procenu stečenog znanja.',1,1),(62,'Zbirka zadataka iz projektovanja softvera',2013,'Zbirka zadataka iz projektovanja softvera',1,1),(63,'Višnja i trešnja',2000,'Poljoprivredna apoteka - Ministarstvo za poljoprivredu, šumarstvo i vodoprivredu Republike Srbije',1,1),(64,'Jabuka',2000,'Poljoprivredna biblioteka',1,1),(65,'Kruška',2000,'Neki opis',1,1),(66,'Strategijski menadžment',2021,'Strategijski menadžment: osnove, proces i koncepti',1,1),(67,'Matematika',2005,'Matematika za 1. razred gimnazije i stručnih škola u kojima se matematika predaje četiri časa nedjeljno. Izdavač: Zavod za udžbenike i nastavna sredstva Istočno Sarajevo.',1,1),(68,'Zbirka rešenih zadataka iz matematike za VIII razred',2005,'Zbirka rešenih zadataka iz matematike za VIII razred (Drugo - doterano izdanje). Izdavač: Matematiskop - Beograd',1,1),(69,'Plus VIII',2005,'Zbirka rešenih zadataka iz matematike za dodatnu nastavu. Izdavač: Matematiskop - Beograd.',1,1),(70,'Računarstvo i Informatika',2002,'Računarstvo i Informatika za treći razred gimnazije. Izdavač: Zavod za udžbenike i nastavna sredstva Srpsko Sarajevo.',2,2),(71,'Astronomija',2002,'Astronomija za 4. razred gimnazije prirodno-matematičkog smjera. Izdavač: Zavod za udžbenike i nastavna sredstva Srpsko Sarajevo.',1,1),(72,'Matematiskop 7',2007,'Matematika za maturante i srednjoškolce. Priprema za upis na fakultet. Osmo izdanje. Izdavač: IP Matematiskop - Beograd.',1,1),(73,'Fizika B',2000,'Fizika B u jednačinama i slikama. Ovaj priručnik odgovara zbirci zadataka fizike za šesti, sedmi i osmi razred osnovne škole. Izdavač: Naša knjiga Beograd.',1,1),(74,'Stanovništvo Republike Srpske',2018,'Stanovništvo Republike Srpske - demografski faktori i pokazatelji. Naučna monografija. Izdavač: Prirodno-matematički fakultet u Banjoj Luci.',1,1);
/*!40000 ALTER TABLE `knjiga` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `knjigazanr`
--

LOCK TABLES `knjigazanr` WRITE;
/*!40000 ALTER TABLE `knjigazanr` DISABLE KEYS */;
INSERT INTO `knjigazanr` VALUES (1,9),(2,9),(3,11),(4,10),(4,11),(5,11),(6,13),(7,8),(8,11),(9,9),(10,9),(11,10),(11,11),(12,10),(12,11),(13,10),(13,11),(14,15),(15,20),(16,15),(17,13),(18,9),(19,20),(19,21),(20,21),(20,22),(21,21),(21,22),(22,20),(22,21),(23,20),(23,21),(24,10),(24,11),(25,10),(25,11),(26,10),(26,23),(27,7),(27,13),(28,20),(29,15),(29,20),(30,12),(31,12),(32,12),(33,24),(34,6),(34,24),(35,25),(35,26),(36,9),(37,6),(37,20),(38,27),(38,29),(39,20),(40,29),(41,3),(41,20),(42,3),(42,20),(43,20),(43,28),(44,28),(45,28),(46,28),(47,27),(47,28),(48,27),(49,10),(49,11),(50,6),(50,20),(51,3),(51,20),(52,6),(52,20),(58,17),(58,18),(59,9),(60,10),(60,11),(61,10),(61,11),(62,10),(62,11),(63,30),(64,30),(65,30),(66,31),(67,9),(68,9),(69,9),(70,10),(70,11),(71,32),(72,9),(73,20),(74,25);
/*!40000 ALTER TABLE `knjigazanr` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `nalog`
--

LOCK TABLES `nalog` WRITE;
/*!40000 ALTER TABLE `nalog` DISABLE KEYS */;
INSERT INTO `nalog` VALUES (1,'Danilo Ković','dak','dakdak22','065065065','danilo@gmail.com','2022-04-01',2,3),(2,'Ana Mijić','ana','anaana11!!','065065065','ana@gmail.com','2022-04-01',1,3),(3,'Dragoljub Ković','tata','tata','065065065','tata@gmail.com','2022-04-01',2,1),(4,'Rada Ković','mama','mama','065065065','mama@gmail.com','2022-04-01',1,1),(5,'Dragica Ković','keka','keka','065065065','keka@gmail.com','2022-04-01',1,1),(6,'Nemanja Adžić','neco','neco','065065065','neco@gmail.com','2022-04-01',1,1),(7,'Nataša Ković','nata','nata','065065065','nata@gmail.com','2022-04-01',1,1),(8,'Dušica Ković','duša','duša','065065065','dusa@gmail.com','2022-04-01',1,1),(9,'Petar Petrović','PeraPera','perapera45','065555333','pera@gmail.com','2022-09-25',1,1),(10,'Mirko','mirkec77','mirkomirko77','065442442','mirkomirko@gmail.com','2022-12-21',1,1),(11,'Marko','Markovic','marko333#','065555333','marko_bl@hotmail.com','2022-12-22',1,0);
/*!40000 ALTER TABLE `nalog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tipnaloga`
--

LOCK TABLES `tipnaloga` WRITE;
/*!40000 ALTER TABLE `tipnaloga` DISABLE KEYS */;
INSERT INTO `tipnaloga` VALUES (1,'korisnik'),(2,'zaposleni');
/*!40000 ALTER TABLE `tipnaloga` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `zanr`
--

LOCK TABLES `zanr` WRITE;
/*!40000 ALTER TABLE `zanr` DISABLE KEYS */;
INSERT INTO `zanr` VALUES (1,'Romantika'),(2,'Misterija'),(3,'Naučna fantastika'),(4,'Triler'),(5,'Horor'),(6,'Autobiografija'),(7,'Drama'),(8,'Poema'),(9,'Matematika'),(10,'Informatika'),(11,'Programiranje'),(12,'Računarske mreže'),(13,'Roman'),(14,'Kriminalistika'),(15,'Priče'),(17,'KovŽanr'),(18,'žžžž'),(20,'Fizika'),(21,'Elektrotehnika'),(22,'Elektronika'),(23,'Biznis'),(24,'Zdravlje i Ishrana'),(25,'Geografija '),(26,'Turizam'),(27,'Istorija'),(28,'Biografija'),(29,'Politika'),(30,'Poljoprivreda'),(31,'Menadžment'),(32,'Astronomija'),(33,'Muzika'),(34,'Gitara');
/*!40000 ALTER TABLE `zanr` ENABLE KEYS */;
UNLOCK TABLES;

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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-22 13:31:55
