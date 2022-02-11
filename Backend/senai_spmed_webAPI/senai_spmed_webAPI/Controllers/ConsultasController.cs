using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmed_webAPI.Domains;
using senai_spmed_webAPI.Interfaces;
using senai_spmed_webAPI.Repositories;
using senai_spmed_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Lista todas as consultas existentes
        /// </summary>
        /// <returns>Uma lista de consultas</returns>
        [Authorize(Roles ="1")]
        [HttpGet]
        public IActionResult ListarTodas()
        {
            try
            {
                return Ok(_consultaRepository.ListarTodas());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Lista as consultas a um usuário, sendo este um paciente ou médico
        /// </summary>
        /// <returns>Uma lista de consultas associadas</returns>
        [Authorize(Roles ="2,3")]
        [HttpGet("minhas")]
        public IActionResult ListarMinhas()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarMinhas(idUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    erro
                });
            }
        }

        /// <summary>
        /// Busca uma consulta pelo id
        /// </summary>
        /// <param name="id">Id da consulta a ser buscada</param>
        /// <returns>Uma consulta</returns>
        [Authorize(Roles ="1")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Consultum consultaBuscada = _consultaRepository.BuscarPorId(id);

                if (consultaBuscada != null)
                {
                    return Ok(consultaBuscada);
                }

                return BadRequest("A consulta requisitada não existe");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto com atributos a serem inseridos</param>
        /// <returns>status code 201 created</returns>
        [Authorize(Roles ="1")]
        [HttpPost]
        public IActionResult Cadastrar(CadastroViewModel novaConsulta)
        {
            try
            {
                Consultum consultaNova = new Consultum();

                consultaNova.IdPaciente = novaConsulta.IdPaciente;
                consultaNova.IdMedico = novaConsulta.IdMedico;
                consultaNova.IdSituacao = novaConsulta.IdSituacao;
                consultaNova.DataConsulta = novaConsulta.DataConsulta;
                consultaNova.DescricaoConsulta = consultaNova.DescricaoConsulta;

                _consultaRepository.Cadastrar(consultaNova);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cancela ou muda a situaçao de uma consulta
        /// </summary>
        /// <param name="idConsulta">Id da consulta a ser buscada</param>
        /// <param name="status">Objeto com atributos a serem inseridos</param>
        /// <returns>Status code 204 no content</returns>
        [Authorize(Roles ="1")]
        [HttpPatch("{idConsulta}")]
        public IActionResult Cancela(int idConsulta, Consultum status)
        {
            try
            {
                _consultaRepository.Cancela(idConsulta, status.IdSituacao.ToString());

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Adiciona descrição a uma consulta
        /// </summary>
        /// <param name="idConsulta">Id da consulta a ser buscada</param>
        /// <param name="novaConsulta">Objeto com atributos a serem inseridos</param>
        /// <returns>Status code 204 no content</returns>
        [Authorize(Roles = "2")]
        [HttpPatch("descricao/{idConsulta}")]
        public IActionResult AdicionaDescricao(int idConsulta, Consultum novaConsulta)
        {
            try
            {
                _consultaRepository.AdicionarDecrição(idConsulta, novaConsulta);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Atualiza uma consulta
        /// </summary>
        /// <param name="idConsulta">Id da consulta a ser buscada</param>
        /// <param name="consultaAtualizada">Objeto com atributos a serem inseridos</param>
        /// <returns>Status code 204 no content</returns>
        [Authorize(Roles ="1")]
        [HttpPut("{idConsulta}")]
        public IActionResult Atualizar(int idConsulta, Consultum consultaAtualizada)
        {
            try
            {
                _consultaRepository.Atualizar(idConsulta, consultaAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Exclui uma consulta
        /// </summary>
        /// <param name="idConsulta">Id da consulta a ser buscada</param>
        /// <returns>Status code 204 no content</returns>
        [Authorize(Roles ="1")]
        [HttpDelete("{idConsulta}")]
        public IActionResult Deletar(int idConsulta)
        {
            try
            {
                _consultaRepository.Deletar(idConsulta);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}
