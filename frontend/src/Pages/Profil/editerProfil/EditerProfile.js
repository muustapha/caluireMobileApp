import React, { useState,useEffect } from 'react';
import { View, Text, Image, TouchableOpacity, Alert } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import Header from '../../../components/header/Header';
import Input from '../../../components/input/Input';
import styles from './StyleEditerProfile';
import Boutton from '../../../components/boutton/Boutton';
import Arobase from '../../../asset/icons/Arobase.svg';
import Cadena from '../../../asset/icons/Cadena.svg';

const retour = require('../../../asset/icons/flecheRetour.png');

const EditerProfile = ({ route,navigation }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState(''); // Ajoutez cette ligne
  const { clientId } = route.params; // Récupérer l'ID du client depuis les paramètres de navigation
  
  useEffect(() => {
    // Exemple d'utilisation de l'ID du client
    console.log('ID du client:', clientId);
  }, []);

  const handleSubmit = () => {
    if (password !== confirmPassword) {
      Alert.alert('Erreur', 'Les mots de passe ne correspondent pas. Veuillez entrer le même mot de passe.');
      return;
    }
  
    fetch(`http://10.0.2.2:5127/api/Clients/${clientId}`, { 
      method: 'Put', 
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        AdresseMail: email, 
        MotDePasse: password,
      }),
    })
    .then((response) => response.json())
    .then((data) => {
      if (data.success) {
        Alert.alert('Profil mis à jour avec succès');
        navigation.goBack(); // Ou navigation vers une autre page
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
          value={email}
          onChangeText={setEmail}
          placeholder="E-mail" 
          icon={<Arobase/>}
        />
        <Input
          value={password}
          onChangeText={setPassword}
          placeholder="Password" 
          icon={<Cadena/>}
        />

        <Text style={styles.text1}>Veuillez vérifier votre mot de passe : </Text>
        <Input
          value={confirmPassword} // Modifiez cette ligne
          onChangeText={setConfirmPassword} // Modifiez cette ligne
          placeholder="Confirmez le mot de passe" // Modifiez cette ligne
          icon={<Cadena/>}
        />
      </View>

      <Boutton title="Enregistrer" onPress={handleSubmit} />

    </LinearGradient>
  );
};

export default EditerProfile;