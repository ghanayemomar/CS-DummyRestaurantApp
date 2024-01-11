using Domain;
using Contracts.Interfaces;
using Contracts.DTO;
using AutoMapper;

namespace BusinessLogic.Services
{

    public class FoodService : IFood
    {
        private readonly List<Food> foods = new List<Food>();
        private readonly IMapper _mapper;
        //
        public FoodService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void CreateFood(CreateFoodDTO foodDto)
        {
            var newFood = _mapper.Map<CreateFoodDTO,Food>(foodDto);
            foods.Add(newFood);
        }
        //
        public List<FoodDTO> RetriveAllFoods()
        {
            var FoodsDots = _mapper.Map<List<FoodDTO>>(foods);
            return FoodsDots;
        }
        //
        public FoodDTO RetriveFoodsById(int id)
        {
            var food = foods.FirstOrDefault(f => f.Id == id);
            if (food != null)
            {
                return _mapper.Map<FoodDTO>(food);
            }
            return null;
        }
        //
        public void UpdateFood(UpdateFoodDTO foodDto)
        {
            var existingFood = foods.FirstOrDefault(d => d.Id == foodDto.Id);
            if (existingFood != null)
            {
                _mapper.Map(foodDto, existingFood);
            }
        }
        //
        public bool DeleteFood(int id)
        {
            var foodToRemove = foods.FirstOrDefault(d => d.Id == id);
            if (foodToRemove != null)
            {
                foods.Remove(foodToRemove);
                return true;
            }
            return false;
        }
        private int GenerateNewId()
        {
            return foods.Count > 0 ? foods.Max(d => d.Id) + 1 : 1;
        }
    }
}