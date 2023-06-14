import React,{useEffect,useState} from 'react';
import {  View ,StyleSheet} from 'react-native';
import Header from '../Components/Header';
import Contact from '../Components/Contact';
import Icons from 'react-native-vector-icons/Ionicons';
import {openDatabase} from 'react-native-sqlite-storage';
import Search from '../Components/Search';
let db = openDatabase({name: 'ContactsDatabase.db'});

function ContactList({navigation}) {
  const [searchName,setSearchName]=useState("");
  const [userList, setUserList] = useState([]);
  useEffect(() => {
    getData()
  });
  const getData = () => {
    var temp = [];
    db.transaction(tx => {
      tx.executeSql('SELECT * FROM table_contact ORDER BY LOWER(name) ASC', [], (tx, results) => {
        for (let i = 0; i < results.rows.length; ++i)
        {
            temp.push(results.rows.item(i));
        }
        setUserList(temp)
      });
    });
};
  
  const filterData = (data) => {
    return data.filter((item) =>
      item.name.toLowerCase().includes(searchName.toLowerCase())
   );
  }
  return (
    <View style={styles.container}>

      <Header title="Contact List" isHome="true" navigation={navigation}/>

      <Search onChangeSearchText={(val)=>setSearchName(val)}  searchName={searchName}/>

      <View style={styles.listItems}>
        <Contact data={filterData(userList)} navigation={navigation}/>
      </View>

      <View style={styles.addButton}>
        <Icons name='add-circle' size={55} color='gray' onPress={()=>{
          navigation.navigate('AddEditContact',{ data: {}})
        }}/>
      </View>

    </View>
   
  );
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  addButton:{
    height: 62,
    flexDirection: 'row', 
    justifyContent: 'flex-end', 
    marginRight:10,
  },
  listItems:{
   height:'68%'
  },
 
});


export default ContactList;
