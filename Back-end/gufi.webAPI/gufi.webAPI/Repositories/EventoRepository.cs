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
    public class EventoRepository : IEventoRepository
    {
        GufiContext ctx = new GufiContext();
        public void Atualizar(int id, Evento novoEvento)
        {
            Evento eventoBuscado = BuscarPorId(id);

            if(eventoBuscado != null)
            {
                eventoBuscado.IdInstituicao = novoEvento.IdInstituicao;
                eventoBuscado.IdTipoEvento = novoEvento.IdTipoEvento;
                eventoBuscado.NomeEvento = novoEvento.NomeEvento;
                eventoBuscado.Descricao = novoEvento.Descricao;
                eventoBuscado.DataEvento = novoEvento.DataEvento;
                eventoBuscado.AcessoLivre = novoEvento.AcessoLivre;
            }

            ctx.Eventos.Update(eventoBuscado);
            ctx.SaveChanges();
        }

        public Evento BuscarPorId(int id)
        {
            return ctx.Eventos.FirstOrDefault(e => e.IdEvento == id);
        }

        public void Cadastar(Evento evento)
        {
            ctx.Eventos.Add(evento);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Evento eventoBuscado = BuscarPorId(id);

            if (eventoBuscado != null)
            {
                ctx.Eventos.Remove(eventoBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Evento> ListarTodos()
        {
            return ctx.Eventos.Include(x => x.IdTipoEventoNavigation).Include(y => y.IdInstituicaoNavigation).ToList();
        }
    }
}
