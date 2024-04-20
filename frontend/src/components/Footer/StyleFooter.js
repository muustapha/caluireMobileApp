import { StyleSheet } from 'react-native';

const styles = StyleSheet.create({
  footer: {
    height: '7%',
    width: '100%',
    flexDirection: 'row',
    justifyContent: 'flex-end', // Aligner le conteneur à droite
  },
  container: {
    alignItems: 'flex-end', // Aligner les éléments à droite

  },
  footerText: {
    fontSize: 13,
    color: '#000',
    fontWeight: 'bold',
    marginLeft: 11,
  },
  icon: {
    flex: 1,
    resizeMode: 'contain',
  },
});
export default styles;