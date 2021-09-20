using gufi.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gufi.webAPI.Interfaces
{
    interface IInstituicaoRepository
    {
        /// <summary>
        /// Cadastra uma nova instituição
        /// </summary>
        /// <param name="instituicao">Objeto Instituicao a ser cadastrado</param>
        void Cadastrar(Instituicao instituicao);

        /// <summary>
        /// Lista todas as instituições cadastradas
        /// </summary>
        /// <returns>Uma lista de instituições</returns>
        List<Instituicao> ListarTodos();

        /// <summary>
        /// Retorna uma instituição específica
        /// </summary>
        /// <param name="id">ID da instituição</param>
        /// <returns>Objeto Instituicao que foi buscado</returns>
        Instituicao BuscarPorId(int id);

        /// <summary>
        /// Atualiza uma instituição específica
        /// </summary>
        /// <param name="id">ID da instituição</param>
        /// <param name="novaInstituicao">Objeto Instituicao com as novas informações</param>
        void Atualizar(int id, Instituicao novaInstituicao);

        /// <summary>
        /// Deleta uma instituição específica
        /// </summary>
        /// <param name="id">ID da instituição a ser deletada</param>
        void Deletar(int id);
    }
}
