import React, { useState } from 'react'; // Ajoutez useState ici
import { View, Text, Image, TouchableOpacity } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import Header from '../../../components/header/Header';
import Input from '../../../components/input/Input';
import styles from './StyleCreerProfile';
import Boutton from '../../../components/boutton/Boutton';

const retour = require('../../../asset/icons/flecheRetour.png');

const CreerProfile = ({ navigation }) => {
    const [nom, setNom] = useState(''); // Ajoutez cette ligne
    const [prenom, setPrenom] = useState(''); // Ajoutez cette ligne
    const [adresse, setAdresse] = useState(''); // Ajoutez cette ligne
    const [numeroDeTelephone, setNumeroDeTelephone] = useState(''); // Ajoutez cette ligne

    return (
        <LinearGradient colors={['#ffffff', '#999999']} style={styles.container}>
            <Header icon={retour} title={"Créer votre profile"} navigation={navigation} />
            <View style={styles.container0}>
                <Input
                    value={nom}
                    onChangeText={setNom}
                    placeholder="Nom" // Assurez-vous que c'est une chaîne de caractères
                />
                <Input
                    vqlue={prenom}
                    onChangeText={setPrenom}
                    placeholder="Prénom" />

                <Input
                    value={adresse}
                    onChangeText={setAdresse}
                    placeholder="Adresse" />

                <Input
                    value={numeroDeTelephone}
                    onChangeText={setNumeroDeTelephone}
                    placeholder="Numéro de téléphone" />

            </View>

<Boutton title="Enregistrer" onPress={() => { }} />












        </LinearGradient>
    );
};

export default CreerProfile;