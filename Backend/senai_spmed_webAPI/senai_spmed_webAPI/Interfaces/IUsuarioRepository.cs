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
        /// <param name="email">recebe o e-mail do usuario</param>
        /// <param name="senha">recebe a senha do usuario</param>
        /// <returns>O usuário encontrado</returns>
        Usuario Login(string email, string senha);

        /// <summary>
        /// Busca por um usuário pelo seu ID
        /// </summary>
        /// <param name="idUsuario">ID do usuário a ser buscado</param>
        /// <returns>Usuário encontrado</returns>
        Usuario BuscarPorId(int idUsuario);

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoUsuario">Recebe os dados de um usuário cadastrado</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns> Uma lista de usuários</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Atualiza os dados de um usuário
        /// </summary>
        /// <param name="usuarioAtualizado">Recebe os novos dados do usuário</param>
        void Atualizar(Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="idUsuario"> ID do usuário a ser deletado</param>
        void Deletar(int idUsuario);

        /// <summary>
        /// Salva a foto de um usuário
        /// </summary>
        /// <param name="foto">foto a ser salva</param>
        /// <param name="id_usuario">id do usuário a qual a foto pertence</param>
        void SalvarPerfilDir(IFormFile foto, int id_usuario);

        /// <summary>
        /// Consulta a foto do usuário
        /// </summary>
        /// <param name="id_usuario">id do usuário a ter a foto buscada</param>
        /// <returns>A foto em base64</returns>
        string ConsultarPerfilDir(int id_usuario);

        /// <summary>
        /// Cria pasta caso não exista
        /// </summary>
        void CriarPasta();
    }
}
