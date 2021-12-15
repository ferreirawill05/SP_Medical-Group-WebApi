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
    public class PacientesController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface
        /// </summary>
        private IPacienteRepository _pacienteRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações feitas no repositório
        /// </summary>
        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Lista todos os Pacientes existentes
        /// </summary>
        /// <returns>Uma lista de pacientes com o status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_pacienteRepository.Listar());
        }

        /// <summary>
        /// Busca um paciente pelo seu id
        /// </summary>
        /// <param name="idPaciente">id do paciente a ser buscado</param>
        /// <returns>Um paciente encontrado com o status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idPaciente}")]
        public IActionResult BuscarPorId(int idPaciente)
        {
            Paciente PacienteBuscado = _pacienteRepository.BuscarPorId(idPaciente);

            if (PacienteBuscado == null)
            {
                return NotFound("O Paciente informado não existe!");
            }
            return Ok(PacienteBuscado);
        }

        /// <summary>
        /// Cadastra um Paciente
        /// </summary>
        /// <param name="novoPaciente">Paciente a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Paciente novoPaciente)
        {
            if (novoPaciente.DataNascimento < DateTime.Now)
            {
                _pacienteRepository.Cadastrar(novoPaciente);
            }
            else
            {

                return BadRequest(new { mensagem = "Teriamos o primeiro viajante do tempo?!" });
            }

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um paciente existente
        /// </summary>
        /// <param name="pacienteAtualizado">Objeto com as novas informações do Paciente e o id do paciente a ser atualizado</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(Paciente pacienteAtualizado)
        {
            try
            {
                if (pacienteAtualizado.DataNascimento < DateTime.Now)
                {
                    Paciente PacienteBuscado = _pacienteRepository.BuscarPorId(pacienteAtualizado.IdPaciente);

                    if (PacienteBuscado != null)
                    {
                        if (pacienteAtualizado != null)
                            _pacienteRepository.Atualizar(pacienteAtualizado);

                    }
                    else
                    {
                        return BadRequest(new { mensagem = "O Paciente informado não existe" });
                    }
                    return StatusCode(204);
                }
                else
                {
                    return BadRequest(new { mensagem = "Teriamos o primeiro viajante do tempo?!" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um paciente
        /// </summary>
        /// <param name="idPaciente">id do Paciente a ser deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idPaciente}")]
        public IActionResult Deletar(int idPaciente)
        {
            _pacienteRepository.Deletar(idPaciente);

            return StatusCode(204);
        }
    }
}
