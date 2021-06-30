using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface IConsultaRepository
    {
        //O METODO ABAIXO LISTA AS CONSULTAS
        List<Consulta> Listar();

        //O METODO ABAIXO BUSCA UMA CONSULTAS A PARTIR DO SEU ID QUE SERÁ PASSADO NA URL
        Consulta BuscarPorId(int id);

        //O METODO ABAIXO CADASTRA UMA NOVA CLCONSULTASINICA
        void Cadastrar(Consulta novaConsulta);

        //O METODO ABAIXO ATUALIZA UMA CONSULTAS, QUE FOI BUSCADA PRIMEIRO PELO ID
        void Atualizar(int id, Consulta ConsultaAtualizada);

        //DELETA UMA CONSULTAS A PARTIR DO ID PASSADO NA URL
        void Deletar(int id);

        //LISTA AS CONSULTAS E SEUS MEDICOS
        List<Consulta> ListaMedicos();

        //LISTA AS CONSULTAS E SEUS PACIENTES
        List<Consulta> ListaPaciente();

        //LISTA AS CONSULTAS E SEUS Situacao
        List<Consulta> ListaSituacao();

        //LISTA MINHAS CONSULTAS
        List<Consulta> ListarProprias(int id);

        //LISTA CONSULTAS DE UM DETERMINADO MEDICO
        List<Consulta> ListarConsultaMedico(int id);


    }
}
