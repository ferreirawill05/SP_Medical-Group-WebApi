using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmed_webAPI.Interfaces;
using senai_spmed_webAPI.Repositories;
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
    public class PerfisController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public PerfisController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Salva uma foto no perfil
        /// </summary>
        /// <param name="arquivo">Arquivo com a foto a ser postada</param>
        /// <returns>Status code Ok</returns>
        [Authorize(Roles = "1,2,3")]
        [HttpPost("imagem/dir")]
        public IActionResult postDir(IFormFile arquivo)
        {
            try
            {
                if (arquivo.Length > 500000)
                {
                    return BadRequest(new { mensagem = "o tamanho máximo da imagem foi atingido" });
                }

                string extensao = arquivo.FileName.Split('.').Last();

                if (extensao != "png")
                {
                    return BadRequest(new { mensagem = "Apenas arquivos .png são aceitados" });
                }

                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _usuarioRepository.SalvarPerfilDir(arquivo, idUsuario);

                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Pega uma foto salva 
        /// </summary>
        /// <returns>Uma base64 de uma foto salva</returns>
        [Authorize(Roles ="1,2,3")]
        [HttpGet("imagem/dir")]
        public IActionResult getDir()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = _usuarioRepository.ConsultarPerfilDir(idUsuario);

                return Ok(base64);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
