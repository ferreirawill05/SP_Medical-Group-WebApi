using senai_spmed_webAPI.Context;
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
        SPMedContext ctx = new SPMedContext();
        public void Atualizar(int idPaciente, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = BuscarPorId(idPaciente);

            if (pacienteAtualizado.IdUsuario != null && pacienteAtualizado.IdEndereco != null && pacienteAtualizado.NomePaciente != null && pacienteAtualizado.DataNascimento != null && pacienteAtualizado.Telefone != null && pacienteAtualizado.Rg != null && pacienteAtualizado.Cpf != null)
            {
                pacienteBuscado.IdUsuario = pacienteAtualizado.IdUsuario;
                pacienteBuscado.IdEndereco = pacienteAtualizado.IdEndereco;
                pacienteBuscado.NomePaciente = pacienteAtualizado.NomePaciente;
                pacienteBuscado.DataNascimento = pacienteAtualizado.DataNascimento;
                pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
                pacienteBuscado.Rg = pacienteAtualizado.Rg;
                pacienteBuscado.Cpf = pacienteAtualizado.Cpf;
            }

            ctx.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int idPaciente)
        {
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == idPaciente);
        }

        public void Cadastrar(Paciente novopaciente)
        {
            if (DateTime.Now > novopaciente.DataNascimento)
            {
                ctx.Add(novopaciente);

                ctx.SaveChanges();
            }

            
        }

        public void Deletar(int idPaciente)
        {
            Paciente pacienteBuscado = BuscarPorId(idPaciente);

            ctx.Pacientes.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
