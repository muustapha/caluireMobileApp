import React, { useEffect, useState } from 'react';
import { View, StyleSheet,FlatList } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import Header from '../../components/header/Header';
import Footer from '../../components/Footer/Footer';
import Produit from '../../components/produits/produit';
import Trier from '../../components/trier/Trier';

const retour = require('../../asset/icons/flecheRetour.png');

const OrdinateurVisiteur = ({ navigation }) => {
    const [ordinateurs, setordinateurs] = useState([]);

   useEffect(() => {
  fetch('http://10.0.2.2:5127/api/Produits/magasin/ordinateur')
    .then(response => {
      // Affichez la réponse brute pour le débogage
      console.log('Réponse brute:', response);

      // Vérifiez que le type de contenu est du JSON avant de parser
      const contentType = response.headers.get('content-type');
      if (contentType && contentType.indexOf('application/json') !== -1) {
        return response.json();
      } else {
        throw new TypeError("Oops, nous n'avons pas du JSON!");
      }
    })
    .then(data => {
      console.log('Données brutes:', data);
      setordinateurs(data);
    })
    .catch(error => console.error('Erreur:', error));
}, []);
    return (
      <LinearGradient colors={['#ffffff', '#999999']} style={styles.container}>
        <Header icon={retour} title="ORDINATEURS" navigation={navigation} />
 
        <Trier produits={ordinateurs} setProduits={setordinateurs} />
<View style={styles.container1}>
  <View style={styles.container2}>
  {ordinateurs.map((item, index) => {
    return (
      <Produit key={index.toString()} item={item} navigation={navigation} produits={ordinateurs} setProduits={setordinateurs} />
    );
  })}
</View>
</View>
        <Footer />
      </LinearGradient>
    );
};
    
const styles = StyleSheet.create({
  container: {
    width: '100%',
    height: '100%', 
  
  },

  container1: {

    width: '100%',
    height: '80%',
    flexDirection: 'row',
    flexWrap: 'wrap',
  },
    container2: {
    width: '100%',
    height: '37%',
    flexDirection: 'row',
    flexWrap: 'wrap',
    marginHorizontal  : 25,

    }
});

export default OrdinateurVisiteur;
