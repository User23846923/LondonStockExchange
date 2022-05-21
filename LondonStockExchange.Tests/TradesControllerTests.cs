using LondonStockExchange.Controllers;
using LondonStockExchange.DataLayer;
using LondonStockExchange.Models;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LondonStockExchange.Tests
{
    public class TradesControllerTests
    {
        private readonly Mock<ILogger<TradesController>> mockLogger = new Mock<ILogger<TradesController>>();
        private readonly Mock<ITradeRepository> mockTradeRepository = new Mock<ITradeRepository>();

        private readonly List<Trade> mockTrades = new List<Trade>
        {
            new Trade { Id = 1, BrokerId = 1, Ticker = "CAT.L", Amount = 1000, Price = 25.0M },
            new Trade { Id = 2, BrokerId = 1, Ticker = "DOG.L", Amount = 100, Price = 10.0M },
            new Trade { Id = 3, BrokerId = 1, Ticker = "DOG.L", Amount = 100, Price = 20.0M },
            new Trade { Id = 4, BrokerId = 1, Ticker = "DOG.L", Amount = 100, Price = 30.0M },
        };

        private TradesController tradesController;

        public TradesControllerTests()
        {
            tradesController = new TradesController(
               mockTradeRepository.Object,
               mockLogger.Object);
        }

        [SetUp]
        public void Setup()
        {
            mockTradeRepository
                .Setup((r) => r.GetTrades())
                .Returns(mockTrades);

            foreach (var trade in mockTrades)
            {
                mockTradeRepository
                    .Setup((r) => r.GetTrade(trade.Id))
                    .Returns(trade);
            }
        }

        [Test]
        public void GetListWorks()
        {
            var tradesList = tradesController.Get();

            Assert.IsNotNull(tradesList);
            Assert.AreEqual(4, tradesList.Count());
        }

        [Test]
        public void GetSingleNotPresentWorks()
        {
            var trade = tradesController.Get(201);

            Assert.IsNull(trade);
        }

        [Test]
        public void GetSinglePresentWorks()
        {
            var trade = tradesController.Get(1);

            Assert.IsNotNull(trade);
            Assert.AreEqual(1, trade.Id);
        }
    }
}
