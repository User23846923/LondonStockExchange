using LondonStockExchange.Models;

namespace LondonStockExchange.DataLayer
{
    /// <summary>
    /// Interface for a quick and dirty Entity Framework knock-off
    /// </summary>
    public interface IDbContext
    {
        IList<Trade> Trades { get; set; }

        IList<StockValue> StockValues { get; set; }

        Task<bool> SaveChanges();
    }
}
