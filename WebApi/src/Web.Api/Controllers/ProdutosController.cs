using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.DTOs;
using Web.Api.Extensions;
using Web.Business.Interfaces;
using Web.Business.Models;

namespace Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoService produtoService, IMapper mapper)//, IUser user) : base( user)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Action responsável por retornar uma lista de produtos.
        /// </summary>
        /// <response code="200">A lista de produtos foi obtida com sucesso.</response>
        /// <response code="400">Ocorreu um erro ao obter a lista.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            try
            {
                var produtos = _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoService.ObterTodos());
                return Ok(produtos);
            }
            catch
            {
                return BadRequest(new { message = "Ocorreu um erro desconhecido" });
            }

        }

        /// <summary>
        /// Action responsável por adicionar um produto no sistema.
        /// </summary>
        /// <param name="produtoDTO">Abstração da entidade produto.</param>
        /// <response code="200">Produto adicionado com sucesso.</response>
        /// <response code="400">Ocorreu um erro ao adicionar o produto.</response>
        /// <response code="412">Os valores informados do produto não são válidos.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        public async Task<ActionResult> Adicionar(ProdutoDTO produtoDTO)
        {
            try
            {
                if (!ModelState.IsValid) return StatusCode(StatusCodes.Status412PreconditionFailed);

                await _produtoService.Adicionar(_mapper.Map<Produto>(produtoDTO));

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Action responsável por remover um produto.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <response code="200">Produto removido com sucesso.</response>
        /// <response code="400">Ocorreu um erro ao remover o produto.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Remover(int id)
        {
            try
            {
                var produto = await ObterId(id);
                if (produto == null) return BadRequest();

                await _produtoService.Remover(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Action responsável por atualizar um produto.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <param name="produtoDTO">Abstração da entidade produto.</param>
        /// <response code="200">Produto atualizado com sucesso.</response>
        /// <response code="400">Ocorreu um erro ao atualizar o produto.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProdutoDTO>> Atualizar(int id, ProdutoDTO produtoDTO)
        {
            try
            {
                if (id != produtoDTO.Id)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest();

                await _produtoService.Atualizar(_mapper.Map<Produto>(produtoDTO));
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Action responsável por retornar um produto.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <response code="200">Produto obtido com sucesso.</response>
        /// <response code="400">Ocorreu um erro ao obter o produto.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RetornoProdutoDTO>> GetId(int id)
        {
            try
            {
                var produto = await ObterId(id);
                produto.ValorVenda = (produto.ValorVenda * produto.ValorUnitario);
                return Ok(produto);
            }
            catch
            {
                return BadRequest(new { message = "Ocorreu um erro desconhecido" });
            }
        }


        /// <summary>
        /// Método responsável por retornar um produto pelo id.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        private async Task<RetornoProdutoDTO> ObterId(int id)
        {
            return _mapper.Map<RetornoProdutoDTO>(await _produtoService.ObterCompraProduto(id));
        }

    }
}
