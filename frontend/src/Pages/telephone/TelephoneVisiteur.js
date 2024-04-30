import React, { useEffect, useState } from 'react';
import { View, Text, StyleSheet, Image,FlatList, TouchableOpacity} from 'react-native';
import Header from '../../components/header/Header';
import LinearGradient from 'react-native-linear-gradient';
import Footer from '../../components/Footer/Footer';
import { Picker } from '@react-native-picker/picker';

const retour = require('../../asset/icons/flecheRetour.png');
const image = require('../../asset/images/samsung s22.png');

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
            <Picker.Item style={styles.picker} label="Trier par marque" value="marque" />
            <Picker.Item style={styles.picker} label="Trier par prix croissant" value="prix croissant" />
            <Picker.Item style={styles.picker} label="Trier par prix décroissant" value="prix décroissant" />
          </Picker>
  <FlatList style={styles.container1}  
  data={telephones}
   numColumns={4}
  keyExtractor={(item, index) => item.id ? item.id.toString() : index.toString()}
  renderItem={({ item }) => (
    <View style={styles.container0}>
     <Image
  style={styles.image}
  source={item.Photographie ? { uri: item.Photographie } : image}
  onError={(e) => console.log('Erreur de chargement de l\'image:', e.nativeEvent.error)}
/>
      <Text style={styles.text}>{item.prix}</Text>
    </View>
  )}
/>
        </View>
        <Footer />
      </LinearGradient>
    );
};

const styles = StyleSheet.create({
container1: {

    height: '80%',
    flexDirection: 'row', 
    flexWrap: 'wrap',
    },

  image: {
    width: 100,
    height: 100,
    borderRadius: 15,
    marginVertical: 10,
  },
  
  container0: {
  padding: 5,
  marginVertical: 8,
  marginHorizontal: 8,
  width:'17%',
  height: '90%',
  marginLeft: 5,
   
    borderRadius: 15,
    backgroundColor: '#f8f8f8f8',
    
  },
  container: {
  
   
    width: '100%',
    height: '100%',
  },
  text: {
    fontSize: 17,
    textAlign: 'center',
    fontWeight: 'bold',
  },
  picker: {
    fontSize: 20,
    fontFamily: 'arial',
  },
});

export default PageAcceuilVisiteur;