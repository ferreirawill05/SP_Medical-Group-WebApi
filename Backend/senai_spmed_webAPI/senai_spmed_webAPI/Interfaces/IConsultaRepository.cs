using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Altera o status de uma consulta
        /// </summary>
        /// <param name="idConsulta">Id da consulta a ser atualizada</param>
        /// <param name="idSituacao">Id da nova situação de consulta</param>
        void AlterarStatus(int idConsulta, int idSituacao);

        /// <summary>
        /// Lista as consulta relacionadas a um usuario
        /// </summary>
        /// <param name="idUsuario">Id do usuário a ter suas consultas listadas</param>
        List<Consulta> ListarMinhas(int idUsuario);

        /// <summary>
        /// Atualiza a descrição de uma consulta 
        /// </summary>
        /// <param name="idConsulta">Id da consulta a ser atualizada</param>
        /// <param name="descricao">Descrição as ser atualizada</param>
        void AdicionarDescricao(int idConsulta, string descricao);

        /// <summary>
        /// Busca por um consulta pelo seu ID
        /// </summary>
        /// <param name="idConsulta">ID do consulta a ser buscado</param>
        /// <returns>Consulta encontrada</returns>
        Consulta BuscarPorId(int idConsulta);

        /// <summary>
        /// Cadastra uma consulta
        /// </summary>
        /// <param name="novaConsulta">Recebe os dados de uma consulta cadastrada</param>
        void Cadastrar(Consulta novaConsulta);

        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns> Uma lista de consultas</returns>
        List<Consulta> Listar();

        /// <summary>
        /// Atualiza os dados de uma consulta
        /// </summary>
        /// <param name="consultaAtualizada">Recebe os novos dados da consulta</param>
        void Atualizar(Consulta consultaAtualizada);

        /// <summary>
        /// Deleta uma consulta
        /// </summary>
        /// <param name="idConsulta"> ID da consulta a ser deletada</param>
        void Deletar(int idConsulta);
    }
}
