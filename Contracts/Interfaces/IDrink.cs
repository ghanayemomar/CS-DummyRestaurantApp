using Contracts.DTO;

namespace Contracts.Interfaces
{
    public interface IDrink
    {
        Task CreateDrinkAsync(CreateDrinkDTO drink);
        Task<DrinkDTO> RetriveDrinkByIdAsync(int id);
        Task<List<DrinkDTO>> RetriveAllDrinksAsync();
        Task UpdateDrinkAsync(UpdateDrinkDTO drink);
        Task<bool> DeleteDrinkAsync(int id);
    }
}
