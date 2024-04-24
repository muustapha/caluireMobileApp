import React, { useState,useEffect } from 'react';
import { View, Text, Image, TouchableOpacity, Alert } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import Header from '../../../components/header/Header';
import Input from '../../../components/input/Input';
import styles from './StyleVerificationProfil';
import Boutton from '../../../components/boutton/Boutton';


const retour = require('../../../asset/icons/flecheRetour.png');

const VerificationProfile = ({ route,navigation }) => {
 
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
      </View>

      <Boutton title="verification" onPress={handleSubmit} />

    </LinearGradient>
  );
};

export default VerificationProfile;