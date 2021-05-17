using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Business.Models
{
    public class Compra: Entity
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int QtdComprada { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
