import { Component} from 'react';
import Cabecalho from '../../Components/Header/header'
import Rodapé from '../../Components/Footer/footer'
import '../../assets/Css/CadastroUsuario.css'

class CadastraUsuario  extends Component{
    constructor(props){
        super(props);
        this.state = {
            idTipoUsuario : 0,
            email : '',
            senha : '',
            dataNascimento : Date,
            rg : '',
            telefone: 0,
            cpf: '',
            endereco : ''
        }
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA idTipoUsuario

    AtualizaIdTipoUsuario = async(event) => {
        await this.setState({idTipoUsuario : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA EMAIL

    AtualizaEmail = async(event) => {
        await this.setState({email : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA SENHA

    AtualizaSenha = async(event) => {
        await this.setState({senha : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA A DATA

    AtualizadataNascimento = async(event) => {
        await this.setState({dataNascimento : event.target.value})
    };

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA RG

    AtualizaRg = async(event) => {
        await this.setState({rg : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA TELEFONE

    AtualizaTelefone = async(event) => {
        await this.setState({telefone : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA CPF

    AtualizaCpf = async(event) => {
        await this.setState({cpf : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA A ENDERECO

    AtualizaEndereco = async(event) => {
        await this.setState({endereco : event.target.value})
    };

    //---------------------------------------------------------------------------------------------------

    //CADASTRA UM NOVA USUARIO

    cadastranovousuario = (event) => {
        //IGNOROU O COMPORTAMENTO PADRÃO DO NAVEGADOR
        event.preventDefault();

        fetch('http://localhost:5000/api/Usuarios', {
                
            //DEFINE O METODO DA REQUISIÇÃO COMO POST
            method : 'POST',
                
            //CONVERTE A RESPOSTA RECEBIDA EM JSON
            body : JSON.stringify ({idTipoUsuario : this.state.idTipoUsuario, email : this.state.email, senha : this.state.senha, dataNascimento : this.state.dataNascimento, rg : this.state.rg, telefone : this.state.telefone, cpf : this.state.cpf, endereco : this.state.endereco }),
            
            //DEFINE O CABEÇALHO DA REQUISIÇÃO
            headers : {
            "Content-Type" : "application/json"
            }
        });
    }

//---------------------------------------------------------------------------------------------------
    limparCampos = () => {
        this.setState({
            idTipoUsuario : 0,
            email : '',
            senha : '',
            dataNascimento : new Date(),
            rg : '',
            telefone: 0,
            cpf: '',
            endereco : ''
        })
    }
//---------------------------------------------------------------------------------------------------
    render(){ 
        return(
            <main>
                <Cabecalho/>
                <section>
                <h2>CADASTRO CONSULTA</h2>
                    <form onSubmit={this.cadastranovousuario}>
                <div className="Cadastrar">
                    
                    <input placeholder="Digite o TipoUsuario paciente = 1 e medico = 2" value = {this.state.idTipoUsuario} onChange={this.AtualizaIdTipoUsuario} type="number" className='gui2'></input>

                    
                    <input placeholder="Digite o email do usuario" value = {this.state.email} onChange={this.AtualizaEmail}type="text" className="gui2"></input>

                    
                    <input placeholder="Digite a senha do usuario" value = {this.state.senha} onChange={this.AtualizaSenha} type="text" className='gui2'></input>

                    
                    <input placeholder="Digite a data de nascimento do usuario" value = {this.state.dataNascimento} onChange={this.AtualizadataNascimento} type="date" className='gui2'></input>

                    
                    <input placeholder= "Digite o rg do usuario" value = {this.state.rg} onChange={this.AtualizaRg} type="text" className='gui2'></input>

                    
                    <input placeholder="Digite o telefone do usuario" value = {this.state.telefone} onChange={this.AtualizaTelefone}type="number" className='gui2' ></input>

                    
                    <input placeholder="Digite o cpf do usuario" value = {this.state.cpf} onChange={this.AtualizaCpf} type="text" className='gui2'></input>

                    
                    <input placeholder="Digite o endereço do usuario" value = {this.state.endereco} onChange={this.AtualizaEndereco} type="text" className='gui2'></input>
                    
                    {
                        <button type='submit' disabled={this.state.idTipoUsuario === '' && this.state.email === '' && this.state.senha === '' && this.state.dataNascimento === '' && this.state.rg === '' && this.state.telefone === '' && this.state.cpf ==='' && this.state.endereco === '' ? 'none' : ''} >Cadastrar</button>
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
export default CadastraUsuario;