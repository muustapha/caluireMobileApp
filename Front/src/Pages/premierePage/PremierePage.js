import React from 'react';
import { View, Text, Image, StyleSheet, TouchableOpacity } from 'react-native';
import Header from '../../components/header/header';

const Logo = ''; // Remplacez par le chemin de votre fichier de logo

const PremierePage = ({ navigation }) => {
  return (
    <View style={styles.container}>
      <Header />
      <Image source={Logo} style={styles.logo} />
      <Text style={styles.title}>Caluire Mobile</Text>
      <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('PageAcceuiVlisiteur')}>
        <Text style={styles.buttonText}>Visiter</Text>
      </TouchableOpacity>
      <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('PageConnection')}>
        <Text style={styles.buttonText}>Se Connecter</Text>
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
    container: {
      flex: 1,
      justifyContent: 'center',
      alignItems: 'center',
    },
    
    logo: {
      width: 100,
      height: 100,
    },
    button: {
      backgroundColor: '#841584',
      padding: 10,
      margin: 10,
      borderRadius: 5,
    },
    buttonText: {
      color: '#fff',
      textAlign: 'center',
    },
  });
  
  export default PremierePage;