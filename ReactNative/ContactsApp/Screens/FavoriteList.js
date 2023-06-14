import React ,{useState,useEffect}from 'react';
import { View } from 'react-native';
import {openDatabase} from 'react-native-sqlite-storage';
import Header from '../Components/Header';
import Contact from '../Components/Contact';
let db = openDatabase({name: 'ContactsDatabase.db'});
function FavoriteList({navigation}) {
  const [userList, setUserList] = useState([]);
  useEffect(() => {
    getData()
  });
  const getData = () => {
    var temp = [];
    db.transaction(tx => {
      tx.executeSql('SELECT * FROM table_contact WHERE favorite==1 ORDER BY LOWER(name) ASC', [], (tx, results) => {
        for (let i = 0; i < results.rows.length; ++i)
        {
            temp.push(results.rows.item(i));
        }
        setUserList(temp)
      });
    });
};
  return (
    <View style={{flex: 1,}}>
     <Header title="Favorite Contact List" isHome="true" navigation={navigation}/>
      <View style={{margin:10}}>
        <Contact data={userList} navigation={navigation}/>
      </View>
    </View>
  );
}

export default FavoriteList;
