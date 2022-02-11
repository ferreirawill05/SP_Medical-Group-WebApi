using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.ViewModels
{
    public class CadastroViewModel
    {
        public int? IdPaciente { get; set; }
        [Required(ErrorMessage = "É necessário cadastrar um médico")]
        public int? IdMedico { get; set; }
        public int? IdSituacao { get; set; }

        [Required(ErrorMessage = "É necessário cadastrar uma data")]
        public DateTime DataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }
    }
}
