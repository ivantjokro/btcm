namespace btcm
{
    public static class Utilities
    {
        public  const int maxLength = 17;
        public static string ShortenText(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return text.Length <= maxLength ? text : string.Format("{0}{1}", text.Substring(0, maxLength), "...");
        }
    }
}
