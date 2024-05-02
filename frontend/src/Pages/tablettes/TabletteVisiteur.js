import React, { useEffect, useState, useRef } from 'react';
import {StyleSheet} from 'react-native';
import Header from '../../components/header/Header';
import LinearGradient from 'react-native-linear-gradient';
import Footer from '../../components/Footer/Footer';
import Produit from '../../components/produits/produit';

const retour = require('../../asset/icons/flecheRetour.png');

const TabletteVisiteur = ({ navigation }) => {
    const [tablettes, setTablettes] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);
    const [filtre, setFiltre] = useState('');
    const clickCount = useRef(0);
    const [zoomed, setZoomed] = useState(false);

    useEffect(() => {
      fetch('http://10.0.2.2:5127/api/Produits/magasin/tablette')
        .then(response => response.json())
        .then(data => setTablettes(data))
        .catch(error => console.error('Erreur:', error));
    }, []);

    useEffect(() => {
      let tablettesTries = [...tablettes];
      if (filtre === 'marque') {
        tablettesTries.sort((a, b) => a.marque.localeCompare(b.marque));
      } else if (filtre === 'prix croissant') {
        tablettesTries.sort((a, b) => a.prix - b.prix);
      } else if (filtre === 'prix décroissant') {
        tablettesTries.sort((a, b) => b.prix - a.prix);
      }
      setTablettes(tablettesTries);
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
        <Header icon={retour} title={"TABLETTES"} navigation={navigation}/>
        <Produit />
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

export default TabletteVisiteur;