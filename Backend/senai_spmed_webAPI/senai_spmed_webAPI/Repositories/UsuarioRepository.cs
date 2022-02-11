using Microsoft.AspNetCore.Http;
using senai_spmed_webAPI.Context;
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
        SPMedContext ctx = new SPMedContext();

        public void Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            if (usuarioAtualizado.IdTipoUsuario != null && usuarioAtualizado.Email != null && usuarioAtualizado.Senha != null)
            {
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novousuario)
        {
            ctx.Add(novousuario);

            ctx.SaveChanges();
        }

        public string ConsultarPerfilDir(int idUsuario)
        {
            string nomeNovo = idUsuario.ToString() + ".png";

            string caminho = Path.Combine("Perfil", nomeNovo);

            //analisa se o caminho existe
            if (File.Exists(caminho))
            {
                //recupera o array de bytes
                byte[] bytesArquivo = File.ReadAllBytes(caminho);

                //converte em base64
                return Convert.ToBase64String(bytesArquivo);
            }

            return null;
        }

        public void Deletar(int idUsuario)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public void SalvarPerfilDir(IFormFile foto, int idUsuario)
        {
            //Define o nome do arquivo ocm o Id do Usuairo + .png
            string nomeNovo = idUsuario.ToString() + ".png";

            //FileStream fornece uma exibicao para uma sequencia de bytes, dando suporte para leitura e gravação
            using (var stream = new FileStream(Path.Combine("Perfil", nomeNovo), FileMode.Create))
            {
                //copipa todos os elementos(array de bytes)  para o caminho indicado
                foto.CopyTo(stream);
            }
        }
    }
}
