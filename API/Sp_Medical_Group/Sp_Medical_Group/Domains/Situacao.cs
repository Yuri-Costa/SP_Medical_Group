using System;
using System.Collections.Generic;

#nullable disable

namespace Sp_Medical_Group.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdSituacao { get; set; }
        public string Situacao1 { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
