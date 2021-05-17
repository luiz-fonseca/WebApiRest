using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.DTOs
{
    public class CompraDTO
    {
        public int ProdutoId { get; set; }
        public int QtdComprada { get; set; }
        public CartaoDTO Cartao { get; set; }
    }
}
