using gufi.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gufi.webAPI.Interfaces
{
    interface ITipoEventoRepository
    {
        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="tipoEvento">Objeto TipoEvento a ser cadastrado</param>
        void Cadastrar(TipoEvento tipoEvento);

        /// <summary>
        /// Lista todos os tipos de evento cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de tipos de evento</returns>
        List<TipoEvento> ListarTodos();

        /// <summary>
        /// Retorna um tipo de evento específico
        /// </summary>
        /// <param name="id">ID do tipo de evento</param>
        /// <returns>Objeto TipoEvento que foi buscado</returns>
        TipoEvento BuscarPorId(int id);

        /// <summary>
        /// Atualiza um tipo de evento específico
        /// </summary>
        /// <param name="id">ID do tipo de evento</param>
        /// <param name="novoTipoEvento">Objeto TipoEvento com as novas informações</param>
        void Atualizar(int id, TipoEvento novoTipoEvento);

        /// <summary>
        /// Deleta um tipo de evento específico
        /// </summary>
        /// <param name="id">ID do tipo de evento a ser deletado</param>
        void Deletar(int id);
    }
}
