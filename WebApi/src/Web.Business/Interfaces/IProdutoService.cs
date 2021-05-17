using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Models;

namespace Web.Business.Interfaces
{
    public interface IProdutoService: IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(int id);
        Task Remover(int id);
        Task<Produto> ObterCompraProduto(int id);


    }
}
