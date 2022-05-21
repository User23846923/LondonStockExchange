using LondonStockExchange.Models;

namespace LondonStockExchange.DataLayer
{
    public interface ITradeRepository
    {
        IList<Trade> GetTrades();
        Trade? GetTrade(int id);
        void Insert(Trade trade);
        void Update(Trade trade);
        void Delete(int id);
    }
}
