import React, { useEffect, useState, useRef } from 'react';
import { View, TouchableOpacity, Text, StyleSheet, Image } from 'react-native';
import { Picker } from '@react-native-picker/picker';

// Assurez-vous d'importer les données produits ou de les passer comme props au composant
const Produit = ({ item, navigation, produits, setProduits }) => {
  const [filtre, setFiltre] = useState('');
  const clickCount = useRef(0);

  const handlePress = () => {
    clickCount.current++;
    
  };

  

  return (
 
      
      <View style={styles.container0}>
        <TouchableOpacity onPress={handlePress}>
          <Image
            style={styles.image}
            source={{ uri: item.photographie }}
          />
          <Text style={styles.text}>{item.nomProduit}</Text>
          <Text style={styles.text}>{item.prix}</Text>
        </TouchableOpacity>
      </View>
  )
};

const styles = StyleSheet.create({
  image: {
    width: 100,
    height: 100,
    borderRadius: 15,
    marginVertical: 10,
  },
  container0: {
    padding: 5,
    marginVertical: 8,
    marginHorizontal: 8,
    width: '85%',
    height: '48%',
    marginLeft: 5,
    borderRadius: 15,
    backgroundColor: '#f8f8f8', // Corrigé la valeur de couleur
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
