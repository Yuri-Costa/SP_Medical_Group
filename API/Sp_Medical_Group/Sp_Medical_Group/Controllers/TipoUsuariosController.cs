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
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipos { get; set; }

        public TipoUsuariosController()
        {
            _tipos = new TipoUsuarioRepository();
        }

        //METODO DE LISTAR
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipos.Listar());
        }

        [HttpPost]
        public IActionResult CadastrarTipoUsuario(TipoUsuario novaTipoUsuario)
        {
            //CHAMA O METODO
            _tipos.Cadastrar(novaTipoUsuario);

            //RETORNA STATUS CODE
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTipoUsuario(int id, TipoUsuario TipoUsuarioAtualizada)
        {
            _tipos.Atualizar(id, TipoUsuarioAtualizada);

            return StatusCode(204);
        }

        [HttpGet("usuario")]
        public IActionResult ListarUsuarios()
        {
            return Ok(_tipos.ListaUsuario());
        }
    }
}
