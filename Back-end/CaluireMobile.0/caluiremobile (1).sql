-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : mer. 27 mars 2024 à 00:31
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

DELIMITER $$
--
-- Procédures
--
DROP PROCEDURE IF EXISTS `ConvertAllTablesToInnoDB`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ConvertAllTablesToInnoDB` ()   BEGIN
    DECLARE done INT DEFAULT 0;
    DECLARE tableName CHAR(64);
    DECLARE cur CURSOR FOR SELECT table_name FROM information_schema.tables WHERE table_schema = 'caluiremobile' AND engine = 'MyISAM';
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

    OPEN cur;

    read_loop: LOOP
        FETCH cur INTO tableName;

        IF done THEN
            LEAVE read_loop;
        END IF;

        SET @s = CONCAT('ALTER TABLE ', tableName, ' ENGINE=InnoDB;');
        PREPARE stmt FROM @s;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END LOOP;

    CLOSE cur;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `clients`
--

DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `Id_client` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) DEFAULT NULL,
  `prénom` varchar(50) DEFAULT NULL,
  `adresseMail` varchar(50) DEFAULT NULL,
  `login` varchar(50) DEFAULT NULL,
  `motDePasse` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `adresse` varchar(50) DEFAULT NULL,
  `telephone` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Id_client`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `employes`
--

DROP TABLE IF EXISTS `employes`;
CREATE TABLE IF NOT EXISTS `employes` (
  `Id_employe` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) DEFAULT NULL,
  `prenom` varchar(50) DEFAULT NULL,
  `adresse` varchar(50) DEFAULT NULL,
  `mail` varchar(50) DEFAULT NULL,
  `dateEmbauche` datetime DEFAULT NULL,
  `telephone` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Id_employe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `operations`
--

DROP TABLE IF EXISTS `operations`;
CREATE TABLE IF NOT EXISTS `operations` (
  `Id_operation` int NOT NULL AUTO_INCREMENT,
  `flagOperation` enum('reparation','pickUp','vente') CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'reparation',
  `dateDemande` datetime DEFAULT NULL,
  `dateRecuperation` datetime DEFAULT NULL,
  `dateRetour` datetime DEFAULT NULL,
  `dateReparation` datetime DEFAULT NULL,
  `dateVentes` datetime DEFAULT NULL,
  `adressePickup` varchar(50) DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `serviceExpress` tinyint(1) DEFAULT NULL,
  `montant` decimal(10,2) DEFAULT NULL,
  `quantite` int DEFAULT NULL,
  `description` text NOT NULL,
  PRIMARY KEY (`Id_operation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `prise_en_charges`
--

DROP TABLE IF EXISTS `prise_en_charges`;
CREATE TABLE IF NOT EXISTS `prise_en_charges` (
  `idPriseEnCharge` int NOT NULL AUTO_INCREMENT,
  `Id_employe` int NOT NULL,
  `Id_operation` int NOT NULL,
  PRIMARY KEY (`idPriseEnCharge`),
  KEY `Id_employe` (`Id_employe`),
  KEY `Id_operation` (`Id_operation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `produits`
--

DROP TABLE IF EXISTS `produits`;
CREATE TABLE IF NOT EXISTS `produits` (
  `Id_produit` int NOT NULL AUTO_INCREMENT,
  `FlagProduit` enum('Client','Magasin') CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `nomProduit` varchar(50) DEFAULT NULL,
  `marque` varchar(50) DEFAULT NULL,
  `prix` decimal(10,2) DEFAULT NULL,
  `stock` int DEFAULT NULL,
  `photographie` varchar(255) DEFAULT NULL,
  `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Id_typesProduit` int NOT NULL,
  PRIMARY KEY (`Id_produit`),
  KEY `Id_typesProduit` (`Id_typesProduit`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `rendez_vous`
--

DROP TABLE IF EXISTS `rendez_vous`;
CREATE TABLE IF NOT EXISTS `rendez_vous` (
  `idRendez-vous` int NOT NULL AUTO_INCREMENT,
  `Id_client` int NOT NULL,
  `Id_operation` int NOT NULL,
  `description` text,
  `dateHeureRdv` datetime DEFAULT NULL,
  PRIMARY KEY (`idRendez-vous`),
  KEY `Id_client` (`Id_client`),
  KEY `Id_operation` (`Id_operation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `socketio`
--

DROP TABLE IF EXISTS `socketio`;
CREATE TABLE IF NOT EXISTS `socketio` (
  `IdSocketio` int NOT NULL AUTO_INCREMENT,
  `Id_client` int NOT NULL,
  `Id_employe` int NOT NULL,
  `NomUtilisateur` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`IdSocketio`),
  KEY `Id_client` (`Id_client`),
  KEY `Id_employe` (`Id_employe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `traductions`
--

DROP TABLE IF EXISTS `traductions`;
CREATE TABLE IF NOT EXISTS `traductions` (
  `Id_traduction` int NOT NULL AUTO_INCREMENT,
  `clef` varchar(250) DEFAULT NULL,
  `langue` varchar(10) DEFAULT NULL,
  `valeur` text,
  PRIMARY KEY (`Id_traduction`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `traiters`
--

DROP TABLE IF EXISTS `traiters`;
CREATE TABLE IF NOT EXISTS `traiters` (
  `idTraiter` int NOT NULL AUTO_INCREMENT,
  `Id_operation` int NOT NULL,
  `Id_produit` int NOT NULL,
  PRIMARY KEY (`idTraiter`),
  UNIQUE KEY `Id_operation` (`Id_operation`),
  KEY `Id_produit` (`Id_produit`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `transactionspaiments`
--

DROP TABLE IF EXISTS `transactionspaiments`;
CREATE TABLE IF NOT EXISTS `transactionspaiments` (
  `Id_transactionPaiment` int NOT NULL AUTO_INCREMENT,
  `montant` decimal(10,2) DEFAULT NULL,
  `dateTransaction` datetime DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `methodePayement` varchar(50) DEFAULT NULL,
  `Id_operation` int NOT NULL,
  PRIMARY KEY (`Id_transactionPaiment`),
  KEY `Id_operation` (`Id_operation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `typesproduits`
--

DROP TABLE IF EXISTS `typesproduits`;
CREATE TABLE IF NOT EXISTS `typesproduits` (
  `Id_typesProduit` int NOT NULL AUTO_INCREMENT,
  `nomTypes` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id_typesProduit`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `prise_en_charges`
--
ALTER TABLE `prise_en_charges`
  ADD CONSTRAINT `prise_en_charges_ibfk_1` FOREIGN KEY (`Id_employe`) REFERENCES `employes` (`Id_employe`),
  ADD CONSTRAINT `prise_en_charges_ibfk_2` FOREIGN KEY (`Id_operation`) REFERENCES `operations` (`Id_operation`);

--
-- Contraintes pour la table `produits`
--
ALTER TABLE `produits`
  ADD CONSTRAINT `produits_ibfk_1` FOREIGN KEY (`Id_typesProduit`) REFERENCES `typesproduits` (`Id_typesProduit`);

--
-- Contraintes pour la table `rendez_vous`
--
ALTER TABLE `rendez_vous`
  ADD CONSTRAINT `rendez_vous_ibfk_1` FOREIGN KEY (`Id_client`) REFERENCES `clients` (`Id_client`),
  ADD CONSTRAINT `rendez_vous_ibfk_2` FOREIGN KEY (`Id_operation`) REFERENCES `operations` (`Id_operation`);

--
-- Contraintes pour la table `socketio`
--
ALTER TABLE `socketio`
  ADD CONSTRAINT `socketio_ibfk_1` FOREIGN KEY (`Id_client`) REFERENCES `clients` (`Id_client`),
  ADD CONSTRAINT `socketio_ibfk_2` FOREIGN KEY (`Id_employe`) REFERENCES `employes` (`Id_employe`);

--
-- Contraintes pour la table `traiters`
--
ALTER TABLE `traiters`
  ADD CONSTRAINT `traiters_ibfk_1` FOREIGN KEY (`Id_produit`) REFERENCES `produits` (`Id_produit`),
  ADD CONSTRAINT `traiters_ibfk_2` FOREIGN KEY (`Id_operation`) REFERENCES `operations` (`Id_operation`);

--
-- Contraintes pour la table `transactionspaiments`
--
ALTER TABLE `transactionspaiments`
  ADD CONSTRAINT `transactionspaiments_ibfk_1` FOREIGN KEY (`Id_operation`) REFERENCES `operations` (`Id_operation`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
