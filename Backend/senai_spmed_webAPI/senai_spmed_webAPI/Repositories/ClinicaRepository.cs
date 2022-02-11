using senai_spmed_webAPI.Context;
using senai_spmed_webAPI.Domains;
using senai_spmed_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SPMedContext ctx = new SPMedContext();

        public void Atualizar(int idClinica, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = BuscarPorId(idClinica);

            if (clinicaAtualizada.IdEndereco != null && clinicaAtualizada.NomeFantasia != null && clinicaAtualizada.Cnpj != null && clinicaAtualizada.RazaoSocial != null && clinicaAtualizada.HorarioAbertura != null && clinicaAtualizada.HorarioFechamento != null)
            {
                clinicaBuscada.IdEndereco = clinicaAtualizada.IdEndereco;
                clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
                clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
                clinicaBuscada.HorarioAbertura = clinicaAtualizada.HorarioAbertura;
                clinicaBuscada.HorarioFechamento = clinicaAtualizada.HorarioFechamento;

            }

            ctx.Clinicas.Update(clinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int idClinica)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == idClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            Clinica clinicaBuscada = BuscarPorId(idClinica);

            ctx.Clinicas.Remove(clinicaBuscada);

            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas
                .Select(c => new Clinica
                {
                    IdClinica = c.IdClinica,
                    IdEnderecoNavigation = new Endereco
                    {
                        Rua = c.IdEnderecoNavigation.Rua,
                        Numero = c.IdEnderecoNavigation.Numero,
                        Bairro = c.IdEnderecoNavigation.Bairro,
                        Cidade = c.IdEnderecoNavigation.Cidade,
                        Estado = c.IdEnderecoNavigation.Estado,
                        Cep = c.IdEnderecoNavigation.Cep
                    },
                    NomeFantasia = c.NomeFantasia,
                    Cnpj = c.Cnpj,
                    RazaoSocial = c.RazaoSocial,
                    HorarioAbertura = c.HorarioAbertura,
                    HorarioFechamento = c.HorarioFechamento,
                    Medicos = c.Medicos
                }).ToList();
        }
    }
}
