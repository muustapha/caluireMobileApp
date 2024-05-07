import React, { useState, useContext } from 'react';
import { Text, TouchableOpacity, View, Modal, Button, Image } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import styles from './StyleAjouterPanier';
import { Picker } from '@react-native-picker/picker';
import PanierContext from '../../Pages/panier/paniercontext';




const AjouterPanier = ({ produit, title }) => {
  const [modalVisible, setModalVisible] = useState(false);
  const [quantite, setQuantite] = useState(1);
  const { panier, setPanier } = useContext(PanierContext);


const ajouterAuPanier = async (produit, quantite) => {
  setPanier(prevPanier => {
    const indexProduit = prevPanier.findIndex(p => p.produit.nomProduit === produit.nomProduit);
    let nouveauPanier = [...prevPanier];
    if (indexProduit !== -1) {
      // Si le produit existe déjà dans le panier, incrémenter la quantité
      nouveauPanier[indexProduit].quantite += quantite;
    } else {
      // Si le produit n'est pas encore dans le panier, ajouter une nouvelle ligne
      nouveauPanier.push({ produit, quantite: Number(quantite) });
    }
    AsyncStorage.setItem('panier', JSON.stringify(nouveauPanier));
    return nouveauPanier;
  });
};

    return (
        <View style={styles.container}>
            <TouchableOpacity onPress={() => setModalVisible(true)} style={styles.boutton}>
                <Text style={styles.bouttonText}>{title}</Text>
            </TouchableOpacity>

            <Modal
  animationType="slide"
  transparent={true}
  visible={modalVisible}
>
  <View style={styles.centeredView}>
    <View style={styles.modalView}>
      <Image
        style={styles.image}
        source={{ uri: produit.photographie }}
      />
      <Text style={styles.modalText}> {produit.nomProduit}</Text>
      <Text style={styles.modalText}>Prix: {produit.prix}€</Text>

      <Picker
        selectedValue={quantite}
        style={{ height: 50, width: 100 }}
        onValueChange={(itemValue, itemIndex) => setQuantite(itemValue)}
      >
        <Picker.Item label="1" value={1} />
        <Picker.Item label="2" value={2} />
        <Picker.Item label="3" value={3} />
        <Picker.Item label="4" value={4} />
        <Picker.Item label="5" value={5} />
      </Picker>

      <TouchableOpacity
        style={styles.bouttonModal}
        onPress={() => {
          ajouterAuPanier(produit, quantite);
          setModalVisible(!modalVisible);
        }}
      >
        <Text style={styles.bouttonText}>Ajouter au panier</Text>
      </TouchableOpacity>
      <TouchableOpacity
        style={styles.bouttonAnnuler}
        onPress={() => {
          setModalVisible(false);
        }}
      >
        <Text style={styles.bouttonText}>Annuler</Text>
      </TouchableOpacity>
    </View>
  </View>
</Modal>
        </View>
    );
}

export default AjouterPanier;