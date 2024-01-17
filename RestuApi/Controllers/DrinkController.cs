using Contracts.DTO;
using Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RestuApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DrinkController : ControllerBase
    {   //
        private readonly IDrink _drink;
        //
        public DrinkController(IDrink drink)
        {
            _drink = drink;
        }
        //
        [HttpPost]
        public async Task CreateDrink([FromBody] CreateDrinkDTO drink)
        {
            _drink.CreateDrinkAsync(drink);
        }
        //
        [HttpGet]
        public async Task<IActionResult> RetriveAllDrinks()
        {
            var result = await _drink.RetriveAllDrinksAsync();
            var finalResult = new DrinkWithTotalPriceDTO()
            {
                Drinks = result,
                TotalPrice = result.Select(d => d.Price).Sum(),
            };
            return Ok(finalResult);
        }
        //
        [HttpGet]
        public async Task<IActionResult> RetriveDrinkById(int id)
        {
            var drink = await _drink.RetriveDrinkByIdAsync(id);
            if (drink == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }
        //
        [HttpDelete]
        public async Task<IActionResult> DeleteDrink(int id)
        {
            var success = await _drink.DeleteDrinkAsync(id);
            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut]
        public async Task UpdateDrink([FromBody] UpdateDrinkDTO drink)
        {
            await _drink.UpdateDrinkAsync(drink);
        }

    }
}
