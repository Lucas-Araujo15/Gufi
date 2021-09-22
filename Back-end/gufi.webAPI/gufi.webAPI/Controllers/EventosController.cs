using gufi.webAPI.Domains;
using gufi.webAPI.Interfaces;
using gufi.webAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gufi.webAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private IEventoRepository eventoRepository { get; set; }

        public EventosController()
        {
            eventoRepository = new EventoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(eventoRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            if (id == 0)
            {
                return BadRequest(new
                {
                    mensagem = "O ID do evento não foi informado"
                });
            }

            Evento eventoBuscado = eventoRepository.BuscarPorId(id);

            if (eventoBuscado != null)
            {
                return Ok(eventoRepository.BuscarPorId(id));
            }

            return BadRequest(new
            {
                mensagem = "O evento buscado não foi encontrado."
            });
        }

        [HttpPost]
        public IActionResult Cadastrar(Evento novoEvento)
        {
            if (novoEvento.IdInstituicao == 0 || novoEvento.IdTipoEvento == 0 || novoEvento.NomeEvento == null || novoEvento.AcessoLivre == null || novoEvento.Descricao == null)
            {
                return BadRequest(new
                {
                    mensagem = "Algumas informações não foram informadas"
                });
            }

            eventoRepository.Cadastrar(novoEvento);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if (id == 0)
            {
                return BadRequest(new
                {
                    mensagem = "O ID do evento não foi informado"
                });
            }

            Evento eventoBuscado = eventoRepository.BuscarPorId(id);

            if (eventoBuscado != null)
            {
                eventoRepository.Deletar(id);
                return NoContent();
            }

            return BadRequest(new
            {
                mensagem = "O evento buscado não foi encontrado."
            });
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Evento novoEvento)
        {
            if (novoEvento.IdInstituicao == 0 || novoEvento.IdTipoEvento == 0 || novoEvento.NomeEvento == null || novoEvento.AcessoLivre == null || novoEvento.Descricao == null)
            {
                return BadRequest(new
                {
                    mensagem = "Algumas informações não foram informadas"
                });
            }

            eventoRepository.Atualizar(id, novoEvento);
            return StatusCode(201);
        }
    }
}
