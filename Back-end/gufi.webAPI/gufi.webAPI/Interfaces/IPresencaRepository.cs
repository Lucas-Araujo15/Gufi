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

        /// <summary>
        /// Lista todas as presença de um usuário específico
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Uma lista de presenças</returns>
        List<Presenca> ListarMinhas(int id);

        /// <summary>
        /// Altera o status de uma presença
        /// </summary>
        /// <param name="idPresenca">ID da presença que será alterada</param>
        /// <param name="status">Novo status para a presença</param>
        void AprovarRecusar(int idPresenca, string status);

        /// <summary>
        /// Inscreve um novo usuário
        /// </summary>
        /// <param name="inscricao">Objeto Presenca que estará inscrito</param>
        void Inscrever(Presenca inscricao);
    }
}
