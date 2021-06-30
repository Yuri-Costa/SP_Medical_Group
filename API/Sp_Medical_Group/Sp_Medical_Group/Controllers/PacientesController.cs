using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using Sp_Medical_Group.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _paciente { get; set; }

        public PacientesController()
        {
            _paciente = new PacienteRepository();
        }

        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //[Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult Get()
        {   
            //RETORNA UMA LISTA DE PACIENTES
            return Ok(_paciente.Listar());
        }

        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //[Authorize(Roles = "2")]
        [HttpGet("{id}")]
        public IActionResult BuscaPaciente(int id)
        {
            //RETORNA UM PACIENTE PASSANDO ID DELE PELA URL
            return Ok(_paciente.BuscarPorId(id));
        }

        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        [HttpPost]
        public IActionResult CadastraPaciente(Paciente novoPaciente)
        {
            //CHAMA O METODO DE CADASTRAR
            _paciente.Cadastrar(novoPaciente);

            //RETORNA STATUS CODE 201 - CREATED
            return StatusCode(201);
        }

        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //METODO DE ATUALIZAR 
        //[Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult UpdatePaciente(int id, Paciente pacienteAtualizada)
        {
            //ATUALIZA UM OBJETO PASSANDO ID PELA URL
            _paciente.Atualizar(id, pacienteAtualizada);

            //RETORNA UM STATUS CODE 204 - NO CONTENT
            return StatusCode(204);
        }
        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //METODO DELETAR
        //[Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult DeletarPaciente(int id)
        {
            //DELETA UM OBJETO PASSANDO O ID DELE PELA URL
            _paciente.Deletar(id);
            

            //RETORNA UM STATUS CODE 204 - NO CONTENT
            return StatusCode(204);
        }

        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //LISTA Pacientes E SEUS consultas
        //[Authorize(Roles = "2")]
        [HttpGet("consultas")]
        public IActionResult ListarConsulta()
        {
            //RETORNA UM PACIENTE E SUAS RESPECTIVAS CONSULTAS
            return Ok(_paciente.ListaConsulta());
        }
    }
}
