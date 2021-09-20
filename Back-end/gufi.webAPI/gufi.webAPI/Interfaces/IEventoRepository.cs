using gufi.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gufi.webAPI.Interfaces
{
    interface IEventoRepository
    {
        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="evento">Objeto Evento a ser cadastrado</param>
        void Cadastar(Evento evento);

        /// <summary>
        /// Lista todos os eventos cadastrados
        /// </summary>
        /// <returns>Uma lista de eventos</returns>
        List<Evento> ListarTodos();

        /// <summary>
        /// Retorna um evento em específico
        /// </summary>
        /// <param name="id">ID do evento</param>
        /// <returns>Evento que foi buscado</returns>
        Evento BuscarPorId(int id);

        /// <summary>
        /// Atualiza um evento específico
        /// </summary>
        /// <param name="id">ID do evento a ser atualizado</param>
        /// <param name="novoEvento">Objeto Evento com as novas informações</param>
        void Atualizar(int id, Evento novoEvento);

        /// <summary>
        /// Deleta um evento específico
        /// </summary>
        /// <param name="id">ID do evento a ser deletado</param>
        void Deletar(int id);
    }
}
