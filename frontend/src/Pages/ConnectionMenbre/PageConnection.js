import React, { useState } from 'react';
import { View, TextInput, Button, StyleSheet, Alert, Image } from 'react-native';
import Header from '../../components/header/Header';
import LinearGradient from 'react-native-linear-gradient';

const retour = require('../../asset/icons/flecheRetour.png');
const PageConnection = ({ navigation }) => { // Ajoutez 'navigation' ici
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handlePress = () => {
    fetch('https://your-api-url.com/auth', { // Remplacez par l'URL de votre API
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        email: email,
        password: password,
      }),
    })
    .then((response) => response.json())
    .then((data) => {
      if (data.success) {
        Alert.alert('Connexion réussie');
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
    <LinearGradient colors={['#ffffff', '#999999']} style={styles.containerPage}>  
      <Header icon={retour} title={'HEUREUX DE VOUS REVOIR'} navigation={navigation}/>    
      <View style={styles.container}>
        <TextInput
          style={styles.input}
          value={email}
          onChangeText={setEmail}
          placeholder="Email"
        />
        <TextInput
          style={styles.input}
          value={password}
          onChangeText={setPassword}
          placeholder="Password"
          secureTextEntry
        />
        <Button title="Se connecter" onPress={handlePress} />
      </View>
    </LinearGradient>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    padding: 16,
  },
  input: {
    height: 40,
    borderColor: 'gray',
    borderWidth: 1,
    marginBottom: 10,
    paddingLeft: 8,
  },
  containerPage: {
    flex: 1,
    justifyContent: 'space-between',
    width: '100%',
    height: '100%',
  },
});

export default PageConnection;