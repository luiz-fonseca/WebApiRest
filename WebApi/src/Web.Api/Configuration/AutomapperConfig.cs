using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.DTOs;
using Web.Business.Models;

namespace Web.Api.Configuration
{
    public class AutomapperConfig: Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Compra, CompraDTO>().ReverseMap();

            CreateMap<Produto, RetornoProdutoDTO>()
                .ForMember(dest => dest.DataVenda, opt => opt.MapFrom(src => src.Compras.FirstOrDefault().DataCadastro))
                .ForMember(dest => dest.ValorVenda, opt => opt.MapFrom(src => src.Compras.FirstOrDefault().QtdComprada));
        }
    }
}
