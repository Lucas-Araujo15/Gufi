using System;
using System.Collections.Generic;

#nullable disable

namespace gufi.webAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ImagemPerfil ImagemPerfil { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
