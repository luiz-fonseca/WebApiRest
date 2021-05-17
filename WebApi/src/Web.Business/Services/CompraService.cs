using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Interfaces;
using Web.Business.Models;

namespace Web.Business.Services
{
    public class CompraService: ICompraService
    {
        private readonly ICompraRepository _compraRepository;

        public CompraService(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public async Task Adicionar(Compra compra)
        {
            await _compraRepository.Adicionar(compra);
        }

        public void Dispose()
        {
            _compraRepository.Dispose();
        }
    }
}
