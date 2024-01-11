using Contracts.DTO;

namespace Contracts.Interfaces
{
    public interface IDrink
    {
        void CreateDrink(CreateDrinkDTO drink);
        DrinkDTO RetriveDrinkById(int id);
        List<DrinkDTO> RetriveAllDrinks();
        void UpdateDrink(UpdateDrinkDTO drink);
        bool DeleteDrink(int id);
    }
}
