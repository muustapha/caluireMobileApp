import {StyleSheet } from "react-native";

const styles = StyleSheet.create({
    container: {
        width: '100%',
       
        alignItems: 'center',
    },
    boutton: {
        backgroundColor: 'red',
        padding: 1,
           borderRadius: 15,
        width: '70%',
        height: '35%', 
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
width: '40%',
height: '25%',
   },
   centeredView: {

width: '100%',
height: '100%',

   },
modalView: {
    flex: 1,
width: '40%',
height: '40%',



}

    });
export default styles;