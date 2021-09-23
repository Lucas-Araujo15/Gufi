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
    public class TipoEventoRepository : ITipoEventoRepository
    {
        GUFIContext ctx = new GUFIContext();
        public void Atualizar(int id, TipoEvento novoTipoEvento)
        {
            TipoEvento tipoEventoBuscado = BuscarPorId(id);

            if (tipoEventoBuscado != null)
            {
                tipoEventoBuscado.TituloTipoEvento = novoTipoEvento.TituloTipoEvento;
            }

            ctx.TipoEventos.Update(tipoEventoBuscado);
            ctx.SaveChanges();
        }

        public TipoEvento BuscarPorId(int id)
        {
            return ctx.TipoEventos.FirstOrDefault(t => t.IdTipoEvento == id);
        }

        public void Cadastrar(TipoEvento tipoEvento)
        {
            ctx.TipoEventos.Add(tipoEvento);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoEvento tipoEventoBuscado = BuscarPorId(id);

            if (tipoEventoBuscado != null)
            {
                ctx.TipoEventos.Remove(tipoEventoBuscado);
                ctx.SaveChanges();
            }
        }

        public List<TipoEvento> ListarTodos()
        {
            return ctx.TipoEventos.Include(x => x.Eventos).ToList();
        }
    }
}
