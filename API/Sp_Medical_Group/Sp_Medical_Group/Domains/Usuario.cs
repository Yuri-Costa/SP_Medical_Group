using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sp_Medical_Group.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O Campo senha precisa de no minimo 3 caracteres")]
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }
        public int Telefone { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
