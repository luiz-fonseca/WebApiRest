using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Api.Interfaces
{
    public interface IRequisicao
    {
        Task<HttpResponseMessage> PostRequest(string json, string link);
    }
}
