using System.Collections.Generic;

namespace btcm.Models
{
    public class Response
    {
        public Result Result { get; set; }

        public Error Error { get; set; }
    }

    public class Result
    {
        public IEnumerable<Transaction> Transactions { get; set; }
    }

    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
