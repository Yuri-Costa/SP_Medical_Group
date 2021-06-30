import { Component} from 'react';

import Cabecalho from '../../Components/Header/header'
import Rodapé from '../../Components/Footer/footer'

import '../../assets/Css/CadastraMedico.css'

class CadastraPaciente  extends Component{
    constructor(props){
        super(props);
        this.state = {
            idUsuario : 1,
            nome : '',
            rg : '',
            telefone: '',
            cpf: '',
            numCartao : ''
        }
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA idUsuario

    AtualizaIdUsuario = async(event) => {
        await this.setState({idUsuario : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA NOME

    AtualizaNome = async(event) => {
        await this.setState({nome : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA RG

    AtualizaRg = async(event) => {
        await this.setState({rg : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA A TELEFONE

    AtualizaTelefone = async(event) => {
        await this.setState({telefone : event.target.value})
    };

    //---------------------------------------------------------------------------------------------------
   
    //ATUALIZA CPF

    AtualizaCpf = async(event) => {
        await this.setState({cpf : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA A numCartao

    AtualizanumCartao = async(event) => {
        await this.setState({numCartao : event.target.value})
    };

    //---------------------------------------------------------------------------------------------------

    //CADASTRA UM NOVA USUARIO

    cadastraNovoPaciente = (event) => {
        //IGNOROU O COMPORTAMENTO PADRÃO DO NAVEGADOR
        event.preventDefault();

        fetch('http://localhost:5000/api/pacientes', {
                
            //DEFINE O METODO DA REQUISIÇÃO COMO POST
            method : 'POST',
                
            //CONVERTE A RESPOSTA RECEBIDA EM JSON
            body : JSON.stringify ({idUsuario : this.state.idUsuario, nome : this.state.nome, rg : this.state.rg,  telefone : this.state.telefone, cpf : this.state.cpf, numCartao : this.state.numCartao }),
            
            //DEFINE O CABEÇALHO DA REQUISIÇÃO
            headers : {
            "Content-Type" : "application/json"
            }
        });
    }

//---------------------------------------------------------------------------------------------------
    limparCampos = () => {
        this.setState({
            idUsuario : 1,
            nome : '',
            rg : '',
            telefone: '',
            cpf: '',
            numCartao : ''
        })
    }
//---------------------------------------------------------------------------------------------------
    render(){ 
        return(
            <main>
                <Cabecalho/>
                <section className="Cadastro">
                <h2>CADASTRO DE PACIENTE</h2>
                    <form onSubmit={this.cadastraNovoPaciente} className="formulario">
                <div>
                    <input value = {this.state.idUsuario} type="number"></input>

                    <input placeholder="Digite o nome do paciente" value = {this.state.nome} onChange={this.AtualizaNome}type="text"></input>

                    <input placeholder= "Digite o rg do paciente" value = {this.state.rg} onChange={this.AtualizaRg} type="text"></input>

                    <input placeholder="Digite o telefone do paciente" value = {this.state.telefone} onChange={this.AtualizaTelefone}type="number"></input>

                    <input placeholder="Digite o cpf do paciente" value = {this.state.cpf} onChange={this.AtualizaCpf} type="text"></input>

                    <input placeholder="Digite o Numero do cartao do paciente" value = {this.state.numCartao} onChange={this.AtualizanumCartao} type="text"></input>
                    
                    {
                        <button type='submit' disabled={this.state.idUsuario === '' && this.state.nome === '' && this.state.rg === '' && this.state.telefone === '' && this.state.cpf ==='' && this.state.numCartao === '' ? 'none' : ''}>Cadastrar</button>
                    }
                        <button onClick={this.limparCampos}>
                            Cancelar
                        </button>
                </div>
            </form> 
                </section>
                <Rodapé/>
            </main>
        )}
}
export default CadastraPaciente;