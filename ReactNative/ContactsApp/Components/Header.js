import React,{useEffect,useState} from "react";
import {View,Text,TouchableOpacity,StyleSheet} from 'react-native';
import Icons from 'react-native-vector-icons/Ionicons';
function Header({title,isHome,navigation,onPress,favorite}){
    const [fav,setfav]=useState(favorite)
    useEffect(()=>{
        setfav(favorite)
    },[favorite,title])
    const handleFav=()=>{
        console.log( fav);
        onPress(!fav)
        setfav(!fav)
    }
    return(
        <View style={styles.container}>
            {
                isHome? 
                <TouchableOpacity style={{width:'15%'}} onPress={()=>{navigation.openDrawer()}}>
                    <Icons name="menu-sharp" size={30} style={{ marginLeft:18}}/> 
                </TouchableOpacity> :
                <TouchableOpacity style={{width:'15%'}} onPress={()=>{navigation.goBack()}}>
                    <Icons name="arrow-back" size={35} style={{marginLeft:18}}/> 
                </TouchableOpacity>
            }
            
            <View style={{width:'70%'}}>
                <Text style={{fontWeight:'bold',fontSize:25,alignSelf:'center'}}>{title}</Text>
            </View>
            {
                isHome ? 
                null:
                <TouchableOpacity style={{width:'15%'}} onPress={()=>handleFav()}>
                    {
                    fav? 
                    <Icons name="star" size={30} style={{alignSelf:'center'}}/>
                    :
                    <Icons name="star-outline" size={30} style={{alignSelf:'center'}}/>
                    }                       
                </TouchableOpacity>
            }
        </View>
    )
}
const styles = StyleSheet.create({
    container: {
      width:'100%',
      flexDirection: 'row',
      alignItems: 'center',
      padding: 10,
    }
})


export default Header;