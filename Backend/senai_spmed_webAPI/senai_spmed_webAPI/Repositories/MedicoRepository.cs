using senai_spmed_webAPI.Domains;
using senai_spmed_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpmedContext ctx = new SpmedContext();
        public void Atualizar(Medico MedicoAtualizado)
        {
            Medico medicoBuscado = BuscarPorId(MedicoAtualizado.IdMedico);

            if (MedicoAtualizado.IdClinica != 0)
            {
                medicoBuscado.IdClinica = MedicoAtualizado.IdClinica;
            }

            if (MedicoAtualizado.Crmv != null)
            {
                medicoBuscado.Crmv = MedicoAtualizado.Crmv;
            }


            if (MedicoAtualizado.IdEspecialidade != 0)
            {
                medicoBuscado.IdEspecialidade = MedicoAtualizado.IdEspecialidade;
            }

            if (medicoBuscado.IdUsuario != 0)
            {
                medicoBuscado.IdUsuario = MedicoAtualizado.IdUsuario;
            }

            ctx.Medicos.Update(medicoBuscado);

            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int idMedico)
        {
            return ctx.Medicos.Include(u => u.IdUsuarioNavigation).Include(c => c.IdClinicaNavigation).Include(e => e.IdEspecialidadeNavigation).FirstOrDefault(m => m.IdMedico == idMedico);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int idMedico)
        {
            Medico medicoBuscado = BuscarPorId(idMedico);

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos.Include(u => u.IdUsuarioNavigation).Include(c => c.IdClinicaNavigation).Include(e => e.IdEspecialidadeNavigation).ToList();
        }
    }
}
