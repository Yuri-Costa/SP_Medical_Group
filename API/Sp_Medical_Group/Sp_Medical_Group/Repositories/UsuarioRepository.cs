using Microsoft.EntityFrameworkCore;
using Sp_Medical_Group.Contexts;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        MedicalGroupContext ctx = new MedicalGroupContext();

//----------------------------------------------------------------------------------------------
//ATUALIZA OS DADOS DO USUARIO
        public void Atualizar(int id, Usuario usuarioAtualizada)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            if (usuarioBuscado.IdUsuario != null)
            {
                usuarioBuscado.IdUsuario = usuarioAtualizada.IdUsuario;
            }
            ctx.Usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();
        }

//----------------------------------------------------------------------------------------------
//BUSCA O USUARIO PELO ID
        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

//----------------------------------------------------------------------------------------------
//CADASTRA UM NOVO USUARIO
        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            //SALVA AS ALTERAÇÕES FEITAS
            ctx.SaveChanges();
        }

//----------------------------------------------------------------------------------------------
//DELETA OS DADOS DE UM USUARIO
        public void Deletar(int id)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

//----------------------------------------------------------------------------------------------
//LISTA OS USUARIOS MEDICOS
        public List<Usuario> ListaMedicos()
        {
            return ctx.Usuarios.Include(u => u.Medicos).ToList();
        }

//----------------------------------------------------------------------------------------------
//LISTA OS USUARIOS PACIENTES
        public List<Usuario> ListaPacientes()
        {
            return ctx.Usuarios.Include(u => u.Pacientes).ToList();
        }

//----------------------------------------------------------------------------------------------
//LISTA OS USUARIOS
        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

//----------------------------------------------------------------------------------------------
//LISTA OS USUARIOS E SEUS TIPOS
        public List<Usuario> ListaTipoUsuario()
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }

//----------------------------------------------------------------------------------------------
//BUSCA O USUARIO POR EMAIL E SENHA
        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
//----------------------------------------------------------------------------------------------