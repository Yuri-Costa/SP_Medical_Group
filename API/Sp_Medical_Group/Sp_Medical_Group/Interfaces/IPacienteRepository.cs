using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface IPacienteRepository
    {
        //O METODO ABAIXO LISTA OS PACIENTES
        List<Paciente> Listar();

        //O METODO ABAIXO BUSCA UM PACIENTES A PARTIR DO SEU ID QUE SERÁ PASSADO NA URL
        Paciente BuscarPorId(int id);

        //O METODO ABAIXO CADASTRA UMA NOVA CLINICA
        void Cadastrar(Paciente novoPaciente);

        //O METODO ABAIXO ATUALIZA UM PACIENTES, QUE FOI BUSCADA PRIMEIRO PELO ID
        void Atualizar(int id, Paciente pacienteAtualizado);

        //DELETA UMA PACIENTES A PARTIR DO ID PASSADO NA URL
        void Deletar(int id);

        //LISTA AS PACIENTES E SEUS MEDICOS
        List<Paciente> ListaConsulta();
    }
}
