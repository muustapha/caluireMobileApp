import React from 'react';
import { View, Text, Image, StyleSheet, TouchableOpacity } from 'react-native';
import Header from '../../components/header/Header1';
import LinearGradient from 'react-native-linear-gradient';
import Header1 from '../../components/header/Header1';

const Logo = require('../../asset/images/logo.png');

const PremierePage = ({ navigation }) => {
  return (
    <LinearGradient colors={['#ecf4f9', '#6aa6c5']} style={styles.container}>
    
      <Header1  title="Produits disponible : 20 téléphones, 3 tablette, 2 ordinateur"  />
     
      <View style={styles.containerLogo}>
        <Image source={Logo} style={styles.logo} />
        <Text style={styles.title}>Caluire Mobile</Text>
      </View>
      <View style={styles.containerbouttons}>
        <Text style={styles.title1}>Bienvenue</Text>
        <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('PageAcceuillVisiteur')}>
          <Text style={styles.buttonText}>Visiter</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('PageConnection')}>
          <Text style={styles.buttonText}>Se Connecter</Text>
        </TouchableOpacity>
      </View>
      <View style={styles.footer}>
  <Text style={[styles.title2]}>
    En vous connectant, vous acceptez la politique de confidentialité et les conditions d'utilisation.
  </Text>
</View>
    </LinearGradient>
  );
};

const styles = StyleSheet.create({

  title1: {
    fontSize: 31,
    textAlign: 'center',
    color: '#fff',
    marginBottom: 20,
    fontFamily: 'times new roman',
  },
title: {
    fontSize: 31,
    textAlign: 'center',
    color: '#030303',
    marginBottom: 20,
    fontWeight: 'bold',
    fontFamily: 'times new roman',
  },

 logo: {
  backgroundColor: 'transparent',
  width: '75%',
  height: '75%',
  resizeMode: 'contain',
},
  button: {
    backgroundColor: '#fffdfd',
    padding: 10,
    margin: 10,
    borderRadius: 5,
  },
  buttonText: {
    color: '#030303',
    textAlign: 'center',
    fontSize: 20,
    fontWeight: 'bold',
    fontFamily: 'times new roman',
  },
  container: {
    flex: 1,
    justifyContent: 'flex-start',
    alignItems: 'center',

  },
  containerLogo: {
    alignItems: 'center',
    justifyContent: 'center',
    width: '100%', // Ajoutez une largeur
    height: '50%', // Ajoutez une hauteur
    marginBottom: 20,
    marginTop: 60,
  },
  containerbouttons: {
    justifyContent: 'center',
    flex: 0.75,
    backgroundColor: '#313131',
    width: '100%',
    
},
 title2: {
    textAlign: 'center',
    fontSize: 15,
    fontWeight: 'bold',
   alignContent: 'flex-end',
    color: '#fff',
fontFamily: 'popins',
paddingTop: 20,
},
  footer: {
   flex: 0.25,
    width: '100%',
    height : '0.5%',

    },

});

export default PremierePage;