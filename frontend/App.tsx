import React, { useState, useEffect } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import { createDrawerNavigator } from '@react-navigation/drawer';
import PremierePage from './src/Pages/premierePage/PremierePage';
import PageConnection from './src/Pages/ConnectionMenbre/PageConnection';
import PageAcceuilVisiteur from './src/Pages/pageAcceuil/pageAcceuilVisiteur/PageAcceuilVisiteur';
import CreerProfile from './src/Pages/Profil/creerProfil/CreerProfile';
import EditerProfile from './src/Pages/Profil/editerProfil/EditerProfile';
import VerificationProfile from './src/Pages/Profil/validerProfil/VerificationProfil';
import ConnexionErreur from './src/Pages/ConnectionMenbre/ConnexionErreur';
import PageAcceuil from './src/Pages/pageAcceuil/pageAcceuilMenbre/PageAcceuil';
import Telephones from './src/Pages/telephone/TelephoneVisiteur';
import TabletteVisiteur from './src/Pages/tablettes/TabletteVisiteur';
import OrdinateurVisiteur from './src/Pages/ordinateurs/OrdinateurVisiteur';
import AccessoireVisiteur from './src/Pages/accessoires/AccessoireVisiteur';
import Panier from './src/Pages/panier/Panier';
import PanierContext from './src/Pages/panier/paniercontext';
import Focus from './src/Pages/focus/Focus';
import MonProfil from './src/Pages/Profil/monProfil/MonProfil';
import Contact from './src/Pages/contact/Contact';
import Drawers from './src/components/drawer/Drawers';
import 'react-native-gesture-handler';


const Stack = createStackNavigator();
const Drawer = createDrawerNavigator();

const App = () => {
  const [panier, setPanier] = useState([]);

  useEffect(() => {
    const recupererPanier = async () => {
      const panierData = await AsyncStorage.getItem('panier');
      try {
        if (panierData) {
          setPanier(JSON.parse(panierData));
        }
      } catch (error) {
        console.error('Erreur lors de la conversion de panierData en JSON :', error);
      }
    };

    recupererPanier();
  }, []);

  const utilisateurConnecte = false;

  return (
    <PanierContext.Provider value={{ panier, setPanier }}>
      <NavigationContainer>
        {utilisateurConnecte ? (
          <Drawer.Navigator drawerContent={() => <Drawers />}>
            <Drawer.Screen name="PageAcceuil" component={PageAcceuil} />
            <Drawer.Screen name="MonProfil" component={MonProfil} />
            <Drawer.Screen name="Contact" component={Contact} />
          </Drawer.Navigator>
        ) : (
          <Stack.Navigator initialRouteName="PremierePage">
            <Stack.Screen name="PremierePage" component={PremierePage} options={{ headerShown: false }} />
            <Stack.Screen name="PageConnection" component={PageConnection} options={{ headerShown: false }} />
            <Stack.Screen name="PageAcceuillVisiteur" component={PageAcceuilVisiteur} options={{ headerShown: false }} />
            <Stack.Screen name="CreerProfile" component={CreerProfile} options={{ headerShown: false }} />
            <Stack.Screen name="EditerProfile" component={EditerProfile} options={{ headerShown: false }} />
            <Stack.Screen name="VerificationProfile" component={VerificationProfile} options={{ headerShown: false }} />
            <Stack.Screen name="ConnexionErreur" component={ConnexionErreur} options={{ headerShown: false }} />
            <Stack.Screen name="Telephone" component={Telephones} options={{ headerShown: false }} />
            <Stack.Screen name="Tablette" component={TabletteVisiteur} options={{ headerShown: false }} />
            <Stack.Screen name="Ordinateur" component={OrdinateurVisiteur} options={{ headerShown: false }} />
            <Stack.Screen name="Accessoire" component={AccessoireVisiteur} options={{ headerShown: false }} />
            <Stack.Screen name="PageAcceuil" component={PageAcceuil} options={{ headerShown: false }} />
            <Stack.Screen name="Focus" component={Focus} options={{ headerShown: false }} />
            <Stack.Screen name="MonProfil" component={MonProfil} options={{ headerShown: false }} />
            <Stack.Screen name="Contact" component={Contact} options={{ headerShown: false }} />
            <Stack.Screen name="Drawers" component={Drawers} options={{ headerShown: false }} />
          </Stack.Navigator>
        )}
      </NavigationContainer>
    </PanierContext.Provider>
  );
};

export default App;
