using senai_spmed_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Lista todas as medico
        /// </summary>
        /// <returns>Uma lista de medico</returns>
        List<Medico> ListarTodos();

        /// <summary>
        /// Busca um medico pelo id
        /// </summary>
        /// <param name="idMedico">id da medico a ser buscada</param>
        /// <returns>Uma medico</returns>
        Medico BuscarPorId(int idMedico);

        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="novoMedico">Objeto medico com atributos a serem cadastrados</param>
        void Cadastrar(Medico novomedico);

        /// <summary>
        /// Atualiza um medico existente
        /// </summary>
        /// <param name="idMedico">id da medico a ser buscado</param>
        /// <param name="medicoAtualizado">Objeto medico com atributos a serem atualizados</param>
        void Atualizar(int idMedico, Medico medicoAtualizado);

        /// <summary>
        /// Exclui um medico
        /// </summary>
        /// <param name="idMedico">id do medico a ser buscado</param>
        void Deletar(int idMedico);
    }
}
