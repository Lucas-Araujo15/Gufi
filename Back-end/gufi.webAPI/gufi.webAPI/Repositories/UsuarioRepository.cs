using gufi.webAPI.Contexts;
using gufi.webAPI.Domains;
using gufi.webAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace gufi.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        GUFIContext ctx = new GUFIContext();

        public void Atualizar(int id, Usuario novoUsuario)
        {
            Usuario usuarioBuscado = BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.IdTipoUsuario = novoUsuario.IdTipoUsuario;
                usuarioBuscado.NomeUsuario = novoUsuario.NomeUsuario;
                usuarioBuscado.Senha = novoUsuario.Senha;
                usuarioBuscado.Email = novoUsuario.Email;
            }

            ctx.Usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
        }

        public string ConsultarPerfilDir(int idUsuario)
        {
            string nome_novo = idUsuario.ToString() + ".png";
            string caminho = Path.Combine("Perfil", nome_novo);

            if (File.Exists(caminho))
            {
                byte[] bytesArquivo = File.ReadAllBytes(caminho);
                return Convert.ToBase64String(bytesArquivo);
            }

            return null;
        }

        public string ConsultarPerfilBD(int idUsuario)
        {
            ImagemPerfil imagemUsuario = new ImagemPerfil();

            imagemUsuario = ctx.ImagemPerfils.FirstOrDefault(i => i.IdUsuario == idUsuario);

            if (imagemUsuario != null)
            {
                return Convert.ToBase64String(imagemUsuario.Binario);
            }

            return null;
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                ctx.Usuarios.Remove(usuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.Include(x => x.IdTipoUsuarioNavigation).Include(y => y.Presencas).ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public void SalvarPerfilBD(IFormFile foto, int id)
        {
            ImagemPerfil imagemPerfil = new ImagemPerfil();

            using(var ms = new MemoryStream())
            {
                foto.CopyTo(ms);
                imagemPerfil.NomeArquivo = foto.FileName;
                imagemPerfil.MimeType = foto.FileName.Split('.').Last();
                imagemPerfil.Binario = ms.ToArray();
                imagemPerfil.IdUsuario = id;
            }

            ImagemPerfil fotoexistente = new ImagemPerfil();
            fotoexistente = ctx.ImagemPerfils.FirstOrDefault(i => i.IdUsuario == id);

            if (fotoexistente != null)
            {
                fotoexistente.Binario = imagemPerfil.Binario;
                fotoexistente.NomeArquivo = imagemPerfil.NomeArquivo;
                fotoexistente.MimeType = imagemPerfil.MimeType;
                fotoexistente.IdUsuario = id;

                //atualiza a imagem de perfil do usuario.
                ctx.ImagemPerfils.Update(fotoexistente);
            }
            else
            {
                ctx.ImagemPerfils.Add(imagemPerfil);
            }

            //salvar as modificações.
            ctx.SaveChanges();
        }

        public void SalvarPerfilDir(IFormFile foto, int id)
        {
            string nome_novo = id.ToString() + ".png";

            using (var stream = new FileStream(Path.Combine("perfil", nome_novo), FileMode.Create))
            {
                foto.CopyTo(stream);
            }
        }
    }
}
