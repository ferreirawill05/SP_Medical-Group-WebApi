using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Domains
{
    /// <summary>
    /// Classe que represent (tabela) de Médicos
    /// </summary>
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();   
        }

        public int IdMedico { get; set; }
        public int IdUsuario { get; set; }
        public short IdClinica { get; set; }
        public short IdEspecialidade { get; set; }

        [Required(ErrorMessage = "O Crmv do médico é obrigatório")]
        public string Crmv { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
