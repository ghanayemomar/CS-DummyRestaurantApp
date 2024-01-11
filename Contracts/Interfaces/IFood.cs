using Contracts.DTO;

namespace Contracts.Interfaces
{
    public interface IFood
    {
        void CreateFood(CreateFoodDTO drink);
        FoodDTO RetriveFoodsById(int id);
        List<FoodDTO> RetriveAllFoods();
        void UpdateFood(UpdateFoodDTO drink);
        bool DeleteFood(int id);

    }
}
