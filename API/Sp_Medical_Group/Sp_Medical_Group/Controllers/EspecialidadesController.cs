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
    public class EspecialidadesController : ControllerBase
    {
        private IEspecialidadeRepository _especialidade { get; set; }


        public EspecialidadesController()
        {
            _especialidade = new EspecialidadeRepository();
        }

        //----------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 1 E 2 A EXECUTAR O METODO
        //[Authorize(Roles = "1, 2")]
        //METODO DE LISTAR
        [HttpGet]

        //CHAMA O METODO DE LISTAR
        public IActionResult Get()
        {
            // RETORNA UMA LISTA DE ESPECIALIDADES
            return Ok(_especialidade.Listar());
        }

        //----------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO

        //[Authorize(Roles = "1, 2")]
        //METODO DE BUSCAR POR ID QUE FOI PASSADO NA URL
        [HttpGet("{id}")]
        public IActionResult BuscaEspecialidade(int id)
        {
            // RETORNA O OBJETO BUSCADO
            return Ok(_especialidade.BuscarPorId(id));
        }

        //----------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //[Authorize(Roles = "2")]
        //METODO DE CADASTRAR 
        [HttpPost]
        public IActionResult CadastraClinica(Especialidade novaEspecialidade)
        {
            //CHAMA O METODO DE CADASTRAR
            _especialidade.Cadastrar(novaEspecialidade);

            //RETORNA STATUS CODE 201 - CREATED
            return StatusCode(201);
        }

        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //[Authorize(Roles = "2")]
        //METODO DE ATUALIZAR PASSANDO O OBJETO A SER ATUALIZAR PELA URL A PARTIR DO ID
        [HttpPut("{id}")]
        public IActionResult UpdateClinica(int id, Especialidade especialidadeAtualizada)
        {
            //CHAMA O METODO DE ATUALIZAR
            _especialidade.Atualizar(id, especialidadeAtualizada);

            //RETORNA UM STATUS CODE 204 - NO CONTENT
            return StatusCode(204);
        }
        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //[Authorize(Roles = "2")]

        //METODO DELETAR
        [HttpDelete("{id}")]
        public IActionResult DeletarEspecialidade(int id)
        {
            //CHAMA O METODO DE DELETAR
            _especialidade.Deletar(id);

            //RETORNA UM STATUS CODE 204 - NO CONTENT
            return StatusCode(204);
        }

        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 1 E 2 A EXECUTAR O METODO
        //[Authorize(Roles = "1, 2")]
        //LISTA CLINICAS E SEUS MEDICOS
        [HttpGet("medicos")]
        public IActionResult ListarMedicos()
        {
            //RETORNA LISTA DE ESPECIALIDADES E OS MEDICOS DE CADA ÁREA
            return Ok(_especialidade.ListaMedicos());
        }
    }
}
