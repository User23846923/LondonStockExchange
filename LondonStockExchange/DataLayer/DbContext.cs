using LondonStockExchange.Models;

namespace LondonStockExchange.DataLayer
{
    public class DbContext : IDbContext
    {
        public IList<Trade> Trades { get; set; } = new List<Trade>();

        public IList<StockValue> StockValues { get; set; } = new List<StockValue>();

        public async Task<bool> SaveChanges()
        {
            return await Task.FromResult(true);
        }
    }
}
