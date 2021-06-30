using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using Sp_Medical_Group.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consulta { get; set; }

        public ConsultasController()
        {
            _consulta = new ConsultaRepository();
        }

//----------------------------------------------------------------------------------------
//AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 1 A EXECUTAR O METODO

        //[Authorize(Roles = "1")]
        [HttpGet]

        //CHAMA O METODO DE LISTAR
        public IActionResult Get()
        {
            //RETORNA A LISTA DE CONSULTAS
            return Ok(_consulta.Listar());
        }

//----------------------------------------------------------------------------------------
//AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO

        //[Authorize(Roles = "2")]
        //METODO DE BUSCAR POR ID QUE FOI PASSADO NA URL
        [HttpGet("{id}")]

        //CHAMA O METODO DE BUSCARPORID
        public IActionResult BuscaConsulta(int id)
        {
            //RETORNA A CONSULTA BUSCADA
            return Ok(_consulta.BuscarPorId(id));
        }

//----------------------------------------------------------------------------------------
//AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO

        //[Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult CadastraConsulta(Consulta novaConsulta)
        {
            //CHAMA O METODO DE CADASTRAR
            _consulta.Cadastrar(novaConsulta);

            //RETORNA STATUS CODE 201 - CREATED
            return StatusCode(201);
        }

//----------------------------------------------------------------------------------------
//AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //[Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult UpdateClinica(int id, Consulta consultaAtualizada)
        {   
            // CHAMA O METODO ATUALIZAR
            _consulta.Atualizar(id, consultaAtualizada);

            //RETORNA UM STATUS CODE 204 - NO CONTENT
            return StatusCode(204);
        }

//----------------------------------------------------------------------------------------
//AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO

        //[Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult DeletarConsulta(int id)
        {
            // CHAMA O METODO DE DELETAR
            _consulta.Deletar(id);

            //RETORNA UM STATUS CODE 204 - NO CONTENT
            return StatusCode(204);
        }

//----------------------------------------------------------------------------------------
//AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 1 E 2 A EXECUTAR O METODO

        //[Authorize(Roles = "1, 2")]
        [HttpGet("medicos")]

        // LISTA OS MEDICOS
        public IActionResult ListarMedicos()
        {
            //RETORNA UMA LISTA DE MEDICOS
            return Ok(_consulta.ListaMedicos());
        }

//----------------------------------------------------------------------------------------
//AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 1 E 2 A EXECUTAR O METODO

        //[Authorize(Roles = "1, 2")]
        [HttpGet("paciente")]
        
        //CHAMA O METODO DE LISTAR PACIENTES
        public IActionResult ListarPaciente()
        {
            //RETORNA UMA LISTA DE PACIENTES
            return Ok(_consulta.ListaPaciente());
        }

        //----------------------------------------------------------------------------------------
        [HttpGet("minhas")]
        public IActionResult ListarProprias()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(_consulta.ListarProprias(IdUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Necessáio estar logado para vizualizar suas próprias consultas!",
                    ex
                });
            }
        }

        //----------------------------------------------------------------------------------------

        [HttpGet("agendadas")]
        public IActionResult ListaAssociadas()
        {
            try
            {
                int IdMed = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(_consulta.ListarConsultaMedico(IdMed));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Necessáio estar logado para vizualizar suas próprias consultas!",
                    ex
                });
            }
        }

    }
}
