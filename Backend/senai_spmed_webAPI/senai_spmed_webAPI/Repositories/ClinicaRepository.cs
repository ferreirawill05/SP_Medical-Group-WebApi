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
        SpmedContext ctx = new SpmedContext();
        public void Atualizar(Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = BuscarPorId(clinicaAtualizada.IdClinica);

            clinicaBuscada.HorarioAbertura = clinicaAtualizada.HorarioAbertura;
            clinicaBuscada.HorarioFechamento = clinicaAtualizada.HorarioFechamento;


            if (clinicaAtualizada.NomeFantasia != null)
            {
                clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
            }

            if (clinicaAtualizada.RazaoSocial != null)
            {
                clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
            }

            if (clinicaAtualizada.Cnpj != null)
            {
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
            }

            if (clinicaAtualizada.Endereco != null)
            {
                clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
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

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
