// import React, {useState,useEffect} from 'react';
// import AsyncStorage from '@react-native-async-storage/async-storage';
// import PanierContext from './src/Pages/panier/paniercontext';
// import DrawerNavigator from './DrawerNavigator'; // Importez le DrawerNavigator

// const App = () => {
//   const [panier, setPanier] = useState([]);
//   useEffect(() => {
//     const recupererPanier = async () => {
//       const panierData = await AsyncStorage.getItem('panier');
//       if (panierData) {
//         setPanier(JSON.parse(panierData));
//       }
//     };

//     recupererPanier();
//   }, []);

//   return (
//     <PanierContext.Provider value={{ panier, setPanier }}>
//       <DrawerNavigator />
//     </PanierContext.Provider>
//   );
// };

// export default App;