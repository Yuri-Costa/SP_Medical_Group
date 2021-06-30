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
{   //RETORNA OS DADOS EM FORMATO JSON
    [Produces("application/json")]

    // FAZ COM QUE A URL SEJA HTTP://LOCALHOST:5000/API/NOMECONTROLLER
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinica { get; set; }


        public ClinicasController()
        {
            _clinica = new ClinicaRepository();
        }

        //----------------------------------------------------------------------------------------
        // AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 1 A EXECUTAR O METODO DE LISTAR
        //[Authorize(Roles = "1")]
        //METODO DE LISTAR
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clinica.Listar());
        }

        //----------------------------------------------------------------------------------------
        // AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 1 A EXECUTAR O METODO DE BUSCAR
        //[Authorize(Roles = "1")]
        //METODO DE BUSCAR POR ID QUE FOI PASSADO NA URL
        [HttpGet("{id}")]
        public IActionResult BuscaClinica(int id)
        {
            return Ok(_clinica.BuscarPorId(id));
        }

        //----------------------------------------------------------------------------------------
        // AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO DE CADASTRAR
        //[Authorize(Roles = "2")]
        //METODO DE CADASTRAR 
        [HttpPost]
        public IActionResult CadastraClinica(Clinica novaClinica)
        {
            //CHAMA O METODO CADASTRAR
            _clinica.Cadastrar(novaClinica);

            //RETORNA STATUS CODE 201 CREATED
            return StatusCode(201);
        }

        //----------------------------------------------------------------------------------------------
        // AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO DE ATUALIZAR
        //[Authorize(Roles = "2")]
        //METODO DE ATUALIZAR 
        [HttpPut("{id}")]
        public IActionResult UpdateClinica(int id, Clinica clinicaAtualizada)
        {
            //CHAMA O METODO ATUALIZAR
            _clinica.Atualizar(id, clinicaAtualizada);

            //RETORNA STATUS CODE 204 NO CONTENT
            return StatusCode(204);
        }
        //----------------------------------------------------------------------------------------------
        // AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO DE DELETAR
        //[Authorize(Roles = "2")]

        //METODO DELETAR
        [HttpDelete("{id}")]
        public IActionResult DeletarClinica(int id)
        {
            //CHAMA O METODO DE DELETAR
            _clinica.Deletar(id);

            // RETORNA UM STATUS CODE 204 - NO CONTENT
            return StatusCode(204);
        }

        //----------------------------------------------------------------------------------------------
        // AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 1 A EXECUTAR O METODO DE LISTAR AS CLINICAS E OS RESPECTIVOS MEDICOS
        //[Authorize(Roles = "1")]
        //LISTA CLINICAS E SEUS MEDICOS
        [HttpGet ("medicos")]
        public IActionResult ListarMedicos()
        {
            return Ok(_clinica.ListaMedicos());
        }
    }
}
