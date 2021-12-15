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
    public class ConsultasController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface
        /// </summary>
        private IConsultaRepository _consultaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações feitas no repositório
        /// </summary>
        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        ///  Listas todas as consultas do usuário logado
        /// </summary>
        /// <returns>Uma lista de consultas</returns>
        [Authorize(Roles = "2,3")]
        [HttpGet("minhas")]
        public IActionResult ListarMinhas()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarMinhas(idUsuario));
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as presenças se o usuário não estiver logado!",
                    error
                });
            }
        }

        /// <summary>
        /// Lista todas as Consultas existentes
        /// </summary>
        /// <returns>Uma lista de consultas com o status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_consultaRepository.Listar());
        }

        /// <summary>
        /// Busca uma consulta pelo seu id
        /// </summary>
        /// <param name="idConsulta">id da consulta a ser buscada</param>
        /// <returns>Uma consulta encontrada com o status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idConsulta}")]
        public IActionResult BuscarPorId(int idConsulta)
        {
            Consulta ConsultaBuscada = _consultaRepository.BuscarPorId(idConsulta);

            if (ConsultaBuscada == null)
            {
                return NotFound("A Consulta informada não existe!");
            }
            return Ok(ConsultaBuscada);
        }

        /// <summary>
        /// Cadastra uma Consulta
        /// </summary>
        /// <param name="novaConsulta">Consulta a ser cadastrada</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Consulta novaConsulta)
        {
            _consultaRepository.Cadastrar(novaConsulta);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma consulta existente
        /// </summary>
        /// <param name="consultaAtualizada">Objeto com as novas informações da Consulta e o id da consulta a ser atualizada</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(Consulta consultaAtualizada)
        {
            try
            {
                Consulta consultaBuscada = _consultaRepository.BuscarPorId(consultaAtualizada.IdConsulta);
                if (consultaBuscada != null)
                {
                    _consultaRepository.Atualizar(consultaAtualizada);
                    return StatusCode(204);
                }
                else
                {
                    return BadRequest(new { mensagem = "A Consulta informada não existe" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        /// <summary>
        /// Deleta uma consulta
        /// </summary>
        /// <param name="idConsulta">id da Consulta a ser deletada</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idConsulta}")]
        public IActionResult Deletar(int idConsulta)
        {
            _consultaRepository.Deletar(idConsulta);

            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza a situação de uma consulta
        /// </summary>
        /// <param name="idConsulta">Id da consulta a ser atualizada</param>
        /// <param name="status">nova situação da consulta</param>
        /// <returns>Um status code 200 - OK</returns>
        [Authorize(Roles = "1")]
        [HttpPatch("status/{idConsulta}")]
        public IActionResult AlterarStatus(int idConsulta, Situacao status)
        {
            try
            {
                _consultaRepository.AlterarStatus(idConsulta, status.IdSituacao);

                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
                throw;
            }
        }

        /// <summary>
        /// Atualiza a descrição de uma consulta
        /// </summary>
        /// <param name="idConsulta">Id da consulta a ser atualizada</param>
        /// <param name="descricao">nova descrição da consulta</param>
        /// <returns>Um status code 200 - OK</returns>
        [Authorize(Roles = "2")]
        [HttpPatch("descricao/{idConsulta}")]
        public IActionResult AdicionarDescricao(int idConsulta, Consulta descricao)
        {
            try
            {
                _consultaRepository.AdicionarDescricao(idConsulta, descricao.Descricao);

                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
                throw;
            }
        }
    }
}
