using LondonStockExchange.Models;

namespace LondonStockExchange.Services
{
    /// <summary>
    /// Interface for the trades service
    /// </summary>
    public interface ITradesService
    {
        /// <summary>
        /// Inserts the trade and updates the stock value.
        /// </summary>
        /// <param name="trade">The trade.</param>
        void InsertTrade(Trade trade);

        /// <summary>
        /// Gets all stock values.
        /// </summary>
        IList<StockValue> GetAllStockValues();

        /// <summary>
        /// Gets the stock values.
        /// </summary>
        /// <param name="tickers">The tickers.</param>
        IList<StockValue> GetStockValues(IList<string> tickers);
    }
}
