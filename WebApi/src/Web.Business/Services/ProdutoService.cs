using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Interfaces;
using Web.Business.Models;

namespace Web.Business.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Adicionar(Produto produto)
        {
            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            await _produtoRepository.Atualizar(produto);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _produtoRepository.ObterTodos();
        }

        public async Task<Produto> ObterPorId(int id)
        {
            return await _produtoRepository.ObterPorId(id);
        }

        public async Task Remover(int id)
        {
            await _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }

        public async Task<Produto> ObterCompraProduto(int id)
        {
           return await _produtoRepository.ObterCompraProduto(id);
        }
    }
}
