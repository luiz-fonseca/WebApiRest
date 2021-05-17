using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Extensions;
using Web.Api.Interfaces;
using Web.Api.Services;
using Web.Business.Interfaces;
using Web.Business.Services;
using Web.Data.Context;
using Web.Data.Repository;

namespace Web.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<ICompraRepository, CompraRepository>();
            services.AddScoped<ICompraService, CompraService>();

            services.AddScoped<ICartaoService, CartaoService>();
            services.AddScoped<IRequisicao, Requisicao>();

            return services;

        }
    }
}
