import React, { useState } from 'react';
import { View, TextInput, } from 'react-native';
import styles from './StyleInput';


const Input = ({ icon, placeholder, value, onChangeText, secureTextEntry }) => {
  const [isFocused, setIsFocused] = useState(false);

  return (
  
        <View style={[styles.container, isFocused ? styles.focused : {}]}>
      {icon}
      <TextInput
        style={styles.input}
        value={value}
        onChangeText={onChangeText}
        placeholder={placeholder}
        secureTextEntry={secureTextEntry}
        onFocus={() => setIsFocused(true)}
        onBlur={() => setIsFocused(false)}
      />
    </View>
    
  );
};

export default Input;