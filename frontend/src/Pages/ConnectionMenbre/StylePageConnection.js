import { StyleSheet } from 'react-native';
import { flingHandlerName } from 'react-native-gesture-handler/lib/typescript/handlers/FlingGestureHandler';
const styles = StyleSheet.create({
    eye: {
        width: '100%',
        height: '50%',
        color: "black",
        right: 30,
    },
    containerPage: {


        width: '100%',
        height: '100%',
    },
    title: {
        fontSize: 27,
        textAlign: 'center',
        marginTop: '10%',
        fontWeight: 'bold',
        fontFamily: 'popins',
        color: '#075B3F',
    },

    container0: {

        padding: 3,
        alignItems: 'center',
        width: '100%',
        marginTop: '15%',
    },

    container: {
        borderWidth: 1.5,
        marginVertical: '5%',
        width: '100%',
        borderRadius: 25,
        height: '13%',
        width: '80%',
        backgroundColor: '#F0EEE9',
        alignContent: 'center',
        flexDirection: 'row',
        alignItems: 'center',

    },
    container1: {


    },
    title1: {
        fontSize: 15,
        marginLeft: '53%',
        color: '#4f5aff',
        fontWeight: 'bold',
        fontFamily: 'times new roman',


    },
    container2: {

        alignItems: 'center',
        width: '100%',
        marginBottom: '5%',
    },
 
    containerText: {
        width: '100%',

    },
    title2: {
        textAlign: 'center',
        color: '#4f5aff',
        fontSize: 15,
        fontWeight: 'bold',
        fontFamily: 'times new roman',

    },
    footer: {

        alignItems: 'center',
        width: '100%',
        marginTop: '35%',

    },
    buttonFooter: {
        backgroundColor: '#fff',
        padding: 5,
        borderRadius: 25,
        width: '90%',
        // height: '70%',
        // alignItems: 'center',
        // position: 'absolute', // Ajoutez cette ligne

        borderWidth: 1,
        borderColor: '#075B3F',
        elevation: 5,
    },
    buttonTextFooter: {
        color: '#075B3F',
        fontSize: 17,
        textAlign: 'center',
        fontWeight: 'bold',
        fontFamily: 'roboto slab',
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
    },







    centeredView: {
        height: '75%',
        justifyContent: "center",
        alignItems: "center",
        marginTop: 22,
        elevation: 5,
    },
    modalView: {
        margin: 20,
        backgroundColor: "white",
        borderRadius: 20,
        padding: 5,
        alignItems: "center",
        shadowColor: "#000",
        shadowOffset: {
            width: '15%',
            height: '15%'
        },
        marginTop: '25%',
        elevation: 5
    },
    modalText: {
        marginBottom: 15,
        textAlign: "center",
        fontSize: 20,
        fontFamily: 'popins',
     
    },
    icon: {
        width: '10%',
        height: '10%',
        marginLeft: 10,
    },
    focused: {
        borderColor: '#5FCDA6',
        borderWidth: 1.5,
        height: '20%', // Changez cela en fonction de votre style de focus
    },

    modalButton: {
        backgroundColor: '#5FCDA6',
        padding: 10,
        borderRadius: 15,
        width: '40%',
        borderWidth: 1,
        borderColor: '#fff',
        elevation: 5,

    }, 
});

export default styles;  