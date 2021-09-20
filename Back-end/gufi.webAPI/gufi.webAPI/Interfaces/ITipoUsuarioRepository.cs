using gufi.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gufi.webAPI.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario">Objeto TipoUsuario a ser cadastrado</param>
        void Cadastrar(TipoUsuario tipoUsuario);

        /// <summary>
        /// Lista todos os tipos de usuário cadastrados
        /// </summary>
        /// <returns>Uma lista de tipos de usuário</returns>
        List<TipoUsuario> ListarTodos();

        /// <summary>
        /// Retorna um tipo de usuário específico
        /// </summary>
        /// <param name="id">ID do tipo de usuário</param>
        /// <returns>Objeto TipoUsuario que foi buscado</returns>
        TipoUsuario BuscarPorId(int id);

        /// <summary>
        /// Atualiza um tipo de usuário específico
        /// </summary>
        /// <param name="id">ID do tipo de usuário</param>
        /// <param name="novoTipoUsuario">Objeto TipoUsuario com as novas informações</param>
        void Atualizar(int id, TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Deleta um tipo de usuário específico
        /// </summary>
        /// <param name="id">ID do tipo de usuário a ser deletado</param>
        void Deletar(int id);
    }
}
