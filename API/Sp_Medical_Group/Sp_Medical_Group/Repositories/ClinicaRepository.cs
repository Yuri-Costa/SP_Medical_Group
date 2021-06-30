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
    public class ClinicaRepository : IClinicaRepository
    {
        MedicalGroupContext ctx = new MedicalGroupContext();

//----------------------------------------------------------------------------------------------

        //ATUALIZA OS DADOS DE UMA CLINICA
        public void Atualizar(int id, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            if(clinicaBuscada.NomeFantasia != null)
            {
                clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
            }
            ctx.Clinicas.Update(clinicaBuscada);
            ctx.SaveChanges();
        }

//----------------------------------------------------------------------------------------------

        public Clinica BuscarPorId(int id)
        {
            // RETORNA A PRIMEIRA CLINICA ENCONTRADA PARA O ID INFORMADO
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == id);
        }

        //----------------------------------------------------------------------------------------------
        //CADASTRA A NOVA CLINICA NO BANCO DE DADOS

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            //SALVA AS ALTERAÇÕES FEITAS
            ctx.SaveChanges();
        }

 //----------------------------------------------------------------------------------------------
        
        //DELETA UMA CLINICA
        public void Deletar(int id)
        {
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            ctx.Clinicas.Remove(clinicaBuscada);

            ctx.SaveChanges();
        }

//----------------------------------------------------------------------------------------------

        public List<Clinica> ListaMedicos()
        {
            return ctx.Clinicas.Include(c => c.Medicos ).ToList();
        }

//----------------------------------------------------------------------------------------------

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
