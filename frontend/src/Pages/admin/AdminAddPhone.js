import React, { useState } from 'react';
import { Button, TextInput, View } from 'react-native';

const AdminAddPhone = () => {
  const [flagProduit, setFlagProduit] = useState('');
  const [nomProduit, setNomProduit] = useState('');
  const [marque, setMarque] = useState('');
  const [prix, setPrix] = useState('');
  const [stock, setStock] = useState('');
  const [photographie, setPhotographie] = useState('');
  const [description, setDescription] = useState('');
  const [idTypesProduit, setIdTypesProduit] = useState('');

  const handleSubmit = () => {
    fetch('http://10.0.2.2:5127/api/Produits', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        FlagProduit: flagProduit,
        NomProduit: nomProduit,
        Marque: marque,
        Prix: prix,
        Stock: stock,
        Photographie: photographie,
        Description: description,
        IdTypesProduit: idTypesProduit,
      }),
    })
      .then(response => response.json())
      .then(data => {
        console.log('Success:', data);
      })
      .catch((error) => {
        console.error('Error:', error);
      });
  };
  const selectImage = () => {
    const options = {
      title: 'Sélectionner une photo',
      storageOptions: {
        skipBackup: true,
        path: 'images',
      },
    };
  
    ImagePicker.showImagePicker(options, (response) => {
      if (response.didCancel) {
        console.log('L\'utilisateur a annulé la prise de photo');
      } else if (response.error) {
        console.log('Erreur ImagePicker : ', response.error);
      } else {
        const source = { uri: response.uri };
        setPhotographie(source.uri);
      }
    });
  };

  return (
    <View>
      
      <TextInput
        placeholder="Flag du produit"
        value={flagProduit}
        onChangeText={setFlagProduit}
      />
      <TextInput
        placeholder="Nom du produit"
        value={nomProduit}
        onChangeText={setNomProduit}
      />
      <TextInput
        placeholder="Marque"
        value={marque}
        onChangeText={setMarque}
      />
      <TextInput
        placeholder="Prix"
        value={prix}
        onChangeText={setPrix}
      />
      <TextInput
        placeholder="Stock"
        value={stock}
        onChangeText={setStock}
      />
      <Button title="Sélectionner une photo" onPress={selectImage} />

<TextInput
  placeholder="URL de la photographie"
  value={photographie}
  onChangeText={setPhotographie}
/>

      <TextInput
        placeholder="Description"
        value={description}
        onChangeText={setDescription}
      />
      <TextInput
        placeholder="Id du type de produit"
        value={idTypesProduit}
        onChangeText={setIdTypesProduit}
      />
      <Button title="Ajouter le téléphone" onPress={handleSubmit} />
    </View>
  );
};

export default AdminAddPhone;