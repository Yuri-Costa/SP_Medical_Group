import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

import Login from './Pages/Login';
import Paciente from './Pages/PacienteConsulta';
import Medico from './Pages/ConsultaMedico';



const AuthStack = createStackNavigator();

export default function Stack(){
  return(
    <NavigationContainer>
      <AuthStack.Navigator
        headerMode = 'none'
      >
        <AuthStack.Screen name = 'Login' component={Login} />
        <AuthStack.Screen name = 'Paciente' component={Paciente} />
        <AuthStack.Screen name = 'Medico' component={Medico} />
      </AuthStack.Navigator>
    </NavigationContainer>
  )
}
