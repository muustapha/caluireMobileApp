import React, { useState,useEffect } from 'react';
import { View, Text, Image, TouchableOpacity, Alert } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import Header from '../../../components/header/Header';
import Input from '../../../components/input/Input';
import styles from './StyleEditerProfile';
import Boutton from '../../../components/boutton/Boutton';
import Arobase from '../../../asset/icons/Arobase.svg';
import Cadena from '../../../asset/icons/Cadena.svg';
import VerificationProfile from '../validerProfil/VerificationProfil';

const retour = require('../../../asset/icons/flecheRetour.png');

const EditerProfile = ({ route,navigation }) => {
  const [AdresseMail, setAdressemail] = useState('');
  const [MotDePasse, setMotDePasse] = useState('');
  const [ConfirmMotDePasse, setConfirmMotDePasse] = useState(''); // Ajoutez cette ligne
  const { clientId } = route.params; // Récupérer l'ID du client depuis les paramètres de navigation
  
  useEffect(() => {
    // Exemple d'utilisation de l'ID du client
    console.log('ID du client:', clientId);
  }, []);

  const handleSubmit = () => {
    if (MotDePasse !== ConfirmMotDePasse) {
      Alert.alert('Erreur', 'Les mots de passe ne correspondent pas. Veuillez entrer le même mot de passe.');
      return;
    }
  
    fetch(`http://10.0.2.2:5127/api/Clients/${clientId}`, { 
      method: 'Put', 
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        AdresseMail: AdresseMail, 
        MotDePasse: MotDePasse,
      }),
    })
    .then((response) => response.json())
    .then((data) => {
      if (data.success) {
        Alert.alert('Profil mis à jour avec succès');
        navigation.navigate(VerificationProfile); // Ou navigation vers une autre page
      } else {
        Alert.alert('Erreur', data.message);
      }
    })
    .catch((error) => {
      console.error('Erreur:', error);
      Alert.alert('Erreur Réseau', 'Un problème est survenu avec la demande réseau.');
    });
  };
  

  return (
    <LinearGradient colors={['#ffffff', '#999999']} style={styles.container}>
      <Header icon={retour} title={"Editer votre profil"} navigation={navigation} />
      <Text style={styles.text}>Veuillez remplir les champs suivants : </Text>
      <View style={styles.container0}>
        <Input
          value={AdresseMail}
          onChangeText={setAdressemail}
          placeholder="E-mail" 
          icon={<Arobase/>}
        />
        <Input
          value={MotDePasse}
          onChangeText={setMotDePasse}
          placeholder="Password" 
          icon={<Cadena/>}
        />

        <Text style={styles.text1}>Veuillez vérifier votre mot de passe : </Text>
        <Input
          value={ConfirmMotDePasse} // Modifiez cette ligne
          onChangeText={setConfirmMotDePasse} // Modifiez cette ligne
          placeholder="Confirmez le mot de passe" // Modifiez cette ligne
          icon={<Cadena/>}
        />
      </View>

      <Boutton title="Enregistrer" onPress={handleSubmit} />

    </LinearGradient>
  );
};

export default EditerProfile;