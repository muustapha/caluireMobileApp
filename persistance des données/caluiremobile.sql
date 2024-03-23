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
DROP DATABASE IF EXISTS `caluiremobile`;
CREATE DATABASE IF NOT EXISTS `caluiremobile` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `caluiremobile`;

DROP TABLE IF EXISTS clients;
CREATE TABLE IF NOT EXISTS clients(
   Id_client INT AUTO_INCREMENT,
   nom VARCHAR(50),
   prénom VARCHAR(50),
   adresseMail VARCHAR(50),
   MotDepasse VARCHAR(50),
   abonnee BOOLEAN,
   adresse VARCHAR(50),
   telephone VARCHAR(20),
   PRIMARY KEY(Id_client)
);

DROP TABLE IF EXISTS employes;
CREATE TABLE IF NOT EXISTS employes(
   Id_employe INT AUTO_INCREMENT,
   nom VARCHAR(50),
   prenom VARCHAR(50),
   adresse VARCHAR(50),
   mail VARCHAR(50),
   dateEmbauche DATETIME,
   telephone VARCHAR(20),
   PRIMARY KEY(Id_employe)
);

DROP TABLE IF EXISTS typesProduits;
CREATE TABLE IF NOT EXISTS typesProduits(
   Id_typesProduit INT AUTO_INCREMENT,
   nomTypes VARCHAR(50),
   PRIMARY KEY(Id_typesProduit)
);

DROP TABLE IF EXISTS operations;
CREATE TABLE IF NOT EXISTS operations(
   Id_operation INT AUTO_INCREMENT,
   dateDemande DATETIME,
   dateRecuperation DATETIME,
   dateRetour DATETIME,
   dateVentes DATETIME,
   dateReparation DATETIME,
   adressePickup VARCHAR(50),
   status VARCHAR(50),
   serviceExpress BOOLEAN,
   montant DECIMAL(10,2),
   quantite INT,
   flag_reparation_pickUp_vente_ VARCHAR(50),
   PRIMARY KEY(Id_operation)
);

DROP TABLE IF EXISTS produits;
CREATE TABLE IF NOT EXISTS produits(
   Id_produit INT AUTO_INCREMENT,
   nomProduit VARCHAR(50),
   marque VARCHAR(50),
   prix DECIMAL(10,2),
   stock INT,
   flag_client_employe_ VARCHAR(50),
   photographie VARCHAR(255),
   Id_typesProduit INT NOT NULL,
   PRIMARY KEY(Id_produit),
   FOREIGN KEY(Id_typesProduit) REFERENCES typesProduits(Id_typesProduit)
);

DROP TABLE IF EXISTS transactionPaiments;
CREATE TABLE IF NOT EXISTS transactionPaiments(
   Id_transactionPaiment INT AUTO_INCREMENT,
   montant DECIMAL(10,2),
   dateTransaction DATETIME,
   status VARCHAR(50),
   methodePayement VARCHAR(50),
   Id_operation INT NOT NULL,
   PRIMARY KEY(Id_transactionPaiment),
   FOREIGN KEY(Id_operation) REFERENCES operations(Id_operation)
);

DROP TABLE IF EXISTS traduction;
CREATE TABLE IF NOT EXISTS traduction(
   Id_traduction INT AUTO_INCREMENT,
   clef VARCHAR(250),
   langue VARCHAR(10),
   valeur TEXT,
   PRIMARY KEY(Id_traduction)
);

DROP TABLE IF EXISTS tchat;
CREATE TABLE IF NOT EXISTS tchat(
   Id_client INT,
   Id_employe INT,
   NomUtilisateur VARCHAR(50),
   socketId VARCHAR(50),
   PRIMARY KEY(Id_client, Id_employe),
   FOREIGN KEY(Id_client) REFERENCES clients(Id_client),
   FOREIGN KEY(Id_employe) REFERENCES employes(Id_employe)
);

DROP TABLE IF EXISTS rendez_vous;
CREATE TABLE IF NOT EXISTS rendez_vous(
   Id_client INT,
   Id_operation INT,
   description TEXT,
   dateHeureRdv DATETIME,
   PRIMARY KEY(Id_client, Id_operation),
   FOREIGN KEY(Id_client) REFERENCES clients(Id_client),
   FOREIGN KEY(Id_operation) REFERENCES operations(Id_operation)
);

DROP TABLE IF EXISTS prise_en_charge;
CREATE TABLE IF NOT EXISTS prise_en_charge(
   Id_employe INT,
   Id_operation INT,
   PRIMARY KEY(Id_employe, Id_operation),
   FOREIGN KEY(Id_employe) REFERENCES employes(Id_employe),
   FOREIGN KEY(Id_operation) REFERENCES operations(Id_operation)
);

DROP TABLE IF EXISTS traiter;
CREATE TABLE IF NOT EXISTS traiter(
   Id_operation INT,
   Id_produit INT,
   PRIMARY KEY(Id_operation, Id_produit),
   FOREIGN KEY(Id_operation) REFERENCES operations(Id_operation),
   FOREIGN KEY(Id_produit) REFERENCES produits(Id_produit)
);
