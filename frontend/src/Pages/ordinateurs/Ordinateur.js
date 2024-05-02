import React, { useEffect, useState, useRef } from 'react';
import { View, TouchableOpacity, Text, StyleSheet, Image, FlatList, Dimensions } from 'react-native';
import Header from '../../components/header/Header';
import LinearGradient from 'react-native-linear-gradient';
import Footer from '../../components/Footer/Footer';
import { Picker } from '@react-native-picker/picker';
import ImageView from 'react-native-image-pan-zoom';

const retour = require('../../asset/icons/flecheRetour.png');

const OrdinateursVisiteur = ({ navigation }) => {
    const [ordinateurs, setOrdinateurs] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);
    const [filtre, setFiltre] = useState('');
    const clickCount = useRef(0);
    const [zoomed, setZoomed] = useState(false);

    useEffect(() => {
      fetch('http://10.0.2.2:5127/api/Produits/magasin/Ordinateurs')
        .then(response => response.json())
        .then(data => setOrdinateurs(data))
        .catch(error => console.error('Erreur:', error));
    }, []);

    useEffect(() => {
      let ordinateursTries = [...ordinateurs];
      if (filtre === 'marque') {
        ordinateursTries.sort((a, b) => a.marque.localeCompare(b.marque));
      } else if (filtre === 'prix croissant') {
        ordinateursTries.sort((a, b) => a.prix - b.prix);
      } else if (filtre === 'prix décroissant') {
        ordinateursTries.sort((a, b) => b.prix - a.prix);
      }
      setOrdinateurs(ordinateursTries);
    }, [filtre]);

    const handlePress = () => {
      clickCount.current++;
      setTimeout(() => {
        if (clickCount.current > 1) {
          navigation.navigate('Focus');
        } else {
          setZoomed(true);
        }
        clickCount.current = 0;
      }, 300); // Délai pour le double clic
    };
    
    return (
      <LinearGradient colors={['#ffffff', '#999999']} style={styles.container}>
        <Header icon={retour} title={"Ordinateurs"} navigation={navigation}/>
        <View>
          <Picker selectedValue={filtre} onValueChange={(itemValue) => setFiltre(itemValue)}>
            <Picker.Item style={styles.picker} label="Trier par marque" value="marque" />
            <Picker.Item style={styles.picker} label="Trier par prix croissant" value="prix croissant" />
            <Picker.Item style={styles.picker} label="Trier par prix décroissant" value="prix décroissant" />
          </Picker>
          <FlatList style={styles.container1}  
            data={ordinateurs}
            numColumns={4}
            keyExtractor={(item, index) => item.id ? item.id.toString() : index.toString()}
            renderItem={({ item }) => (
              <View style={styles.container0}>
                <TouchableOpacity onPress={handlePress}>
                  {zoomed ? (
                    <ImageView
                      cropWidth={Dimensions.get('window').width}
                      cropHeight={Dimensions.get('window').height}
                      imageWidth={200}
                      imageHeight={200}
                    >
                      <Image
                        style={styles.image}
                        source={{ uri: item.photographie }}
                      />
                    </ImageView>
                  ) : (
                    <Image
                      style={styles.image}
                      source={{ uri: item.photographie }}
                    />
                  )}
                </TouchableOpacity>
                <Text style={styles.text}>{item.nomProduit}</Text>
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

export default OrdinateursVisiteur;