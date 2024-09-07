using AutoMapper;
using StockMarket.DTOs;
using StockMarket.Models;

namespace StockMarket.Mappers
{
    public class CommentMapper:Profile
    {
        public CommentMapper() {
            CreateMap<CommentDto, Comment>();

            CreateMap<Comment, CommentDtoDisplay>().ForMember(dest=>dest.createdBy,opt=>opt.MapFrom(src=>src.applicationuser.FullName));

        }
    }
}
