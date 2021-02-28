namespace btcm.Models
{
    public class HeaderParameter
    {
        private readonly string alg;
        private readonly string typ;
        private readonly string kid;

        public HeaderParameter(string alg, string typ, string kid) {
            this.alg = alg;
            this.typ = typ;
            this.kid = kid;
        }
    }
}
