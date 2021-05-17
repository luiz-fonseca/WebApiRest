using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Business.Models
{
    public class Produto: Entity
    {
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QtdEstoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public IEnumerable<Compra> Compras { get; set; }
    }
}
