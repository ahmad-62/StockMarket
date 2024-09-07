using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockMarket.DTOs;
using StockMarket.Helpers.ClaimsExtension;
using StockMarket.Models;
using StockMarket.Services;
using StockMarket.Services.Unit_Of_Work;

namespace StockMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IcommentService commentService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IStockService stockService;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        public CommentController(IcommentService commentService, IUnitOfWork unitOfWork, IStockService stockService, IMapper mapper,UserManager<ApplicationUser> userManager) {
            this.commentService = commentService;
            this.unitOfWork = unitOfWork;
            this.stockService = stockService;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var comments = mapper.Map<IEnumerable<CommentDtoDisplay>>(await commentService.GetAllWithUser());
                return Ok(comments);
            }
            catch (Exception ex) {

                return BadRequest(ex.Message);
            }


        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id) {

            if (!await commentService.ExistsAsync(Id)) {
                return NotFound("This comment isnot found");
            }
            var comment = mapper.Map<CommentDtoDisplay>(await commentService.GetWithUSer(Id));

            return Ok(comment);

        }
        [HttpPost]
        public async Task<IActionResult> create(CommentDto commentDto)
        {
            if (!await stockService.ExistsAsync(commentDto.StockID))
                return NotFound("This Stock Is not Found");
            if (ModelState.IsValid)
            {
                try {
                    var comment = mapper.Map<Comment>(commentDto);
                    var user=await userManager.FindByNameAsync(User.GetuserName());
                    comment.ApplicationuserId = user.Id;
                    await commentService.CreateAsync(comment);
                    await unitOfWork.savechanges();
                    return Ok("created");
                } catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return BadRequest(ModelState);

        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id,CommentDto commentDto)
        {
            if (! await commentService.ExistsAsync(Id))
            {
                return NotFound("This Comment is not found");
            }
            if (!await stockService.ExistsAsync(commentDto.StockID))
            { return NotFound("This Stock Is not Found"); }
            if (ModelState.IsValid)
            {
                try
                {
                   var comment=await commentService.GetAsync(Id);

                    comment=  mapper.Map(commentDto,comment);
                    commentService.Update(comment);
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
        public async  Task<IActionResult> Delete(int Id) {
            if (!await commentService.ExistsAsync(Id))
            {
                return NotFound("This Comment is not found");
            }
            try
            {
                var comment = await commentService.GetAsync(Id);

                commentService.Delete(comment);
                await unitOfWork.savechanges();
                return Ok("Deleted");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }

}
