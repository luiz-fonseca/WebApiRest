using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.DTOs
{
    public class CartaoDTO
    {
        public string Titular { get; set; }
        public string Numero { get; set; }
        public string DataExpiracao { get; set; }
        public string Bandeira { get; set; }
        public string Cvv { get; set; }
    }
}
