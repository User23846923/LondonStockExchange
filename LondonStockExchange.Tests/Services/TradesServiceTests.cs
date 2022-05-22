using LondonStockExchange.DataLayer;
using LondonStockExchange.Models;
using LondonStockExchange.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace LondonStockExchange.Tests.Services
{
    public class TradesServiceTests
    {
        private readonly List<Trade> _mockTrades = new()
        {
            new Trade { Id = 2, BrokerId = 1, Ticker = "NWG.L", Amount = 100, Price = 10.0M },
            new Trade { Id = 3, BrokerId = 1, Ticker = "NWG.L", Amount = 100, Price = 20.0M },
            new Trade { Id = 4, BrokerId = 1, Ticker = "NWG.L", Amount = 100, Price = 30.0M },
            new Trade { Id = 1, BrokerId = 1, Ticker = "LLOY.L", Amount = 1000, Price = 25.0M },
        };

        private readonly List<StockValue> _mockStockValues = new()
        {
            new StockValue{ Ticker = "NWG.L", SumVolume = 2000, SumPriceVolume = 20000, AveragePrice = 10},
            new StockValue{ Ticker = "LLOY.L", SumVolume = 1000, SumPriceVolume = 25000, AveragePrice = 25},
        };

        private IDbContext _mockDbContext = new DbContext();
        private Mock<IVwapCalculator> _mockVwapCalculator = new();

        [SetUp]
        public void SetUp()
        {
            _mockDbContext = new DbContext();

            _mockVwapCalculator = new Mock<IVwapCalculator>();

            _mockVwapCalculator
                .Setup(c => c.CalculateUpdatedStockValue(It.IsAny<StockValue>(), It.IsAny<Trade>()))
                    .Returns(_mockStockValues[0]);
        }

        [Test]
        public void InsertFirstTradeInsertsTrade()
        {
            var tradeService = new TradesService(_mockDbContext, _mockVwapCalculator.Object);

            tradeService.InsertTrade(_mockTrades[0]);

            Assert.AreEqual(1, _mockDbContext.Trades.Count);
        }

        [Test]
        public void InsertFirstTradeAlsoInsertsStockValue()
        {
            var tradeService = new TradesService(_mockDbContext, _mockVwapCalculator.Object);

            tradeService.InsertTrade(_mockTrades[0]);

            Assert.AreEqual(1, _mockDbContext.StockValues.Count);

            _mockVwapCalculator
                .Verify((c) => c.CalculateUpdatedStockValue(It.IsAny<StockValue>(), It.IsAny<Trade>()),
                Times.Once);
        }

        [Test]
        public void InsertSecondTradeUpdatesExistingStockValue()
        {
            var tradeService = new TradesService(_mockDbContext, _mockVwapCalculator.Object);

            tradeService.InsertTrade(_mockTrades[0]);
            tradeService.InsertTrade(_mockTrades[1]);

            Assert.AreEqual(1, _mockDbContext.StockValues.Count);

            _mockVwapCalculator
                .Verify((c) => c.CalculateUpdatedStockValue(It.IsAny<StockValue>(), It.IsAny<Trade>()),
                Times.Exactly(2));
        }

        [Test]
        public void GetAllStockValuesWorks()
        {
            var tradeService = new TradesService(_mockDbContext, _mockVwapCalculator.Object);

            var stockValuesList = tradeService.GetAllStockValues();

            Assert.AreEqual(_mockDbContext.StockValues, stockValuesList);
        }


        [Test]
        public void GetStockValuesNotPresentReturnsEmptyList()
        {
            var tradeService = new TradesService(_mockDbContext, _mockVwapCalculator.Object);

            var stockValuesList = tradeService.GetStockValues(new List<string> { "XYZ.L" });

            Assert.IsNotNull(stockValuesList);
            Assert.AreEqual(0, stockValuesList.Count);
        }

        [Test]
        public void GetStockValuesPresentWorks()
        {
            foreach (var stockValue in _mockStockValues)
            {
                _mockDbContext.StockValues.Add(stockValue);
            }

            var tradeService = new TradesService(_mockDbContext, _mockVwapCalculator.Object);

            var stockValuesList = tradeService.GetStockValues(new List<string> { "NWG.L" });

            Assert.AreEqual(1, stockValuesList.Count);
        }
    }
}
