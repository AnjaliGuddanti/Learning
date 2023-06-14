import React,{useEffect} from "react"
import { TouchableOpacity,View,Animated,Text,TextInput,StyleSheet } from "react-native";
import Icons from 'react-native-vector-icons/Ionicons';
const Search=({ onChangeSearchText ,searchName})=>{
    return(
      <View style={styles.searchWrapperStyle}>
      <Icons size={24} name="search" color="black" style={styles.iconStyle} />
      <TextInput
        placeholder="Search"
        placeholderTextColor="black"
        style={styles.searchInputStyle}
        value={searchName}
        onChangeText={(newText) => {
            onChangeSearchText(newText)
      }}
      />
      {searchName=='' ? null:
        <Icons
        size={24}
        name="close"
        color="black"
        style={styles.iconStyle}
        onPress={() => {
            onChangeSearchText("");
        }}
      />
      }  
    </View>
    )
}
const styles = StyleSheet.create( {
    searchWrapperStyle: {
        height: 56,
        borderWidth:0.7,
        borderRadius:10,
        marginHorizontal:28,
        marginVertical:20,
        flexDirection: "row",
        justifyContent: "space-between",
      },
      iconStyle: {
        alignSelf:'center',
        marginHorizontal: 8,
      },
      searchInputStyle: {
        flex: 1,
        fontSize: 18,
        margin: 0,
      },
})
export default Search;