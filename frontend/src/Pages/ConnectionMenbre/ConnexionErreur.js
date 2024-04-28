import React, { useState } from 'react';
import { View, Text, TextInput, Button, StyleSheet, Alert, Modal, TouchableOpacity, Image, } from 'react-native';
import HeaderErreur from '../../components/header/HeaderErreur';
import LinearGradient from 'react-native-linear-gradient';
import Arobase from '../../asset/icons/Arobase.svg';
import Cadena from '../../asset/icons/Cadena.svg';
import styles from './StylePageConnection';
import Icon from 'react-native-vector-icons/FontAwesome';
import Boutton from '../../components/boutton/Boutton';

const retour = require('../../asset/icons/flecheRetour.png');



const ConnexionErreur = ({ navigation }) => { // Ajoutez 'navigation' ici
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [modalVisible, setModalVisible] = useState(false);
  const [isPolicyModalVisible, setPolicyModalVisible] = useState(false);
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
        AdresseMail: email, // Assurez-vous que ces clés correspondent à ce que votre API attend
        MotDePasse: password,
      }),
    })
      .then((response) => response.json())
      .then((data) => {
        if (data.success) {
          Alert.alert('Connexion réussie', 'Vous êtes maintenant connecté.');
          navigation.navigate('AccueilMembre'); // Assurez-vous que 'AccueilMembre' est le bon nom de la route
        } else {
          Alert.alert('Erreur de connexion', data.message);
          navigation.navigate('ErreurConnexion'); // Assurez-vous que 'ErreurConnexion' est le bon nom de la route
        }
      })
      .catch((error) => {
        console.error('Erreur:', error);
        Alert.alert('Erreur de réseau', 'Impossible de se connecter au serveur.');
        navigation.navigate('ErreurConnexion'); // Navigation en cas d'erreur réseau
      });
  };
  

  return (
    <LinearGradient colors={['#ffffff', '#999999']} style={styles.containerPage}>
      <HeaderErreur icon={retour} title={'oups!Adresse mail ou mot de passe incorrect.'} navigation={navigation} />
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
        <Boutton title = 'Se connecter'onPress={() => { }}/>
        </View>
      
        <View style={styles.containerText}>
        <TouchableOpacity onPress={() => setPolicyModalVisible(true)}>
          <Text style={[styles.title2]}>
            En vous connectant, vous acceptez la politique de confidentialité et les conditions d'utilisation.
          </Text>
        </TouchableOpacity>
      </View>
      <View style={styles.footer}>
        <TouchableOpacity
          style={styles.buttonFooter}
          onPress={() => navigation.navigate('CreerProfile')}
          >
          <Text style={styles.buttonTextFooter}>Créer votre compte</Text>
        </TouchableOpacity></View>

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
<TouchableOpacity
  style={styles.modalButton}
  onPress={() => {
    setModalVisible(!modalVisible);
    Alert.alert("Vérifiez votre boîte mail", "Dans quelques minutes, vous recevrez un mail de réinitialisation de votre mot de passe");
  }}
>
  <Text style={styles.buttonText}>Envoyer</Text>
</TouchableOpacity>
          </View>
        </View>
      </Modal>
      <Modal
        animationType="slide"
        transparent={true}
        visible={isPolicyModalVisible}
        onRequestClose={() => {
          setPolicyModalVisible(!isPolicyModalVisible);
        }}
      >
        <View style={styles.centeredView}>
  <View style={styles.modalView}>
    <Text style={styles.modalText}>Politique de confidentialité et conditions d'utilisation</Text>
    <TouchableOpacity
      style={styles.modalButton}
      onPress={() => setPolicyModalVisible(!isPolicyModalVisible)}
    >
      <Text style={styles.buttonText}>Fermer</Text>
    </TouchableOpacity>
  </View>
</View>
      </Modal>
    </LinearGradient>
  );
};


export default ConnexionErreur;