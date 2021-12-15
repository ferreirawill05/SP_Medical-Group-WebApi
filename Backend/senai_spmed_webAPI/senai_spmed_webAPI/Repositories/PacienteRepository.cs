using senai_spmed_webAPI.Domains;
using senai_spmed_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SpmedContext ctx = new SpmedContext();
        public void Atualizar(Paciente PacienteAtualizado)
        {
            Paciente pacienteBuscado = BuscarPorId(PacienteAtualizado.IdPaciente);

            pacienteBuscado.DataNascimento = PacienteAtualizado.DataNascimento;

            if (PacienteAtualizado.IdUsuario != 0)
            {
                pacienteBuscado.IdUsuario = PacienteAtualizado.IdUsuario;
            }

            if (PacienteAtualizado.Cpf != null)
            {
                pacienteBuscado.Cpf = PacienteAtualizado.Cpf;
            }

            if (PacienteAtualizado.Endereco != null)
            {
                pacienteBuscado.Endereco = PacienteAtualizado.Endereco;
            }

            if (PacienteAtualizado.Rg != null)
            {
                pacienteBuscado.Rg = PacienteAtualizado.Rg;
            }

            if (PacienteAtualizado.Telefone != null)
            {
                pacienteBuscado.Telefone = PacienteAtualizado.Telefone;
            }

            ctx.Pacientes.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int idPaciente)
        {
            return ctx.Pacientes.Include(u => u.IdUsuarioNavigation).FirstOrDefault(p => p.IdPaciente == idPaciente);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int idPaciente)
        {
            Paciente pacienteBuscado = BuscarPorId(idPaciente);

            ctx.Pacientes.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes.Include(u => u.IdUsuarioNavigation).ToList();
        }
    }
}
