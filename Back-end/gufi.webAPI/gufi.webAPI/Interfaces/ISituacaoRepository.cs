using gufi.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gufi.webAPI.Interfaces
{
    interface ISituacaoRepository
    {
        /// <summary>
        /// Cadastra uma nova situação
        /// </summary>
        /// <param name="situacao">Objeto Situacao que será cadastrado</param>
        void Cadastrar(Situacao situacao);

        /// <summary>
        /// Lista todas as situações cadastradas
        /// </summary>
        /// <returns>Uma lista de situações possíveis</returns>
        List<Situacao> ListarTodos();

        /// <summary>
        /// Retorna uma situação específica
        /// </summary>
        /// <param name="id">ID da situação</param>
        /// <returns>Objeto Situacao que foi buscado</returns>
        Situacao BuscarPorId(int id);

        /// <summary>
        /// Atualiza um situação específica
        /// </summary>
        /// <param name="id">ID da situação</param>
        /// <param name="novaSituacao">Objeto Situacao com as novas informações</param>
        void Atualizar(int id, Situacao novaSituacao);

        /// <summary>
        /// Deleta uma situação específica
        /// </summary>
        /// <param name="id">ID da situação a ser deletada</param>
        void Deletar(int id);
    }
}
