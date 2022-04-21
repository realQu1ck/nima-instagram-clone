import * as React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import {
  createStackNavigator,
  CardStyleInterpolators,
} from '@react-navigation/stack';

import LoginPage from './src/containers/Account/LoginPage';
import ChooseUsername from './src/containers/Account/ChooseUsername';

var Stack = createStackNavigator();

export default function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName={'Login'} screenOptions={{ headerShown: false, animationEnabled: true, cardStyleInterpolator: CardStyleInterpolators.forHorizontalIOS }}>
        <Stack.Screen name='Login' component={LoginPage} />
        <Stack.Screen name='ChooseUsername' component={ChooseUsername} />
      </Stack.Navigator>
    </NavigationContainer>
  )
}