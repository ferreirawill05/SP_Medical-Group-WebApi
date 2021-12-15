using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Busca por um médico pelo seu ID
        /// </summary>
        /// <param name="idMedico">ID do usuário a ser buscado</param>
        /// <returns>Usuário encontrado</returns>
        Medico BuscarPorId(int idMedico);

        /// <summary>
        /// Cadastra um médico
        /// </summary>
        /// <param name="novoMedico">Recebe os dados de um usuário cadastrado</param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Lista todos os médicos
        /// </summary>
        /// <returns> Uma lista de usuários</returns>
        List<Medico> Listar();

        /// <summary>
        /// Atualiza os dados de um médico
        /// </summary>
        /// <param name="MedicoAtualizado">Recebe os novos dados do médico</param>
        void Atualizar(Medico MedicoAtualizado);

        /// <summary>
        /// Deleta um médico
        /// </summary>
        /// <param name="idMedico"> ID do médico a ser deletado</param>
        void Deletar(int idMedico);
    }
}
