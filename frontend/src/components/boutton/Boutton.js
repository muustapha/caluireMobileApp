import react from 'react';
import styles from '../boutton/StyleBoutton';
import { Text, TouchableOpacity, View } from 'react-native';

const Boutton = ({ title, onPress }) => {
    return (
        <View style={styles.container}>
        <TouchableOpacity onPress={onPress} style={styles.boutton}>
            <Text style={styles.bouttonText}>{title}</Text>
        </TouchableOpacity>
        </View>
    );
}
export default Boutton;