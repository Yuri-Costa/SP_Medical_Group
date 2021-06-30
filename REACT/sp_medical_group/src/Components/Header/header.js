import React, {Component} from 'react';

import logo from "../../assets/img/logo.png";

import '../../assets/Css/header.css';
import { Link } from 'react-router-dom';

class header extends Component{
    render(){
        return(
            <header>
                <div className="container cabecalho">
                    <div>
                    <img src={logo} className="icone__login" alt="logo do SPMG" />
                    </div>
                    <nav>
                    <ul>
                        <li><Link to ="/">INÍCIO</Link></li>
                        <li><Link to ="/">HISTÓRIA</Link></li>
                        <li><Link to ="/">LOCALIZAÇÃO</Link></li>
                        <li><Link to ="/">ESPECIALIDADES</Link></li>
                        <li><Link to ="/login">PLANOS</Link></li>
                        <li><i class="fas fa-user-alt"></i><Link to ="/">LOGIN</Link></li>
                        <div className="login">
                            {/* <li><p><a href="#">CONTATOS</a></p></li> */}
                        </div>
                </ul>
                    </nav>
                </div>
            </header>       
        )
    }
}
export default header;