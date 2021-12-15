using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Domains
{
    /// <summary>
    /// Classe que representa entidade (tabela) de Pacientes
    /// </summary>
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }
        public int IdUsuario { get; set; }
        public string Telefone { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O Rg do paciente é obrigatório")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "O Cpf do paciente é obrigatório")]
        public string Cpf { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
