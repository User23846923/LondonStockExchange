using LondonStockExchange.DataLayer;
using LondonStockExchange.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LondonStockExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradesController : ControllerBase
    {
        private readonly ITradeRepository _tradeRepository;

        private readonly ILogger<TradesController> _logger;

        public TradesController(
            ITradeRepository tradeRepository,
            ILogger<TradesController> logger)
        {
            _tradeRepository = tradeRepository;
            _logger = logger;
        }

        // GET: api/<TradesController>
        [HttpGet]
        public IList<Trade> Get()
        {
            return _tradeRepository.GetTrades();
        }

        // GET api/<TradesController>/5
        [HttpGet("{id}")]
        public Trade? Get(int id)
        {
            return _tradeRepository.GetTrade(id);
        }

        // POST api/<TradesController>
        [HttpPost]
        public void Post([FromBody] Trade trade)
        {
            _tradeRepository.Insert(trade);
        }

        // PUT api/<TradesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Trade trade)
        {
            _tradeRepository.Update(trade);
        }

        // DELETE api/<TradesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tradeRepository.Delete(id);
        }
    }
}
