-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : sam. 23 mars 2024 à 01:11
-- Version du serveur : 8.0.31
-- Version de PHP : 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `caluiremobile`
--
CREATE DATABASE IF NOT EXISTS `caluiremobile` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `caluiremobile`;

-- --------------------------------------------------------

--
-- Structure de la table `clients`
--

DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `Id_Client_` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) DEFAULT NULL,
  `prénom` varchar(50) DEFAULT NULL,
  `adresseMail` varchar(50) DEFAULT NULL,
  `MotDepasse` varchar(50) DEFAULT NULL,
  `abonnee` tinyint(1) DEFAULT NULL,
  `adresse` varchar(50) DEFAULT NULL,
  `telephone` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Id_Client_`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `employes`
--

DROP TABLE IF EXISTS `employes`;
CREATE TABLE IF NOT EXISTS `employes` (
  `Id_employes` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) DEFAULT NULL,
  `prenom` varchar(50) DEFAULT NULL,
  `adresse` varchar(50) DEFAULT NULL,
  `mail` varchar(50) DEFAULT NULL,
  `dateEmbauche` datetime DEFAULT NULL,
  `telephone` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Id_employes`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `prise_en_charge`
--

DROP TABLE IF EXISTS `prise_en_charge`;
CREATE TABLE IF NOT EXISTS `prise_en_charge` (
  `Id_employes` int NOT NULL,
  `Id_reparation_pickUp_Vente` int NOT NULL,
  PRIMARY KEY (`Id_employes`,`Id_reparation_pickUp_Vente`),
  KEY `Id_reparation_pickUp_Vente` (`Id_reparation_pickUp_Vente`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `produits`
--

DROP TABLE IF EXISTS `produits`;
CREATE TABLE IF NOT EXISTS `produits` (
  `Id_produits` int NOT NULL AUTO_INCREMENT,
  `nomProduit` varchar(50) DEFAULT NULL,
  `marque` varchar(50) DEFAULT NULL,
  `prix` decimal(10,2) DEFAULT NULL,
  `stock` int DEFAULT NULL,
  `Id_reparation_pickUp_Vente` int DEFAULT NULL,
  `Id_client_` int DEFAULT NULL,
  `Id_typesProduits` int DEFAULT NULL,
  PRIMARY KEY (`Id_produits`),
  KEY `Id_reparation_pickUp_Vente` (`Id_reparation_pickUp_Vente`),
  KEY `Id_client_` (`Id_client_`),
  KEY `Id_typesProduits` (`Id_typesProduits`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `rendez_vous`
--

DROP TABLE IF EXISTS `rendez_vous`;
CREATE TABLE IF NOT EXISTS `rendez_vous` (
  `Id_client_` int NOT NULL,
  `Id_reparation_pickUp_Vente` int NOT NULL,
  `description` text,
  `dateHeureRdv` datetime DEFAULT NULL,
  PRIMARY KEY (`Id_client_`,`Id_reparation_pickUp_Vente`),
  KEY `Id_reparation_pickUp_Vente` (`Id_reparation_pickUp_Vente`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `reparation_pickup_vente`
--

DROP TABLE IF EXISTS `reparation_pickup_vente`;
CREATE TABLE IF NOT EXISTS `reparation_pickup_vente` (
  `Id_reparation_pickUp_Vente` int NOT NULL AUTO_INCREMENT,
  `dateDemande` datetime DEFAULT NULL,
  `dateRecuperation` datetime DEFAULT NULL,
  `dateRetour` datetime DEFAULT NULL,
  `dateVentes` datetime DEFAULT NULL,
  `dateRéparation` datetime DEFAULT NULL,
  `adressePickup` varchar(50) DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `serviceExpress` tinyint(1) DEFAULT NULL,
  `montant` decimal(10,2) DEFAULT NULL,
  `quantite` int DEFAULT NULL,
  `flag` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id_reparation_pickUp_Vente`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `tchat`
--

DROP TABLE IF EXISTS `tchat`;
CREATE TABLE IF NOT EXISTS `tchat` (
  `Id_client_` int NOT NULL,
  `Id_employes` int NOT NULL,
  `NomUtilisateur` varchar(50) DEFAULT NULL,
  `socketId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id_client_`,`Id_employes`),
  KEY `Id_employes` (`Id_employes`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `traduction`
--

DROP TABLE IF EXISTS `traduction`;
CREATE TABLE IF NOT EXISTS `traduction` (
  `Id_traduction` int NOT NULL AUTO_INCREMENT,
  `clef` varchar(250) DEFAULT NULL,
  `langue` varchar(10) DEFAULT NULL,
  `valeur` text,
sv c  ) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `transactionpaiment`
--

DROP TABLE IF EXISTS `transactionpaiment`;
CREATE TABLE IF NOT EXISTS `transactionpaiment` (
  `Id_transactionPaiment` int NOT NULL AUTO_INCREMENT,
  `montant` decimal(10,2) DEFAULT NULL,
  `dateTransaction` datetime DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `methodePayement` varchar(50) DEFAULT NULL,
  `Id_reparation_pickUp_Vente` int DEFAULT NULL,
  PRIMARY KEY (`Id_transactionPaiment`),
  UNIQUE KEY `Id_reparation_pickUp_Vente` (`Id_reparation_pickUp_Vente`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `typesproduits`mù
ù
quantitefùc:DSV/
--

DROP TABLE IF EXISTS `typesproduits`;
CREATE TABLE IF NOT EXISTS `typesproduits` (
  `Id_typesProduits` int NOT NULL AUTO_INCREMENT,
  `nomTypes` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id_typesProduits`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
