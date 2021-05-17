using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Interfaces;

namespace Web.Api.Services
{
    public class Requisicao: IRequisicao
    {
        public async Task<HttpResponseMessage> PostRequest(string json, string link)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    link, new StringContent(json, Encoding.UTF8, "application/json"));

                return response;
            }
        }
    }
}
