import {StyleSheet } from "react-native";

const styles = StyleSheet.create({
    container: {
        width: '100%',
       
        alignItems: 'center',
   position: 'absolute',
    bottom:0,
    marginBottom: 10,
    },
    boutton: {
        backgroundColor: 'red',
        padding: 1,
           borderRadius: 15,
        width: '70%',
        height: '95%', 
        borderWidth: 1,
        borderColor: '#000',
        
    },
    bouttonText: {
        color: 'white',
        fontSize: 15,
        textAlign: 'center',
        fontWeight: 'bold',
        fontFamily: 'times new roman',

    },
   image: {
width: '60%',
height: '45%',
borderRadius: 15,
marginVertical: '20%',
   },
   centeredView: {

width: '100%',
height: '100%',
backgroundColor: 'rgba(0,0,0,0.5)',
   },
modalView: {
width: '80%',
height: '80%',
backgroundColor: '#999999',
alignItems: 'center',
marginTop: '25%',
marginLeft: '10%',
borderRadius: 20,
padding: 15,

},

modalText: {
fontSize: 25,
textAlign: 'center',
fontWeight: 'bold',
fontFamily: 'popins',   
},
bouttonModal: {
backgroundColor: 'red',
padding: 10,
borderRadius: 15,
width: '50%',
marginTop: 20,
},
bouttonAnnuler: {
backgroundColor: 'red',
padding: 10,
borderRadius: 15,
width: '50%',
marginTop: 20,
},
    });
export default styles;