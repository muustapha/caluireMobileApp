import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import PremierePage from './src/Pages/premierePage/PremierePage';
import PageConnection from './src/Pages/ConnectionMenbre/PageConnection';
import PageAcceuilVisiteur from './src/Pages/pageAcceuilVisiteur/PageAcceuilVisiteur';
import CreerProfile from './src/Pages/Profil/creerProfil/CreerProfile';
const Stack = createStackNavigator();

const App = () => {
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="PremierePage">
        <Stack.Screen name="PremierePage" component={PremierePage} options={{ headerShown: false }} />
        <Stack.Screen name="PageConnection" component={PageConnection} options={{ headerShown: false }} />
        <Stack.Screen name="PageAcceuillVisiteur" component={PageAcceuilVisiteur} options={{ headerShown: false }}/>
        <Stack.Screen name="CreerProfile" component={CreerProfile} options={{ headerShown: false }}/>
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default App;
