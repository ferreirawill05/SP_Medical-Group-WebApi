using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// Busca por uma clinica pelo seu ID
        /// </summary>
        /// <param name="idClinica">ID da clinica a ser buscada</param>
        /// <returns>Clínica encontrada</returns>
        Clinica BuscarPorId(int idClinica);

        /// <summary>
        /// Cadastra uma clinica
        /// </summary>
        /// <param name="novaClinica">Recebe os dados de uma clínica cadastrada</param>
        void Cadastrar(Clinica novaClinica);

        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns> Uma lista de clinicas</returns>
        List<Clinica> Listar();

        /// <summary>
        /// Atualiza os dados de uma clinica
        /// </summary>
        /// <param name="clinicaAtualizada">Recebe os novos dados da clinica</param>
        void Atualizar(Clinica clinicaAtualizada);

        /// <summary>
        /// Deleta uma clínica
        /// </summary>
        /// <param name="idClinica"> ID da clínica a ser deletada</param>
        void Deletar(int idClinica);
    }
}
