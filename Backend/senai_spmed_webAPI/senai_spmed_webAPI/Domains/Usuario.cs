using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Domains
{
    /// <summary>
    /// Classe que representa entidade (tabela) de Usuarios
    /// </summary>
    public partial class Usuario
    {
        public Usuario();
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public byte IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório!")]
        [StringLength(9, MinimumLength = 3, ErrorMessage = "A senha deve ter de 3 a 10 caracteres")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }   
    }
}
