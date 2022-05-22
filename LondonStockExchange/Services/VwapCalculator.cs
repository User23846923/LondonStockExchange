using LondonStockExchange.Models;

namespace LondonStockExchange.Services
{
    public class VwapCalculator : IVwapCalculator
    {
        public StockValue CalculateUpdatedStockValue(StockValue currentStockValue, Trade newTrade)
        {
            var sumVolume = currentStockValue.SumVolume + newTrade.Amount;
            var sumPriceVolume = currentStockValue.SumPriceVolume + newTrade.Price * newTrade.Amount;
            var averagePrice = sumPriceVolume / sumVolume;

            return new StockValue
            {
                Ticker = newTrade.Ticker,
                SumVolume = sumVolume,
                SumPriceVolume = sumPriceVolume,
                AveragePrice = averagePrice,
            };
        }
    }
}
