using LondonStockExchange.DataLayer;
using LondonStockExchange.Models;

namespace LondonStockExchange.Services
{
    public class TradesService : ITradesService
    {
        private readonly IDbContext _dbContext;
        private readonly IVwapCalculator _vwapCalculator;

        public TradesService(IDbContext dbContext, IVwapCalculator vwapCalculator)
        {
            _dbContext = dbContext;
            _vwapCalculator = vwapCalculator;
        }

        public void InsertTrade(Trade trade)
        {
            var stockValue = _dbContext.StockValues
                .FirstOrDefault(v => v.Ticker == trade.Ticker)
                ?? new StockValue { Ticker = trade.Ticker };

            var updatedStockValue = _vwapCalculator.CalculateUpdatedStockValue(stockValue, trade);

            _dbContext.Trades.Add(trade);
            _dbContext.StockValues.Remove(stockValue);
            _dbContext.StockValues.Add(updatedStockValue);
            _dbContext.SaveChanges();
        }

        public IList<StockValue> GetAllStockValues()
        {
            return _dbContext.StockValues;
        }

        public IList<StockValue> GetStockValues(IList<string> tickers)
        {
            return _dbContext.StockValues
                .Where(v => tickers.Contains(v.Ticker))
                .ToList();
        }
    }
}
