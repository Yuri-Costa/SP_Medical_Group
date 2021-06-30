import { Component} from 'react';
import { Link } from 'react-router-dom';
import '../../assets/Css/minhas.css'

class ListaMedicoConsulta extends Component{
    constructor(props){
        super(props);
        this.state = {
            ListaMedicoConsulta : []
        }
    }



    ListaConsultasMed = () => {

        //METODO FEITO PARA SABER SE AO CARREGAR A PAGINA, É CARREGADA A FUNÇÃO DE BUSCAR CONSULTA
        console.log('Metodo funcionando')

        console.log(localStorage.getItem('SPMG_token'))

        //CHAMA A API USANDO O FETCH
        fetch('http://localhost:5000/api/consultas/agendadas', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('SPMG_token')
            }
        })

        //TRANSFORMA A RESPOSTA EM JSON
        //DEFINE O TIPO DE DADO DO RETORNO COMO JSON
        // .then(resposta => resposta.json())

        //PEGA OS DADOS DA RESPOSTA E COLOCA DENTRO DO ARRAY
        .then(resposta => console.log(resposta.json()))
        // .then(dados => this.setState({ListaMedicoConsulta : dados}))

        // .then(console.log(this.state.ListaMedicoConsulta))

        //CASO OCORRA UM ERRO, MOSTRA NO CONSOLE DO NAVEGADOR
        .catch((erro) => console.log(erro))

    }
    logout = () => {
        localStorage.removeItem('SPMG_token')
    }

    //--------------------------------------------------------------------------------------------------

    //CHAMA A FUNÇÃO BUSCAR CONSULTA ASSIM QUE O COMPONENTE FOR RENDERIZADO
    componentDidMount(){
        this.ListaConsultasMed();
    }

    //---------------------------------------------------------------------------------------------------

    render(){ 
        return(
            <section>
                 <title>SP MEDICAL GROUP</title>
         

         <Link to="#" className="scrolltop" id="scroll-top">
            <i className='bx bx-chevron-up scrolltop__icon'></i>
      </Link>
        <header className="l-header" id="header">
            <nav className="nav bd-container">
                <Link to="#" className="nav__logo">SP MEDICAL GROUP</Link>

                <div className="nav__menu" id="nav-menu">
                    <ul className="nav__list">
                        <li className="nav__item nav__link active-link"><Link to="#home">Início</Link></li>
                        <li className="nav__item nav__link"><Link to= 'https://www.google.com.br/maps/place/SP+Medical+Group/@-34.6194312,-58.51194,17z/data=!3m1!4b1!4m5!3m4!1s0x95bcc82ca6ea8077:0x4584245b3e799434!8m2!3d-34.619416!4d-58.509721'>Localização</Link></li>
                        <li className="nav__item nav__link"><Link to="#services">Consultas</Link></li>
                        <li className="nav__item nav__link"><Link to="/Login">Login</Link></li>

                    </ul>
                </div>

                <div className="nav__toggle" id="nav-toggle">
                    <i className='bx bx-menu'></i>
                </div>
            </nav>
        </header>
                <div>
                    --------------------------------------------------------------------------
                </div>
                <div>
                    --------------------------------------------------------------------------
                </div>
                <div>
                    --------------------------------------------------------------------------
                </div>
                

                <div>
                < a onClick = {this.logout} href="/"><h3>Sair</h3></a>
                    <h2>Minhas Consultas </h2>
                    {
                        this.state.ListaMedicoConsulta.map((minhas) => {
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
                
            </section>
        )
    }
}
export default ListaMedicoConsulta;
