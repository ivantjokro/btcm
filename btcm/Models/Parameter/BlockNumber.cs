using System.Collections;

namespace btcm.Models
{
    public class BlockNumber
    {
        public string Jsonrpc { get; set; } = "2.0";
        public int Id { get; set; } = 1;
        public string Method { get; set; }
        public ArrayList Params { get; set; }
    }
}
