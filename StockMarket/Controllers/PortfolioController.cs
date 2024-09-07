using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client;
using StockMarket.Helpers.ClaimsExtension;
using StockMarket.Models;
using StockMarket.Services;
using StockMarket.Services.Unit_Of_Work;

namespace StockMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService portfolioService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IStockService stockService;
        private readonly IUnitOfWork unitOfWork;
        public PortfolioController(IPortfolioService portfolioService, UserManager<ApplicationUser> userManager,IStockService stockService, IUnitOfWork unitOfWork) {
            this.portfolioService = portfolioService;
            this.userManager = userManager;
            this.stockService = stockService;
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAsync()
        {
            try
            {

                var Appuser = await userManager.FindByNameAsync(User.GetuserName());
                if (Appuser is null)
                    return BadRequest();

                return Ok(await portfolioService.GetStokcsByuser(Appuser));

            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);

            }

        }
        [HttpPost("{symbol}")]

        public async Task<IActionResult> CreateAsync(string symbol)
        {
            try {

                var Appuser = await userManager.FindByNameAsync(User.GetuserName());
                if (Appuser is null)
                    return BadRequest();
                var stock=await stockService.GeyBySymbol(symbol);
                if(stock is null)
                    return BadRequest("Invalid Stock");
                var userporfilio=await portfolioService.GetStokcsByuser(Appuser);
                if (userporfilio.Any(e => e.Symbol.ToLower() == symbol.ToLower()))
                {
                    return BadRequest("Cannot add same stock to portfolio");
                }
                var CreatedPorfilio = new Protfolio
                {
                    ApplicationuserId = Appuser.Id,
                    StockId = stock.Id,

                };
                await portfolioService.CreateAsync(CreatedPorfilio);
                await unitOfWork.savechanges();
                return Ok("Creatd");


            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);

            }



        }
        [HttpDelete]
        
        public async Task<IActionResult> Delete(string symbol)
        {
            try { 
            
            var appuser=await userManager.FindByNameAsync(User.GetuserName());
                var stock = stockService.GeyBySymbol(symbol);
                if(stock is null)
                {
                    return BadRequest("This Stock is not Found");
                }
                var portfolio=await portfolioService.GetPortoflioofuser(appuser,symbol);
                if(portfolio is null)
                {
                    return BadRequest("there is no portfolio");
                }
                portfolioService.Delete(portfolio);
                await unitOfWork.savechanges();

                return Ok("Deleted");
            
            
            }
            catch (Exception ex) {
            
            return StatusCode(500,ex.Message);
            }


        }
    }

}
