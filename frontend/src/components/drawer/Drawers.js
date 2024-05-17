import React from 'react';
import { View, StyleSheet } from 'react-native';
import { DrawerContentScrollView, DrawerItem } from '@react-navigation/drawer';
import Deconnection from '../deconnection/deconnection';
import { useNavigation } from '@react-navigation/native';

const Drawers = () => {
  const navigation = useNavigation();

  return (
    <DrawerContentScrollView>
      {/* Optionnel : Ajouter une entête ou des informations de profil ici */}
      <DrawerItem 
        label="PageAccueil"
        onPress={() => navigation.navigate('PageAcceuil')} // Correction orthographe 'Acceuil' à 'Accueil'
      />
      <DrawerItem 
        label="Mon Profil"
        onPress={() => navigation.navigate('MonProfil')}
      />
      <DrawerItem 
        label="Contact"
        onPress={() => navigation.navigate('Contact')}
      />
      <View style={styles.logoutButtonWrapper}>
        <Deconnection />
      </View>
    </DrawerContentScrollView>
  );
};

const styles = StyleSheet.create({
  drawerHeader: {
    padding: 20,
    borderBottomWidth: 1,
  },
  headerText: {
    fontSize: 18,
    fontWeight: 'bold',
  },
  logoutButtonWrapper: {
    marginTop: 10, // Ajouté pour alignement et espace
  },
});

export default Drawers;
