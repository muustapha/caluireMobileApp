import React, { useState } from 'react';
import { View, Text, TextInput, Button, StyleSheet, Alert, Modal, TouchableOpacity, Image, } from 'react-native';
import Header from '../../components/header/Header';
import LinearGradient from 'react-native-linear-gradient';
import Arobase from '../../asset/icons/Arobase.svg';
import Cadena from '../../asset/icons/Cadena.svg';

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

 

  return (
    <LinearGradient colors={['#ffffff', '#999999']} style={styles.containerPage}>
      <Header icon={retour} title={'HEUREUX DE VOUS REVOIR'} navigation={navigation} />
     
      <Text style={styles.title}>Numéro de téléphone : 0612875642</Text>
      <Text style={styles.title}>Adresse : </Text>
    </LinearGradient>
  );
};


export default PageConnection;