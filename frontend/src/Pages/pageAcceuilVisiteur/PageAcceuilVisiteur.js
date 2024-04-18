import React from 'react';
import { View, Text, Button, StyleSheet, Image } from 'react-native';
import Header from '../../components/header/header';

const cadieIcon = require('../../asset/icons/cadie.png');

const PageAcceuilVisiteur = () => {
  return (
    <View style={styles.container}>
      <Header />
      <Text style={styles.title}>Veuillez sélectionner un type de produit</Text>
      <Button title="Téléphones" onPress={() => { }} />
      <Button title="Ordinateurs" onPress={() => { }} />
      <Button title="Tablettes" onPress={() => { }} />
      <Button title="Accessoires" onPress={() => { }} />
      <View style={styles.footer}>
        <Image source={cadieIcon} style={styles.icon} />
        <Text>Panier</Text>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'space-between',
    padding: 16,
  },
  title: {
    fontSize: 24,
    textAlign: 'center',
  },
  footer: {
    alignItems: 'center',
  },
  icon: {
    width: 30,
    height: 30,
  },
});

export default PageAcceuilVisiteur;