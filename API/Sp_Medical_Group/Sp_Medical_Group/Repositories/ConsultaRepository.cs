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
    public class ConsultaRepository : IConsultaRepository
    {
        MedicalGroupContext ctx = new MedicalGroupContext();

//----------------------------------------------------------------------------------------------
//ATUALIZA UMA CONSULTA
        public void Atualizar(int id, Consulta ConsultaAtualizada)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            if (consultaBuscada.DataConsulta != null)
            {
                consultaBuscada.DataConsulta = ConsultaAtualizada.DataConsulta;
            }
            ctx.Consultas.Update(consultaBuscada);
            ctx.SaveChanges();
        }


//----------------------------------------------------------------------------------------------
//BUSCA UMA CONSULTA PELO ID
        public Consulta BuscarPorId(int id)
        {
            return ctx.Consultas.FirstOrDefault(con => con.IdConsulta == id);
        }


//----------------------------------------------------------------------------------------------
//CADASTRA UMA CONSULTA
        public void Cadastrar(Consulta novaConsulta)
        {
            ctx.Consultas.Add(novaConsulta);

            //SALVA AS ALTERAÇÕES FEITAS
            ctx.SaveChanges();
        }
//----------------------------------------------------------------------------------------------
//DELETA UMA CONSULTA PELO ID 
        public void Deletar(int id)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            ctx.Consultas.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

//----------------------------------------------------------------------------------------------
//LISTA A CONSULTA E OS DADOS DOS MEDICOS
        public List<Consulta> ListaMedicos()
        {
            return ctx.Consultas.Include(con => con.IdMedicoNavigation).ToList();
        }

//----------------------------------------------------------------------------------------------
//LISTA CONSULTA E OS DADOS DOS PACIENTES
        public List<Consulta> ListaPaciente()
        {
            return ctx.Consultas.Include(con => con.IdPacienteNavigation).ToList();
        }

//----------------------------------------------------------------------------------------------
//LISTA AS CONSULTAS
        public List<Consulta> Listar()
        {
            return ctx.Consultas.ToList();
        }

        //----------------------------------------------------------------------------------------------
       

        //----------------------------------------------------------------------------------------------
        //LISTA AS CONSULTAS E A SITUAÇÃO DELA
        public List<Consulta> ListaSituacao()
        {
            return ctx.Consultas.Include(con => con.IdSituacaoNavigation).ToList();
        }

        //----------------------------------------------------------------------------------------------
        //LISTA AS CONSULTAS DE UM DETERMINADO PACIENTE LOGADO A PARTIR DO SEU ID 
        public List<Consulta> ListarProprias(int id)
        {
            return ctx.Consultas
                .Include(c => c.IdSituacaoNavigation)
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdPacienteNavigation)
                .Where(c => c.IdPacienteNavigation.IdUsuario == id)
                .ToList();
        }

        //----------------------------------------------------------------------------------------------
        //LISTA AS CONSULTAS DE UM DETERMINADO MEDICO LOGADO A PARTIR DO SEU ID 
        public List<Consulta> ListarConsultaMedico(int id)
        {
            return ctx.Consultas
                .Include(c => c.IdSituacaoNavigation)
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdPacienteNavigation)
                .Where(c => c.IdMedicoNavigation.IdUsuario == id)
                .ToList();
        }
    }
}
