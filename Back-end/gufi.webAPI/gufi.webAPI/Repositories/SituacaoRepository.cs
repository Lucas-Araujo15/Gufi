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
    public class SituacaoRepository : ISituacaoRepository
    {
        GufiContext ctx = new GufiContext();
        public void Atualizar(int id, Situacao novaSituacao)
        {
            Situacao situacaoBuscada = BuscarPorId(id);

            if (situacaoBuscada != null)
            {
                situacaoBuscada.Descricao = novaSituacao.Descricao;
            }

            ctx.Situacaos.Update(situacaoBuscada);
            ctx.SaveChanges();
        }

        public Situacao BuscarPorId(int id)
        {
            return ctx.Situacaos.FirstOrDefault(s => s.IdSituacao == id);
        }

        public void Cadastrar(Situacao situacao)
        {
            ctx.Situacaos.Add(situacao);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Situacao situacaoBuscada = BuscarPorId(id);

            if (situacaoBuscada != null)
            {
                ctx.Situacaos.Remove(situacaoBuscada);
                ctx.SaveChanges();
            }
        }

        public List<Situacao> ListarTodos()
        {
            return ctx.Situacaos.Include(x => x.Descricao).Include(y => y.Presencas).ToList();
        }
    }
}
