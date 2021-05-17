using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.DTOs;
using Web.Api.Interfaces;
using Web.Api.Services;
using Web.Business.Interfaces;
using Web.Business.Models;

namespace Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraService _compraService;
        private readonly IMapper _mapper;
        private readonly ICartaoService _cartaoService;
        private readonly IProdutoService _produtoService;
        public ComprasController(ICompraService compraService, IMapper mapper,
            ICartaoService cartaoService, IProdutoService produtoService)
        {
            _compraService = compraService;
            _mapper = mapper;
            _cartaoService = cartaoService;
            _produtoService = produtoService;
        }

        /// <summary>
        /// Action responsável por realizar uma compra.
        /// </summary>
        /// <param name="compraDTO">Abstração da entidade compra.</param>
        /// <response code="200">Compra realizada com sucesso.</response>
        /// <response code="400">Ocorreu um erro ao comprar produto.</response>
        /// <response code="412">Os valores informados da compra não são válidos.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        public async Task<ActionResult> Adicionar(CompraDTO compraDTO)
        {
            try
            {
                if (!ModelState.IsValid) return StatusCode(StatusCodes.Status412PreconditionFailed);

                var produto = await _produtoService.ObterPorId(compraDTO.ProdutoId);

                if (produto.QtdEstoque < compraDTO.QtdComprada) return StatusCode(StatusCodes.Status412PreconditionFailed);

                PagamentoDTO pagamentoDTO = new PagamentoDTO();
                pagamentoDTO.Cartao = compraDTO.Cartao;
                pagamentoDTO.Valor = (produto.ValorUnitario * compraDTO.QtdComprada);

                produto.QtdEstoque = (produto.QtdEstoque - compraDTO.QtdComprada);

                var result = await _cartaoService.TransacaoCartaoCredito(pagamentoDTO);
                if (result == null) return StatusCode(StatusCodes.Status412PreconditionFailed);

                if (result.Estado.Contains("APROVADO"))
                {
                    await _produtoService.Atualizar(produto);
                    await _compraService.Adicionar(_mapper.Map<Compra>(compraDTO));
                    return Ok();
                }
                else
                {
                    return StatusCode(StatusCodes.Status412PreconditionFailed);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
