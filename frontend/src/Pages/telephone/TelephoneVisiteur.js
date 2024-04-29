import React, { useEffect, useState } from 'react';
import { View, Text, StyleSheet, Image,FlatList, TouchableOpacity} from 'react-native';
import Header from '../../components/header/Header';
import LinearGradient from 'react-native-linear-gradient';
import Footer from '../../components/Footer/Footer';
import { Picker } from '@react-native-picker/picker';

const retour = require('../../asset/icons/flecheRetour.png');

const PageAcceuilVisiteur = ({ navigation }) => {
    const [telephones, setTelephones] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);
    const [filtre, setFiltre] = useState('');

    useEffect(() => {
      fetch('http://10.0.2.2:5127/api/Produits/magasin/telephone')
        .then(response => response.json())
        .then(data => setTelephones(data))
        .catch(error => console.error('Erreur:', error));
    }, []);

    useEffect(() => {
      let telephonesTries = [...telephones];
      if (filtre === 'marque') {
        telephonesTries.sort((a, b) => a.marque.localeCompare(b.marque));
      } else if (filtre === 'prix croissant') {
        telephonesTries.sort((a, b) => a.prix - b.prix);
      } else if (filtre === 'prix décroissant') {
        telephonesTries.sort((a, b) => b.prix - a.prix);
      }
      setTelephones(telephonesTries);
    }, [filtre]);

    return (
      <LinearGradient colors={['#ffffff', '#999999']} style={styles.container}>
        <Header icon={retour} title={"TELEPHONES"} navigation={navigation}/>
        <View>
          <Picker selectedValue={filtre} onValueChange={(itemValue) => setFiltre(itemValue)}>
            <Picker.Item label="Trier par marque" value="marque" />
            <Picker.Item label="Trier par prix croissant" value="prix croissant" />
            <Picker.Item label="Trier par prix décroissant" value="prix décroissant" />
          </Picker>
          <FlatList
            data={telephones}
            keyExtractor={item => item.id ? item.id.toString() : ''}            renderItem={({ item }) => (
              <View>
                <Image source={{ uri: item.Photographie }} />
                <Text>{item.nomProduit}</Text>
                <Text>{item.prix}</Text>
              </View>
            )}
          />
        </View>
        <Footer />
      </LinearGradient>
    );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'space-between',
    width: '100%',
    height: '100%',
  },
  title: {
    fontSize: 24,
    textAlign: 'center',
  },
  button: {
    backgroundColor: '#f8f8f8f8',
    padding: 10,
    margin: 10,
    borderRadius: 5,
  },
  buttonText: {
    color: '#000000',
    textAlign: 'center',
    fontSize: 30,
    fontWeight: 'semi-bold',
  },
});

export default PageAcceuilVisiteur;