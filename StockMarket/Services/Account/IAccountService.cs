using Microsoft.AspNetCore.Identity;
using StockMarket.DTOs;
using StockMarket.Helpers;

namespace StockMarket.Services.Account
{
    public interface IAccountService
    {
        Task<Response> Register(RegisterDto registerDto);
        Task<Response> login(LoginDto loginDto);

    }
}
