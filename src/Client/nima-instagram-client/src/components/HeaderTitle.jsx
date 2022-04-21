import React from 'react'
import { View, Image, TouchableOpacity, StyleSheet, Text } from 'react-native'

export default class HeaderTitle extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            style: props.style,
            title: props.title,
            onClick: props.onClick
        }
    }

    render() {
        return (
            <View style={this.state.style}>
                <View style={styles.container}>
                    <Text style={styles.txtTitle}>{this.state.title}</Text>
                    <View style={{ flex: 1 }} />
                    <TouchableOpacity style={styles.btnBack} onPress={this.state.onClick}>
                        <Image source={require('../../assets/back.png')} style={styles.imgBack} />
                    </TouchableOpacity>
                </View>
            </View>
        );
    }
}

const styles = StyleSheet.create({
    fcontainer: {
        width: '100%',
        height: 80,
    },
    container: {
        width: '100%',
        height: 40,
        flexDirection: 'row-reverse'
    },
    imgBack: {
        width: 40,
        height: 40,
    },
    btnBack: {
        width: 80,
        height: 80,
        flex: 0,
        marginRight: 10,
        marginLeft: 10
    },
    txtTitle: {
        color: 'black',
        fontSize: 25,
        textAlignVertical: 'center',
        marginRight: 10,
        marginLeft: 10
    }
})