using Microsoft.AspNetCore.Http;
using senai_spmed_webAPI.Domains;
using senai_spmed_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmed_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpmedContext ctx = new SpmedContext();

        public void Atualizar(Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(usuarioAtualizado.IdUsuario);

            if (usuarioAtualizado.NomeUsuario != null)
            {
                usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            }

            if (usuarioAtualizado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            if (usuarioAtualizado.Senha != null)
            {
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public string ConsultarPerfilDir(int id_usuario)
        {
            CriarPasta();

            string nome_novo = id_usuario.ToString() + ".png";
            string caminho = Path.Combine("Perfil", nome_novo);

            if (File.Exists(caminho))
            {
                byte[] bytesArquivo = File.ReadAllBytes(caminho);
                return Convert.ToBase64String(bytesArquivo);
            }

            return null;

        }

        public void CriarPasta()
        {
            string pasta = "Perfil";

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
        }

        public void Deletar(int idUsuario)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public void SalvarPerfilDir(IFormFile foto, int id_usuario)
        {
            string nome_novo = id_usuario.ToString() + ".png";

            using (var stream = new FileStream(Path.Combine("Perfil", nome_novo), FileMode.Create))
            {
                foto.CopyTo(stream);
            }
        }
    }
}
