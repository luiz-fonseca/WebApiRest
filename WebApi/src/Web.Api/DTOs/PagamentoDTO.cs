using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.DTOs
{
    public class PagamentoDTO
    {
        public decimal Valor { get; set; }
        public CartaoDTO Cartao { get; set; }
    }
}
