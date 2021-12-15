using senai_spmed_webAPI.Domains;
using senai_spmed_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SpmedContext ctx = new SpmedContext();
        public void AdicionarDescricao(int idConsulta, string descricao)
        {
            Consulta consultaBuscada = BuscarPorId(idConsulta);

            if (descricao == null || descricao == "")
            {
                consultaBuscada.Descricao = consultaBuscada.Descricao;
            }
            else
            {
                consultaBuscada.Descricao = descricao;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public void AlterarStatus(int idConsulta, int status)
        {
            Consulta consultaBuscada = BuscarPorId(idConsulta);

            switch (status)
            {
                case 1:
                    consultaBuscada.IdSituacao = 1;
                    break;

                case 2:
                    consultaBuscada.IdSituacao = 2;
                    break;

                case 3:
                    consultaBuscada.IdSituacao = 3;
                    break;

                default:
                    consultaBuscada.IdSituacao = consultaBuscada.IdSituacao;
                    break;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public void Atualizar(Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = BuscarPorId(consultaAtualizada.IdConsulta);

            if (consultaAtualizada.IdMedico != 0)
            {
                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
            }

            if (consultaAtualizada.IdPaciente != 0)
            {
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
            }

            if (consultaAtualizada.IdSituacao != 0)
            {
                consultaBuscada.IdSituacao = consultaAtualizada.IdSituacao;
            }

            consultaBuscada.DataeHora = consultaAtualizada.DataeHora;

            if (consultaAtualizada.Descricao != null)
            {
                consultaBuscada.Descricao = consultaAtualizada.Descricao;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int idConsulta)
        {
            return ctx.Consulta
               .Include(p => p.IdMedicoNavigation)
               .Include(p => p.IdMedicoNavigation.IdUsuarioNavigation)
               .Include(p => p.IdPacienteNavigation)
               .Include(p => p.IdPacienteNavigation.IdUsuarioNavigation)
               .Include(p => p.IdSituacaoNavigation)
                .FirstOrDefault(c => c.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            Consulta consultaBuscada = BuscarPorId(idConsulta);

            ctx.Consulta.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consulta
               .Include(p => p.IdMedicoNavigation)
               .Include(p => p.IdMedicoNavigation.IdUsuarioNavigation)
               .Include(p => p.IdPacienteNavigation)
               .Include(p => p.IdPacienteNavigation.IdUsuarioNavigation)
               .Include(p => p.IdSituacaoNavigation)
                .ToList();
        }

        public List<Consulta> ListarMinhas(int idUsuario)
        {
            return ctx.Consulta
               .Include(p => p.IdMedicoNavigation)
               .Include(p => p.IdMedicoNavigation.IdUsuarioNavigation)
               .Include(p => p.IdPacienteNavigation)
               .Include(p => p.IdPacienteNavigation.IdUsuarioNavigation)
               .Include(p => p.IdSituacaoNavigation)
               .Where(p => p.IdMedicoNavigation.IdUsuario == idUsuario || p.IdPacienteNavigation.IdUsuario == idUsuario)
               .ToList();
        }
    }
}
