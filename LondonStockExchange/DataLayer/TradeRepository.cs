using LondonStockExchange.Models;

namespace LondonStockExchange.DataLayer
{
    public class TradeRepository : ITradeRepository
    {
        private readonly IList<Trade> _tradeList = new List<Trade>();

        public IList<Trade> GetTrades()
        {
            return _tradeList;
        }

        public Trade? GetTrade(int id)
        {
            return _tradeList
                .FirstOrDefault((t) => t.Id == id);
        }

        public void Insert(Trade trade)
        {
            _tradeList.Add(trade);
        }

        public void Update(Trade trade)
        {
            Delete(trade.Id);

            _tradeList.Add(trade);
        }

        public void Delete(int id)
        {
            var old = _tradeList
                .FirstOrDefault((t) => t.Id == id);

            if (old != null)
            {
                _tradeList.Remove(old);
            }
        }
    }
}
