using btcm.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{

    [TestClass]
    public class SearchInputTests
    {
        private const string prefix = "0x";
        [TestMethod]
        public void TestPrefixHexWithBlockHexAreEqual()
        {
            string hexCode = "a5bd2";
            string blockNumber = "678866";
            SearchInput searchInput = new SearchInput() { BlockNumber = blockNumber };
            var blockHexEther = searchInput.ConvertHexFromBlockNumber();

            Assert.IsNotNull(blockHexEther);
            Assert.AreEqual(string.Format("{0}{1}", prefix, hexCode), blockHexEther);
        }
    }
}