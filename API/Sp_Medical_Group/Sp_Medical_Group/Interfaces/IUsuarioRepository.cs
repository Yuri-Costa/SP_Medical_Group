using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface IUsuarioRepository
    {
        //O METODO ABAIXO LISTA OS USUARIOS
        List<Usuario> Listar();

        //O METODO ABAIXO BUSCA UM USUARIO A PARTIR DO SEU ID QUE SERÁ PASSADO NA URL
        Usuario BuscarPorId(int id);

        Usuario Login(string email, string senha);

        //O METODO ABAIXO CADASTRA UMA NOVA USUARIO
        void Cadastrar(Usuario novoUsuario);

        //O METODO ABAIXO ATUALIZA UM USUARIO, QUE FOI BUSCADA PRIMEIRO PELO ID
        void Atualizar(int id, Usuario usuarioAtualizada);

        //DELETA UM USUARIO A PARTIR DO ID PASSADO NA URL
        void Deletar(int id);

        //LISTA OS USUARIOS E SEUS MEDICOS
        List<Usuario> ListaMedicos();

        //LISTA OS USUARIOS E SEUS Pacientes
        List<Usuario> ListaPacientes();

        //LISTA OS USUARIOS E SEUS TipoUsuario
        List<Usuario> ListaTipoUsuario();
    }
}
