import React, { useState } from 'react';
import { View, Text, Image, StyleSheet, Dimensions, TouchableOpacity } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import Header from '../../components/header/Header';
import ImageZoom from 'react-native-image-pan-zoom';

const retour = require('../../asset/icons/flecheRetour.png');

const Focus = ({ route, navigation }) => {
  const { item } = route.params;
  const [imageUri, setImageUri] = useState(item.photographie);

  const changeImage = () => {
    // Mettez ici le code pour changer l'image
    setImageUri('newImageUri');
  };

  return (
    <LinearGradient colors={['#ffffff', '#999999']} style={styles.container}>
        <Header icon={retour} title="FOCUS PRODUIT" navigation={navigation} />
    <View style={styles.container0}>
      <TouchableOpacity onPress={changeImage}>
        <ImageZoom
          cropWidth={Dimensions.get('window').width}
          cropHeight={Dimensions.get('window').width} // limit the height
          imageWidth={Dimensions.get('window').width}
          imageHeight={Dimensions.get('window').width} // limit the height
        >
          <Image
            style={styles.image}
            source={{ uri: imageUri }}
          />
        </ImageZoom>
      </TouchableOpacity>
      <Text style={styles.text}>{item.nomProduit}</Text>
      <Text style={styles.text}>{item.prix}€</Text>
      <Text style={styles.text}>Quantité : {item.stock}</Text>
      <Text style={styles.text}>{item.description}</Text>
    </View>
    </LinearGradient>
  );
};

const styles = StyleSheet.create({
    container: {
        width: '100%',
        height: '100%',
    },
    image: {
        width: '100%',
        height: '100%',
        borderRadius: 15,
    },
    container0: {
        padding: 5,
        width: '100%',
        height: '100%',
        borderRadius: 15,
        alignItems: 'center',
    },
    text: {
        fontSize: 17,
        textAlign: 'center',
        fontWeight: 'bold',
    },
});

export default Focus;