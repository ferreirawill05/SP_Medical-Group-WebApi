using senai_spmed_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>Uma lista de clinicas</returns>
        List<Clinica> ListarTodos();

        /// <summary>
        /// Busca uma clinica pelo id
        /// </summary>
        /// <param name="idClinica">id da clinica a ser buscada</param>
        /// <returns>Uma clinica</returns>
        Clinica BuscarPorId(int idClinica);

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica">Objeto clinica com atributos a serem cadastrados</param>
        void Cadastrar(Clinica novaClinica);

        /// <summary>
        /// Atualiza uma clinica existente
        /// </summary>
        /// <param name="idClinica">id da clinica a ser buscada</param>
        /// <param name="clinicaAtualizada">Objeto clinica com atributos a serem atualizados</param>
        void Atualizar(int idClinica, Clinica clinicaAtualizada);

        /// <summary>
        /// Exclui uma clinica
        /// </summary>
        /// <param name="idClinica">id da clinica a ser buscada</param>
        void Deletar(int idClinica);
    }
}
