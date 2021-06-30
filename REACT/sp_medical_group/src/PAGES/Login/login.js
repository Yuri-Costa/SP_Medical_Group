import React, {Component} from 'react';
import axios from 'axios';
import {parseJwt, usuarioAutenticado} from '../../Services/auth';
import logo from '../../assets/img/logo.png';
import '../../assets/Css/login.css';

class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : '',
            errorMessage : '',
            isLoading : false
        }
    };

    //------------------------------------------------------------------------------------------------------
    //CHAMA A API PARA REALIZAR O LOGIN
    efetuaLogin = (event) => {
        //IGNORA O COMPORTAMENTO PADRÃO
        event.preventDefault();

        //TIRA A FRASE DE ERRO E DEFINE QUE A REQUISIÇÃO ESTA EM ANDAMENTO
        this.setState({errorMessage : '', isLoading : true})

        //DEFINE A URL E O CORPO DA REQUISIÇÃO
        axios.post('http://localhost:5000/api/login', {
            email : this.state.email,
            senha : this.state.senha,
        })

        .then(resposta => {
            if(resposta.status === 200){
                //ARMAZENA NO LOCALSTORAGE O TOKEN
                localStorage.setItem('SPMG_token', resposta.data.token)

                //EXIBE NO CONSOLE O NOSSO TOKEN 
                //SE CLICAR EM CIMA ELE MOSTRA A DIVISÃO DO TOKEN TAMBEM
                //DA PRA "VALIDAR" ELE NO JWT.IO
                console.log('Meu Token é :' + resposta.data.token)

                //DEFINE QUE A REQUISIÇÃO TERMINOU
                this.setState({isLoading : false})

                console.log(parseJwt());

                //EXIBE NO CONSOLE APENAS O TIPO DE USUARIO
                console.log(parseJwt().role);

                if(parseJwt().role === "1"){
                    console.log(this.props);
                    console.log(usuarioAutenticado());
                    this.props.history.push('/minhas')
                }
                else if(parseJwt().role === "2"){
                    console.log(this.props);
                    console.log(usuarioAutenticado());
                    this.props.history.push('/MedicoConsulta')
                }
                else if(parseJwt().role === "3"){
                    console.log(this.props);
                    console.log(usuarioAutenticado());
                    this.props.history.push('/gerenciador')
                }
                else{
                    this.props.history.push('/consulta')
                }

            }
        })

        //CASO O USUARIO DIGITE O EMAIL OU SENHA ERRADOS, NÓS PERSONALIZAMOS UMA MENSAGEM
        .catch(() => {
            //MENSAGEM PERSONALIZADA QUE CRIAMOS:
            this.setState({errorMessage : 'E-mail ou senha invalidos ! Tente novamente. ', isLoading : false })
        })
    }

    //FUNÇÃO QUE ATUALIZA O STATE DE ACORDO COM INPUT
    //PODE SER REUTILIZADA
    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value})
    }

    render(){
        return(
            <div>
                <section className = "entrar">

                <main>

                    <form  className="box" onSubmit={this.efetuaLogin}>
                        <img src={logo} className="icone__login" alt="logo do SPMG" />
                        <input type="text" name="email" placeholder="Email" value={this.state.email} onChange={this.atualizaStateCampo}/>
                        <input type="password" name="senha" placeholder="Senha"value={this.state.senha} onChange={this.atualizaStateCampo}/>

                        <p style={{color : 'red'}}>{this.state.errorMessage}</p>

                        {
                            
                            this.state.isLoading === true &&
                            <button type="submit" className="logar" disabled>Carregando...</button>
                            
                        }

                        {
                            this.state.isLoading === false &&
                            <button type="submit" className="logar" disabled = { this.state.email === '' || this.state.senha === '' ? 'none' : ''}>Login</button>
                            
                            
                        }
                    </form>
                </main>
                </section>
                    
            </div>
            
        )
    }
};
export default Login;