import React from 'react';
import { View, Text, StyleSheet, TouchableOpacity } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import Footer from '../../../components/Footer/Footer';
import HeaderDrawer from '../../../components/header/HeaderDrawer';
import { useNavigationState } from '@react-navigation/native';

const PageAcceuil = ({ navigation }) => {
  const utilisateurConnecte = false;
  const isDrawerOpen = useNavigationState(state => state.routes.some(r => r.name === 'DrawerOpen'));
  return (
    <LinearGradient colors={['#ffffff', '#999999']} style={styles.container}>
      <HeaderDrawer title={"ACCUEIL"} navigation={navigation} isDrawerOpen={isDrawerOpen} utilisateurConnecte={utilisateurConnecte} />
      <Text style={styles.title}>Veuillez sélectionner un type de produit</Text>
      <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('Telephone')}>
        <Text style={styles.buttonText}>Téléphones</Text>
      </TouchableOpacity>
      <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('Ordinateur')}>
        <Text style={styles.buttonText}>Ordinateurs</Text>
      </TouchableOpacity>
      <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('Tablette')}>
        <Text style={styles.buttonText}>Tablettes</Text>
      </TouchableOpacity>
      <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('Accessoire')}>
        <Text style={styles.buttonText}>Accessoires</Text>
      </TouchableOpacity>
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
    fontWeight: 'bold',
  },
});

export default PageAcceuil;
