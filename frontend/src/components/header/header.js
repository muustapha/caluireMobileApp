import React from 'react';
import { View, Text,TouchableOpacity, Image } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import styles from './StyleHeader';


const Header = ({icon, title,navigation }) => {
  return (<LinearGradient start={{x: 0, y: 0}} end={{x: 1, y: 0}}
  colors={['#B8DBED', '#61A0C1']} style={styles.header}>
<TouchableOpacity onPress={() => { navigation.goBack(); }}>
  <Image source={icon} style={styles.icon} />
</TouchableOpacity>
      <Text style={styles.headerText}>{title}</Text>
  
    </LinearGradient>
  );
};

export default Header;