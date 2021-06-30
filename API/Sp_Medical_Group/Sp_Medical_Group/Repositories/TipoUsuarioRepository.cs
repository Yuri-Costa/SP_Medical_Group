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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        MedicalGroupContext ctx = new MedicalGroupContext();

//----------------------------------------------------------------------------------------------
//ATUALIZA OS DADOS DO TIPOUSUARIO
        public void Atualizar(int id, TipoUsuario TipoUsuarioAtualizada)
        {
            TipoUsuario TipoUsuarioBuscada = ctx.TipoUsuarios.Find(id);

            if (TipoUsuarioBuscada.TipoUsuario1 != null)
            {
                TipoUsuarioBuscada.TipoUsuario1 = TipoUsuarioAtualizada.TipoUsuario1;
            }
            ctx.TipoUsuarios.Update(TipoUsuarioBuscada);
            ctx.SaveChanges();
        }

//----------------------------------------------------------------------------------------------
//CADASTRA UM NOVO TIPOUSUARIO
        public void Cadastrar(TipoUsuario novaTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novaTipoUsuario);

            //SALVA AS ALTERAÇÕES FEITAS
            ctx.SaveChanges();
        }

//----------------------------------------------------------------------------------------------
//LISTA OS TIPOSUSUARIOS
        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }

//----------------------------------------------------------------------------------------------
//LISTA OS USUARIOS E OS TIPOS DELES
        public List<TipoUsuario> ListaUsuario()
        {
            return ctx.TipoUsuarios.Include(t => t.Usuarios).ToList();
        }
    }
}
