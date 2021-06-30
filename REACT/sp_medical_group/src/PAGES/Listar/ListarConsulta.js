import { Component} from 'react';
import '../../assets/Css/Listar.css'
import { Link } from 'react-router-dom';


import logo from "../../assets/img/logo.png";
import instagram from '../../assets/img/instagram.png'
import twitter from '../../assets/img/twitter.png'
import youtube from '../../assets/img/youtube.png'
import facebook from '../../assets/img/facebook.png'

class ListaConsultas  extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaConsulta : [],
            idConsultaAlterado : 0,
            idPac : 0,
            idMed : 0,
            idSit: 0,
            data : Date
        }
    }

    //---------------------------------------------------------------------------------------------------

    buscarConsultas = () => {
        //METODO FEITO PARA SABER SE AO CARREGAR A PAGINA, É CARREGADA A FUNÇÃO DE BUSCAR CONSULTA
        console.log('Metodo funcionando')

        //CHAMA A API USANDO O FETCH
        fetch('http://localhost:5000/api/consultas/paciente')
        
        //TRANSFORMA A RESPOSTA EM JSON
        //DEFINE O TIPO DE DADO DO RETORNO COMO JSON
        .then(resposta => resposta.json())

        //PEGA OS DADOS DA RESPOSTA E COLOCA DENTRO DO ARRAY
        .then(dados => this.setState({ listaConsulta : dados }))
        
        //CASO OCORRA UM ERRO, MOSTRA NO CONSOLE DO NAVEGADOR
        .catch((erro) => console.log(erro))
    }

    //---------------------------------------------------------------------------------------------------

    //RECEBE A CONSULTA DA LISTA
    buscarConsultaPorId = (consulta) => {
        this.setState({
            idConsultaAlterado : consulta.idConsulta,
            idPac : consulta.idPaciente,
            idMed : consulta.idMedico,
            idSit : consulta.idSituacao,
            data : consulta.dataConsulta
        }, () => {
            console.log(
                'A consulta ' + consulta.idConsulta + ' foi selecionado,',
                'agora o valor do state idConsultaAlterado é: ' + this.state.idConsultaAlterado,
                'e o valor do state id paciente é:' + this.state.idPac
            );
        });
    };

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA O ID DO PACIENTE

    AtualizaIdPac = async(event) => {
        await this.setState({idPac : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA O ID DO MEDICO

    AtualizaidMed = async(event) => {
        await this.setState({idMed : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA O ID DA SITUAÇÃO

    AtualizaidSit = async(event) => {
        await this.setState({idSit : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA A DATA

    Atualizadata = async(event) => {
        await this.setState({data : event.target.value})
    };

    //---------------------------------------------------------------------------------------------------

    //CADASTRA UMA NOVA CONSULTA

    cadastranovaconsulta = (event) => {
        //IGNOROU O COMPORTAMENTO PADRÃO DO NAVEGADOR
        event.preventDefault();

        if(this.state.idConsultaAlterado !== 0){   
            //CHAMA A API USANDO FETCH
            fetch('http://localhost:5000/api/Consultas/' + this.state.idConsultaAlterado, {

            //DEFINE O METODO DA REQUISIÇÃO COMO PUT
            method: 'PUT',

            //CONVERTE A RESPOSTA RECEBIDA EM JSON
            body : JSON.stringify({idPaciente : this.state.idPac, idMedico : this.state.idMed, idSituacao : this.state.idSit, dataConsulta : this.state.data}),

            //DEFINE O CABEÇALHO DA REQUISIÇÃO
            Headers : {
                'Content-Type' : 'application/json'
            }
            })

            .then(resposta => {
                if(resposta.status === 204){
                    console.log('Consulta ' + this.state.idConsultaAlterado + ' atualizado')
                }
            })
            .then(this.buscarConsultas)
            .then(this.limparCampos)
        }
        else
        {        
            //CHAMA A API USANDO FETCH
            fetch('http://localhost:5000/api/consultas', {
                
            //DEFINE O METODO DA REQUISIÇÃO COMO POST
            method : 'POST',
                
            //CONVERTE A RESPOSTA RECEBIDA EM JSON
            body : JSON.stringify ({idPaciente : this.state.idPac, idMedico : this.state.idMed, idSituacao : this.state.idSit, dataConsulta : this.state.data }),

            //DEFINE O CABEÇALHO DA REQUISIÇÃO
            headers : {
            "Content-Type" : "application/json"
            }
        })
            .then(console.log('Consulta Cadastrada'))
            .catch(erro => console.log(erro))
    }
}
    //---------------------------------------------------------------------------------------------------
    //FUNÇÃO RESPONSAVEL POR EXCLUIR UM CONSULTA

    excluirConsulta = (consulta) => {
        console.log('O tipo de evento ' + consulta.idConsulta + ' foi selecionado')

        //CHAMA A API PASSANDO O ID DO EVENTO SELECIONADO NA URL
        fetch('http://localhost:5000/api/consultas/' + consulta.idConsulta, {

            //DEFINE O METODO DA REQUISIÇÃO
            method : 'DELETE'
        })

        .then(resposta => {
            if(resposta.status === 204){
                console.log('Consulta' + consulta.idConsulta + 'foi excluida')
            }
        })

        .catch(erro => console.log(erro))

        .then(this.buscarConsultas)
    }


    //---------------------------------------------------------------------------------------------------

    limparCampos = () => {
        this.setState({
            idPac : 0,
            idMed : 0,
            idSit: 0,
            data : Date
        })
    }

    //---------------------------------------------------------------------------------------------------

    //CHAMA A FUNÇÃO BUSCAR CONSULTA ASSIM QUE O COMPONENTE FOR RENDERIZADO
    componentDidMount(){
        this.buscarConsultas();
    }

    //---------------------------------------------------------------------------------------------------

    render(){ 
        return(

            <main>
                
                <section className="tabela">
                <header>
                <div className="container cabecalho">
                    <div>
                    <img src={logo} className="icone__login" alt="logo do SPMG" />
                    </div>
                    <nav>
                    <ul>
                        <li><Link to="/" title="voltar para a página inicial">INÍCIO</Link></li>
                        <li><Link to="#" title="Ir até a sessão de história das partidas">HISTÓRIA</Link></li>
                        <li><Link to="#" title="Ir até a sessão de localização das unidades do SP Medical Group">LOCALIZAÇÃO</Link></li>
                        <li><Link to="#" title="Ir até a sessão de especialidades">ESPECIALIDADES</Link></li>
                        <li><Link to="#" title="Ir até a sessão de PLANOS">PLANOS</Link></li>
                        <li><Link to="/Login"><i className="fas fa-user-alt"></i> LOGIN</Link></li>
                        <div className="login">
                            <li><p><Link to="/Login">CONTATOS</Link></p></li>
                        </div>
                </ul>
                    </nav>
                </div>
            </header> 
            <section className="Cadastro">
                        <h2>CADASTRO CONSULTA</h2>
                            <form onSubmit={this.cadastranovaconsulta}>
                    <div>
                    <input placeholder= "Digite o id do paciente" value = {this.state.idPac} onChange={this.AtualizaIdPac} type="number" className="gui1"></input>
                    <input placeholder="Digite o id do medico" value = {this.state.idMed} onChange={this.AtualizaidMed}type="number" className="gui1"></input>
                    <input placeholder="Digite o id da situação" value = {this.state.idSit} onChange={this.AtualizaidSit} type="number" className="gui1"></input>
                    <input placeholder="Digite a data da consulta" value = {this.state.data} onChange={this.Atualizadata} type="date" className="gui1"></input>
                    
                    {
                        <button type='submit' disabled={this.state.idMed === ''&& this.state.idPac === ''&& this.state.idSit===''&& this.state.data === '' ? 'none' : ''}>
                            {
                                this.state.idConsultaAlterado === 0 ? 'Cadastrar' : 'Atualizar'
                            }
                        </button>
                    }
                        <button onClick={this.limparCampos}>
                            Cancelar
                        </button>
                </div>
            </form> 

            {
                this.state.idConsultaAlterado !== 0 &&
                <div>
                    <p>A consulta {this.state.idConsultaAlterado} está sendo editada</p>
                    <p>Caso queira cancelar clique no botão 'Cancelar'</p>
                </div>
            }
        </section>   
                    <h2>LISTA DE CONSULTAS</h2>
                    <table>
                        <tbody className="identificar">
                            {
                                this.state.listaConsulta.map( (consulta) => {
                                    return (
                                        <div className="identificador">
                                            
                                            <p>IdConsulta: {consulta.idConsulta}</p>
                                            <p>idPaciente: {consulta.idPaciente} </p>
                                            <p>IdMedico: {consulta.idMedico}</p>
                                            <p>NomePaciente: {consulta.idPacienteNavigation.nome} </p>
                                            <p>Telefone: {consulta.idPacienteNavigation.telefone} </p>
                                            <p>Num Cartão: {consulta.idPacienteNavigation.numCartao} </p>
                                            <p>Situação: {consulta.idSituacao}</p>
                                            <p>Data Consulta: {consulta.dataConsulta}</p>
                                            <p>Ações: <button onClick={() => this.buscarConsultaPorId(consulta)}>Editar</button> <button onClick={() => this.excluirConsulta(consulta)}>Excluir</button> </p>
                                        </div>
                                    )
                                } )
                            }
                        </tbody>
                    </table>
                </section>
                
        <footer>
                <div className="icones">
                <img src={instagram} alt="logo do instagra" />
                <img src={facebook} alt="logo do facebook" />
                <img src={twitter}  alt="logo do twitter" />
                <img src={youtube} alt="logo do youtube" />
                </div>
                <div className="center">
                <img src={logo} alt="logo do SPMG" />
                <p>© Copyright 2021 Guilherme André, Senai de Informatica.</p>
                </div>
                <div className="news">
                <p>RECEBA NOSSOS EMAILS</p>
                <input type="email" name="Email" id="news"/>
                </div>
            </footer>
        </main>
        )
    }
}
export default ListaConsultas;