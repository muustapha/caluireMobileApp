import React, { useContext, useState } from 'react';
import { View, Text, Image, TouchableOpacity, } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import LinearGradient from 'react-native-linear-gradient';
import Header from '../../components/header/Header';
import Footer from '../../components/Footer/Footer';
import styles from './StylePanier';
import panierContext from './paniercontext';


const retour = require('../../asset/icons/flecheRetour.png');

const Panier = ({ navigation }) => {
  const {panier, setPanier} = useContext(panierContext);



  const supprimerDuPanier = async (index) => {
    setPanier(prevPanier => {
      let nouveauPanier = [...prevPanier];
      nouveauPanier.splice(index, 1);
      AsyncStorage.setItem('panier', JSON.stringify(nouveauPanier));
      return nouveauPanier;
    });
  };

  const total = panier.reduce((sum, item) => sum + (item.produit.prix * item.quantite), 0);
  const fraisDeLivraison = 5;
  const totalAvecLivraison = total + fraisDeLivraison;

  const validerCommande = () => {
    // Ici, vous pouvez appeler votre API pour valider la commande
  };

  return (
    <LinearGradient colors={['#ffffff', '#999999']} style={styles.container}>
      <Header icon={retour} title="PANIER" navigation={navigation} />

{panier.map((item, index) => (
  item.produit && (
    <View key={index} style={styles.produitContainer}>
      <Image
        style={styles.image}
        source={{ uri: item.produit.photographie }}
      />
      <Text style={styles.Text}>{item.produit.nomProduit}</Text>
      <Text style={styles.Text}>{item.produit.prix}€</Text>
      <Text style={styles.Text}>Quantité : {item.quantite}</Text> 
      <TouchableOpacity style={styles.boutton} onPress={() => supprimerDuPanier(index)}>
        <Text style={styles.textBoutton}>Supprimer</Text>
      </TouchableOpacity>
    </View>
  )
))}
      <View style={styles.container1}>
        <View style={styles.containertext}>
        <Text style={styles.Text}>Sous-Total : {total}€</Text></View>
        <View style={styles.containertext}>
        <Text style={styles.Text}>Livraison : {fraisDeLivraison}€</Text></View>
        <View style={styles.containertext}>
        <Text style={styles.Text}>Total : {totalAvecLivraison}€</Text></View></View>
      <TouchableOpacity style={styles.boutton0} onPress={validerCommande}>
        <Text style={styles.textBoutton}>Valider</Text>
      </TouchableOpacity>

    </LinearGradient>
  );
};

export default Panier;