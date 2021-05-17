using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Models;

namespace Web.Business.Interfaces
{
    public interface ICompraService : IDisposable
    {
        Task Adicionar(Compra compra);
    }
}
