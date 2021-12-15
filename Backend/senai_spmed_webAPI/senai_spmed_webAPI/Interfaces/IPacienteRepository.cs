using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Busca por um paciente pelo seu ID
        /// </summary>
        /// <param name="idPaciente">ID do usuário a ser buscado</param>
        /// <returns>Usuário encontrado</returns>
        Paciente BuscarPorId(int idPaciente);

        /// <summary>
        /// Cadastra um paciente
        /// </summary>
        /// <param name="novoPaciente">Recebe os dados de um usuário cadastrado</param>
        void Cadastrar(Paciente novoPaciente);

        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns> Uma lista de usuários</returns>
        List<Paciente> Listar();

        /// <summary>
        /// Atualiza os dados de um paciente
        /// </summary>
        /// <param name="PacienteAtualizado">Recebe os novos dados do paciente</param>
        void Atualizar(Paciente PacienteAtualizado);

        /// <summary>
        /// Deleta um paciente
        /// </summary>
        /// <param name="idPaciente"> ID do paciente a ser deletado</param>
        void Deletar(int idPaciente);
    }
}
