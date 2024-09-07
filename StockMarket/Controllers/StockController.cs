using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockMarket.DTOs;
using StockMarket.Models;
using StockMarket.Services;
using StockMarket.Services.Unit_Of_Work;

namespace StockMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService stockService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public StockController(IStockService stockservice,IMapper mapper,IUnitOfWork unitOfWork) {
        this.stockService = stockservice;
        this.mapper = mapper;
           this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            try
            {
                var stocks = mapper.Map<IEnumerable<StockDtoDisplay>>(await stockService.GetStockswithComments());
                return Ok(stocks);
            }
            catch (Exception ex) { 
            return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{Id}")]
           public async Task<IActionResult> Get(int Id) {
            try
            {
                if (!await stockService.ExistsAsync(Id))
                {
                    return NotFound("This stock is not found");
                }
                var stock = mapper.Map<StockDtoDisplay>(await stockService.GetStockWithcomment(Id));

                return Ok(stock);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }
        [HttpPost]
        public async Task<IActionResult> create(StockDTO stockDTO)
        {
            if (ModelState.IsValid)
            {
                try {
                    var stock = mapper.Map<Stock>(stockDTO);
                    await stockService.CreateAsync(stock);
                    await unitOfWork.savechanges();

                    return Ok("created");
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                }

            return BadRequest(ModelState);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id,StockDTO stockDto)
        {
            if (!await  stockService.ExistsAsync(Id))
                return NotFound();

            if (ModelState.IsValid)
            {
                try {
                    var stock = await stockService.GetAsync(Id);

                    mapper.Map(stockDto, stock);
                    stockService.Update(stock);
                    await unitOfWork.savechanges();
                    return Ok("Updated");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                }
            return BadRequest(ModelState);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (!await stockService.ExistsAsync(Id))
                return NotFound();
            try
            {
                var stock = await stockService.GetAsync(Id);

                stockService.Delete(stock);
                await unitOfWork.savechanges();
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
