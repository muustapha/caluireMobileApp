import React, { useState } from 'react';
import { View, Text, TextInput, Button, StyleSheet, Alert, Modal, TouchableOpacity, Image, } from 'react-native';
import Header from '../../components/header/Header';
import LinearGradient from 'react-native-linear-gradient';
import Arobase from '../../asset/icons/Arobase.svg';
import Cadena from '../../asset/icons/Cadena.svg';
import styles from './StylePageConnection';
import Icon from 'react-native-vector-icons/FontAwesome';
import Boutton from '../../components/boutton/Boutton';

const retour = require('../../asset/icons/flecheRetour.png');

const PageConnection = ({ navigation }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [modalVisible, setModalVisible] = useState(false);
  const [isPolicyModalVisible, setPolicyModalVisible] = useState(false);
  const [isEmailFocused, setIsEmailFocused] = useState(false);
  const [isPasswordFocused, setIsPasswordFocused] = useState(false);
  const [isPasswordHidden, setIsPasswordHidden] = useState(true);
  const [isLoading, setIsLoading] = useState(false); // Ajout d'un état de chargement

 const [clientId, setClientId] = useState(null); // Ajout d'un nouvel état pour stocker l'ID du client

const handlePress = () => {
  setIsLoading(true); // Début du chargement
  console.log("Envoi de la requête de connexion avec:", { adresseMail: email, motDePasse: password });
  fetch('http://10.0.2.2:5127/api/Clients/Login', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      adresseMail: email,
      motDePasse: password,
    }),
  })
  .then(response => response.json())
  .then(data => {
    console.log("Réponse de l'API:", data);
    if (data.success) {
      setClientId(data.clientId); // Stocker l'ID du client
      Alert.alert('Connexion réussie', 'Vous êtes maintenant connecté.');
      navigation.navigate('PageAcceuil', { clientId: data.clientId }); // Passer l'ID du client à la page d'accueil
    } else {
      Alert.alert('Erreur de connexion', data.message);
      navigation.navigate('ConnexionErreur');
    }
  })
  .catch(error => {
    console.error('Erreur:', error);
    Alert.alert('Erreur de réseau', 'Impossible de se connecter au serveur.');
    navigation.navigate('ConnexionErreur');
  });
}

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
<Boutton title='Se connecter' onPress={handlePress} />
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


export default PageConnection;