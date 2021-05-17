using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Web.Api.DTOs
{
    public class ProdutoDTO
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QtdEstoque { get; set; }
    }
}
