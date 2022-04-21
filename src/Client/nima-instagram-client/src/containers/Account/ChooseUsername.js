import React from 'react'
import {
    View, Text,
    StyleSheet, TouchableOpacity,
    StatusBar
} from 'react-native'
import HeaderTitle from '../../components/HeaderTitle';


export default class ChooseUsername extends React.Component {
    render() {
        return (
          <View style={styles.container}>
              <StatusBar backgroundColor={'transparent'}/>
              <HeaderTitle title={null} onClick={() => this.props.navigation.pop()}/>
              <View style={styles.centerContainer}>
                
              </View>
              <View>

              </View>
          </View>
     );
    }
}

const styles = StyleSheet.create({
    container:{
        backgroundColor:'white',
        flex:1
    },
    centerContainer:{
        flex:1,
        justifyContent:'center'
    }
})