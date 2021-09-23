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
    public class InstituicaoRepository : IInstituicaoRepository
    {
        GUFIContext ctx = new GUFIContext();
        public void Atualizar(int id, Instituicao novaInstituicao)
        {
            Instituicao instituicaoBuscada = BuscarPorId(id);

            if (instituicaoBuscada != null)
            {
                instituicaoBuscada.Cnpj = novaInstituicao.Cnpj;
                instituicaoBuscada.Endereco = novaInstituicao.Endereco;
                instituicaoBuscada.NomeFantasia = novaInstituicao.NomeFantasia;
            }

            ctx.Instituicaos.Update(instituicaoBuscada);
            ctx.SaveChanges();
        }

        public Instituicao BuscarPorId(int id)
        {
            return ctx.Instituicaos.FirstOrDefault(i => i.IdInstituicao == id);
        }

        public void Cadastrar(Instituicao instituicao)
        {
            ctx.Instituicaos.Add(instituicao);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Instituicao instituicaoBuscada = BuscarPorId(id);

            if(instituicaoBuscada != null)
            {
                ctx.Instituicaos.Remove(instituicaoBuscada);
                ctx.SaveChanges();
            }
        }

        public List<Instituicao> ListarTodos()
        {
            return ctx.Instituicaos.Include(x => x.Eventos).ToList();
        }
    }
}
