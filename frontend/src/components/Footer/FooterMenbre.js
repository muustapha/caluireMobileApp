import React from 'react';
import { View, Text, Image, TouchableOpacity } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import styles from './StyleFooter';


const cadieIcon = require('../../asset/icons/cadie.png');
const notification = require('../../asset/icons/notification.png');
const pickUp = require('../../asset/icons/pickUp.png');
const réparation = require('../../asset/icons/réparation.png');
const tchat = require('../../asset/icons/tchat.png');


const FooterMenbre = () => {
    return (
        <LinearGradient colors={['#E1CD5F', '#DAD5A0']} style={styles.footer}>
            <View style={styles.container}>
            <TouchableOpacity onPress={() => { console.log('Icone cliquée!'); }}>
                    <Image source={cadieIcon} style={styles.icon} />
                <Text style={styles.footerText}>Panier</Text>                
                </TouchableOpacity>
                <TouchableOpacity onPress={() => { console.log('Icone cliquée!'); }}>
                    <Image source={notification} style={styles.icon} />
                <Text style={styles.footerText}>Notification</Text>                </TouchableOpacity>
                <TouchableOpacity onPress={() => { console.log('Icone cliquée!'); }}>
                    <Image source={pickUp} style={styles.icon} />
                <Text style={styles.footerText}>PickUp</Text>                
                </TouchableOpacity>
                <TouchableOpacity onPress={() => { console.log('Icone cliquée!'); }}>
                    <Image source={réparation} style={styles.icon} />
                <Text style={styles.footerText}>Réparation</Text>                
                </TouchableOpacity> <TouchableOpacity onPress={() => { console.log('Icone cliquée!'); }}>
                    <Image source={tchat} style={styles.icon} />
                <Text style={styles.footerText}>Tchat</Text>                
                </TouchableOpacity>

            </View>
        </LinearGradient>
    );
}

export default FooterMenbre;