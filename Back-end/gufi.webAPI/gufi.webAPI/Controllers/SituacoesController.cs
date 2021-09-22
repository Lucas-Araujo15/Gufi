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
    public class SituacoesController : ControllerBase
    {
        private ISituacaoRepository situacaoRepository { get; set; }

        public SituacoesController()
        {
            situacaoRepository = new SituacaoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(situacaoRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            if (id == 0)
            {
                return BadRequest(new
                {
                    mensagem = "O ID da situação não foi informado"
                });
            }

            Situacao situacaoBuscada = situacaoRepository.BuscarPorId(id);

            if (situacaoBuscada != null)
            {
                return Ok(situacaoRepository.BuscarPorId(id));
            }

            return BadRequest(new
            {
                mensagem = "A situação buscada não foi encontrada."
            });
        }

        [HttpPost]
        public IActionResult Cadastrar(Situacao novaSituacao)
        {
            if (novaSituacao.Descricao == null)
            {
                return BadRequest(new
                {
                    mensagem = "Algumas informações não foram informadas"
                });
            }

            situacaoRepository.Cadastrar(novaSituacao);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if (id == 0)
            {
                return BadRequest(new
                {
                    mensagem = "O ID da situação não foi informado"
                });
            }

            Situacao situacaoBuscada = situacaoRepository.BuscarPorId(id);

            if (situacaoBuscada != null)
            {
                situacaoRepository.Deletar(id);
                return NoContent();
            }

            return BadRequest(new
            {
                mensagem = "A situação buscad não foi encontrada."
            });
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Situacao novaSituacao)
        {
            if (novaSituacao.Descricao == null)
            {
                return BadRequest(new
                {
                    mensagem = "Algumas informações não foram informadas"
                });
            }

            situacaoRepository.Atualizar(id, novaSituacao);
            return StatusCode(201);
        }
    }
}
