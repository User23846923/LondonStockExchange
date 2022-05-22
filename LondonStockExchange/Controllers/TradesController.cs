using LondonStockExchange.Models;
using LondonStockExchange.Services;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockExchange.Controllers
{
    /// <summary>
    /// Trades Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class TradesController : ControllerBase
    {
        private readonly ITradesService _tradesService;

        public TradesController(ITradesService tradesService)
        {
            _tradesService = tradesService;
        }

        // POST api/<TradesController>
        [HttpPost]
        public void Post([FromBody] Trade trade)
        {
            _tradesService.InsertTrade(trade);
        }
    }
}
