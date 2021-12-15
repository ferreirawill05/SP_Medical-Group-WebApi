using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Domains
{

    /// <summary>
    /// Essa classe representa entidade (tabela) de Clinicas
    /// </summary>
    
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdClinica { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O horário de abertura é obrigatório")]
        public TimeSpan HorarioAbertura { get; set; }

        [Required(ErrorMessage = "O horário de fechamento é obrigatório")]
        public TimeSpan HorarioFechamento { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }

    }
}
