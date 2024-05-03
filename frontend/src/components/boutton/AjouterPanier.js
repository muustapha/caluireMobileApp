import React, { useState } from 'react';
import { Text, TouchableOpacity, View, Modal, Button, Image } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import  styles  from './StyleAjouterPanier';

const ajouterAuPanier = async (produit) => {
    let panier = await AsyncStorage.getItem('panier');
    panier = panier != null ? JSON.parse(panier) : [];
    panier.push(produit);
    await AsyncStorage.setItem('panier', JSON.stringify(panier));
}

const AjouterPanier = ({ produit, title }) => {
    const [modalVisible, setModalVisible] = useState(false);

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
                        {<Image
                            style={styles.image}
                            source={{ uri: produit.photographie }}
                        />}
                        <Text style={styles.modalText}> {produit.nomProduit}</Text>
                        <Text style={styles.modalText}>Prix: {produit.prix}€</Text>
                        <Button
                            title="Ajout au panier"
                            onPress={() => {
                                ajouterAuPanier(produit);
                                setModalVisible(!modalVisible);
                            }}
                        />
                    </View>
                </View>
            </Modal>
        </View>
    );
}

export default AjouterPanier;