using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmed_webAPI.Domains;
using senai_spmed_webAPI.Interfaces;
using senai_spmed_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface
        /// </summary>
        private IClinicaRepository _clinicaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações feitas no repositório
        /// </summary>
        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Lista todos os Usuário existentes
        /// </summary>
        /// <returns>Uma lista de usuários com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_clinicaRepository.Listar());
        }

        /// <summary>
        /// Busca uma clinica pelo seu id
        /// </summary>
        /// <param name="idClinica">id da clinica a ser buscado</param>
        /// <returns>Uma clinica encontrada com o status code 200 - Ok</returns>
        [HttpGet("{idClinica}")]
        public IActionResult BuscarPorId(int idClinica)
        {
            Clinica ClinicaBuscada = _clinicaRepository.BuscarPorId(idClinica);

            if (ClinicaBuscada == null)
            {
                return NotFound("A clínica informada não existe!");
            }
            return Ok(ClinicaBuscada);
        }

        /// <summary>
        /// Cadastra uma Clínica
        /// </summary>
        /// <param name="novaClinica">Clinica a ser cadastrada</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica novaClinica)
        {
            _clinicaRepository.Cadastrar(novaClinica);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma clinica existente
        /// </summary>
        /// <param name="ClinicaAtualizada">Objeto com as novas informações da clinica e o id da clinica a ser atualizada</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(Clinica ClinicaAtualizada)
        {
            try
            {
                Clinica ClinicaBuscado = _clinicaRepository.BuscarPorId(ClinicaAtualizada.IdClinica);
                if (ClinicaBuscado != null)
                {
                    if (ClinicaAtualizada != null)
                        _clinicaRepository.Atualizar(ClinicaAtualizada);
                }
                else
                {
                    return BadRequest(new { mensagem = "A clinca informada não existe" });
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma clinica
        /// </summary>
        /// <param name="idClinica">id da clinica a ser deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idClinica}")]
        public IActionResult Deletar(int idClinica)
        {
            _clinicaRepository.Deletar(idClinica);

            return StatusCode(204);
        }
    }
}
