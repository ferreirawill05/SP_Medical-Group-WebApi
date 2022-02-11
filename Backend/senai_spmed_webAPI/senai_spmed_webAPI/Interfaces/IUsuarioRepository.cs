using Microsoft.AspNetCore.Http;
using senai_spmed_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Valida o usuário 
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Um objeto do tipo Usuario que foi encontrado</returns>
        Usuario Login(string email, string senha);

        /// <summary>
        /// Lista todas as usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Busca uma usuario pelo id
        /// </summary>
        /// <param name="idUsuario">id do usuario a ser buscado</param>
        /// <returns>Um usuario</returns>
        Usuario BuscarPorId(int idUsuario);

        /// <summary>
        /// Cadastra uma nova usuario
        /// </summary>
        /// <param name="novausuario">Objeto usuario com atributos a serem cadastrados</param>
        void Cadastrar(Usuario novausuario);

        /// <summary>
        /// Atualiza uma usuario existente
        /// </summary>
        /// <param name="idUsuario">id da usuario a ser buscada</param>
        /// <param name="usuarioAtualizada">Objeto usuario com atributos a serem atualizados</param>
        void Atualizar(int idUsuario, Usuario usuarioAtualizada);

        /// <summary>
        /// Exclui uma usuario
        /// </summary>
        /// <param name="idUsuario">id da usuario a ser buscada</param>
        void Deletar(int idUsuario);

        void SalvarPerfilDir(IFormFile foto, int idUsuario);

        string ConsultarPerfilDir(int idUsuario);
    }
}
