using FinShark.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : Controller
    {

        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStocks()
        {
            var stocks = _context.Stocks.ToList();  

            return Ok(stocks);  
        }

        [HttpGet("{id}")]
        public IActionResult GetStockByID([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);

            if(stock is null)
            {
                return NotFound();
            }

            return Ok(stock);   
        }
    }
}
