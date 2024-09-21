using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _dBContext; 
        public StockController(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _dBContext.Stocks.ToList();

            return Ok(stocks);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var stock = _dBContext.Stocks.Find(id);

            if (stock == null) 
            {
                return NotFound();
            }

            return Ok(stock);
        }


    }
}