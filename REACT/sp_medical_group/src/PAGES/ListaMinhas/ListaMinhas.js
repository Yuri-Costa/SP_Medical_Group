import { Component} from 'react';
import Cabeçalho from '../../Components/Header/header'
import Rodapé from '../../Components/Footer/footer'

import '../../assets/Css/minhas.css'



    class ListaMinhas extends Component{
        constructor(props){
            super(props);
            this.state = {
                ListaMinha : []
            }
        }

    //---------------------------------------------------------------------------------------------------

    ListaMinhasConsultas = () => {

        //METODO FEITO PARA SABER SE AO CARREGAR A PAGINA, É CARREGADA A FUNÇÃO DE BUSCAR CONSULTA
        console.log('Metodo funcionando')

        //CHAMA A API USANDO O FETCH
        fetch('http://localhost:5000/api/consultas/minhas', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('SPMG_token')
            }
        })

        //TRANSFORMA A RESPOSTA EM JSON
        //DEFINE O TIPO DE DADO DO RETORNO COMO JSON
        .then(resposta => resposta.json())

        //PEGA OS DADOS DA RESPOSTA E COLOCA DENTRO DO ARRAY
        .then(dados => this.setState({ListaMinha : dados}))
        
        //CASO OCORRA UM ERRO, MOSTRA NO CONSOLE DO NAVEGADOR
        .catch((erro) => console.log(erro))

    }
    logout = () => {
        localStorage.removeItem('SPMG_token')
    }

    //--------------------------------------------------------------------------------------------------

    //CHAMA A FUNÇÃO BUSCAR CONSULTA ASSIM QUE O COMPONENTE FOR RENDERIZADO
    componentDidMount(){
        this.ListaMinhasConsultas();
    }

    //---------------------------------------------------------------------------------------------------

    render(){ 
        return(
            <section>
                <Cabeçalho/>

                <div>
                <a onClick={this.logout} href="/"><h3>Sair</h3></a>
                    <h2>Minhas Consultas </h2>
                    {
                        this.state.ListaMinha.map((minhas) => {
                            return(
                                <div className="Minhas">
                                <p>IdConsulta: {minhas.idConsulta}</p>
                                <p>Nome Paciente: {minhas.idPacienteNavigation.nome} </p>
                                <p>Nome Medico: {minhas.idMedicoNavigation.nome}</p>
                                <p>CRM: {minhas.idMedicoNavigation.crm} </p>
                                <p>Data Consulta: {minhas.dataConsulta}</p>
                                <p>Situação: {minhas.idSituacaoNavigation.situacao1}</p>
                                </div>
                            )
                        })
                    }
                </div>
                <Rodapé/>
            </section>
        )
    }
}
export default ListaMinhas;