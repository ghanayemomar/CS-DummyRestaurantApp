using Contracts.Interfaces;
using Domain;
using Contracts.DTO;
using AutoMapper;
using Restaurant;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class DrinkService : IDrink
    {
        private readonly IMapper _mapper;

        private readonly AppDbContext _context;

        public DrinkService(IMapper mapper)
        {
            _mapper = mapper;
            _context = new AppDbContext();
        }

        /// 
        public async Task CreateDrinkAsync(CreateDrinkDTO drinkDto)
        {
            var newDrink = _mapper.Map<CreateDrinkDTO, Drink>(drinkDto);
            _context.Drinks.Add(newDrink);
            await _context.SaveChangesAsync();
        }
        //
        public async Task<List<DrinkDTO>> RetriveAllDrinksAsync()
        {
            var drinks =await _context.Drinks.Where(d=>!d.IsDeleted).ToListAsync();
            var drinkDtos = _mapper.Map<List<DrinkDTO>>(drinks);
            return drinkDtos;
        }
        //
        public async Task<DrinkDTO> RetriveDrinkByIdAsync(int id)
        {
            var item = await  _context.Drinks.FirstOrDefaultAsync(drink => drink.Id == id);
            if (item != null && item.IsDeleted != true)
            {
                return _mapper.Map<DrinkDTO>(item);
            }
            else
            {
                return null;
            }
        }

        //
        public async Task UpdateDrinkAsync(UpdateDrinkDTO drinkDto)
        {
            var existingDrink = await _context.Drinks.FirstOrDefaultAsync(d => d.Id == drinkDto.Id);
            if (existingDrink != null)
            {
                _mapper.Map(drinkDto, existingDrink);
                await _context.SaveChangesAsync();
            }
        }
        //
        public async Task<bool> DeleteDrinkAsync(int id)
        {
            var drinkToRemove = await _context.Drinks.FirstOrDefaultAsync(drink => drink.Id == id);

            if (drinkToRemove != null)
            {
                drinkToRemove.IsDeleted = true; // Soft delete by updating the flag
                await _context.SaveChangesAsync(); // Use asynchronous SaveChanges
                return true;
            }

            return false;
        }

        //
    }
}
