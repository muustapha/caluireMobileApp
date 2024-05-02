import React, { useEffect, useState } from 'react';
import { View, StyleSheet,FlatList } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import Header from '../../components/header/Header';
import Footer from '../../components/Footer/Footer';
import Produit from '../../components/produits/produit';
import { Picker } from '@react-native-picker/picker';

const retour = require('../../asset/icons/flecheRetour.png');

const TelephoneVisiteur = ({ navigation }) => {
    const [telephones, setTelephones] = useState([]);

    useEffect(() => {
      fetch('http://10.0.2.2:5127/api/Produits/magasin/telephone')
        .then(response => response.json())
        .then(data => setTelephones(data))
        .catch(error => console.error('Erreur:', error));
    }, []);

    return (
      <LinearGradient colors={['#ffffff', '#999999']} style={styles.container}>
        <Header icon={retour} title="TELEPHONES" navigation={navigation} />
        <Picker/>
        <FlatList style={styles.container1}
      data={telephones}
      renderItem={({ item }) => (
        <Produit item={item} navigation={navigation} produits={telephones} setProduits={setTelephones} />
      )}
      keyExtractor={item => item.id}
      numColumns={4}
    />
        <Footer />
      </LinearGradient>
    );
};
    
const styles = StyleSheet.create({
  container: {
    width: '100%',
    height: '100%',  },
  container1: {
    flexDirection: 'row',
    flexWrap: 'wrap',
  },
});

export default TelephoneVisiteur;
