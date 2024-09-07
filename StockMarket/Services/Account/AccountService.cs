using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockMarket.Data;
using StockMarket.DTOs;
using StockMarket.Helpers;
using StockMarket.Models;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace StockMarket.Services.Account
{
    public class AccountService:IAccountService
    {
        private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser>  userManager;
        private readonly ITokenService tokenService;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountService(AppDbContext context,UserManager<ApplicationUser> userManager,ITokenService tokenService,SignInManager<ApplicationUser> signInManager) {
        this.context = context;
        this.userManager = userManager;
        this.tokenService = tokenService;
        this.signInManager = signInManager;
        }

  

        public async Task<Response> Register(RegisterDto registerDto)
        {
            var response=new Response();
            try 
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                    FullName = registerDto.FirstName + " " + registerDto.LastName

                };
                var createdResult = await userManager.CreateAsync(user, registerDto.Password);
                if (!createdResult.Succeeded)
                {
                    response.Result = createdResult;

                    return response;
                }
                var RoleResult = await userManager.AddToRoleAsync(user, "User");
                if (!RoleResult.Succeeded)
                {
                    response.Result= RoleResult;    
                     return  response;
                     

                }
                response.Token= tokenService.CreateToken(user);
                response.Result=IdentityResult.Success;
                return response ;

            }
            catch (Exception ex) {
                response.Result = IdentityResult.Failed(new IdentityError { Description=ex.Message});
                return response;

            }

 }
        public async Task<Response> login(LoginDto loginDto)
        {
            var response= new Response();
            try { 
            var user=await userManager.Users.FirstOrDefaultAsync(x=>x.UserName==loginDto.UserName);
                if (user is null)
                {
                    response.Result = IdentityResult.Failed(new IdentityError { Description = " UserName is invalid" });
                    return response;

                } 
                var result=await signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);
                if (!result.Succeeded)
                {
                    response.Result = IdentityResult.Failed(new IdentityError { Description = "Invalid Password" });
                    return response;
                }
                response.Token = tokenService.CreateToken(user);
                response.Result= IdentityResult.Success;
                return response;
                    
            
            
            
            }
            catch (Exception ex) {
                response.Result = IdentityResult.Failed( new IdentityError { Description = ex.Message } );
                return response;
            
            }
        }


    }
}
