using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using btcm.Controllers;
using Moq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using btcm.Models;

namespace Tests
{
    [TestClass]
    public class GetTransactionsCommandTest
    {
        private Mock<IConfiguration> _configuration;
        private Mock<ILogger> _logger;
        private GetTransactionsHandle _createCommand;

        [TestMethod]
        public void TestCallApiContainSameBlockNumber()
        {
            string ethBlockHex = "0xa5bd2"; // Decimal 678866

            _configuration = new Mock<IConfiguration>();
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "Api:Method")]).Returns("eth_getBlockByNumber");
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "Api:Url")]).Returns("https://mainnet.infura.io/v3/22b2ebe2940745b3835907b30e8257a4");
            _logger = new Mock<ILogger>();

            _createCommand = new GetTransactionsHandle(_configuration.Object, _logger.Object);

            IEnumerable<Transaction> transactions = _createCommand.Handle(ethBlockHex);
            var BlockNumberCollection = transactions.Select(x => x.BlockNumber);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(BlockNumberCollection.Contains(ethBlockHex));
        }
    }
}