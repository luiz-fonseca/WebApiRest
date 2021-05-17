using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.DTOs;

namespace Web.Api.Controllers
{
    [Route("api/compras/pagamento")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        /// <summary>
        /// Action responsável por validar uma transação de cartão de crédito.
        /// </summary>
        /// <param name="pagamentoDTO">Abstração da entidade Pagamento.</param>
        [HttpPost]
        public ActionResult<RetornoPagamentoDTO> Compra(PagamentoDTO pagamentoDTO)
        {
            RetornoPagamentoDTO retornoPagamento = new RetornoPagamentoDTO();
            retornoPagamento.Valor = pagamentoDTO.Valor;
            if (pagamentoDTO.Valor > 100)
            {
                retornoPagamento.Estado = "APROVADO";
            }
            else
            {
                retornoPagamento.Estado = "REJEITADO";
            }
            return retornoPagamento;
        }
    }
}
