import React, { useState, useEffect } from 'react';
import { View, Text, TouchableOpacity, Alert } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import Header from '../../../components/header/Header';
import Input from '../../../components/input/Input';
import styles from './StyleEditerProfile';
import Boutton from '../../../components/boutton/Boutton';
import Arobase from '../../../asset/icons/Arobase.svg';
import Cadena from '../../../asset/icons/Cadena.svg';
import VerificationProfile from '../validerProfil/VerificationProfil';

const retour = require('../../../asset/icons/flecheRetour.png');

const EditerProfile = ({ navigation, route }) => {
    const [AdresseMail, setAdresseMail] = useState('');
    const [MotDePasse, setMotDePasse] = useState('');
    const [ConfirmMotDePasse, setConfirmMotDePasse] = useState('');
    const clientId = route.params.clientId; // Récupérez l'ID du client à partir des paramètres de navigation

    useEffect(() => {
      // Simuler le chargement des données utilisateur
      setAdresseMail('exemple@domaine.fr');
    }, []);

    const handleSubmit = () => {
      if (MotDePasse !== ConfirmMotDePasse) {
          Alert.alert('Erreur', 'Les mots de passe ne correspondent pas. Veuillez entrer le même mot de passe.');
          return;
      }

      const userProfile = {
        AdresseMail,
        MotDePasse
      };

      fetch(`http://10.0.2.2:5127/api/Clients/${clientId}`, { 
        method: 'Put', 
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(userProfile),
      })
     .then(response => {
        console.log(response); // Vérification de l'état et du texte de la réponse
        if (!response.ok) {
            return response.text().then(text => {
                throw new Error('Network response was not ok: ' + response.statusText + ', Body: ' + text);
            });
        }
        // Vérifiez que le type de contenu de la réponse est 'application/json' avant de parser
        const contentType = response.headers.get('content-type');
        if (!contentType || !contentType.includes('application/json')) {
            throw new TypeError("La réponse n'est pas du JSON valide!");
        }
        return response.json(); // Parse en JSON seulement si le contenu est de type JSON
     })
     .then(data => {
        if (data.success) {
            // Appel pour envoyer un email de confirmation
            fetch(`http://10.0.2.2:5127/api/Clients/sendEmail/${clientId}`, {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
    },
    body: JSON.stringify({ AdresseMail }) // Assurez-vous que AdresseMail est défini
})
.then(response => {
    console.log(response); // Ajout du console.log ici
    return response.json();
})
.then(data => {
  if (data.success) {
      Alert.alert(
          'Email envoyé', 
          'Un email de confirmation a été envoyé à votre adresse.',
          [
              {text: 'OK', onPress: () => navigation.navigate('VerificationProfile')}
          ]
      );
    } else {
        Alert.alert('Erreur', data.message);
    }
})
            .catch(error => {
                console.error('Erreur:', error);
                Alert.alert('Erreur Réseau', 'Un problème est survenu avec la demande réseau.');
            });
        } else {
            Alert.alert('Erreur', data.message);
        }
     })
     .catch(error => {
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
            onChangeText={setAdresseMail}
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
            value={ConfirmMotDePasse}
            onChangeText={setConfirmMotDePasse}
            placeholder="Confirmez le mot de passe"
            icon={<Cadena/>}
          />
        </View>

        <Boutton title="Enregistrer" onPress={handleSubmit} />

      </LinearGradient>
    );
};

export default EditerProfile;