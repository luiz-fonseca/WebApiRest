using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.DTOs;

namespace Web.Api.Interfaces
{
    public interface ICartaoService
    {
        Task<RetornoPagamentoDTO> TransacaoCartaoCredito(PagamentoDTO pagamentoDTO);
    }
}
