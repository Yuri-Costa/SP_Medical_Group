// import { Component} from 'react';

import Cabecalho from '../../Components/Header/header'
import Rodapé from '../../Components/Footer/footer'

import '../../assets/Css/adm.css';

import Listar from '../../assets/img/lista-de-papel.png'
import Medico from '../../assets/img/doctor.png'
import Paciente from '../../assets/img/sneeze.png'


function AdmPage(){
    return (
        <div>
            <Cabecalho/>
            <main className="gerenciar">
                <div className="gerenciador">
                <a href="/consulta"><img src={Listar} className="Lista" alt="Lista Consultas" /></a>
                <a href="/consulta"><p>Listar Consultas</p></a>
                </div>

                <div className="gerenciador">
                <a href="/cadastrarMedico"><img src={Medico} className="Lista" alt="Lista Consultas" /></a>
                <a href="/cadastrarMedico"><p>Cadastra Medico</p></a> 
                </div>

                <div className="gerenciador">
                <a href="/cadastrarPaciente"><img src={Paciente} className="Lista" alt="Lista Consultas" /></a>
                <a href="/cadastrarPaciente"><p>Cadastra Paciente</p></a>
                </div>

            </main>
            <Rodapé/>
        </div>
    )
}
export default AdmPage;