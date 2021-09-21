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

        public void AprovarRecusar(int idPresenca, string status)
        {
            Presenca presencaBuscada = BuscarPorId(idPresenca);

            switch (status)
            {
                case "1":
                    presencaBuscada.IdSituacao = 1;
                    break;
                case "2":
                    presencaBuscada.IdSituacao = 2;
                    break;
                case "3":
                    presencaBuscada.IdSituacao = 3;
                    break;
                default:
                    presencaBuscada.IdSituacao = presencaBuscada.IdSituacao;
                    break;
            }

            ctx.Presencas.Update(presencaBuscada);
            ctx.SaveChanges();
        }
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

            if (presencaBuscada != null)
            {
                ctx.Presencas.Remove(presencaBuscada);
                ctx.SaveChanges();
            }
        }

        public void Inscrever(Presenca inscricao)
        {
            ctx.Presencas.Add(inscricao);
            ctx.SaveChanges();
        }

        public List<Presenca> ListarMinhas(int id)
        {
            return ctx.Presencas
                .Include(x => x.IdUsuarioNavigation)
                .Include("IdSituacaoNavigation")
                .Include(y => y.IdEventoNavigation.IdTipoEventoNavigation)
                .Where(x => x.IdUsuario == id).ToList();
        }

        public List<Presenca> ListarTodos()
        {
            return ctx.Presencas.Include(x => x.IdEventoNavigation).Include(y => y.IdSituacaoNavigation).Include(z => z.IdUsuarioNavigation).ToList();
        }
    }
}
