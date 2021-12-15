using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Domains
{
    /// <summary>
    /// Classe que representa entidade (tabela) de Especialidades
    /// </summary>
    public partial class Especialidade
    {
        Medicos = new HashSet<Medico>();
    }

    public short IdEspecialidade { get; set; }
    public string Descricao { get; set; }

    public virtual ICollection<Medico> Medicos { get; set; }
}
