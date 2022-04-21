import React from 'react';
import {
    View,
    StyleSheet, TextInput, Text,
    Image, TouchableOpacity
} from 'react-native';
import HorizontalLineText from '../../components/HorizontalLineText';
import InputText from '../../components/InputText';
import LinkButton from '../../components/LinkButton';
import TextButton from '../../components/TextButton';

class LoginPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            
        }
    }

    render() {
        return (
            <View style={styles.container}>
                <View style={styles.firstHalf}>
                    <Image source={require('../../../assets/instagram-text-logo.png')} style={styles.insLogo} resizeMode={'stretch'}/>
                    <InputText placeholder='Username' style={styles.inpText}/>
                    <InputText placeholder='Password' style={styles.inpText} isPass={true} />
                    <LinkButton text={'Forget Password ?'} style={styles.btnLink} onClick={() => console.log("Hi")} />
                    <TextButton style={styles.btnLogin} text={'Login'}/>
                    <HorizontalLineText style={styles.hline} text={'OR'} />
                    <TextButton style={styles.btnLogin} text={'Continue With Facebook'}/>
                </View>
                <View style={styles.signUpLink}>
                    <Text>Don't have an account ? </Text>
                    <LinkButton text={'Sign Up'} onClick={() => this.props.navigation.navigate('ChooseUsername')}/>
                </View>
            </View>
        );
    }
}

const styles = StyleSheet.create({
    container: {
        backgroundColor: 'white',
        flex: 1,
    },
    firstHalf:{
        flex:1,
        justifyContent: 'center',
    },
    insLogo: {
        width: 200,
        height: 80,
        justifyContent: 'center',
        alignSelf: 'center'
    },
    inpText: {
        marginTop: 10,
        marginRight: 10,
        marginLeft: 10,
    },
    btnLogin: {
        marginTop: 10,
        marginLeft: 10,
        marginRight: 10,
    },
    btnLink: {
        textAlign: 'right',
        alignSelf:'flex-end',
        marginTop: 10,
        marginRight: 10
    },
    hline: {
        marginTop: 15,
        marginRight: 10,
        marginLeft: 10
    },
    signUpLink:{
        textAlign:'center',
        alignContent:'center',
        alignSelf:'center',
        flexDirection:'row',
        marginBottom:10
    }
})

export default LoginPage;