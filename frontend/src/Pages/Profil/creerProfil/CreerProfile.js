import React, { useState } from 'react';
import { View, Text, Image, TouchableOpacity, Alert } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import Header from '../../../components/header/Header';
import Input from '../../../components/input/Input';
import styles from './StyleCreerProfile';
import Boutton from '../../../components/boutton/Boutton';
import IconNom from '../../../asset/icons/Nom.svg';
import IconAdresse from '../../../asset/icons/Adresse.svg';
import IconTelephone from '../../../asset/icons/Telephone.svg';

const retour = require('../../../asset/icons/flecheRetour.png');

const CreerProfile = ({ navigation }) => {
  const [nom, setNom] = useState('');
  const [prenom, setPrenom] = useState('');
  const [adresse, setAdresse] = useState('');
  const [Telephone, setTelephone] = useState('');

  const handleSubmit = () => {
    fetch('http://10.0.2.2:5127/api/Clients', { // Remplacez par l'URL de votre API
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        nom: nom,
        prenom: prenom,
        adresse: adresse,
        Telephone: Telephone,
      }),
    })
      .then((response) => response.json())
      .then((data) => {
        if (data.success) {
          Alert.alert('Profil créé avec succès');
          // Ici, vous pouvez naviguer vers une autre page si nécessaire
        } else {
          Alert.alert('Erreur', data.message);
        }
      })
      .catch((error) => {
        console.error('Erreur:', error);
      });
  };

  return (
    <LinearGradient colors={['#ffffff', '#999999']} style={styles.container}>
      <Header icon={retour} title={"Créer votre profil"} navigation={navigation} />
      <Text style={styles.text}>Veuillez remplir les champs suivants : </Text>
      <View style={styles.container0}>
        <Input
          value={nom}
          onChangeText={setNom}
          placeholder="Nom" 
          icon={<IconNom/>}
        />
        <Input
          value={prenom}
          onChangeText={setPrenom}
          placeholder="Prénom" 
          icon={<IconNom/>}
        />
        <Input
          value={adresse}
          onChangeText={setAdresse}
          placeholder="Adresse" 
          icon={<IconAdresse/>}
        />
        <Input
          value={Telephone}
          onChangeText={setTelephone}
          placeholder="Numéro de téléphone" 
          icon={<IconTelephone/>}
        />
      </View>

      <Boutton title="Enregistrer" onPress={handleSubmit} />

    </LinearGradient>
  );
};

export default CreerProfile;