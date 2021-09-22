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
    public class InstituicoesController : ControllerBase
    {
        private IInstituicaoRepository instituicaoRepository { get; set; }

        public InstituicoesController()
        {
            instituicaoRepository = new InstituicaoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(instituicaoRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            if (id == 0)
            {
                return BadRequest(new
                {
                    mensagem = "O ID da instituição não foi informado"
                });
            }

            Instituicao instituicaoBuscada = instituicaoRepository.BuscarPorId(id);

            if (instituicaoBuscada != null)
            {
                return Ok(instituicaoRepository.BuscarPorId(id));
            }

            return BadRequest(new
            {
                mensagem = "A instituição buscada não foi encontrada."
            });
        }

        [HttpPost]
        public IActionResult Cadastrar(Instituicao novaInstituicao)
        {
            if (novaInstituicao.Cnpj == null || novaInstituicao.Endereco == null || novaInstituicao.NomeFantasia == null)
            {
                return BadRequest(new
                {
                    mensagem = "Algumas informações não foram informadas"
                });
            }

            instituicaoRepository.Cadastrar(novaInstituicao);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if (id == 0)
            {
                return BadRequest(new
                {
                    mensagem = "O ID da instituição não foi informado"
                });
            }

            Instituicao instituicaoBuscada = instituicaoRepository.BuscarPorId(id);

            if (instituicaoBuscada != null)
            {
                instituicaoRepository.Deletar(id);
                return NoContent();
            }

            return BadRequest(new
            {
                mensagem = "A instituição buscada não foi encontrada"
            });
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Instituicao novaInstituicao)
        {
            if (novaInstituicao.Cnpj == null || novaInstituicao.Endereco == null || novaInstituicao.NomeFantasia == null)
            {
                return BadRequest(new
                {
                    mensagem = "Algumas informações não foram informadas"
                });
            }

            instituicaoRepository.Atualizar(id, novaInstituicao);
            return StatusCode(201);
        }
    }
}
