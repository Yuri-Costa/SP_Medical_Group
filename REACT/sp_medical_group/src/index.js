import React from 'react';
import ReactDOM from 'react-dom';
import {Route, BrowserRouter as Router, Switch} from 'react-router-dom';


import './index.css';



import App from './PAGES/Home/App';
import ListaConsultas from './PAGES/Listar/ListarConsulta'
import login from './PAGES/Login/login'
import Cadastro from './PAGES/CadastroUsuario/CadastroUsuario'
import Paciente from './PAGES/CadastraPaciente/CadastraPaciente'
import Medico from './PAGES/CadastraMedico/CadastraMedico'
import Minhas from './PAGES/ListaMinhas/ListaMinhas'
import ConsultaMedico from './PAGES/MedicoConsulta/MedicoConsulta'
import AdmPage from './PAGES/ADM/Adm'
import Header from './Components/Header/header'
import footer from './Components/Footer/footer'




import reportWebVitals from './reportWebVitals';


const routing = (
  <Router>
    <div>
        <Switch>
          <Route exact path="/" component={App}/> 
          <Route path="/consulta" component={ListaConsultas}/>
          <Route path="/cadastraUsuario" component={Cadastro}/>
          <Route path="/cadastrarPaciente" component={Paciente}/>
          <Route path="/cadastrarMedico" component={Medico}/>
          <Route path="/minhas" component={Minhas}/>
          <Route path="/gerenciador" component={AdmPage}/>
          <Route path="/login" component={login}/>
          <Route path="/header" component={Header}/>
          <Route path="/footer" component={footer}/>
          <Route path="/MedicoConsulta" component={ConsultaMedico}/>
        </Switch>
    </div>
  </Router>
)
ReactDOM.render(routing, document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
