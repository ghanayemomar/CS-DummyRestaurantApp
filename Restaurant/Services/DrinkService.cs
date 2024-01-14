using Contracts.Interfaces;
using Domain;
using Contracts.DTO;
using AutoMapper;

namespace BusinessLogic.Services
{
    public class DrinkService : IDrink
    {
        private readonly List<Drink> drinks = new List<Drink>();
        private readonly IMapper _mapper;


        public DrinkService(IMapper mapper)
        {
            _mapper = mapper;
            AddDummyData();
        }
        private void AddDummyData()
        {
            drinks.Add(new Drink { Id = 1, Name = "Cola", Price = 1.99m });
            drinks.Add(new Drink { Id = 2, Name = "Orange Juice", Price = 2.49m });
            drinks.Add(new Drink { Id = 3, Name = "Lemonade", Price = 1.79m });
            drinks.Add(new Drink { Id = 4, Name = "Iced Tea", Price = 1.89m });
            drinks.Add(new Drink { Id = 5, Name = "Water", Price = 0.99m });
        }

        /// 
        public void CreateDrink(CreateDrinkDTO drinkDto)
        {
            var newDrink = _mapper.Map<CreateDrinkDTO, Drink>(drinkDto);

            drinks.Add(newDrink);

        }
        //
        public List<DrinkDTO> RetriveAllDrinks()
        {
            var drinkDtos = _mapper.Map<List<DrinkDTO>>(drinks);
            return drinkDtos;
        }



        public DrinkDTO RetriveDrinkById(int id)
        {
            var drink = drinks.FirstOrDefault(d => d.Id == id);
            if (drink == null)
            {
                return null;
            }
            return _mapper.Map<DrinkDTO>(drink);

        }

        //
        public void UpdateDrink(UpdateDrinkDTO drinkDto)
        {
            var existingDrink = drinks.FirstOrDefault(d => d.Id == drinkDto.Id);
            if (existingDrink != null)
            {
                _mapper.Map(drinkDto, existingDrink);
            }
        }
        //
        public bool DeleteDrink(int id)
        {
            var drinkToRemove = drinks.FirstOrDefault(d => d.Id == id);
            if (drinkToRemove != null)
            {
                drinks.Remove(drinkToRemove);
                return true;
            }
            return false;
        }
        //
        private int GenerateNewId()
        {
            return drinks.Count > 0 ? drinks.Max(d => d.Id) + 1 : 1;
        }
        //
    }
}
