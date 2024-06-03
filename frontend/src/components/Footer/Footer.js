import React from 'react';
import { View, Text, Image, TouchableOpacity } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import styles from './StyleFooter';
import { useNavigation } from '@react-navigation/native';


const cadieIcon = require('../../asset/icons/cadie.png');
const Footer = () => {
    const navigation = useNavigation();
    return (
        <LinearGradient colors={['#E1CD5F', '#DAD5A0']} style={styles.footer}>
            <View style={styles.container}>
                <TouchableOpacity onPress={() => { navigation.navigate('Panier'); }}>
  <Image source={cadieIcon} style={styles.icon} />
  <Text style={styles.footerText}>Panier</Text>                
</TouchableOpacity>

            </View>
        </LinearGradient>
    );
}

export default Footer;