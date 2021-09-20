using gufi.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gufi.webAPI.Interfaces
{
    interface IPresencaRepository
    {
        /// <summary>
        /// Cadastra uma nova presença
        /// </summary>
        /// <param name="presenca"></param>
        void Cadastrar(Presenca presenca);

        /// <summary>
        /// Lista todas as presenças cadastradas
        /// </summary>
        /// <returns>Uma lista de presenças</returns>
        List<Presenca> ListarTodos();

        /// <summary>
        /// Retorna uma presença específica
        /// </summary>
        /// <param name="id">ID da presença</param>
        /// <returns>Objeto Presenca que foi buscado</returns>
        Presenca BuscarPorId(int id);

        /// <summary>
        /// Atualiza uma presença específica
        /// </summary>
        /// <param name="id">ID da presença</param>
        /// <param name="novaPresenca">Objeto Presenca com as novas informações</param>
        void Atualizar(int id, Presenca novaPresenca);

        /// <summary>
        /// Deleta uma presença específica
        /// </summary>
        /// <param name="id">ID da presença a ser deletada</param>
        void Deletar(int id);
    }
}
