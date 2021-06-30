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
    public class SituacoesController : ControllerBase
    {
        private ISituacaoRepository _situacao { get; set; }

        public SituacoesController()
        {
            _situacao = new SituacaoRepository();
        }

        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //METODO DE LISTAR
        //[Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Get()
        {
            // LISTA AS SITUAÇÕES
            return Ok(_situacao.Listar());
        }


        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //METODO DE LISTAR
        //[Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult CadastrarSituacao(Situacao novaSituacao)
        {
            //CHAMA O METODO CADASTAR
            _situacao.Cadastrar(novaSituacao);

            //RETORNA STATUS CODE 201 - CREATED
            return StatusCode(201);
        }


        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 2 A EXECUTAR O METODO
        //METODO DE ATUALIZAR PASSANDO ID PELA URL
        //[Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult UpdateSituacao(int id, Situacao situacaoAtualizada)
        {
            _situacao.Atualizar(id, situacaoAtualizada);

            //RETORNA STATUS CODE 204 - NO CONTENT
            return StatusCode(204);
        }


        //----------------------------------------------------------------------------------------------
        //AUTORIZA O USUARIO QUE POSSUI O IDTIPOUSUARIO = 1 A EXECUTAR O METODO
        //METODO DE LISTAR AS CONSUTAS E AS SITUAÇÕES
        //[Authorize(Roles = "1")]
        //LISTA CLINICAS E SEUS MEDICOS
        [HttpGet("consultas")]
        public IActionResult ListarConsultas()
        {
            //RETORNA A LISTA DE CONSULTAS E A SITUAÇÃO DA MESMA
            return Ok(_situacao.ListaConsulta());
        }

    }
}
