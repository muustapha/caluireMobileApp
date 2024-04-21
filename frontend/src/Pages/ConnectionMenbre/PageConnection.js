import React, { useState } from 'react';
import { View, Text, TextInput, Button, StyleSheet, Alert, Modal, TouchableOpacity, Image, } from 'react-native';
import Header from '../../components/header/Header';
import LinearGradient from 'react-native-linear-gradient';
import Arobase from '../../asset/icons/Arobase.svg';
import Cadena from '../../asset/icons/Cadena.svg';
import styles from './StylePageConnection';
import Icon from 'react-native-vector-icons/FontAwesome';

const retour = require('../../asset/icons/flecheRetour.png');



const PageConnection = ({ navigation }) => { // Ajoutez 'navigation' ici
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [modalVisible, setModalVisible] = useState(false);
  const [isEmailFocused, setIsEmailFocused] = useState(false);
  const [isPasswordFocused, setIsPasswordFocused] = useState(false);
  const [isPasswordHidden, setIsPasswordHidden] = useState(true);

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
      <Header icon={retour} title={'HEUREUX DE VOUS REVOIR'} navigation={navigation} />
      <Text style={styles.title}>Connectez-vous</Text>
      <View style={styles.container0}>
       <View style={[styles.container, isEmailFocused ? styles.focused : {}]}>
  <Arobase style={styles.icon} />
  <TextInput
    style={styles.input}
    value={email}
    onChangeText={setEmail}
    placeholder="E-mail"
    onFocus={() => setIsEmailFocused(true)}
    onBlur={() => setIsEmailFocused(false)}
  />
</View>
<View style={[styles.container, isPasswordFocused ? styles.focused : {}]}>
  <Cadena style={styles.icon} />
  <TextInput
    style={styles.input}
    value={password}
    onChangeText={setPassword}
    placeholder="Password"
    secureTextEntry={isPasswordHidden}
    onFocus={() => setIsPasswordFocused(true)}
    onBlur={() => setIsPasswordFocused(false)}
  />
  <TouchableOpacity onPress={() => setIsPasswordHidden(!isPasswordHidden)}>
  <Icon style={styles.eye} name={isPasswordHidden ? 'eye' : 'eye-slash'} size={24} color="black" />

  </TouchableOpacity>
</View>
<View style={styles.container1}>  
        <TouchableOpacity onPress={() => setModalVisible(true)}>
          <Text style={styles.title1}>Mot de passe oublié ?</Text>
        </TouchableOpacity>
</View>
      </View>
   

      <View style={styles.container2}>
  <TouchableOpacity
    style={styles.button}
    onPress={handlePress}
  >
    <Text style={styles.buttonText}>Se connecter</Text>
  </TouchableOpacity></View>
 <View style={styles.containerText}>
 <Text style={[styles.title2]}>
    En vous connectant, vous acceptez la politique de confidentialité et les conditions d'utilisation.
  </Text>
  </View>
      <Modal
        animationType="slide"
        transparent={true}
        visible={modalVisible}
        onRequestClose={() => {
          setModalVisible(!modalVisible);
        }}
      >
        <View style={styles.centeredView}>
          <View style={styles.modalView}>
            <Text style={styles.modalText}>Entrez votre email pour réinitialiser votre mot de passe</Text>
            <TextInput
              style={styles.input}
              placeholder="Email"
            />
            <Button
              onPress={() => setModalVisible(!modalVisible)}
              title="Envoyer"
            />
          </View>
        </View>
      </Modal>
    </LinearGradient>
  );
};


export default PageConnection;