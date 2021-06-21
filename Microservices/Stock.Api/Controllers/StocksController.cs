using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Stock.Api.Entities;
using Stock.Api.Models;
using Stock.Api.Repository;

namespace Stock.Api.Controllers
{

    [EnableCors("CORS-Enabler")]
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        public IStocksRepository _repo;

        public StocksController(IStocksRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("/stocks")]
        public IActionResult GetStockList()
        {
            var result = _repo.getStockExchangesList();
            return Ok(result);
        }

        [HttpPost]
        [Route("/add")]
        public IActionResult AddStockExchange([FromBody]StockExchanges stockExchange)
        {
            _repo.addStockExchange(stockExchange);
            return Ok();
        }

        [HttpGet]
        [Route("/companies/{id}")]
        public IActionResult GetCompaniesList(int id)
        {
            return Ok(_repo.getCompaniesList(id));
        }

        [EnableCors("CORS-Enabler")]
        [HttpPost("/addStocks")]
        public IActionResult AddStock([FromBody]StockPriceModel stockprices)
        {
             return Ok();
        }

    }
}
