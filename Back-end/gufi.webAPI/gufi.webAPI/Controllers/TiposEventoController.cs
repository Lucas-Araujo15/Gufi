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
    public class TiposEventoController : ControllerBase
    {
        private ITipoEventoRepository tipoEventoRepository { get; set; }

        public TiposEventoController()
        {
            tipoEventoRepository = new TipoEventoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(tipoEventoRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            if (id == 0)
            {
                return BadRequest(new
                {
                    mensagem = "O ID do tipo de evento não foi informado"
                });
            }

            TipoEvento tipoEventoBuscado = tipoEventoRepository.BuscarPorId(id);

            if (tipoEventoBuscado != null)
            {
                return Ok(tipoEventoRepository.BuscarPorId(id));
            }

            return BadRequest(new
            {
                mensagem = "O tipo de evento buscado não foi encontrado."
            });
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoEvento novoTipoEvento)
        {
            if (novoTipoEvento.TituloTipoEvento == null)
            {
                return BadRequest(new
                {
                    mensagem = "Algumas informações não foram informadas"
                });
            }

            tipoEventoRepository.Cadastrar(novoTipoEvento);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if (id == 0)
            {
                return BadRequest(new
                {
                    mensagem = "O ID do tipo de evento não foi informado"
                });
            }

            TipoEvento tipoEventoBuscado = tipoEventoRepository.BuscarPorId(id);

            if (tipoEventoBuscado != null)
            {
                tipoEventoRepository.Deletar(id);
                return NoContent();
            }

            return BadRequest(new
            {
                mensagem = "O tipo de evento buscado não foi encontrado."
            });
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TipoEvento novoTipoEvento)
        {
            if (novoTipoEvento.TituloTipoEvento == null)
            {
                return BadRequest(new
                {
                    mensagem = "Algumas informações não foram informadas"
                });
            }

            tipoEventoRepository.Atualizar(id, novoTipoEvento);
            return StatusCode(201);
        }
    }
}
