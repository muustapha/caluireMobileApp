import React from 'react';
import { View, Text, StyleSheet } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import styles from './StyleHeader1';

const Header1 = ({ title }) => {
  return (<LinearGradient start={{x: 0, y: 0}} end={{x: 1, y: 0}}
  colors={['#313131', '#8d9293']} style={styles.header}>
  
      <Text style={styles.headerText}>{title}</Text>

    </LinearGradient>
  );
};


export default Header1;