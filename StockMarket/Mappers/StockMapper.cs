using AutoMapper;
using StockMarket.DTOs;
using StockMarket.Models;

namespace StockMarket.Mappers
{
    public class StockMapper:Profile
    {
        public StockMapper() {

            CreateMap<Stock, StockDTO>().ReverseMap();
            CreateMap<Stock, StockDtoDisplay>().ForMember(dest=>dest.comments,opt=>opt.MapFrom(src=>src.comments));
        }

    }
}
