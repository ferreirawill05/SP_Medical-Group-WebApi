using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Domains
{
    /// <summary>
    /// Classe que representa entidade (tabela) de TipoUsuario
    /// </summary>
    public partial class TipoUsuario
    {
        public TipoUsuario();
        {
            Usuarios = new HashSet<Usuario>();
        }

    public byte IdTipoUsuario { get; set; }
    public string TituloTipoUsuario { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; }
}
}
