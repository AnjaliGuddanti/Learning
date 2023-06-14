import React,{useContext,useState} from 'react';
import {store} from './AddPosts';
function Alert(props) {
    const [showAlert, setshowAlert] = useContext(store);
    console.log(showAlert);
    return (
            <div className="px-5">
                <div className="alert alert-success">
                    <strong>Well done!</strong> Post Added...{showAlert}
                </div>       
            </div>
    );
}

export default Alert;