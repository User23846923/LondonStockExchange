using LondonStockExchange.Models;

namespace LondonStockExchange.Services
{
    /// <summary>
    /// Interface for an incremental volume weighted average price calculator
    /// </summary>
    public interface IVwapCalculator
    {
        /// <summary>
        /// Calculates the updated stock value.
        /// </summary>
        /// <param name="currentStockValue">The current stock value.</param>
        /// <param name="newTrade">The new trade.</param>
        StockValue CalculateUpdatedStockValue(StockValue currentStockValue, Trade newTrade);
    }
}
