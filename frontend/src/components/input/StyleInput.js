import React from "react";
import { StyleSheet } from "react-native";


const styles = StyleSheet.create({


    container: {
        borderWidth: 1,
        width: '100%',
        borderRadius: 25,
        height: '11%',
        width: '80%',
        backgroundColor: '#F0EEE9',
        flexDirection: 'row',
        alignItems: 'center',
        marginVertical: '5%',
    },
    iconContainer: {
        width: '10%',
        
        marginLeft: 10,
    },
    input: {
        fontFamily: 'popins',
        fontSize: 20,
        width: '80%',
        height: '100%',
        marginLeft: '5%',
        color: '#000',
        padding: 7,
        marginTop: 5,
        textAlign: 'left',
    },
    focused: {
        borderColor: '#5FCDA6',
        borderWidth: 1.5,
        height: '20%', // Changez cela en fonction de votre style de focus
    },
});
export default styles;