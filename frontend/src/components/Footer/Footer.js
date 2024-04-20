import React from 'react';
import { View, Text, Image, TouchableOpacity } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import styles from './StyleFooter';

const cadieIcon = require('../../asset/icons/cadie.png');

const Footer = () => {
    return (
        <LinearGradient colors={['#E1CD5F', '#DAD5A0']} style={styles.footer}>
            <View style={styles.container}>
                <TouchableOpacity onPress={() => { console.log('Icone cliquée!'); }}>
                    <Image source={cadieIcon} style={styles.icon} />
                <Text style={styles.footerText}>Panier</Text>                
                </TouchableOpacity>

            </View>
        </LinearGradient>
    );
}

export default Footer;