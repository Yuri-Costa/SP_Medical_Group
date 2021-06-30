using Microsoft.EntityFrameworkCore;
using Sp_Medical_Group.Contexts;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        MedicalGroupContext ctx = new MedicalGroupContext();

//----------------------------------------------------------------------------------------------
//ATUALIZA OS DADOS 
        public void Atualizar(int id, Situacao SituacaoAtualizada)
        {
            Situacao situacaoBuscada = ctx.Situacaos.Find(id);

            if (situacaoBuscada.Situacao1 != null)
            {
                situacaoBuscada.Situacao1 = SituacaoAtualizada.Situacao1;
            }
            ctx.Situacaos.Update(situacaoBuscada);
            ctx.SaveChanges();
        }

//----------------------------------------------------------------------------------------------
//CADASTRA UMA NOVA SITUAÇÃO
        public void Cadastrar(Situacao novaSituacao)
        {
            ctx.Situacaos.Add(novaSituacao);

            //SALVA AS ALTERAÇÕES FEITAS
            ctx.SaveChanges();
        }

//----------------------------------------------------------------------------------------------
//LISTA AS SITUAÇÕES
        public List<Situacao> Listar()
        {
            return ctx.Situacaos.ToList();
        }

//----------------------------------------------------------------------------------------------
//LISTA A CONSULTA E SUA SITUAÇÃO
        public List<Situacao> ListaConsulta()
        {
            return ctx.Situacaos.Include(s => s.Consulta).ToList();
        }
    }
}
