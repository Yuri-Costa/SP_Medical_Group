using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface IMedicoRepository
    {
        //O METODO ABAIXO LISTA OS MEDICOS
        List<Medico> Listar();

        //O METODO ABAIXO BUSCA UM MEDICO A PARTIR DO SEU ID QUE SERÁ PASSADO NA URL
        Medico BuscarPorId(int id);

        //O METODO ABAIXO CADASTRA UMA NOVO MEDICO
        void CadastrarMedico(Medico novoMedico);

        //O METODO ABAIXO ATUALIZA UM Medico, QUE FOI BUSCADA PRIMEIRO PELO ID
        void Atualizar(int id, Medico medicoAtualizado);

        //DELETA UM MEDICO A PARTIR DO ID PASSADO NA URL
        void Deletar(int id);

        //LISTA AS MEDICO E SUAS CONSULTAS
        List<Medico> ListaConsulta();

        //LISTA AS CONSULTAS POR MEDICOS
        List<Medico> ListarAssociado(int id);
    }
}
