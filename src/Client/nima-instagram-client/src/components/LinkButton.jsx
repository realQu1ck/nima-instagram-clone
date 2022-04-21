import React , {Component} from 'react'
import { Text, StyleSheet, TouchableOpacity } from 'react-native'

export default class LinkButton extends Component
{
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
            <TouchableOpacity style={this.props.style} onPress={this.props.onClick}>
                <Text style={styles.txtLink}>{this.state.text}</Text>
            </TouchableOpacity>
        );
    }
}

const styles = StyleSheet.create({
    txtLink: {
        color: 'blue'
    }
})