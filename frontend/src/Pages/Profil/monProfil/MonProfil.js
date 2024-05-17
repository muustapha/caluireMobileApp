import React, { useState, useEffect } from 'react';
import { View, Text, StyleSheet } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import HeaderDrawer from '../../../components/header/HeaderDrawer';

const CreerProfile = ({ navigation }) => {
    const [client, setClient] = useState({});

    useEffect(() => {
        fetch('http://10.0.2.2:5127/api/Clients/1') // Remplacez 1 par l'ID du client
            .then(response => response.json())
            .then(data => {
                setClient(data);
            })
            .catch(error => console.error('Erreur:', error));
    }, []);

    return (
        <LinearGradient colors={['#ffffff', '#999999']} style={styles.container}>
            <HeaderDrawer title="TELEPHONES" navigation={navigation} />
            <View style={styles.container1}>
                <Text style={styles.text}>Nom : {client.nom} </Text>
                <Text style={styles.text}>Prénom : {client.prénom} </Text>
                <Text style={styles.text}>Adresse : {client.adresse} </Text>
                <Text style={styles.text}>Numéro de téléphone : {client.telephone}</Text>
            </View>
        </LinearGradient>
    );
};

const styles = StyleSheet.create({
    container: {
        width: '100%',
        height: '100%',
    },
    container1: {
        width: '100%',
        height: '80%',
        flexDirection: 'row',
        flexWrap: 'wrap',
    },
    text: {
        fontSize: 16,
        color: '#000',
    },
});

export default CreerProfile;