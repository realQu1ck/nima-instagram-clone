import React, { Component } from 'react'
import { Text, StyleSheet, TouchableOpacity, View } from 'react-native'

export default class TextButton extends Component {
    constructor(props) {
        super(props);
        this.state = {
            text: props.text,
            style: props.style,
            onClick: props.onClick
        }
    }
    render() {
        return (
            <View style={this.state.style}>
                <TouchableOpacity onPress={this.state.onClick} style={styles.btnStyle}>
                    <Text style={styles.txtStyle}>{this.state.text}</Text>
                </TouchableOpacity>
            </View>
        );
    }
}

const styles = StyleSheet.create({
    btnStyle: {
        backgroundColor: '#3949AB',
        justifyContent: 'center',
        borderRadius: 5,
        height: 40
    },
    txtStyle: {
        color: 'white',
        textAlign: 'center'
    },
})