import React, { useState } from 'react';
import { View, Text, TouchableOpacity, Modal } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useNavigation } from '@react-navigation/native';

const Deconnection = () => {
  const [showModal, setShowModal] = useState(false);
  const navigation = useNavigation();

  const handleLogout = async () => {
    try {
      const token = await AsyncStorage.getItem("userToken");
      // Si vous stockez également le temps d'expiration du token, vous pouvez le récupérer ici
      // const tokenExpiryTime = await AsyncStorage.getItem("tokenExpiryTime");
      // const currentTime = new Date().getTime();
  
      // Vérifier si le token est présent (connecté) dans AsyncStorage
      if (token) {
        // Si le token est présent, supprimez-le pour effectuer la déconnexion
        await AsyncStorage.removeItem("userToken");
        
        // Mettez à jour l'état d'authentification pour indiquer que l'utilisateur est déconnecté
        // Cela peut impliquer de mettre à jour un état global ou de déclencher une fonction de mise à jour dans le contexte d'authentification
        // Par exemple, si vous utilisez useContext pour gérer l'état d'authentification :
        // updateAuthState(false);
  
        // Naviguer vers la page d'accueil après la déconnexion
        navigation.navigate('Home');
      } else {
        console.log("Aucun token trouvé. L'utilisateur n'est pas connecté.");
      }
    } catch (error) {
      console.error("Erreur lors de la déconnexion : ", error.message);
    } finally {
      setShowModal(false);
    }
  };
  

  return (
    <>
      <TouchableOpacity onPress={() => setShowModal(true)}>
        <Text>Logout</Text>
      </TouchableOpacity>
      <Modal
        visible={showModal}
        transparent={true}
        animationType="slide"
        onRequestClose={() => setShowModal(false)}
      >
        <View>
          <View>
            <Text>Voulez-vous vraiment vous déconnecter ?</Text>
            <TouchableOpacity onPress={handleLogout}>
              <Text>Yes</Text>
            </TouchableOpacity>
            <TouchableOpacity onPress={() => setShowModal(false)}>
              <Text>No</Text>
            </TouchableOpacity>
          </View>
        </View>
      </Modal>
    </>
  );
};

export default Deconnection;
