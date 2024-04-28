import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import PremierePage from './src/Pages/premierePage/PremierePage';
import PageConnection from './src/Pages/ConnectionMenbre/PageConnection';
import PageAcceuilVisiteur from './src/Pages/pageAcceuil/pageAcceuilVisiteur/PageAcceuilVisiteur';
import CreerProfile from './src/Pages/Profil/creerProfil/CreerProfile';
import EditerProfile from './src/Pages/Profil/editerProfil/EditerProfile';
import VerificationProfile from './src/Pages/Profil/validerProfil/VerificationProfil';
import ConnexionErreur from './src/Pages/ConnectionMenbre/ConnexionErreur';
import PageAcceuilMenbre from './src/Pages/pageAcceuil/pageAcceuilMenbre/PageAcceuilMenbre';
const Stack = createStackNavigator();

const App = () => {
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="PremierePage">
        <Stack.Screen name="PremierePage" component={PremierePage} options={{ headerShown: false }} />
        <Stack.Screen name="PageConnection" component={PageConnection} options={{ headerShown: false }} />
        <Stack.Screen name="PageAcceuillVisiteur" component={PageAcceuilVisiteur} options={{ headerShown: false }}/>
        <Stack.Screen name="CreerProfile" component={CreerProfile} options={{ headerShown: false }}/>
        <Stack.Screen name="EditerProfile" component={EditerProfile} options={{ headerShown: false }}/>
        <Stack.Screen name="VerificationProfile" component={VerificationProfile} options={{ headerShown: false }}/>
       <Stack.Screen name="ConnexionErreur" component={ConnexionErreur} options={{ headerShown: false }}/>
       <Stack.Screen name="PageAcceuilMenbre" component={PageAcceuilMenbre} options={{ headerShown: false }}/>
       
       
        </Stack.Navigator>
    </NavigationContainer>
  );
};

export default App;
