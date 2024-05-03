import React, { useState, useEffect } from 'react';
import { Picker } from '@react-native-picker/picker';
import { StyleSheet } from 'react-native';

const Trier = ({ produits, setProduits }) => {
  const [filtre, setFiltre] = useState('');

 useEffect(() => {
  let produitsTries = [...produits];
  if (filtre === 'marque') {
    produitsTries.sort((a, b) => a.marque.localeCompare(b.marque));
  } else if (filtre === 'prix croissant') {
    produitsTries.sort((a, b) => a.prix - b.prix);
  } else if (filtre === 'prix décroissant') {
    produitsTries.sort((a, b) => b.prix - a.prix);
  }

  // Vérifiez si les produits ont réellement changé
  if (JSON.stringify(produits) !== JSON.stringify(produitsTries)) {
    setProduits(produitsTries);
  }
}, [filtre, produits, setProduits]);

  return (
    <Picker selectedValue={filtre} onValueChange={(itemValue) => setFiltre(itemValue)}>
      <Picker.Item style={styles.picker} label="Trier par marque" value="marque" />
      <Picker.Item style={styles.picker} label="Trier par prix croissant" value="prix croissant" />
      <Picker.Item style={styles.picker} label="Trier par prix décroissant" value="prix décroissant" />
    </Picker>
  );
};

const styles = StyleSheet.create({
  picker: {
   
  },
});

export default Trier;