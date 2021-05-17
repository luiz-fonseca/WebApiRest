using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.DTOs
{
    public class RetornoProdutoDTO: ProdutoDTO
    {
        public decimal ValorVenda { get; set; }
        public DateTime DataVenda { get; set; }
    }
}
