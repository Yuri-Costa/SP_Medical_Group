import React, {Component} from 'react';

import logo from "../../assets/img/logo.png";
import instagram from '../../assets/img/instagram.png'
import twitter from '../../assets/img/twitter.png'
import youtube from '../../assets/img/youtube.png'
import facebook from '../../assets/img/facebook.png'


import '../../assets/Css/footer.css';

class footer extends Component{
    render(){
        return(
            <footer>
                <div className="icones">
                <img src={instagram} alt="logo do instagra" />
                <img src={facebook} alt="logo do facebook" />
                <img src={twitter}  alt="logo do twitter" />
                <img src={youtube} alt="logo do youtube" />
                </div>
                <div className="center">
                <img src={logo} alt="logo do SPMG" />
                <p>© Copyright 2021, Senai de Informatica.</p>
                </div>
                <div className="news">
                <p>RECEBA NOSSOS EMAILS</p>
                <input type="email" name="Email" id="news"/>
                </div>
            </footer>
        )
    }
}
export default footer;