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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _medico { get; set; }

        public MedicosController()
        {
            _medico = new MedicoRepository();
        }

        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 1 E 2 A EXECUTAR O METODO
        //[Authorize(Roles = "1, 2")]
        [HttpGet]

        // CHAMA O METODO DE CADASTRAR
        public IActionResult Get()
        {
            // LISTA OS MEDICOS
            return Ok(_medico.Listar());
        }

        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 1 E 2 A EXECUTAR O METODO
        //[Authorize(Roles = "1, 2")]
        [HttpGet("{id}")]

        // BUSCA UM MEDICO A PARTIR DO ID
        public IActionResult BuscaMedico(int id)
        {
            //RETORNA O MEDICO BUSCADO PELO ID
            return Ok(_medico.BuscarPorId(id));
        }

        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO

        //[Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult CadastraMedico(Medico novoMedico)
        {
            //CHAMA O METODO DE CADASTAR
            _medico.CadastrarMedico(novoMedico);

            //RETORNA STATUS CODE 201 - CREATED
            return StatusCode(201);
        }

        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //[Authorize(Roles = "2")]
        //METODO DE ATUALIZAR 
        [HttpPut("{id}")]
        public IActionResult UpdatePaciente(int id, Medico medicoAtualizado)
        {
            //CHAMA O METODO DE ATUALIZAR
            _medico.Atualizar(id, medicoAtualizado);

            //RETORNA UM 204 - NO CONTENT
            return StatusCode(204);
        }
        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //[Authorize(Roles = "2")]
        //METODO DELETAR
        [HttpDelete("{id}")]
        public IActionResult DeletarMedico(int id)
        {
            //CHAMA O METODO DE DELETAR PASSANDO O OBJETO QUE SERÁ DELETADO PELA URL ATRAVES DO ID
            _medico.Deletar(id);

            return StatusCode(204);
        }

        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //[Authorize(Roles = "2")]
        //LISTA Pacientes E SEUS consultas
        [HttpGet("consultas")]
        public IActionResult ListarConsulta()
        {
            //RETORA LISTA DE MEDICOS E SUAS CONSULTAS
            return Ok(_medico.ListaConsulta());
        }

        //----------------------------------------------------------------------------------------------
        //LISTA AS CONSULAS RELACIONADAS A UM MEDICO
        [HttpGet("MedConsulta")]
        public IActionResult ListarAssociado()
        {
            try
            {
                int idMedico = Convert.ToInt32(HttpContext.User.Claims.First(m => m.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_medico.ListarAssociado(idMedico));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Necessário fazer o login",
                    ex
                });
            }

        }
    }
}
