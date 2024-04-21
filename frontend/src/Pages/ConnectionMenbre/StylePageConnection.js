import { StyleSheet } from 'react-native';
import { flingHandlerName } from 'react-native-gesture-handler/lib/typescript/handlers/FlingGestureHandler';
const styles = StyleSheet.create({
    eye: {
        width:'100%',
        height:'50%',
        color:"black",
        right:30,      
     },
    container0: {
        flex: 1,
        alignItems: 'center',
        height: '50%',
        width: '100%',
        justifyContent: 'center',
        marginTop: '25%',
    },

    container: {
        borderWidth: 1.5,
        marginVertical: '5%',
        width: '100%',
        borderRadius: 25,
        height: '8%',
        width: '80%',
        backgroundColor: '#F0EEE9',
        alignContent: 'center',
        flexDirection: 'row',
        alignItems: 'center',

    },

    container2: {

        alignItems: 'center',
        width: '100%',

    },
    button: {
        backgroundColor: '#5FCDA6',
        padding: 15,
        borderRadius: 15,
        width: '70%',
        // height: '70%',
        // alignItems: 'center',
        // position: 'absolute', // Ajoutez cette ligne
        bottom: 325,
         
        elevation: 5,
    },
    buttonText: {
        color: 'white',
        fontSize: 23,
        textAlign: 'center',
        fontWeight: 'bold',
        fontFamily: 'popins',
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
    title2: {
        color: 'white', 
        fontSize: 15,
        fontWeight: 'bold',
        fontFamily: 'times new roman',
        

    },
    containerText: {
        
        
    
        
       
    },
    containerPage: {
        flex: 1,
        justifyContent: 'space-between',
        width: '100%',
        height: '100%',
    },

    title: {
        fontSize: 24,
        textAlign: 'center',
        marginTop: '10%',
        fontWeight: 'bold',
        fontFamily: 'popins',

    },
    title1: {
        fontSize: 14,
        marginLeft: '53%',
        color: 'blue',
        fontWeight: 'bold',
        fontFamily: 'times new roman',


    },
    container1: {
        marginBottom: '90%',
    },
    centeredView: {
        flex: 1,
        justifyContent: "center",
        alignItems: "center",
        marginTop: 22
    },
    modalView: {
        margin: 20,
        backgroundColor: "white",
        borderRadius: 20,
        padding: 35,
        alignItems: "center",
        shadowColor: "#000",
        shadowOffset: {
            width: 0,
            height: 2
        },
        shadowOpacity: 0.25,
        shadowRadius: 4,
        elevation: 5
    },
    modalText: {
        marginBottom: 15,
        textAlign: "center"
    },
    icon: {
        width: '10%',
        height: '10%',
        marginLeft: 10,
    },
    focused: {
        borderColor: 'blue',
        borderWidth: 2,
        height: '55%', // Changez cela en fonction de votre style de focus
    },
});

export default styles;  