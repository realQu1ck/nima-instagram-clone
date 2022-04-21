import React from 'react'
import { Text, View } from 'react-native'

export default class HorizontalLineText extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            style: props.style,
            text: props.text
        }
    }

    render() {
        return (
            <View style={this.props.style}>
                <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                    <View style={{ flex: 1, height: 1, backgroundColor: 'gray' }} />
                    <View>
                        <Text style={{ width: 50, textAlign: 'center' }}>{this.state.text}</Text>
                    </View>
                    <View style={{ flex: 1, height: 1, backgroundColor: 'gray' }} />
                </View>
            </View>
        );
    }
}