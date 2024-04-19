import React from 'react';
import { View, Text, StyleSheet } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
const Header = ({ title }) => {
  return (<LinearGradient start={{x: 0, y: 0}} end={{x: 1, y: 0}}
  colors={['#8d9293', '#313131']} style={styles.container}>
    <View style={styles.header}>
      <Text style={styles.headerText}>{title}</Text>
    </View>
    </LinearGradient>
  );
};
const styles = StyleSheet.create({
  header: {
    height: 60,
    width: '104%',
    justifyContent: 'center',
    alignItems: 'center',
    
  },
  headerText: {
    fontSize: 20,
    fontWeight: 'semi-bold',
    color: '#fff',
    alignContent: 'center',
    alignItems: 'center',
paddingLeft: 7,
paddingRight: 7,
  },
});

export default Header;