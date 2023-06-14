import React from 'react';
import { createDrawerNavigator } from '@react-navigation/drawer';
import HomeStack from '../Routes/HomeStack'
import FavStack from './FavStack';
const Drawer = createDrawerNavigator();
function DrawerNavigator() {
  return (
    <Drawer.Navigator initialRouteName='HomeStack'  screenOptions={{
      headerShown: false}}>
        <Drawer.Screen name="Contact list screen" component={HomeStack} />
        <Drawer.Screen name="Favorite contacts" component={FavStack} />
    </Drawer.Navigator>
  );
}
export default DrawerNavigator;

