using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.DTOs
{
    public class RetornoPagamentoDTO
    {
        public decimal Valor { get; set; }
        public string Estado { get; set; }
    }
}
