using gufi.webAPI.Domains;
using gufi.webAPI.Interfaces;
using gufi.webAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace gufi.webAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class PresencasController : ControllerBase
    {
        private IPresencaRepository presencaRepository { get; set; }

        public PresencasController()
        {
            presencaRepository = new PresencaRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Presenca presenca)
        {
            if (presenca.IdEvento == 0 || presenca.IdSituacao == 0 || presenca.IdUsuario == 0)
            {
                return BadRequest(new
                {
                    mensagem = "Algumas informações não foram especificadas."
                });
            }
            
            presencaRepository.Cadastrar(presenca);
            return StatusCode(201);
        }

        [HttpPost("inscricao/{idEvento}")]
        public IActionResult Inscrever(int idEvento)
        {
            try
            {
                Presenca novaInscricao = new Presenca()
                {
                    IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(o => o.Type == JwtRegisteredClaimNames.Jti).Value),
                    IdEvento = idEvento,
                    IdSituacao = 3
                };

                presencaRepository.Inscrever(novaInscricao);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não foi possível fazer a inscrição.",
                    error
                });
            }
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(presencaRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            return Ok(presencaRepository.BuscarPorId(id));
        }

        [HttpGet("minhas")]
        public IActionResult ListarMinhas()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(o => o.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(presencaRepository.ListarMinhas(idUsuario));
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "O usuário precisa estar logado para ver suas presenças.",
                    error
                });
            }
        }

        [HttpPatch("{idPresenca}")]
        public IActionResult Aprovacao(int idPresenca, Presenca status)
        {
            try
            {
                presencaRepository.AprovarRecusar(idPresenca, status.IdSituacao.ToString());
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Presenca novaPresenca)
        {
            if (novaPresenca.IdEvento == 0 || novaPresenca.IdSituacao == 0 || novaPresenca.IdUsuario == 0)
            {
                return BadRequest(new
                {
                    mensagem = "Algumas informações não foram especificadas."
                });
            }

            Presenca presencaVerificacao = presencaRepository.BuscarPorId(id);

            if (presencaVerificacao != null)
            {
                presencaRepository.Atualizar(id, novaPresenca);
                return Ok();
            }

            return BadRequest(new
            {
                mensagem = "A presença indicada não foi encontrada."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            Presenca presencaBuscar = presencaRepository.BuscarPorId(id);

            if(presencaBuscar != null)
            {
                presencaRepository.Deletar(id);
                return NoContent();
            }

            return BadRequest(new
            {
                mensagem = "A presença indicada não foi encontrada."
            });
        }
    }
}
