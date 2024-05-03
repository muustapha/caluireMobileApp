import React, { useEffect, useState } from 'react';
import { View, Text } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

const Panier = () => {
  const [panier, setPanier] = useState([]);

  useEffect(() => {
    const recupererPanier = async () => {
      let panier = await AsyncStorage.getItem('panier');
      panier = panier != null ? JSON.parse(panier) : [];
      setPanier(panier);
    };

    recupererPanier();
  }, []);

  return (
    <View>
      {panier.map((produit, index) => (
        <Text key={index}>{produit.nomProduit}</Text>
      ))}
    </View>
  );
};

export default Panier;