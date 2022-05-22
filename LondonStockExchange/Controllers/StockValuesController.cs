using LondonStockExchange.Models;
using LondonStockExchange.Services;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockExchange.Controllers
{
    /// <summary>
    /// Stock Values Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class StockValuesController : ControllerBase
    {
        private readonly ITradesService _tradesService;

        public StockValuesController(ITradesService tradesService)
        {
            _tradesService = tradesService;
        }

        // GET: api/<StockValuesController>
        [HttpGet]
        public IList<StockValue> GetAllStockValues()
        {
            return _tradesService.GetAllStockValues();
        }

        // GET: api/<StockValuesController>/A.L;B.L;C.L
        [HttpGet]
        [Route("api/[controller]/{tickers}")]
        public IList<StockValue> GetStockValues([FromRoute] string tickers)
        {
            var tickerList = tickers.Split(";");
            return _tradesService.GetStockValues(tickerList);
        }
    }
}
