import React, { Component } from 'react'
import { StyleSheet, TextInput, View } from 'react-native'

export default class InputText extends Component {
    constructor(props) {
        super(props);
        this.state = {
            text: props.text,
            style: props.style,
            isPass: props.isPass,
            placeholder: props.placeholder
        }
    }
    render() {
        return (
            <View style={this.state.style}>
                <TextInput placeholder={this.state.placeholder}
                    secureTextEntry={this.state.isPass === true ? true : false}
                    style={styles.inpStyle} 
                    onChangeText={inp => this.setState({text: inp})}/>
            </View>
        );
    }
}

const styles = StyleSheet.create({
    inpStyle: {
        backgroundColor: '#F5F5F5',
        borderColor: '#F5F5F5',
        height: 50,
        borderRadius: 5,
        borderWidth: 1,
        padding: 5
    }
})