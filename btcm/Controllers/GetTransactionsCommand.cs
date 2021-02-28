using btcm.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace btcm.Controllers
{

    public class GetTransactionsCommand : ICommand<IEnumerable<Transaction>>
    {
    }
    public class GetTransactionsHandle : BaseMapHandle, IHandlesCommand<GetTransactionsCommand, IEnumerable<Transaction>>
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public GetTransactionsHandle(IConfiguration configuration, ILogger logger) : base(configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public IEnumerable<Transaction> Handle(string hashBlockNumber)
        {
            var response = GetEthereumTransactions(hashBlockNumber);

            return (response.Error == null) ? response?.Result?.Transactions : null;
        }

        private Response GetEthereumTransactions(string hashBlockNumber)
        {
            using (var client = new HttpClient())
            {
                AddMapHeader(client);

                var body = new BlockNumber()
                {
                    Method = _configuration["Api:Method"],
                    Params = new ArrayList() { hashBlockNumber, true }
                };

                string defaultErrorCode = string.Empty;
                string defaultErrorMessage;
                try
                {
                    var response = client.PostAsync(_configuration["Api:Url"],
                        new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")).Result;
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        var Content = response.Content.ReadAsStringAsync().Result;
                        Response orderResult = JsonConvert.DeserializeObject<Response>(Content);

                        return orderResult;
                    }
                    else
                    {
                        defaultErrorCode = response?.StatusCode.ToString();
                        defaultErrorMessage = response?.Content?.ToString();
                        _logger.LogError($"Failed Response Status, {response.StatusCode} from Web Api. Message : {response.Content}", this);
                    }
                }
                catch (Exception ex)
                {
                    defaultErrorMessage = ex.Message;
                    _logger.LogError($"Failed to get transactions {ex.Message} from Web Api.", ex, this);
                }

                return new Response() { Error = new Error() { Code = defaultErrorCode, Message = defaultErrorMessage } };
            }

        }
    }
}
