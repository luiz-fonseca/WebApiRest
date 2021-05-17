using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.DTOs
{
    public class CartaoDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titular { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [CreditCard(ErrorMessage = "Cartão de crédito inválido")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string DataExpiracao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bandeira { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(3, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 3)]
        public string Cvv { get; set; }
    }
}
