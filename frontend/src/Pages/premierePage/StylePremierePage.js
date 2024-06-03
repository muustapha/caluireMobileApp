import { StyleSheet } from 'react-native';

const styles = StyleSheet.create({

    title1: {
      fontSize: 31,
      textAlign: 'center',
      color: '#fff',
      marginBottom: 20,
      fontFamily: 'times new roman',
    },
  title: {
      fontSize: 31,
      textAlign: 'center',
      color: '#030303',
      marginBottom: 20,
      fontWeight: 'bold',
      fontFamily: 'times new roman',
    },
  
   logo: {
    backgroundColor: 'transparent',
    width: '75%',
    height: '75%',
    resizeMode: 'contain',
  },
    button: {
      backgroundColor: '#fffdfd',
      padding: 10,
      margin: 10,
      borderRadius: 5,
    },
    buttonText: {
      color: '#030303',
      textAlign: 'center',
      fontSize: 20,
      fontWeight: 'bold',
      fontFamily: 'times new roman',
    },
    container: {
      flex: 1,
      justifyContent: 'flex-start',
      alignItems: 'center',
  
    },
    containerLogo: {
      alignItems: 'center',
      justifyContent: 'center',
      width: '100%', // Ajoutez une largeur
      height: '50%', // Ajoutez une hauteur
      marginBottom: 20,
      marginTop: 60,
    },
    containerbouttons: {
      justifyContent: 'center',
      flex: 0.75,
      backgroundColor: '#313131',
      width: '100%',
      
  },
   title2: {
      textAlign: 'center',
      fontSize: 15,
      fontWeight: 'bold',
     alignContent: 'flex-end',
      color: '#fff',
  fontFamily: 'popins',
  paddingTop: 20,
  },
    footer: {
     flex: 0.25,
      width: '100%',
      height : '0.5%',
  
      },
  
  });
  export default styles;