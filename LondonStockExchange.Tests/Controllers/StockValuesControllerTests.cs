using LondonStockExchange.Controllers;
using LondonStockExchange.Models;
using LondonStockExchange.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LondonStockExchange.Tests.Controllers
{
    public class StockValuesControllerTests
    {
        private readonly List<StockValue> _mockStockValues = new()
        {
            new StockValue{ Ticker = "LLOY.L", SumVolume = 1000, SumPriceVolume = 25000, AveragePrice = 25},
            new StockValue{ Ticker = "NWG.L", SumVolume = 2000, SumPriceVolume = 20000, AveragePrice = 10},
        };

        private readonly Mock<ITradesService> mockTradesService = new();

        [SetUp]
        public void SetUp()
        {
            mockTradesService
                .Setup(s => s.GetAllStockValues())
                .Returns(_mockStockValues);

            mockTradesService
                .Setup(s => s.GetStockValues(new List<string> { "XYZ.L" }))
                .Returns(new List<StockValue>());

            mockTradesService
                .Setup(s => s.GetStockValues(new List<string> { "NWG.L" }))
                .Returns(_mockStockValues.Where((v) => v.Ticker == "NWG.L").ToList());
        }

        [Test]
        public void GetAllStockValuesWorks()
        {
            var stockValuesController = new StockValuesController(mockTradesService.Object);

            var stockValuesList = stockValuesController.GetAllStockValues();

            Assert.AreEqual(_mockStockValues, stockValuesList);
        }

        [Test]
        public void GetSingleNotPresentWorks()
        {
            var stockValuesController = new StockValuesController(mockTradesService.Object);

            var stockValuesList = stockValuesController.GetStockValues("XYZ.L");

            Assert.IsNotNull(stockValuesList);
            Assert.IsEmpty(stockValuesList);
        }

        [Test]
        public void GetSinglePresentWorks()
        {
            var stockValuesController = new StockValuesController(mockTradesService.Object);

            var stockValuesList = stockValuesController.GetStockValues("NWG.L");

            Assert.IsNotNull(stockValuesList);
            Assert.AreEqual(1, stockValuesList.Count);
        }
    }
}
