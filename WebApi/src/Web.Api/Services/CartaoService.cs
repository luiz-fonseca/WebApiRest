using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.DTOs;
using Web.Api.Interfaces;

namespace Web.Api.Services
{
    public class CartaoService : ICartaoService
    {
        private readonly IRequisicao _requisicao;
        public CartaoService(IRequisicao requisicao)
        {
            _requisicao = requisicao;
        }
        public async Task<RetornoPagamentoDTO> TransacaoCartaoCredito(PagamentoDTO pagamentoDTO)
        {
            RetornoPagamentoDTO result = null;
            try
            {
                string json = JsonConvert.SerializeObject(pagamentoDTO);
                var response = await _requisicao.PostRequest(json, "https://localhost:44333/api/compras/pagamento");

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<RetornoPagamentoDTO>(responseString);
                }
                else
                {
                    result = null;
                }

            }
            catch (Exception e)
            {
                result = null;
                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}
