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
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        MedicalGroupContext ctx = new MedicalGroupContext();


        //----------------------------------------------------------------------------------------------
        //ATUALIZA UMA ESPECIALIDADE
        public void Atualizar(int id, Especialidade especialidadeAtualizada)
        {
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id);

            if (especialidadeBuscada.Especialidade1 != null)
            {
                especialidadeBuscada.Especialidade1 = especialidadeAtualizada.Especialidade1;
            }
            ctx.Especialidades.Update(especialidadeBuscada);
            ctx.SaveChanges();
        }

        //----------------------------------------------------------------------------------------------
        //BUSCA ESPECIALIDADE POR ID
        public Especialidade BuscarPorId(int id)
        {
            return ctx.Especialidades.FirstOrDefault(c => c.IdEspecialidade == id);
        }

        //----------------------------------------------------------------------------------------------
        //CADASTRA ESPECIALIDADE
        public void Cadastrar(Especialidade novaEspecialidade)
        {
            ctx.Especialidades.Add(novaEspecialidade);

            //SALVA AS ALTERAÇÕES FEITAS
            ctx.SaveChanges();
        }

        //----------------------------------------------------------------------------------------------
        //DELETA ESPECIALIDADE
        public void Deletar(int id)
        {
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id);

            ctx.Especialidades.Remove(especialidadeBuscada);

            ctx.SaveChanges();
        }

        //----------------------------------------------------------------------------------------------
        //LISTA AS ESPECIALIDADES
        public List<Especialidade> Listar()
        {
            return ctx.Especialidades.ToList();
        }

        //----------------------------------------------------------------------------------------------
        //LISTA AS ESPECIALIDADES E SEUS RESPECTIVOS MEDICOS

        public List<Especialidade> ListaMedicos()
        {
            return ctx.Especialidades.Include(e => e.Medicos).ToList();
        }

        //----------------------------------------------------------------------------------------------
    }
}
