import { Component} from 'react';

import Cabecalho from '../../Components/Header/header'
import Rodapé from '../../Components/Footer/footer'

import '../../assets/Css/CadastraMedico.css'

class CadastraMedico  extends Component{
    constructor(props){
        super(props);
        this.state = {
            idEspecialidade: '',
            idUsuario : 2,
            idClinica: '',
            nome: '',
            crm: '',
        }
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA idEspecialidade

    AtualizaIdEspecialidade = async(event) => {
        await this.setState({idEspecialidade : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA idUsuario

    AtualizaIdUsuario = async(event) => {
        await this.setState({nome : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA idClinica

    AtualizaIdClinica = async(event) => {
        await this.setState({idClinica : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA nome

    AtualizaNome = async(event) => {
        await this.setState({nome : event.target.value})
    };

    //---------------------------------------------------------------------------------------------------
   
    //ATUALIZA crm

    AtualizaCrm = async(event) => {
        await this.setState({crm : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
   

    //CADASTRA UM NOVO MEDICO

    cadastraNovoMedico = (event) => {
        //IGNOROU O COMPORTAMENTO PADRÃO DO NAVEGADOR
        event.preventDefault();

        fetch('http://localhost:5000/api/medicos', {
                
            //DEFINE O METODO DA REQUISIÇÃO COMO POST
            method : 'POST',

            //CONVERTE A RESPOSTA RECEBIDA EM JSON
            body : JSON.stringify ({idEspecialidade : this.state.idEspecialidade, idUsuario : this.state.idUsuario, idClinica : this.state.idClinica, nome : this.state.nome, crm : this.state.crm}),
            
            //DEFINE O CABEÇALHO DA REQUISIÇÃO
            headers : {
            "Content-Type" : "application/json"
            }
        });
    }

//---------------------------------------------------------------------------------------------------
    limparCampos = () => {
        this.setState({
            idEspecialidade: 0,
            idUsuario : 2,
            idClinica: 0,
            nome: '',
            crm: '',
        })
    }

    //---------------------------------------------------------------------------------------------------

    logout = () => {
        localStorage.removeItem('SPMG_token')
    }
//---------------------------------------------------------------------------------------------------
    render(){ 
        return(
            <main>
                <Cabecalho/>
                <section className="Cadastro">
                <a onClick={this.logout} href="/"><h3>Sair</h3></a>
                <h2>CADASTRO DE MEDICO</h2>
                
                    <form onSubmit={this.cadastraNovoMedico} className="formulario">
                <div>
                    <input value = {this.state.idUsuario} type="number"></input>

                    <input placeholder="Digite o idEspecialidade do medico" value = {this.state.idEspecialidade} onChange={this.AtualizaIdEspecialidade}type="number"></input>

                    <input placeholder= "Digite o idClinica do medico" value = {this.state.idClinica} onChange={this.AtualizaIdClinica} type="number"></input>

                    <input placeholder="Digite o nome do medico" value = {this.state.nome} onChange={this.AtualizaNome}type="text"></input>

                    <input placeholder="Digite o crm do medico" value = {this.state.crm} onChange={this.AtualizaCrm} type="number"></input>

                    
                    {
                        <button type='submit' disabled={this.state.idUsuario === '' && this.state.nome === '' && this.state.idEspecialidade === '' && this.state.idClinica === '' && this.state.crm === '' ? 'none' : ''}>Cadastrar</button>
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
export default CadastraMedico;