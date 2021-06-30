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
    public class PacienteRepository : IPacienteRepository
    {
        MedicalGroupContext ctx = new MedicalGroupContext();

//----------------------------------------------------------------------------------------------
//ATUALIZA OS DADOS DO PACIENTE
        public void Atualizar(int id, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            if (pacienteBuscado.Cpf != null)
            {
                pacienteBuscado.Cpf = pacienteAtualizado.Cpf;
            }
            ctx.Pacientes.Update(pacienteBuscado);

            if (pacienteBuscado.Nome != null)
            {
                pacienteBuscado.Nome = pacienteAtualizado.Nome;
            }

            if (pacienteBuscado.Rg != null)
            {
                pacienteBuscado.Rg = pacienteAtualizado.Rg;
            }

            if (pacienteBuscado.Telefone != null)
            {
                pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
            }

            ctx.Pacientes.Update(pacienteBuscado);
            ctx.SaveChanges();

        }

//----------------------------------------------------------------------------------------------
//BUSCA OS DADOS DO PACIENTE BUSCADO PELO ID

        public Paciente BuscarPorId(int id)
        {
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);
        }

//----------------------------------------------------------------------------------------------
//CADASTRA UM NOVO PACIENTE
        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);

            //SALVA AS ALTERAÇÕES FEITAS
            ctx.SaveChanges();
        }

//----------------------------------------------------------------------------------------------
//DELETA UM PACIENTE A PARTIR DO ID
        public void Deletar(int id)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            ctx.Pacientes.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }

//----------------------------------------------------------------------------------------------
//LISTA OS PACIENTES E SUAS RESPECTIVAA CONSULTAS
        public List<Paciente> ListaConsulta()
        {
            return ctx.Pacientes.Include(p => p.Consulta).ToList();
        }

//----------------------------------------------------------------------------------------------
//LISTA OS DADOS DO PACIENTE
        public List<Paciente> Listar()
        {
            return ctx.Pacientes.ToList();
        }


//----------------------------------------------------------------------------------------------
    }
}
