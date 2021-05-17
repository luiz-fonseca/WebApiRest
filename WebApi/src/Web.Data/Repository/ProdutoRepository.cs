using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Web.Business.Interfaces;
using Web.Business.Models;
using Web.Data.Context;

namespace Web.Data.Repository
{
    public class ProdutoRepository: Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base(context) { }

        public async Task<Produto> ObterCompraProduto(int id)
        {
            return await Db.Produtos.AsNoTracking().Include(c => c.Compras.OrderByDescending(c => c.DataCadastro))
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
