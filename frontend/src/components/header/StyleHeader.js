import { StyleSheet } from 'react-native';

const styles = StyleSheet.create({
  header: {
    flexDirection: 'row',
    alignItems: 'center', // Ajoutez ceci
    textAlign: 'center',
    height: '7%',
    width: '100%',
  },
  icon: {
    width: 30,
    height: 30,
    resizeMode: 'cover',
    marginLeft: 10,
  },
  headerText: {
    fontSize: 25,
    fontWeight: 'bold',
    color: '#fff',
    fontFamily: 'popins',
   textAlign: 'center',
    flex: 1,
  },
});
export default styles;