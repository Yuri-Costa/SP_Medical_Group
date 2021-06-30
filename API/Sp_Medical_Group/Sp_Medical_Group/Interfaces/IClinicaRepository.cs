using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface IClinicaRepository
    {
        //O METODO ABAIXO LISTA AS CLINICAS
        List<Clinica> Listar();

        //O METODO ABAIXO BUSCA UMA CLINICA A PARTIR DO SEU ID QUE SERÁ PASSADO NA URL
        Clinica BuscarPorId(int id);

        //O METODO ABAIXO CADASTRA UMA NOVA CLINICA
        void Cadastrar(Clinica novaClinica);

        //O METODO ABAIXO ATUALIZA UMA CLINICA, QUE FOI BUSCADA PRIMEIRO PELO ID
        void Atualizar(int id, Clinica clinicaAtualizada);

        //DELETA UMA CLINICA A PARTIR DO ID PASSADO NA URL
        void Deletar(int id);

        //LISTA AS CLINICAS E SEUS MEDICOS
        List<Clinica> ListaMedicos();
    }
}
