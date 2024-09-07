using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockMarket.DTOs;
using StockMarket.Models;
using StockMarket.Services.Account;

namespace StockMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
this.accountService = accountService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Response = await accountService.Register(registerDto);
                if (Response.Result.Succeeded)
                {
                    return Ok(new { Token = Response.Token });

                }
                var Errors = Response.Result.Errors.Select(c => c.Description);
                return StatusCode(500, Errors);
            }


            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> login(LoginDto loginDto)
        {
            try { 
            var user= await accountService.login(loginDto);
            if(user.Result.Succeeded)
                {
                    return Ok(new {Token=user.Token});
                }
            var Errors=user.Result.Errors.Select(x=>x.Description);
                return StatusCode(500, Errors);
            
            
            
            }
            catch (Exception ex) { 
            return StatusCode(500, ex.Message); 
            }

        }
    }
}
