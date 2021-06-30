using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface ISituacaoRepository
    {
        List<Situacao> Listar();

        void Cadastrar(Situacao novaSituacao);

        //O METODO ABAIXO ATUALIZA UMA SITUACAO, QUE FOI BUSCADA PRIMEIRO PELO ID
        void Atualizar(int id, Situacao SituacaoAtualizada);

        List<Situacao> ListaConsulta();
    }
}
