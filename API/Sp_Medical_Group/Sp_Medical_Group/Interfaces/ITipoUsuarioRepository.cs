using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        void Cadastrar(TipoUsuario novaTipoUsuario);

        //O METODO ABAIXO ATUALIZA UM TipoUsuario, QUE FOI BUSCADA PRIMEIRO PELO ID
        void Atualizar(int id, TipoUsuario TipoUsuarioAtualizada);

        List<TipoUsuario> ListaUsuario();
    }
}
