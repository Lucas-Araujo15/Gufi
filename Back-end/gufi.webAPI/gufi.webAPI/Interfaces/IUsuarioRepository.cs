using gufi.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gufi.webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Busca um usuário específico
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Objeto Usuario correspondente as credenciais informadas</returns>
        Usuario Login(string email, string senha);

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Objeto Usuario a ser cadastrado</param>
        void Cadastrar(Usuario usuario);

        /// <summary>
        /// Lista todos os usuários cadastrados
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Retorna um usuário específico
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Objeto Usuario que foi buscado</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Atualiza um usuário específico
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="novoUsuario">Objeto Usuario com as novas informações</param>
        void Atualizar(int id, Usuario novoUsuario);

        /// <summary>
        /// Deleta um usuário específico
        /// </summary>
        /// <param name="id">ID do usuário a ser deletado</param>
        void Deletar(int id);
    }
}
