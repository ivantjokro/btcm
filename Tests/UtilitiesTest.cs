using Microsoft.VisualStudio.TestTools.UnitTesting;
using btcm;

namespace Tests
{
    [TestClass]
    public class UtilitiesTest
    {
        private const string continueSign = "...";
        [TestMethod]
        public void TestShortenTextReturnTwentyCharacters()
        {
            const int maxChars = 20;
            const string originalWord = "0xe6d2c63ef9044757338054ed8e938917de97aa96815b0c8e30f97fad130101fe";
            var shortenWord = Utilities.ShortenText(originalWord);

            Assert.IsNotNull(shortenWord);
            Assert.AreEqual(maxChars, shortenWord.Length);
        }

        [TestMethod]
        public void TestShortTextWithLessThanTwentyCharactersAreEqualToOriginalText()
        {
            const string originalWord = "9148873";
            var shortenWord = Utilities.ShortenText(originalWord);

            Assert.IsNotNull(shortenWord);
            Assert.AreEqual(shortenWord, originalWord);
        }

        [TestMethod]
        public void TestShortenWordEndWithContinueSign()
        {
            const string originalWord = "0xd409545096ffe4a4db43875a9b32d766c6364c66";
            var shortenWord = Utilities.ShortenText(originalWord);

            Assert.IsNotNull(shortenWord);
            Assert.IsTrue(shortenWord.EndsWith(continueSign));
        }

        [TestMethod]
        public void TestShortenWordContainOriginalWordReturnTrue()
        {

            const string originalWord = "0xd409545096ffe4a4db43875a9b32d766c6364c66";
            var shortenWord = Utilities.ShortenText(originalWord);

            // Remove the continue sign to compare with original word
            var shortWord = shortenWord.Replace(continueSign, string.Empty);

            Assert.IsNotNull(shortenWord);
            Assert.IsTrue(originalWord.Contains(shortWord));
        }
    }
}
