using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface IEspecialidadeRepository
    {
        List<Especialidade> Listar();

        //O METODO ABAIXO BUSCA UMA Especialidade A PARTIR DO SEU ID QUE SERÁ PASSADO NA URL
        Especialidade BuscarPorId(int id);

        //O METODO ABAIXO CADASTRA UMA NOVA Especialidade
        void Cadastrar(Especialidade novaEspecialidade);

        //O METODO ABAIXO ATUALIZA UMA Especialidade, QUE FOI BUSCADA PRIMEIRO PELO ID
        void Atualizar(int id, Especialidade especialidadeAtualizada);

        //DELETA UMA Especialidade A PARTIR DO ID PASSADO NA URL
        void Deletar(int id);

        List<Especialidade> ListaMedicos();
    }
}
