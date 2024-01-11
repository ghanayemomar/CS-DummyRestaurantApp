using AutoMapper;
using Contracts.DTO;
using Domain;

namespace BusinessLogic.Services
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Food, FoodDTO>().ReverseMap();
            CreateMap<Drink, DrinkDTO>().ReverseMap();
            CreateMap<Drink, CreateDrinkDTO>().ReverseMap();
            CreateMap<Drink, UpdateDrinkDTO>().ReverseMap();



        }
    }
}
