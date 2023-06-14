import React,{useState} from "react"
import { TouchableOpacity,View,Modal,Text,StyleSheet } from "react-native";
import ImagePickerCrop from 'react-native-image-crop-picker';
const UploadImageModal=({ trackImage })=>{
  const [showModal, setShowModal] = useState(false);
  const PickImageFromGallery=()=>{
    setShowModal(false)
    ImagePickerCrop.openPicker({
      width: 300,
      height: 400,
      cropping: true
    }).then(image => {
      console.log(image);
      trackImage(image.path)
    }).catch(error=>{
      console.log(error)
    });
  }
  const PickImageFromCamera=()=>{
    setShowModal(false)
      ImagePickerCrop.openCamera({
        width: 300,
        height: 400,
        cropping: true,
      }).then(image => {
        console.log(image);
        trackImage(image.path)
      }).catch(error=>{
        console.log(error)
      });
  }   
    return(
      <View>
          <TouchableOpacity
          style={styles.modalButton}
          onPress={() => {
            setShowModal(true)
          }}>
          <Text style={styles.modalButtonTitle}>Upload Image </Text>
          </TouchableOpacity>
      
        <Modal transparent={true} visible={showModal}>
          <View style={styles.centeredView}>
              <View style={styles.modalView}>
                <View style={{alignItems: 'center'}}>
                  <Text style={styles.modalTitle}>Upload Photo</Text>
                  <Text style={styles.modalSubtitle}>Choose Profile Picture</Text>
                </View>
                <TouchableOpacity style={styles.modalButton} onPress={() => PickImageFromCamera()} >
                  <Text style={styles.modalButtonTitle}>Take Photo</Text>
                </TouchableOpacity>
                <TouchableOpacity style={styles.modalButton} onPress={() => PickImageFromGallery()}>
                  <Text style={styles.modalButtonTitle}>Choose From Gallery</Text>
                </TouchableOpacity>
                <TouchableOpacity
                  style={styles.modalButton}
                  onPress={() => setShowModal(false)}>
                  <Text style={styles.modalButtonTitle}>Cancel</Text>
                </TouchableOpacity>
              </View>
              </View>
        </Modal>
      </View>
    )
}
const styles = StyleSheet.create({
  centeredView: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
  },
  modalView: {
    backgroundColor: "white",
    padding: 40,
    borderRadius: 20,
    shadowColor: "black",
    elevation: 5,
  },
 
  modalTitle: {
    fontSize: 27,
    height: 35,
  },
  modalSubtitle: {
    fontSize: 14,
    color: 'gray',
    height: 30,
    marginBottom: 10,
  },
  modalButton: {
    padding: 13,
    borderRadius: 10,
    backgroundColor: 'gray',
    alignItems: 'center',
    marginVertical: 7,
  },
  modalButtonTitle: {
    fontSize: 17,
    fontWeight: 'bold',
    color: 'white',
  },
})
export default UploadImageModal;