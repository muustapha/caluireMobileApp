import React, { useEffect, useState } from 'react';
import { View, Text, Image,  TouchableOpacity } from 'react-native';
import styles from './StylePremierePage';
import Header1 from '../../components/header/Header1';
import LinearGradient from 'react-native-linear-gradient';

const Logo = require('../../asset/images/logo.png');

const PremierePage = ({ navigation }) => {
  const [title, setTitle] = useState('');

  useEffect(() => {
    fetch('http://10.0.2.2:5127/api/Produits/flag/typeProduit')
      .then(response => response.json())
      .then(data => {
        const telephones = data.filter(item => item.type === 'telephone').length;
        const tablettes = data.filter(item => item.type === 'tablette').length;
        const ordinateurs = data.filter(item => item.type === 'ordinateur').length;
        setTitle(`Produits disponible : ${telephones} téléphones, ${tablettes} tablettes, ${ordinateurs} ordinateurs`);
      })
      .catch(error => console.error(error));
  }, []);

  return (
    <LinearGradient colors={['#ecf4f9', '#6aa6c5']} style={styles.container}>
      <Header1 title={title} />
     
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



export default PremierePage;