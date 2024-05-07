import React, {useState, useRef } from 'react';
import { View, TouchableOpacity, Text, StyleSheet, Image } from 'react-native';
import Boutton from '../boutton/AjouterPanier';
import AsyncStorage from '@react-native-async-storage/async-storage';
import AjouterPanier from '../boutton/AjouterPanier';


// Assurez-vous d'importer les données produits ou de les passer comme props au composant
const Produit = ({ item, navigation, produits, setProduits }) => {
const [panier, setPanier] = useState([]);
  const handlePress = () => {
    navigation.navigate('Focus', { item: item });
    
  };

  

  return (
 
      
      <View style={styles.container0}>
        <TouchableOpacity  onPress={handlePress}>
          <Image
            style={styles.image}
            source={{ uri: item.photographie }}
          />
          <Text style={styles.text}>{item.nomProduit}</Text>
          <Text style={styles.text}>{item.prix}€</Text>
          {/* <Text style={styles.text}>Quantité : {item.stock}</Text> */}
        </TouchableOpacity>
<AjouterPanier
  produit={{ nomProduit: item.nomProduit, prix: item.prix, photographie: item.photographie }}
  title="Ajouter"
/>
      </View>
  )
};

const styles = StyleSheet.create({
  image: {
    width: '80%',
    height: '40%',
    borderRadius: 15,
    marginVertical: 10,
  },
  container0: {
    padding: 5,
    width: '30%',
    height: '90%',
    marginLeft: 1.5,
    borderRadius: 15,
    backgroundColor: '#f8f8f8', 
  },
  text: {
    fontSize: 17,
    textAlign: 'center',
    fontWeight: 'bold',
  },
  
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  container1: { 
  
  },
});

export default Produit;
