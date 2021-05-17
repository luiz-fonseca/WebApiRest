﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.DTOs
{
    public class CompraDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QtdComprada { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public CartaoDTO Cartao { get; set; }
    }
}
