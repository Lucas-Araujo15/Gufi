using gufi.webAPI.Contexts;
using gufi.webAPI.Domains;
using gufi.webAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gufi.webAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        GufiContext ctx = new GufiContext();
        public void Atualizar(int id, TipoUsuario novoTipoUsuario)
        {
            TipoUsuario tipoUsuarioBuscado = BuscarPorId(id);

            if (tipoUsuarioBuscado != null)
            {
                tipoUsuarioBuscado.TituloTipoUsuario = novoTipoUsuario.TituloTipoUsuario;
            }

            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            ctx.TipoUsuarios.Add(tipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoUsuarioBuscado = BuscarPorId(id);

            if (tipoUsuarioBuscado != null)
            {
                ctx.TipoUsuarios.Remove(tipoUsuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios.Include(x => x.Usuarios).ToList();
        }
    }
}
