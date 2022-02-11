using senai_spmed_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Lista todas as paciente
        /// </summary>
        /// <returns>Uma lista de paciente</returns>
        List<Paciente> ListarTodos();

        /// <summary>
        /// Busca um paciente pelo id
        /// </summary>
        /// <param name="idPaciente">id da paciente a ser buscada</param>
        /// <returns>Uma paciente</returns>
        Paciente BuscarPorId(int idPaciente);

        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="novopaciente">Objeto paciente com atributos a serem cadastrados</param>
        void Cadastrar(Paciente novopaciente);

        /// <summary>
        /// Atualiza um paciente existente
        /// </summary>
        /// <param name="idPaciente">id da paciente a ser buscado</param>
        /// <param name="pacienteAtualizado">Objeto paciente com atributos a serem atualizados</param>
        void Atualizar(int idPaciente, Paciente pacienteAtualizado);

        /// <summary>
        /// Exclui um paciente
        /// </summary>
        /// <param name="idPaciente">id do paciente a ser buscado</param>
        void Deletar(int idPaciente);
    }
}
