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
    public class MedicoRepository : IMedicoRepository
    {
        MedicalGroupContext ctx = new MedicalGroupContext();

//----------------------------------------------------------------------------------------------
//ATUALIZA OS DADOS DO MEDICO
        public void Atualizar(int id, Medico medicoAtualizado)
        {
            Medico medicoBuscada = ctx.Medicos.Find(id);

            if (medicoBuscada.Nome != null)
            {
                medicoBuscada.Nome = medicoAtualizado.Nome;
            }

            if (medicoBuscada.Crm != null)
            {
                medicoBuscada.Crm = medicoAtualizado.Crm;
            }

            ctx.Medicos.Update(medicoBuscada);
            ctx.SaveChanges();

        }

//----------------------------------------------------------------------------------------------
//BUSCA O MEDICO PELO ID 

        public Medico BuscarPorId(int id)
        {
            return ctx.Medicos.FirstOrDefault(m => m.IdMedico == id);
        }

//----------------------------------------------------------------------------------------------
//DELETA OS DADOS DO MEDICO A PARIT DO ID 
        public void Deletar(int id)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

//----------------------------------------------------------------------------------------------
//LISTA OS MEDICOS E SUAS RESPECTIVAS CONSULTAS
        public List<Medico> ListaConsulta()
        {
            return ctx.Medicos.Include(m => m.Consulta).ToList();
        }

//----------------------------------------------------------------------------------------------
//LISTA OS MEDICOS
        public List<Medico> Listar()
        {
            return ctx.Medicos.ToList();
        }

        //----------------------------------------------------------------------------------------------
        // CADASTRA UM MEDICO
        public void CadastrarMedico(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            //SALVA AS ALTERAÇÕES FEITAS
            ctx.SaveChanges();
        }

        //----------------------------------------------------------------------------------------------
        // LISTA MEDICOS E SUAS CONSULTAS

        public List<Medico> ListarAssociado(int id)
        {

            return ctx.Medicos
                .Include(m => m.IdClinicaNavigation)
                .Include(m => m.Consulta)
                .Where(m => m.IdMedico == id)
                .ToList();
        }
    }
}
