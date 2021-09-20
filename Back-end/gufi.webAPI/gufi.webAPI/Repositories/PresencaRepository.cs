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
    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();
        public void Atualizar(int id, Presenca novaPresenca)
        {
            Presenca presencaBuscada = BuscarPorId(id);

            if (presencaBuscada != null)
            {
                presencaBuscada.IdEvento = novaPresenca.IdEvento;
                presencaBuscada.IdSituacao = novaPresenca.IdSituacao;
                presencaBuscada.IdUsuario = novaPresenca.IdUsuario;
            }

            ctx.Presencas.Update(presencaBuscada);
            ctx.SaveChanges();
        }

        public Presenca BuscarPorId(int id)
        {
            return ctx.Presencas.FirstOrDefault(p => p.IdPresenca == id);
        }

        public void Cadastrar(Presenca presenca)
        {
            ctx.Presencas.Add(presenca);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Presenca presencaBuscada = BuscarPorId(id);

            if(presencaBuscada != null)
            {
                ctx.Presencas.Remove(presencaBuscada);
                ctx.SaveChanges();
            }
        }

        public List<Presenca> ListarTodos()
        {
            return ctx.Presencas.Include(x => x.IdEventoNavigation).Include(y => y.IdSituacaoNavigation).Include(z => z.IdUsuarioNavigation).ToList();
        }
    }
}
