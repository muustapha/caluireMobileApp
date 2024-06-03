import React, { useState, useRef } from 'react';
import { View, TouchableOpacity, Text, Image } from 'react-native';
import styles from './StyleProduit';
import Boutton from '../boutton/AjouterPanier';
import AsyncStorage from '@react-native-async-storage/async-storage';
import AjouterPanier from '../boutton/AjouterPanier';



const Produit = ({ item, navigation, produits, setProduits }) => {
  const [panier, setPanier] = useState([]);
  const handlePress = () => {
    navigation.navigate('Focus', { item: item });

  };

  return (


    <View style={styles.container0}>
      <TouchableOpacity onPress={handlePress}>
        <Image
          style={styles.image}
          source={{ uri: item.photographie }}
        />
        <Text style={styles.text}>{item.nomProduit}</Text>
        <Text style={styles.text}>{item.prix}€</Text>
      </TouchableOpacity>
      <AjouterPanier
        produit={{ nomProduit: item.nomProduit, prix: item.prix, photographie: item.photographie }}
        title="Ajouter"
      />
    </View>
  )
};



export default Produit;
