namespace LondonStockExchange.Models
{
    /// <summary>
    /// A rolling volume weighted average price of a Stock
    /// </summary>
    public class StockValue
    {
        public string Ticker { get; set; } = "";
        public decimal AveragePrice { get; set; }
        public decimal SumVolume { get; set; }
        public decimal SumPriceVolume { get; set; }
    }
}
