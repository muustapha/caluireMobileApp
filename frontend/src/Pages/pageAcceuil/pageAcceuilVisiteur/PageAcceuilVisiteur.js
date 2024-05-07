import React from 'react';
import { View, Text, StyleSheet, Image, TouchableOpacity } from 'react-native';
import Header from '../../../components/header/Header';
import LinearGradient from 'react-native-linear-gradient';
import Footer from '../../../components/Footer/Footer';

const retour = require('../../../asset/icons/flecheRetour.png');


const PageAcceuilVisiteur = ({ navigation }) => {
  return (
    <LinearGradient colors={['#ffffff', '#999999']} style={styles.container}>

      <Header icon={retour} title={"ACCEUIL"} navigation={navigation}/>
      <Text style={styles.title}>Veuillez sélectionner un type de produit</Text>
     <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('Telephone')}>
  <Text style={styles.buttonText}>Téléphones</Text>
</TouchableOpacity>
      <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('Ordinateur')}>
        <Text style={styles.buttonText}>Ordinateurs</Text>
      </TouchableOpacity>
      <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('Tablette')}>
        <Text style={styles.buttonText}>Tablettes</Text>
      </TouchableOpacity>
      <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('Accessoire')}>
        <Text style={styles.buttonText}>Accessoires</Text>
      </TouchableOpacity>
      <Footer />

    </LinearGradient>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'space-between',
    width: '100%',
    height: '100%',
  },
  title: {
    fontSize: 24,
    textAlign: 'center',
  },


  button: {
    backgroundColor: '#f8f8f8f8',
    padding: 10,
    margin: 10,
    borderRadius: 5,
  },
  buttonText: {
    color: '#000000',
    textAlign: 'center',
    fontSize: 30,
    fontWeight: 'bold',
  },
});

export default PageAcceuilVisiteur;