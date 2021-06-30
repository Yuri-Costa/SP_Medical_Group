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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _user { get; set; }

        public UsuariosController()
        {
            _user = new UsuarioRepository();
        }

        //----------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO

        //METODO DE LISTAR
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_user.Listar());
        }

        //----------------------------------------------------------------------------------------

        //METODO DE BUSCAR POR ID QUE FOI PASSADO NA URL
        [HttpGet("{id}")]
        public IActionResult BuscaClinica(int id)
        {
            return Ok(_user.BuscarPorId(id));
        }

        //----------------------------------------------------------------------------------------
        //METODO DE CADASTRAR 
        [HttpPost]
        public IActionResult CadastraClinica(Usuario novoUsuario)
        {
            //CHAMA O METODO
            _user.Cadastrar(novoUsuario);

            //RETORNA STATUS CODE
            return StatusCode(201);
        }

        //----------------------------------------------------------------------------------------------
        //METODO DE ATUALIZAR 
        [HttpPut("{id}")]
        public IActionResult UpdateClinica(int id, Usuario usuarioAtualizado)
        {
            _user.Atualizar(id, usuarioAtualizado);

            return StatusCode(204);
        }
        //----------------------------------------------------------------------------------------------
        //METODO DELETAR
        [HttpDelete("{id}")]
        public IActionResult DeletarConsulta(int id)
        {
            _user.Deletar(id);

            return StatusCode(204);
        }

        //----------------------------------------------------------------------------------------------
        //LISTA CLINICAS E SEUS MEDICOS
        [HttpGet("medicos")]
        public IActionResult ListarMedicos()
        {
            return Ok(_user.ListaMedicos());
        }

        //----------------------------------------------------------------------------------------------
        //LISTA CLINICAS E SEUS paciente
        [HttpGet("paciente")]
        public IActionResult ListaPaciente()
        {
            return Ok(_user.ListaPacientes());
        }
        //----------------------------------------------------------------------------------------------
        //LISTA CLINICAS E SEUS tipo usuario
        [HttpGet("tipousuario")]
        public IActionResult ListarTipoUsuario()
        {
            return Ok(_user.ListaTipoUsuario());
        }
    }
}
