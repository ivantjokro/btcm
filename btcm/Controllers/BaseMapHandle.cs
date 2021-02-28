using btcm.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace btcm.Controllers
{
    public class BaseMapHandle
    {
        private readonly IConfiguration _configuration;
        

        public BaseMapHandle(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddMapHeader(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add(ConfigConstants.Alg, _configuration["Api:Alg"]);
            client.DefaultRequestHeaders.Add(ConfigConstants.Typ, _configuration["Api:Typ"]);
            client.DefaultRequestHeaders.Add(ConfigConstants.Key, _configuration["Api:Key"]);
        }
    }
}
