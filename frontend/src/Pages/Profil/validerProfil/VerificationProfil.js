import React, { useState,useEffect } from 'react';
import { View, Text, Image, TouchableOpacity, Alert } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import Header from '../../../components/header/Header';
import Input from '../../../components/input/Input';
import styles from './StyleVerificationProfil';
import Boutton from '../../../components/boutton/Boutton';
import { useNavigation } from '@react-navigation/native';

const retour = require('../../../asset/icons/flecheRetour.png');

const VerificationProfile = () => {
  const navigation = useNavigation();
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = () => {
    // Exemple d'URL, remplacez par votre endpoint correct
    fetch('https://yourapi.com/verify', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        email: email,
        password: password,
      }),
    })
    .then(response => response.json())
    .then(data => {
      if (data.isValid) {
        // Si la validation est réussie, rediriger vers la page d'accueil des membres
        navigation.navigate('HomeMember');
      } else {
        // Si non validé, montrer une alerte et potentiellement rester sur la même page
        Alert.alert('Validation Échouée', 'Les informations fournies ne sont pas valides.');
        navigation.goBack();  // Pour retourner à la page précédente
      }
    })
    .catch(error => {
      console.error('Erreur:', error);
      Alert.alert('Erreur Réseau', 'Un problème est survenu lors de la connexion au serveur.');
    });
  };
 
  return (
    <LinearGradient colors={['#ffffff', '#999999']} style={styles.container}>
      <Header icon={retour} title={"Valider votre profil"} navigation={navigation} />
      <Text style={styles.text}>Veuillez remplir les champs suivants : </Text>
      <View style={styles.container0}>
        <Input
         
        />
        <Input
         
        />

     
        <Input
          
        />

        <Input
         
         />
         <Input
          
         />
 
      
         <Input
           
         />

      </View>

      <Boutton title="verification" onPress={handleSubmit} />

    </LinearGradient>
  );
};

export default VerificationProfile;