import React, { useContext } from 'react';
import { View, Text, Button } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import styles from './StyleHeader';
import { useNavigation, DrawerActions } from '@react-navigation/native';

const HeaderDrawer = ({ title }) => {
  const navigation = useNavigation();

  const handleToggleDrawer = () => {
    navigation.dispatch(DrawerActions.toggleDrawer());
  };

  return (
    <LinearGradient start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} colors={['#B8DBED', '#61A0C1']} style={styles.header}>
      <Button title="Menu" onPress={handleToggleDrawer} />
      <Text style={styles.headerText}>{title}</Text>
    </LinearGradient>
  );
};

export default HeaderDrawer;