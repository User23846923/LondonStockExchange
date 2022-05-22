using LondonStockExchange.Controllers;
using LondonStockExchange.Models;
using LondonStockExchange.Services;
using Moq;
using NUnit.Framework;

namespace LondonStockExchange.Tests.Controllers
{
    public class TradesControllerTests
    {
        private readonly Trade mockTrade = new() { Id = 1, BrokerId = 1, Ticker = "NWG.L", Amount = 1000, Price = 25.0M };

        private readonly Mock<ITradesService> mockTradesService = new();

        [Test]
        public void PostTradeInsertsTrade()
        {
            var tradesController = new TradesController(mockTradesService.Object);

            tradesController.Post(mockTrade);

            mockTradesService
                .Verify((s) => s.InsertTrade(mockTrade),
                Times.Once);
        }
    }
}
