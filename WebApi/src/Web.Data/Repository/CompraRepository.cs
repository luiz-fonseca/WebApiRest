using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Interfaces;
using Web.Business.Models;
using Web.Data.Context;

namespace Web.Data.Repository
{
    public class CompraRepository : Repository<Compra>, ICompraRepository
    {
        public CompraRepository(MeuDbContext context) : base(context) { }
    }
}
