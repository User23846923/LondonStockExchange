namespace LondonStockExchange.Models
{
    /// <summary>
    ///  A trade
    /// </summary>
    public class Trade
    {
        public int Id { get; set; }
        public int BrokerId { get; set; }
        public string Ticker { get; set; } = "";
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
    }
}
