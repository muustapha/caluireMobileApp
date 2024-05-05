import React, { useEffect, useState } from 'react';
import { View, Text, Image, TouchableOpacity, } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import LinearGradient from 'react-native-linear-gradient';
import Header from '../../components/header/Header';
import Footer from '../../components/Footer/Footer';
import styles from './StylePanier';

const retour = require('../../asset/icons/flecheRetour.png');

const Panier = ({ navigation }) => {
  const [panier, setPanier] = useState([]);

  useEffect(() => {
    const recupererPanier = async () => {
      let panier = await AsyncStorage.getItem('panier');
      panier = panier != null ? JSON.parse(panier) : [];
      setPanier(panier);
    };

    recupererPanier();
  }, []);

  const total = panier.reduce((sum, produit) => sum + produit.prix, 0);
  const fraisDeLivraison = 5; // Mettez ici le montant des frais de livraison
  const totalAvecLivraison = total + fraisDeLivraison;

  const supprimerDuPanier = async (index) => {
    let nouveauPanier = [...panier];
    nouveauPanier.splice(index, 1);
    setPanier(nouveauPanier);
    await AsyncStorage.setItem('panier', JSON.stringify(nouveauPanier));
  };

  const validerCommande = () => {
    // Ici, vous pouvez appeler votre API pour valider la commande
  };

  return (
    <LinearGradient colors={['#ffffff', '#999999']} style={styles.container}>
      <Header icon={retour} title="PANIER" navigation={navigation} />

      {panier.map((produit, index) => (
        <View key={index} style={styles.produitContainer}>
          <Image
            style={styles.image}
            source={{ uri: produit.photographie }}
          />
          <Text style={styles.Text}>{produit.nomProduit}</Text>
          <Text style={styles.Text}>{produit.prix}€</Text>
          <TouchableOpacity style={styles.boutton} onPress={() => supprimerDuPanier(index)}>
            <Text style={styles.textBoutton}>Supprimer</Text>
          </TouchableOpacity>
        </View>
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
<View style={styles.container2}>
      <Footer /></View>
    </LinearGradient>
  );
};

export default Panier;